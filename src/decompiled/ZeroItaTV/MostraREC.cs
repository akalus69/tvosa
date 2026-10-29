// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class MostraREC : Form
{
	private string dr = "";

	private string vlc = "";

	private IContainer components = null;

	private ListBox listBox1;

	private Label label1;

	private Button button1;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private Button button2;

	private Label label2;

	private ComboBox comboBox1;

	public MostraREC(string r, string v)
	{
		vlc = v;
		dr = r;
		InitializeComponent();
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void caricalista()
	{
		try
		{
			listBox1.Items.Clear();
		}
		catch
		{
		}
		try
		{
			string[] files = Directory.GetFiles(dr);
			foreach (string fileName in files)
			{
				FileInfo fileInfo = new FileInfo(fileName);
				if (fileInfo.Name.IndexOf(".avi") >= 0 || fileInfo.Name.IndexOf(".asf") >= 0)
				{
					listBox1.Items.Add(fileInfo.Name);
				}
			}
		}
		catch
		{
		}
	}

	public void partiprogr()
	{
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
	}

	public void leggirec()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\formatorec.txt");
			string selectedItem = streamReader.ReadLine();
			streamReader.Close();
			comboBox1.SelectedItem = selectedItem;
		}
		catch
		{
		}
	}

	private void MostraREC_Load(object sender, EventArgs e)
	{
		partiprogr();
		leggirec();
		caricalista();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			Process.Start(dr);
		}
		catch
		{
		}
	}

	private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			Process.Start(vlc, "\"" + dr + "\\" + listBox1.SelectedItem.ToString() + "\"");
		}
		catch
		{
		}
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			File.Delete(dr + "\\" + listBox1.SelectedItem.ToString());
			caricalista();
		}
		catch
		{
		}
	}

	public void scrivirec()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\formatorec.txt");
			streamWriter.WriteLine(comboBox1.SelectedItem.ToString());
			Program.formatorec = comboBox1.SelectedItem.ToString();
			streamWriter.Close();
		}
		catch
		{
		}
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		scrivirec();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.MostraREC));
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.label1 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label2 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.button2 = new System.Windows.Forms.Button();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.listBox1.FormattingEnabled = true;
		this.listBox1.ItemHeight = 15;
		this.listBox1.Location = new System.Drawing.Point(9, 36);
		this.listBox1.Margin = new System.Windows.Forms.Padding(4);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(510, 274);
		this.listBox1.TabIndex = 0;
		this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
		this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(5, 18);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(207, 15);
		this.label1.TabIndex = 1;
		this.label1.Text = "Doppio click per aprire link registrato";
		this.label1.Click += new System.EventHandler(this.label1_Click);
		this.button1.Location = new System.Drawing.Point(5, 20);
		this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(187, 26);
		this.button1.TabIndex = 2;
		this.button1.Text = "Apri Cartella con Explorer";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.listBox1);
		this.groupBox1.Location = new System.Drawing.Point(10, 102);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Size = new System.Drawing.Size(536, 321);
		this.groupBox1.TabIndex = 3;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Lista File Registrati";
		this.groupBox2.Controls.Add(this.label2);
		this.groupBox2.Controls.Add(this.comboBox1);
		this.groupBox2.Controls.Add(this.button2);
		this.groupBox2.Controls.Add(this.button1);
		this.groupBox2.Location = new System.Drawing.Point(19, 9);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Size = new System.Drawing.Size(528, 89);
		this.groupBox2.TabIndex = 4;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Opzioni MostraRec";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(331, 32);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(127, 15);
		this.label2.TabIndex = 2;
		this.label2.Text = "Formato registrazione";
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "avi", "asf" });
		this.comboBox1.Location = new System.Drawing.Point(338, 49);
		this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(106, 23);
		this.comboBox1.TabIndex = 4;
		this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
		this.button2.Location = new System.Drawing.Point(5, 49);
		this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(187, 26);
		this.button2.TabIndex = 3;
		this.button2.Text = "Elimina file selezionato";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(570, 448);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "MostraREC";
		base.Opacity = 0.0;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "MostraREC";
		base.Load += new System.EventHandler(this.MostraREC_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		base.ResumeLayout(false);
	}
}
