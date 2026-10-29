// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class RecTv : Form
{
	public bool normale = true;

	private IList<string> listalettac = new List<string>();

	private IList<string> listareg = new List<string>();

	private IList<string> listareg1 = new List<string>();

	private IList<string> listareg2 = new List<string>();

	private IList<string> listareg3 = new List<string>();

	private IList<string> listareg4 = new List<string>();

	private IList<string> listareg5 = new List<string>();

	private IList<string> listareg6 = new List<string>();

	private bool palinsesto = false;

	public Form1 mio;

	public string urlpal = "";

	private IContainer components = null;

	private Label label2;

	private Label label1;

	private Label label3;

	private Button button1;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private ListBox listBox1;

	private Label label4;

	private Label label5;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem rimuovereToolStripMenuItem;

	private Button button2;

	private GroupBox groupBox3;

	public ListBox listBox2;

	public DateTimePicker dateTimePicker1;

	private Label label6;

	private WebBrowser webBrowser1;

	public ComboBox comboBox1;

	public TextBox textBox1;

	public TextBox textBox2;

	public TextBox textBox3;

	public ComboBox comboBox2;

	public RecTv(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	private void leggimionvc()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\nuovicanali.txt");
			string text = "";
			List<string> list = new List<string>();
			while ((text = streamReader.ReadLine()) != null)
			{
				listalettac.Add(text);
				list.Add(text);
				text = streamReader.ReadLine();
				listalettac.Add(text);
			}
			streamReader.Close();
			list.Sort();
			foreach (string item in list)
			{
				comboBox1.Items.Add(item);
			}
		}
		catch
		{
		}
	}

	public void trovaora()
	{
		try
		{
			int num = 0;
			foreach (object item in listBox2.Items)
			{
				string text = item.ToString();
				string text2 = text.Substring(0, text.IndexOf("-") - 1).Replace(".", ":");
				int num2 = int.Parse(text2.Substring(0, text2.IndexOf(":")));
				int num3 = int.Parse(text2.Substring(text2.IndexOf(":") + 1));
				DateTime now = DateTime.Now;
				if (num2 < 5 || now.Hour >= 5)
				{
					if (now.Hour == num2)
					{
						if (now.Minute < num3)
						{
							break;
						}
					}
					else if (now.Hour < num2)
					{
						break;
					}
				}
				num++;
			}
			if (num > 0)
			{
				num--;
			}
			listBox2.SelectedItem = listBox2.Items[num];
		}
		catch (Exception)
		{
		}
	}

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + Program.mio.linguaprogramma + "RECX.txt");
			string text = streamReader.ReadToEnd();
			string text2 = text;
			streamReader.Close();
			if (text2.IndexOf("groupBox1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox1.Text = text3;
			}
			if (text2.IndexOf("groupBox2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox2.Text = text3;
			}
			if (text2.IndexOf("groupBox3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox3.Text = text3;
			}
			if (text2.IndexOf("label2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label2.Text = text3;
			}
			if (text2.IndexOf("label1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label1.Text = text3;
			}
			if (text2.IndexOf("label3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label3.Text = text3;
			}
			if (text2.IndexOf("label6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label6.Text = text3;
			}
			if (text2.IndexOf("label5") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label5"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label5.Text = text3;
			}
			if (text2.IndexOf("label4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label4.Text = text3;
			}
			if (text2.IndexOf("button1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button1.Text = text3;
			}
			if (text2.IndexOf("button2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button2.Text = text3;
			}
		}
		catch
		{
		}
	}

	private void RecTv_Load(object sender, EventArgs e)
	{
		cambialing();
		webBrowser1.ScriptErrorsSuppressed = true;
		groupBox3.Visible = false;
		webBrowser1.Visible = false;
		comboBox2.SelectedIndex = 0;
		try
		{
			if (normale)
			{
				ThreadCapo threadCapo = new ThreadCapo(this);
				Thread thread = new Thread(threadCapo.componi);
				thread.IsBackground = true;
				thread.Priority = ThreadPriority.BelowNormal;
				thread.Start();
				DateTime now = DateTime.Now;
				textBox1.Text = now.Hour + ":" + now.Minute;
				now = now.AddMinutes(30.0);
				textBox2.Text = now.Hour + ":" + now.Minute;
			}
			else
			{
				Opacity = 1.0;
			}
		}
		catch
		{
		}
		try
		{
			DateTime value = dateTimePicker1.Value;
		}
		catch
		{
		}
		leggimionvc();
		leggigiorno();
		button2_Click(sender, e);
	}

	private void RecTv_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	public void button1_Click(object sender, EventArgs e)
	{
		bool flag = true;
		int num = 0;
		while (flag)
		{
			try
			{
				flag = false;
				string text = comboBox1.SelectedItem.ToString();
				string text2 = textBox1.Text;
				string text3 = textBox2.Text;
				text2 = text2.Replace(".", ":");
				text3 = text3.Replace(".", ":");
				text2 = text2.Trim();
				text3 = text3.Trim();
				textBox1.Text = text2;
				textBox2.Text = text3;
				if (textBox3.Text.IndexOf(" ") == 0)
				{
					textBox3.Text = textBox3.Text.Substring(1);
				}
				string value = textBox3.Text;
				int num2 = int.Parse(text2.Substring(0, text2.IndexOf(":")));
				num2 = int.Parse(text2.Substring(text2.IndexOf(":") + 1));
				num2 = int.Parse(text3.Substring(0, text3.IndexOf(":")));
				num2 = int.Parse(text3.Substring(text3.IndexOf(":") + 1));
				DateTime value2 = dateTimePicker1.Value;
				if (palinsesto)
				{
					bool flag2 = false;
					try
					{
						string text4 = listBox2.SelectedItem.ToString();
						flag2 = true;
					}
					catch
					{
					}
					if (int.Parse(text2.Substring(0, text2.IndexOf(":"))) < 5 && !flag2)
					{
					}
				}
				if (!string.IsNullOrEmpty(value))
				{
					string text5 = value2.Day + "_" + value2.Month + "_" + value2.Year;
					if (!Directory.Exists(Program.pr + "\\" + text5))
					{
						Directory.CreateDirectory(Program.pr + "\\" + text5);
					}
					try
					{
						StreamWriter streamWriter;
						int num3;
						if (comboBox1.SelectedIndex > 5)
						{
							streamWriter = new StreamWriter(Program.pr + "\\" + text5 + "\\canaliagg.txt", append: true);
							streamWriter.WriteLine(textBox1.Text + " " + textBox3.Text + "    |||" + textBox2.Text);
							num3 = 0;
							foreach (string item in listalettac)
							{
								if (item == comboBox1.SelectedItem)
								{
									break;
								}
								num3++;
							}
							num3++;
							if (comboBox2.SelectedIndex == 0)
							{
								streamWriter.WriteLine(string.Concat("REC |||", comboBox1.SelectedItem, "!$!", listalettac[num3]));
							}
							else
							{
								streamWriter.WriteLine(string.Concat("SHOW |||", comboBox1.SelectedItem, "!$!", listalettac[num3]));
							}
							streamWriter.Close();
							leggigiorno();
							continue;
						}
						string text6 = "";
						switch (comboBox1.SelectedIndex)
						{
						case 0:
							text6 = "\\rai1.txt";
							break;
						case 1:
							text6 = "\\rai2.txt";
							break;
						case 2:
							text6 = "\\rai3.txt";
							break;
						case 3:
							text6 = "\\quattro.txt";
							break;
						case 4:
							text6 = "\\cinque.txt";
							break;
						case 5:
							text6 = "\\italia.txt";
							break;
						}
						streamWriter = new StreamWriter(Program.pr + "\\" + text5 + text6, append: true);
						streamWriter.WriteLine(textBox1.Text + " " + textBox3.Text + "    |||" + textBox2.Text);
						num3 = 0;
						foreach (string item2 in listalettac)
						{
							if (item2 == comboBox1.SelectedItem)
							{
								break;
							}
							num3++;
						}
						num3++;
						if (comboBox2.SelectedIndex == 0)
						{
							streamWriter.WriteLine("REC ");
						}
						else
						{
							streamWriter.WriteLine("SHOW ");
						}
						streamWriter.Close();
						leggigiorno();
						MessageBox.Show("Registrazione Aggiunta");
					}
					catch
					{
						if (num < 1000)
						{
							flag = true;
						}
						num++;
					}
				}
				else
				{
					MessageBox.Show("Devi inserire il nome del file che vuoi salvare");
				}
			}
			catch
			{
				MessageBox.Show("Errore,Controllare di aver settato tutto correttamente");
			}
		}
	}

	private void leggigiorno()
	{
		try
		{
			listareg.Clear();
		}
		catch
		{
		}
		try
		{
			listareg1.Clear();
		}
		catch
		{
		}
		try
		{
			listareg2.Clear();
		}
		catch
		{
		}
		try
		{
			listareg3.Clear();
		}
		catch
		{
		}
		try
		{
			listareg4.Clear();
		}
		catch
		{
		}
		try
		{
			listareg5.Clear();
		}
		catch
		{
		}
		try
		{
			listareg6.Clear();
		}
		catch
		{
		}
		try
		{
			listBox1.Items.Clear();
		}
		catch
		{
		}
		try
		{
			DateTime value = dateTimePicker1.Value;
			try
			{
				string text = textBox1.Text;
				if (palinsesto && int.Parse(text.Substring(0, text.IndexOf(":"))) >= 6)
				{
				}
			}
			catch
			{
			}
			string text2 = value.Day + "_" + value.Month + "_" + value.Year;
			if (File.Exists(Program.pr + "\\" + text2 + "\\canaliagg.txt"))
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\" + text2 + "\\canaliagg.txt");
				string text3 = "";
				while ((text3 = streamReader.ReadLine()) != null)
				{
					listareg.Add(text3);
					string text4 = text3;
					text3 = streamReader.ReadLine();
					listareg.Add(text3);
					string text5 = "Ora inizio " + text4.Substring(0, text4.IndexOf(" ")) + " ";
					string text6 = text4.Substring(text4.IndexOf(" ") + 1);
					text6 = text6.Substring(0, text6.IndexOf("|||"));
					text6 = text6.Trim();
					text5 = text5 + "Ora fine " + text4.Substring(text4.IndexOf("|||") + 3) + " ";
					string text7 = text3.Substring(0, text3.IndexOf("|||"));
					text3 = text3.Substring(text3.IndexOf("|||") + 3);
					text5 = text5 + "Canale :" + text3.Substring(0, text3.IndexOf("!$!")) + " --> " + text6 + " (" + text7 + ")";
					listBox1.Items.Add(text5);
				}
				streamReader.Close();
			}
			for (int i = 0; i < 6; i++)
			{
				try
				{
					string text8 = "";
					IList<string> list = new List<string>();
					switch (i)
					{
					case 0:
						text8 = "\\rai1.txt";
						list = listareg1;
						break;
					case 1:
						text8 = "\\rai2.txt";
						list = listareg2;
						break;
					case 2:
						text8 = "\\rai3.txt";
						list = listareg3;
						break;
					case 3:
						text8 = "\\quattro.txt";
						list = listareg4;
						break;
					case 4:
						text8 = "\\cinque.txt";
						list = listareg5;
						break;
					case 5:
						text8 = "\\italia.txt";
						list = listareg6;
						break;
					}
					StreamReader streamReader = new StreamReader(Program.pr + "\\" + text2 + text8);
					string text3 = "";
					text8 = text8.Replace("\\", "");
					text8 = text8.Replace(".txt", "");
					while ((text3 = streamReader.ReadLine()) != null)
					{
						list.Add(text3);
						string text4 = text3;
						text3 = streamReader.ReadLine();
						list.Add(text3);
						string text5 = "Ora inizio " + text4.Substring(0, text4.IndexOf(" ")) + " ";
						string text6 = text4.Substring(text4.IndexOf(" ") + 1);
						text6 = text6.Substring(0, text6.IndexOf("|||"));
						text6 = text6.Trim();
						text5 = text5 + "Ora fine " + text4.Substring(text4.IndexOf("|||") + 3) + " ";
						text5 = text5 + "Canale :" + text8 + " --> " + text6 + " (" + text3 + ")";
						listBox1.Items.Add(text5);
					}
					streamReader.Close();
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void label5_Click(object sender, EventArgs e)
	{
	}

	private void scrivilistareg(string rx, IList<string> llx, int uscitasic)
	{
		try
		{
			string text = dateTimePicker1.Value.Day + "_" + dateTimePicker1.Value.Month + "_" + dateTimePicker1.Value.Year;
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text + rx);
			foreach (string item in llx)
			{
				if (!string.IsNullOrEmpty(item))
				{
					streamWriter.WriteLine(item);
				}
			}
			streamWriter.Close();
			leggigiorno();
		}
		catch
		{
			if (uscitasic < 10)
			{
				scrivilistareg(rx, llx, uscitasic++);
			}
		}
	}

	private void scrivilistareg()
	{
		try
		{
			string text = dateTimePicker1.Value.Day + "_" + dateTimePicker1.Value.Month + "_" + dateTimePicker1.Value.Year;
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text + "\\canaliagg.txt");
			foreach (string item in listareg)
			{
				if (!string.IsNullOrEmpty(item))
				{
					streamWriter.WriteLine(item);
				}
			}
			streamWriter.Close();
			leggigiorno();
		}
		catch
		{
		}
	}

	private void rimuovereToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			List<string> list;
			int num;
			if (text.IndexOf(":(") > 0)
			{
				list = new List<string>();
				foreach (string item in listBox1.Items)
				{
					if (item.IndexOf(":(") > 0)
					{
						list.Add(item);
					}
				}
				num = 0;
				foreach (string item2 in list)
				{
					if (item2 == text)
					{
						break;
					}
					num++;
				}
				num *= 2;
				listareg[num] = "";
				listareg[num + 1] = "";
				scrivilistareg();
				return;
			}
			list = new List<string>();
			string text3 = "";
			IList<string> list2 = new List<string>();
			if (text.IndexOf(":rai1") > 0)
			{
				text3 = ":rai1";
				list2 = listareg1;
			}
			else if (text.IndexOf(":rai2") > 0)
			{
				text3 = ":rai2";
				list2 = listareg2;
			}
			else if (text.IndexOf(":rai3") > 0)
			{
				text3 = ":rai3";
				list2 = listareg3;
			}
			else if (text.IndexOf(":quattro") > 0)
			{
				text3 = ":quattro";
				list2 = listareg4;
			}
			else if (text.IndexOf(":cinque") > 0)
			{
				text3 = ":cinque";
				list2 = listareg5;
			}
			else if (text.IndexOf(":italia") > 0)
			{
				text3 = ":italia";
				list2 = listareg6;
			}
			foreach (string item3 in listBox1.Items)
			{
				if (item3.IndexOf(text3) > 0)
				{
					list.Add(item3);
				}
			}
			num = 0;
			foreach (string item4 in list)
			{
				if (item4 == text)
				{
					break;
				}
				num++;
			}
			num *= 2;
			list2[num] = "";
			list2[num + 1] = "";
			scrivilistareg("\\" + text3.Replace(":", "") + ".txt", list2, 0);
		}
		catch
		{
		}
	}

	private void groupBox3_Enter(object sender, EventArgs e)
	{
	}

	private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
	{
		DateTime now = DateTime.Now;
		int day = now.Day;
		int day2 = now.AddDays(3.0).Day;
		int num = 1;
		if (now.Day > 3)
		{
			num = now.AddDays(-3.0).Day;
		}
		int day3 = dateTimePicker1.Value.Day;
		if (day2 >= day3 && num <= day3 && now.Month == dateTimePicker1.Value.Month && now.Year == dateTimePicker1.Value.Year)
		{
			if (!button2.Visible)
			{
				button2_Click(new object(), new EventArgs());
				button2.Visible = true;
			}
			try
			{
				if (palinsesto)
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
				}
			}
			catch
			{
			}
		}
		else
		{
			button2.Visible = false;
			if (palinsesto)
			{
				mettiapposto();
				palinsesto = false;
			}
		}
		leggigiorno();
	}

	private void mettiapposto()
	{
		button2.Text = "Mostra Palinsesto";
		Size = new Size(Width, Height - groupBox3.Size.Height - 20);
		groupBox1.Location = new Point(groupBox1.Location.X, groupBox1.Location.Y - groupBox3.Size.Height - 10);
		groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y - groupBox3.Size.Height - 10);
		groupBox3.Location = new Point(476, groupBox3.Location.Y);
		groupBox3.Visible = false;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (!palinsesto)
		{
			button2.Text = "Nascondi Palinsesto";
			palinsesto = true;
			Size = new Size(Width, Height + groupBox3.Size.Height + 20);
			groupBox1.Location = new Point(groupBox1.Location.X, groupBox1.Location.Y + groupBox3.Size.Height + 10);
			groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y + groupBox3.Size.Height + 10);
			groupBox3.Location = new Point(groupBox1.Location.X, groupBox3.Location.Y);
			groupBox3.Visible = true;
		}
		else
		{
			palinsesto = false;
			mettiapposto();
		}
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		webBrowser1.Visible = false;
		try
		{
			listBox2.Items.Clear();
		}
		catch
		{
		}
		if (!normale)
		{
			return;
		}
		try
		{
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(sport) sport italia" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/sportitalia/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) rai 4" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rai4/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) rai 5" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rai5/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(sport) euro sport" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/eurosport/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) rai 1" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(mediaset) la 5" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/la5/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) rai 1" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(regionale) primo canale" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vaiprimocanale);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(regionale) retesole " && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vairetesoleumbria);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(regionale) rete sole roma" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vairetesoleroma);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) rai 2" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raidue/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) rai 3" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raitre/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(mediaset) rete 4" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rete4/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(generalista) la 7 " && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/la7/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(musica) deejay tv" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/deejaytv/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(generalista) odeon tv" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/odeon/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(generalista) cielo" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/cielo/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(mediaset) canale 5" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/canale5/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(mediaset) italia 1" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/italia1/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(divertimento) rai sat yoyo" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatyoyo/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(cinema) rai cinema" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatcinema/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(sport) rai sport" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisport1/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(notiziari) rai news 24" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rainews24/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) raisat premium" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatpremium/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(cultura) rai storia" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raistoria/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(cultura) rai scuola" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiscuola/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(divertimento) rai gulp" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raigulp/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(generalista) 7 gold" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/7gold/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(generalista) tv 2000" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/sat2000/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (comboBox1.SelectedItem.ToString().ToLowerInvariant() == "(rai) rai sat extra" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatextra/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			string text = leggipalinternet(comboBox1.SelectedItem.ToString());
			if (text != "")
			{
				webBrowser1.Visible = true;
				webBrowser1.Navigate(text);
			}
		}
		catch
		{
		}
	}

	private string leggipalinternet(string parola)
	{
		string result = "";
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\palinternet");
			string text = "";
			parola = parola.Substring(parola.IndexOf("("));
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text.CompareTo(parola) == 0)
				{
					text = streamReader.ReadLine();
					result = text;
				}
			}
			streamReader.Close();
		}
		catch
		{
		}
		return result;
	}

	private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string text = listBox2.SelectedItem.ToString();
			textBox1.Text = text.Substring(0, text.IndexOf("-") - 1).Replace(".", ":");
			text = text.Substring(text.IndexOf("-") + 2);
			textBox2.Text = text.Substring(0, text.IndexOf(" ")).Replace(".", ":");
			text = text.Substring(text.IndexOf(" "));
			text = text.Substring(text.IndexOf(":") + 1);
			text = text.Replace("\"", "");
			text = text.Replace(".", "");
			text = text.Replace(",", "");
			text = text.Replace("&", "");
			text = text.Replace("/", "");
			textBox3.Text = text;
		}
		catch
		{
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.RecTv));
		this.label2 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.label6 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.rimuovereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		this.label4 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		this.listBox2 = new System.Windows.Forms.ListBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		this.groupBox3.SuspendLayout();
		base.SuspendLayout();
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 18);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 15);
		this.label2.TabIndex = 7;
		this.label2.Text = "Canale";
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[6] { "(Rai) Rai 1", "(Rai) Rai 2", "(Rai) Rai 3", "(Mediaset) Rete 4", "(Mediaset) Canale 5", "(Mediaset) Italia 1" });
		this.comboBox1.Location = new System.Drawing.Point(6, 41);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(272, 23);
		this.comboBox1.TabIndex = 6;
		this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
		this.textBox1.Location = new System.Drawing.Point(6, 79);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(109, 21);
		this.textBox1.TabIndex = 8;
		this.textBox1.Text = "00:00";
		this.textBox2.Location = new System.Drawing.Point(6, 131);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(109, 21);
		this.textBox2.TabIndex = 9;
		this.textBox2.Text = "00:05";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(155, 82);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(241, 15);
		this.label1.TabIndex = 10;
		this.label1.Text = "Orario Inizio registrazione (formato hh:mm)";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(155, 136);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(237, 15);
		this.label3.TabIndex = 11;
		this.label3.Text = "Orario Fine registrazione (formato hh:mm)";
		this.button1.Location = new System.Drawing.Point(313, 189);
		this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(87, 21);
		this.button1.TabIndex = 12;
		this.button1.Text = "Registra";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.groupBox1.Controls.Add(this.comboBox2);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.textBox3);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.Controls.Add(this.comboBox1);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Location = new System.Drawing.Point(12, 49);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Size = new System.Drawing.Size(432, 232);
		this.groupBox1.TabIndex = 13;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Registrazione";
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Items.AddRange(new object[2] { "REC", "SHOW" });
		this.comboBox2.Location = new System.Drawing.Point(310, 41);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(82, 23);
		this.comboBox2.TabIndex = 16;
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(324, 18);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(47, 15);
		this.label6.TabIndex = 15;
		this.label6.Text = "Metodo";
		this.textBox3.Location = new System.Drawing.Point(10, 189);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(268, 21);
		this.textBox3.TabIndex = 14;
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(6, 170);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(165, 15);
		this.label5.TabIndex = 13;
		this.label5.Text = "Nome Programma registrato";
		this.label5.Click += new System.EventHandler(this.label5_Click);
		this.groupBox2.Controls.Add(this.listBox1);
		this.groupBox2.Location = new System.Drawing.Point(12, 294);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Size = new System.Drawing.Size(604, 127);
		this.groupBox2.TabIndex = 14;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Registrazioni in programma (click tasto destro per cancellare)";
		this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.ItemHeight = 15;
		this.listBox1.Location = new System.Drawing.Point(10, 22);
		this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(588, 94);
		this.listBox1.TabIndex = 0;
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.rimuovereToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(264, 26);
		this.rimuovereToolStripMenuItem.Name = "rimuovereToolStripMenuItem";
		this.rimuovereToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
		this.rimuovereToolStripMenuItem.Text = "Rimuovere registrazione selezionato";
		this.rimuovereToolStripMenuItem.Click += new System.EventHandler(this.rimuovereToolStripMenuItem_Click);
		this.dateTimePicker1.Location = new System.Drawing.Point(12, 22);
		this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.dateTimePicker1.Name = "dateTimePicker1";
		this.dateTimePicker1.Size = new System.Drawing.Size(241, 21);
		this.dateTimePicker1.TabIndex = 13;
		this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(8, 7);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(177, 15);
		this.label4.TabIndex = 14;
		this.label4.Text = "Data scelta per la registrazione";
		this.button2.ForeColor = System.Drawing.Color.Red;
		this.button2.Location = new System.Drawing.Point(282, 22);
		this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(131, 21);
		this.button2.TabIndex = 15;
		this.button2.Text = "Nascondi Palinsesto";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.groupBox3.Controls.Add(this.listBox2);
		this.groupBox3.Controls.Add(this.webBrowser1);
		this.groupBox3.Location = new System.Drawing.Point(479, 51);
		this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox3.Size = new System.Drawing.Size(604, 208);
		this.groupBox3.TabIndex = 16;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Palinsesto Canale Selezionato";
		this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
		this.webBrowser1.Location = new System.Drawing.Point(12, 14);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(125, 184);
		this.webBrowser1.TabIndex = 2;
		this.listBox2.ContextMenuStrip = this.contextMenuStrip1;
		this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listBox2.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listBox2.FormattingEnabled = true;
		this.listBox2.HorizontalScrollbar = true;
		this.listBox2.ItemHeight = 17;
		this.listBox2.Location = new System.Drawing.Point(3, 16);
		this.listBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.listBox2.Name = "listBox2";
		this.listBox2.Size = new System.Drawing.Size(598, 174);
		this.listBox2.TabIndex = 1;
		this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(628, 446);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.groupBox3);
		base.Controls.Add(this.dateTimePicker1);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "RecTv";
		base.Opacity = 0.0;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "RecTv";
		base.Load += new System.EventHandler(this.RecTv_Load);
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecTv_FormClosing);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.contextMenuStrip1.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
