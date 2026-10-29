// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Diagnostics;
using System.IO;

namespace ZeroItaTV.Threadx;

// Motore di registrazione 2026: sidecar Python tools\tvosa_recorder.py
// (yt-dlp su sorgenti ufficiali RaiPlay/RSI). Sostituisce down.exe/VLC-sout
// del 2011. Avvio: Start(url, cartella, nome) attende TVOSA_REC_STARTED.
// Fermo: Stop() scrive 'stop' sullo stdin; il sidecar finalizza e remuxa.
internal class RecorderService
{
	private Process proc;

	public bool IsRecording
	{
		get
		{
			try
			{
				return proc != null && !proc.HasExited;
			}
			catch
			{
				return false;
			}
		}
	}

	public bool Start(string url, string outdir, string nomeBase, out string error)
	{
		error = "";
		try
		{
			string script = Program.pr + "\\tools\\tvosa_recorder.py";
			if (!File.Exists(script))
			{
				error = "tvosa_recorder.py non trovato in tools\\";
				return false;
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo("py", "-3.13 \"" + script + "\" \"" + outdir + "\" \"" + nomeBase + "\" \"" + url + "\"");
			processStartInfo.WorkingDirectory = Program.pr;
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.CreateNoWindow = true;
			proc = Process.Start(processStartInfo);
			string line;
			while ((line = proc.StandardOutput.ReadLine()) != null)
			{
				if (line.StartsWith("TVOSA_REC_STARTED"))
				{
					return true;
				}
				if (line.StartsWith("TVOSA_REC_ERROR"))
				{
					error = line;
					Stop();
					return false;
				}
			}
			error = "sidecar terminato in modo inatteso";
			return false;
		}
		catch (Exception ex)
		{
			error = ex.Message;
			return false;
		}
	}

	public void Stop()
	{
		try
		{
			if (IsRecording)
			{
				proc.StandardInput.WriteLine("stop");
				proc.StandardInput.Flush();
				proc.WaitForExit(180000);
			}
		}
		catch
		{
		}
	}
}