// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Properties;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class Form1 : Form
{
	private IContainer components = null;

	private Button button1;

	private Button button3;

	private Button button4;

	private Button button5;

	private Button button6;

	private Button button2;

	private Button button7;

	public Label label1;

	private Button button8;

	private Button button9;

	public CheckBox checkBox1;

	private Button button10;

	private Button button11;

	private Button button12;

	private Button button13;

	private Button button14;

	private Button button15;

	private Button button16;

	private Button button17;

	private ContextMenuStrip menuExtra;

	private Button button18;

	private NotifyIcon notifyIcon1;

	private Panel panel1;

	private Button button19;

	private Button button20;

	private PictureBox pictureBox1;

	private Button button21;

	public LinkLabel linkLabel1;

	private ToolTip toolTip1;

	private Button button22;

	private TextBox textBox1;

	public Panel panel2;

	private PictureBox pictureBox2;

	public WebBrowser webBrowser1;

	private Label label2;

	public HtmlElementCollection textAreaMX;

	public Thread TTXSCARICAREVLC;

	public string filedascaricare = "";

	public string docux = "";

	public string tipoprocessore = "x86";

	public bool root = false;

	public bool opzionipubblicita = false;

	public string linguaprogramma = "\\ITA\\";

	public bool modificavideo = true;

	public bool avvisaqnd = false;

	public bool usatomultipli = true;

	public bool multipliwebtv = false;

	public bool chattvosa = false;

	public bool justinalwaysx = false;

	public bool aspettasionoperpartirefilm = true;

	public string vlc = "";

	public string dvreg = "";

	public string canaleguardare = "";

	public string raiuno = ""; // vecchio URL 2011 non piu' attivo

	public string raidue = ""; // vecchio URL 2011 non piu' attivo

	public string raitre = ""; // vecchio URL 2011 non piu' attivo

	public string cinque = ""; // vecchio URL 2011 non piu' attivo

	public string italia1 = ""; // vecchio URL 2011 non piu' attivo

	public string quattro = ""; // vecchio URL 2011 non piu' attivo

	public ProgrammiTV ale;

	private Point mouseOffset;

	private bool isMouseDown = false;

	private Thread TTXV;

	public Thread TTXVPAL;

	public string formatorec = ".asf";

	public Thread TTXINVIO;

	public bool disclaimersino = false;

	public string raiunow = "";

	public string raiduew = "";

	public string raitrew = "";

	public string cinquew = "";

	public string italia1w = "";

	public string quattrow = "";

	public bool raiunoweb = false;

	public bool raidueweb = false;

	public bool raitreweb = false;

	public bool retequattroweb = false;

	public bool canalecinqueweb = false;

	public bool italiaunoweb = false;

	public bool raisport = false;

	public bool raisport2 = false;

	public bool raicinema = false;

	public bool raisatpr = false;

	public bool raiscuola = false;

	public bool raigulp = false;

	public bool raiyoyo = false;

	public bool raisatextra = false;

	public bool raiecono = false;

	public bool raicinque = false;

	public ManageCanali managecan;

	public string raiunostringavlc = "https://www.raiplay.it/dirette/rai1";

	public string raiduestringavlc = "https://www.raiplay.it/dirette/rai2";

	public string raitrestringavlc = "https://www.raiplay.it/dirette/rai3";

	public string raisportstringavlc = "https://www.raiplay.it/dirette/raisport";

	public string raisport2stringavlc = "https://www.raiplay.it/dirette/raisport";

	public string raicinemastringavlc = "https://www.raiplay.it/dirette/raimovie";

	public string raisatprmstringavlc = "https://www.raiplay.it/dirette/raipremium";

	public string raiscuolastringavlc = "https://www.raiplay.it/dirette/raiscuola";

	public string raigulpstringavlc = "https://www.raiplay.it/dirette/raigulp";

	public string raiyoyostringavlc = "https://www.raiplay.it/dirette/raiyoyo";

	public string raisatexstringavlc = "https://www.raiplay.it/dirette/rai5";

	public string raieconostringavlc = "https://www.raiplay.it/dirette/rai3";

	public string raicinquestringavlc = "https://www.raiplay.it/dirette/rai5";

	public string raistoriastringavlc = "https://www.raiplay.it/dirette/raistoria";


	public bool raistoriavlcr = true;

	public bool raiunovlcr = false;

	public bool raiduevlcr = false;

	public bool raitrevlcr = false;

	public bool raisportvlcr = false;

	public bool raisport2vlcr = false;

	public bool raicinemavlcr = false;

	public bool raisatprvlcr = false;

	public bool raiscuolavlcr = false;

	public bool raigulpvlcr = false;

	public bool raiyoyovlcr = false;

	public bool raisatextravlcr = false;

	public bool raieconovlcr = false;

	public bool raicinquevlcr = false;

	public int canaleselezionato = 0;

	public WEBTV TVweb;

	public WEBTV TVwebprov;

	public Opzioni optx;

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Form1));
		this.button1 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.button6 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button7 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.button8 = new System.Windows.Forms.Button();
		this.button9 = new System.Windows.Forms.Button();
		this.button10 = new System.Windows.Forms.Button();
		this.button11 = new System.Windows.Forms.Button();
		this.button12 = new System.Windows.Forms.Button();
		this.button13 = new System.Windows.Forms.Button();
		this.button14 = new System.Windows.Forms.Button();
		this.button15 = new System.Windows.Forms.Button();
		this.button16 = new System.Windows.Forms.Button();
		this.button17 = new System.Windows.Forms.Button();
		this.button18 = new System.Windows.Forms.Button();
		this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
		this.panel1 = new System.Windows.Forms.Panel();
		this.button19 = new System.Windows.Forms.Button();
		this.button20 = new System.Windows.Forms.Button();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.button21 = new System.Windows.Forms.Button();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.panel2 = new System.Windows.Forms.Panel();
		this.button22 = new System.Windows.Forms.Button();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		this.label2 = new System.Windows.Forms.Label();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.button1.AccessibleDescription = "";
		this.button1.AccessibleName = "Registra o Guarda Palinsesto RAI o MEDIASET";
		this.button1.BackColor = System.Drawing.Color.Transparent;
		this.button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
		this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.button1.FlatAppearance.BorderSize = 0;
		this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.Location = new System.Drawing.Point(18, 183);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(123, 25);
		this.button1.TabIndex = 0;
		this.button1.UseVisualStyleBackColor = false;
		this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
		this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
		this.button1.MouseEnter += new System.EventHandler(this.button1_MouseHover);
		this.button3.AccessibleDescription = "";
		this.button3.AccessibleName = "Setta VLC";
		this.button3.BackColor = System.Drawing.Color.Transparent;
		this.button3.BackgroundImage = (System.Drawing.Image)resources.GetObject("button3.BackgroundImage");
		this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button3.FlatAppearance.BorderSize = 0;
		this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.Location = new System.Drawing.Point(13, 31);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(110, 23);
		this.button3.TabIndex = 5;
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.button4.AccessibleDescription = "";
		this.button4.AccessibleName = "uno";
		this.button4.BackColor = System.Drawing.Color.Transparent;
		this.button4.BackgroundImage = (System.Drawing.Image)resources.GetObject("button4.BackgroundImage");
		this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button4.FlatAppearance.BorderSize = 0;
		this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button4.ForeColor = System.Drawing.Color.Black;
		this.button4.Location = new System.Drawing.Point(16, 420);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(38, 19);
		this.button4.TabIndex = 8;
		this.button4.UseVisualStyleBackColor = false;
		this.button4.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button4_MouseDown);
		this.button4.MouseHover += new System.EventHandler(this.button4_MouseHover);
		this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button4_MouseUp);
		this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
		this.button5.AccessibleDescription = "";
		this.button5.AccessibleName = "due";
		this.button5.BackColor = System.Drawing.Color.Transparent;
		this.button5.BackgroundImage = (System.Drawing.Image)resources.GetObject("button5.BackgroundImage");
		this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button5.FlatAppearance.BorderSize = 0;
		this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button5.ForeColor = System.Drawing.Color.Black;
		this.button5.Location = new System.Drawing.Point(59, 420);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(38, 19);
		this.button5.TabIndex = 9;
		this.button5.UseVisualStyleBackColor = false;
		this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button5_MouseDown);
		this.button5.MouseHover += new System.EventHandler(this.button5_MouseHover);
		this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button5_MouseUp);
		this.checkBox1.AutoSize = true;
		this.checkBox1.BackColor = System.Drawing.Color.Transparent;
		this.checkBox1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.checkBox1.Location = new System.Drawing.Point(16, 81);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(103, 19);
		this.checkBox1.TabIndex = 7;
		this.checkBox1.Text = "FULL SCREEN";
		this.checkBox1.UseVisualStyleBackColor = false;
		this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
		this.button6.AccessibleDescription = "";
		this.button6.AccessibleName = "Setta Directory dove registrare i file video";
		this.button6.BackColor = System.Drawing.Color.Transparent;
		this.button6.BackgroundImage = (System.Drawing.Image)resources.GetObject("button6.BackgroundImage");
		this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button6.FlatAppearance.BorderSize = 0;
		this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button6.Location = new System.Drawing.Point(14, 17);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(110, 32);
		this.button6.TabIndex = 4;
		this.button6.UseVisualStyleBackColor = false;
		this.button6.Click += new System.EventHandler(this.button6_Click);
		this.button2.AccessibleDescription = "";
		this.button2.AccessibleName = "Chiudi TVOSA";
		this.button2.BackColor = System.Drawing.Color.Transparent;
		this.button2.BackgroundImage = (System.Drawing.Image)resources.GetObject("button2.BackgroundImage");
		this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button2.FlatAppearance.BorderSize = 0;
		this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.Location = new System.Drawing.Point(111, 12);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(25, 23);
		this.button2.TabIndex = 31;
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(this.button2_Click_1);
		this.button7.AccessibleDescription = "";
		this.button7.AccessibleName = "tre";
		this.button7.BackColor = System.Drawing.Color.Transparent;
		this.button7.BackgroundImage = (System.Drawing.Image)resources.GetObject("button7.BackgroundImage");
		this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button7.FlatAppearance.BorderSize = 0;
		this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button7.ForeColor = System.Drawing.Color.Black;
		this.button7.Location = new System.Drawing.Point(101, 420);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(38, 19);
		this.button7.TabIndex = 10;
		this.button7.UseVisualStyleBackColor = false;
		this.button7.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
		this.button7.Click += new System.EventHandler(this.button7_Click);
		this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button7_MouseDown);
		this.button7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button7_MouseUp);
		this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(31, 63);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(96, 116);
		this.label1.TabIndex = 9;
		this.label1.Text = " ***** TVOSA *****\r\n       \r\n\r\n\r\n\r\n\r\n\r\n               ver 2.9f";
		this.label1.Click += new System.EventHandler(this.label1_Click);
		this.button8.AccessibleDescription = "";
		this.button8.AccessibleName = "Nascondi TVOSA in traybar";
		this.button8.BackColor = System.Drawing.Color.Transparent;
		this.button8.BackgroundImage = (System.Drawing.Image)resources.GetObject("button8.BackgroundImage");
		this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button8.FlatAppearance.BorderSize = 0;
		this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button8.Location = new System.Drawing.Point(84, 11);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(25, 23);
		this.button8.TabIndex = 30;
		this.button8.UseVisualStyleBackColor = false;
		this.button8.Click += new System.EventHandler(this.button8_Click);
		this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button8_MouseDown);
		this.button8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button8_MouseUp);
		this.button9.AccessibleDescription = "";
		this.button9.AccessibleName = "Lista Canali";
		this.button9.BackColor = System.Drawing.Color.Transparent;
		this.button9.BackgroundImage = (System.Drawing.Image)resources.GetObject("button9.BackgroundImage");
		this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button9.FlatAppearance.BorderSize = 0;
		this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button9.Location = new System.Drawing.Point(18, 241);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(123, 25);
		this.button9.TabIndex = 2;
		this.button9.UseVisualStyleBackColor = false;
		this.button9.MouseLeave += new System.EventHandler(this.button9_MouseLeave);
		this.button9.Click += new System.EventHandler(this.button9_Click);
		this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button9_MouseDown);
		this.button9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button9_MouseUp);
		this.button9.MouseEnter += new System.EventHandler(this.button9_MouseHover);
		this.button10.AccessibleDescription = "";
		this.button10.AccessibleName = "quattro";
		this.button10.BackColor = System.Drawing.Color.Transparent;
		this.button10.BackgroundImage = (System.Drawing.Image)resources.GetObject("button10.BackgroundImage");
		this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button10.FlatAppearance.BorderSize = 0;
		this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button10.ForeColor = System.Drawing.Color.Black;
		this.button10.Location = new System.Drawing.Point(16, 446);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(38, 19);
		this.button10.TabIndex = 11;
		this.button10.UseVisualStyleBackColor = false;
		this.button10.MouseLeave += new System.EventHandler(this.button10_MouseLeave);
		this.button10.Click += new System.EventHandler(this.button10_Click);
		this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button10_MouseDown);
		this.button10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
		this.button10.MouseEnter += new System.EventHandler(this.button10_MouseEnter);
		this.button11.AccessibleDescription = "";
		this.button11.AccessibleName = "cinque";
		this.button11.BackColor = System.Drawing.Color.Transparent;
		this.button11.BackgroundImage = (System.Drawing.Image)resources.GetObject("button11.BackgroundImage");
		this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button11.FlatAppearance.BorderSize = 0;
		this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button11.ForeColor = System.Drawing.Color.Black;
		this.button11.Location = new System.Drawing.Point(59, 446);
		this.button11.Name = "button11";
		this.button11.Size = new System.Drawing.Size(38, 19);
		this.button11.TabIndex = 12;
		this.button11.UseVisualStyleBackColor = false;
		this.button11.MouseLeave += new System.EventHandler(this.button11_MouseLeave);
		this.button11.Click += new System.EventHandler(this.button11_Click);
		this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button11_MouseDown);
		this.button11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button11_MouseUp);
		this.button11.MouseEnter += new System.EventHandler(this.button11_MouseEnter);
		this.button12.AccessibleDescription = "";
		this.button12.AccessibleName = "sei";
		this.button12.BackColor = System.Drawing.Color.Transparent;
		this.button12.BackgroundImage = (System.Drawing.Image)resources.GetObject("button12.BackgroundImage");
		this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button12.FlatAppearance.BorderSize = 0;
		this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button12.ForeColor = System.Drawing.Color.Black;
		this.button12.Location = new System.Drawing.Point(101, 446);
		this.button12.Name = "button12";
		this.button12.Size = new System.Drawing.Size(38, 19);
		this.button12.TabIndex = 14;
		this.button12.UseVisualStyleBackColor = false;
		this.button12.MouseLeave += new System.EventHandler(this.button12_MouseLeave);
		this.button12.Click += new System.EventHandler(this.button12_Click);
		this.button12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button12_MouseDown);
		this.button12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button12_MouseUp);
		this.button12.MouseEnter += new System.EventHandler(this.button12_MouseEnter);
		this.button13.AccessibleDescription = "";
		this.button13.AccessibleName = "sette";
		this.button13.BackColor = System.Drawing.Color.Transparent;
		this.button13.BackgroundImage = (System.Drawing.Image)resources.GetObject("button13.BackgroundImage");
		this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button13.FlatAppearance.BorderSize = 0;
		this.button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button13.ForeColor = System.Drawing.Color.Black;
		this.button13.Location = new System.Drawing.Point(16, 470);
		this.button13.Name = "button13";
		this.button13.Size = new System.Drawing.Size(38, 19);
		this.button13.TabIndex = 15;
		this.button13.UseVisualStyleBackColor = false;
		this.button13.MouseLeave += new System.EventHandler(this.button13_MouseLeave);
		this.button13.Click += new System.EventHandler(this.button13_Click);
		this.button13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button13_MouseDown);
		this.button13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button13_MouseUp);
		this.button13.MouseEnter += new System.EventHandler(this.button13_MouseEnter);
		this.button14.AccessibleDescription = "";
		this.button14.AccessibleName = "otto";
		this.button14.BackColor = System.Drawing.Color.Transparent;
		this.button14.BackgroundImage = (System.Drawing.Image)resources.GetObject("button14.BackgroundImage");
		this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button14.FlatAppearance.BorderSize = 0;
		this.button14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button14.ForeColor = System.Drawing.Color.Black;
		this.button14.Location = new System.Drawing.Point(59, 470);
		this.button14.Name = "button14";
		this.button14.Size = new System.Drawing.Size(38, 19);
		this.button14.TabIndex = 16;
		this.button14.UseVisualStyleBackColor = false;
		this.button14.MouseLeave += new System.EventHandler(this.button14_MouseLeave);
		this.button14.Click += new System.EventHandler(this.button14_Click);
		this.button14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button14_MouseDown);
		this.button14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button14_MouseUp);
		this.button14.MouseEnter += new System.EventHandler(this.button14_MouseEnter);
		this.button15.AccessibleDescription = "";
		this.button15.AccessibleName = "nove";
		this.button15.BackColor = System.Drawing.Color.Transparent;
		this.button15.BackgroundImage = (System.Drawing.Image)resources.GetObject("button15.BackgroundImage");
		this.button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button15.FlatAppearance.BorderSize = 0;
		this.button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button15.ForeColor = System.Drawing.Color.Black;
		this.button15.Location = new System.Drawing.Point(101, 470);
		this.button15.Name = "button15";
		this.button15.Size = new System.Drawing.Size(38, 19);
		this.button15.TabIndex = 17;
		this.button15.UseVisualStyleBackColor = false;
		this.button15.MouseLeave += new System.EventHandler(this.button15_MouseLeave);
		this.button15.Click += new System.EventHandler(this.button15_Click);
		this.button15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button15_MouseDown);
		this.button15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button15_MouseUp);
		this.button15.MouseEnter += new System.EventHandler(this.button15_MouseEnter);
		this.button16.AccessibleDescription = "";
		this.button16.AccessibleName = "zero";
		this.button16.BackColor = System.Drawing.Color.Transparent;
		this.button16.BackgroundImage = (System.Drawing.Image)resources.GetObject("button16.BackgroundImage");
		this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button16.FlatAppearance.BorderSize = 0;
		this.button16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button16.ForeColor = System.Drawing.Color.Black;
		this.button16.Location = new System.Drawing.Point(59, 496);
		this.button16.Name = "button16";
		this.button16.Size = new System.Drawing.Size(38, 19);
		this.button16.TabIndex = 18;
		this.button16.UseVisualStyleBackColor = false;
		this.button16.MouseLeave += new System.EventHandler(this.button16_MouseLeave);
		this.button16.Click += new System.EventHandler(this.button16_Click);
		this.button16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button16_MouseDown);
		this.button16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button16_MouseUp);
		this.button16.MouseEnter += new System.EventHandler(this.button16_MouseEnter);
		this.button17.AccessibleDescription = "";
		this.button17.AccessibleName = "Extra: trova film e trailer";
		this.button17.BackColor = System.Drawing.Color.Transparent;
		this.button17.BackgroundImage = (System.Drawing.Image)resources.GetObject("button17.BackgroundImage");
		this.button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button17.FlatAppearance.BorderSize = 0;
		this.button17.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button17.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button17.ForeColor = System.Drawing.Color.Black;
		this.button17.Location = new System.Drawing.Point(18, 212);
		this.button17.Name = "button17";
		this.button17.Size = new System.Drawing.Size(123, 25);
		this.button17.TabIndex = 1;
		this.button17.UseVisualStyleBackColor = false;
		this.button17.MouseLeave += new System.EventHandler(this.button17_MouseLeave);
		this.button17.Click += new System.EventHandler(this.button17_Click);
		this.button17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button17_MouseDown);
		this.button17.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
		this.button17.MouseEnter += new System.EventHandler(this.button17_MouseHover);
		this.button18.AccessibleDescription = "";
		this.button18.AccessibleName = "Apri Cartella dove hai registrato i video";
		this.button18.BackColor = System.Drawing.Color.Transparent;
		this.button18.BackgroundImage = (System.Drawing.Image)resources.GetObject("button18.BackgroundImage");
		this.button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button18.FlatAppearance.BorderSize = 0;
		this.button18.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button18.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button18.Location = new System.Drawing.Point(13, 55);
		this.button18.Name = "button18";
		this.button18.Size = new System.Drawing.Size(110, 23);
		this.button18.TabIndex = 6;
		this.button18.UseVisualStyleBackColor = false;
		this.button18.Click += new System.EventHandler(this.button18_Click);
		this.notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
		this.notifyIcon1.Text = "TVOSA";
		this.notifyIcon1.Visible = true;
		this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
		this.panel1.BackColor = System.Drawing.Color.Transparent;
		this.panel1.Controls.Add(this.button6);
		this.panel1.Controls.Add(this.button18);
		this.panel1.Controls.Add(this.button3);
		this.panel1.Controls.Add(this.checkBox1);
		this.panel1.Location = new System.Drawing.Point(12, 298);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(43, 22);
		this.panel1.TabIndex = 21;
		this.button19.AccessibleDescription = "";
		this.button19.AccessibleName = "Opzioni";
		this.button19.BackColor = System.Drawing.Color.Transparent;
		this.button19.BackgroundImage = (System.Drawing.Image)resources.GetObject("button19.BackgroundImage");
		this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button19.FlatAppearance.BorderSize = 0;
		this.button19.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button19.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button19.Location = new System.Drawing.Point(18, 270);
		this.button19.Name = "button19";
		this.button19.Size = new System.Drawing.Size(123, 25);
		this.button19.TabIndex = 3;
		this.button19.UseVisualStyleBackColor = false;
		this.button19.MouseLeave += new System.EventHandler(this.button19_MouseLeave);
		this.button19.Click += new System.EventHandler(this.button19_Click);
		this.button19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button19_MouseDown);
		this.button19.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button19_MouseUp);
		this.button19.MouseEnter += new System.EventHandler(this.button19_MouseEnter);
		this.button20.AccessibleDescription = "";
		this.button20.AccessibleName = "Autori";
		this.button20.BackColor = System.Drawing.Color.Transparent;
		this.button20.BackgroundImage = (System.Drawing.Image)resources.GetObject("button20.BackgroundImage");
		this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button20.FlatAppearance.BorderSize = 0;
		this.button20.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button20.ForeColor = System.Drawing.Color.Black;
		this.button20.Location = new System.Drawing.Point(101, 496);
		this.button20.Name = "button20";
		this.button20.Size = new System.Drawing.Size(38, 19);
		this.button20.TabIndex = 23;
		this.button20.UseVisualStyleBackColor = false;
		this.button20.MouseLeave += new System.EventHandler(this.button20_MouseLeave);
		this.button20.Click += new System.EventHandler(this.button20_Click);
		this.button20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button20_MouseDown);
		this.button20.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button20_MouseUp);
		this.button20.MouseEnter += new System.EventHandler(this.button20_MouseEnter);
		this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(60, 327);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(38, 34);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 24;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
		this.button21.AccessibleDescription = "";
		this.button21.AccessibleName = "Televideo";
		this.button21.BackColor = System.Drawing.Color.Transparent;
		this.button21.BackgroundImage = (System.Drawing.Image)resources.GetObject("button21.BackgroundImage");
		this.button21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button21.FlatAppearance.BorderSize = 0;
		this.button21.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
		this.button21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
		this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button21.ForeColor = System.Drawing.Color.Black;
		this.button21.Location = new System.Drawing.Point(16, 496);
		this.button21.Name = "button21";
		this.button21.Size = new System.Drawing.Size(38, 19);
		this.button21.TabIndex = 25;
		this.button21.UseVisualStyleBackColor = false;
		this.button21.MouseLeave += new System.EventHandler(this.button21_MouseLeave);
		this.button21.Click += new System.EventHandler(this.button21_Click);
		this.button21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button21_MouseDown);
		this.button21.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button21_MouseUp);
		this.button21.MouseEnter += new System.EventHandler(this.button21_MouseEnter);
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
		this.linkLabel1.Font = new System.Drawing.Font("Comic Sans MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel1.LinkColor = System.Drawing.Color.Wheat;
		this.linkLabel1.Location = new System.Drawing.Point(31, 127);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(97, 32);
		this.linkLabel1.TabIndex = 26;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "Nuova Versione\r\nDISPONIBILE";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
		this.toolTip1.IsBalloon = true;
		this.panel2.BackColor = System.Drawing.Color.Transparent;
		this.panel2.Controls.Add(this.button22);
		this.panel2.Controls.Add(this.textBox1);
		this.panel2.Location = new System.Drawing.Point(18, 35);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(126, 25);
		this.panel2.TabIndex = 28;
		this.button22.AccessibleDescription = "";
		this.button22.AccessibleName = "Guarda canale inserito";
		this.button22.ForeColor = System.Drawing.Color.DarkOliveGreen;
		this.button22.Location = new System.Drawing.Point(97, -1);
		this.button22.Name = "button22";
		this.button22.Size = new System.Drawing.Size(29, 23);
		this.button22.TabIndex = 1;
		this.button22.Text = "ok";
		this.button22.UseVisualStyleBackColor = true;
		this.button22.Click += new System.EventHandler(this.button22_Click);
		this.textBox1.AccessibleDescription = "";
		this.textBox1.AccessibleName = "Inserisci canale che desideri vedere";
		this.textBox1.Location = new System.Drawing.Point(0, 1);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(96, 20);
		this.textBox1.TabIndex = 0;
		this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
		this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox2.Location = new System.Drawing.Point(58, 394);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(42, 13);
		this.pictureBox2.TabIndex = 32;
		this.pictureBox2.TabStop = false;
		this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
		this.webBrowser1.Location = new System.Drawing.Point(12, 379);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(20, 37);
		this.webBrowser1.TabIndex = 33;
		this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
		this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(56, 398);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(46, 9);
		this.label2.TabIndex = 34;
		this.label2.Text = "ZAPPING";
		this.label2.Click += new System.EventHandler(this.pictureBox2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Fuchsia;
		this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		base.ClientSize = new System.Drawing.Size(156, 534);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.webBrowser1);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.button16);
		base.Controls.Add(this.linkLabel1);
		base.Controls.Add(this.button21);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.button20);
		// 2026-10-29: TROVA FILM e TRAILER SERATA non sono piu' pulsanti sul
		// telecomando: vivono nel menu del tasto EXTRA (button17_Click).
		base.Controls.Add(this.button19);
		base.Controls.Add(this.button17);
		base.Controls.Add(this.button15);
		base.Controls.Add(this.button14);
		base.Controls.Add(this.button13);
		base.Controls.Add(this.button12);
		base.Controls.Add(this.button11);
		base.Controls.Add(this.button10);
		base.Controls.Add(this.button9);
		base.Controls.Add(this.button8);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button7);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button1);
		this.DoubleBuffered = true;
		this.ForeColor = System.Drawing.Color.White;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Form1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "TVOSA";
		base.TopMost = true;
		base.TransparencyKey = System.Drawing.Color.Fuchsia;
		base.Load += new System.EventHandler(this.Form1_Load);
		base.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
		base.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
		base.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
		base.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public Form1()
	{
		InitializeComponent();
	}

	public void settatooltip()
	{
		toolTip1.AutoPopDelay = 8000;
		toolTip1.InitialDelay = 1000;
		toolTip1.ReshowDelay = 500;
		toolTip1.ShowAlways = true;
		toolTip1.SetToolTip(pictureBox1, "Vai al sito ufficiale di TVOSA per le ultime notizie o la guida del programma, doppio click qui per accederci");
		toolTip1.SetToolTip(button20, "Autori");
		if (chattvosa)
		{
			toolTip1.SetToolTip(button21, "Chat TVOSA");
		}
		else
		{
			toolTip1.SetToolTip(button21, "Televideo");
		}
		toolTip1.SetToolTip(button8, "Nascondi TVOSA in traybar");
		toolTip1.SetToolTip(button2, "Chiudi TVOSA");
	}

	public void scrivivlc(string x)
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\vlc.txt");
			streamWriter.WriteLine(x);
			streamWriter.Close();
		}
		catch
		{
		}
	}

	public void leggiopzchat()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\chatvosa.txt");
			string text = streamReader.ReadLine();
			streamReader.Close();
			if (text.IndexOf("tru") >= 0)
			{
				chattvosa = true;
			}
		}
		catch
		{
		}
	}

	private static byte[] encryptStringToBytes_AES(string plainText, byte[] Key, byte[] IV)
	{
		if (plainText == null || plainText.Length <= 0)
		{
			return null;
		}
		if (Key == null || Key.Length <= 0)
		{
			return null;
		}
		if (IV == null || IV.Length <= 0)
		{
			return null;
		}
		MemoryStream memoryStream = null;
		RijndaelManaged rijndaelManaged = null;
		try
		{
			rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = IV;
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			memoryStream = new MemoryStream();
			using CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.Write(plainText);
		}
		finally
		{
			rijndaelManaged?.Clear();
		}
		return memoryStream.ToArray();
	}

	private static string decryptStringFromBytes_AES(IList<byte> cipherText, byte[] Key, byte[] IV)
	{
		if (cipherText == null || cipherText.Count <= 0)
		{
			return null;
		}
		if (Key == null)
		{
			return null;
		}
		if (IV == null || IV.Length <= 0)
		{
			return null;
		}
		RijndaelManaged rijndaelManaged = null;
		string result = null;
		try
		{
			byte[] array = new byte[cipherText.Count];
			int num = 0;
			foreach (byte item in cipherText)
			{
				array[num] = item;
				num++;
			}
			rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = IV;
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryStream stream = new MemoryStream(array);
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2);
			result = streamReader.ReadToEnd();
		}
		finally
		{
			rijndaelManaged?.Clear();
		}
		return result;
	}

	public void aggiornacanalicriptati()
	{
		try
		{
			if (!File.Exists(Program.pr + "\\opz"))
			{
				return;
			}
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			IList<byte> list = new List<byte>();
			StreamReader streamReader = new StreamReader(Program.pr + "\\opz");
			string text = streamReader.ReadLine();
			string text2 = streamReader.ReadLine();
			string text3 = streamReader.ReadLine();
			streamReader.Close();
			int num = 0;
			byte[] array = new byte[32];
			while (text2.IndexOf(";") >= 0)
			{
				string s = text2.Substring(0, text2.IndexOf(";"));
				text2 = text2.Substring(text2.IndexOf(";") + 1);
				array[num] = byte.Parse(s);
				num++;
			}
			array[num] = byte.Parse(text2);
			rijndaelManaged.Key = array;
			num = 0;
			byte[] array2 = new byte[16];
			while (text3.IndexOf(";") >= 0)
			{
				string s = text3.Substring(0, text3.IndexOf(";"));
				text3 = text3.Substring(text3.IndexOf(";") + 1);
				array2[num] = byte.Parse(s);
				num++;
			}
			array2[num] = byte.Parse(text3);
			rijndaelManaged.IV = array2;
			num = 0;
			while (text.IndexOf(";") >= 0)
			{
				string s = text.Substring(0, text.IndexOf(";"));
				text = text.Substring(text.IndexOf(";") + 1);
				list.Add(byte.Parse(s));
				num++;
			}
			list.Add(byte.Parse(text));
			string text4 = decryptStringFromBytes_AES(list, rijndaelManaged.Key, rijndaelManaged.IV);
			num = 1;
			while (text4.IndexOf(Environment.NewLine) >= 0)
			{
				string text5 = text4.Substring(0, text4.IndexOf(Environment.NewLine));
				switch (num)
				{
				case 1:
					raiunostringavlc = text5;
					break;
				case 2:
					raiduestringavlc = text5;
					break;
				case 3:
					raitrestringavlc = text5;
					break;
				case 4:
					raisportstringavlc = text5;
					break;
				case 5:
					raicinemastringavlc = text5;
					break;
				case 6:
					raisatprmstringavlc = text5;
					break;
				case 7:
					raiscuolastringavlc = text5;
					break;
				case 8:
					raigulpstringavlc = text5;
					break;
				case 9:
					raiyoyostringavlc = text5;
					break;
				case 10:
					raisatexstringavlc = text5;
					break;
				case 11:
					raieconostringavlc = text5;
					break;
				case 12:
					raistoriastringavlc = text5;
					break;
				}
				num++;
				text4 = text4.Substring(text4.IndexOf(Environment.NewLine) + 1);
			}
		}
		catch (Exception)
		{
		}
	}

	public void creagioco()
		{
			// BONIFICA 2026-10-28: GamesLink/Gioca (giochi Flash pirata, Flash EOL 2021) rimosso.
		}

	private static string decryptStringFromBytes_AES(byte[] cipherText, byte[] Key, byte[] IV)
	{
		if (cipherText == null || cipherText.Length <= 0)
		{
			throw new ArgumentNullException("cipherText");
		}
		if (Key == null || Key.Length <= 0)
		{
			throw new ArgumentNullException("Key");
		}
		if (IV == null || IV.Length <= 0)
		{
			throw new ArgumentNullException("Key");
		}
		RijndaelManaged rijndaelManaged = null;
		string result = null;
		try
		{
			rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = IV;
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryStream stream = new MemoryStream(cipherText);
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2);
			result = streamReader.ReadToEnd();
		}
		finally
		{
			rijndaelManaged?.Clear();
		}
		return result;
	}

	public void scrivireg(string x)
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\regdv.txt");
			streamWriter.WriteLine(x);
			streamWriter.Close();
		}
		catch
		{
		}
	}

	private void leggijustin()
	{
		try
		{
			if (File.Exists(Program.pr + "\\justalways"))
			{
				justinalwaysx = true;
			}
		}
		catch
		{
		}
	}

	public void leggifull()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\full.txt");
			string text = streamReader.ReadLine();
			streamReader.Close();
			if (text == "1")
			{
				checkBox1.Checked = true;
			}
		}
		catch
		{
		}
	}

	public void leggidvreg()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\regdv.txt");
			dvreg = streamReader.ReadLine();
			streamReader.Close();
		}
		catch
		{
		}
	}

	public void partiriccan()
	{
		try
		{
			TTXV.Abort();
		}
		catch
		{
		}
		try
		{
			if (aspettasionoperpartirefilm && multipliwebtv && usatomultipli)
			{
				TVwebprov = new WEBTV();
				usatomultipli = false;
				TVwebprov.FormBorderStyle = FormBorderStyle.Sizable;
				TVwebprov.ControlBox = true;
				TVwebprov.button2.Visible = false;
				TVwebprov.button3.Visible = false;
				TVwebprov.Show();
				TVwebprov.Hide();
			}
			ThreadDbtele threadDbtele = new ThreadDbtele(this);
			TTXV = new Thread(threadDbtele.guardav);
			TTXV.IsBackground = true;
			TTXV.Priority = ThreadPriority.BelowNormal;
			TTXV.Start();
		}
		catch
		{
		}
	}

	public void scrivifull()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\full.txt");
			if (checkBox1.Checked)
			{
				streamWriter.WriteLine("1");
			}
			else
			{
				streamWriter.WriteLine("0");
			}
			streamWriter.Close();
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
			Program.formatorec = streamReader.ReadLine();
			streamReader.Close();
		}
		catch
		{
		}
	}

	public void leggiopzcanx()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\configopz.txt");
			try
			{
				string text = "";
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raiunoweb = true;
				}
				else
				{
					raiunoweb = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raiunovlcr = true;
					}
					else
					{
						raiunovlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raidueweb = true;
				}
				else
				{
					raidueweb = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raiduevlcr = true;
					}
					else
					{
						raiduevlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raitreweb = true;
				}
				else
				{
					raitreweb = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raitrevlcr = true;
					}
					else
					{
						raitrevlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					retequattroweb = true;
				}
				else
				{
					retequattroweb = false;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					canalecinqueweb = true;
				}
				else
				{
					canalecinqueweb = false;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					italiaunoweb = true;
				}
				else
				{
					italiaunoweb = false;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raisport = true;
				}
				else
				{
					raisport = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raisportvlcr = true;
					}
					else
					{
						raisportvlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raicinema = true;
				}
				else
				{
					raicinema = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raicinemavlcr = true;
					}
					else
					{
						raicinemavlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raisatpr = true;
				}
				else
				{
					raisatpr = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raisatprvlcr = true;
					}
					else
					{
						raisatprvlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raiscuola = true;
				}
				else
				{
					raiscuola = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raiscuolavlcr = true;
					}
					else
					{
						raiscuolavlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raigulp = true;
				}
				else
				{
					raigulp = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raigulpvlcr = true;
					}
					else
					{
						raigulpvlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raiyoyo = true;
				}
				else
				{
					raiyoyo = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raiyoyovlcr = true;
					}
					else
					{
						raiyoyovlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raisatextra = true;
				}
				else
				{
					raisatextra = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raisatextravlcr = true;
					}
					else
					{
						raisatextravlcr = false;
					}
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					raiecono = true;
				}
				else
				{
					raiecono = false;
					if (text.IndexOf("VLCR") >= 0)
					{
						raieconovlcr = true;
					}
					else
					{
						raieconovlcr = false;
					}
				}
			}
			catch
			{
			}
			streamReader.Close();
		}
		catch
		{
		}
	}

	public void nuovicanaliraimedia()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\raimediaset.txt");
			string text = streamReader.ReadLine();
			if (text.IndexOf("|<-->|") > 0)
			{
				raiunow = text.Substring(text.IndexOf("|<-->|") + 6);
				text = text.Substring(0, text.IndexOf("|<-->|"));
			}
			raiuno = text;
			text = streamReader.ReadLine();
			if (text.IndexOf("|<-->|") > 0)
			{
				raiduew = text.Substring(text.IndexOf("|<-->|") + 6);
				text = text.Substring(0, text.IndexOf("|<-->|"));
			}
			raidue = text;
			text = streamReader.ReadLine();
			if (text.IndexOf("|<-->|") > 0)
			{
				raitrew = text.Substring(text.IndexOf("|<-->|") + 6);
				text = text.Substring(0, text.IndexOf("|<-->|"));
			}
			raitre = text;
			text = streamReader.ReadLine();
			if (text.IndexOf("|<-->|") > 0)
			{
				quattrow = text.Substring(text.IndexOf("|<-->|") + 6);
				text = text.Substring(0, text.IndexOf("|<-->|"));
			}
			quattro = text;
			text = streamReader.ReadLine();
			if (text.IndexOf("|<-->|") > 0)
			{
				cinquew = text.Substring(text.IndexOf("|<-->|") + 6);
				text = text.Substring(0, text.IndexOf("|<-->|"));
			}
			cinque = text;
			text = streamReader.ReadLine();
			if (text.IndexOf("|<-->|") > 0)
			{
				italia1w = text.Substring(text.IndexOf("|<-->|") + 6);
				text = text.Substring(0, text.IndexOf("|<-->|"));
			}
			italia1 = text;
			streamReader.Close();
		}
		catch
		{
		}
	}

	public void partiupdate()
	{
		try
		{
			ThreadCapo threadCapo = new ThreadCapo(this);
			Thread thread = new Thread(threadCapo.leggiaggiornamento);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
	}

	private void controllaprocessore()
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			if (folderPath.IndexOf("(x86)") > 0)
			{
				tipoprocessore = "x64";
			}
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\controllopc.txt");
			streamWriter.WriteLine(tipoprocessore);
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		webBrowser1.ScriptErrorsSuppressed = true;
		webBrowser1.Visible = false;
		controllaprocessore();
		try
		{
			managecan = new ManageCanali(this);
		}
		catch (Exception)
		{
		}
		try
		{
			Program.mio = this;
			// MCP 2026: server di controllo localhost-only (127.0.0.1:19831)
			ControlServer.Start(this);
		}
		catch
		{
		}
		try
		{
			if (File.Exists(Program.pr + "\\linguaggio"))
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\linguaggio");
				string text = streamReader.ReadLine();
				streamReader.Close();
				linguaprogramma = "\\" + text + "\\";
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(Program.pr + "\\avvisaqnd"))
			{
				avvisaqnd = true;
				try
				{
					ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(this);
					TTXVPAL = new Thread(threadSimileAltriCanali.vaiemostraprogrammitv);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
				}
				catch
				{
				}
			}
			if (!File.Exists(Program.pr + "\\disc.txt"))
			{
				DISCLAIMER dISCLAIMER = new DISCLAIMER(this);
				dISCLAIMER.ShowDialog();
			}
			else
			{
				disclaimersino = true;
			}
			if (!disclaimersino)
			{
				Close();
			}
			if (!File.Exists(Program.pr + "\\nvda"))
			{
				panel2.Visible = false;
			}
			TVweb = new WEBTV();
			TVweb.Show();
			TVweb.Hide();
			linkLabel1.Visible = false;
			panel1.Visible = false;
			notifyIcon1.Visible = false;
			Control.CheckForIllegalCrossThreadCalls = false;
			leggifull();
			leggijustin();
			leggirec();
			leggiopzchat();
			partiupdate();
			nuovicanaliraimedia();
			leggiopzcanx();
			settatooltip();
			if (!Directory.Exists(Program.pr + "\\REG"))
			{
				Directory.CreateDirectory(Program.pr + "\\REG");
			}
			dvreg = Program.pr + "\\REG";
			leggidvreg();
			bool flag = true;
			if (File.Exists(Program.pr + "\\vlc.txt"))
			{
				flag = false;
				StreamReader streamReader = new StreamReader(Program.pr + "\\vlc.txt");
				vlc = streamReader.ReadLine();
				streamReader.Close();
				if (!File.Exists(vlc))
				{
					flag = true;
				}
			}
			if (flag)
			{
				try
				{
					ThreadVLC threadVLC = new ThreadVLC(this);
					Thread thread = new Thread(threadVLC.vai);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
				}
				catch
				{
				}
			}
			try
			{
				ThreadCapo threadCapo = new ThreadCapo(this);
				Thread thread = new Thread(threadCapo.vai);
				thread.IsBackground = true;
				thread.Priority = ThreadPriority.BelowNormal;
				thread.Start();
			}
			catch
			{
			}
			try
			{
				if (DateTime.Now.DayOfWeek.ToString().ToLowerInvariant() == "thursday")
				{
					StreamReader streamReader = new StreamReader(Application.StartupPath + "\\gggg");
					string text2 = streamReader.ReadLine();
					streamReader.Close();
					if (text2 != DateTime.Now.Day.ToString())
					{
						StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\gggg");
						streamWriter.WriteLine(DateTime.Now.Day.ToString());
						streamWriter.Close();
						Offerte offerte = new Offerte();
						offerte.Text = "NewsProgramma";
						// BONIFICA 2026: pagina news 2011 morta, si usa mymovies (stessa fonte EPG)
					offerte.webBrowser1.Navigate("https://www.mymovies.it/");
						offerte.Show();
					}
				}
			}
			catch (Exception)
			{
				try
				{
					StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\gggg");
					streamWriter.WriteLine(DateTime.Now.Day.ToString());
					streamWriter.Close();
					Offerte offerte = new Offerte();
					offerte.Text = "NewsProgramma";
					// BONIFICA 2026: pagina news 2011 morta, si usa mymovies (stessa fonte EPG)
					offerte.webBrowser1.Navigate("https://www.mymovies.it/");
					offerte.Show();
				}
				catch (Exception)
				{
				}
			}
		}
		catch
		{
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Process.Start(Program.pr);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.ShowDialog();
		if (!string.IsNullOrEmpty(openFileDialog.FileName))
		{
			scrivivlc(openFileDialog.FileName);
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			ale.Close();
		}
		catch
		{
		}
		ale = new ProgrammiTV(this);
		ale.Show();
	}

	private void button4_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "1";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
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
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "2";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		scrivifull();
	}

	private void button6_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.ShowDialog();
		if (folderBrowserDialog.SelectedPath != null)
		{
			scrivireg(folderBrowserDialog.SelectedPath);
			dvreg = folderBrowserDialog.SelectedPath;
		}
	}

	private void button2_Click_1(object sender, EventArgs e)
	{
		Close();
	}

	private void Form1_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			int num = -e.X - SystemInformation.FrameBorderSize.Width;
			int num2 = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
			mouseOffset = new Point(num, num2);
			isMouseDown = true;
		}
	}

	private void Form1_MouseMove(object sender, MouseEventArgs e)
	{
		if (isMouseDown)
		{
			Point mousePosition = Control.MousePosition;
			mousePosition.Offset(mouseOffset.X, mouseOffset.Y);
			Location = mousePosition;
		}
	}

	private void Form1_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			isMouseDown = false;
		}
	}

	private void button9_Click(object sender, EventArgs e)
	{
		try
		{
			managecan.Close();
		}
		catch (Exception)
		{
		}
		try
		{
			managecan = new ManageCanali(this);
			managecan.Show();
		}
		catch (Exception)
		{
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "3";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button10_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "4";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button11_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "5";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button12_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "6";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button13_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "7";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button14_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "8";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button15_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "9";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button16_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				int.Parse(label1.Text);
			}
			catch
			{
				label1.Text = "";
			}
			label1.Text += "0";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				aspettasionoperpartirefilm = false;
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	// EXTRA 2026-10-29: il vecchio "REC EXTRA" (canali extra) e' stato spostato
	// dentro la finestra CANALI (groupBox 'Opzioni Canali Extra'); questo tasto ora
	// apre il menu con le due funzionalita nuove: TROVA FILM e TRAILER SERATA.
	private void button17_Click(object sender, EventArgs e)
	{
		if (menuExtra == null)
		{
			menuExtra = new ContextMenuStrip();
			menuExtra.Items.Add("TROVA FILM", null, new EventHandler(this.buttonTrovaFilm_Click));
			menuExtra.Items.Add("TRAILER SERATA", null, new EventHandler(this.buttonTrailers_Click));
		}
		menuExtra.Show(button17, new Point(0, button17.Height));
	}

	// TROVA FILM 2026: apre la finestra di ricerca "dove vedo un film stasera"
	private void buttonTrovaFilm_Click(object sender, EventArgs e)
	{
		try
		{
			TrovaFilm trovaFilm = new TrovaFilm();
			trovaFilm.Show();
		}
		catch
		{
		}
	}

	private void buttonTrailers_Click(object sender, EventArgs e)
	{
		try
		{
			ApriTrailers().Show();
		}
		catch
		{
		}
	}

	// usata anche dal ControlServer (endpoint /trailershow): una sola finestra trailer,
	// se gia' aperta viene riattivata invece di riaprirne un'altra
	public SelettoreTrailers ApriTrailers()
	{
		if (winTrailers == null || winTrailers.IsDisposed)
		{
			winTrailers = new SelettoreTrailers();
		}
		return winTrailers;
	}

	private SelettoreTrailers winTrailers;

	private void button18_Click(object sender, EventArgs e)
	{
		try
		{
			MostraREC mostraREC = new MostraREC(dvreg, vlc);
			mostraREC.Show();
		}
		catch
		{
		}
	}

	private void button8_Click(object sender, EventArgs e)
	{
		Hide();
		notifyIcon1.Visible = true;
	}

	private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
	{
		Show();
		notifyIcon1.Visible = false;
	}

	private void button19_Click(object sender, EventArgs e)
	{
		if (panel1.Visible)
		{
			panel1.Visible = false;
			return;
		}
		optx = new Opzioni(this);
		optx.Show();
	}

	private void button20_Click(object sender, EventArgs e)
	{
		Ringraziamenti ringraziamenti = new Ringraziamenti();
		ringraziamenti.Show();
	}

	private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			// BONIFICA 2026: vecchio sito 2011 spento.
			MessageBox.Show("Il vecchio sito di TVOSA (2011) non esiste piu': il progetto e' riesumato nel 2026 su GitHub.");
		}
		catch
		{
		}
	}

	private void button21_Click(object sender, EventArgs e)
	{
		try
		{
			Televideo televideo = new Televideo();
			if (chattvosa)
			{
				televideo.settapg("http://chatroll.com/embed/chat/tvosa-chat?name=tvosa-chat");
				televideo.Text = "Chat TVOSA";
				televideo.MaximizeBox = true;
			}
			else
			{
				televideo.settapg("http://www.televideo.rai.it/televideo/pub/popupTelevideo.jsp?p=103&s=1&r=Nazionale&pagetocall=popupTelevideo.jsp");
				televideo.Text = "Televideo";
				televideo.MaximizeBox = false;
			}
			televideo.Show();
		}
		catch
		{
		}
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			// BONIFICA 2026: il vecchio sito dell'autore 2011 non esiste piu'.
			MessageBox.Show("Il vecchio sito di TVOSA (2011) non esiste piu': il progetto e' riesumato nel 2026 su GitHub.");
		}
		catch
		{
		}
	}

	private void Form1_MouseClick(object sender, MouseEventArgs e)
	{
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			// BONIFICA 2026: il download 2011 non esiste piu'.
			MessageBox.Show("TVOSA 2026 vive nel repository GitHub: non serve piu' il download da web.");
		}
		catch
		{
		}
	}

	public void LOG(string x)
	{
		try
		{
			if (File.Exists(Program.pr + "\\logattivati"))
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\log.txt", append: true);
				streamWriter.WriteLine(x);
				streamWriter.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	private void button22_Click(object sender, EventArgs e)
	{
		try
		{
			if (textBox1.Text == "22222")
			{
				File.Delete(Program.pr + "\\nvda");
				panel2.Visible = false;
				return;
			}
			if (textBox1.Text == "joint root")
			{
				root = true;
				File.Create(Program.pr + "\\logattivati");
			}
			// BONIFICA 2026: rimossi tre easter egg personali dell'autore 2011.
			else if (textBox1.Text == "TVOSA")
			{
				MessageBox.Show("Hint: se inserisci qui dentro un link ad un file e premi OK verra' scaricato automaticamente... per provare scarica la versione consigliata di vlc scrivendo qui \"vlc\"  ;)");
			}
			// BONIFICA 2026: rimossi gli easter egg 'pataka'/'joint ciccionema' che aprivano
			// la finestra di ricerca streaming pirata CercaStreamingF.
			else if (textBox1.Text == "vlc")
			{
				textBox1.Text = "https://www.videolan.org/vlc/download-windows.html";
			}
			if (textBox1.Text.IndexOf("http:") >= 0)
			{
				try
				{
					filedascaricare = textBox1.Text;
					ThreadCapo threadCapo = new ThreadCapo(this);
					Thread thread = new Thread(threadCapo.scaricafile);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
				}
				catch
				{
				}
			}
			int num = int.Parse(textBox1.Text);
			label1.Text = textBox1.Text;
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
			try
			{
				ThreadDbtele threadDbtele = new ThreadDbtele(this);
				TTXV = new Thread(threadDbtele.guardav);
				TTXV.IsBackground = true;
				TTXV.Priority = ThreadPriority.BelowNormal;
				TTXV.Start();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void textBox1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyData.ToString() == "Return")
		{
			button22_Click(sender, new EventArgs());
		}
	}

	private void button1_MouseHover(object sender, EventArgs e)
	{
		try
		{
			button1.BackgroundImage = Resources.rec_show3;
		}
		catch
		{
		}
	}

	private void button1_MouseDown(object sender, MouseEventArgs e)
	{
		button1.BackgroundImage = Resources.rec_show2;
	}

	private void button1_MouseUp(object sender, MouseEventArgs e)
	{
		button1.BackgroundImage = Resources.rec_show1;
	}

	private void button1_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button1.BackgroundImage = Resources.rec_show1;
		}
		catch
		{
		}
	}

	private void button8_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button8.BackgroundImage = Resources.icona2;
		}
		catch
		{
		}
	}

	private void button8_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button8.BackgroundImage = Resources.icona1;
		}
		catch
		{
		}
	}

	private void button17_MouseHover(object sender, EventArgs e)
	{
		try
		{
			button17.BackgroundImage = Resources.recExtra3;
		}
		catch
		{
		}
	}

	private void button17_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button17.BackgroundImage = Resources.rec_extra1;
		}
		catch
		{
		}
	}

	private void button17_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button17.BackgroundImage = Resources.recExtra2;
		}
		catch
		{
		}
	}

	private void button17_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button17.BackgroundImage = Resources.rec_extra1;
		}
		catch
		{
		}
	}

	private void button9_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button9.BackgroundImage = Resources.canali2;
		}
		catch
		{
		}
	}

	private void button9_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button9.BackgroundImage = Resources.canali1;
		}
		catch
		{
		}
	}

	private void button9_MouseHover(object sender, EventArgs e)
	{
		try
		{
			button9.BackgroundImage = Resources.canali3;
		}
		catch
		{
		}
	}

	private void button9_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button9.BackgroundImage = Resources.canali1;
		}
		catch
		{
		}
	}

	private void button19_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button19.BackgroundImage = Resources.opzioni;
		}
		catch
		{
		}
	}

	private void button19_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button19.BackgroundImage = Resources.opzioni1;
		}
		catch
		{
		}
	}

	private void button19_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button19.BackgroundImage = Resources.opzioni3;
		}
		catch
		{
		}
	}

	private void button19_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button19.BackgroundImage = Resources.opzioni1;
		}
		catch
		{
		}
	}

	private void button4_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button4.BackgroundImage = Resources.tasti1_2;
		}
		catch
		{
		}
	}

	private void button4_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button4.BackgroundImage = Resources.tasti1_1;
		}
		catch
		{
		}
	}

	private void button4_MouseHover(object sender, EventArgs e)
	{
	}

	private void button4_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button4.BackgroundImage = Resources.tasto1_3;
		}
		catch
		{
		}
	}

	private void button4_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button4.BackgroundImage = Resources.tasti1_1;
		}
		catch
		{
		}
	}

	private void button5_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button5.BackgroundImage = Resources.tasti2_2;
		}
		catch
		{
		}
	}

	private void button5_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button5.BackgroundImage = Resources.tasti2_1;
		}
		catch
		{
		}
	}

	private void button5_MouseHover(object sender, EventArgs e)
	{
		try
		{
			button5.BackgroundImage = Resources.tasto2_3;
		}
		catch
		{
		}
	}

	private void button5_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button5.BackgroundImage = Resources.tasti2_1;
		}
		catch
		{
		}
	}

	private void button7_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button7.BackgroundImage = Resources.tasti3_2;
		}
		catch
		{
		}
	}

	private void button7_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button7.BackgroundImage = Resources.tasti3_1;
		}
		catch
		{
		}
	}

	private void button7_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button7.BackgroundImage = Resources.tasto3_3;
		}
		catch
		{
		}
	}

	private void button7_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button7.BackgroundImage = Resources.tasti3_1;
		}
		catch
		{
		}
	}

	private void button10_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button10.BackgroundImage = Resources.tasti4_2;
		}
		catch
		{
		}
	}

	private void button10_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button10.BackgroundImage = Resources.tasti4_1;
		}
		catch
		{
		}
	}

	private void button10_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button10.BackgroundImage = Resources.tasto4_3;
		}
		catch
		{
		}
	}

	private void button10_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button10.BackgroundImage = Resources.tasti4_1;
		}
		catch
		{
		}
	}

	private void button11_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button11.BackgroundImage = Resources.tasti5_2;
		}
		catch
		{
		}
	}

	private void button11_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button11.BackgroundImage = Resources.tasti5_1;
		}
		catch
		{
		}
	}

	private void button11_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button11.BackgroundImage = Resources.tasto5_3;
		}
		catch
		{
		}
	}

	private void button11_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button11.BackgroundImage = Resources.tasti5_1;
		}
		catch
		{
		}
	}

	private void button12_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button12.BackgroundImage = Resources.tasti6_2;
		}
		catch
		{
		}
	}

	private void button12_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button12.BackgroundImage = Resources.tasti6_1;
		}
		catch
		{
		}
	}

	private void button12_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button12.BackgroundImage = Resources.tasto6_3;
		}
		catch
		{
		}
	}

	private void button12_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button12.BackgroundImage = Resources.tasti6_1;
		}
		catch
		{
		}
	}

	private void button13_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button13.BackgroundImage = Resources.tasti7_2;
		}
		catch
		{
		}
	}

	private void button13_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button13.BackgroundImage = Resources.tasti7_1;
		}
		catch
		{
		}
	}

	private void button13_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button13.BackgroundImage = Resources.tasto7_3;
		}
		catch
		{
		}
	}

	private void button13_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button13.BackgroundImage = Resources.tasti7_1;
		}
		catch
		{
		}
	}

	private void button14_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button14.BackgroundImage = Resources.tasti8_2;
		}
		catch
		{
		}
	}

	private void button14_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button14.BackgroundImage = Resources.tasti8_1;
		}
		catch
		{
		}
	}

	private void button14_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button14.BackgroundImage = Resources.tasto8_3;
		}
		catch
		{
		}
	}

	private void button14_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button14.BackgroundImage = Resources.tasti8_1;
		}
		catch
		{
		}
	}

	private void button15_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button15.BackgroundImage = Resources.tasti9_2;
		}
		catch
		{
		}
	}

	private void button15_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button15.BackgroundImage = Resources.tasti9_1;
		}
		catch
		{
		}
	}

	private void button15_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button15.BackgroundImage = Resources.tasto9_3;
		}
		catch
		{
		}
	}

	private void button15_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button15.BackgroundImage = Resources.tasti9_1;
		}
		catch
		{
		}
	}

	private void button16_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button16.BackgroundImage = Resources.tasti0_2;
		}
		catch
		{
		}
	}

	private void button16_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button16.BackgroundImage = Resources.tasti0_1;
		}
		catch
		{
		}
	}

	private void button16_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button16.BackgroundImage = Resources.tasto0_3;
		}
		catch
		{
		}
	}

	private void button16_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button16.BackgroundImage = Resources.tasti0_1;
		}
		catch
		{
		}
	}

	private void button20_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button20.BackgroundImage = Resources.i2;
		}
		catch
		{
		}
	}

	private void button20_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button20.BackgroundImage = Resources.i1;
		}
		catch
		{
		}
	}

	private void button20_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button20.BackgroundImage = Resources.i3;
		}
		catch
		{
		}
	}

	private void button20_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button20.BackgroundImage = Resources.i1;
		}
		catch
		{
		}
	}

	private void button21_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			button21.BackgroundImage = Resources.tasticnc_2;
		}
		catch
		{
		}
	}

	private void button21_MouseUp(object sender, MouseEventArgs e)
	{
		try
		{
			button21.BackgroundImage = Resources.tasticnc_1;
		}
		catch
		{
		}
	}

	private void button21_MouseEnter(object sender, EventArgs e)
	{
		try
		{
			button21.BackgroundImage = Resources.tastocnc_3;
		}
		catch
		{
		}
	}

	private void button21_MouseLeave(object sender, EventArgs e)
	{
		try
		{
			button21.BackgroundImage = Resources.tasticnc_1;
		}
		catch
		{
		}
	}

	private void label1_Click(object sender, EventArgs e)
	{
		try
		{
			int num = int.Parse(label1.Text);
			label1.Text = "";
			try
			{
				TTXV.Abort();
			}
			catch
			{
			}
		}
		catch (Exception)
		{
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		try
		{
			Zapping zapping = new Zapping(this);
			zapping.Show();
		}
		catch (Exception)
		{
		}
	}

	private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		docux = webBrowser1.DocumentText;
		if (webBrowser1.Url.ToString().IndexOf("movshare.") < 0)
		{
			return;
		}
		HtmlElementCollection all = webBrowser1.Document.All;
		for (int i = 0; i < all.Count; i++)
		{
			HtmlElement htmlElement = all[i];
			string tagName = htmlElement.TagName;
			if (tagName.ToLowerInvariant() == "form" && htmlElement.OuterHtml.IndexOf("id=watch") >= 0)
			{
				all[i].InvokeMember("submit");
			}
		}
	}

	private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
	}
}
