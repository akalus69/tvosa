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

public class Zapping : Form
{
	private Thread TTXV;

	private Thread TTXV2;

	public Form1 mio;

	public bool pausa = true;

	public int canalevisto = 0;

	public bool avantiindi = false;

	private IContainer components = null;

	private SplitContainer splitContainer1;

	private GroupBox groupBox1;

	private Label label1;

	private GroupBox groupBox2;

	private Button button2;

	private Button button1;

	private GroupBox groupBox3;

	private CheckBox checkBox7;

	private CheckBox checkBox6;

	private CheckBox checkBox5;

	private CheckBox checkBox4;

	private CheckBox checkBox3;

	private CheckBox checkBox2;

	private CheckBox checkBox1;

	private CheckBox checkBox18;

	private CheckBox checkBox17;

	private CheckBox checkBox16;

	private CheckBox checkBox15;

	private CheckBox checkBox14;

	private CheckBox checkBox13;

	private CheckBox checkBox12;

	private CheckBox checkBox11;

	private CheckBox checkBox10;

	private CheckBox checkBox9;

	private CheckBox checkBox8;

	private RadioButton radioButton2;

	private RadioButton radioButton1;

	private Button button4;

	private Button button3;

	private CheckBox checkBox20;

	private CheckBox checkBox19;

	public GroupBox groupBox4;

	public Label label3;

	private CheckBox checkBox21;

	private CheckBox checkBox23;

	private CheckBox checkBox22;

	private GroupBox groupBox6;

	private RadioButton radioButton4;

	private GroupBox groupBox5;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem togliDaListaCanaliSelezionatiToolStripMenuItem;

	public ListBox listBox1;

	public ComboBox comboBox1;

	public RadioButton radioButton3;

	private GroupBox groupBox7;

	private Button button6;

	private Button button5;

