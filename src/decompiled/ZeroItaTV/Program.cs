// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Threading;
using System.Windows.Forms;

namespace ZeroItaTV;

internal static class Program
{
	public static string pr = Application.StartupPath;

	public static string formatorec;

	public static Form1 mio;

	[STAThread]
	private static void Main()
	{
		try
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new Form1());
		}
		catch
		{
		}
	}

	private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
	{
	}
}
