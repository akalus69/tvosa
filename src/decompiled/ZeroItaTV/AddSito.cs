// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZeroItaTV;

public class AddSito : Form
{
	private IContainer components = null;

	private Button button1;

	private TextBox textBox1;

	private Label label1;

	public AddSito()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			string path = Program.pr + "\\nuovisiti";
			StreamWriter streamWriter = new StreamWriter(path);
			streamWriter.Write(textBox1.Text);
			streamWriter.Close();
			Close();
		}
		catch (Exception)
		{
		}
	}

	private void AddSito_Load(object sender, EventArgs e)
	{
		try
		{
			string path = Program.pr + "\\nuovisiti";
			StreamReader streamReader = new StreamReader(path);
			textBox1.Text = streamReader.ReadToEnd();
			streamReader.Close();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.AddSito));
		this.button1 = new System.Windows.Forms.Button();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.button1.Location = new System.Drawing.Point(197, 12);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 0;
		this.button1.Text = "Salva";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.textBox1.Location = new System.Drawing.Point(12, 82);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.textBox1.Size = new System.Drawing.Size(260, 156);
		this.textBox1.TabIndex = 1;
		this.textBox1.Text = resources.GetString("textBox1.Text");
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 50);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(218, 13);
		this.label1.TabIndex = 2;
		this.label1.Text = "Aggiungi i siti tra cui vuoi controllare qui sotto";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 262);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.button1);
		base.Name = "AddSito";
		this.Text = "AddSito";
		base.Load += new System.EventHandler(this.AddSito_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
