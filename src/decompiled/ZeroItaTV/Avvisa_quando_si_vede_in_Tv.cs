// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZeroItaTV;

public class Avvisa_quando_si_vede_in_Tv : Form
{
	private IContainer components = null;

	private GroupBox groupBox1;

	private Label label2;

	private TextBox textBox1;

	private Button button1;

	private Label label1;

	private GroupBox groupBox2;

	private ListBox listBox1;

	private Button button2;

	private Button button3;

	private GroupBox groupBox3;

	private Button button4;

	private Button button5;

	private ListBox listBox2;

	private Button button6;

	private Form1 mio;

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Avvisa_quando_si_vede_in_Tv));
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.button6 = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.button3 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.button4 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.listBox2 = new System.Windows.Forms.ListBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox3.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.button6);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.Location = new System.Drawing.Point(8, 73);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(784, 71);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Opzioni inserimento parole da ricercare ";
		this.button6.Location = new System.Drawing.Point(630, 41);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(148, 23);
		this.button6.TabIndex = 3;
		this.button6.Text = "Aggiungi in Registrare";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(this.button6_Click);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 16);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(173, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "Parola / Parole / Nome Programma";
		this.textBox1.Location = new System.Drawing.Point(6, 32);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(539, 20);
		this.textBox1.TabIndex = 1;
		this.button1.Location = new System.Drawing.Point(630, 16);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(148, 23);
		this.button1.TabIndex = 0;
		this.button1.Text = "Aggiungi in Segnalare";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.label1.Location = new System.Drawing.Point(5, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(787, 61);
		this.label1.TabIndex = 1;
		this.label1.Text = resources.GetString("label1.Text");
		this.groupBox2.Controls.Add(this.button3);
		this.groupBox2.Controls.Add(this.button2);
		this.groupBox2.Controls.Add(this.listBox1);
		this.groupBox2.Location = new System.Drawing.Point(7, 150);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(389, 205);
		this.groupBox2.TabIndex = 2;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Parole da Segnalare";
		this.button3.Location = new System.Drawing.Point(308, 113);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(75, 79);
		this.button3.TabIndex = 4;
		this.button3.Text = "Sposta Parola in\r\nRegistra \r\n-->";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.button2.Location = new System.Drawing.Point(308, 19);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(75, 79);
		this.button2.TabIndex = 3;
		this.button2.Text = "Elimina Parola Selezionata";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Location = new System.Drawing.Point(6, 19);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(296, 173);
		this.listBox1.TabIndex = 0;
		this.groupBox3.Controls.Add(this.button4);
		this.groupBox3.Controls.Add(this.button5);
		this.groupBox3.Controls.Add(this.listBox2);
		this.groupBox3.Location = new System.Drawing.Point(402, 150);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(390, 205);
		this.groupBox3.TabIndex = 5;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Parole da Registrare";
		this.button4.Location = new System.Drawing.Point(6, 113);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(75, 79);
		this.button4.TabIndex = 4;
		this.button4.Text = "Sposta Parola in\r\nSegnalare\r\n<--";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.button5.Location = new System.Drawing.Point(6, 19);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(75, 79);
		this.button5.TabIndex = 3;
		this.button5.Text = "Elimina Parola Selezionata";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.listBox2.FormattingEnabled = true;
		this.listBox2.Location = new System.Drawing.Point(87, 19);
		this.listBox2.Name = "listBox2";
		this.listBox2.Size = new System.Drawing.Size(296, 173);
		this.listBox2.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(803, 363);
		base.Controls.Add(this.groupBox3);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.groupBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Avvisa_quando_si_vede_in_Tv";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Avvisa quando si vede in Tv";
		base.Load += new System.EventHandler(this.Avvisa_quando_si_vede_in_Tv_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	public Avvisa_quando_si_vede_in_Tv(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	private void leggispecial()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\extraspecialtv");
			string text = "";
			while ((text = streamReader.ReadLine()) != null)
			{
				listBox1.Items.Add(text);
			}
			streamReader.Close();
		}
		catch
		{
		}
	}

	private void leggispecial2()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\extraspecialtvreg");
			string text = "";
			while ((text = streamReader.ReadLine()) != null)
			{
				listBox2.Items.Add(text);
			}
			streamReader.Close();
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\extraspecialtv", append: true);
				streamWriter.WriteLine(textBox1.Text);
				streamWriter.Close();
				listBox1.Items.Add(textBox1.Text);
				textBox1.Text = "";
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + mio.linguaprogramma + "AVV.txt");
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
			if (text2.IndexOf("button6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button6.Text = text3;
			}
			if (text2.IndexOf("button1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button1.Text = text3;
			}
			if (text2.IndexOf("button3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button3.Text = text3;
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
			if (text2.IndexOf("button5") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button5"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button5.Text = text3;
			}
		}
		catch
		{
		}
	}

	private void Avvisa_quando_si_vede_in_Tv_Load(object sender, EventArgs e)
	{
		cambialing();
		leggispecial();
		leggispecial2();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			listBox1.Items.Remove(listBox1.SelectedItem);
			try
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\extraspecialtv");
				foreach (object item in listBox1.Items)
				{
					streamWriter.WriteLine(item.ToString());
				}
				streamWriter.Close();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button6_Click(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(textBox1.Text))
			{
				try
				{
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\extraspecialtvreg", append: true);
					streamWriter.WriteLine(textBox1.Text);
					streamWriter.Close();
					listBox2.Items.Add(textBox1.Text);
					textBox1.Text = "";
					return;
				}
				catch
				{
					return;
				}
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
			listBox2.Items.Remove(listBox2.SelectedItem);
			try
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\extraspecialtvreg");
				foreach (object item in listBox2.Items)
				{
					streamWriter.WriteLine(item.ToString());
				}
				streamWriter.Close();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			listBox1.Items.Remove(listBox1.SelectedItem);
			try
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\extraspecialtv");
				foreach (object item in listBox1.Items)
				{
					streamWriter.WriteLine(item.ToString());
				}
				streamWriter.Close();
				try
				{
					streamWriter = new StreamWriter(Program.pr + "\\extraspecialtvreg", append: true);
					streamWriter.WriteLine(text);
					streamWriter.Close();
					listBox2.Items.Add(text);
				}
				catch
				{
				}
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox2.SelectedItem.ToString();
			listBox2.Items.Remove(listBox2.SelectedItem);
			try
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\extraspecialtvreg");
				foreach (object item in listBox2.Items)
				{
					streamWriter.WriteLine(item.ToString());
				}
				streamWriter.Close();
				try
				{
					streamWriter = new StreamWriter(Program.pr + "\\extraspecialtv", append: true);
					streamWriter.WriteLine(text);
					streamWriter.Close();
					listBox1.Items.Add(text);
				}
				catch
				{
				}
			}
			catch
			{
			}
		}
		catch
		{
		}
	}
}
