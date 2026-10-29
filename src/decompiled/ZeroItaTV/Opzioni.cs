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

public class Opzioni : Form
{
	private IContainer components = null;

	private GroupBox groupBox1;

	private Panel panel4;

	private Panel panel5;

	private Label label6;

	private RadioButton radioButton9;

	private RadioButton radioButton10;

	private Label label5;

	private RadioButton radioButton7;

	private RadioButton radioButton8;

	private Panel panel3;

	private Label label4;

	private RadioButton radioButton5;

	private RadioButton radioButton6;

	private Panel panel2;

	private Label label3;

	private RadioButton radioButton3;

	private RadioButton radioButton4;

	private Label label2;

	private Panel panel1;

	private Label label1;

	private RadioButton radioButton2;

	private RadioButton radioButton1;

	private CheckBox checkBox1;

	private Panel panel8;

	private Label label9;

	private RadioButton radioButton15;

	private RadioButton radioButton16;

	private Panel panel7;

	private Label label8;

	private RadioButton radioButton13;

	private RadioButton radioButton14;

	private Panel panel6;

	private Label label7;

	private RadioButton radioButton11;

	private RadioButton radioButton12;

	private Panel panel11;

	private Label label12;

	private RadioButton radioButton21;

	private RadioButton radioButton22;

	private Panel panel10;

	private Label label11;

	private RadioButton radioButton19;

	private RadioButton radioButton20;

	private Panel panel9;

	private Label label10;

	private RadioButton radioButton17;

	private RadioButton radioButton18;

	private Panel panel14;

	private Label label15;

	private RadioButton radioButton27;

	private RadioButton radioButton28;

	private Panel panel13;

	private Label label14;

	private RadioButton radioButton25;

	private RadioButton radioButton26;

	private Panel panel12;

	private Label label13;

	private RadioButton radioButton23;

	private RadioButton radioButton24;

	private Button button1;

	private Button button2;

	private RadioButton radioButton33;

	private RadioButton radioButton32;

	private RadioButton radioButton31;

	private RadioButton radioButton30;

	private RadioButton radioButton29;

	private RadioButton radioButton39;

	private RadioButton radioButton38;

	private RadioButton radioButton37;

	private RadioButton radioButton36;

	private RadioButton radioButton35;

	private RadioButton radioButton34;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private GroupBox groupBox2;

	private Label label17;

	private ComboBox comboBox1;

	private Button button3;

	private Button button4;

	private GroupBox groupBox3;

	private Label label18;

	private ListBox listBox1;

	private Button button5;

	private GroupBox groupBox4;

	private Button button6;

	private CheckBox checkBox2;

	private GroupBox groupBox5;

	private Button button8;

	private Button button7;

	private ComboBox comboBox2;

	private Label label19;

	private TabPage tabPage3;

	private GroupBox groupBox8;

	private CheckBox checkBox6;

	public ProgressBar progressBar3;

	private GroupBox groupBox7;

	private Button button17;

	private Button button15;

	private Button button16;

	private CheckBox checkBox5;

	private Button button12;

	public ProgressBar progressBar2;

	private Button button13;

	private Button button14;

	private CheckBox checkBox7;

	public CheckBox checkBox8;

	private GroupBox groupBox9;

	private CheckBox checkBox3;

	private GroupBox groupBox6;

	private RadioButton radioButton41;

	private RadioButton radioButton40;

	private Panel panel15;

	private RadioButton radioButton42;

	private Label label16;

	private RadioButton radioButton43;

	private RadioButton radioButton44;

	private LinkLabel linkLabel1;

	private Label label20;

	private Button button9;

	private CheckBox checkBox4;

	private GroupBox groupBox10;

	private Button button10;

	private Panel panel16;

	private RadioButton radioButton45;

	private Label label21;

	private RadioButton radioButton46;

	private RadioButton radioButton47;

	private Thread TTXX;

	private Thread TTXVPALX;

	public Form1 mio;

