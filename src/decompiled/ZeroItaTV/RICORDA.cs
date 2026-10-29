// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZeroItaTV;

public class RICORDA : Form
{
	private IContainer components = null;

	private Label label1;

	public ListBox listBox1;

	private Button button2;

	private CheckBox checkBox1;

	private SplitContainer splitContainer1;

	private SplitContainer splitContainer2;

	private SplitContainer splitContainer3;

	private Button button4;

	private Label label3;

	private ComboBox comboBox1;

	private Label label2;

	public Button button1;

	public Button button3;

	private IList<string> listatotalecanali = new List<string>();

	private IList<string> listalettac = new List<string>();

	private Form1 mio = Program.mio;

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.RICORDA));
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.label1 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.splitContainer2 = new System.Windows.Forms.SplitContainer();
		this.splitContainer3 = new System.Windows.Forms.SplitContainer();
		this.button4 = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label2 = new System.Windows.Forms.Label();
		this.button3 = new System.Windows.Forms.Button();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.splitContainer2.Panel1.SuspendLayout();
		this.splitContainer2.Panel2.SuspendLayout();
		this.splitContainer2.SuspendLayout();
		this.splitContainer3.Panel1.SuspendLayout();
		this.splitContainer3.Panel2.SuspendLayout();
		this.splitContainer3.SuspendLayout();
		base.SuspendLayout();
		this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.listBox1.FormattingEnabled = true;
		this.listBox1.ItemHeight = 15;
		this.listBox1.Location = new System.Drawing.Point(0, 0);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(745, 274);
		this.listBox1.TabIndex = 0;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(3, 6);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(120, 16);
		this.label1.TabIndex = 1;
		this.label1.Text = "Risultati Ottenuti";
		this.button1.Location = new System.Drawing.Point(403, 16);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(216, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "Su Evento Selezionato Non avvisare più";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.button2.Location = new System.Drawing.Point(16, 44);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(338, 23);
		this.button2.TabIndex = 3;
		this.button2.Text = "Mostra Canale Selezionato";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(6, 14);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(95, 17);
		this.checkBox1.TabIndex = 4;
		this.checkBox1.Text = "Avviso Sonoro";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
		this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
		this.splitContainer1.Size = new System.Drawing.Size(745, 396);
		this.splitContainer1.SplitterDistance = 303;
		this.splitContainer1.TabIndex = 5;
		this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer2.Location = new System.Drawing.Point(0, 0);
		this.splitContainer2.Name = "splitContainer2";
		this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer2.Panel1.Controls.Add(this.label1);
		this.splitContainer2.Panel2.Controls.Add(this.listBox1);
		this.splitContainer2.Size = new System.Drawing.Size(745, 303);
		this.splitContainer2.SplitterDistance = 25;
		this.splitContainer2.TabIndex = 1;
		this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer3.Location = new System.Drawing.Point(0, 0);
		this.splitContainer3.Name = "splitContainer3";
		this.splitContainer3.Panel1.Controls.Add(this.checkBox1);
		this.splitContainer3.Panel2.Controls.Add(this.button4);
		this.splitContainer3.Panel2.Controls.Add(this.label3);
		this.splitContainer3.Panel2.Controls.Add(this.comboBox1);
		this.splitContainer3.Panel2.Controls.Add(this.label2);
		this.splitContainer3.Panel2.Controls.Add(this.button3);
		this.splitContainer3.Panel2.Controls.Add(this.button1);
		this.splitContainer3.Panel2.Controls.Add(this.button2);
		this.splitContainer3.Size = new System.Drawing.Size(745, 89);
		this.splitContainer3.SplitterDistance = 110;
		this.splitContainer3.TabIndex = 5;
		this.button4.Location = new System.Drawing.Point(283, 15);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(71, 23);
		this.button4.TabIndex = 8;
		this.button4.Text = "OK";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(140, 19);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(137, 13);
		this.label3.TabIndex = 7;
		this.label3.Text = "il programma selezionato -->";
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "REC", "SHOW" });
		this.comboBox1.Location = new System.Drawing.Point(63, 16);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(70, 21);
		this.comboBox1.TabIndex = 6;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(13, 19);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(44, 13);
		this.label2.TabIndex = 5;
		this.label2.Text = "Metti in ";
		this.button3.Location = new System.Drawing.Point(403, 44);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(216, 23);
		this.button3.TabIndex = 4;
		this.button3.Text = "Tutti questi Eventi Non avvisare più";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(745, 396);
		base.Controls.Add(this.splitContainer1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "RICORDA";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "RICORDA";
		base.Load += new System.EventHandler(this.RICORDA_Load);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		this.splitContainer2.Panel1.ResumeLayout(false);
		this.splitContainer2.Panel1.PerformLayout();
		this.splitContainer2.Panel2.ResumeLayout(false);
		this.splitContainer2.ResumeLayout(false);
		this.splitContainer3.Panel1.ResumeLayout(false);
		this.splitContainer3.Panel1.PerformLayout();
		this.splitContainer3.Panel2.ResumeLayout(false);
		this.splitContainer3.Panel2.PerformLayout();
		this.splitContainer3.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	public RICORDA()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			DateTime now = DateTime.Now;
			try
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\avvisioggi", append: true);
				streamWriter.WriteLine(now.Day + "//" + now.Month + "//" + now.Year + " " + text);
				streamWriter.Close();
				listBox1.Items.Remove(listBox1.SelectedItem);
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void leggimionvc()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\nuovicanali.txt");
			string text = "";
			while ((text = streamReader.ReadLine()) != null)
			{
				listalettac.Add(text);
				text = streamReader.ReadLine();
				listalettac.Add(text);
			}
			streamReader.Close();
		}
		catch
		{
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		try
		{
			foreach (string item in listBox1.Items)
			{
				string text2 = item;
				DateTime now = DateTime.Now;
				try
				{
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\avvisioggi", append: true);
					streamWriter.WriteLine(now.Day + "//" + now.Month + "//" + now.Year + " " + text2);
					streamWriter.Close();
				}
				catch
				{
				}
			}
			Close();
		}
		catch
		{
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			if (text.IndexOf("   ") >= 0)
			{
				text = text.Substring(0, text.IndexOf("   "));
			}
			if (text.IndexOf(")") >= 0)
			{
				text = text.Substring(0, text.IndexOf(")"));
			}
			foreach (string item in listatotalecanali)
			{
				if (item.IndexOf(text) >= 0)
				{
					string text2 = item;
					mio.label1.Text = text2.Substring(0, text2.IndexOf(" "));
					mio.aspettasionoperpartirefilm = true;
					mio.partiriccan();
				}
			}
		}
		catch
		{
		}
	}

	private void leggimioc()
	{
		try
		{
			listatotalecanali.Clear();
		}
		catch
		{
		}
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\propriotel.txt");
			string text = "";
			while ((text = streamReader.ReadLine()) != null)
			{
				listatotalecanali.Add(text);
			}
			streamReader.Close();
		}
		catch
		{
		}
	}

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + mio.linguaprogramma + "RIC.txt");
			string text = streamReader.ReadToEnd();
			string text2 = text;
			streamReader.Close();
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
			if (text2.IndexOf("label2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label2.Text = text3;
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
			if (text2.IndexOf("button4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button4.Text = text3;
			}
			if (text2.IndexOf("button3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button3.Text = text3;
			}
			if (text2.IndexOf("checkBox1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox1.Text = text3;
			}
		}
		catch
		{
		}
	}

	private void RICORDA_Load(object sender, EventArgs e)
	{
		cambialing();
		leggimioc();
		leggimionvc();
		comboBox1.SelectedIndex = 0;
	}

	private void button4_Click(object sender, EventArgs e)
	{
		bool flag = true;
		int num = 0;
		while (flag)
		{
			try
			{
				flag = false;
				string text = listBox1.SelectedItem.ToString();
				if (text.IndexOf("   ") > 0)
				{
					text = text.Substring(0, text.IndexOf("   "));
				}
				string text2 = listBox1.SelectedItem.ToString();
				if (text.IndexOf(")") > 0)
				{
					text = text.Substring(0, text.IndexOf(")"));
				}
				if (text2.IndexOf(")") > 0)
				{
					text2 = text2.Substring(text2.IndexOf(")") + 1);
				}
				if (text2.IndexOf("   ") > 0)
				{
					text2 = text2.Substring(text2.IndexOf("   ") + 3);
				}
				if (text2.IndexOf("-->") >= 0)
				{
					text2 = text2.Substring(text2.IndexOf("-->") + 3);
				}
				string text3 = text2.Substring(text2.IndexOf("-") + 2);
				string text4 = text3.Substring(text3.LastIndexOf(":") + 1);
				text2 = text2.Substring(0, text2.IndexOf("-"));
				text2 = text2.Replace(" ", "");
				text3 = text3.Trim();
				text3 = text3.Substring(0, text3.IndexOf(" "));
				string text5 = text;
				text2 = text2.Replace(".", ":");
				text3 = text3.Replace(".", ":");
				string text6 = text2;
				string text7 = text3;
				while (text4.IndexOf(" ") == 0)
				{
					text4 = text4.Substring(1);
				}
				string text8 = text4;
				int num2 = int.Parse(text6.Substring(0, text6.IndexOf(":")));
				num2 = int.Parse(text6.Substring(text6.IndexOf(":") + 1));
				num2 = int.Parse(text7.Substring(0, text7.IndexOf(":")));
				num2 = int.Parse(text7.Substring(text7.IndexOf(":") + 1));
				DateTime dateTime = DateTime.Now;
				bool flag2 = false;
				try
				{
					flag2 = true;
				}
				catch
				{
				}
				if (int.Parse(text6.Substring(0, text6.IndexOf(":"))) < 5 && flag2)
				{
					dateTime = dateTime.AddDays(1.0);
					MessageBox.Show("Registrazione aggiunta al giorno successivo(trattandosi di 1 programma di domani)");
				}
				if (string.IsNullOrEmpty(text8))
				{
					continue;
				}
				string text9 = dateTime.Day + "_" + dateTime.Month + "_" + dateTime.Year;
				if (!Directory.Exists(Program.pr + "\\" + text9))
				{
					Directory.CreateDirectory(Program.pr + "\\" + text9);
				}
				try
				{
					int num3 = 0;
					num3 = text switch
					{
						"Rai 1" => 1, 
						"Rai 2" => 2, 
						"Rai 3" => 3, 
						"Rete 4" => 4, 
						"Canale 5" => 5, 
						"Italia 1" => 6, 
						_ => 10, 
					};
					if (num3 > 7)
					{
						StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text9 + "\\canaliagg.txt", append: true);
						streamWriter.WriteLine(text6 + " " + text8 + "    |||" + text7);
						int num4 = 0;
						foreach (string item in listalettac)
						{
							if (item.IndexOf(text) >= 0)
							{
								text = item;
								break;
							}
							num4++;
						}
						num4++;
						if (comboBox1.SelectedIndex == 0)
						{
							streamWriter.WriteLine("REC |||" + text + "!$!" + listalettac[num4]);
						}
						else
						{
							streamWriter.WriteLine("SHOW |||" + text + "!$!" + listalettac[num4]);
						}
						streamWriter.Close();
					}
					else
					{
						string text10 = "";
						switch (num3)
						{
						case 1:
							text10 = "\\rai1.txt";
							break;
						case 2:
							text10 = "\\rai2.txt";
							break;
						case 3:
							text10 = "\\rai3.txt";
							break;
						case 4:
							text10 = "\\quattro.txt";
							break;
						case 5:
							text10 = "\\cinque.txt";
							break;
						case 6:
							text10 = "\\italia.txt";
							break;
						}
						StreamWriter streamWriter = new StreamWriter(Program.pr + "\\" + text9 + text10, append: true);
						streamWriter.WriteLine(text6 + " " + text8 + "    |||" + text7);
						int num4 = 0;
						num4++;
						if (comboBox1.SelectedIndex == 0)
						{
							streamWriter.WriteLine("REC ");
						}
						else
						{
							streamWriter.WriteLine("SHOW ");
						}
						streamWriter.Close();
					}
					MessageBox.Show("Registrazione Aggiunta");
				}
				catch
				{
					if (num < 100)
					{
						flag = true;
					}
					num++;
				}
			}
			catch
			{
				MessageBox.Show("Errore,Controllare di aver settato tutto correttamente");
			}
		}
	}
}