	public Zapping(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	private void leggicanali()
	{
		try
		{
			listBox1.Items.Clear();
			List<string> list = new List<string>();
			try
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\canaliesclusi.txt");
				string text = "";
				while ((text = streamReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				streamReader.Close();
			}
			catch (Exception)
			{
			}
			try
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\canaliesclusipersonali.txt");
				string text = "";
				while ((text = streamReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				streamReader.Close();
			}
			catch (Exception)
			{
			}
			StreamReader streamReader2 = new StreamReader(Program.pr + "\\nuovicanali.txt");
			string text2 = "";
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			List<string> list2 = new List<string>();
			while ((text2 = streamReader2.ReadLine()) != null)
			{
				num++;
				bool flag = true;
				if (!checkBox1.Checked)
				{
					if (text2.IndexOf("(Rai)") >= 0)
					{
						flag = false;
					}
				}
				else if (num2 == 0)
				{
					num2++;
				}
				if (!checkBox2.Checked)
				{
					if (text2.IndexOf("(Mediaset)") >= 0)
					{
						flag = false;
					}
				}
				else if (num3 == 0)
				{
					num3++;
				}
				if (!checkBox3.Checked && text2.IndexOf("(Divertimento)") >= 0)
				{
					flag = false;
				}
				if (!checkBox4.Checked && text2.IndexOf("(Cinema)") >= 0)
				{
					flag = false;
				}
				if (!checkBox5.Checked && text2.IndexOf("(Generalista)") >= 0)
				{
					flag = false;
				}
				if (!checkBox6.Checked && text2.IndexOf("(Sport)") >= 0)
				{
					flag = false;
				}
				if (!checkBox8.Checked && text2.IndexOf("(Musica)") >= 0)
				{
					flag = false;
				}
				if (!checkBox7.Checked && text2.IndexOf("(Regionale)") >= 0)
				{
					flag = false;
				}
				if (!checkBox9.Checked && text2.IndexOf("(Notiziari)") >= 0)
				{
					flag = false;
				}
				if (!checkBox10.Checked && text2.IndexOf("(Cultura)") >= 0)
				{
					flag = false;
				}
				if (!checkBox12.Checked && text2.IndexOf("(Moda)") >= 0)
				{
					flag = false;
				}
				if (!checkBox4.Checked && text2.IndexOf("(Eventi)") >= 0)
				{
					flag = false;
				}
				if (!checkBox11.Checked && text2.IndexOf("(Tecnologia)") >= 0)
				{
					flag = false;
				}
				if (!checkBox14.Checked && text2.IndexOf("(Religione)") >= 0)
				{
					flag = false;
				}
				if (!checkBox16.Checked && text2.IndexOf("(Televendita)") >= 0)
				{
					flag = false;
				}
				if (!checkBox15.Checked && text2.IndexOf("(Arte)") >= 0)
				{
					flag = false;
				}
				if (!checkBox17.Checked && text2.IndexOf("(Fiera)") >= 0)
				{
					flag = false;
				}
				if (!checkBox18.Checked && text2.IndexOf("(Documentari)") >= 0)
				{
					flag = false;
				}
				if (!checkBox19.Checked && text2.IndexOf("(Radio)") >= 0)
				{
					flag = false;
				}
				if (!checkBox20.Checked && text2.IndexOf("(Esteri)") >= 0)
				{
					flag = false;
				}
				if (!checkBox21.Checked && text2.IndexOf("(WebCam)") >= 0)
				{
					flag = false;
				}
				if (!checkBox22.Checked && text2.IndexOf("(Hot)") >= 0)
				{
					flag = false;
				}
				if (!checkBox23.Checked && text2.IndexOf("(Meteo)") >= 0)
				{
					flag = false;
				}
				if (text2.IndexOf("(Ricerca)") >= 0)
				{
					flag = false;
				}
				string item = streamReader2.ReadLine();
				if (flag && !list.Contains(item))
				{
					list2.Add(text2);
				}
			}
			list2.Sort();
			num += 6;
			label3.Text = "Numero : " + list2.Count;
			streamReader2.Close();
			foreach (string item2 in list2)
			{
				listBox1.Items.Add(item2);
			}
		}
		catch
		{
		}
	}

	private void riempicombobox()
	{
		try
		{
			for (int i = 15; i < 151; i++)
			{
				if (i % 5 == 0)
				{
					comboBox1.Items.Add(i);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void Zapping_Load(object sender, EventArgs e)
	{
		try
		{
			int num = Screen.PrimaryScreen.Bounds.Width;
			int num2 = Screen.PrimaryScreen.Bounds.Height;
			Location = new Point(num - Size.Width, num2 - Size.Height - 50);
			riempicombobox();
			comboBox1.SelectedIndex = 1;
			leggiconf();
			leggicanali();
		}
		catch (Exception)
		{
			throw;
		}
	}

	private void checkBox20_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void radioButton1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			TTXV.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			ThreadZapping threadZapping = new ThreadZapping(this);
			TTXV = new Thread(threadZapping.apriopz);
			TTXV.IsBackground = true;
			TTXV.Priority = ThreadPriority.BelowNormal;
			TTXV.Start();
		}
		catch (Exception)
		{
		}
	}

	private void radioButton2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			TTXV.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			ThreadZapping threadZapping = new ThreadZapping(this);
			TTXV = new Thread(threadZapping.chiudiopz);
			TTXV.IsBackground = true;
			TTXV.Priority = ThreadPriority.BelowNormal;
			TTXV.Start();
		}
		catch (Exception)
		{
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox2_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox4_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void groupBox3_Enter(object sender, EventArgs e)
	{
	}

	private void checkBox5_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox6_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox8_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox7_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox9_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox10_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox12_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox13_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox11_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox14_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox16_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox15_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox17_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox18_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox19_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox22_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox23_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void checkBox21_CheckedChanged(object sender, EventArgs e)
	{
		leggicanali();
	}

	private void Zapping_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			TTXV2.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\confzapping.4x4");
			streamWriter.WriteLine(Location.X + ";" + Location.Y);
			streamWriter.WriteLine(comboBox1.SelectedIndex.ToString());
			streamWriter.WriteLine(radioButton1.Checked.ToString());
			streamWriter.WriteLine(radioButton3.Checked.ToString());
			streamWriter.WriteLine(checkBox1.Checked.ToString());
			streamWriter.WriteLine(checkBox2.Checked.ToString());
			streamWriter.WriteLine(checkBox3.Checked.ToString());
			streamWriter.WriteLine(checkBox4.Checked.ToString());
			streamWriter.WriteLine(checkBox5.Checked.ToString());
			streamWriter.WriteLine(checkBox6.Checked.ToString());
			streamWriter.WriteLine(checkBox7.Checked.ToString());
			streamWriter.WriteLine(checkBox8.Checked.ToString());
			streamWriter.WriteLine(checkBox9.Checked.ToString());
			streamWriter.WriteLine(checkBox10.Checked.ToString());
			streamWriter.WriteLine(checkBox11.Checked.ToString());
			streamWriter.WriteLine(checkBox12.Checked.ToString());
			streamWriter.WriteLine(checkBox13.Checked.ToString());
			streamWriter.WriteLine(checkBox14.Checked.ToString());
			streamWriter.WriteLine(checkBox15.Checked.ToString());
			streamWriter.WriteLine(checkBox16.Checked.ToString());
			streamWriter.WriteLine(checkBox17.Checked.ToString());
			streamWriter.WriteLine(checkBox18.Checked.ToString());
			streamWriter.WriteLine(checkBox19.Checked.ToString());
			streamWriter.WriteLine(checkBox20.Checked.ToString());
			streamWriter.WriteLine(checkBox21.Checked.ToString());
			streamWriter.WriteLine(checkBox22.Checked.ToString());
			streamWriter.WriteLine(checkBox23.Checked.ToString());
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
	}

	private void leggiconf()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\confzapping.4x4");
			string text = streamReader.ReadLine();
			string s = text.Substring(0, text.IndexOf(";"));
			string s2 = text.Substring(text.IndexOf(";") + 1);
			int num = int.Parse(s);
			int num2 = int.Parse(s2);
			Location = new Point(num, num2);
			text = streamReader.ReadLine();
			text = text.Replace(" ", "");
			comboBox1.SelectedIndex = int.Parse(text);
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				Size = new Size(457, 437);
				radioButton1.Checked = true;
			}
			else
			{
				Size = new Size(457, 147);
				radioButton2.Checked = true;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				radioButton3.Checked = true;
			}
			else
			{
				radioButton4.Checked = true;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox1.Checked = true;
			}
			else
			{
				checkBox1.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox2.Checked = true;
			}
			else
			{
				checkBox2.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox3.Checked = true;
			}
			else
			{
				checkBox3.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox4.Checked = true;
			}
			else
			{
				checkBox4.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox5.Checked = true;
			}
			else
			{
				checkBox5.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox6.Checked = true;
			}
			else
			{
				checkBox6.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox7.Checked = true;
			}
			else
			{
				checkBox7.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox8.Checked = true;
			}
			else
			{
				checkBox8.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox9.Checked = true;
			}
			else
			{
				checkBox9.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox10.Checked = true;
			}
			else
			{
				checkBox10.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox11.Checked = true;
			}
			else
			{
				checkBox11.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox12.Checked = true;
			}
			else
			{
				checkBox12.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox13.Checked = true;
			}
			else
			{
				checkBox13.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox14.Checked = true;
			}
			else
			{
				checkBox14.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox15.Checked = true;
			}
			else
			{
				checkBox15.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox16.Checked = true;
			}
			else
			{
				checkBox16.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox17.Checked = true;
			}
			else
			{
				checkBox17.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox18.Checked = true;
			}
			else
			{
				checkBox18.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox19.Checked = true;
			}
			else
			{
				checkBox19.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox20.Checked = true;
			}
			else
			{
				checkBox20.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox21.Checked = true;
			}
			else
			{
				checkBox21.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox22.Checked = true;
			}
			else
			{
				checkBox22.Checked = false;
			}
			text = streamReader.ReadLine();
			if (bool.Parse(text))
			{
				checkBox23.Checked = true;
			}
			else
			{
				checkBox23.Checked = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private void togliDaListaCanaliSelezionatiToolStripMenuItem_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		foreach (object item in listBox1.Items)
		{
			list.Add(item.ToString());
		}
		foreach (object selectedItem in listBox1.SelectedItems)
		{
			list.Remove(selectedItem.ToString());
		}
		listBox1.Items.Clear();
		foreach (string item2 in list)
		{
			listBox1.Items.Add(item2);
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (!pausa)
		{
			pausa = true;
			button1.Text = "Play";
			return;
		}
		pausa = false;
		button1.Text = "Pause";
		try
		{
			if (TTXV2 == null || !TTXV2.IsAlive)
			{
				ThreadZapping threadZapping = new ThreadZapping(this);
				TTXV2 = new Thread(threadZapping.vai);
				TTXV2.IsBackground = true;
				TTXV2.Priority = ThreadPriority.BelowNormal;
				TTXV2.Start();
			}
		}
		catch (Exception)
		{
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			TTXV2.Abort();
		}
		catch (Exception)
		{
		}
		pausa = true;
		button1.Text = "Play";
	}

	private void button3_Click(object sender, EventArgs e)
	{
		avantiindi = true;
		try
		{
			TTXV2.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			Thread.Sleep(500);
			try
			{
				if (TTXV2 == null || !TTXV2.IsAlive)
				{
					ThreadZapping threadZapping = new ThreadZapping(this);
					TTXV2 = new Thread(threadZapping.vai);
					TTXV2.IsBackground = true;
					TTXV2.Priority = ThreadPriority.BelowNormal;
					TTXV2.Start();
					listBox1.SelectedItem = listBox1.Items[listBox1.SelectedIndex + 1];
				}
			}
			catch (Exception)
			{
			}
		}
		catch
		{
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		avantiindi = true;
		try
		{
			TTXV2.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			Thread.Sleep(500);
			try
			{
				if (TTXV2 == null || !TTXV2.IsAlive)
				{
					ThreadZapping threadZapping = new ThreadZapping(this);
					TTXV2 = new Thread(threadZapping.vai);
					TTXV2.IsBackground = true;
					TTXV2.Priority = ThreadPriority.BelowNormal;
					TTXV2.Start();
					listBox1.SelectedItem = listBox1.Items[listBox1.SelectedIndex - 1];
				}
			}
			catch (Exception)
			{
			}
		}
		catch
		{
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		try
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (!Directory.Exists(Program.pr + "\\ZappingDIR"))
			{
				Directory.CreateDirectory(Program.pr + "\\ZappingDIR");
			}
			saveFileDialog.InitialDirectory = Program.pr + "\\ZappingDIR";
			saveFileDialog.ShowDialog();
			if (string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				return;
			}
			StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
			foreach (string item in listBox1.Items)
			{
				streamWriter.WriteLine(item);
			}
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
	}

	private void button6_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (!Directory.Exists(Program.pr + "\\ZappingDIR"))
			{
				Directory.CreateDirectory(Program.pr + "\\ZappingDIR");
			}
			openFileDialog.InitialDirectory = Program.pr + "\\ZappingDIR";
			openFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(openFileDialog.FileName))
			{
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);
				string text = "";
				while ((text = streamReader.ReadLine()) != null)
				{
					listBox1.Items.Add(text);
				}
				streamReader.Close();
			}
		}
		catch (Exception)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Zapping));
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.radioButton4 = new System.Windows.Forms.RadioButton();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label3 = new System.Windows.Forms.Label();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.checkBox23 = new System.Windows.Forms.CheckBox();
		this.checkBox22 = new System.Windows.Forms.CheckBox();
		this.checkBox21 = new System.Windows.Forms.CheckBox();
		this.checkBox20 = new System.Windows.Forms.CheckBox();
		this.checkBox19 = new System.Windows.Forms.CheckBox();
		this.checkBox18 = new System.Windows.Forms.CheckBox();
		this.checkBox17 = new System.Windows.Forms.CheckBox();
		this.checkBox16 = new System.Windows.Forms.CheckBox();
		this.checkBox15 = new System.Windows.Forms.CheckBox();
		this.checkBox14 = new System.Windows.Forms.CheckBox();
		this.checkBox13 = new System.Windows.Forms.CheckBox();
		this.checkBox12 = new System.Windows.Forms.CheckBox();
		this.checkBox11 = new System.Windows.Forms.CheckBox();
		this.checkBox10 = new System.Windows.Forms.CheckBox();
		this.checkBox9 = new System.Windows.Forms.CheckBox();
		this.checkBox8 = new System.Windows.Forms.CheckBox();
		this.checkBox7 = new System.Windows.Forms.CheckBox();
		this.checkBox6 = new System.Windows.Forms.CheckBox();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.label1 = new System.Windows.Forms.Label();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.togliDaListaCanaliSelezionatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.button4 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.groupBox7 = new System.Windows.Forms.GroupBox();
		this.button5 = new System.Windows.Forms.Button();
		this.button6 = new System.Windows.Forms.Button();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.groupBox7.SuspendLayout();
		base.SuspendLayout();
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
		this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
		this.splitContainer1.Size = new System.Drawing.Size(441, 401);
		this.splitContainer1.SplitterDistance = 339;
		this.splitContainer1.TabIndex = 0;
		this.groupBox1.Controls.Add(this.groupBox7);
		this.groupBox1.Controls.Add(this.groupBox6);
		this.groupBox1.Controls.Add(this.groupBox5);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.groupBox3);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.listBox1);
		this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox1.Location = new System.Drawing.Point(0, 0);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(441, 339);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Opzioni";
		this.groupBox6.Controls.Add(this.radioButton4);
		this.groupBox6.Controls.Add(this.radioButton3);
		this.groupBox6.Location = new System.Drawing.Point(164, 274);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new System.Drawing.Size(96, 52);
		this.groupBox6.TabIndex = 7;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "Random";
		this.radioButton4.AutoSize = true;
		this.radioButton4.Location = new System.Drawing.Point(48, 19);
		this.radioButton4.Name = "radioButton4";
		this.radioButton4.Size = new System.Drawing.Size(39, 17);
		this.radioButton4.TabIndex = 1;
		this.radioButton4.TabStop = true;
		this.radioButton4.Text = "No";
		this.radioButton4.UseVisualStyleBackColor = true;
		this.radioButton3.AutoSize = true;
		this.radioButton3.Location = new System.Drawing.Point(8, 19);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(34, 17);
		this.radioButton3.TabIndex = 0;
		this.radioButton3.TabStop = true;
		this.radioButton3.Text = "Si";
		this.radioButton3.UseVisualStyleBackColor = true;
		this.groupBox5.Controls.Add(this.comboBox1);
		this.groupBox5.Location = new System.Drawing.Point(12, 274);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(146, 52);
		this.groupBox5.TabIndex = 6;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Tempo Zapping (secondi)";
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(6, 19);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(127, 21);
		this.comboBox1.TabIndex = 3;
		this.label3.Location = new System.Drawing.Point(293, 18);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(136, 13);
		this.label3.TabIndex = 5;
		this.label3.Text = "Numero : 10";
		this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.groupBox3.Controls.Add(this.checkBox23);
		this.groupBox3.Controls.Add(this.checkBox22);
		this.groupBox3.Controls.Add(this.checkBox21);
		this.groupBox3.Controls.Add(this.checkBox20);
		this.groupBox3.Controls.Add(this.checkBox19);
		this.groupBox3.Controls.Add(this.checkBox18);
		this.groupBox3.Controls.Add(this.checkBox17);
		this.groupBox3.Controls.Add(this.checkBox16);
		this.groupBox3.Controls.Add(this.checkBox15);
		this.groupBox3.Controls.Add(this.checkBox14);
		this.groupBox3.Controls.Add(this.checkBox13);
		this.groupBox3.Controls.Add(this.checkBox12);
		this.groupBox3.Controls.Add(this.checkBox11);
		this.groupBox3.Controls.Add(this.checkBox10);
		this.groupBox3.Controls.Add(this.checkBox9);
		this.groupBox3.Controls.Add(this.checkBox8);
		this.groupBox3.Controls.Add(this.checkBox7);
		this.groupBox3.Controls.Add(this.checkBox6);
		this.groupBox3.Controls.Add(this.checkBox5);
		this.groupBox3.Controls.Add(this.checkBox4);
		this.groupBox3.Controls.Add(this.checkBox3);
		this.groupBox3.Controls.Add(this.checkBox2);
		this.groupBox3.Controls.Add(this.checkBox1);
		this.groupBox3.Location = new System.Drawing.Point(12, 109);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(417, 159);
		this.groupBox3.TabIndex = 2;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Generi inclusi";
		this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
		this.checkBox23.AutoSize = true;
		this.checkBox23.Location = new System.Drawing.Point(62, 136);
		this.checkBox23.Name = "checkBox23";
		this.checkBox23.Size = new System.Drawing.Size(56, 17);
		this.checkBox23.TabIndex = 22;
		this.checkBox23.Text = "Meteo";
		this.checkBox23.UseVisualStyleBackColor = true;
		this.checkBox23.CheckedChanged += new System.EventHandler(this.checkBox23_CheckedChanged);
		this.checkBox22.AutoSize = true;
		this.checkBox22.Location = new System.Drawing.Point(6, 136);
		this.checkBox22.Name = "checkBox22";
		this.checkBox22.Size = new System.Drawing.Size(43, 17);
		this.checkBox22.TabIndex = 21;
		this.checkBox22.Text = "Hot";
		this.checkBox22.UseVisualStyleBackColor = true;
		this.checkBox22.CheckedChanged += new System.EventHandler(this.checkBox22_CheckedChanged);
		this.checkBox21.AutoSize = true;
		this.checkBox21.Location = new System.Drawing.Point(140, 136);
		this.checkBox21.Name = "checkBox21";
		this.checkBox21.Size = new System.Drawing.Size(70, 17);
		this.checkBox21.TabIndex = 20;
		this.checkBox21.Text = "WebCam";
		this.checkBox21.UseVisualStyleBackColor = true;
		this.checkBox21.CheckedChanged += new System.EventHandler(this.checkBox21_CheckedChanged);
		this.checkBox20.AutoSize = true;
		this.checkBox20.Location = new System.Drawing.Point(316, 106);
		this.checkBox20.Name = "checkBox20";
		this.checkBox20.Size = new System.Drawing.Size(52, 17);
		this.checkBox20.TabIndex = 19;
		this.checkBox20.Text = "Esteri";
		this.checkBox20.UseVisualStyleBackColor = true;
		this.checkBox20.CheckedChanged += new System.EventHandler(this.checkBox20_CheckedChanged);
		this.checkBox19.AutoSize = true;
		this.checkBox19.Location = new System.Drawing.Point(234, 106);
		this.checkBox19.Name = "checkBox19";
		this.checkBox19.Size = new System.Drawing.Size(54, 17);
		this.checkBox19.TabIndex = 18;
		this.checkBox19.Text = "Radio";
		this.checkBox19.UseVisualStyleBackColor = true;
		this.checkBox19.CheckedChanged += new System.EventHandler(this.checkBox19_CheckedChanged);
		this.checkBox18.AutoSize = true;
		this.checkBox18.Location = new System.Drawing.Point(140, 106);
		this.checkBox18.Name = "checkBox18";
		this.checkBox18.Size = new System.Drawing.Size(86, 17);
		this.checkBox18.TabIndex = 17;
		this.checkBox18.Text = "Documentari";
		this.checkBox18.UseVisualStyleBackColor = true;
		this.checkBox18.CheckedChanged += new System.EventHandler(this.checkBox18_CheckedChanged);
		this.checkBox17.AutoSize = true;
		this.checkBox17.Location = new System.Drawing.Point(62, 106);
		this.checkBox17.Name = "checkBox17";
		this.checkBox17.Size = new System.Drawing.Size(49, 17);
		this.checkBox17.TabIndex = 16;
		this.checkBox17.Text = "Fiera";
		this.checkBox17.UseVisualStyleBackColor = true;
		this.checkBox17.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
		this.checkBox16.AutoSize = true;
		this.checkBox16.Location = new System.Drawing.Point(316, 77);
		this.checkBox16.Name = "checkBox16";
		this.checkBox16.Size = new System.Drawing.Size(82, 17);
		this.checkBox16.TabIndex = 15;
		this.checkBox16.Text = "Televendita";
		this.checkBox16.UseVisualStyleBackColor = true;
		this.checkBox16.CheckedChanged += new System.EventHandler(this.checkBox16_CheckedChanged);
		this.checkBox15.AutoSize = true;
		this.checkBox15.Location = new System.Drawing.Point(6, 106);
		this.checkBox15.Name = "checkBox15";
		this.checkBox15.Size = new System.Drawing.Size(45, 17);
		this.checkBox15.TabIndex = 14;
		this.checkBox15.Text = "Arte";
		this.checkBox15.UseVisualStyleBackColor = true;
		this.checkBox15.CheckedChanged += new System.EventHandler(this.checkBox15_CheckedChanged);
		this.checkBox14.AutoSize = true;
		this.checkBox14.Location = new System.Drawing.Point(234, 77);
		this.checkBox14.Name = "checkBox14";
		this.checkBox14.Size = new System.Drawing.Size(70, 17);
		this.checkBox14.TabIndex = 13;
		this.checkBox14.Text = "Religione";
		this.checkBox14.UseVisualStyleBackColor = true;
		this.checkBox14.CheckedChanged += new System.EventHandler(this.checkBox14_CheckedChanged);
		this.checkBox13.AutoSize = true;
		this.checkBox13.Location = new System.Drawing.Point(62, 77);
		this.checkBox13.Name = "checkBox13";
		this.checkBox13.Size = new System.Drawing.Size(56, 17);
		this.checkBox13.TabIndex = 12;
		this.checkBox13.Text = "Eventi";
		this.checkBox13.UseVisualStyleBackColor = true;
		this.checkBox13.CheckedChanged += new System.EventHandler(this.checkBox13_CheckedChanged);
		this.checkBox12.AutoSize = true;
		this.checkBox12.Location = new System.Drawing.Point(6, 77);
		this.checkBox12.Name = "checkBox12";
		this.checkBox12.Size = new System.Drawing.Size(53, 17);
		this.checkBox12.TabIndex = 11;
		this.checkBox12.Text = "Moda";
		this.checkBox12.UseVisualStyleBackColor = true;
		this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
		this.checkBox11.AutoSize = true;
		this.checkBox11.Location = new System.Drawing.Point(140, 77);
		this.checkBox11.Name = "checkBox11";
		this.checkBox11.Size = new System.Drawing.Size(79, 17);
		this.checkBox11.TabIndex = 10;
		this.checkBox11.Text = "Tecnologia";
		this.checkBox11.UseVisualStyleBackColor = true;
		this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
		this.checkBox10.AutoSize = true;
		this.checkBox10.Location = new System.Drawing.Point(316, 49);
		this.checkBox10.Name = "checkBox10";
		this.checkBox10.Size = new System.Drawing.Size(59, 17);
		this.checkBox10.TabIndex = 9;
		this.checkBox10.Text = "Cultura";
		this.checkBox10.UseVisualStyleBackColor = true;
		this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
		this.checkBox9.AutoSize = true;
		this.checkBox9.Location = new System.Drawing.Point(234, 49);
		this.checkBox9.Name = "checkBox9";
		this.checkBox9.Size = new System.Drawing.Size(63, 17);
		this.checkBox9.TabIndex = 8;
		this.checkBox9.Text = "Notiziari";
		this.checkBox9.UseVisualStyleBackColor = true;
		this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
		this.checkBox8.AutoSize = true;
		this.checkBox8.Location = new System.Drawing.Point(62, 49);
		this.checkBox8.Name = "checkBox8";
		this.checkBox8.Size = new System.Drawing.Size(60, 17);
		this.checkBox8.TabIndex = 7;
		this.checkBox8.Text = "Musica";
		this.checkBox8.UseVisualStyleBackColor = true;
		this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
		this.checkBox7.AutoSize = true;
		this.checkBox7.Location = new System.Drawing.Point(140, 49);
		this.checkBox7.Name = "checkBox7";
		this.checkBox7.Size = new System.Drawing.Size(74, 17);
		this.checkBox7.TabIndex = 6;
		this.checkBox7.Text = "Regionale";
		this.checkBox7.UseVisualStyleBackColor = true;
		this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
		this.checkBox6.AutoSize = true;
		this.checkBox6.Location = new System.Drawing.Point(6, 49);
		this.checkBox6.Name = "checkBox6";
		this.checkBox6.Size = new System.Drawing.Size(51, 17);
		this.checkBox6.TabIndex = 5;
		this.checkBox6.Text = "Sport";
		this.checkBox6.UseVisualStyleBackColor = true;
		this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
		this.checkBox5.AutoSize = true;
		this.checkBox5.Location = new System.Drawing.Point(316, 19);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(79, 17);
		this.checkBox5.TabIndex = 4;
		this.checkBox5.Text = "Generalista";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
		this.checkBox4.AutoSize = true;
		this.checkBox4.Location = new System.Drawing.Point(234, 19);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(61, 17);
		this.checkBox4.TabIndex = 3;
		this.checkBox4.Text = "Cinema";
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
		this.checkBox3.AutoSize = true;
		this.checkBox3.Location = new System.Drawing.Point(140, 19);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(85, 17);
		this.checkBox3.TabIndex = 2;
		this.checkBox3.Text = "Divertimento";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
		this.checkBox2.AutoSize = true;
		this.checkBox2.Location = new System.Drawing.Point(62, 19);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(69, 17);
		this.checkBox2.TabIndex = 1;
		this.checkBox2.Text = "Mediaset";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(6, 19);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(42, 17);
		this.checkBox1.TabIndex = 0;
		this.checkBox1.Text = "Rai";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(10, 19);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(136, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Canali in cui fare lo zapping";
		this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Location = new System.Drawing.Point(12, 34);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(417, 69);
		this.listBox1.TabIndex = 0;
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.togliDaListaCanaliSelezionatiToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(234, 26);
		this.togliDaListaCanaliSelezionatiToolStripMenuItem.Name = "togliDaListaCanaliSelezionatiToolStripMenuItem";
		this.togliDaListaCanaliSelezionatiToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
		this.togliDaListaCanaliSelezionatiToolStripMenuItem.Text = "Togli da lista canali selezionati";
		this.togliDaListaCanaliSelezionatiToolStripMenuItem.Click += new System.EventHandler(this.togliDaListaCanaliSelezionatiToolStripMenuItem_Click);
		this.groupBox2.Controls.Add(this.button4);
		this.groupBox2.Controls.Add(this.button3);
		this.groupBox2.Controls.Add(this.groupBox4);
		this.groupBox2.Controls.Add(this.button2);
		this.groupBox2.Controls.Add(this.button1);
		this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox2.Location = new System.Drawing.Point(0, 0);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(441, 58);
		this.groupBox2.TabIndex = 0;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Comandi";
		this.button4.Location = new System.Drawing.Point(152, 25);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(54, 23);
		this.button4.TabIndex = 4;
		this.button4.Text = "<<";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.button3.Location = new System.Drawing.Point(212, 25);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(54, 23);
		this.button3.TabIndex = 3;
		this.button3.Text = ">>";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.groupBox4.Controls.Add(this.radioButton2);
		this.groupBox4.Controls.Add(this.radioButton1);
		this.groupBox4.Location = new System.Drawing.Point(309, 19);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(120, 35);
		this.groupBox4.TabIndex = 2;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Apri Opzioni";
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(61, 12);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(39, 17);
		this.radioButton2.TabIndex = 1;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "No";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
		this.radioButton1.AutoSize = true;
		this.radioButton1.Location = new System.Drawing.Point(6, 12);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(34, 17);
		this.radioButton1.TabIndex = 0;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "Si";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
		this.button2.Location = new System.Drawing.Point(74, 25);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(54, 23);
		this.button2.TabIndex = 1;
		this.button2.Text = "Stop";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.button1.Location = new System.Drawing.Point(6, 25);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(54, 23);
		this.button1.TabIndex = 0;
		this.button1.Text = "Play";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.groupBox7.Controls.Add(this.button6);
		this.groupBox7.Controls.Add(this.button5);
		this.groupBox7.Location = new System.Drawing.Point(266, 274);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Size = new System.Drawing.Size(163, 52);
		this.groupBox7.TabIndex = 8;
		this.groupBox7.TabStop = false;
		this.groupBox7.Text = "Opzioni Lista";
		this.button5.Location = new System.Drawing.Point(5, 19);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(75, 23);
		this.button5.TabIndex = 0;
		this.button5.Text = "Salva";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.button6.Location = new System.Drawing.Point(83, 19);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(75, 23);
		this.button6.TabIndex = 1;
		this.button6.Text = "Carica";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(this.button6_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(441, 401);
		base.Controls.Add(this.splitContainer1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "Zapping";
		this.Text = "Zapping";
		base.TopMost = true;
		base.Load += new System.EventHandler(this.Zapping_Load);
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Zapping_FormClosing);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.contextMenuStrip1.ResumeLayout(false);
		this.groupBox2.ResumeLayout(false);
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox7.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
