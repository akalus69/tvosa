// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ZeroItaTV.Threadx;

internal class ThreadDbtele
{
	private Form1 mio;

	private ProgrammiTV mio2;

	public ThreadDbtele(Form1 m)
	{
		mio = m;
		mio2 = m.ale;
	}

	private void clearl()
	{
		try
		{
			mio2.listBox1.Items.Clear();
			mio2.listBox2.Items.Clear();
			mio2.listBox3.Items.Clear();
			mio2.listBox4.Items.Clear();
			mio2.listBox5.Items.Clear();
			mio2.listBox6.Items.Clear();
		}
		catch
		{
		}
	}

	private string leggicanale2(string url)
	{
		string result = "";
		try
		{
			Stream stream = null;
			WebRequest webRequest = WebRequest.Create(url);
			WebResponse response = webRequest.GetResponse();
			stream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
			result = streamReader.ReadToEnd();
			streamReader.Close();
			stream.Close();
		}
		catch
		{
		}
		return result;
	}

	public static string EncodeTo64(string toEncode)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(toEncode);
		return Convert.ToBase64String(bytes);
	}

	private string leggicanale(string url)
	{
		// BONIFICA 2026: risoluzione URL mms via pl/ZR.exe rimossa (nessun chiamante, 2026 usa yt-dlp).
		return "";
	}


	private string leggicanale5(string url)
	{
		string text = "";
		try
		{
			string text2 = url.Substring(url.LastIndexOf("=") + 1);
			try
			{
				Stream stream = null;
				WebRequest webRequest = WebRequest.Create("http://videowall.rai.it/cgi-bin/date");
				WebResponse response = webRequest.GetResponse();
				stream = response.GetResponseStream();
				StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
				text = streamReader.ReadToEnd();
				streamReader.Close();
				stream.Close();
			}
			catch
			{
			}
			string text3 = text2 + ";" + text;
			char[] array = text3.ToCharArray();
			string text4 = "";
			int num = 0;
			char[] array2 = array;
			foreach (char value in array2)
			{
				int num2 = Convert.ToInt32(value);
				num2 += num;
				text4 += Convert.ToChar(num2);
				num++;
			}
			string text5 = EncodeTo64(text4);
			Process process = new Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Verb = "tvosagetlab";
			process.StartInfo.FileName = Program.pr + "\\pl\\curl.exe";
			process.StartInfo.Arguments = "-A \"Mozilla/5.0 (Windows; U; Windows NT 6.1; it; rv:1.9.2) Gecko/20100115 Firefox/3.6\" -H \"Connection: keep-alive\" -H \"Keep-Alive: 300\" -H \"viaurl: www.rai.tv\" -H \"ttAuth: " + text5 + "\" -H \"Content-Lenght: 0\" " + url + " --output \"" + Program.pr + "\\pl\\can.txt\"";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			while (!File.Exists(Program.pr + "\\pl\\can.txt"))
			{
				Thread.Sleep(100);
			}
			for (int j = 0; j < 8; j++)
			{
				bool flag = false;
				Process[] processes = Process.GetProcesses();
				foreach (Process process2 in processes)
				{
					if (process2.ProcessName == "curl")
					{
						flag = true;
					}
				}
				if (!flag)
				{
					j = 8;
					break;
				}
				Thread.Sleep(1000);
			}
			StreamReader streamReader2 = new StreamReader(Program.pr + "\\pl\\can.txt");
			string text6 = streamReader2.ReadToEnd();
			streamReader2.Close();
			File.Delete(Program.pr + "\\pl\\can.txt");
			if (text6.IndexOf("HREF=") >= 0)
			{
				text6 = text6.Substring(text6.IndexOf("HREF=") + 6);
				text = text6.Substring(0, text6.IndexOf("\""));
			}
		}
		catch
		{
		}
		return text;
	}

	private string leggicanale4(string url)
	{
		string result = "";
		try
		{
			Process process = new Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Verb = "tvosagetlab";
			process.StartInfo.FileName = Program.pr + "\\pl\\wget.exe";
			process.StartInfo.Arguments = "--header=\"viaurl: www.rai.tv\" " + url + " -q --output-document=\"" + Program.pr + "\\pl\\can.txt\" - ";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			while (!File.Exists(Program.pr + "\\pl\\can.txt"))
			{
				Thread.Sleep(100);
			}
			for (int i = 0; i < 8; i++)
			{
				bool flag = false;
				Process[] processes = Process.GetProcesses();
				foreach (Process process2 in processes)
				{
					if (process2.ProcessName == "wget")
					{
						flag = true;
					}
				}
				if (!flag)
				{
					i = 8;
					break;
				}
				Thread.Sleep(1000);
			}
			StreamReader streamReader = new StreamReader(Program.pr + "\\pl\\can.txt");
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			File.Delete(Program.pr + "\\pl\\can.txt");
			if (text.IndexOf("HREF=") >= 0)
			{
				text = text.Substring(text.IndexOf("HREF=") + 6);
				result = text.Substring(0, text.IndexOf("\""));
			}
		}
		catch
		{
		}
		return result;
	}

	private string leggicanale3(string url)
	{
		string result = "";
		try
		{
			Process.Start(Program.pr + "\\pl\\wget.exe", "--header=\"viaurl: www.rai.tv\" " + url + " -q --output-document=\"" + Program.pr + "\\pl\\can.txt\" - ");
			while (!File.Exists(Program.pr + "\\pl\\can.txt"))
			{
				Thread.Sleep(100);
			}
			Thread.Sleep(8000);
			StreamReader streamReader = new StreamReader(Program.pr + "\\pl\\can.txt");
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			File.Delete(Program.pr + "\\pl\\can.txt");
			if (text.IndexOf("HREF=") >= 0)
			{
				text = text.Substring(text.IndexOf("HREF=") + 6);
				result = text.Substring(0, text.IndexOf("\""));
			}
		}
		catch
		{
		}
		return result;
	}

	public void particanale(string x)
	{
		try
		{
			string[] files = Directory.GetFiles(Program.pr + "\\pl\\tmp");
			string[] array = files;
			foreach (string text in array)
			{
				if (text.IndexOf(".bat") > 0)
				{
					try
					{
						File.Delete(text);
					}
					catch (Exception)
					{
					}
				}
			}
			Process process = new Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.WorkingDirectory = Program.pr + "\\pl\\tmp";
			process.StartInfo.Verb = "tvosaraifiv";
			string fileName = creafilebatregistrazionex(x);
			process.StartInfo.FileName = fileName;
			process.StartInfo.UseShellExecute = false;
			process.Start();
			Thread.Sleep(48000);
			process.Kill();
			process.CloseMainWindow();
		}
		catch (Exception)
		{
		}
	}

	private string creafilebatregistrazionex(string ch)
	{
		string text = "";
		try
		{
			if (!Directory.Exists(Program.pr + "\\pl\\tmp"))
			{
				Directory.CreateDirectory(Program.pr + "\\pl\\tmp");
			}
			for (int i = 0; i < 100; i++)
			{
				if (!File.Exists(Program.pr + "\\pl\\tmp\\tmp" + i + ".bat"))
				{
					text = Program.pr + "\\pl\\tmp\\tmp" + i + ".bat";
					break;
				}
			}
			StreamWriter streamWriter = new StreamWriter(text);
			streamWriter.WriteLine("set \"head=viaurl: www.rai.tv\"");
			streamWriter.WriteLine("set \"vuoto=2>nul\"");
			if (mio.tipoprocessore == "x86")
			{
				streamWriter.WriteLine("set \"vlc=c:\\progra~1\\videolan\\vlc\\vlc\"");
			}
			else
			{
				streamWriter.WriteLine("set \"vlc=c:\\progra~2\\videolan\\vlc\\vlc\"");
			}
			if (mio.checkBox1.Checked)
			{
				streamWriter.WriteLine("call curl -H \"%head%\" \"" + ch + "\" %vuoto% | %vlc% -f -");
			}
			else
			{
				streamWriter.WriteLine("call curl -H \"%head%\" \"" + ch + "\" %vuoto% | %vlc% -");
			}
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
		return text;
	}

	public void guardav()
	{
		string text = mio.label1.Text;
		try
		{
			mio.canaleselezionato = int.Parse(text);
		}
		catch (Exception)
		{
		}
		try
		{
			if (!mio.aspettasionoperpartirefilm)
			{
				for (int i = 0; i < 10; i++)
				{
					Thread.Sleep(300);
				}
			}
			else
			{
				Thread.Sleep(500);
			}
		}
		catch (Exception)
		{
		}
		IList<string> list = new List<string>();
		if (text == "00000" || text == "11111")
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\nvda");
			streamWriter.Close();
			mio.panel2.Visible = true;
		}
		try
		{
			bool flag = true;
			StreamReader streamReader = new StreamReader(Program.pr + "\\propriotel.txt");
			string text2 = "";
			while ((text2 = streamReader.ReadLine()) != null)
			{
				list.Add(text2);
			}
			streamReader.Close();
			bool flag2 = false;
			bool flag3 = false;
			string text3 = "";
			bool flag4 = false;
			string text4 = "";
			foreach (string item in list)
			{
				string text5 = text;
				if (text.Length == 0)
				{
					text = mio.canaleselezionato.ToString();
				}
				if (item.Substring(0, item.IndexOf(" ")).CompareTo(text) != 0)
				{
					continue;
				}
				flag2 = true;
				string text6 = "";
				text4 = item.Substring(item.IndexOf(")") + 2);
				string text7 = "";
				switch (text4.ToLowerInvariant())
				{
				case "rai 1":
					if (mio.raiunoweb && !string.IsNullOrEmpty(mio.raiunow))
					{
						flag3 = true;
						text3 = mio.raiunow;
					}
					text6 = "http://www.mymovies.it/tv/raiuno/";
					text7 = ((!mio.raiunovlcr) ? mio.raiuno : mio.raiuno);
					break;
				case "rai 2":
					if (mio.raidueweb && !string.IsNullOrEmpty(mio.raiduew))
					{
						flag3 = true;
						text3 = mio.raiduew;
					}
					text6 = "http://www.mymovies.it/tv/raidue/";
					text7 = ((!mio.raiduevlcr) ? mio.raidue : mio.raidue);
					break;
				case "rai 3":
					if (mio.raitreweb && !string.IsNullOrEmpty(mio.raitrew))
					{
						flag3 = true;
						text3 = mio.raitrew;
					}
					text6 = "http://www.mymovies.it/tv/raitre/";
					text7 = ((!mio.raitrevlcr) ? mio.raitre : "trex");
					break;
				case "rete 4":
					if (mio.retequattroweb && !string.IsNullOrEmpty(mio.quattrow))
					{
						flag3 = true;
						text3 = mio.quattrow;
					}
					text6 = "http://www.mymovies.it/tv/rete4/";
					text7 = mio.quattro;
					break;
				case "canale 5":
					if (mio.canalecinqueweb && !string.IsNullOrEmpty(mio.cinquew))
					{
						flag3 = true;
						text3 = mio.cinquew;
					}
					text6 = "http://www.mymovies.it/tv/canale5/";
					text7 = mio.cinque;
					break;
				case "italia 1":
					if (mio.italiaunoweb && !string.IsNullOrEmpty(mio.italia1w))
					{
						flag3 = true;
						text3 = mio.italia1w;
					}
					text6 = "http://www.mymovies.it/tv/italia1/";
					text7 = mio.italia1;
					break;
				default:
					try
					{
						flag = true;
						StreamReader streamReader2 = new StreamReader(Program.pr + "\\nuovicanali.txt");
						string text8 = "";
						text4 = item.Substring(item.IndexOf(" ") + 1);
						while ((text8 = streamReader2.ReadLine()) != null)
						{
							if (text8.CompareTo(text4) == 0)
							{
								string text9 = streamReader2.ReadLine();
								if (text9.IndexOf("|<-->|") > 0)
								{
									text3 = text9.Substring(text9.IndexOf("|<-->|") + 6);
									flag3 = true;
									text9 = text9.Substring(0, text9.IndexOf("|<-->|"));
								}
								text7 = "--http-user-agent=\"VLC media player - version 1.0.5 Goldeneye - (c) 1996-2010 the VideoLAN team\" -vvv " + text9;
							}
						}
						streamReader.Close();
						text4 = item.Substring(item.IndexOf(")") + 2);
						switch (text4.ToLowerInvariant())
						{
						case "rai 4":
							if (!mio.raiecono)
							{
								flag3 = false;
								text7 = mio.raieconostringavlc;
							}
							if (mio.raieconovlcr)
							{
								text7 = mio.raieconostringavlc;
							}
							text6 = "http://www.mymovies.it/tv/rai4/";
							break;
						case "rai 5":
							if (!mio.raicinque)
							{
								flag3 = false;
								text7 = mio.raicinquestringavlc;
							}
							if (mio.raicinquevlcr)
							{
								text7 = mio.raicinquestringavlc;
							}
							text6 = "http://www.mymovies.it/tv/rai5/";
							break;
						case "sport italia":
							text6 = "http://www.mymovies.it/tv/sportitalia/";
							break;
						case "rai sport":
							if (!mio.raisport)
							{
								flag3 = false;
								text7 = mio.raisportstringavlc;
							}
							if (mio.raisportvlcr)
							{
								text7 = mio.raisportstringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raisport1/";
							break;
						case "rai sport 2":
							if (!mio.raisport2)
							{
								flag3 = false;
								text7 = mio.raisport2stringavlc;
							}
							if (mio.raisport2vlcr)
							{
								text7 = mio.raisport2stringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raisport1/";
							break;
						case "rai news 24":
							text6 = "http://www.mymovies.it/tv/rainews24/";
							break;
						case "rai cinema":
							if (!mio.raicinema)
							{
								flag3 = false;
								text7 = mio.raicinemastringavlc;
							}
							if (mio.raicinemavlcr)
							{
								text7 = mio.raicinemastringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raisatcinema/";
							break;
						case "raisat premium":
							if (!mio.raisatpr)
							{
								flag3 = false;
								text7 = mio.raisatprmstringavlc;
							}
							if (mio.raisatprvlcr)
							{
								text7 = mio.raisatprmstringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raisatpremium/";
							break;
						case "rai storia":
							if (mio.raistoriavlcr)
							{
								flag3 = false;
								text7 = mio.raistoriastringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raistoria/";
							break;
						case "rai scuola":
							if (!mio.raiscuola)
							{
								flag3 = false;
								text7 = mio.raiscuolastringavlc;
							}
							if (mio.raiscuolavlcr)
							{
								text7 = mio.raiscuolastringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raiscuola/";
							break;
						case "rai gulp":
							if (!mio.raigulp)
							{
								flag3 = false;
								text7 = mio.raigulpstringavlc;
							}
							if (mio.raigulpvlcr)
							{
								text7 = mio.raigulpstringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raigulp/";
							break;
						case "rai sat yoyo":
							if (!mio.raiyoyo)
							{
								flag3 = false;
								text7 = mio.raiyoyostringavlc;
							}
							if (mio.raiyoyovlcr)
							{
								text7 = mio.raiyoyostringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raisatyoyo/";
							break;
						case "rai sat extra":
							if (!mio.raisatextra)
							{
								text7 = mio.raisatexstringavlc;
								flag3 = false;
							}
							if (mio.raisatextravlcr)
							{
								text7 = mio.raisatexstringavlc;
							}
							text6 = "http://www.mymovies.it/tv/raisatextra/";
							break;
						case "tv 2000":
							text6 = "http://www.mymovies.it/tv/sat2000/";
							break;
						case "euro sport":
							text6 = "http://www.mymovies.it/tv/eurosport/";
							break;
						case "la 7(WEB)":
							text6 = "http://www.mymovies.it/tv/la7/";
							break;
						case "la 7":
							text6 = "http://www.mymovies.it/tv/la7/";
							text7 = "la 7";
							break;
						case "7 gold":
							text6 = "http://www.mymovies.it/tv/7gold/";
							break;
						case "deejay tv":
							text6 = "http://www.mymovies.it/tv/deejaytv/";
							break;
						case "odeon tv":
							text6 = "http://www.mymovies.it/tv/odeon/";
							break;
						case "cielo":
							text6 = "http://www.mymovies.it/tv/cielo/";
							text7 = "cielo";
							break;
						case "cielo web":
							text6 = "http://www.mymovies.it/tv/cielo/";
							break;
						case "rsi la 1":
							text6 = "http://la1.rsi.ch/home/networks/la1/palinsesto.html";
							text7 = "RSI1";
							break;
						case "rsi la 2":
							text6 = "http://la2.rsi.ch/home/networks/la2/palinsesto.html";
							text7 = "RSI2";
							break;
						default:
							flag = false;
							break;
						}
					}
					catch
					{
					}
					break;
				}
				int num = int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString());
				int num2 = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
				if (mio.Location.X < num2 - mio.Size.Width - 5)
				{
					mio.Location = new Point(num2 - mio.Size.Width - 5, mio.Location.Y);
				}
				if (!flag3)
				{
					if (text7 != mio.raiuno && text7 != mio.raidue && text7 != mio.raieconostringavlc && text7 != mio.raicinemastringavlc && text7 != mio.raicinquestringavlc && text7 != mio.raieconostringavlc && text7 != mio.raigulpstringavlc && text7 != mio.raisatexstringavlc && text7 != mio.raisatprmstringavlc && text7 != mio.raiscuolastringavlc && text7 != mio.raisport2stringavlc && text7 != mio.raisportstringavlc && text7 != mio.raistoriastringavlc && text7 != mio.raiyoyostringavlc && text7 != mio.raieconostringavlc && text7 != "trex" && text7 != mio.quattro && text7 != mio.cinque && text7 != mio.italia1 && text7 != "cielo" && text7 != "la 7" && text7 != "RSI1" && text7 != "RSI2")
					{
						if (mio.checkBox1.Checked)
						{
							Process.Start(mio.vlc, "-f " + text7);
						}
						else
						{
							Process.Start(mio.vlc, text7);
						}
					}
					else
					{
						try
						{
							Process process = new Process();
							process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
							process.StartInfo.Verb = "tvosarai";
							if (text7 == mio.raiuno)
							{
								if (mio.checkBox1.Checked)
								{
									process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\unof.bat";
								}
								else
								{
									process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\uno.bat";
								}
							}
							else if (text7 == mio.raidue)
							{
								if (mio.checkBox1.Checked)
								{
									process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\duef.bat";
								}
								else
								{
									process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\due.bat";
								}
							}
							else
							{
								switch (text7)
								{
								case "trex":
									if (mio.checkBox1.Checked)
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\tref.bat";
									}
									else
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\tre.bat";
									}
									break;
								case "cielo":
									if (mio.checkBox1.Checked)
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\cief.bat";
									}
									else
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\cie.bat";
									}
									break;
								case "RSI1":
									if (mio.checkBox1.Checked)
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\ri1f.bat";
									}
									else
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\ri1.bat";
									}
									break;
								case "RSI2":
									if (mio.checkBox1.Checked)
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\ri2f.bat";
									}
									else
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\ri2.bat";
									}
									break;
								case "la 7":
									if (mio.checkBox1.Checked)
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\la7f.bat";
									}
									else
									{
										process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\la7.bat";
									}
									break;
								default:
									if (text7 == mio.quattro)
									{
										if (mio.checkBox1.Checked)
										{
											process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\quaf.bat";
										}
										else
										{
											process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\qua.bat";
										}
									}
									else if (text7 == mio.cinque)
									{
										if (mio.checkBox1.Checked)
										{
											process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\cinf.bat";
										}
										else
										{
											process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\cin.bat";
										}
									}
									else if (text7 == mio.italia1)
									{
										if (mio.checkBox1.Checked)
										{
											process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\itaf.bat";
										}
										else
										{
											process.StartInfo.FileName = Program.pr + "\\pl\\" + mio.tipoprocessore + "\\ita.bat";
										}
									}
									else
									{
										particanale(text7);
									}
									break;
								}
							}
							process.StartInfo.UseShellExecute = false;
							process.StartInfo.CreateNoWindow = true;
							process.Start();
						}
						catch (Exception)
						{
						}
					}
				}
				else
				{
					if (mio.justinalwaysx && text3.IndexOf("justin.") >= 0)
					{
						string text10 = "";
						try
						{
							Stream stream = null;
							string text11 = "";
							WebRequest webRequest = WebRequest.Create(text3);
							WebResponse response = webRequest.GetResponse();
							stream = response.GetResponseStream();
							StreamReader streamReader3 = new StreamReader(stream, Encoding.UTF8);
							text10 = streamReader3.ReadToEnd();
							streamReader3.Close();
							stream.Close();
						}
						catch (Exception)
						{
						}
						try
						{
							text10 = text10.Substring(text10.IndexOf("<b>Codice</b>"));
							text10 = text10.Substring(text10.IndexOf("value="));
							text10 = text10.Substring(text10.IndexOf("\"") + 1);
							string text12 = text10.Substring(0, text10.IndexOf("\""));
							text12 = text12.Replace("&lt;", "<");
							text12 = text12.Replace("&gt;", ">");
							text12 = text12.Replace("&quot;", "\"");
							int num3 = mio.TVweb.Height - 100;
							int num4 = mio.TVweb.Width - 30;
							string text13 = text12.Substring(0, text12.IndexOf("height="));
							text13 = text13 + "height=\"" + num3 + "\"";
							string text14 = text12.Substring(text12.IndexOf("height="));
							text14 = text14.Substring(text14.IndexOf("\"") + 1);
							string text15 = text14;
							text14 = text14.Substring(0, text14.IndexOf("width="));
							text15 = text15.Substring(text15.IndexOf("width="));
							text15 = text15.Substring(text15.IndexOf("\"") + 1);
							text15 = text15.Substring(text15.IndexOf("\"") + 1);
							text12 = text13 + text14 + "width=\"" + num4 + "\"" + text15;
							text12 = text12.Replace("auto_play=false", "auto_play=true");
							if (text12.IndexOf("</object>") >= 0)
							{
								text12 = text12.Substring(0, text12.IndexOf("</object>") + 9);
							}
							StreamWriter streamWriter = new StreamWriter(Program.pr + "\\tmpjustin");
							streamWriter.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"DTD/xhtml1-transitional.dtd\">");
							streamWriter.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
							streamWriter.WriteLine("<body>");
							streamWriter.WriteLine(text12);
							streamWriter.WriteLine("<a href=\"" + text3 + "\" target=\"_blank\">Apri pagina justin con Webbrowser predefinito</a>");
							streamWriter.WriteLine("</body>");
							streamWriter.WriteLine("</html>");
							streamWriter.Close();
							text3 = Program.pr + "\\tmpjustin";
						}
						catch
						{
						}
					}
					if (mio.aspettasionoperpartirefilm && mio.multipliwebtv)
					{
						mio.TVwebprov.guarda(text3);
						mio.TVwebprov.mostra();
						mio.usatomultipli = true;
					}
					else
					{
						mio.TVweb.guarda(text3);
						mio.TVweb.mostra();
					}
				}
				if (!string.IsNullOrEmpty(text6))
				{
					if (!flag)
					{
						list.Clear();
						int num5 = 0;
						if (DateTime.Now.Hour < 6)
						{
							num5 = -1;
						}
						string text16 = "";
						try
						{
							Stream stream = null;
							string text11 = "";
							WebRequest webRequest = WebRequest.Create(((num5 != 0) ? (text6 + "ieri/") : text6));
							((HttpWebRequest)webRequest).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0 Safari/537.36";
							WebResponse response = webRequest.GetResponse();
							stream = response.GetResponseStream();
							StreamReader streamReader3 = new StreamReader(stream, Encoding.UTF8);
							text16 = streamReader3.ReadToEnd();
							streamReader3.Close();
							stream.Close();
						}
						catch (Exception)
						{
						}
						string text17 = text16;
						// BONIFICA 2026: parser palinsesto mymovies markup attuale
						string[] arrayx = text16.Split(new string[1] { "schedine-separa" }, StringSplitOptions.None);
						for (int bx = 0; bx < arrayx.Length; bx++)
						{
							MatchCollection matchCollection3 = Regex.Matches(arrayx[bx], "calendario2[^>]*>\\s*<div[^>]*></div>\\s*([0-9]{1,2}:[0-9]{2})\\s*<div");
							MatchCollection matchCollection4 = Regex.Matches(arrayx[bx], "schedine-titolo\\\">\\s*([^<]+?)\\s*</div>");
							int count2 = Math.Min(matchCollection3.Count, matchCollection4.Count);
							for (int k2 = 0; k2 < count2; k2++)
							{
								string text18 = matchCollection3[k2].Groups[1].Value;
								string text20 = Regex.Replace(WebUtility.HtmlDecode(matchCollection4[k2].Groups[1].Value), "\\s+", " ").Trim();
								list.Add(text18 + " " + text20);
							}
						}
						DateTime now = DateTime.Now;
						int num6 = 0;
						foreach (string item2 in list)
						{
							string text18 = item2.Substring(0, item2.IndexOf(" "));
							int num7 = int.Parse(text18.Substring(0, text18.IndexOf(":")));
							int num8 = int.Parse(text18.Substring(text18.IndexOf(":") + 1));
							if ((num7 < 6 || now.Hour >= 6) && (now.Hour < num7 || (now.Hour == num7 && now.Minute < num8)))
							{
								break;
							}
							num6++;
						}
						if (num6 > 0)
						{
							num6--;
						}
						int num9 = 0;
						num9 = ((num6 != list.Count) ? (num6 + 1) : 0);
						string text21 = list[num9].Substring(0, list[num9].IndexOf(" "));
						mio.label1.Text = text4 + Environment.NewLine + list[num6].Substring(0, list[num6].IndexOf(" ")) + " - " + text21 + Environment.NewLine + list[num6].Substring(list[num6].IndexOf(" ") + 1);
						break;
					}
					try
					{
						List<string> list2 = new List<string>();
						IList<string> list3 = new List<string>();
						bool flag5 = true;
						if (text6.IndexOf("movies") >= 0)
						{
							DateTime now2 = DateTime.Now;
							if (now2.Hour < 5)
							{
								now2 = now2.AddDays(-1.0);
								string text22 = now2.Day.ToString();
								string text23 = now2.Month.ToString();
								if (now2.Day < 10)
								{
									text22 = "0" + text22;
								}
								if (now2.Month < 10)
								{
									text23 = "0" + text23;
								}
							}
							string text16 = "";
							try
							{
								Stream stream = null;
								WebRequest webRequest = WebRequest.Create(text6);
							((HttpWebRequest)webRequest).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0 Safari/537.36";
								WebResponse response = webRequest.GetResponse();
								stream = response.GetResponseStream();
								StreamReader streamReader3 = new StreamReader(stream, Encoding.UTF8);
								text16 = streamReader3.ReadToEnd();
								streamReader3.Close();
								stream.Close();
							}
							catch (Exception)
							{
							}
							string text17 = text16;
							string text24 = "";
							string text25 = "";
							string text26 = "";
							if (text16.IndexOf("<table style=\"width:100%\" class=\"struttura") >= 0)
						{
							text16 = text16.Substring(text16.IndexOf("<table style=\"width:100%\" class=\"struttura"));
						}
						// BONIFICA 2026: parser mymovies markup attuale
						string[] arrayy = text16.Split(new string[1] { "schedine-separa" }, StringSplitOptions.None);
						for (int by = 0; by < arrayy.Length; by++)
						{
							MatchCollection matchCollection5 = Regex.Matches(arrayy[by], "calendario2[^>]*>\\s*<div[^>]*></div>\\s*([0-9]{1,2}:[0-9]{2})\\s*<div");
							MatchCollection matchCollection6 = Regex.Matches(arrayy[by], "schedine-titolo\\\">\\s*([^<]+?)\\s*</div>");
							int count3 = Math.Min(matchCollection5.Count, matchCollection6.Count);
							for (int k3 = 0; k3 < count3; k3++)
							{
								string text27 = matchCollection5[k3].Groups[1].Value.Replace(":", ".");
								string text20 = Regex.Replace(WebUtility.HtmlDecode(matchCollection6[k3].Groups[1].Value), "\\s+", " ").Trim();
								list2.Add(text27 + ":" + text20);
							}
						}
						}
						else
						{
							flag5 = false;
							string text16 = "";
							try
							{
								mio.docux = "";
								mio.webBrowser1.Navigate(text6);
								while (mio.docux.IndexOf("</html>") < 0)
								{
									Thread.Sleep(1000);
								}
								text16 = mio.docux;
							}
							catch (Exception)
							{
							}
							while (text16.IndexOf("<div class=\"date\"") > 0)
							{
								text16 = text16.Substring(text16.IndexOf("<div class=\"date\"") + 1);
								text16 = text16.Substring(text16.IndexOf(">") + 1);
								string text27 = text16.Substring(0, text16.IndexOf("<"));
								text27 = text27.Trim();
								if (text27.Length > 2)
								{
									text16 = text16.Substring(text16.IndexOf("<li class=\"title\"") + 1);
									text16 = text16.Substring(text16.IndexOf(">") + 1);
									string text20 = text16.Substring(0, text16.IndexOf("<"));
									text20 = text20.Trim();
									text27 = text27.Replace(":", ".");
									list2.Add(text27 + ":" + text20);
								}
							}
						}
						for (int i = 0; i < list2.Count; i++)
						{
							string text29 = list2[i].Substring(0, list2[i].IndexOf(":"));
							string text30 = list2[i].Substring(list2[i].IndexOf(":") + 1);
							if (i < list2.Count - 1)
							{
								string text31 = list2[i + 1].Substring(0, list2[i + 1].IndexOf(":"));
								list3.Add(text29 + " - " + text31 + " : " + text30);
							}
							else
							{
								list3.Add(text29 + " - 06.00 : " + text30);
							}
						}
						try
						{
							int num10 = 0;
							foreach (string item3 in list3)
							{
								string text32 = item3.ToString();
								string text33 = text32.Substring(0, text32.IndexOf("-") - 1).Replace(".", ":");
								int num11 = int.Parse(text33.Substring(0, text33.IndexOf(":")));
								int num8 = int.Parse(text33.Substring(text33.IndexOf(":") + 1));
								DateTime now3 = DateTime.Now;
								if (num11 < 5 || now3.Hour >= 5)
								{
									if (flag5 && num11 < 5 && now3.Hour >= 5)
									{
										break;
									}
									if (now3.Hour == num11)
									{
										if (now3.Minute < num8)
										{
											break;
										}
									}
									else if (now3.Hour < num11)
									{
										break;
									}
								}
								num10++;
							}
							if (num10 > 0)
							{
								num10--;
							}
							mio.label1.Text = text4 + Environment.NewLine + Environment.NewLine + list3[num10];
						}
						catch
						{
						}
					}
					catch
					{
						mio.label1.Text = text4;
					}
				}
				else
				{
					mio.label1.Text = text4;
				}
				break;
			}
			if (!flag2)
			{
				MessageBox.Show("Attenzione, canale selezionato non esistente");
				mio.label1.Text = "";
				return;
			}
			// BONIFICA 2026: contatore pubblicitario 2011 dell'autore, morto
			mio.TVweb.webBrowser2.Navigate("about:blank");
			if (mio.opzionipubblicita)
			{
				Thread.Sleep(2000);
				// BONIFICA 2026: pagina ads 2011 dell'autore, morta
				mio.TVweb.webBrowser2.Navigate("about:blank");
				mio.TVweb.docwb2 = "";
				string text34 = "";
				Random random = new Random();
				switch (random.Next(45))
				{
				case 0:
					text34 = "asus";
					break;
				case 1:
					text34 = "auto";
					break;
				case 2:
					text34 = "auto online";
					break;
				case 3:
					text34 = "banche on line";
					break;
				case 4:
					text34 = "banche online";
					break;
				case 5:
					text34 = "cadillac suv";
					break;
				case 6:
					text34 = "car auto";
					break;
				case 7:
					text34 = "computer";
					break;
				case 8:
					text34 = "computer desktop";
					break;
				case 9:
					text34 = "computer portatili";
					break;
				case 10:
					text34 = "computer shop";
					break;
				case 11:
					text34 = "computer software";
					break;
				case 12:
					text34 = "computer store";
					break;
				case 13:
					text34 = "finanziamenti on line";
					break;
				case 14:
					text34 = "finanziamenti online";
					break;
				case 15:
					text34 = "finanziamenti personali";
					break;
				case 16:
					text34 = "for mesothelioma";
					break;
				case 17:
					text34 = "free";
					break;
				case 18:
					text34 = "giochi cellulare";
					break;
				case 19:
					text34 = "gps";
					break;
				case 20:
					text34 = "hotel italia";
					break;
				case 21:
					text34 = "immagini auto";
					break;
				case 22:
					text34 = "mesothelioma";
					break;
				case 23:
					text34 = "mobile";
					break;
				case 24:
					text34 = "mobile phones";
					break;
				case 25:
					text34 = "n95";
					break;
				case 26:
					text34 = "nokia";
					break;
				case 27:
					text34 = "notebook";
					break;
				case 28:
					text34 = "phones";
					break;
				case 29:
					text34 = "pleural mesothelioma";
					break;
				case 30:
					text34 = "prestito banca";
					break;
				case 31:
					text34 = "project management software";
					break;
				case 32:
					text34 = "sms";
					break;
				case 33:
					text34 = "software";
					break;
				case 34:
					text34 = "software backup";
					break;
				case 35:
					text34 = "software business";
					break;
				case 36:
					text34 = "software business plan";
					break;
				case 37:
					text34 = "software free";
					break;
				case 38:
					text34 = "software gratis";
					break;
				case 39:
					text34 = "software newsletter";
					break;
				case 40:
					text34 = "software project";
					break;
				case 41:
					text34 = "software windows";
					break;
				case 42:
					text34 = "soldi";
					break;
				case 43:
					text34 = "rai";
					break;
				case 44:
					text34 = "sport";
					break;
				}
				text34 = text34.Replace(" ", "+");
				// BONIFICA 2026: ricerca CSE con vecchio AdSense dell'autore, sostituita da ricerca Google pulita
				mio.TVweb.webBrowser2.Navigate("https://www.google.com/search?q=" + text34 + "&hl=it");
				while (mio.TVweb.docwb2.ToLowerInvariant().IndexOf("</html") < 0)
				{
					Thread.Sleep(1000);
				}
				string docwb = mio.TVweb.docwb2;
				Pubblicit linkn = new Pubblicit();
				Pubblicit linkn2 = new Pubblicit();
				trovalinkpubblicita(docwb, out linkn, out linkn2);
				if (!(linkn.nome != "") && !(linkn2.nome != ""))
				{
					return;
				}
				if (linkn.nome != "")
				{
					mio.TVweb.ln1 = linkn;
					mio.TVweb.button5.Text = linkn.nome;
					mio.TVweb.button5.Visible = true;
					if (random.Next(5) == 0)
					{
						mio.TVweb.button5.ForeColor = Color.Orange;
					}
					else
					{
						mio.TVweb.button5.ForeColor = Color.White;
					}
				}
				else
				{
					mio.TVweb.button5.Visible = false;
				}
				if (linkn2.nome != "")
				{
					mio.TVweb.ln2 = linkn2;
					mio.TVweb.button6.Text = linkn2.nome;
					mio.TVweb.button6.Visible = true;
					if (random.Next(7) == 0)
					{
						mio.TVweb.button6.ForeColor = Color.Orange;
					}
					else
					{
						mio.TVweb.button6.ForeColor = Color.White;
					}
				}
				else
				{
					mio.TVweb.button6.Visible = false;
				}
				mio.TVweb.groupBox1.Visible = true;
			}
			else
			{
				mio.TVweb.splitContainer2.SplitterDistance = 700;
				mio.TVweb.groupBox1.Visible = false;
			}
		}
		catch
		{
			mio.label1.Text = "";
		}
	}

	private string trasf(string nnome)
	{
		string text = "";
		nnome = nnome.Replace("&#8211;", "");
		nnome = nnome.Replace("&#8220;", "");
		nnome = nnome.Replace("&#8230;", "");
		nnome = nnome.Replace("&#220;", "");
		nnome = nnome.Replace("&#8212;", "");
		nnome = nnome.Replace("&#8221;", "");
		nnome = nnome.Replace("&#8217;", "'");
		nnome = nnome.Replace("&#8222;", "");
		nnome = nnome.Replace("&#038;", "");
		nnome = nnome.Replace("&#039;", "'");
		nnome = nnome.Replace("&#215;", "X");
		nnome = nnome.Replace("&#176;", "X");
		nnome = nnome.Replace("&#39;", "'");
		nnome = nnome.Replace("&#39", "");
		nnome = nnome.Replace("#39;", "'");
		nnome = nnome.Replace("&#039;", "");
		nnome = nnome.Replace("&#160;", "");
		nnome = nnome.Replace("&Egrave;", "è");
		nnome = nnome.Replace("&egrave;", "è");
		nnome = nnome.Replace("\r", "");
		nnome = nnome.Replace("/t", "");
		nnome = nnome.Replace("\t", "");
		nnome = nnome.Replace("->", "");
		nnome = nnome.Replace("<-", "");
		nnome = nnome.Replace("--", "");
		nnome = nnome.Replace("  ", "");
		nnome = nnome.Replace("</a>", " ");
		nnome = nnome.Replace("</h3>", "");
		nnome = nnome.Replace("</p>", ",");
		nnome = nnome.Replace("<p>", "° ");
		nnome = nnome.Replace("<br/>", "° ");
		nnome = nnome.Replace("<br>", "° ");
		nnome = nnome.Replace("<br />", "° ");
		nnome = nnome.Replace("<div class=\"liveViewers\">", "");
		nnome = nnome.Replace("&nbsp;", "");
		nnome = nnome.Replace("&bull;", "");
		nnome = nnome.Replace("amp;", "");
		nnome = nnome.Replace("\n", "");
		nnome = nnome.Replace("/r", "");
		nnome = nnome.Replace("/n", "");
		nnome = nnome.Replace("gggg", "");
		return nnome;
	}

	private void trovalinkpubblicita(string doc, out Pubblicit linkn, out Pubblicit linkn2)
	{
		linkn = new Pubblicit();
		linkn2 = new Pubblicit();
		try
		{
			if (doc.IndexOf("<b>Annunci Google") > 0)
			{
				doc = doc.Substring(doc.IndexOf("<b>Annunci Google"));
				doc = doc.Substring(doc.IndexOf("href=") + 5);
				string text = doc.Substring(0, doc.IndexOf("\""));
				text = "http://www.google.it" + text;
				doc = doc.Substring(doc.IndexOf(">") + 1);
				string nnome = doc.Substring(0, doc.IndexOf("<"));
				doc = doc.Substring(doc.IndexOf("&nbsp;") + 1);
				doc = doc.Substring(doc.IndexOf("&nbsp;") + 1);
				doc = doc.Substring(doc.IndexOf("&nbsp;") + 6);
				string text2 = doc.Substring(0, doc.IndexOf("<"));
				text2 = text2.Trim();
				nnome = trasf(nnome);
				text2 = trasf(text2);
				linkn.nome = nnome;
				linkn.extra = text2;
				linkn.link = text;
				doc = doc.Substring(doc.IndexOf("href=") + 5);
				text = doc.Substring(0, doc.IndexOf("\""));
				text = "http://www.google.it" + text;
				doc = doc.Substring(doc.IndexOf(">") + 1);
				nnome = doc.Substring(0, doc.IndexOf("<"));
				doc = doc.Substring(doc.IndexOf("&nbsp;") + 1);
				doc = doc.Substring(doc.IndexOf("&nbsp;") + 1);
				doc = doc.Substring(doc.IndexOf("&nbsp;") + 6);
				text2 = doc.Substring(0, doc.IndexOf("<"));
				text2 = text2.Trim();
				nnome = trasf(nnome);
				text2 = trasf(text2);
				linkn2.nome = nnome;
				linkn2.extra = text2;
				linkn2.link = text;
			}
		}
		catch (Exception)
		{
		}
	}

	public void vaitutti(int canx)
	{
		try
		{
			ListBox listBox = null;
			string text = "";
			switch (canx)
			{
			case 1:
				listBox = mio2.listBox1;
				text = "http://www.mymovies.it/tv/raiuno/";
				break;
			case 2:
				listBox = mio2.listBox2;
				text = "http://www.mymovies.it/tv/raidue/";
				break;
			case 3:
				listBox = mio2.listBox3;
				text = "http://www.mymovies.it/tv/raitre/";
				break;
			case 4:
				listBox = mio2.listBox4;
				text = "http://www.mymovies.it/tv/rete4/";
				break;
			case 5:
				listBox = mio2.listBox5;
				text = "http://www.mymovies.it/tv/canale5/";
				break;
			case 6:
				listBox = mio2.listBox6;
				text = "http://www.mymovies.it/tv/italia1/";
				break;
			}
			DateTime now = DateTime.Now;
			string text2 = "";
			if (now.Day != mio2.dateTimePicker1.Value.Day)
			{
				now = mio2.dateTimePicker1.Value;
				text2 = "?g=" + now.Day + now.Month + now.Year;
			}
			Stream stream = null;
			string requestUriString = text + text2;
			WebRequest webRequest = WebRequest.Create(requestUriString);
			WebResponse response = webRequest.GetResponse();
			stream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
			string text3 = streamReader.ReadToEnd();
			streamReader.Close();
			stream.Close();
			string text4 = text3;
			string text5 = "";
			string text6 = "";
			string text7 = "";
			listBox.Items.Clear();
			while (text3.IndexOf("<td style=\"width:5%;\">") >= 0)
			{
				text3 = text3.Substring(text3.IndexOf("<td style=\"width:5%;\">") + 2);
				text4 = text3;
				if (text4.IndexOf("<td style=\"width:5%;\">") >= 0)
				{
					text4 = text4.Substring(0, text4.IndexOf("<td style=\"width:5%;\">"));
				}
				text4 = text4.Substring(text4.IndexOf(">") + 1);
				string text8 = text4.Substring(0, text4.IndexOf("<"));
				text8 = text8.Replace(",", ":");
				if (text7 != "")
				{
					listBox.Items.Add(text7 + " - " + text8 + " : " + text6);
				}
				if (text4.IndexOf("<a class=\"linktabella\" style=\"font-size:100%;") >= 0)
				{
					text4 = text4.Substring(text4.IndexOf("<a class=\"linktabella\" style=\"font-size:100%;") + 7);
					text4 = text4.Substring(text4.IndexOf("b>") + 2);
				}
				else
				{
					text4 = text4.Substring(text4.IndexOf("<span style=\"letter-spacing: 1px;\">") + 7);
					text4 = text4.Substring(text4.IndexOf("<span style=\"letter-spacing: 1px;\">") + 7);
					text4 = text4.Substring(text4.IndexOf(">") + 1);
				}
				string text9 = text4.Substring(0, text4.IndexOf("<"));
				text9 = text9.Replace("&quot;", "\"");
				if (text3.IndexOf("<td style=\"width:5%;\">") >= 0)
				{
					text3 = text3.Substring(text3.IndexOf("<td style=\"width:5%;\">") + 2);
					text4 = text3;
					if (text4.IndexOf("<td style=\"width:5%;\">") >= 0)
					{
						text4 = text4.Substring(0, text4.IndexOf("<td style=\"width:5%;\">"));
					}
					text4 = text4.Substring(text4.IndexOf(">") + 1);
					text7 = text4.Substring(0, text4.IndexOf("<"));
					text7 = text7.Replace(",", ":");
					if (text4.IndexOf("<a class=\"linktabella\" style=\"font-size:100%;") >= 0)
					{
						text4 = text4.Substring(text4.IndexOf("<a class=\"linktabella\" style=\"font-size:100%;") + 7);
						text4 = text4.Substring(text4.IndexOf("b>") + 2);
					}
					else
					{
						text4 = text4.Substring(text4.IndexOf("<span style=\"letter-spacing: 1px;\">") + 7);
						text4 = text4.Substring(text4.IndexOf("<span style=\"letter-spacing: 1px;\">") + 7);
						text4 = text4.Substring(text4.IndexOf(">") + 1);
					}
					text6 = text4.Substring(0, text4.IndexOf("<"));
					text6 = text6.Replace("&quot;", "\"");
					listBox.Items.Add(text8 + " - " + text7 + " : " + text9);
				}
			}
			if (text2 == "")
			{
				mio2.programmaattuale();
			}
		}
		catch
		{
		}
	}

	public void vai()
	{
		try
		{
			clearl();
			int num = 0;
			DateTime now = DateTime.Now;
			if (now.Month == mio2.dateTimePicker1.Value.Month)
			{
				num = mio2.dateTimePicker1.Value.Day - now.Day;
			}
			// BONIFICA 2026: fonte palinsesti lospettacolo.it morta (404). Ora mymovies.it, markup 2026.
			string text2 = mio2.dateTimePicker1.Value.Day + "_" + mio2.dateTimePicker1.Value.Month + "_" + mio2.dateTimePicker1.Value.Year;
			mio2.progressBar1.Value = 0;
			mio2.progressBar1.Maximum = 6;
			string[] array = new string[6] { "https://www.mymovies.it/tv/raiuno/", "https://www.mymovies.it/tv/raidue/", "https://www.mymovies.it/tv/raitre/", "https://www.mymovies.it/tv/rete4/", "https://www.mymovies.it/tv/canale5/", "https://www.mymovies.it/tv/italia1/" };
			if (num >= 1)
			{
				string suffix = ((num != 1) ? "dopodomani/" : "domani/");
				for (int k = 0; k < 6; k++)
				{
					array[k] = array[k] + suffix;
				}
			}
			int num2 = 0;
			foreach (string item in array)
			{
				num2++;
				WebRequest webRequest = WebRequest.Create(item);
				((HttpWebRequest)webRequest).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0 Safari/537.36";
				WebResponse response = webRequest.GetResponse();
				Stream stream = response.GetResponseStream();
				StreamReader streamReader2 = new StreamReader(stream, Encoding.UTF8);
				string text5 = streamReader2.ReadToEnd();
				streamReader2.Close();
				stream.Close();
				string[] array2 = text5.Split(new string[1] { "schedine-separa" }, StringSplitOptions.None);
				for (int b = 0; b < array2.Length; b++)
				{
					MatchCollection matchCollection = Regex.Matches(array2[b], "calendario2[^>]*>\\s*<div[^>]*></div>\\s*([0-9]{1,2}:[0-9]{2})\\s*<div");
					MatchCollection matchCollection2 = Regex.Matches(array2[b], "schedine-titolo\\\">\\s*([^<]+?)\\s*</div>");
					int count = Math.Min(matchCollection.Count, matchCollection2.Count);
					for (int k = 0; k < count; k++)
					{
						string text6 = matchCollection[k].Groups[1].Value;
						string text8 = Regex.Replace(WebUtility.HtmlDecode(matchCollection2[k].Groups[1].Value), "\\s+", " ").Trim();
						string text7 = "";
						if (num2 == 1)
						{
							mio2.listBox1.Items.Add(text6 + " " + text8 + "                                                             |||" + text7);
						}
						if (num2 == 2)
						{
							mio2.listBox2.Items.Add(text6 + " " + text8 + "                                                             |||" + text7);
						}
						if (num2 == 3)
						{
							mio2.listBox3.Items.Add(text6 + " " + text8 + "                                                             |||" + text7);
						}
						if (num2 == 4)
						{
							mio2.listBox4.Items.Add(text6 + " " + text8 + "                                                             |||" + text7);
						}
						if (num2 == 5)
						{
							mio2.listBox5.Items.Add(text6 + " " + text8 + "                                                             |||" + text7);
						}
						if (num2 == 6)
						{
							mio2.listBox6.Items.Add(text6 + " " + text8 + "                                                             |||" + text7);
						}
					}
				}
				mio2.progressBar1.PerformStep();
			}
			mio2.settapl(mio2.listBox1, Program.pr + "\\" + text2 + "\\rai1.txt");
			mio2.settapl(mio2.listBox2, Program.pr + "\\" + text2 + "\\rai2.txt");
			mio2.settapl(mio2.listBox3, Program.pr + "\\" + text2 + "\\rai3.txt");
			mio2.settapl(mio2.listBox5, Program.pr + "\\" + text2 + "\\cinque.txt");
			mio2.settapl(mio2.listBox4, Program.pr + "\\" + text2 + "\\quattro.txt");
			mio2.settapl(mio2.listBox6, Program.pr + "\\" + text2 + "\\italia.txt");
			mio2.programmaattuale();
		}
		catch
		{
			clearl();
			string text2 = mio2.dateTimePicker1.Value.Day + "_" + mio2.dateTimePicker1.Value.Month + "_" + mio2.dateTimePicker1.Value.Year;
			mio2.progressBar1.Value = 0;
			mio2.secondaconf = true;
			for (int i = 1; i < 7; i++)
			{
				vaitutti(i);
				mio2.progressBar1.PerformStep();
			}
			mio2.programmaattuale();
			mio2.settapl(mio2.listBox1, Program.pr + "\\" + text2 + "\\rai1.txt");
			mio2.settapl(mio2.listBox2, Program.pr + "\\" + text2 + "\\rai2.txt");
			mio2.settapl(mio2.listBox3, Program.pr + "\\" + text2 + "\\rai3.txt");
			mio2.settapl(mio2.listBox5, Program.pr + "\\" + text2 + "\\cinque.txt");
			mio2.settapl(mio2.listBox4, Program.pr + "\\" + text2 + "\\quattro.txt");
			mio2.settapl(mio2.listBox6, Program.pr + "\\" + text2 + "\\italia.txt");
			text2 = mio2.dateTimePicker1.Value.AddDays(1.0).Day + "_" + mio2.dateTimePicker1.Value.AddDays(1.0).Month + "_" + mio2.dateTimePicker1.Value.AddDays(1.0).Year;
			mio2.settapl(mio2.listBox1, Program.pr + "\\" + text2 + "\\rai1.txt");
			mio2.settapl(mio2.listBox2, Program.pr + "\\" + text2 + "\\rai2.txt");
			mio2.settapl(mio2.listBox3, Program.pr + "\\" + text2 + "\\rai3.txt");
			mio2.settapl(mio2.listBox5, Program.pr + "\\" + text2 + "\\cinque.txt");
			mio2.settapl(mio2.listBox4, Program.pr + "\\" + text2 + "\\quattro.txt");
			mio2.settapl(mio2.listBox6, Program.pr + "\\" + text2 + "\\italia.txt");
		}
	}
}