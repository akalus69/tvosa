// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Properties;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class Ringraziamenti : Form
{
	private IContainer components = null;

	private SplitContainer splitContainer1;

	private SplitContainer splitContainer2;

	private SplitContainer splitContainer3;

	private PictureBox pictureBox1;

	public Label label1;

	public LinkLabel linkLabel1;

	private TextBox textBox1;

	private PictureBox pictureBox2;

	public Label label2;

	public Label label3;

	private PictureBox pictureBox3;

	private Label label4;

	private Label label5;

	private PictureBox pictureBox4;

	public Ringraziamenti()
	{
		InitializeComponent();
	}

	private void Ringraziamenti_Load(object sender, EventArgs e)
	{
		Random random = new Random((int)DateTime.Now.Ticks);
		int num = random.Next(33);
		if (num == 0)
		{
			pictureBox1.Image = Resources._200019_920;
		}
		else if (num > 30)
		{
			pictureBox1.Image = Resources.bianconiglio;
		}
		linkLabel1.Visible = false;
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
		try
		{
			ThreadCapo threadCapo = new ThreadCapo(this, 2);
			Thread thread = new Thread(threadCapo.scrivi);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
		try
		{
			ThreadCapo threadCapo = new ThreadCapo(this, 2);
			Thread thread = new Thread(threadCapo.scrivi2);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
		try
		{
			ThreadCapo threadCapo = new ThreadCapo(this, 2);
			Thread thread = new Thread(threadCapo.scrivi3);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start(linkLabel1.Text);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Ringraziamenti));
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.splitContainer3 = new System.Windows.Forms.SplitContainer();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.label1 = new System.Windows.Forms.Label();
		this.splitContainer2 = new System.Windows.Forms.SplitContainer();
		this.label2 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.splitContainer3.Panel1.SuspendLayout();
		this.splitContainer3.Panel2.SuspendLayout();
		this.splitContainer3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.splitContainer2.Panel1.SuspendLayout();
		this.splitContainer2.Panel2.SuspendLayout();
		this.splitContainer2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		base.SuspendLayout();
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.IsSplitterFixed = true;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
		this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
		this.splitContainer1.Size = new System.Drawing.Size(794, 633);
		this.splitContainer1.SplitterDistance = 173;
		this.splitContainer1.TabIndex = 0;
		this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer3.IsSplitterFixed = true;
		this.splitContainer3.Location = new System.Drawing.Point(0, 0);
		this.splitContainer3.Name = "splitContainer3";
		this.splitContainer3.Panel1.Controls.Add(this.pictureBox1);
		this.splitContainer3.Panel2.Controls.Add(this.linkLabel1);
		this.splitContainer3.Panel2.Controls.Add(this.label1);
		this.splitContainer3.Size = new System.Drawing.Size(794, 173);
		this.splitContainer3.SplitterDistance = 205;
		this.splitContainer3.SplitterWidth = 1;
		this.splitContainer3.TabIndex = 1;
		this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureBox1.Image = ZeroItaTV.Properties.Resources._4x4;
		this.pictureBox1.Location = new System.Drawing.Point(0, 0);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(205, 173);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Location = new System.Drawing.Point(2, 157);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(177, 13);
		this.linkLabel1.TabIndex = 1;
		this.linkLabel1.TabStop = true;
		// BONIFICA 2026: rimosso il vecchio profilo SourceForge dell'autore 2011.
		this.linkLabel1.Text = "Il progetto originale (2011) continua nel repository 2026.";
		this.linkLabel1.Enabled = false;
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
		this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.label1.Font = new System.Drawing.Font("Segoe Script", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(0, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(588, 173);
		this.label1.TabIndex = 0;
		this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer2.IsSplitterFixed = true;
		this.splitContainer2.Location = new System.Drawing.Point(0, 0);
		this.splitContainer2.Name = "splitContainer2";
		this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer2.Panel1.Controls.Add(this.label2);
		this.splitContainer2.Panel1.Controls.Add(this.pictureBox2);
		this.splitContainer2.Panel2.Controls.Add(this.pictureBox4);
		this.splitContainer2.Panel2.Controls.Add(this.label5);
		this.splitContainer2.Panel2.Controls.Add(this.label4);
		this.splitContainer2.Panel2.Controls.Add(this.label3);
		this.splitContainer2.Panel2.Controls.Add(this.pictureBox3);
		this.splitContainer2.Panel2.Controls.Add(this.textBox1);
		this.splitContainer2.Size = new System.Drawing.Size(794, 456);
		this.splitContainer2.SplitterDistance = 174;
		this.splitContainer2.TabIndex = 0;
		this.label2.Font = new System.Drawing.Font("Segoe Script", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(12, 12);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(560, 149);
		this.label2.TabIndex = 1;
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(578, 3);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(205, 173);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox2.TabIndex = 0;
		this.pictureBox2.TabStop = false;
		this.pictureBox4.Image = ZeroItaTV.Properties.Resources.LogoWinnew;
		this.pictureBox4.Location = new System.Drawing.Point(383, 225);
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.Size = new System.Drawing.Size(105, 50);
		this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox4.TabIndex = 6;
		this.pictureBox4.TabStop = false;
		this.pictureBox4.Visible = false;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(10, 253);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(375, 16);
		this.label5.TabIndex = 5;
		this.label5.Text = "Questa versione di TVOSA è stata realizzata per Win Magazine";
		this.label5.Visible = false;
		this.label4.Font = new System.Drawing.Font("Segoe Script", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(3, 188);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(626, 34);
		this.label4.TabIndex = 4;
		this.label4.Text = "TVOSA ringrazia tutti i siti/giornali che hanno parlato e parleranno di noi, a tutti gli utenti, i fan di FaceBook e gli iscritti al sito.. GRAZIE";
		this.label3.Font = new System.Drawing.Font("Segoe Script", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(214, 3);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(572, 168);
		this.label3.TabIndex = 3;
		this.pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
		this.pictureBox3.Location = new System.Drawing.Point(3, 3);
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.Size = new System.Drawing.Size(205, 173);
		this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox3.TabIndex = 2;
		this.pictureBox3.TabStop = false;
		this.textBox1.Location = new System.Drawing.Point(646, 190);
		this.textBox1.Name = "textBox1";
		this.textBox1.ReadOnly = true;
		this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.textBox1.Size = new System.Drawing.Size(139, 20);
		this.textBox1.TabIndex = 2;
		this.textBox1.Text = "progetto TVOSA - versione riscoperta 2026";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(794, 633);
		base.Controls.Add(this.splitContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "Ringraziamenti";
		this.Text = "Credits";
		base.Load += new System.EventHandler(this.Ringraziamenti_Load);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		this.splitContainer3.Panel1.ResumeLayout(false);
		this.splitContainer3.Panel2.ResumeLayout(false);
		this.splitContainer3.Panel2.PerformLayout();
		this.splitContainer3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.splitContainer2.Panel1.ResumeLayout(false);
		this.splitContainer2.Panel2.ResumeLayout(false);
		this.splitContainer2.Panel2.PerformLayout();
		this.splitContainer2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		base.ResumeLayout(false);
	}
}
