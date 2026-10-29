# TvOsa - TV On SmartfOne App
# Copyright (C) 2011-2026 akalus69
# Licenza GNU GPLv3 - vedi LICENSE
#!/usr/bin/env python3
"""TVOSA recorder sidecar v3 — registra una diretta HLS (RaiPlay ecc.) via yt-dlp.

Uso:  py -3.13 tvosa_recorder.py <dir_output> <nome_base> <url>
Stop: scrivere una riga 'stop' (o 'q') sullo stdin del processo.

Meccanica verificata sperimentalmente (2026-10-28):
- yt-dlp CLI lanciato in console NUOVA nascosta; il fermo avviene inviando
  un VERO CTRL_C_EVENT alla sua console (AttachConsole + GenerateConsoleCtrlEvent).
- Il Ctrl-C arriva contemporaneamente a yt-dlp e al suo ffmpeg: ffmpeg finalizza
  il flusso TS in modo pulito, yt-dlp esce lasciando <nome>.ts.part NON rinominato.
- Il sidecar quindi: protegge se stesso dal Ctrl-C (SIG_IGN temporaneo), aspetta
  l'uscita del figlio, rinomina .part -> .ts, e remuxa in .mp4 (se ffmpeg c'e').
- Il container reale del live HLS e' MPEG-TS: chiamarlo .mp4 lo rende solo
  meta' riproducibile dai player (motivo del 'video da 3 secondi').
"""
import ctypes
import os
import signal
import subprocess
import sys
import threading
import time

CREATE_NEW_CONSOLE = 0x00000010
STARTF_USESHOWWINDOW = 0x0001
SW_HIDE = 0
CTRL_C_EVENT = 0

kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)

stop_evt = threading.Event()


def stdin_watch():
    for line in sys.stdin:
        if line.strip().lower() in ("stop", "q"):
            stop_evt.set()
            return


def send_ctrl_c_to_console_of(pid):
    """Invia CTRL_C_EVENT alla console del processo `pid`, sopravvivendovi."""
    kernel32.FreeConsole()
    if not kernel32.AttachConsole(pid):
        print("TVOSA_REC_ATTACH_FAIL err=" + str(ctypes.get_last_error()), flush=True)
        return False
    prev = signal.signal(signal.SIGINT, signal.SIG_IGN)  # non uccidere noi stessi
    kernel32.SetConsoleCtrlHandler(None, True)
    ok = bool(kernel32.GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0))
    time.sleep(0.4)
    kernel32.SetConsoleCtrlHandler(None, False)
    signal.signal(signal.SIGINT, prev)
    kernel32.FreeConsole()
    return ok


def finalize(outdir: str, name: str) -> str:
    """Rinomina il .part prodotto (una variante qualsiasi) -> .ts e prova il remux in .mp4."""
    import glob
    ts = os.path.join(outdir, name + ".ts")
    final = ts
    parts = sorted(glob.glob(os.path.join(outdir, name + "*.part")),
                   key=os.path.getsize, reverse=True)
    if parts:
        if os.path.exists(ts):
            os.remove(ts)
        os.replace(parts[0], ts)
        for old in parts[1:]:  # scarti piccoli di tentativi multipli
            try:
                os.remove(old)
            except OSError:
                pass
    elif not os.path.exists(ts):
        # yt-dlp potrebbe aver gia' finalizzato con altra estensione
        for ext in ("mp4", "mkv", "webm"):
            cand = os.path.join(outdir, name + "." + ext)
            if os.path.exists(cand):
                return cand
        return ""
    mp4 = os.path.join(outdir, name + ".mp4")
    try:
        subprocess.run(
            ["ffmpeg", "-hide_banner", "-loglevel", "error", "-y",
             "-i", ts, "-c", "copy", mp4],
            check=True, timeout=600)
        os.remove(ts)
        final = mp4
    except Exception:  # ffmpeg assente o remux fallito: teniamo il .ts
        pass
    return final


def main():
    if len(sys.argv) != 4:
        print("uso: tvosa_recorder.py <outdir> <nome_base> <url>", flush=True)
        sys.exit(2)
    outdir, name, url = sys.argv[1], sys.argv[2], sys.argv[3]
    os.makedirs(outdir, exist_ok=True)
    outtmpl = os.path.join(outdir, name + ".ts")

    si = subprocess.STARTUPINFO()
    si.dwFlags |= STARTF_USESHOWWINDOW
    si.wShowWindow = SW_HIDE

    cmd = [
        sys.executable, "-m", "yt_dlp",
        "--no-warnings", "--quiet", "--no-progress",
        "--concurrent-fragments", "4",
        "--newline",
        "-o", outtmpl,
        url,
    ]
    child = subprocess.Popen(  # pyright: ignore[reportCallIssue]
        cmd, creationflags=CREATE_NEW_CONSOLE, startupinfo=si,
        stdin=subprocess.DEVNULL,
    )
    print("TVOSA_REC_STARTED", flush=True)

    threading.Thread(target=stdin_watch, daemon=True).start()
    while not stop_evt.wait(0.5):
        if child.poll() is not None:
            break

    if stop_evt.is_set() and child.poll() is None:
        print("TVOSA_REC_STOPPING", flush=True)
        if not send_ctrl_c_to_console_of(child.pid):
            child.terminate()
        try:
            child.wait(timeout=25)
        except subprocess.TimeoutExpired:
            # il TS e' append-safe: il kill brutale non perde dati,
            # sara' finalize() a rinominare/remuxare correttamente
            subprocess.run(["taskkill", "/T", "/F", "/PID", str(child.pid)],
                           capture_output=True)
            time.sleep(1)

    final = finalize(outdir, name)
    if final:
        print("TVOSA_REC_FILE=" + final, flush=True)
        print("TVOSA_REC_DONE", flush=True)
    else:
        print("TVOSA_REC_ERROR nessun file prodotto", flush=True)
        sys.exit(1)


if __name__ == "__main__":
    main()