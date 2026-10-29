// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Properties;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class Telegiornali : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private PictureBox pictureBox2;

	private Label label3;

	private PictureBox pictureBox3;

	private Label label4;

	private PictureBox pictureBox4;

	private Label label5;

	private PictureBox pictureBox5;

	private Label label6;

	private PictureBox pictureBox6;

	private Label label7;

	private PictureBox pictureBox7;

	private Label label8;

	private PictureBox pictureBox8;

	private Label label9;

	private PictureBox pictureBox9;

	private Label label10;

	private PictureBox pictureBox10;

	private Label label11;

	private PictureBox pictureBox11;

	private Label label12;

	private PictureBox pictureBox12;

	private Label label13;

	private PictureBox pictureBox13;

	private Label label14;

	private PictureBox pictureBox14;

	private Label label15;

	private PictureBox pictureBox15;

	private Label label16;

	private PictureBox pictureBox16;

	private Label label17;

	private PictureBox pictureBox17;

	private Label label18;

	private PictureBox pictureBox18;

	private Label label19;

	private PictureBox pictureBox19;

	private Label label20;

	private PictureBox pictureBox20;

	private Label label21;

	private PictureBox pictureBox21;

	public Form1 mio;

	private Thread TTX;

	public string canaleteleg = "";

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Telegiornali));
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.label17 = new System.Windows.Forms.Label();
		this.label18 = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.label21 = new System.Windows.Forms.Label();
		this.pictureBox21 = new System.Windows.Forms.PictureBox();
		this.pictureBox17 = new System.Windows.Forms.PictureBox();
		this.pictureBox18 = new System.Windows.Forms.PictureBox();
		this.pictureBox19 = new System.Windows.Forms.PictureBox();
		this.pictureBox20 = new System.Windows.Forms.PictureBox();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.pictureBox12 = new System.Windows.Forms.PictureBox();
		this.pictureBox13 = new System.Windows.Forms.PictureBox();
		this.pictureBox14 = new System.Windows.Forms.PictureBox();
		this.pictureBox15 = new System.Windows.Forms.PictureBox();
		this.pictureBox16 = new System.Windows.Forms.PictureBox();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox21).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(34, 113);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(116, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Trentino Alto Adige";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(213, 113);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(97, 13);
		this.label2.TabIndex = 3;
		this.label2.Text = "Emilia Romagna";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(410, 544);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(41, 13);
		this.label3.TabIndex = 5;
		this.label3.Text = "Sicilia";
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(592, 113);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(37, 13);
		this.label4.TabIndex = 7;
		this.label4.Text = "Lazio";
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(34, 258);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(119, 13);
		this.label5.TabIndex = 9;
		this.label5.Text = "Friuli-Venezia Giulia";
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(231, 258);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(61, 13);
		this.label6.TabIndex = 11;
		this.label6.Text = "Sardegna";
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(405, 683);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(46, 13);
		this.label7.TabIndex = 13;
		this.label7.Text = "Umbria";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.Location = new System.Drawing.Point(582, 258);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(62, 13);
		this.label8.TabIndex = 15;
		this.label8.Text = "Basilicata";
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(582, 544);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(43, 13);
		this.label9.TabIndex = 31;
		this.label9.Text = "Molise";
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label10.Location = new System.Drawing.Point(410, 113);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(47, 13);
		this.label10.TabIndex = 29;
		this.label10.Text = "Veneto";
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.Location = new System.Drawing.Point(231, 544);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(61, 13);
		this.label11.TabIndex = 27;
		this.label11.Text = "Sardegna";
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label12.Location = new System.Drawing.Point(58, 544);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(62, 13);
		this.label12.TabIndex = 25;
		this.label12.Text = "Campania";
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.Location = new System.Drawing.Point(586, 399);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(45, 13);
		this.label13.TabIndex = 23;
		this.label13.Text = "Liguria";
		this.label14.AutoSize = true;
		this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label14.Location = new System.Drawing.Point(414, 399);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(42, 13);
		this.label14.TabIndex = 21;
		this.label14.Text = "Puglia";
		this.label15.AutoSize = true;
		this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label15.Location = new System.Drawing.Point(231, 399);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(53, 13);
		this.label15.TabIndex = 19;
		this.label15.Text = "Calabria";
		this.label16.AutoSize = true;
		this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label16.Location = new System.Drawing.Point(58, 399);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(56, 13);
		this.label16.TabIndex = 17;
		this.label16.Text = "Toscana";
		this.label17.AutoSize = true;
		this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label17.Location = new System.Drawing.Point(582, 683);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(59, 13);
		this.label17.TabIndex = 40;
		this.label17.Text = "Piemonte";
		this.label18.AutoSize = true;
		this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label18.Location = new System.Drawing.Point(397, 258);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(65, 13);
		this.label18.TabIndex = 38;
		this.label18.Text = "Lombardia";
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label19.Location = new System.Drawing.Point(231, 683);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(49, 13);
		this.label19.TabIndex = 36;
		this.label19.Text = "Marche";
		this.label20.AutoSize = true;
		this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label20.Location = new System.Drawing.Point(58, 683);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(52, 13);
		this.label20.TabIndex = 34;
		this.label20.Text = "Abruzzo";
		this.label21.AutoSize = true;
		this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label21.Location = new System.Drawing.Point(39, 822);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(87, 13);
		this.label21.TabIndex = 42;
		this.label21.Text = "Valle D' Aosta";
		this.pictureBox21.Image = ZeroItaTV.Properties.Resources.PIEMONTE;
		this.pictureBox21.Location = new System.Drawing.Point(22, 721);
		this.pictureBox21.Name = "pictureBox21";
		this.pictureBox21.Size = new System.Drawing.Size(123, 97);
		this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox21.TabIndex = 41;
		this.pictureBox21.TabStop = false;
		this.pictureBox21.Click += new System.EventHandler(this.pictureBox21_Click);
		this.pictureBox17.Image = ZeroItaTV.Properties.Resources.PIEMONTE;
		this.pictureBox17.Location = new System.Drawing.Point(546, 582);
		this.pictureBox17.Name = "pictureBox17";
		this.pictureBox17.Size = new System.Drawing.Size(123, 97);
		this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox17.TabIndex = 39;
		this.pictureBox17.TabStop = false;
		this.pictureBox17.Click += new System.EventHandler(this.pictureBox17_Click);
		this.pictureBox18.Image = ZeroItaTV.Properties.Resources.LOMBARDIA;
		this.pictureBox18.Location = new System.Drawing.Point(370, 157);
		this.pictureBox18.Name = "pictureBox18";
		this.pictureBox18.Size = new System.Drawing.Size(123, 97);
		this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox18.TabIndex = 37;
		this.pictureBox18.TabStop = false;
		this.pictureBox18.Click += new System.EventHandler(this.pictureBox18_Click);
		this.pictureBox19.Image = ZeroItaTV.Properties.Resources.MARCHE_e_SAN_MARINO;
		this.pictureBox19.Location = new System.Drawing.Point(194, 582);
		this.pictureBox19.Name = "pictureBox19";
		this.pictureBox19.Size = new System.Drawing.Size(123, 97);
		this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox19.TabIndex = 35;
		this.pictureBox19.TabStop = false;
		this.pictureBox19.Click += new System.EventHandler(this.pictureBox19_Click);
		this.pictureBox20.Image = ZeroItaTV.Properties.Resources.ABRUZZO_e_MOLISE;
		this.pictureBox20.Location = new System.Drawing.Point(22, 582);
		this.pictureBox20.Name = "pictureBox20";
		this.pictureBox20.Size = new System.Drawing.Size(123, 97);
		this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox20.TabIndex = 33;
		this.pictureBox20.TabStop = false;
		this.pictureBox20.Click += new System.EventHandler(this.pictureBox20_Click);
		this.pictureBox9.Image = ZeroItaTV.Properties.Resources.ABRUZZO_e_MOLISE;
		this.pictureBox9.Location = new System.Drawing.Point(546, 443);
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.Size = new System.Drawing.Size(123, 97);
		this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox9.TabIndex = 30;
		this.pictureBox9.TabStop = false;
		this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
		this.pictureBox10.Image = ZeroItaTV.Properties.Resources.VENETO;
		this.pictureBox10.Location = new System.Drawing.Point(370, 12);
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.Size = new System.Drawing.Size(123, 97);
		this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox10.TabIndex = 28;
		this.pictureBox10.TabStop = false;
		this.pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
		this.pictureBox11.Image = ZeroItaTV.Properties.Resources.SARDEGNA;
		this.pictureBox11.Location = new System.Drawing.Point(194, 443);
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.Size = new System.Drawing.Size(123, 97);
		this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox11.TabIndex = 26;
		this.pictureBox11.TabStop = false;
		this.pictureBox11.Click += new System.EventHandler(this.pictureBox11_Click);
		this.pictureBox12.Image = ZeroItaTV.Properties.Resources.CAMPANIA;
		this.pictureBox12.Location = new System.Drawing.Point(22, 443);
		this.pictureBox12.Name = "pictureBox12";
		this.pictureBox12.Size = new System.Drawing.Size(123, 97);
		this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox12.TabIndex = 24;
		this.pictureBox12.TabStop = false;
		this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
		this.pictureBox13.Image = ZeroItaTV.Properties.Resources.LIGURIA;
		this.pictureBox13.Location = new System.Drawing.Point(546, 298);
		this.pictureBox13.Name = "pictureBox13";
		this.pictureBox13.Size = new System.Drawing.Size(123, 97);
		this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox13.TabIndex = 22;
		this.pictureBox13.TabStop = false;
		this.pictureBox13.Click += new System.EventHandler(this.pictureBox13_Click);
		this.pictureBox14.Image = ZeroItaTV.Properties.Resources.PUGLIA;
		this.pictureBox14.Location = new System.Drawing.Point(370, 298);
		this.pictureBox14.Name = "pictureBox14";
		this.pictureBox14.Size = new System.Drawing.Size(123, 97);
		this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox14.TabIndex = 20;
		this.pictureBox14.TabStop = false;
		this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
		this.pictureBox15.Image = ZeroItaTV.Properties.Resources.CALABRIA;
		this.pictureBox15.Location = new System.Drawing.Point(194, 298);
		this.pictureBox15.Name = "pictureBox15";
		this.pictureBox15.Size = new System.Drawing.Size(123, 97);
		this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox15.TabIndex = 18;
		this.pictureBox15.TabStop = false;
		this.pictureBox15.Click += new System.EventHandler(this.pictureBox15_Click);
		this.pictureBox16.Image = ZeroItaTV.Properties.Resources.TOSCANA;
		this.pictureBox16.Location = new System.Drawing.Point(22, 298);
		this.pictureBox16.Name = "pictureBox16";
		this.pictureBox16.Size = new System.Drawing.Size(123, 97);
		this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox16.TabIndex = 16;
		this.pictureBox16.TabStop = false;
		this.pictureBox16.Click += new System.EventHandler(this.pictureBox16_Click);
		this.pictureBox8.Image = ZeroItaTV.Properties.Resources.BASILICATA;
		this.pictureBox8.Location = new System.Drawing.Point(546, 157);
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.Size = new System.Drawing.Size(123, 97);
		this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox8.TabIndex = 14;
		this.pictureBox8.TabStop = false;
		this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
		this.pictureBox7.Image = ZeroItaTV.Properties.Resources.UMBRIA;
		this.pictureBox7.Location = new System.Drawing.Point(370, 583);
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.Size = new System.Drawing.Size(123, 97);
		this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox7.TabIndex = 12;
		this.pictureBox7.TabStop = false;
		this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
		this.pictureBox6.Image = ZeroItaTV.Properties.Resources.SARDEGNA;
		this.pictureBox6.Location = new System.Drawing.Point(194, 157);
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.Size = new System.Drawing.Size(123, 97);
		this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox6.TabIndex = 10;
		this.pictureBox6.TabStop = false;
		this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
		this.pictureBox5.Image = ZeroItaTV.Properties.Resources.FRIULI_VENEZIA_GIULIA;
		this.pictureBox5.Location = new System.Drawing.Point(22, 157);
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.Size = new System.Drawing.Size(123, 97);
		this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox5.TabIndex = 8;
		this.pictureBox5.TabStop = false;
		this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
		this.pictureBox4.Image = ZeroItaTV.Properties.Resources.LAZIO;
		this.pictureBox4.Location = new System.Drawing.Point(546, 12);
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.Size = new System.Drawing.Size(123, 97);
		this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox4.TabIndex = 6;
		this.pictureBox4.TabStop = false;
		this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
		this.pictureBox3.Image = ZeroItaTV.Properties.Resources.SICILIA;
		this.pictureBox3.Location = new System.Drawing.Point(370, 443);
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.Size = new System.Drawing.Size(123, 97);
		this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox3.TabIndex = 4;
		this.pictureBox3.TabStop = false;
		this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
		this.pictureBox2.Image = ZeroItaTV.Properties.Resources.EMILIA_ROMAGNA;
		this.pictureBox2.Location = new System.Drawing.Point(194, 12);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(123, 97);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox2.TabIndex = 2;
		this.pictureBox2.TabStop = false;
		this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
		this.pictureBox1.Image = ZeroItaTV.Properties.Resources.TRENTINO___ALTO_ADIGE;
		this.pictureBox1.Location = new System.Drawing.Point(22, 12);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(123, 97);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoScroll = true;
		base.ClientSize = new System.Drawing.Size(701, 571);
		base.Controls.Add(this.label21);
		base.Controls.Add(this.pictureBox21);
		base.Controls.Add(this.label17);
		base.Controls.Add(this.pictureBox17);
		base.Controls.Add(this.label18);
		base.Controls.Add(this.pictureBox18);
		base.Controls.Add(this.label19);
		base.Controls.Add(this.pictureBox19);
		base.Controls.Add(this.label20);
		base.Controls.Add(this.pictureBox20);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.pictureBox9);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.pictureBox10);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.pictureBox11);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.pictureBox12);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.pictureBox13);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.pictureBox14);
		base.Controls.Add(this.label15);
		base.Controls.Add(this.pictureBox15);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.pictureBox16);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.pictureBox8);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Telegiornali";
		this.Text = "Telegiornali Regionali Oggi ";
		base.Load += new System.EventHandler(this.Telegiornali_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox21).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public Telegiornali(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	private void Telegiornali_Load(object sender, EventArgs e)
	{
	}

	private void particanale()
	{
		try
		{
			TTX.Abort();
		}
		catch
		{
		}
		try
		{
			ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(this);
			TTX = new Thread(threadSimileAltriCanali.particanaleteleg);
			TTX.IsBackground = true;
			TTX.Priority = ThreadPriority.BelowNormal;
			TTX.Start();
		}
		catch
		{
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^trentino.html";
		particanale();
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^emiliaromagna.html";
		particanale();
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^sicilia.html";
		particanale();
	}

	private void pictureBox4_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^lazio.html";
		particanale();
	}

	private void pictureBox5_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^friuli.html";
		particanale();
	}

	private void pictureBox6_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^sardegna.html";
		particanale();
	}

	private void pictureBox7_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^umbria.html";
		particanale();
	}

	private void pictureBox16_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^umbria.html";
		particanale();
	}

	private void pictureBox10_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^veneto.html";
		particanale();
	}

	private void pictureBox18_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^lombardia.html";
		particanale();
	}

	private void pictureBox8_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^basilicata.html";
		particanale();
	}

	private void pictureBox15_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^calabria.html";
		particanale();
	}

	private void pictureBox14_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^puglia.html";
		particanale();
	}

	private void pictureBox13_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^liguria.html";
		particanale();
	}

	private void pictureBox12_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^campania.html";
		particanale();
	}

	private void pictureBox11_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^sardegna.html";
		particanale();
	}

	private void pictureBox9_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^molise.html";
		particanale();
	}

	private void pictureBox20_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^abruzzo.html";
		particanale();
	}

	private void pictureBox19_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^marche.html";
		particanale();
	}

	private void pictureBox17_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^piemonte.html";
		particanale();
	}

	private void pictureBox21_Click(object sender, EventArgs e)
	{
		canaleteleg = "http://www.tgr.rai.it/SITOTG/TGR_popupvideo/1,8506,tgr^valdaosta.html";
		particanale();
	}
}
