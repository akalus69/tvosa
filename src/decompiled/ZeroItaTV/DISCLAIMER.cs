// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZeroItaTV;

public class DISCLAIMER : Form
{
	private Form1 mio;

	private IContainer components = null;

	private Label label1;

	private Label label2;

	private RadioButton radioButton1;

	private RadioButton radioButton2;

	private GroupBox groupBox1;

	private CheckBox checkBox1;

	private Button button1;

	private GroupBox groupBox2;

	private ComboBox comboBox2;

	public DISCLAIMER(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + mio.linguaprogramma + "DISC.txt");
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
			text2 = text;
			if (text2.IndexOf("groupBox2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox2.Text = text3;
			}
			text2 = text;
			if (text2.IndexOf("label1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label1.Text = text3;
			}
			text2 = text;
			if (text2.IndexOf("label2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label2.Text = text3;
			}
			text2 = text;
			if (text2.IndexOf("radioButton1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton1.Text = text3;
			}
			text2 = text;
			if (text2.IndexOf("radioButton2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton2.Text = text3;
			}
			text2 = text;
			if (text2.IndexOf("button1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button1.Text = text3;
			}
			text2 = text;
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

	private void DISCLAIMER_Load(object sender, EventArgs e)
	{
		cambialing();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (radioButton2.Checked)
			{
				Close();
				return;
			}
			mio.disclaimersino = true;
			if (checkBox1.Checked)
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\disc.txt");
				streamWriter.Write("Accetto " + Environment.MachineName);
				streamWriter.Close();
			}
			Close();
		}
		catch
		{
		}
	}

	private void DISCLAIMER_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = comboBox2.SelectedIndex;
		mio.linguaprogramma = "\\" + comboBox2.SelectedItem.ToString() + "\\";
		StreamWriter streamWriter = new StreamWriter(Program.pr + "\\linguaggio");
		streamWriter.WriteLine(comboBox2.SelectedItem.ToString());
		streamWriter.Close();
		cambialing();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.DISCLAIMER));
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.button1 = new System.Windows.Forms.Button();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(18, 56);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(563, 107);
		this.label1.TabIndex = 0;
		this.label1.Text = "......";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(235, 23);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(132, 22);
		this.label2.TabIndex = 1;
		this.label2.Text = "ATTENZIONE";
		this.radioButton1.AutoSize = true;
		this.radioButton1.Location = new System.Drawing.Point(15, 29);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(34, 17);
		this.radioButton1.TabIndex = 2;
		this.radioButton1.Text = "Si";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.radioButton2.AutoSize = true;
		this.radioButton2.Checked = true;
		this.radioButton2.Location = new System.Drawing.Point(62, 29);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(39, 17);
		this.radioButton2.TabIndex = 3;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "No";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.groupBox1.Controls.Add(this.radioButton2);
		this.groupBox1.Controls.Add(this.radioButton1);
		this.groupBox1.Location = new System.Drawing.Point(21, 166);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(113, 66);
		this.groupBox1.TabIndex = 4;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Accetti ?";
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(21, 257);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(176, 17);
		this.checkBox1.TabIndex = 5;
		this.checkBox1.Text = "Non Mostrare più questo avviso";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.button1.Location = new System.Drawing.Point(506, 253);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 6;
		this.button1.Text = "Ok";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.groupBox2.Controls.Add(this.comboBox2);
		this.groupBox2.Location = new System.Drawing.Point(192, 166);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(175, 66);
		this.groupBox2.TabIndex = 5;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Linguaggio Programma";
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Items.AddRange(new object[2] { "ITA", "ENG" });
		this.comboBox2.Location = new System.Drawing.Point(18, 29);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(134, 21);
		this.comboBox2.TabIndex = 15;
		this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(617, 295);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "DISCLAIMER";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "DISCLAIMER";
		base.Load += new System.EventHandler(this.DISCLAIMER_Load);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DISCLAIMER_FormClosed);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