	private string linkautor = "";

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.Opzioni));
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.panel15 = new System.Windows.Forms.Panel();
		this.radioButton42 = new System.Windows.Forms.RadioButton();
		this.label16 = new System.Windows.Forms.Label();
		this.radioButton43 = new System.Windows.Forms.RadioButton();
		this.radioButton44 = new System.Windows.Forms.RadioButton();
		this.panel14 = new System.Windows.Forms.Panel();
		this.radioButton39 = new System.Windows.Forms.RadioButton();
		this.label15 = new System.Windows.Forms.Label();
		this.radioButton27 = new System.Windows.Forms.RadioButton();
		this.radioButton28 = new System.Windows.Forms.RadioButton();
		this.panel13 = new System.Windows.Forms.Panel();
		this.radioButton38 = new System.Windows.Forms.RadioButton();
		this.label14 = new System.Windows.Forms.Label();
		this.radioButton25 = new System.Windows.Forms.RadioButton();
		this.radioButton26 = new System.Windows.Forms.RadioButton();
		this.panel12 = new System.Windows.Forms.Panel();
		this.radioButton37 = new System.Windows.Forms.RadioButton();
		this.label13 = new System.Windows.Forms.Label();
		this.radioButton23 = new System.Windows.Forms.RadioButton();
		this.radioButton24 = new System.Windows.Forms.RadioButton();
		this.panel11 = new System.Windows.Forms.Panel();
		this.radioButton36 = new System.Windows.Forms.RadioButton();
		this.label12 = new System.Windows.Forms.Label();
		this.radioButton21 = new System.Windows.Forms.RadioButton();
		this.radioButton22 = new System.Windows.Forms.RadioButton();
		this.panel10 = new System.Windows.Forms.Panel();
		this.radioButton35 = new System.Windows.Forms.RadioButton();
		this.label11 = new System.Windows.Forms.Label();
		this.radioButton19 = new System.Windows.Forms.RadioButton();
		this.radioButton20 = new System.Windows.Forms.RadioButton();
		this.panel9 = new System.Windows.Forms.Panel();
		this.radioButton34 = new System.Windows.Forms.RadioButton();
		this.label10 = new System.Windows.Forms.Label();
		this.radioButton17 = new System.Windows.Forms.RadioButton();
		this.radioButton18 = new System.Windows.Forms.RadioButton();
		this.panel8 = new System.Windows.Forms.Panel();
		this.radioButton33 = new System.Windows.Forms.RadioButton();
		this.label9 = new System.Windows.Forms.Label();
		this.radioButton15 = new System.Windows.Forms.RadioButton();
		this.radioButton16 = new System.Windows.Forms.RadioButton();
		this.panel7 = new System.Windows.Forms.Panel();
		this.radioButton32 = new System.Windows.Forms.RadioButton();
		this.label8 = new System.Windows.Forms.Label();
		this.radioButton13 = new System.Windows.Forms.RadioButton();
		this.radioButton14 = new System.Windows.Forms.RadioButton();
		this.panel6 = new System.Windows.Forms.Panel();
		this.label7 = new System.Windows.Forms.Label();
		this.radioButton11 = new System.Windows.Forms.RadioButton();
		this.radioButton12 = new System.Windows.Forms.RadioButton();
		this.panel5 = new System.Windows.Forms.Panel();
		this.label6 = new System.Windows.Forms.Label();
		this.radioButton9 = new System.Windows.Forms.RadioButton();
		this.radioButton10 = new System.Windows.Forms.RadioButton();
		this.panel4 = new System.Windows.Forms.Panel();
		this.label5 = new System.Windows.Forms.Label();
		this.radioButton7 = new System.Windows.Forms.RadioButton();
		this.radioButton8 = new System.Windows.Forms.RadioButton();
		this.panel3 = new System.Windows.Forms.Panel();
		this.radioButton31 = new System.Windows.Forms.RadioButton();
		this.label4 = new System.Windows.Forms.Label();
		this.radioButton5 = new System.Windows.Forms.RadioButton();
		this.radioButton6 = new System.Windows.Forms.RadioButton();
		this.panel2 = new System.Windows.Forms.Panel();
		this.radioButton30 = new System.Windows.Forms.RadioButton();
		this.label3 = new System.Windows.Forms.Label();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.radioButton4 = new System.Windows.Forms.RadioButton();
		this.label2 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.radioButton29 = new System.Windows.Forms.RadioButton();
		this.label1 = new System.Windows.Forms.Label();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.button9 = new System.Windows.Forms.Button();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.label20 = new System.Windows.Forms.Label();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.radioButton41 = new System.Windows.Forms.RadioButton();
		this.radioButton40 = new System.Windows.Forms.RadioButton();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.label19 = new System.Windows.Forms.Label();
		this.button8 = new System.Windows.Forms.Button();
		this.button7 = new System.Windows.Forms.Button();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.button5 = new System.Windows.Forms.Button();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.button6 = new System.Windows.Forms.Button();
		this.label17 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.button4 = new System.Windows.Forms.Button();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.label18 = new System.Windows.Forms.Label();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.button3 = new System.Windows.Forms.Button();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.groupBox10 = new System.Windows.Forms.GroupBox();
		this.button10 = new System.Windows.Forms.Button();
		this.groupBox9 = new System.Windows.Forms.GroupBox();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.checkBox8 = new System.Windows.Forms.CheckBox();
		this.groupBox8 = new System.Windows.Forms.GroupBox();
		this.checkBox7 = new System.Windows.Forms.CheckBox();
		this.button16 = new System.Windows.Forms.Button();
		this.button15 = new System.Windows.Forms.Button();
		this.groupBox7 = new System.Windows.Forms.GroupBox();
		this.checkBox6 = new System.Windows.Forms.CheckBox();
		this.button17 = new System.Windows.Forms.Button();
		this.progressBar3 = new System.Windows.Forms.ProgressBar();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.button12 = new System.Windows.Forms.Button();
		this.progressBar2 = new System.Windows.Forms.ProgressBar();
		this.button13 = new System.Windows.Forms.Button();
		this.button14 = new System.Windows.Forms.Button();
		this.panel16 = new System.Windows.Forms.Panel();
		this.radioButton45 = new System.Windows.Forms.RadioButton();
		this.label21 = new System.Windows.Forms.Label();
		this.radioButton46 = new System.Windows.Forms.RadioButton();
		this.radioButton47 = new System.Windows.Forms.RadioButton();
		this.groupBox1.SuspendLayout();
		this.panel15.SuspendLayout();
		this.panel14.SuspendLayout();
		this.panel13.SuspendLayout();
		this.panel12.SuspendLayout();
		this.panel11.SuspendLayout();
		this.panel10.SuspendLayout();
		this.panel9.SuspendLayout();
		this.panel8.SuspendLayout();
		this.panel7.SuspendLayout();
		this.panel6.SuspendLayout();
		this.panel5.SuspendLayout();
		this.panel4.SuspendLayout();
		this.panel3.SuspendLayout();
		this.panel2.SuspendLayout();
		this.panel1.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.tabPage3.SuspendLayout();
		this.groupBox10.SuspendLayout();
		this.groupBox9.SuspendLayout();
		this.groupBox8.SuspendLayout();
		this.groupBox7.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.panel16.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.panel16);
		this.groupBox1.Controls.Add(this.panel15);
		this.groupBox1.Controls.Add(this.panel14);
		this.groupBox1.Controls.Add(this.panel13);
		this.groupBox1.Controls.Add(this.panel12);
		this.groupBox1.Controls.Add(this.panel11);
		this.groupBox1.Controls.Add(this.panel10);
		this.groupBox1.Controls.Add(this.panel9);
		this.groupBox1.Controls.Add(this.panel8);
		this.groupBox1.Controls.Add(this.panel7);
		this.groupBox1.Controls.Add(this.panel6);
		this.groupBox1.Controls.Add(this.panel5);
		this.groupBox1.Controls.Add(this.panel4);
		this.groupBox1.Controls.Add(this.panel3);
		this.groupBox1.Controls.Add(this.panel2);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.panel1);
		this.groupBox1.Location = new System.Drawing.Point(8, 65);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(508, 511);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Opzioni Visualizzazione Canali";
		this.panel15.Controls.Add(this.radioButton42);
		this.panel15.Controls.Add(this.label16);
		this.panel15.Controls.Add(this.radioButton43);
		this.panel15.Controls.Add(this.radioButton44);
		this.panel15.Location = new System.Drawing.Point(6, 454);
		this.panel15.Name = "panel15";
		this.panel15.Size = new System.Drawing.Size(243, 48);
		this.panel15.TabIndex = 7;
		this.radioButton42.AutoSize = true;
		this.radioButton42.Location = new System.Drawing.Point(187, 14);
		this.radioButton42.Name = "radioButton42";
		this.radioButton42.Size = new System.Drawing.Size(53, 17);
		this.radioButton42.TabIndex = 6;
		this.radioButton42.TabStop = true;
		this.radioButton42.Text = "RVLC";
		this.radioButton42.UseVisualStyleBackColor = true;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(3, 18);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(80, 13);
		this.label16.TabIndex = 2;
		this.label16.Text = "RAISPORT 2 +";
		this.radioButton43.AutoSize = true;
		this.radioButton43.Location = new System.Drawing.Point(88, 14);
		this.radioButton43.Name = "radioButton43";
		this.radioButton43.Size = new System.Drawing.Size(45, 17);
		this.radioButton43.TabIndex = 1;
		this.radioButton43.TabStop = true;
		this.radioButton43.Text = "VLC";
		this.radioButton43.UseVisualStyleBackColor = true;
		this.radioButton44.AutoSize = true;
		this.radioButton44.Location = new System.Drawing.Point(139, 14);
		this.radioButton44.Name = "radioButton44";
		this.radioButton44.Size = new System.Drawing.Size(48, 17);
		this.radioButton44.TabIndex = 0;
		this.radioButton44.TabStop = true;
		this.radioButton44.Text = "Web";
		this.radioButton44.UseVisualStyleBackColor = true;
		this.panel14.Controls.Add(this.radioButton39);
		this.panel14.Controls.Add(this.label15);
		this.panel14.Controls.Add(this.radioButton27);
		this.panel14.Controls.Add(this.radioButton28);
		this.panel14.Location = new System.Drawing.Point(255, 400);
		this.panel14.Name = "panel14";
		this.panel14.Size = new System.Drawing.Size(246, 48);
		this.panel14.TabIndex = 11;
		this.radioButton39.AutoSize = true;
		this.radioButton39.Location = new System.Drawing.Point(190, 14);
		this.radioButton39.Name = "radioButton39";
		this.radioButton39.Size = new System.Drawing.Size(53, 17);
		this.radioButton39.TabIndex = 4;
		this.radioButton39.TabStop = true;
		this.radioButton39.Text = "RVLC";
		this.radioButton39.UseVisualStyleBackColor = true;
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(3, 18);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(34, 13);
		this.label15.TabIndex = 2;
		this.label15.Text = "RAI 4";
		this.radioButton27.AutoSize = true;
		this.radioButton27.Location = new System.Drawing.Point(93, 14);
		this.radioButton27.Name = "radioButton27";
		this.radioButton27.Size = new System.Drawing.Size(45, 17);
		this.radioButton27.TabIndex = 1;
		this.radioButton27.TabStop = true;
		this.radioButton27.Text = "VLC";
		this.radioButton27.UseVisualStyleBackColor = true;
		this.radioButton28.AutoSize = true;
		this.radioButton28.Location = new System.Drawing.Point(144, 14);
		this.radioButton28.Name = "radioButton28";
		this.radioButton28.Size = new System.Drawing.Size(48, 17);
		this.radioButton28.TabIndex = 0;
		this.radioButton28.TabStop = true;
		this.radioButton28.Text = "Web";
		this.radioButton28.UseVisualStyleBackColor = true;
		this.panel13.Controls.Add(this.radioButton38);
		this.panel13.Controls.Add(this.label14);
		this.panel13.Controls.Add(this.radioButton25);
		this.panel13.Controls.Add(this.radioButton26);
		this.panel13.Location = new System.Drawing.Point(255, 346);
		this.panel13.Name = "panel13";
		this.panel13.Size = new System.Drawing.Size(246, 48);
		this.panel13.TabIndex = 10;
		this.radioButton38.AutoSize = true;
		this.radioButton38.Location = new System.Drawing.Point(190, 14);
		this.radioButton38.Name = "radioButton38";
		this.radioButton38.Size = new System.Drawing.Size(53, 17);
		this.radioButton38.TabIndex = 4;
		this.radioButton38.TabStop = true;
		this.radioButton38.Text = "RVLC";
		this.radioButton38.UseVisualStyleBackColor = true;
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(3, 18);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(88, 13);
		this.label14.TabIndex = 2;
		this.label14.Text = "RAI SAT EXTRA";
		this.radioButton25.AutoSize = true;
		this.radioButton25.Location = new System.Drawing.Point(93, 14);
		this.radioButton25.Name = "radioButton25";
		this.radioButton25.Size = new System.Drawing.Size(45, 17);
		this.radioButton25.TabIndex = 1;
		this.radioButton25.TabStop = true;
		this.radioButton25.Text = "VLC";
		this.radioButton25.UseVisualStyleBackColor = true;
		this.radioButton26.AutoSize = true;
		this.radioButton26.Location = new System.Drawing.Point(144, 14);
		this.radioButton26.Name = "radioButton26";
		this.radioButton26.Size = new System.Drawing.Size(48, 17);
		this.radioButton26.TabIndex = 0;
		this.radioButton26.TabStop = true;
		this.radioButton26.Text = "Web";
		this.radioButton26.UseVisualStyleBackColor = true;
		this.panel12.Controls.Add(this.radioButton37);
		this.panel12.Controls.Add(this.label13);
		this.panel12.Controls.Add(this.radioButton23);
		this.panel12.Controls.Add(this.radioButton24);
		this.panel12.Location = new System.Drawing.Point(255, 292);
		this.panel12.Name = "panel12";
		this.panel12.Size = new System.Drawing.Size(246, 48);
		this.panel12.TabIndex = 9;
		this.radioButton37.AutoSize = true;
		this.radioButton37.Location = new System.Drawing.Point(190, 14);
		this.radioButton37.Name = "radioButton37";
		this.radioButton37.Size = new System.Drawing.Size(53, 17);
		this.radioButton37.TabIndex = 4;
		this.radioButton37.TabStop = true;
		this.radioButton37.Text = "RVLC";
		this.radioButton37.UseVisualStyleBackColor = true;
		this.label13.AutoSize = true;
		this.label13.Location = new System.Drawing.Point(3, 18);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(58, 13);
		this.label13.TabIndex = 2;
		this.label13.Text = "RAI YOYO";
		this.radioButton23.AutoSize = true;
		this.radioButton23.Location = new System.Drawing.Point(93, 14);
		this.radioButton23.Name = "radioButton23";
		this.radioButton23.Size = new System.Drawing.Size(45, 17);
		this.radioButton23.TabIndex = 1;
		this.radioButton23.TabStop = true;
		this.radioButton23.Text = "VLC";
		this.radioButton23.UseVisualStyleBackColor = true;
		this.radioButton24.AutoSize = true;
		this.radioButton24.Location = new System.Drawing.Point(144, 14);
		this.radioButton24.Name = "radioButton24";
		this.radioButton24.Size = new System.Drawing.Size(48, 17);
		this.radioButton24.TabIndex = 0;
		this.radioButton24.TabStop = true;
		this.radioButton24.Text = "Web";
		this.radioButton24.UseVisualStyleBackColor = true;
		this.panel11.Controls.Add(this.radioButton36);
		this.panel11.Controls.Add(this.label12);
		this.panel11.Controls.Add(this.radioButton21);
		this.panel11.Controls.Add(this.radioButton22);
		this.panel11.Location = new System.Drawing.Point(255, 238);
		this.panel11.Name = "panel11";
		this.panel11.Size = new System.Drawing.Size(246, 48);
		this.panel11.TabIndex = 8;
		this.radioButton36.AutoSize = true;
		this.radioButton36.Location = new System.Drawing.Point(190, 14);
		this.radioButton36.Name = "radioButton36";
		this.radioButton36.Size = new System.Drawing.Size(53, 17);
		this.radioButton36.TabIndex = 5;
		this.radioButton36.TabStop = true;
		this.radioButton36.Text = "RVLC";
		this.radioButton36.UseVisualStyleBackColor = true;
		this.label12.AutoSize = true;
		this.label12.Location = new System.Drawing.Point(3, 18);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(57, 13);
		this.label12.TabIndex = 2;
		this.label12.Text = "RAI GULP";
		this.radioButton21.AutoSize = true;
		this.radioButton21.Location = new System.Drawing.Point(93, 14);
		this.radioButton21.Name = "radioButton21";
		this.radioButton21.Size = new System.Drawing.Size(45, 17);
		this.radioButton21.TabIndex = 1;
		this.radioButton21.TabStop = true;
		this.radioButton21.Text = "VLC";
		this.radioButton21.UseVisualStyleBackColor = true;
		this.radioButton22.AutoSize = true;
		this.radioButton22.Location = new System.Drawing.Point(144, 14);
		this.radioButton22.Name = "radioButton22";
		this.radioButton22.Size = new System.Drawing.Size(48, 17);
		this.radioButton22.TabIndex = 0;
		this.radioButton22.TabStop = true;
		this.radioButton22.Text = "Web";
		this.radioButton22.UseVisualStyleBackColor = true;
		this.panel10.Controls.Add(this.radioButton35);
		this.panel10.Controls.Add(this.label11);
		this.panel10.Controls.Add(this.radioButton19);
		this.panel10.Controls.Add(this.radioButton20);
		this.panel10.Location = new System.Drawing.Point(255, 184);
		this.panel10.Name = "panel10";
		this.panel10.Size = new System.Drawing.Size(246, 48);
		this.panel10.TabIndex = 7;
		this.radioButton35.AutoSize = true;
		this.radioButton35.Location = new System.Drawing.Point(190, 14);
		this.radioButton35.Name = "radioButton35";
		this.radioButton35.Size = new System.Drawing.Size(53, 17);
		this.radioButton35.TabIndex = 4;
		this.radioButton35.TabStop = true;
		this.radioButton35.Text = "RVLC";
		this.radioButton35.UseVisualStyleBackColor = true;
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(3, 18);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(71, 13);
		this.label11.TabIndex = 2;
		this.label11.Text = "RAI SCUOLA";
		this.radioButton19.AutoSize = true;
		this.radioButton19.Location = new System.Drawing.Point(93, 14);
		this.radioButton19.Name = "radioButton19";
		this.radioButton19.Size = new System.Drawing.Size(45, 17);
		this.radioButton19.TabIndex = 1;
		this.radioButton19.TabStop = true;
		this.radioButton19.Text = "VLC";
		this.radioButton19.UseVisualStyleBackColor = true;
		this.radioButton20.AutoSize = true;
		this.radioButton20.Location = new System.Drawing.Point(144, 14);
		this.radioButton20.Name = "radioButton20";
		this.radioButton20.Size = new System.Drawing.Size(48, 17);
		this.radioButton20.TabIndex = 0;
		this.radioButton20.TabStop = true;
		this.radioButton20.Text = "Web";
		this.radioButton20.UseVisualStyleBackColor = true;
		this.panel9.Controls.Add(this.radioButton34);
		this.panel9.Controls.Add(this.label10);
		this.panel9.Controls.Add(this.radioButton17);
		this.panel9.Controls.Add(this.radioButton18);
		this.panel9.Location = new System.Drawing.Point(255, 130);
		this.panel9.Name = "panel9";
		this.panel9.Size = new System.Drawing.Size(246, 48);
		this.panel9.TabIndex = 6;
		this.radioButton34.AutoSize = true;
		this.radioButton34.Location = new System.Drawing.Point(190, 14);
		this.radioButton34.Name = "radioButton34";
		this.radioButton34.Size = new System.Drawing.Size(53, 17);
		this.radioButton34.TabIndex = 4;
		this.radioButton34.TabStop = true;
		this.radioButton34.Text = "RVLC";
		this.radioButton34.UseVisualStyleBackColor = true;
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(3, 18);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(76, 13);
		this.label10.TabIndex = 2;
		this.label10.Text = "RAI SAT PRM";
		this.radioButton17.AutoSize = true;
		this.radioButton17.Location = new System.Drawing.Point(93, 14);
		this.radioButton17.Name = "radioButton17";
		this.radioButton17.Size = new System.Drawing.Size(45, 17);
		this.radioButton17.TabIndex = 1;
		this.radioButton17.TabStop = true;
		this.radioButton17.Text = "VLC";
		this.radioButton17.UseVisualStyleBackColor = true;
		this.radioButton18.AutoSize = true;
		this.radioButton18.Location = new System.Drawing.Point(144, 14);
		this.radioButton18.Name = "radioButton18";
		this.radioButton18.Size = new System.Drawing.Size(48, 17);
		this.radioButton18.TabIndex = 0;
		this.radioButton18.TabStop = true;
		this.radioButton18.Text = "Web";
		this.radioButton18.UseVisualStyleBackColor = true;
		this.panel8.Controls.Add(this.radioButton33);
		this.panel8.Controls.Add(this.label9);
		this.panel8.Controls.Add(this.radioButton15);
		this.panel8.Controls.Add(this.radioButton16);
		this.panel8.Location = new System.Drawing.Point(255, 76);
		this.panel8.Name = "panel8";
		this.panel8.Size = new System.Drawing.Size(247, 48);
		this.panel8.TabIndex = 5;
		this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
		this.radioButton33.AutoSize = true;
		this.radioButton33.Location = new System.Drawing.Point(193, 14);
		this.radioButton33.Name = "radioButton33";
		this.radioButton33.Size = new System.Drawing.Size(53, 17);
		this.radioButton33.TabIndex = 4;
		this.radioButton33.TabStop = true;
		this.radioButton33.Text = "RVLC";
		this.radioButton33.UseVisualStyleBackColor = true;
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(3, 18);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(69, 13);
		this.label9.TabIndex = 2;
		this.label9.Text = "RAI CINEMA";
		this.radioButton15.AutoSize = true;
		this.radioButton15.Location = new System.Drawing.Point(93, 14);
		this.radioButton15.Name = "radioButton15";
		this.radioButton15.Size = new System.Drawing.Size(45, 17);
		this.radioButton15.TabIndex = 1;
		this.radioButton15.TabStop = true;
		this.radioButton15.Text = "VLC";
		this.radioButton15.UseVisualStyleBackColor = true;
		this.radioButton16.AutoSize = true;
		this.radioButton16.Location = new System.Drawing.Point(144, 14);
		this.radioButton16.Name = "radioButton16";
		this.radioButton16.Size = new System.Drawing.Size(48, 17);
		this.radioButton16.TabIndex = 0;
		this.radioButton16.TabStop = true;
		this.radioButton16.Text = "Web";
		this.radioButton16.UseVisualStyleBackColor = true;
		this.panel7.Controls.Add(this.radioButton32);
		this.panel7.Controls.Add(this.label8);
		this.panel7.Controls.Add(this.radioButton13);
		this.panel7.Controls.Add(this.radioButton14);
		this.panel7.Location = new System.Drawing.Point(6, 400);
		this.panel7.Name = "panel7";
		this.panel7.Size = new System.Drawing.Size(243, 48);
		this.panel7.TabIndex = 4;
		this.radioButton32.AutoSize = true;
		this.radioButton32.Location = new System.Drawing.Point(185, 14);
		this.radioButton32.Name = "radioButton32";
		this.radioButton32.Size = new System.Drawing.Size(53, 17);
		this.radioButton32.TabIndex = 6;
		this.radioButton32.TabStop = true;
		this.radioButton32.Text = "RVLC";
		this.radioButton32.UseVisualStyleBackColor = true;
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(3, 18);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(71, 13);
		this.label8.TabIndex = 2;
		this.label8.Text = "RAISPORT +";
		this.radioButton13.AutoSize = true;
		this.radioButton13.Location = new System.Drawing.Point(80, 14);
		this.radioButton13.Name = "radioButton13";
		this.radioButton13.Size = new System.Drawing.Size(45, 17);
		this.radioButton13.TabIndex = 1;
		this.radioButton13.TabStop = true;
		this.radioButton13.Text = "VLC";
		this.radioButton13.UseVisualStyleBackColor = true;
		this.radioButton14.AutoSize = true;
		this.radioButton14.Location = new System.Drawing.Point(131, 14);
		this.radioButton14.Name = "radioButton14";
		this.radioButton14.Size = new System.Drawing.Size(48, 17);
		this.radioButton14.TabIndex = 0;
		this.radioButton14.TabStop = true;
		this.radioButton14.Text = "Web";
		this.radioButton14.UseVisualStyleBackColor = true;
		this.panel6.Controls.Add(this.label7);
		this.panel6.Controls.Add(this.radioButton11);
		this.panel6.Controls.Add(this.radioButton12);
		this.panel6.Location = new System.Drawing.Point(6, 346);
		this.panel6.Name = "panel6";
		this.panel6.Size = new System.Drawing.Size(243, 48);
		this.panel6.TabIndex = 3;
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(3, 18);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(49, 13);
		this.label7.TabIndex = 2;
		this.label7.Text = "ITALIA 1";
		this.radioButton11.AutoSize = true;
		this.radioButton11.Location = new System.Drawing.Point(80, 14);
		this.radioButton11.Name = "radioButton11";
		this.radioButton11.Size = new System.Drawing.Size(45, 17);
		this.radioButton11.TabIndex = 1;
		this.radioButton11.TabStop = true;
		this.radioButton11.Text = "VLC";
		this.radioButton11.UseVisualStyleBackColor = true;
		this.radioButton12.AutoSize = true;
		this.radioButton12.Location = new System.Drawing.Point(131, 14);
		this.radioButton12.Name = "radioButton12";
		this.radioButton12.Size = new System.Drawing.Size(48, 17);
		this.radioButton12.TabIndex = 0;
		this.radioButton12.TabStop = true;
		this.radioButton12.Text = "Web";
		this.radioButton12.UseVisualStyleBackColor = true;
		this.panel5.Controls.Add(this.label6);
		this.panel5.Controls.Add(this.radioButton9);
		this.panel5.Controls.Add(this.radioButton10);
		this.panel5.Location = new System.Drawing.Point(6, 292);
		this.panel5.Name = "panel5";
		this.panel5.Size = new System.Drawing.Size(243, 48);
		this.panel5.TabIndex = 3;
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(3, 18);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(58, 13);
		this.label6.TabIndex = 2;
		this.label6.Text = "CANALE 5";
		this.radioButton9.AutoSize = true;
		this.radioButton9.Location = new System.Drawing.Point(80, 14);
		this.radioButton9.Name = "radioButton9";
		this.radioButton9.Size = new System.Drawing.Size(45, 17);
		this.radioButton9.TabIndex = 1;
		this.radioButton9.TabStop = true;
		this.radioButton9.Text = "VLC";
		this.radioButton9.UseVisualStyleBackColor = true;
		this.radioButton10.AutoSize = true;
		this.radioButton10.Location = new System.Drawing.Point(131, 14);
		this.radioButton10.Name = "radioButton10";
		this.radioButton10.Size = new System.Drawing.Size(48, 17);
		this.radioButton10.TabIndex = 0;
		this.radioButton10.TabStop = true;
		this.radioButton10.Text = "Web";
		this.radioButton10.UseVisualStyleBackColor = true;
		this.panel4.Controls.Add(this.label5);
		this.panel4.Controls.Add(this.radioButton7);
		this.panel4.Controls.Add(this.radioButton8);
		this.panel4.Location = new System.Drawing.Point(6, 238);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(243, 48);
		this.panel4.TabIndex = 3;
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(3, 18);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(45, 13);
		this.label5.TabIndex = 2;
		this.label5.Text = "RETE 4";
		this.radioButton7.AutoSize = true;
		this.radioButton7.Location = new System.Drawing.Point(80, 14);
		this.radioButton7.Name = "radioButton7";
		this.radioButton7.Size = new System.Drawing.Size(45, 17);
		this.radioButton7.TabIndex = 1;
		this.radioButton7.TabStop = true;
		this.radioButton7.Text = "VLC";
		this.radioButton7.UseVisualStyleBackColor = true;
		this.radioButton8.AutoSize = true;
		this.radioButton8.Location = new System.Drawing.Point(131, 14);
		this.radioButton8.Name = "radioButton8";
		this.radioButton8.Size = new System.Drawing.Size(48, 17);
		this.radioButton8.TabIndex = 0;
		this.radioButton8.TabStop = true;
		this.radioButton8.Text = "Web";
		this.radioButton8.UseVisualStyleBackColor = true;
		this.panel3.Controls.Add(this.radioButton31);
		this.panel3.Controls.Add(this.label4);
		this.panel3.Controls.Add(this.radioButton5);
		this.panel3.Controls.Add(this.radioButton6);
		this.panel3.Location = new System.Drawing.Point(6, 184);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(243, 48);
		this.panel3.TabIndex = 3;
		this.radioButton31.AutoSize = true;
		this.radioButton31.Location = new System.Drawing.Point(185, 14);
		this.radioButton31.Name = "radioButton31";
		this.radioButton31.Size = new System.Drawing.Size(53, 17);
		this.radioButton31.TabIndex = 5;
		this.radioButton31.TabStop = true;
		this.radioButton31.Text = "RVLC";
		this.radioButton31.UseVisualStyleBackColor = true;
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(3, 18);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(34, 13);
		this.label4.TabIndex = 2;
		this.label4.Text = "RAI 3";
		this.radioButton5.AutoSize = true;
		this.radioButton5.Location = new System.Drawing.Point(80, 14);
		this.radioButton5.Name = "radioButton5";
		this.radioButton5.Size = new System.Drawing.Size(45, 17);
		this.radioButton5.TabIndex = 1;
		this.radioButton5.TabStop = true;
		this.radioButton5.Text = "VLC";
		this.radioButton5.UseVisualStyleBackColor = true;
		this.radioButton6.AutoSize = true;
		this.radioButton6.Location = new System.Drawing.Point(131, 14);
		this.radioButton6.Name = "radioButton6";
		this.radioButton6.Size = new System.Drawing.Size(48, 17);
		this.radioButton6.TabIndex = 0;
		this.radioButton6.TabStop = true;
		this.radioButton6.Text = "Web";
		this.radioButton6.UseVisualStyleBackColor = true;
		this.panel2.Controls.Add(this.radioButton30);
		this.panel2.Controls.Add(this.label3);
		this.panel2.Controls.Add(this.radioButton3);
		this.panel2.Controls.Add(this.radioButton4);
		this.panel2.Location = new System.Drawing.Point(6, 130);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(243, 48);
		this.panel2.TabIndex = 2;
		this.radioButton30.AutoSize = true;
		this.radioButton30.Location = new System.Drawing.Point(185, 14);
		this.radioButton30.Name = "radioButton30";
		this.radioButton30.Size = new System.Drawing.Size(53, 17);
		this.radioButton30.TabIndex = 4;
		this.radioButton30.TabStop = true;
		this.radioButton30.Text = "RVLC";
		this.radioButton30.UseVisualStyleBackColor = true;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(3, 18);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(34, 13);
		this.label3.TabIndex = 2;
		this.label3.Text = "RAI 2";
		this.radioButton3.AutoSize = true;
		this.radioButton3.Location = new System.Drawing.Point(82, 14);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(45, 17);
		this.radioButton3.TabIndex = 1;
		this.radioButton3.TabStop = true;
		this.radioButton3.Text = "VLC";
		this.radioButton3.UseVisualStyleBackColor = true;
		this.radioButton4.AutoSize = true;
		this.radioButton4.Location = new System.Drawing.Point(133, 14);
		this.radioButton4.Name = "radioButton4";
		this.radioButton4.Size = new System.Drawing.Size(48, 17);
		this.radioButton4.TabIndex = 0;
		this.radioButton4.TabStop = true;
		this.radioButton4.Text = "Web";
		this.radioButton4.UseVisualStyleBackColor = true;
		this.label2.Location = new System.Drawing.Point(7, 20);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(495, 45);
		this.label2.TabIndex = 1;
		this.label2.Text = resources.GetString("label2.Text");
		this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.panel1.Controls.Add(this.radioButton29);
		this.panel1.Controls.Add(this.label1);
		this.panel1.Controls.Add(this.radioButton2);
		this.panel1.Controls.Add(this.radioButton1);
		this.panel1.Location = new System.Drawing.Point(6, 76);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(243, 48);
		this.panel1.TabIndex = 0;
		this.radioButton29.AutoSize = true;
		this.radioButton29.Location = new System.Drawing.Point(187, 14);
		this.radioButton29.Name = "radioButton29";
		this.radioButton29.Size = new System.Drawing.Size(53, 17);
		this.radioButton29.TabIndex = 3;
		this.radioButton29.TabStop = true;
		this.radioButton29.Text = "RVLC";
		this.radioButton29.UseVisualStyleBackColor = true;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(3, 18);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(34, 13);
		this.label1.TabIndex = 2;
		this.label1.Text = "RAI 1";
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(80, 14);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(45, 17);
		this.radioButton2.TabIndex = 1;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "VLC";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton1.AutoSize = true;
		this.radioButton1.Location = new System.Drawing.Point(131, 14);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(48, 17);
		this.radioButton1.TabIndex = 0;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "Web";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(12, 592);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(191, 17);
		this.checkBox1.TabIndex = 1;
		this.checkBox1.Text = "Aggiorna Opzioni Automaticamente";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
		this.button1.Location = new System.Drawing.Point(405, 18);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(92, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "Salva";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.button2.Location = new System.Drawing.Point(307, 18);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(92, 23);
		this.button2.TabIndex = 3;
		this.button2.Text = "Annulla";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl1.Location = new System.Drawing.Point(0, 0);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(548, 659);
		this.tabControl1.TabIndex = 4;
		this.tabPage1.Controls.Add(this.groupBox5);
		this.tabPage1.Controls.Add(this.groupBox4);
		this.tabPage1.Controls.Add(this.groupBox2);
		this.tabPage1.Controls.Add(this.groupBox3);
		this.tabPage1.Location = new System.Drawing.Point(4, 22);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(540, 633);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Opzioni";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.groupBox5.Controls.Add(this.button9);
		this.groupBox5.Controls.Add(this.linkLabel1);
		this.groupBox5.Controls.Add(this.label20);
		this.groupBox5.Controls.Add(this.groupBox6);
		this.groupBox5.Controls.Add(this.comboBox2);
		this.groupBox5.Controls.Add(this.label19);
		this.groupBox5.Controls.Add(this.button8);
		this.groupBox5.Controls.Add(this.button7);
		this.groupBox5.Location = new System.Drawing.Point(3, 148);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(530, 116);
		this.groupBox5.TabIndex = 8;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Opzioni Extra";
		this.button9.AccessibleName = "Televideo";
		this.button9.Location = new System.Drawing.Point(260, 29);
		this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(82, 26);
		this.button9.TabIndex = 19;
		this.button9.Text = "News";
		this.button9.UseVisualStyleBackColor = true;
		this.button9.Click += new System.EventHandler(this.button9_Click_1);
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Location = new System.Drawing.Point(187, 91);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(25, 13);
		this.linkLabel1.TabIndex = 18;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "aka";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
		this.label20.AutoSize = true;
		this.label20.Location = new System.Drawing.Point(22, 91);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(83, 13);
		this.label20.TabIndex = 17;
		this.label20.Text = "Special Thank's";
		this.groupBox6.Controls.Add(this.radioButton41);
		this.groupBox6.Controls.Add(this.radioButton40);
		this.groupBox6.Location = new System.Drawing.Point(10, 19);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new System.Drawing.Size(160, 36);
		this.groupBox6.TabIndex = 16;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "# su telecomando";
		this.radioButton41.AutoSize = true;
		this.radioButton41.Location = new System.Drawing.Point(91, 15);
		this.radioButton41.Name = "radioButton41";
		this.radioButton41.Size = new System.Drawing.Size(50, 17);
		this.radioButton41.TabIndex = 1;
		this.radioButton41.Text = "Chat ";
		this.radioButton41.UseVisualStyleBackColor = true;
		this.radioButton41.CheckedChanged += new System.EventHandler(this.radioButton41_CheckedChanged_2);
		this.radioButton40.AutoSize = true;
		this.radioButton40.Checked = true;
		this.radioButton40.Location = new System.Drawing.Point(15, 15);
		this.radioButton40.Name = "radioButton40";
		this.radioButton40.Size = new System.Drawing.Size(72, 17);
		this.radioButton40.TabIndex = 0;
		this.radioButton40.TabStop = true;
		this.radioButton40.Text = "Televideo";
		this.radioButton40.UseVisualStyleBackColor = true;
		this.radioButton40.CheckedChanged += new System.EventHandler(this.radioButton40_CheckedChanged_2);
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(189, 64);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(322, 21);
		this.comboBox2.TabIndex = 14;
		this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
		this.label19.AutoSize = true;
		this.label19.Location = new System.Drawing.Point(22, 67);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(115, 13);
		this.label19.TabIndex = 6;
		this.label19.Text = "Linguaggio Programma";
		this.button8.AccessibleName = "Chat TVOSA";
		this.button8.Location = new System.Drawing.Point(433, 29);
		this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(82, 26);
		this.button8.TabIndex = 8;
		this.button8.Text = "Chat TVOSA";
		this.button8.UseVisualStyleBackColor = true;
		this.button8.Click += new System.EventHandler(this.button8_Click);
		this.button7.AccessibleName = "Televideo";
		this.button7.Location = new System.Drawing.Point(348, 29);
		this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(82, 26);
		this.button7.TabIndex = 7;
		this.button7.Text = "Televideo";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(this.button7_Click);
		this.groupBox4.Controls.Add(this.checkBox2);
		this.groupBox4.Controls.Add(this.button5);
		this.groupBox4.Location = new System.Drawing.Point(6, 85);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(530, 57);
		this.groupBox4.TabIndex = 7;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Opzioni VLC";
		this.checkBox2.AutoSize = true;
		this.checkBox2.Location = new System.Drawing.Point(212, 28);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(154, 17);
		this.checkBox2.TabIndex = 6;
		this.checkBox2.Text = "Apri VLC in FULL SCREEN";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
		this.button5.Location = new System.Drawing.Point(7, 22);
		this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(188, 26);
		this.button5.TabIndex = 5;
		this.button5.Text = "Setta VLC";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(this.button3_Click);
		this.groupBox2.Controls.Add(this.button6);
		this.groupBox2.Controls.Add(this.label17);
		this.groupBox2.Controls.Add(this.comboBox1);
		this.groupBox2.Controls.Add(this.button4);
		this.groupBox2.Location = new System.Drawing.Point(6, 8);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox2.Size = new System.Drawing.Size(527, 72);
		this.groupBox2.TabIndex = 6;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Opzioni Registrazione";
		this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
		this.button6.Location = new System.Drawing.Point(3, 17);
		this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(187, 26);
		this.button6.TabIndex = 5;
		this.button6.Text = "Dove Registrare";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(this.button6_Click);
		this.label17.AutoSize = true;
		this.label17.Location = new System.Drawing.Point(400, 15);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(112, 13);
		this.label17.TabIndex = 2;
		this.label17.Text = "Formato Registrazione";
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[2] { "avi", "asf" });
		this.comboBox1.Location = new System.Drawing.Point(402, 36);
		this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(106, 21);
		this.comboBox1.TabIndex = 4;
		this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
		this.button4.Location = new System.Drawing.Point(196, 17);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(187, 26);
		this.button4.TabIndex = 2;
		this.button4.Text = "Apri Cartella con Explorer";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.groupBox3.Controls.Add(this.label18);
		this.groupBox3.Controls.Add(this.listBox1);
		this.groupBox3.Controls.Add(this.button3);
		this.groupBox3.Location = new System.Drawing.Point(-3, 280);
		this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox3.Size = new System.Drawing.Size(536, 342);
		this.groupBox3.TabIndex = 5;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Lista File Registrati";
		this.label18.AutoSize = true;
		this.label18.Location = new System.Drawing.Point(12, 35);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(178, 13);
		this.label18.TabIndex = 1;
		this.label18.Text = "Doppio click per aprire link registrato";
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Location = new System.Drawing.Point(16, 52);
		this.listBox1.Margin = new System.Windows.Forms.Padding(4);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(510, 277);
		this.listBox1.TabIndex = 0;
		this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
		this.button3.Location = new System.Drawing.Point(339, 16);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(187, 30);
		this.button3.TabIndex = 3;
		this.button3.Text = "Elimina file selezionato";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click_1);
		this.tabPage3.Controls.Add(this.groupBox10);
		this.tabPage3.Controls.Add(this.groupBox9);
		this.tabPage3.Controls.Add(this.groupBox8);
		this.tabPage3.Controls.Add(this.groupBox7);
		this.tabPage3.Location = new System.Drawing.Point(4, 22);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Size = new System.Drawing.Size(540, 633);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "Canali";
		this.tabPage3.UseVisualStyleBackColor = true;
		this.groupBox10.Controls.Add(this.button10);
		this.groupBox10.ForeColor = System.Drawing.Color.Blue;
		this.groupBox10.Location = new System.Drawing.Point(11, 427);
		this.groupBox10.Name = "groupBox10";
		this.groupBox10.Size = new System.Drawing.Size(505, 68);
		this.groupBox10.TabIndex = 13;
		this.groupBox10.TabStop = false;
		this.groupBox10.Text = "Lista Canali Rimossi";
		this.button10.AccessibleDescription = "";
		this.button10.AccessibleName = "Esporta lista canali";
		this.button10.ForeColor = System.Drawing.Color.Black;
		this.button10.Location = new System.Drawing.Point(7, 18);
		this.button10.Margin = new System.Windows.Forms.Padding(2);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(488, 38);
		this.button10.TabIndex = 14;
		this.button10.Text = "Cancella Lista Canali Esclusi ( Premere su \"Programma Automaticamente Canali\" in \"CANALI\" per trovare tutti i canali originali )";
		this.button10.UseVisualStyleBackColor = true;
		this.button10.Click += new System.EventHandler(this.button10_Click_1);
		this.groupBox9.Controls.Add(this.checkBox4);
		this.groupBox9.Controls.Add(this.checkBox3);
		this.groupBox9.Controls.Add(this.checkBox8);
		this.groupBox9.ForeColor = System.Drawing.Color.Blue;
		this.groupBox9.Location = new System.Drawing.Point(11, 269);
		this.groupBox9.Name = "groupBox9";
		this.groupBox9.Size = new System.Drawing.Size(505, 137);
		this.groupBox9.TabIndex = 12;
		this.groupBox9.TabStop = false;
		this.groupBox9.Text = "Extra Canali";
		this.checkBox4.Enabled = false;
		this.checkBox4.ForeColor = System.Drawing.Color.Black;
		this.checkBox4.Location = new System.Drawing.Point(17, 97);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(340, 34);
		this.checkBox4.TabIndex = 13;
		this.checkBox4.Text = "Ingrandisci dinamicamente il player nelle WEBTV";
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox4.Visible = false;
		this.checkBox3.ForeColor = System.Drawing.Color.Black;
		this.checkBox3.Location = new System.Drawing.Point(17, 60);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(340, 34);
		this.checkBox3.TabIndex = 12;
		this.checkBox3.Text = "Se Canale su Justin Crea Player Massimizzato in automatico";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
		this.checkBox8.ForeColor = System.Drawing.Color.Black;
		this.checkBox8.Location = new System.Drawing.Point(17, 20);
		this.checkBox8.Name = "checkBox8";
		this.checkBox8.Size = new System.Drawing.Size(462, 41);
		this.checkBox8.TabIndex = 10;
		this.checkBox8.Text = "Multiple WEBTV (Con questa opzione potrai visualizzare più canali contemporaneamente anche da WEB)";
		this.checkBox8.UseVisualStyleBackColor = true;
		this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged_1);
		this.groupBox8.Controls.Add(this.checkBox7);
		this.groupBox8.Controls.Add(this.button16);
		this.groupBox8.Controls.Add(this.button15);
		this.groupBox8.ForeColor = System.Drawing.Color.Blue;
		this.groupBox8.Location = new System.Drawing.Point(11, 137);
		this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox8.Size = new System.Drawing.Size(505, 121);
		this.groupBox8.TabIndex = 7;
		this.groupBox8.TabStop = false;
		this.groupBox8.Text = "Esportazione/Invio lista";
		this.checkBox7.AutoSize = true;
		this.checkBox7.ForeColor = System.Drawing.Color.Black;
		this.checkBox7.Location = new System.Drawing.Point(7, 19);
		this.checkBox7.Name = "checkBox7";
		this.checkBox7.Size = new System.Drawing.Size(365, 17);
		this.checkBox7.TabIndex = 16;
		this.checkBox7.Text = "Inviaci la lista in automatico ogni volta che si aggiunge un nuovo canale";
		this.checkBox7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.checkBox7.UseVisualStyleBackColor = true;
		this.button16.AccessibleDescription = "";
		this.button16.AccessibleName = "Esporta lista canali";
		this.button16.ForeColor = System.Drawing.Color.Black;
		this.button16.Location = new System.Drawing.Point(4, 43);
		this.button16.Margin = new System.Windows.Forms.Padding(2);
		this.button16.Name = "button16";
		this.button16.Size = new System.Drawing.Size(488, 22);
		this.button16.TabIndex = 13;
		this.button16.Text = "Esporta Lista Canali";
		this.button16.UseVisualStyleBackColor = true;
		this.button16.Click += new System.EventHandler(this.button16_Click);
		this.button15.AccessibleDescription = "";
		this.button15.AccessibleName = "condividi la tua lista canali";
		this.button15.Enabled = false;
		this.button15.ForeColor = System.Drawing.Color.Black;
		this.button15.Location = new System.Drawing.Point(4, 69);
		this.button15.Margin = new System.Windows.Forms.Padding(2);
		this.button15.Name = "button15";
		this.button15.Size = new System.Drawing.Size(488, 22);
		this.button15.TabIndex = 14;
		this.button15.Text = "Condividi (se hai aggiunto dei canali) la tua Lista Canali";
		this.button15.UseVisualStyleBackColor = true;
		this.button15.Click += new System.EventHandler(this.button15_Click);
		this.groupBox7.Controls.Add(this.checkBox6);
		this.groupBox7.Controls.Add(this.button17);
		this.groupBox7.Controls.Add(this.progressBar3);
		this.groupBox7.ForeColor = System.Drawing.Color.Blue;
		this.groupBox7.Location = new System.Drawing.Point(11, 25);
		this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox7.Size = new System.Drawing.Size(505, 103);
		this.groupBox7.TabIndex = 6;
		this.groupBox7.TabStop = false;
		this.groupBox7.Text = "Aggiornamento Canali";
		this.checkBox6.AutoSize = true;
		this.checkBox6.ForeColor = System.Drawing.Color.Black;
		this.checkBox6.Location = new System.Drawing.Point(5, 18);
		this.checkBox6.Name = "checkBox6";
		this.checkBox6.Size = new System.Drawing.Size(156, 17);
		this.checkBox6.TabIndex = 15;
		this.checkBox6.Text = "Aggiorna lista ad ogni avvio";
		this.checkBox6.UseVisualStyleBackColor = true;
		this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
		this.button17.AccessibleDescription = "";
		this.button17.AccessibleName = "Aggiorna lista Canali da internet";
		this.button17.ForeColor = System.Drawing.Color.Black;
		this.button17.Location = new System.Drawing.Point(7, 40);
		this.button17.Margin = new System.Windows.Forms.Padding(2);
		this.button17.Name = "button17";
		this.button17.Size = new System.Drawing.Size(486, 22);
		this.button17.TabIndex = 7;
		this.button17.Text = "Aggiorna Lista Canali da Internet";
		this.button17.UseVisualStyleBackColor = true;
		this.button17.Click += new System.EventHandler(this.button17_Click);
		this.progressBar3.ForeColor = System.Drawing.Color.Black;
		this.progressBar3.Location = new System.Drawing.Point(7, 66);
		this.progressBar3.Margin = new System.Windows.Forms.Padding(2);
		this.progressBar3.Name = "progressBar3";
		this.progressBar3.Size = new System.Drawing.Size(486, 20);
		this.progressBar3.TabIndex = 8;
		this.tabPage2.Controls.Add(this.groupBox1);
		this.tabPage2.Controls.Add(this.button2);
		this.tabPage2.Controls.Add(this.checkBox1);
		this.tabPage2.Controls.Add(this.button1);
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(540, 633);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Avanzate";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.checkBox5.AutoSize = true;
		this.checkBox5.ForeColor = System.Drawing.Color.Black;
		this.checkBox5.Location = new System.Drawing.Point(3, 19);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(156, 17);
		this.checkBox5.TabIndex = 15;
		this.checkBox5.Text = "Aggiorna lista ad ogni avvio";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.button12.AccessibleDescription = "";
		this.button12.AccessibleName = "condividi la tua lista canali";
		this.button12.Enabled = false;
		this.button12.ForeColor = System.Drawing.Color.Black;
		this.button12.Location = new System.Drawing.Point(439, 69);
		this.button12.Margin = new System.Windows.Forms.Padding(2);
		this.button12.Name = "button12";
		this.button12.Size = new System.Drawing.Size(409, 22);
		this.button12.TabIndex = 14;
		this.button12.Text = "Condividi la tua Lista Canali";
		this.button12.UseVisualStyleBackColor = true;
		this.progressBar2.ForeColor = System.Drawing.Color.Black;
		this.progressBar2.Location = new System.Drawing.Point(1, 69);
		this.progressBar2.Margin = new System.Windows.Forms.Padding(2);
		this.progressBar2.Name = "progressBar2";
		this.progressBar2.Size = new System.Drawing.Size(422, 20);
		this.progressBar2.TabIndex = 8;
		this.button13.AccessibleDescription = "";
		this.button13.AccessibleName = "Esporta lista canali";
		this.button13.ForeColor = System.Drawing.Color.Black;
		this.button13.Location = new System.Drawing.Point(439, 43);
		this.button13.Margin = new System.Windows.Forms.Padding(2);
		this.button13.Name = "button13";
		this.button13.Size = new System.Drawing.Size(409, 22);
		this.button13.TabIndex = 13;
		this.button13.Text = "Esporta Lista Canali";
		this.button13.UseVisualStyleBackColor = true;
		this.button14.AccessibleDescription = "";
		this.button14.AccessibleName = "Aggiorna lista Canali da internet";
		this.button14.ForeColor = System.Drawing.Color.Black;
		this.button14.Location = new System.Drawing.Point(1, 43);
		this.button14.Margin = new System.Windows.Forms.Padding(2);
		this.button14.Name = "button14";
		this.button14.Size = new System.Drawing.Size(422, 22);
		this.button14.TabIndex = 7;
		this.button14.Text = "Aggiorna Lista Canali da Internet";
		this.button14.UseVisualStyleBackColor = true;
		this.panel16.Controls.Add(this.radioButton45);
		this.panel16.Controls.Add(this.label21);
		this.panel16.Controls.Add(this.radioButton46);
		this.panel16.Controls.Add(this.radioButton47);
		this.panel16.Location = new System.Drawing.Point(254, 454);
		this.panel16.Name = "panel16";
		this.panel16.Size = new System.Drawing.Size(246, 48);
		this.panel16.TabIndex = 12;
		this.radioButton45.AutoSize = true;
		this.radioButton45.Location = new System.Drawing.Point(190, 14);
		this.radioButton45.Name = "radioButton45";
		this.radioButton45.Size = new System.Drawing.Size(53, 17);
		this.radioButton45.TabIndex = 4;
		this.radioButton45.TabStop = true;
		this.radioButton45.Text = "RVLC";
		this.radioButton45.UseVisualStyleBackColor = true;
		this.label21.AutoSize = true;
		this.label21.Location = new System.Drawing.Point(3, 18);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(34, 13);
		this.label21.TabIndex = 2;
		this.label21.Text = "RAI 5";
		this.radioButton46.AutoSize = true;
		this.radioButton46.Location = new System.Drawing.Point(93, 14);
		this.radioButton46.Name = "radioButton46";
		this.radioButton46.Size = new System.Drawing.Size(45, 17);
		this.radioButton46.TabIndex = 1;
		this.radioButton46.TabStop = true;
		this.radioButton46.Text = "VLC";
		this.radioButton46.UseVisualStyleBackColor = true;
		this.radioButton47.AutoSize = true;
		this.radioButton47.Location = new System.Drawing.Point(144, 14);
		this.radioButton47.Name = "radioButton47";
		this.radioButton47.Size = new System.Drawing.Size(48, 17);
		this.radioButton47.TabIndex = 0;
		this.radioButton47.TabStop = true;
		this.radioButton47.Text = "Web";
		this.radioButton47.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(548, 659);
		base.Controls.Add(this.tabControl1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Opzioni";
		base.Opacity = 0.0;
		this.Text = "Opzioni TVOSA";
		base.Load += new System.EventHandler(this.Opzioni_Load);
		this.groupBox1.ResumeLayout(false);
		this.panel15.ResumeLayout(false);
		this.panel15.PerformLayout();
		this.panel14.ResumeLayout(false);
		this.panel14.PerformLayout();
		this.panel13.ResumeLayout(false);
		this.panel13.PerformLayout();
		this.panel12.ResumeLayout(false);
		this.panel12.PerformLayout();
		this.panel11.ResumeLayout(false);
		this.panel11.PerformLayout();
		this.panel10.ResumeLayout(false);
		this.panel10.PerformLayout();
		this.panel9.ResumeLayout(false);
		this.panel9.PerformLayout();
		this.panel8.ResumeLayout(false);
		this.panel8.PerformLayout();
		this.panel7.ResumeLayout(false);
		this.panel7.PerformLayout();
		this.panel6.ResumeLayout(false);
		this.panel6.PerformLayout();
		this.panel5.ResumeLayout(false);
		this.panel5.PerformLayout();
		this.panel4.ResumeLayout(false);
		this.panel4.PerformLayout();
		this.panel3.ResumeLayout(false);
		this.panel3.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.tabPage3.ResumeLayout(false);
		this.groupBox10.ResumeLayout(false);
		this.groupBox9.ResumeLayout(false);
		this.groupBox8.ResumeLayout(false);
		this.groupBox8.PerformLayout();
		this.groupBox7.ResumeLayout(false);
		this.groupBox7.PerformLayout();
		this.tabPage2.ResumeLayout(false);
		this.tabPage2.PerformLayout();
		this.panel16.ResumeLayout(false);
		this.panel16.PerformLayout();
		base.ResumeLayout(false);
	}

	public Opzioni(Form1 m)
	{
		mio = m;
		InitializeComponent();
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
			string[] files = Directory.GetFiles(mio.dvreg);
			foreach (string fileName in files)
			{
				FileInfo fileInfo = new FileInfo(fileName);
				if (fileInfo.Name.IndexOf(".avi") >= 0 || fileInfo.Name.IndexOf(".asf") >= 0 || fileInfo.Name.IndexOf(".mkv") >= 0 || fileInfo.Name.IndexOf(".flv") >= 0)
				{
					listBox1.Items.Add(fileInfo.Name);
				}
			}
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

	private void leggiopzchat()
	{
		try
		{
			if (mio.chattvosa)
			{
				radioButton41.Checked = true;
			}
		}
		catch
		{
		}
	}

	private void scriviopzchat(int i)
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\chatvosa.txt");
			if (i == 0)
			{
				streamWriter.WriteLine("true");
				mio.chattvosa = true;
			}
			else
			{
				streamWriter.WriteLine("false");
				mio.chattvosa = false;
			}
			streamWriter.Close();
		}
		catch
		{
		}
	}

	private bool linguaggio()
	{
		bool result = false;
		try
		{
			if (File.Exists(Program.pr + "\\linguaggio"))
			{
				result = true;
			}
		}
		catch
		{
		}
		return result;
	}

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + mio.linguaprogramma + "OPZ.txt");
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
			if (text2.IndexOf("groupBox5") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox5"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox5.Text = text3;
			}
			if (text2.IndexOf("groupBox6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox6.Text = text3;
			}
			if (text2.IndexOf("groupBox4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox4.Text = text3;
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
			if (text2.IndexOf("groupBox9") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox9"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox9.Text = text3;
			}
			if (text2.IndexOf("groupBox8") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox8"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox8.Text = text3;
			}
			if (text2.IndexOf("groupBox7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox7.Text = text3;
			}
			if (text2.IndexOf("linkLabel1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("linkLabel1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				linkLabel1.Text = text3;
			}
			if (text2.IndexOf("label16") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label16"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label16.Text = text3;
			}
			if (text2.IndexOf("label15") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label15"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label15.Text = text3;
			}
			if (text2.IndexOf("label14") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label14"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label14.Text = text3;
			}
			if (text2.IndexOf("label13") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label13"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label13.Text = text3;
			}
			if (text2.IndexOf("label12") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label12"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label12.Text = text3;
			}
			if (text2.IndexOf("label11") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label11"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label11.Text = text3;
			}
			if (text2.IndexOf("label10") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label10"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label10.Text = text3;
			}
			if (text2.IndexOf("label9") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label9"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label9.Text = text3;
			}
			if (text2.IndexOf("label8") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label8"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label8.Text = text3;
			}
			if (text2.IndexOf("label7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label7.Text = text3;
			}
			if (text2.IndexOf("label6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label6.Text = text3;
			}
			if (text2.IndexOf("label5") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label5"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label5.Text = text3;
			}
			if (text2.IndexOf("label4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label4.Text = text3;
			}
			if (text2.IndexOf("label3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label3.Text = text3;
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
			if (text2.IndexOf("label19") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label19"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label19.Text = text3;
			}
			if (text2.IndexOf("label17") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label17"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label17.Text = text3;
			}
			if (text2.IndexOf("label18") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label18"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label18.Text = text3;
			}
			if (text2.IndexOf("label20") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label20"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label20.Text = text3;
			}
			if (text2.IndexOf("radioButton42") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton42"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton42.Text = text3;
			}
			if (text2.IndexOf("radioButton43") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton43"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton43.Text = text3;
			}
			if (text2.IndexOf("radioButton44") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton44"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton44.Text = text3;
			}
			if (text2.IndexOf("radioButton39") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton39"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton39.Text = text3;
			}
			if (text2.IndexOf("radioButton27") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton27"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton27.Text = text3;
			}
			if (text2.IndexOf("radioButton28") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton28"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton28.Text = text3;
			}
			if (text2.IndexOf("radioButton38") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton38"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton38.Text = text3;
			}
			if (text2.IndexOf("radioButton25") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton25"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton25.Text = text3;
			}
			if (text2.IndexOf("radioButton26") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton26"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton26.Text = text3;
			}
			if (text2.IndexOf("radioButton37") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton37"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton37.Text = text3;
			}
			if (text2.IndexOf("radioButton23") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton23"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton23.Text = text3;
			}
			if (text2.IndexOf("radioButton24") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton24"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton24.Text = text3;
			}
			if (text2.IndexOf("radioButton36") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton36"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton36.Text = text3;
			}
			if (text2.IndexOf("radioButton21") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton21"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton21.Text = text3;
			}
			if (text2.IndexOf("radioButton22") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton22"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton22.Text = text3;
			}
			if (text2.IndexOf("radioButton35") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton35"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton35.Text = text3;
			}
			if (text2.IndexOf("radioButton19") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton19"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton19.Text = text3;
			}
			if (text2.IndexOf("radioButton20") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton20"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton20.Text = text3;
			}
			if (text2.IndexOf("radioButton34") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton34"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton34.Text = text3;
			}
			if (text2.IndexOf("radioButton17") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton17"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton17.Text = text3;
			}
			if (text2.IndexOf("radioButton18") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton18"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton18.Text = text3;
			}
			if (text2.IndexOf("radioButton33") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton33"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton33.Text = text3;
			}
			if (text2.IndexOf("radioButton15") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton15"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton15.Text = text3;
			}
			if (text2.IndexOf("radioButton16") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton16"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton16.Text = text3;
			}
			if (text2.IndexOf("radioButton32") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton32"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton32.Text = text3;
			}
			if (text2.IndexOf("radioButton13") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton13"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton13.Text = text3;
			}
			if (text2.IndexOf("radioButton14") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton14"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton14.Text = text3;
			}
			if (text2.IndexOf("radioButton11") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton11"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton11.Text = text3;
			}
			if (text2.IndexOf("radioButton12") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton12"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton12.Text = text3;
			}
			if (text2.IndexOf("radioButton9") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton9"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton9.Text = text3;
			}
			if (text2.IndexOf("radioButton10") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton10"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton10.Text = text3;
			}
			if (text2.IndexOf("radioButton7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton7.Text = text3;
			}
			if (text2.IndexOf("radioButton8") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton8"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton8.Text = text3;
			}
			if (text2.IndexOf("radioButton31") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton31"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton31.Text = text3;
			}
			if (text2.IndexOf("radioButton5") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton5"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton5.Text = text3;
			}
			if (text2.IndexOf("radioButton6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton6.Text = text3;
			}
			if (text2.IndexOf("radioButton30") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton30"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton30.Text = text3;
			}
			if (text2.IndexOf("radioButton3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton3.Text = text3;
			}
			if (text2.IndexOf("radioButton4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton4.Text = text3;
			}
			if (text2.IndexOf("radioButton29") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton29"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton29.Text = text3;
			}
			if (text2.IndexOf("radioButton2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton2.Text = text3;
			}
			if (text2.IndexOf("radioButton1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton1.Text = text3;
			}
			if (text2.IndexOf("radioButton41") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton41"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton41.Text = text3;
			}
			if (text2.IndexOf("radioButton40") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("radioButton40"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				radioButton40.Text = text3;
			}
			if (text2.IndexOf("button1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button1.Text = text3;
			}
			if (text2.IndexOf("button2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button2.Text = text3;
			}
			if (text2.IndexOf("button8") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button8"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button8.Text = text3;
			}
			if (text2.IndexOf("button7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button7.Text = text3;
			}
			if (text2.IndexOf("button5") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button5"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button5.Text = text3;
			}
			if (text2.IndexOf("button6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button6.Text = text3;
			}
			if (text2.IndexOf("button4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button4.Text = text3;
			}
			if (text2.IndexOf("button3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button3.Text = text3;
			}
			if (text2.IndexOf("button16") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button16"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button16.Text = text3;
			}
			if (text2.IndexOf("button15") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button15"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button15.Text = text3;
			}
			if (text2.IndexOf("button17") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button17"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button17.Text = text3;
			}
			if (text2.IndexOf("button12") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button12"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button12.Text = text3;
			}
			if (text2.IndexOf("button13") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button13"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button13.Text = text3;
			}
			if (text2.IndexOf("button14") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button14"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button14.Text = text3;
			}
			if (text2.IndexOf("tabPage1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("tabPage1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				tabPage1.Text = text3;
			}
			if (text2.IndexOf("tabPage3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("tabPage3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				tabPage3.Text = text3;
			}
			if (text2.IndexOf("tabPage2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("tabPage2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				tabPage2.Text = text3;
			}
			if (text2.IndexOf("checkBox1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox1.Text = text3;
			}
			if (text2.IndexOf("checkBox2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox2.Text = text3;
			}
			if (text2.IndexOf("checkBox3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox3.Text = text3;
			}
			if (text2.IndexOf("checkBox8") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox8"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox8.Text = text3;
			}
			if (text2.IndexOf("checkBox7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox7.Text = text3;
			}
			if (text2.IndexOf("checkBox6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox6.Text = text3;
			}
			if (text2.IndexOf("checkBox5") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox5"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox5.Text = text3;
			}
		}
		catch
		{
		}
	}

	private void createcombo()
	{
		ComboBox comboBox = comboBox2;
		try
		{
			string[] directories = Directory.GetDirectories(Program.pr + "\\LENG");
			string[] array = directories;
			foreach (string text in array)
			{
				string item = text.Substring(text.LastIndexOf("\\") + 1);
				comboBox.Items.Add(item);
			}
			if (File.Exists(Program.pr + "\\linguaggio"))
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\linguaggio");
				string selectedItem = streamReader.ReadLine();
				streamReader.Close();
				comboBox.SelectedItem = selectedItem;
			}
		}
		catch
		{
		}
	}

	private void Opzioni_Load(object sender, EventArgs e)
	{
		createcombo();
		checkBox8.Checked = mio.multipliwebtv;
		if (File.Exists(Program.pr + "\\aggcanalesi"))
		{
			button15.Enabled = true;
		}
		if (File.Exists(Program.pr + "\\autoagg"))
		{
			checkBox6.Checked = true;
		}
		if (File.Exists(Program.pr + "\\avvisaqnd"))
		{
		}
		if (File.Exists(Program.pr + "\\autoaggopz"))
		{
			checkBox1.Checked = true;
		}
		if (!linguaggio())
		{
			comboBox2.SelectedIndex = 0;
		}
		cambialing();
		leggiopzcan();
		partiprogr();
		leggijustin();
		leggiopzchat();
		leggirec();
		leggifull();
		caricalista();
	}

	private void panel8_Paint(object sender, PaintEventArgs e)
	{
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start("http://www.informaniaci.it/2009/11/03/freegate-lalternativa-a-ultrasurf-per-justin-tv/");
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

	private void leggiopzcan()
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
					radioButton1.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton29.Checked = true;
				}
				else
				{
					radioButton2.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton4.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton30.Checked = true;
				}
				else
				{
					radioButton3.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton6.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton31.Checked = true;
				}
				else
				{
					radioButton5.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton8.Checked = true;
				}
				else
				{
					radioButton7.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton10.Checked = true;
				}
				else
				{
					radioButton9.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton12.Checked = true;
				}
				else
				{
					radioButton11.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton14.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton32.Checked = true;
				}
				else
				{
					radioButton13.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton16.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton33.Checked = true;
				}
				else
				{
					radioButton15.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton18.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton34.Checked = true;
				}
				else
				{
					radioButton17.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton20.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton35.Checked = true;
				}
				else
				{
					radioButton19.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton22.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton36.Checked = true;
				}
				else
				{
					radioButton21.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton24.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton37.Checked = true;
				}
				else
				{
					radioButton23.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton26.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton38.Checked = true;
				}
				else
				{
					radioButton25.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton28.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton39.Checked = true;
				}
				else
				{
					radioButton27.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton44.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton42.Checked = true;
				}
				else
				{
					radioButton43.Checked = true;
				}
				streamReader.ReadLine();
				text = streamReader.ReadLine();
				if (text.IndexOf("WEB") >= 0)
				{
					radioButton47.Checked = true;
				}
				else if (text.IndexOf("VLCR") >= 0)
				{
					radioButton45.Checked = true;
				}
				else
				{
					radioButton46.Checked = true;
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

	private bool settatoVLCR()
	{
		bool result = false;
		try
		{
			if (radioButton29.Checked)
			{
				result = true;
			}
			if (radioButton30.Checked)
			{
				result = true;
			}
			if (radioButton31.Checked)
			{
				result = true;
			}
			if (radioButton32.Checked)
			{
				result = true;
			}
			if (radioButton33.Checked)
			{
				result = true;
			}
			if (radioButton34.Checked)
			{
				result = true;
			}
			if (radioButton35.Checked)
			{
				result = true;
			}
			if (radioButton36.Checked)
			{
				result = true;
			}
			if (radioButton37.Checked)
			{
				result = true;
			}
			if (radioButton38.Checked)
			{
				result = true;
			}
			if (radioButton39.Checked)
			{
				result = true;
			}
		}
		catch
		{
		}
		return result;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (settatoVLCR() && DialogResult.No == MessageBox.Show("Attenzione è stata selezionata la modalità RVLC, accettando questa richiesta ci si assume ogni responsabilità sulla visione e la registrazione della RAI e dei suoi contenuti", "ATTENZIONE", MessageBoxButtons.YesNo))
			{
				return;
			}
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\configopz.txt");
			streamWriter.WriteLine("RAI 1");
			if (radioButton1.Checked)
			{
				mio.raiunoweb = true;
				mio.raiunovlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raiunoweb = false;
				if (radioButton29.Checked)
				{
					mio.raiunovlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raiunovlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI 2");
			if (radioButton4.Checked)
			{
				mio.raidueweb = true;
				mio.raiduevlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raidueweb = false;
				if (radioButton30.Checked)
				{
					mio.raiduevlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raiduevlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI 3");
			if (radioButton6.Checked)
			{
				mio.raitreweb = true;
				mio.raitrevlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raitreweb = false;
				if (radioButton31.Checked)
				{
					mio.raitrevlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raitrevlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RETE 4");
			if (radioButton8.Checked)
			{
				mio.retequattroweb = true;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.retequattroweb = false;
				streamWriter.WriteLine("VLC");
			}
			streamWriter.WriteLine("CANALE 5");
			if (radioButton10.Checked)
			{
				mio.canalecinqueweb = true;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.canalecinqueweb = false;
				streamWriter.WriteLine("VLC");
			}
			streamWriter.WriteLine("ITALIA 1");
			if (radioButton12.Checked)
			{
				mio.italiaunoweb = true;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.italiaunoweb = false;
				streamWriter.WriteLine("VLC");
			}
			streamWriter.WriteLine("RAI SPORT");
			if (radioButton14.Checked)
			{
				mio.raisport = true;
				mio.raisportvlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raisport = false;
				if (radioButton32.Checked)
				{
					mio.raisportvlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raisportvlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI CINEMA");
			if (radioButton16.Checked)
			{
				mio.raicinema = true;
				mio.raicinemavlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raicinema = false;
				if (radioButton33.Checked)
				{
					mio.raicinemavlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raicinemavlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI SAT EX");
			if (radioButton18.Checked)
			{
				mio.raisatextra = true;
				mio.raisatextravlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raisatextra = false;
				if (radioButton34.Checked)
				{
					mio.raisatextravlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raisatextravlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI SCUOLA");
			if (radioButton20.Checked)
			{
				mio.raiscuola = true;
				mio.raiscuolavlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raiscuola = false;
				if (radioButton35.Checked)
				{
					mio.raiscuolavlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raiscuolavlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI GULP");
			if (radioButton22.Checked)
			{
				mio.raigulp = true;
				mio.raigulpvlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raigulp = false;
				if (radioButton36.Checked)
				{
					mio.raigulpvlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raigulpvlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI YOYO");
			if (radioButton24.Checked)
			{
				mio.raiyoyo = true;
				mio.raiyoyovlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raiyoyo = false;
				if (radioButton37.Checked)
				{
					mio.raiyoyovlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raiyoyovlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI SAT EX");
			if (radioButton26.Checked)
			{
				mio.raisatpr = true;
				mio.raisatprvlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raisatpr = false;
				if (radioButton38.Checked)
				{
					mio.raisatprvlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raisatprvlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI ECON");
			if (radioButton28.Checked)
			{
				mio.raiecono = true;
				mio.raieconovlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raiecono = false;
				if (radioButton39.Checked)
				{
					mio.raieconovlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raieconovlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI SPORT2");
			if (radioButton44.Checked)
			{
				mio.raisport2 = true;
				mio.raisport2vlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raisport2 = false;
				if (radioButton42.Checked)
				{
					mio.raisport2vlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raisport2vlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.WriteLine("RAI 5");
			if (radioButton47.Checked)
			{
				mio.raicinque = true;
				mio.raicinquevlcr = false;
				streamWriter.WriteLine("WEB");
			}
			else
			{
				mio.raicinque = false;
				if (radioButton45.Checked)
				{
					mio.raicinquevlcr = true;
					streamWriter.WriteLine("VLCR");
				}
				else
				{
					mio.raicinquevlcr = false;
					streamWriter.WriteLine("VLC");
				}
			}
			streamWriter.Close();
			Close();
		}
		catch
		{
		}
	}

	private void setta()
	{
		if (!File.Exists(Program.pr + "\\autoaggopz"))
		{
			checkBox1.Checked = false;
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (checkBox1.Checked)
			{
				if (!File.Exists(Program.pr + "\\autoaggopz"))
				{
					File.Create(Program.pr + "\\autoaggopz");
				}
			}
			else if (File.Exists(Program.pr + "\\autoaggopz"))
			{
				File.Delete(Program.pr + "\\autoaggopz");
			}
		}
		catch
		{
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void groupBox2_Enter(object sender, EventArgs e)
	{
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

	private void button3_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.ShowDialog();
		if (!string.IsNullOrEmpty(openFileDialog.FileName))
		{
			scrivivlc(openFileDialog.FileName);
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
				checkBox2.Checked = true;
			}
		}
		catch
		{
		}
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

	private void button6_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.ShowDialog();
		if (folderBrowserDialog.SelectedPath != null)
		{
			scrivireg(folderBrowserDialog.SelectedPath);
			mio.dvreg = folderBrowserDialog.SelectedPath;
		}
		caricalista();
	}

	public void scrivifull()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\full.txt");
			if (checkBox2.Checked)
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

	private void checkBox2_CheckedChanged(object sender, EventArgs e)
	{
		mio.checkBox1.Checked = checkBox2.Checked;
	}

	private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			Process.Start(mio.vlc, "\"" + mio.dvreg + "\\" + listBox1.SelectedItem.ToString() + "\"");
		}
		catch
		{
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		try
		{
			Process.Start(mio.dvreg);
		}
		catch
		{
		}
	}

	private void button3_Click_1(object sender, EventArgs e)
	{
		try
		{
			File.Delete(mio.dvreg + "\\" + listBox1.SelectedItem.ToString());
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

	private void leggijustin()
	{
		if (mio.justinalwaysx)
		{
			checkBox3.Checked = true;
		}
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void radioButton41_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void radioButton40_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void button7_Click(object sender, EventArgs e)
	{
		try
		{
			Televideo televideo = new Televideo();
			televideo.settapg("http://www.televideo.rai.it/televideo/pub/popupTelevideo.jsp?p=103&s=1&r=Nazionale&pagetocall=popupTelevideo.jsp");
			televideo.Text = "Televideo";
			televideo.MaximizeBox = mio.chattvosa;
			televideo.Show();
		}
		catch
		{
		}
	}

	private void button8_Click(object sender, EventArgs e)
	{
		try
		{
			Televideo televideo = new Televideo();
			televideo.Text = "Chat TVOSA";
			televideo.settapg("http://chatroll.com/embed/chat/tvosa-chat?name=tvosa-chat");
			televideo.MaximizeBox = mio.chattvosa;
			televideo.Show();
		}
		catch
		{
		}
	}

	private void checkBox4_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!File.Exists(Program.pr + "\\avvisaqnd"))
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\avvisaqnd");
				streamWriter.Close();
			}
			mio.avvisaqnd = true;
			try
			{
				mio.TTXVPAL.Abort();
			}
			catch
			{
			}
			try
			{
				ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(mio);
				mio.TTXVPAL = new Thread(threadSimileAltriCanali.vaiemostraprogrammitv);
				mio.TTXVPAL.IsBackground = true;
				mio.TTXVPAL.Priority = ThreadPriority.BelowNormal;
				mio.TTXVPAL.Start();
			}
			catch
			{
			}
			File.Delete(Program.pr + "\\avvisaqnd");
			mio.avvisaqnd = false;
			try
			{
				mio.TTXVPAL.Abort();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	private void button9_Click(object sender, EventArgs e)
	{
		Avvisa_quando_si_vede_in_Tv avvisa_quando_si_vede_in_Tv = new Avvisa_quando_si_vede_in_Tv(mio);
		avvisa_quando_si_vede_in_Tv.Show();
	}

	private void button10_Click(object sender, EventArgs e)
	{
		try
		{
			TTXVPALX.Abort();
		}
		catch
		{
		}
		try
		{
			ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(mio, this);
			TTXVPALX = new Thread(threadSimileAltriCanali.vaiemostraprogrammitv2);
			TTXVPALX.IsBackground = true;
			TTXVPALX.Priority = ThreadPriority.BelowNormal;
			TTXVPALX.Start();
		}
		catch
		{
		}
	}

	private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			int selectedIndex = comboBox2.SelectedIndex;
			mio.linguaprogramma = "\\" + comboBox2.SelectedItem.ToString() + "\\";
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\linguaggio");
			streamWriter.WriteLine(comboBox2.SelectedItem.ToString());
			streamWriter.Close();
			cambialing();
			try
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + mio.linguaprogramma + "AUTHOR.txt");
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				text = text.Substring(text.IndexOf(":") + 1);
				string text2 = text.Substring(0, text.IndexOf(Environment.NewLine));
				linkLabel1.Text = text2;
				text = text.Substring(text.IndexOf(":") + 1);
				string text3 = text.Substring(0, text.IndexOf(Environment.NewLine));
				text3 = text3.Replace(" ", "");
				linkautor = text3;
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
			// BONIFICA 2026-10-28: GamesLink (giochi Flash pirata) rimosso.
		}

	private void partiagg()
	{
		try
		{
			TTXX.Abort();
		}
		catch
		{
		}
		try
		{
			ThreadCapo threadCapo = new ThreadCapo(this);
			TTXX = new Thread(threadCapo.aggiorna);
			TTXX.IsBackground = true;
			TTXX.Priority = ThreadPriority.BelowNormal;
			TTXX.Start();
		}
		catch
		{
		}
	}

	private void button17_Click(object sender, EventArgs e)
	{
		partiagg();
	}

	private void button16_Click(object sender, EventArgs e)
	{
		try
		{
			Process.Start(Program.pr + "\\nuovicanali.txt");
		}
		catch
		{
		}
	}

	private void button15_Click(object sender, EventArgs e)
	{
		bool flag = false;
		try
		{
			if (!mio.TTXINVIO.IsAlive)
			{
				flag = true;
			}
		}
		catch
		{
			flag = true;
		}
		if (flag)
		{
			try
			{
				ThreadCapo threadCapo = new ThreadCapo(mio);
				mio.TTXINVIO = new Thread(threadCapo.invia);
				mio.TTXINVIO.IsBackground = true;
				mio.TTXINVIO.Priority = ThreadPriority.BelowNormal;
				mio.TTXINVIO.Start();
				MessageBox.Show("Attendi ti verra' notificato quando la lista sara' stata inviata");
				return;
			}
			catch
			{
				return;
			}
		}
		MessageBox.Show("Bisogna aspettare almeno 5 minuti tra l'invio di 1 lista e 1 altra");
	}

	private void checkBox8_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void radioButton40_CheckedChanged_1(object sender, EventArgs e)
	{
		if (radioButton40.Checked)
		{
			scriviopzchat(1);
		}
		mio.settatooltip();
	}

	private void radioButton41_CheckedChanged_1(object sender, EventArgs e)
	{
		if (radioButton41.Checked)
		{
			scriviopzchat(0);
		}
		mio.settatooltip();
	}

	private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
	{
		mio.multipliwebtv = checkBox8.Checked;
	}

	private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
	{
		try
		{
			if (checkBox3.Checked)
			{
				if (!File.Exists(Program.pr + "\\justalways"))
				{
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\justalways");
					streamWriter.Close();
				}
				mio.justinalwaysx = true;
				checkBox4.Visible = true;
			}
			else
			{
				File.Delete(Program.pr + "\\justalways");
				mio.justinalwaysx = false;
				checkBox4.Visible = false;
			}
		}
		catch
		{
		}
	}

	private void checkBox6_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (checkBox6.Checked)
			{
				if (!File.Exists(Program.pr + "\\autoagg"))
				{
					File.Create(Program.pr + "\\autoagg");
				}
			}
			else if (File.Exists(Program.pr + "\\autoagg"))
			{
				File.Delete(Program.pr + "\\autoagg");
			}
		}
		catch
		{
		}
	}

	private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start(linkautor);
		}
		catch
		{
		}
	}

	private void radioButton41_CheckedChanged_2(object sender, EventArgs e)
	{
		if (radioButton41.Checked)
		{
			scriviopzchat(0);
		}
		mio.settatooltip();
	}

	private void radioButton40_CheckedChanged_2(object sender, EventArgs e)
	{
		if (radioButton40.Checked)
		{
			scriviopzchat(1);
		}
		mio.settatooltip();
	}

	private void button9_Click_1(object sender, EventArgs e)
	{
		Offerte offerte = new Offerte();
		offerte.Text = "NewsProgramma";
		// BONIFICA 2026: pagina news 2011 morta, si usa mymovies (stessa fonte EPG)
		offerte.webBrowser1.Navigate("https://www.mymovies.it/");
		offerte.Show();
	}

	private void button10_Click_1(object sender, EventArgs e)
	{
		try
		{
			if (File.Exists(Program.pr + "\\canaliesclusipersonali.txt"))
			{
				File.Delete(Program.pr + "\\canaliesclusipersonali.txt");
			}
		}
		catch (Exception)
		{
		}
	}
}
