# TvOsa - TV On SmartfOne App
# Copyright (C) 2011-2026 akalus69
# Licenza GNU GPLv3 - vedi LICENSE
#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
tvosa_find.py — sidecar "Dove vedo un film stasera" per la finestra TROVA FILM.
Riusa find_film() del bridge MCP (stessa identica logica agente/UI).
Uso: py -3.13 tvosa_find.py "<titolo>" [PAESE]   (default IT)
Output: testo leggibile su stdout.
"""
import json
import os
import sys

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
sys.stdout.reconfigure(encoding="utf-8")
from tvosa_mcp import find_film  # noqa: E402

ORDINE = ["GRATIS (con pubblicita)", "gratis (on demand gratuito)", "in abbonamento", "noleggio", "acquisto", "al cinema"]


def stampa_disp(disp):
    if not disp:
        return
    printed = set()
    for tipo in ORDINE:
        if tipo in disp:
            printed.add(tipo)
            print("   %s:" % tipo.upper())
            for p in disp[tipo]:
                print("      - %s" % p)
    for extra in disp:
        if extra not in printed:
            print("   %s:" % extra.upper())
            for p in disp[extra]:
                print("      - %s" % p)


def main():
    args = [a for a in sys.argv[1:] if a != "--json"]
    raw = "--json" in sys.argv[1:]
    if not args or not args[0].strip():
        print("Digita un titolo da cercare.")
        return
    title = args[0].strip()
    country = (args[1] if len(args) > 1 else "IT").upper()
    text, err = find_film(title, country)
    if raw:
        # mode server: stdout = JSON grezzo del motore (o errore JSON-ish)
        print(text if err else json.dumps(json.loads(text), ensure_ascii=False))
        return
    if err:
        print(text)
        return
    try:
        d = json.loads(text)
    except ValueError:
        print(text)
        return
    risultati = d.get("risultati") or []
    if len(risultati) > 1:
        print("Trovati %d titoli disponibili (catalogo %s):" % (len(risultati), d.get("paese_catalogo")))
        for i, r in enumerate(risultati, 1):
            print("\n[%d] %s (%s) — %s" % (i, r.get("titolo"), r.get("anno"), r.get("tipo")))
            stampa_disp(r.get("disponibilita") or {})
    elif risultati:
        r = risultati[0]
        print("RISULTATO: %s (%s) — %s — catalogo %s" % (r.get("titolo"), r.get("anno"), r.get("tipo"), d.get("paese_catalogo")))
        stampa_disp(r.get("disponibilita") or {})
    else:
        print("RISULTATO: %s (%s) — catalogo %s" % (d.get("titolo"), d.get("anno"), d.get("paese_catalogo")))
        print("\nNON disponibile oggi in %s (ne' abbonamento, ne' gratis, ne' noleggio)." % d.get("paese_catalogo"))
    alt = [a for a in (d.get("alternative_cercate") or []) if a]
    if alt:
        print("\nAltri titoli simili (non disponibili oggi): " + " | ".join(alt))
    print("\n(Disponibilita' di oggi: i cataloghi cambiano ogni giorno.)")


if __name__ == "__main__":
    main()