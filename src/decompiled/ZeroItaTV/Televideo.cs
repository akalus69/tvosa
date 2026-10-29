// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroItaTV;

public class Televideo : Form
{
	private IContainer components = null;

	private WebBrowser webBrowser1;

	public Televideo()
	{
		InitializeComponent();
	}

	public void settapg(string url)
	{
		webBrowser1.Navigate(url);
	}

	private void Televideo_Load(object sender, EventArgs e)
	{
		webBrowser1.ScriptErrorsSuppressed = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Televideo));
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		base.SuspendLayout();
		this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.webBrowser1.Location = new System.Drawing.Point(0, 0);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(426, 570);
		this.webBrowser1.TabIndex = 0;
		this.webBrowser1.Url = new System.Uri("http://www.televideo.rai.it/televideo/pub/popupTelevideo.jsp?p=103&s=1&r=Nazionale&pagetocall=popupTelevideo.jsp", System.UriKind.Absolute);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(426, 570);
		base.Controls.Add(this.webBrowser1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "Televideo";
		this.Text = "Televideo";
		base.Load += new System.EventHandler(this.Televideo_Load);
		base.ResumeLayout(false);
	}
}
