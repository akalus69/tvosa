// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroItaTV;

public class Offerte : Form
{
	private IContainer components = null;

	public WebBrowser webBrowser1;

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Offerte));
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		base.SuspendLayout();
		this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.webBrowser1.Location = new System.Drawing.Point(0, 0);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(792, 535);
		this.webBrowser1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(792, 535);
		base.Controls.Add(this.webBrowser1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Offerte";
		this.Text = "Offerte";
		base.Load += new System.EventHandler(this.Offerte_Load);
		base.ResumeLayout(false);
	}

	public Offerte()
	{
		InitializeComponent();
	}

	private void Offerte_Load(object sender, EventArgs e)
	{
		webBrowser1.ScriptErrorsSuppressed = true;
	}
}
