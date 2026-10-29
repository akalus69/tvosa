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
using ZeroItaTV.Properties;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class PannelloRicercaTubo : UserControl
{
	private IContainer components = null;

	private Button button1;

	private Button button2;

	private Button button3;

	public Label label1;

	public ListBox listBox1;

	public TextBox textBox1;

	public PictureBox pictureBox1;

	public PictureBox pictureBox2;

	public PictureBox pictureBox3;

	public PictureBox pictureBox4;

	public PictureBox pictureBox5;

	public PictureBox pictureBox6;

	public PictureBox pictureBox7;

	public PictureBox pictureBox8;

	public PictureBox pictureBox9;

	public PictureBox pictureBox10;

	public PictureBox pictureBox11;

	public PictureBox pictureBox12;

	public PictureBox pictureBox13;

	public PictureBox pictureBox14;

	public PictureBox pictureBox15;

	public PictureBox pictureBox16;

	public PictureBox pictureBox17;

	public PictureBox pictureBox18;

	public PictureBox pictureBox19;

	public PictureBox pictureBox20;

	private bool listafocus = false;

	private bool sopralista = false;

	private Thread TTXMUSIC;

	public ManageCanali mio;

	public List<Size> listasiz = new List<Size>();

	public List<Point> listapoint = new List<Point>();

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
		this.button1 = new System.Windows.Forms.Button();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.pictureBox12 = new System.Windows.Forms.PictureBox();
		this.pictureBox13 = new System.Windows.Forms.PictureBox();
		this.pictureBox14 = new System.Windows.Forms.PictureBox();
		this.pictureBox15 = new System.Windows.Forms.PictureBox();
		this.pictureBox16 = new System.Windows.Forms.PictureBox();
		this.pictureBox17 = new System.Windows.Forms.PictureBox();
		this.pictureBox18 = new System.Windows.Forms.PictureBox();
		this.pictureBox19 = new System.Windows.Forms.PictureBox();
		this.pictureBox20 = new System.Windows.Forms.PictureBox();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).BeginInit();
		base.SuspendLayout();
		this.button1.BackColor = System.Drawing.Color.Black;
		this.button1.BackgroundImage = ZeroItaTV.Properties.Resources.button_cancel;
		this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.Location = new System.Drawing.Point(759, 4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(15, 15);
		this.button1.TabIndex = 0;
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.pictureBox1.Image = ZeroItaTV.Properties.Resources._200019_920;
		this.pictureBox1.Location = new System.Drawing.Point(22, 5);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(76, 63);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 1;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
		this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
		this.pictureBox2.Image = ZeroItaTV.Properties.Resources._4x4;
		this.pictureBox2.Location = new System.Drawing.Point(125, 5);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(76, 63);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox2.TabIndex = 2;
		this.pictureBox2.TabStop = false;
		this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
		this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
		this.pictureBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
		this.pictureBox3.Location = new System.Drawing.Point(239, 5);
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.Size = new System.Drawing.Size(76, 63);
		this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox3.TabIndex = 3;
		this.pictureBox3.TabStop = false;
		this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
		this.pictureBox3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox3.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
		this.pictureBox4.Location = new System.Drawing.Point(352, 5);
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.Size = new System.Drawing.Size(76, 63);
		this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox4.TabIndex = 4;
		this.pictureBox4.TabStop = false;
		this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
		this.pictureBox4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox4.MouseHover += new System.EventHandler(this.pictureBox4_MouseHover);
		this.pictureBox5.Location = new System.Drawing.Point(473, 5);
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.Size = new System.Drawing.Size(76, 63);
		this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox5.TabIndex = 5;
		this.pictureBox5.TabStop = false;
		this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
		this.pictureBox5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox5.MouseHover += new System.EventHandler(this.pictureBox5_MouseHover);
		this.pictureBox6.Location = new System.Drawing.Point(473, 85);
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.Size = new System.Drawing.Size(76, 63);
		this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox6.TabIndex = 10;
		this.pictureBox6.TabStop = false;
		this.pictureBox6.MouseLeave += new System.EventHandler(this.pictureBox6_MouseLeave);
		this.pictureBox6.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox6.MouseHover += new System.EventHandler(this.pictureBox6_MouseHover);
		this.pictureBox7.Location = new System.Drawing.Point(352, 85);
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.Size = new System.Drawing.Size(76, 63);
		this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox7.TabIndex = 9;
		this.pictureBox7.TabStop = false;
		this.pictureBox7.MouseLeave += new System.EventHandler(this.pictureBox7_MouseLeave);
		this.pictureBox7.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox7.MouseHover += new System.EventHandler(this.pictureBox7_MouseHover);
		this.pictureBox8.Location = new System.Drawing.Point(239, 85);
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.Size = new System.Drawing.Size(76, 63);
		this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox8.TabIndex = 8;
		this.pictureBox8.TabStop = false;
		this.pictureBox8.MouseLeave += new System.EventHandler(this.pictureBox8_MouseLeave);
		this.pictureBox8.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox8.MouseHover += new System.EventHandler(this.pictureBox8_MouseHover);
		this.pictureBox9.Location = new System.Drawing.Point(125, 85);
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.Size = new System.Drawing.Size(76, 63);
		this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox9.TabIndex = 7;
		this.pictureBox9.TabStop = false;
		this.pictureBox9.MouseLeave += new System.EventHandler(this.pictureBox9_MouseLeave);
		this.pictureBox9.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox9.MouseHover += new System.EventHandler(this.pictureBox9_MouseHover);
		this.pictureBox10.Location = new System.Drawing.Point(22, 85);
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.Size = new System.Drawing.Size(76, 63);
		this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox10.TabIndex = 6;
		this.pictureBox10.TabStop = false;
		this.pictureBox10.MouseLeave += new System.EventHandler(this.pictureBox10_MouseLeave);
		this.pictureBox10.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox10.MouseHover += new System.EventHandler(this.pictureBox10_MouseHover);
		this.pictureBox11.Location = new System.Drawing.Point(473, 166);
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.Size = new System.Drawing.Size(76, 63);
		this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox11.TabIndex = 15;
		this.pictureBox11.TabStop = false;
		this.pictureBox11.MouseLeave += new System.EventHandler(this.pictureBox11_MouseLeave);
		this.pictureBox11.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox11.MouseHover += new System.EventHandler(this.pictureBox11_MouseHover);
		this.pictureBox12.Location = new System.Drawing.Point(352, 166);
		this.pictureBox12.Name = "pictureBox12";
		this.pictureBox12.Size = new System.Drawing.Size(76, 63);
		this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox12.TabIndex = 14;
		this.pictureBox12.TabStop = false;
		this.pictureBox12.MouseLeave += new System.EventHandler(this.pictureBox12_MouseLeave);
		this.pictureBox12.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox12.MouseHover += new System.EventHandler(this.pictureBox12_MouseHover);
		this.pictureBox13.Location = new System.Drawing.Point(239, 166);
		this.pictureBox13.Name = "pictureBox13";
		this.pictureBox13.Size = new System.Drawing.Size(76, 63);
		this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox13.TabIndex = 13;
		this.pictureBox13.TabStop = false;
		this.pictureBox13.MouseLeave += new System.EventHandler(this.pictureBox13_MouseLeave);
		this.pictureBox13.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox13.MouseHover += new System.EventHandler(this.pictureBox13_MouseHover);
		this.pictureBox14.Location = new System.Drawing.Point(125, 166);
		this.pictureBox14.Name = "pictureBox14";
		this.pictureBox14.Size = new System.Drawing.Size(76, 63);
		this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox14.TabIndex = 12;
		this.pictureBox14.TabStop = false;
		this.pictureBox14.MouseLeave += new System.EventHandler(this.pictureBox14_MouseLeave);
		this.pictureBox14.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox14.MouseHover += new System.EventHandler(this.pictureBox14_MouseHover);
		this.pictureBox15.Location = new System.Drawing.Point(22, 166);
		this.pictureBox15.Name = "pictureBox15";
		this.pictureBox15.Size = new System.Drawing.Size(76, 63);
		this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox15.TabIndex = 11;
		this.pictureBox15.TabStop = false;
		this.pictureBox15.MouseLeave += new System.EventHandler(this.pictureBox15_MouseLeave);
		this.pictureBox15.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox15.MouseHover += new System.EventHandler(this.pictureBox15_MouseHover);
		this.pictureBox16.Location = new System.Drawing.Point(473, 250);
		this.pictureBox16.Name = "pictureBox16";
		this.pictureBox16.Size = new System.Drawing.Size(76, 63);
		this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox16.TabIndex = 20;
		this.pictureBox16.TabStop = false;
		this.pictureBox16.MouseLeave += new System.EventHandler(this.pictureBox16_MouseLeave);
		this.pictureBox16.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox16.MouseHover += new System.EventHandler(this.pictureBox16_MouseHover);
		this.pictureBox17.Location = new System.Drawing.Point(352, 250);
		this.pictureBox17.Name = "pictureBox17";
		this.pictureBox17.Size = new System.Drawing.Size(76, 63);
		this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox17.TabIndex = 19;
		this.pictureBox17.TabStop = false;
		this.pictureBox17.MouseLeave += new System.EventHandler(this.pictureBox17_MouseLeave);
		this.pictureBox17.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox17.MouseHover += new System.EventHandler(this.pictureBox17_MouseHover);
		this.pictureBox18.Location = new System.Drawing.Point(239, 250);
		this.pictureBox18.Name = "pictureBox18";
		this.pictureBox18.Size = new System.Drawing.Size(76, 63);
		this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox18.TabIndex = 18;
		this.pictureBox18.TabStop = false;
		this.pictureBox18.MouseLeave += new System.EventHandler(this.pictureBox18_MouseLeave);
		this.pictureBox18.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox18.MouseHover += new System.EventHandler(this.pictureBox18_MouseHover);
		this.pictureBox19.Location = new System.Drawing.Point(125, 250);
		this.pictureBox19.Name = "pictureBox19";
		this.pictureBox19.Size = new System.Drawing.Size(76, 63);
		this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox19.TabIndex = 17;
		this.pictureBox19.TabStop = false;
		this.pictureBox19.MouseLeave += new System.EventHandler(this.pictureBox19_MouseLeave);
		this.pictureBox19.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox19.MouseHover += new System.EventHandler(this.pictureBox19_MouseHover);
		this.pictureBox20.Image = ZeroItaTV.Properties.Resources.bianconiglio;
		this.pictureBox20.Location = new System.Drawing.Point(22, 250);
		this.pictureBox20.Name = "pictureBox20";
		this.pictureBox20.Size = new System.Drawing.Size(76, 63);
		this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox20.TabIndex = 16;
		this.pictureBox20.TabStop = false;
		this.pictureBox20.MouseLeave += new System.EventHandler(this.pictureBox20_MouseLeave);
		this.pictureBox20.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.pictureBox20.MouseHover += new System.EventHandler(this.pictureBox20_MouseHover);
		this.listBox1.BackColor = System.Drawing.Color.Black;
		this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listBox1.ForeColor = System.Drawing.Color.White;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.HorizontalScrollbar = true;
		this.listBox1.Location = new System.Drawing.Point(571, 42);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(194, 264);
		this.listBox1.TabIndex = 21;
		this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
		this.listBox1.MouseHover += new System.EventHandler(this.listBox1_MouseHover);
		this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
		this.listBox1.Enter += new System.EventHandler(this.listBox1_Enter);
		this.listBox1.MouseLeave += new System.EventHandler(this.listBox1_MouseLeave);
		this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
		this.button2.Location = new System.Drawing.Point(571, 13);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(41, 23);
		this.button2.TabIndex = 22;
		this.button2.Text = "<--";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.button3.Location = new System.Drawing.Point(674, 13);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(41, 23);
		this.button3.TabIndex = 23;
		this.button3.Text = "-->";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(618, 19);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(50, 10);
		this.label1.TabIndex = 24;
		this.label1.Text = "1";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox1.Location = new System.Drawing.Point(571, 317);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(100, 20);
		this.textBox1.TabIndex = 25;
		this.textBox1.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Black;
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.listBox1);
		base.Controls.Add(this.pictureBox16);
		base.Controls.Add(this.pictureBox17);
		base.Controls.Add(this.pictureBox18);
		base.Controls.Add(this.pictureBox19);
		base.Controls.Add(this.pictureBox20);
		base.Controls.Add(this.pictureBox11);
		base.Controls.Add(this.pictureBox12);
		base.Controls.Add(this.pictureBox13);
		base.Controls.Add(this.pictureBox14);
		base.Controls.Add(this.pictureBox15);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.pictureBox8);
		base.Controls.Add(this.pictureBox9);
		base.Controls.Add(this.pictureBox10);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.button1);
		base.Name = "PannelloRicercaTubo";
		base.Size = new System.Drawing.Size(780, 351);
		base.Load += new System.EventHandler(this.PannelloRicercaTubo_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public PannelloRicercaTubo(ManageCanali m)
	{
		mio = m;
		InitializeComponent();
	}

	public void setta()
	{
		try
		{
			foreach (object control in Controls)
			{
				try
				{
					PictureBox pictureBox = (PictureBox)control;
					pictureBox.Image = null;
					listapoint.Add(pictureBox.Location);
					listasiz.Add(pictureBox.Size);
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

	private void PannelloRicercaTubo_Load(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		mio.panel1.Visible = false;
		if (!Directory.Exists(Program.pr + "\\Prev"))
		{
			Directory.CreateDirectory(Program.pr + "\\Prev");
			return;
		}
		try
		{
			foreach (object control in Controls)
			{
				try
				{
					PictureBox pictureBox = (PictureBox)control;
					pictureBox.Image = null;
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		string[] files = Directory.GetFiles(Program.pr + "\\Prev");
		foreach (string path in files)
		{
			try
			{
				File.Delete(path);
			}
			catch
			{
			}
		}
	}

	public void leggilplaylistetrasforma2()
	{
		listBox1.Items.Clear();
		string text = "";
		string[] lines = textBox1.Lines;
		foreach (string text2 in lines)
		{
			text = text2.Replace("!$!", "");
			text = text.Replace("&quot", "");
			text = text.Replace("<", "");
			text = text.Replace(">", "");
			if (text.IndexOf("?!?") >= 0)
			{
				text = text.Substring(0, text.IndexOf("?!?"));
			}
			if (text.IndexOf("|||") >= 0)
			{
				text = text.Substring(0, text.IndexOf("|||"));
			}
			if (text.IndexOf("(1)") < 0 && text.IndexOf("(2)") < 0 && text.IndexOf("(3)") < 0 && text.IndexOf("(4)") < 0 && text.IndexOf("(5)") < 0 && text.IndexOf("(6)") < 0)
			{
				listBox1.Items.Add(text);
			}
		}
	}

	private void giga(PictureBox px)
	{
		try
		{
			int num = 14;
			px.Location = new Point(px.Location.X - num / 2, px.Location.Y - num / 2);
			px.Size = new Size(px.Size.Width + num, px.Size.Height + num);
		}
		catch (Exception)
		{
		}
	}

	private void rimpiccio(PictureBox px, int pt)
	{
		try
		{
			px.Location = new Point(listapoint[pt].X, listapoint[pt].Y);
			px.Size = new Size(listasiz[pt].Width, listasiz[pt].Height);
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox1_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox1);
		try
		{
			listBox1.SelectedIndex = 0;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox1_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox1, 19);
	}

	private void pictureBox2_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox2, 18);
	}

	private void pictureBox3_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox3, 17);
	}

	private void pictureBox4_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox4, 16);
	}

	private void pictureBox5_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox5, 15);
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
	}

	private void pictureBox2_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox2);
		try
		{
			listBox1.SelectedIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox3_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox3);
		try
		{
			listBox1.SelectedIndex = 2;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox4_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox4);
		try
		{
			listBox1.SelectedIndex = 3;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox5_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox5);
		try
		{
			listBox1.SelectedIndex = 4;
		}
		catch (Exception)
		{
		}
	}

	private void suonacanzone()
	{
		mio.tubnormale = false;
		try
		{
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(mio);
			Thread thread = new Thread(threadAltriCanali.cercamusica);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
	}

	private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		suonacanzone();
	}

	private void pictureBox10_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox10);
		try
		{
			listBox1.SelectedIndex = 9;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox6_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox6);
		try
		{
			listBox1.SelectedIndex = 5;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox6_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox6, 10);
	}

	private void pictureBox7_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox7);
		try
		{
			listBox1.SelectedIndex = 6;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox7_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox7, 11);
	}

	private void pictureBox8_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox8);
		try
		{
			listBox1.SelectedIndex = 7;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox9_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox9);
		try
		{
			listBox1.SelectedIndex = 8;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox11_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox11);
		try
		{
			listBox1.SelectedIndex = 10;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox12_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox12);
		try
		{
			listBox1.SelectedIndex = 11;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox13_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox13);
		try
		{
			listBox1.SelectedIndex = 12;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox14_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox14);
		try
		{
			listBox1.SelectedIndex = 12;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox15_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox15);
		try
		{
			listBox1.SelectedIndex = 14;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox16_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox16);
		try
		{
			listBox1.SelectedIndex = 15;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox17_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox17);
		try
		{
			listBox1.SelectedIndex = 16;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox18_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox18);
		try
		{
			listBox1.SelectedIndex = 17;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox19_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox19);
		try
		{
			listBox1.SelectedIndex = 18;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox20_MouseHover(object sender, EventArgs e)
	{
		listafocus = false;
		giga(pictureBox20);
		try
		{
			listBox1.SelectedIndex = 19;
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox8_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox8, 12);
	}

	private void pictureBox9_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox9, 13);
	}

	private void pictureBox10_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox10, 14);
	}

	private void pictureBox11_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox11, 5);
	}

	private void pictureBox12_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox12, 6);
	}

	private void pictureBox13_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox13, 7);
	}

	private void pictureBox14_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox14, 8);
	}

	private void pictureBox15_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox15, 9);
	}

	private void pictureBox16_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox16, 0);
	}

	private void pictureBox17_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox17, 1);
	}

	private void pictureBox18_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox18, 2);
	}

	private void pictureBox19_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox19, 3);
	}

	private void pictureBox20_MouseLeave(object sender, EventArgs e)
	{
		rimpiccio(pictureBox20, 4);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(mio.textBox4.Text) || mio.opzrice != 0)
			{
				try
				{
					TTXMUSIC.Abort();
				}
				catch (Exception)
				{
				}
				mio.tubnormale = false;
				ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(mio);
				mio.pg++;
				label1.Text = mio.pg.ToString();
				TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
				TTXMUSIC.IsBackground = true;
				TTXMUSIC.Priority = ThreadPriority.BelowNormal;
				TTXMUSIC.Start();
			}
		}
		catch
		{
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			if ((!string.IsNullOrEmpty(mio.textBox4.Text) || mio.opzrice != 0) && mio.pg > 1)
			{
				try
				{
					TTXMUSIC.Abort();
				}
				catch (Exception)
				{
				}
				mio.tubnormale = false;
				ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(mio);
				mio.pg--;
				label1.Text = mio.pg.ToString();
				TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
				TTXMUSIC.IsBackground = true;
				TTXMUSIC.Priority = ThreadPriority.BelowNormal;
				TTXMUSIC.Start();
			}
		}
		catch
		{
		}
	}

	private void ridimensionatutto()
	{
		try
		{
			rimpiccio(pictureBox1, 19);
			rimpiccio(pictureBox2, 18);
			rimpiccio(pictureBox3, 17);
			rimpiccio(pictureBox4, 16);
			rimpiccio(pictureBox5, 15);
			rimpiccio(pictureBox6, 10);
			rimpiccio(pictureBox7, 11);
			rimpiccio(pictureBox8, 12);
			rimpiccio(pictureBox9, 13);
			rimpiccio(pictureBox10, 14);
			rimpiccio(pictureBox11, 5);
			rimpiccio(pictureBox12, 6);
			rimpiccio(pictureBox13, 7);
			rimpiccio(pictureBox14, 8);
			rimpiccio(pictureBox15, 9);
			rimpiccio(pictureBox16, 0);
			rimpiccio(pictureBox17, 1);
			rimpiccio(pictureBox18, 2);
			rimpiccio(pictureBox19, 3);
			rimpiccio(pictureBox20, 4);
		}
		catch (Exception)
		{
		}
	}

	private void listBox1_MouseHover(object sender, EventArgs e)
	{
		try
		{
			sopralista = true;
		}
		catch (Exception)
		{
		}
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (!listafocus)
			{
				return;
			}
			ridimensionatutto();
			if (sopralista)
			{
				int selectedIndex = listBox1.SelectedIndex;
				if (selectedIndex == 0)
				{
					giga(pictureBox1);
				}
				if (selectedIndex == 1)
				{
					giga(pictureBox2);
				}
				if (selectedIndex == 2)
				{
					giga(pictureBox3);
				}
				if (selectedIndex == 3)
				{
					giga(pictureBox4);
				}
				if (selectedIndex == 4)
				{
					giga(pictureBox5);
				}
				if (selectedIndex == 5)
				{
					giga(pictureBox6);
				}
				if (selectedIndex == 6)
				{
					giga(pictureBox7);
				}
				if (selectedIndex == 7)
				{
					giga(pictureBox8);
				}
				if (selectedIndex == 8)
				{
					giga(pictureBox9);
				}
				if (selectedIndex == 9)
				{
					giga(pictureBox10);
				}
				if (selectedIndex == 10)
				{
					giga(pictureBox11);
				}
				if (selectedIndex == 11)
				{
					giga(pictureBox12);
				}
				if (selectedIndex == 12)
				{
					giga(pictureBox13);
				}
				if (selectedIndex == 13)
				{
					giga(pictureBox14);
				}
				if (selectedIndex == 14)
				{
					giga(pictureBox15);
				}
				if (selectedIndex == 15)
				{
					giga(pictureBox16);
				}
				if (selectedIndex == 16)
				{
					giga(pictureBox17);
				}
				if (selectedIndex == 17)
				{
					giga(pictureBox18);
				}
				if (selectedIndex == 18)
				{
					giga(pictureBox19);
				}
				if (selectedIndex == 19)
				{
					giga(pictureBox20);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void listBox1_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			sopralista = false;
			ridimensionatutto();
		}
		catch (Exception)
		{
		}
	}

	private void listBox1_Enter(object sender, EventArgs e)
	{
		listafocus = true;
	}

	private void listBox1_Click(object sender, EventArgs e)
	{
		listafocus = true;
	}

	private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		suonacanzone();
	}
}
