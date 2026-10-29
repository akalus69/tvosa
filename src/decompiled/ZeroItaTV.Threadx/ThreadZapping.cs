// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace ZeroItaTV.Threadx;

internal class ThreadZapping
{
	private Zapping mio;

	public ThreadZapping(Zapping m)
	{
		mio = m;
	}

	public void apriopz()
	{
		try
		{
			mio.groupBox4.Enabled = false;
			mio.listBox1.Size = new Size(mio.listBox1.Size.Width, 69);
			while (mio.Size.Height < 438)
			{
				mio.Location = new Point(mio.Location.X, mio.Location.Y - 3);
				mio.Size = new Size(mio.Size.Width, mio.Size.Height + 3);
				Thread.Sleep(1);
			}
			mio.groupBox4.Enabled = true;
		}
		catch (Exception)
		{
			mio.Size = new Size(457, 437);
			mio.groupBox4.Enabled = true;
		}
	}

	public void chiudiopz()
	{
		try
		{
			mio.groupBox4.Enabled = false;
			mio.listBox1.Size = new Size(mio.listBox1.Size.Width, 17);
			while (mio.Size.Height > 148)
			{
				mio.Location = new Point(mio.Location.X, mio.Location.Y + 3);
				mio.Size = new Size(mio.Size.Width, mio.Size.Height - 3);
				Thread.Sleep(1);
			}
			mio.groupBox4.Enabled = true;
		}
		catch (Exception)
		{
			mio.Size = new Size(457, 147);
			mio.groupBox4.Enabled = true;
		}
	}

	public void vai()
	{
		Thread.Sleep(2000);
		Process[] processes = Process.GetProcesses();
		try
		{
			int num = 0;
			try
			{
				if (!string.IsNullOrEmpty(mio.listBox1.SelectedItem.ToString()))
				{
					num = mio.listBox1.SelectedIndex;
				}
			}
			catch (Exception)
			{
			}
			while (true)
			{
				bool flag = true;
				Thread.Sleep(1000);
				if (mio.radioButton3.Checked)
				{
					Random random = new Random();
					num = random.Next(mio.listBox1.Items.Count);
				}
				string text = mio.listBox1.Items[num].ToString();
				if (!mio.radioButton3.Checked)
				{
					num++;
				}
				if (num > mio.listBox1.Items.Count)
				{
					num = 0;
				}
				mio.listBox1.SelectedItem = text;
				if (text != "(Rai) Rai 1" && text != "(Rai) Rai 2" && text != "(Rai) Rai 3" && text != "(Mediaset) Italia 1" && text != "(Mediaset) Canale 5" && text != "(Mediaset) Rete 4")
				{
					try
					{
						StreamReader streamReader = new StreamReader(Program.pr + "\\nuovicanali.txt");
						string text2 = "";
						int num2 = 0;
						List<string> list = new List<string>();
						while ((text2 = streamReader.ReadLine()) != null)
						{
							if (!(text2 == text))
							{
								continue;
							}
							string text3 = streamReader.ReadLine();
							int num3;
							int num4;
							if (text3.IndexOf("|<-->|") >= 0)
							{
								text3 = text3.Substring(text3.LastIndexOf(">|") + 2);
								mio.mio.TVweb.guarda(text3);
								mio.mio.TVweb.Show();
								mio.mio.TVweb.Opacity = 1.0;
								num3 = int.Parse(mio.comboBox1.SelectedItem.ToString());
								num4 = 0;
								while (num4 < num3)
								{
									num4++;
									num3 = int.Parse(mio.comboBox1.SelectedItem.ToString());
									Thread.Sleep(1000);
								}
								while (mio.pausa)
								{
									Thread.Sleep(1000);
								}
								mio.mio.TVweb.Hide();
								mio.mio.TVweb.Opacity = 0.0;
								mio.mio.TVweb.webBrowser1.Navigate("");
								continue;
							}
							mio.mio.TVweb.Hide();
							mio.mio.TVweb.Opacity = 0.0;
							mio.mio.TVweb.webBrowser1.Navigate("");
							processes = Process.GetProcesses();
							if (mio.mio.checkBox1.Checked)
							{
								Process.Start(mio.mio.vlc, "-f " + text3);
							}
							else
							{
								Process.Start(mio.mio.vlc, text3);
							}
							Process[] processes2 = Process.GetProcesses();
							bool flag2 = false;
							Process process = null;
							Process[] array = processes2;
							foreach (Process process2 in array)
							{
								bool flag3 = false;
								if (process2.ProcessName.IndexOf("vlc") < 0)
								{
									continue;
								}
								Process[] array2 = processes;
								foreach (Process process3 in array2)
								{
									if (process2.Id == process3.Id)
									{
										flag3 = true;
									}
								}
								if (!flag3)
								{
									flag2 = true;
									process = process2;
								}
							}
							num3 = int.Parse(mio.comboBox1.SelectedItem.ToString());
							num4 = 0;
							while (num4 < num3)
							{
								num4++;
								num3 = int.Parse(mio.comboBox1.SelectedItem.ToString());
								Thread.Sleep(1000);
							}
							while (mio.pausa)
							{
								Thread.Sleep(1000);
							}
							if (flag2)
							{
								process.Kill();
							}
						}
						streamReader.Close();
					}
					catch
					{
					}
				}
				while (mio.pausa)
				{
					Thread.Sleep(1000);
				}
			}
		}
		catch (Exception)
		{
			try
			{
				if (!mio.avantiindi)
				{
					mio.mio.TVweb.Hide();
					mio.mio.TVweb.Opacity = 0.0;
				}
				else
				{
					mio.avantiindi = true;
				}
				mio.mio.TVweb.webBrowser1.Navigate("");
				Process[] processes2 = Process.GetProcesses();
				bool flag2 = false;
				Process process = null;
				Process[] array = processes2;
				foreach (Process process2 in array)
				{
					bool flag3 = false;
					if (process2.ProcessName.IndexOf("vlc") < 0)
					{
						continue;
					}
					Process[] array2 = processes;
					foreach (Process process3 in array2)
					{
						if (process2.Id == process3.Id)
						{
							flag3 = true;
						}
					}
					if (!flag3)
					{
						flag2 = true;
						process = process2;
					}
				}
				if (flag2)
				{
					process.Kill();
				}
			}
			catch
			{
			}
		}
	}
}
