// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Properties;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class ProgrammiTV : Form
{
	private Form1 mio;

	private Thread TTX;

	private bool cambia = true;

	public bool secondaconf = false;

	private IContainer components = null;

	private SplitContainer splitContainer1;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private Label label2;

	private Label label1;

	private GroupBox groupBox1;

	private Label label3;

	private ComboBox comboBox1;

	public RadioButton radioButton4;

	public RadioButton radioButton3;

	public RadioButton radioButton2;

	public RadioButton radioButton1;

	public DateTimePicker dateTimePicker1;

	public ListBox listBox3;

	public ListBox listBox2;

	public ListBox listBox1;

	public ProgressBar progressBar1;

	public ListBox listBox6;

	public ListBox listBox5;

	public ListBox listBox4;

	private PictureBox pictureBox1;

	private PictureBox pictureBox3;

	private PictureBox pictureBox4;

	private PictureBox pictureBox2;

	private PictureBox pictureBox5;

	private PictureBox pictureBox6;

	private PictureBox pictureBox7;

	private PictureBox pictureBox8;

	private PictureBox pictureBox9;

	private PictureBox pictureBox10;

	private PictureBox pictureBox11;

	private PictureBox pictureBox12;

	private LinkLabel linkLabel2;

	private LinkLabel linkLabel1;

	private LinkLabel linkLabel3;

	public ProgrammiTV(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
	{
		if (cambia)
		{
			partithdb();
		}
	}

	private void applicalist(ListBox l1)
	{
		try
		{
			DateTime now = DateTime.Now;
			int num = 0;
			foreach (string item in l1.Items)
			{
				string text2 = item;
				if (text2.IndexOf("(REC)") >= 0 || text2.IndexOf("(SHOW)") >= 0)
				{
					text2 = text2.Substring(text2.IndexOf(")") + 2);
				}
				string text3 = text2.Substring(0, text2.IndexOf(" "));
				int num2 = int.Parse(text3.Substring(0, text3.IndexOf(":")));
				int num3 = int.Parse(text3.Substring(text3.IndexOf(":") + 1));
				if (!secondaconf)
				{
					if ((num2 < 6 || now.Hour >= 6) && ((num2 < 6 && now.Hour >= 6) || now.Hour < num2 || (now.Hour == num2 && now.Minute < num3)))
					{
						break;
					}
				}
				else if ((num2 < 5 || now.Hour >= 5) && ((num2 < 5 && now.Hour >= 5) || now.Hour < num2 || (now.Hour == num2 && now.Minute < num3)))
				{
					break;
				}
				num++;
			}
			if (num > 0)
			{
				num--;
			}
			l1.SelectedItem = l1.Items[num];
		}
		catch (Exception)
		{
		}
	}

	public void programmaattuale()
	{
		applicalist(listBox1);
		applicalist(listBox2);
		applicalist(listBox3);
		applicalist(listBox4);
		applicalist(listBox5);
		applicalist(listBox6);
	}

	private void partithdb()
	{
		try
		{
			TTX.Abort();
		}
		catch
		{
		}
		try
		{
			ThreadDbtele threadDbtele = new ThreadDbtele(mio);
			Thread thread = new Thread(threadDbtele.vai);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
	}

	public void settapl(ListBox l1, string x)
	{
		try
		{
			StreamReader streamReader = new StreamReader(x);
			string text = "";
			IList<string> list = new List<string>();
			IList<string> list2 = new List<string>();
			while ((text = streamReader.ReadLine()) != null)
			{
				list.Add(text);
			}
			streamReader.Close();
			foreach (object item in l1.Items)
			{
				list2.Add(item.ToString());
			}
			int num = 0;
			foreach (string item2 in list2)
			{
				int num2 = 0;
				foreach (string item3 in list)
				{
					if (item3.Length > 10)
					{
						string text2 = item2;
						if (item2.IndexOf("|||") >= 0)
						{
							text2 = item2.Substring(0, item2.IndexOf("|||"));
						}
						string text3 = item3.Substring(0, item3.IndexOf("|||"));
						if (text3.Length > text2.Length)
						{
							text3 = text3.Substring(0, text2.Length);
						}
						if (text2.IndexOf(text3) >= 0)
						{
							string text4 = list[num2 + 1];
							l1.Items[num] = "(" + text4 + ") " + item2;
						}
					}
					num2++;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
	}

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + mio.linguaprogramma + "RECN.txt");
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
			if (text2.IndexOf("linkLabel3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("linkLabel3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				linkLabel3.Text = text3;
			}
			if (text2.IndexOf("linkLabel2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("linkLabel2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				linkLabel2.Text = text3;
			}
			if (text2.IndexOf("linkLabel1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("linkLabel1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				linkLabel1.Text = text3;
			}
			if (text2.IndexOf("label3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label3.Text = text3;
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
			if (text2.IndexOf("radioButton4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton4.Text = text3;
			}
			if (text2.IndexOf("radioButton3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton3.Text = text3;
			}
			if (text2.IndexOf("radioButton2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton2.Text = text3;
			}
			if (text2.IndexOf("radioButton1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton1.Text = text3;
			}
			if (text2.IndexOf("tabPage1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("tabPage1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				tabPage1.Text = text3;
			}
			if (text2.IndexOf("tabPage2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("tabPage2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				tabPage2.Text = text3;
			}
		}
		catch
		{
		}
	}

	private void ProgrammiTV_Load(object sender, EventArgs e)
	{
		cambialing();
		try
		{
			ThreadCapo threadCapo = new ThreadCapo(this);
			Thread thread = new Thread(threadCapo.componi);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
		cambia = false;
		DateTime value = dateTimePicker1.Value;
		if (value.Hour < 6)
		{
			dateTimePicker1.Value = value.AddDays(-1.0);
		}
		cambia = true;
		int num = int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString());
		int num2 = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
		pictureBox3.Size = new Size(pictureBox3.Size.Width, num - pictureBox3.Location.Y - 250);
		pictureBox4.Size = new Size(pictureBox4.Size.Width, num - pictureBox4.Location.Y - 250);
		pictureBox5.Size = new Size(pictureBox5.Size.Width, num - pictureBox5.Location.Y - 250);
		pictureBox9.Size = new Size(pictureBox9.Size.Width, num - pictureBox9.Location.Y - 250);
		pictureBox7.Size = new Size(pictureBox7.Size.Width, num - pictureBox7.Location.Y - 250);
		pictureBox11.Size = new Size(pictureBox11.Size.Width, num - pictureBox11.Location.Y - 250);
		listBox1.Size = new Size(listBox1.Size.Width, num - listBox1.Location.Y - 280);
		listBox2.Size = new Size(listBox2.Size.Width, num - listBox2.Location.Y - 280);
		listBox3.Size = new Size(listBox3.Size.Width, num - listBox3.Location.Y - 280);
		listBox4.Size = new Size(listBox4.Size.Width, num - listBox4.Location.Y - 280);
		listBox5.Size = new Size(listBox5.Size.Width, num - listBox5.Location.Y - 280);
		listBox6.Size = new Size(listBox6.Size.Width, num - listBox6.Location.Y - 280);
		partithdb();
	}

	private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			funzionilista((ListBox)sender, "\\rai1.txt", "rai 1");
		}
		catch
		{
		}
	}

	private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			funzionilista((ListBox)sender, "\\rai2.txt", "rai 2");
		}
		catch
		{
		}
	}

	private void funzionilista(ListBox l1, string xpio, string normale)
		{
			try
			{
	try
				{
					string dbg = "DBG funzionilista xpio=" + xpio + " secondaconf=" + secondaconf
						+ " r1=" + radioButton1.Checked + " r2=" + radioButton2.Checked
						+ " r3=" + radioButton3.Checked + " r4=" + radioButton4.Checked
						+ " selidx=" + l1.SelectedIndex
						+ " sel=[" + (l1.SelectedItem == null ? "NULL" : l1.SelectedItem.ToString()) + "]";
					System.IO.File.AppendAllText(Program.pr + "\\dbg_funz.txt", dbg + Environment.NewLine);
				}
				catch
				{
				}
			string text3;
			int num;
			string text2;
			string text;
			if (!secondaconf)
			{
				text = l1.SelectedItem.ToString();
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				text2 = "";
				text3 = text;
				if (text3.IndexOf("(") >= 0 && text3.IndexOf("(") < 3)
				{
					text3 = text3.Substring(text3.IndexOf(")") + 2);
				}
				num = int.Parse(text3.Substring(0, text3.IndexOf(":")));
				text2 = ((num >= 6 || l1.SelectedIndex <= 3) ? (dateTimePicker1.Value.Day + "_" + dateTimePicker1.Value.Month + "_" + dateTimePicker1.Value.Year) : (dateTimePicker1.Value.AddDays(1.0).Day + "_" + dateTimePicker1.Value.Month + "_" + dateTimePicker1.Value.Year));
				if (radioButton1.Checked)
				{
					if (text.IndexOf("(SHOW)") < 0)
					{
						if (!Directory.Exists(Program.pr + "\\" + text2))
						{
							Directory.CreateDirectory(Program.pr + "\\" + text2);
						}
						string text4 = "";
						text4 = ((l1.SelectedIndex == l1.Items.Count - 1) ? l1.Items[0].ToString() : l1.Items[l1.SelectedIndex + 1].ToString());
						if (text4.IndexOf("(SHOW)") >= 0 || text4.IndexOf("(REC)") >= 0)
						{
							text4 = text4.Substring(text4.IndexOf(" ") + 1);
						}
						text4 = text4.Substring(0, text4.IndexOf(" "));
						text = text.Substring(0, text.IndexOf("|||"));
						string value = text + " |||" + text4;
						StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text2 + xpio, append: true);
						streamWriter.WriteLine(value);
						streamWriter.WriteLine("SHOW");
						streamWriter.Close();
						l1.Items[l1.SelectedIndex] = "(SHOW) " + l1.SelectedItem.ToString();
					}
				}
				else if (radioButton2.Checked)
				{
					if (text.IndexOf("(REC)") < 0)
					{
						if (!Directory.Exists(Program.pr + "\\" + text2))
						{
							Directory.CreateDirectory(Program.pr + "\\" + text2);
						}
						string text4 = "";
						text4 = ((l1.SelectedIndex == l1.Items.Count - 1) ? l1.Items[0].ToString() : l1.Items[l1.SelectedIndex + 1].ToString());
						if (text4.IndexOf("(SHOW)") >= 0 || text4.IndexOf("(REC)") >= 0)
						{
							text4 = text4.Substring(text4.IndexOf(" ") + 1);
						}
						text4 = text4.Substring(0, text4.IndexOf(" "));
						text = text.Substring(0, text.IndexOf("|||"));
						string value = text + " |||" + text4;
						StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text2 + xpio, append: true);
						streamWriter.WriteLine(value);
						streamWriter.WriteLine("REC");
						streamWriter.Close();
						l1.Items[l1.SelectedIndex] = "(REC) " + l1.SelectedItem.ToString();
					}
				}
				else if (radioButton3.Checked)
				{
					text = text.Substring(0, text.IndexOf("|||"));
					text = text.Substring(text.IndexOf(")") + 1);
					text = text.Substring(text.IndexOf(" ") + 1);
					text = "televisione " + normale + " " + text;
					text = text.Replace(" ", "+");
					Process.Start("http://www.google.it/#hl=it&q=" + text + "&meta=&aq=&fp=60bff422675b2c2c");
				}
				else
				{
					if (!radioButton4.Checked || (text.IndexOf("(REC)") >= 0 && text.IndexOf("(SHOW)") >= 0))
					{
						return;
					}
					StreamReader streamReader = new StreamReader(Program.pr + "\\" + text2 + xpio);
					string text5 = "";
					IList<string> list = new List<string>();
					IList<string> list2 = new List<string>();
					while ((text5 = streamReader.ReadLine()) != null)
					{
						list.Add(text5);
						list2.Add(text5);
					}
					streamReader.Close();
					string text6 = text.Substring(text.IndexOf("|||"));
					text = text.Substring(0, text.IndexOf("|||"));
					int num2 = 0;
					foreach (string item in list)
					{
						if (item.IndexOf("|||") >= 0)
						{
							text6 = item.Substring(0, item.IndexOf("|||") - 2);
							if (text.IndexOf(text6) >= 0)
							{
								list2[num2] = "";
								list2[num2 + 1] = "";
							}
						}
					}
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text2 + xpio);
					foreach (string item2 in list2)
					{
						if (!string.IsNullOrEmpty(item2))
						{
							streamWriter.WriteLine(item2);
						}
					}
					streamWriter.Close();
					text = l1.SelectedItem.ToString();
					while (text.IndexOf(")") >= 0 && text.IndexOf(")") < 10)
					{
						text = text.Substring(text.IndexOf(")") + 2);
					}
					l1.Items[l1.SelectedIndex] = text;
				}
				return;
			}
			text = l1.SelectedItem.ToString();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			text2 = "";
			text3 = text;
			if (text3.IndexOf("(") >= 0 && text3.IndexOf("(") > 3)
			{
				text3 = text3.Substring(text3.IndexOf(")") + 2);
			}
			num = int.Parse(text3.Substring(0, text3.IndexOf(":")));
			text2 = ((num >= 5 || l1.SelectedIndex <= 3) ? (dateTimePicker1.Value.Day + "_" + dateTimePicker1.Value.Month + "_" + dateTimePicker1.Value.Year) : (dateTimePicker1.Value.AddDays(1.0).Day + "_" + dateTimePicker1.Value.Month + "_" + dateTimePicker1.Value.Year));
			if (radioButton1.Checked)
			{
				if (text.IndexOf("(SHOW)") < 0)
				{
					if (!Directory.Exists(Program.pr + "\\" + text2))
					{
						Directory.CreateDirectory(Program.pr + "\\" + text2);
					}
					string text4 = text.Substring(text.IndexOf("-") + 2);
					text4 = text4.Substring(0, text4.IndexOf(" "));
					if (text.IndexOf("|||") >= 0)
					{
						text = text.Substring(0, text.IndexOf("|||"));
					}
					string value = text + " |||" + text4;
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text2 + xpio, append: true);
					streamWriter.WriteLine(value);
					streamWriter.WriteLine("SHOW");
					streamWriter.Close();
					l1.Items[l1.SelectedIndex] = "(SHOW) " + l1.SelectedItem.ToString();
				}
			}
			else if (radioButton2.Checked)
			{
				if (text.IndexOf("(REC)") < 0)
				{
					if (!Directory.Exists(Program.pr + "\\" + text2))
					{
						Directory.CreateDirectory(Program.pr + "\\" + text2);
					}
					string text4 = text.Substring(text.IndexOf("-") + 2);
					text4 = text4.Substring(0, text4.IndexOf(" "));
					if (text.IndexOf("|||") >= 0)
					{
						text = text.Substring(0, text.IndexOf("|||"));
					}
					string value = text + " |||" + text4;
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text2 + xpio, append: true);
					streamWriter.WriteLine(value);
					streamWriter.WriteLine("REC");
					streamWriter.Close();
					l1.Items[l1.SelectedIndex] = "(REC) " + l1.SelectedItem.ToString();
				}
			}
			else if (radioButton3.Checked)
			{
				if (text.IndexOf("|||") >= 0)
				{
					text = text.Substring(0, text.IndexOf("|||"));
				}
				text = text.Substring(text.IndexOf("-") + 6);
				text = "televisione " + normale + " " + text;
				text = text.Replace(" ", "+");
				Process.Start("http://www.google.it/#hl=it&q=" + text + "&meta=&aq=&fp=60bff422675b2c2c");
			}
			else
			{
				if (!radioButton4.Checked || (text.IndexOf("(REC)") >= 0 && text.IndexOf("(SHOW)") >= 0))
				{
					return;
				}
				StreamReader streamReader = new StreamReader(Program.pr + "\\" + text2 + xpio);
				string text5 = "";
				IList<string> list = new List<string>();
				IList<string> list2 = new List<string>();
				while ((text5 = streamReader.ReadLine()) != null)
				{
					list.Add(text5);
					list2.Add(text5);
				}
				streamReader.Close();
				string text6 = text;
				if (text.IndexOf("|||") >= 0)
				{
					text6 = text.Substring(text.IndexOf("|||"));
				}
				if (text.IndexOf("|||") >= 0)
				{
					text = text.Substring(0, text.IndexOf("|||"));
				}
				int num2 = 0;
				foreach (string item3 in list)
				{
					if (item3.Length >= 10)
					{
						text6 = item3;
						if (item3.IndexOf("|||") >= 0)
						{
							text6 = item3.Substring(0, item3.IndexOf("|||") - 2);
						}
						if (text.IndexOf(text6) >= 0)
						{
							list2[num2] = "";
							list2[num2 + 1] = "";
						}
					}
					num2++;
				}
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text2 + xpio);
				foreach (string item4 in list2)
				{
					if (!string.IsNullOrEmpty(item4))
					{
						streamWriter.WriteLine(item4);
					}
				}
				streamWriter.Close();
				text = l1.SelectedItem.ToString();
				while (text.IndexOf(")") >= 0 && text.IndexOf(")") < 10)
				{
					text = text.Substring(text.IndexOf(")") + 2);
				}
				l1.Items[l1.SelectedIndex] = text;
			}
		}
		catch
		{
		}
	}

	private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			funzionilista((ListBox)sender, "\\rai3.txt", "rai tre");
		}
		catch
		{
		}
	}

	private void listBox5_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			funzionilista((ListBox)sender, "\\cinque.txt", "canale 5");
		}
		catch
		{
		}
	}

	private void listBox6_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			funzionilista((ListBox)sender, "\\italia.txt", "italia 1");
		}
		catch
		{
		}
	}

	private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void listBox4_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			funzionilista((ListBox)sender, "\\quattro.txt", "rete 4");
		}
		catch
		{
		}
	}

	private void groupBox1_Enter(object sender, EventArgs e)
	{
	}

	private void radioButton3_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start("http://www.rai.tv/dl/replaytv/replaytv.html#");
		}
		catch
		{
		}
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start("http://video.mediaset.it/");
		}
		catch
		{
		}
	}

	private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start("http://www.la7.tv/");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.ProgrammiTV));
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.linkLabel3 = new System.Windows.Forms.LinkLabel();
		this.linkLabel2 = new System.Windows.Forms.LinkLabel();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.radioButton4 = new System.Windows.Forms.RadioButton();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.pictureBox12 = new System.Windows.Forms.PictureBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.listBox3 = new System.Windows.Forms.ListBox();
		this.listBox2 = new System.Windows.Forms.ListBox();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.listBox6 = new System.Windows.Forms.ListBox();
		this.listBox5 = new System.Windows.Forms.ListBox();
		this.listBox4 = new System.Windows.Forms.ListBox();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		this.tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		base.SuspendLayout();
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.splitContainer1.Panel1.Controls.Add(this.linkLabel3);
		this.splitContainer1.Panel1.Controls.Add(this.linkLabel2);
		this.splitContainer1.Panel1.Controls.Add(this.linkLabel1);
		this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
		this.splitContainer1.Panel1.Controls.Add(this.label3);
		this.splitContainer1.Panel1.Controls.Add(this.label2);
		this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
		this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
		this.splitContainer1.Panel1.Controls.Add(this.label1);
		this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
		this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
		this.splitContainer1.Size = new System.Drawing.Size(1135, 615);
		this.splitContainer1.SplitterDistance = 132;
		this.splitContainer1.SplitterWidth = 5;
		this.splitContainer1.TabIndex = 0;
		this.linkLabel3.AutoSize = true;
		this.linkLabel3.DisabledLinkColor = System.Drawing.Color.White;
		this.linkLabel3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel3.ForeColor = System.Drawing.Color.White;
		this.linkLabel3.LinkColor = System.Drawing.Color.Yellow;
		this.linkLabel3.Location = new System.Drawing.Point(933, 42);
		this.linkLabel3.Name = "linkLabel3";
		this.linkLabel3.Size = new System.Drawing.Size(73, 15);
		this.linkLabel3.TabIndex = 11;
		this.linkLabel3.TabStop = true;
		this.linkLabel3.Text = "Archivio LA7";
		this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
		this.linkLabel2.AutoSize = true;
		this.linkLabel2.DisabledLinkColor = System.Drawing.Color.White;
		this.linkLabel2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel2.ForeColor = System.Drawing.Color.White;
		this.linkLabel2.LinkColor = System.Drawing.Color.Yellow;
		this.linkLabel2.Location = new System.Drawing.Point(810, 65);
		this.linkLabel2.Name = "linkLabel2";
		this.linkLabel2.Size = new System.Drawing.Size(111, 15);
		this.linkLabel2.TabIndex = 10;
		this.linkLabel2.TabStop = true;
		this.linkLabel2.Text = "Archivio MEDIASET";
		this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.DisabledLinkColor = System.Drawing.Color.White;
		this.linkLabel1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel1.ForeColor = System.Drawing.Color.White;
		this.linkLabel1.LinkColor = System.Drawing.Color.Yellow;
		this.linkLabel1.Location = new System.Drawing.Point(810, 42);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(71, 15);
		this.linkLabel1.TabIndex = 9;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "Archivio RAI";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
		this.groupBox1.Controls.Add(this.radioButton4);
		this.groupBox1.Controls.Add(this.radioButton3);
		this.groupBox1.Controls.Add(this.radioButton2);
		this.groupBox1.Controls.Add(this.radioButton1);
		this.groupBox1.ForeColor = System.Drawing.Color.White;
		this.groupBox1.Location = new System.Drawing.Point(351, 6);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox1.Size = new System.Drawing.Size(394, 77);
		this.groupBox1.TabIndex = 6;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Opzioni (Doppio click su programma per attivare opzioni)";
		this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
		this.radioButton4.AutoSize = true;
		this.radioButton4.Location = new System.Drawing.Point(202, 22);
		this.radioButton4.Margin = new System.Windows.Forms.Padding(2);
		this.radioButton4.Name = "radioButton4";
		this.radioButton4.Size = new System.Drawing.Size(170, 21);
		this.radioButton4.TabIndex = 3;
		this.radioButton4.Text = "Cancella REC/SHOW";
		this.radioButton4.UseVisualStyleBackColor = true;
		this.radioButton3.AutoSize = true;
		this.radioButton3.Location = new System.Drawing.Point(5, 43);
		this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(252, 21);
		this.radioButton3.TabIndex = 2;
		this.radioButton3.Text = "Cerca informazioni sul programma";
		this.radioButton3.UseVisualStyleBackColor = true;
		this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
		this.radioButton2.AutoSize = true;
		this.radioButton2.Checked = true;
		this.radioButton2.Location = new System.Drawing.Point(110, 22);
		this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(81, 21);
		this.radioButton2.TabIndex = 1;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "Registra";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton1.AutoSize = true;
		this.radioButton1.Location = new System.Drawing.Point(5, 22);
		this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(74, 21);
		this.radioButton1.TabIndex = 0;
		this.radioButton1.Text = "Guarda";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(810, 13);
		this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(35, 17);
		this.label3.TabIndex = 5;
		this.label3.Text = "Filtri";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(4, 9);
		this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(86, 17);
		this.label2.TabIndex = 3;
		this.label2.Text = "Data attuale";
		this.dateTimePicker1.Location = new System.Drawing.Point(112, 9);
		this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
		this.dateTimePicker1.Name = "dateTimePicker1";
		this.dateTimePicker1.Size = new System.Drawing.Size(226, 25);
		this.dateTimePicker1.TabIndex = 2;
		this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(857, 9);
		this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(105, 25);
		this.comboBox1.TabIndex = 4;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(4, 39);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(76, 17);
		this.label1.TabIndex = 1;
		this.label1.Text = "Progresso";
		this.progressBar1.Location = new System.Drawing.Point(7, 58);
		this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(330, 17);
		this.progressBar1.Step = 1;
		this.progressBar1.TabIndex = 0;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl1.Location = new System.Drawing.Point(0, 0);
		this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(1135, 478);
		this.tabControl1.TabIndex = 0;
		this.tabPage1.Controls.Add(this.pictureBox12);
		this.tabPage1.Controls.Add(this.pictureBox2);
		this.tabPage1.Controls.Add(this.pictureBox1);
		this.tabPage1.Controls.Add(this.listBox1);
		this.tabPage1.Controls.Add(this.listBox3);
		this.tabPage1.Controls.Add(this.listBox2);
		this.tabPage1.Controls.Add(this.pictureBox3);
		this.tabPage1.Controls.Add(this.pictureBox4);
		this.tabPage1.Controls.Add(this.pictureBox5);
		this.tabPage1.Location = new System.Drawing.Point(4, 26);
		this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
		this.tabPage1.Size = new System.Drawing.Size(1127, 448);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "RAI";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.pictureBox12.BackColor = System.Drawing.Color.FromArgb(70, 176, 77);
		this.pictureBox12.Image = ZeroItaTV.Properties.Resources.images;
		this.pictureBox12.Location = new System.Drawing.Point(809, 14);
		this.pictureBox12.Name = "pictureBox12";
		this.pictureBox12.Size = new System.Drawing.Size(100, 42);
		this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox12.TabIndex = 18;
		this.pictureBox12.TabStop = false;
		this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(233, 26, 34);
		this.pictureBox2.Image = ZeroItaTV.Properties.Resources.images2;
		this.pictureBox2.Location = new System.Drawing.Point(456, 14);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(100, 42);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox2.TabIndex = 17;
		this.pictureBox2.TabStop = false;
		this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(2, 70, 152);
		this.pictureBox1.Image = ZeroItaTV.Properties.Resources.Rai_Uno;
		this.pictureBox1.Location = new System.Drawing.Point(109, 18);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(100, 42);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 12;
		this.pictureBox1.TabStop = false;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.ItemHeight = 17;
		this.listBox1.Location = new System.Drawing.Point(13, 63);
		this.listBox1.Margin = new System.Windows.Forms.Padding(2);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(315, 293);
		this.listBox1.TabIndex = 0;
		this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
		this.listBox3.FormattingEnabled = true;
		this.listBox3.ItemHeight = 17;
		this.listBox3.Location = new System.Drawing.Point(698, 61);
		this.listBox3.Margin = new System.Windows.Forms.Padding(2);
		this.listBox3.Name = "listBox3";
		this.listBox3.Size = new System.Drawing.Size(315, 293);
		this.listBox3.TabIndex = 10;
		this.listBox3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox3_MouseDoubleClick);
		this.listBox2.FormattingEnabled = true;
		this.listBox2.ItemHeight = 17;
		this.listBox2.Location = new System.Drawing.Point(352, 61);
		this.listBox2.Margin = new System.Windows.Forms.Padding(2);
		this.listBox2.Name = "listBox2";
		this.listBox2.Size = new System.Drawing.Size(315, 293);
		this.listBox2.TabIndex = 8;
		this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
		this.pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
		this.pictureBox3.Location = new System.Drawing.Point(0, 2);
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.Size = new System.Drawing.Size(342, 390);
		this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox3.TabIndex = 14;
		this.pictureBox3.TabStop = false;
		this.pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
		this.pictureBox4.Location = new System.Drawing.Point(339, 2);
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.Size = new System.Drawing.Size(342, 390);
		this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox4.TabIndex = 15;
		this.pictureBox4.TabStop = false;
		this.pictureBox5.Image = (System.Drawing.Image)resources.GetObject("pictureBox5.Image");
		this.pictureBox5.Location = new System.Drawing.Point(685, 2);
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.Size = new System.Drawing.Size(342, 390);
		this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox5.TabIndex = 16;
		this.pictureBox5.TabStop = false;
		this.tabPage2.Controls.Add(this.pictureBox6);
		this.tabPage2.Controls.Add(this.listBox6);
		this.tabPage2.Controls.Add(this.listBox5);
		this.tabPage2.Controls.Add(this.listBox4);
		this.tabPage2.Controls.Add(this.pictureBox7);
		this.tabPage2.Controls.Add(this.pictureBox8);
		this.tabPage2.Controls.Add(this.pictureBox9);
		this.tabPage2.Controls.Add(this.pictureBox10);
		this.tabPage2.Controls.Add(this.pictureBox11);
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
		this.tabPage2.Size = new System.Drawing.Size(1127, 452);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "MEDIASET";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(212, 222, 234);
		this.pictureBox6.Image = ZeroItaTV.Properties.Resources._150px_rete_4svg;
		this.pictureBox6.Location = new System.Drawing.Point(108, 13);
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.Size = new System.Drawing.Size(100, 42);
		this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox6.TabIndex = 15;
		this.pictureBox6.TabStop = false;
		this.listBox6.FormattingEnabled = true;
		this.listBox6.ItemHeight = 17;
		this.listBox6.Location = new System.Drawing.Point(700, 59);
		this.listBox6.Margin = new System.Windows.Forms.Padding(2);
		this.listBox6.Name = "listBox6";
		this.listBox6.Size = new System.Drawing.Size(315, 293);
		this.listBox6.TabIndex = 12;
		this.listBox6.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox6_MouseDoubleClick);
		this.listBox5.FormattingEnabled = true;
		this.listBox5.ItemHeight = 17;
		this.listBox5.Location = new System.Drawing.Point(353, 59);
		this.listBox5.Margin = new System.Windows.Forms.Padding(2);
		this.listBox5.Name = "listBox5";
		this.listBox5.Size = new System.Drawing.Size(315, 293);
		this.listBox5.TabIndex = 10;
		this.listBox5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox5_MouseDoubleClick);
		this.listBox4.FormattingEnabled = true;
		this.listBox4.ItemHeight = 17;
		this.listBox4.Location = new System.Drawing.Point(11, 59);
		this.listBox4.Margin = new System.Windows.Forms.Padding(2);
		this.listBox4.Name = "listBox4";
		this.listBox4.Size = new System.Drawing.Size(315, 293);
		this.listBox4.TabIndex = 8;
		this.listBox4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox4_MouseDoubleClick);
		this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
		this.pictureBox7.Image = (System.Drawing.Image)resources.GetObject("pictureBox7.Image");
		this.pictureBox7.Location = new System.Drawing.Point(-1, 2);
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.Size = new System.Drawing.Size(342, 390);
		this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox7.TabIndex = 16;
		this.pictureBox7.TabStop = false;
		this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(212, 222, 234);
		this.pictureBox8.Image = (System.Drawing.Image)resources.GetObject("pictureBox8.Image");
		this.pictureBox8.Location = new System.Drawing.Point(455, 14);
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.Size = new System.Drawing.Size(100, 42);
		this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox8.TabIndex = 17;
		this.pictureBox8.TabStop = false;
		this.pictureBox9.Image = (System.Drawing.Image)resources.GetObject("pictureBox9.Image");
		this.pictureBox9.Location = new System.Drawing.Point(341, 0);
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.Size = new System.Drawing.Size(342, 390);
		this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox9.TabIndex = 18;
		this.pictureBox9.TabStop = false;
		this.pictureBox10.BackColor = System.Drawing.Color.FromArgb(212, 222, 234);
		this.pictureBox10.Image = (System.Drawing.Image)resources.GetObject("pictureBox10.Image");
		this.pictureBox10.Location = new System.Drawing.Point(800, 14);
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.Size = new System.Drawing.Size(100, 42);
		this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox10.TabIndex = 19;
		this.pictureBox10.TabStop = false;
		this.pictureBox11.Image = (System.Drawing.Image)resources.GetObject("pictureBox11.Image");
		this.pictureBox11.Location = new System.Drawing.Point(687, 0);
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.Size = new System.Drawing.Size(342, 390);
		this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox11.TabIndex = 20;
		this.pictureBox11.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1135, 615);
		base.Controls.Add(this.splitContainer1);
		this.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ForeColor = System.Drawing.Color.White;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ProgrammiTV";
		base.Opacity = 0.0;
		this.Text = "ProgrammiTV";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Load += new System.EventHandler(this.ProgrammiTV_Load);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		this.tabPage2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		base.ResumeLayout(false);
	}
}
