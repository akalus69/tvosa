// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ZeroItaTV.Threadx;

internal class ThreadVLC
{
	private Form1 mio;

	private bool trovato = false;

	public ThreadVLC(Form1 m)
	{
		mio = m;
	}

	private void vlctrova(string xx)
	{
		try
		{
			string[] files = Directory.GetFiles(xx);
			foreach (string text in files)
			{
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Name.ToLowerInvariant().CompareTo("vlc.exe") == 0)
				{
					mio.vlc = text;
					trovato = true;
					mio.scrivivlc(text);
				}
			}
			if (trovato)
			{
				return;
			}
			files = Directory.GetDirectories(xx);
			foreach (string text in files)
			{
				if (text.ToLowerInvariant().IndexOf("video") >= 0 || text.ToLowerInvariant().IndexOf("vlc") >= 0)
				{
					vlctrova(text);
				}
			}
		}
		catch
		{
		}
	}

	public void vai()
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		folderPath = folderPath.Substring(0, folderPath.IndexOf("\\") + 1);
		string[] directories = Directory.GetDirectories(folderPath);
		foreach (string xx in directories)
		{
			vlctrova(xx);
		}
		if (!trovato && DialogResult.Yes == MessageBox.Show("Il programma non ha trovato vlc, si vuole scaricarlo? (se lo si ha gia installato in 1 directory particolare si puo' settare manualmente", "Attenzione", MessageBoxButtons.YesNo))
		{
			Process.Start("http://www.videolan.org/vlc/");
			MessageBox.Show("Ricordati di chiudere e riaprire il programma dopo aver installato VLC oppure setta manualmente la direcotry di installazione di VLC");
		}
	}
}
