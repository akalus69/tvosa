// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Properties;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class ManageCanali : Form
{
	private bool mostrainvececherec = false;

	private int contatoremgupl = 0;

	private int contatoremgvd = 0;

	private string tmplinkvideo = "";

	public string linkvideodoc = "";

	public int opzrice = 0;

	public bool tubnormale = true;

	public int pg = 1;

	private bool dimensionipiu = false;

	public Form1 mio;

	// 2026-10-29: i Canali Extra (ex tasto REC EXTRA del telecomando) vivono qui.
	private System.Windows.Forms.Button buttonExtraCanali;

	private IList<string> listatotalecanali = new List<string>();

	private IList<string> listafiltricanali = new List<string>();

	private Thread TTXX;

	private Thread TTXXTV;

	private Thread TTXVPAL;

	private Thread TTXMUSIC;

	private Thread TTXMEGA;

	public IList<string> listatotale = new List<string>();

	private Thread TTXSPORTINFO;

	public PannelloRicercaTubo pannellotubo;

	private Thread TTXVPALX;

	private IList<string> listalettac = new List<string>();

	private IList<string> listareg = new List<string>();

	public bool palinsesto = true;

	public string canaleguardare = "";

	public string urlpal = "";

	public string linkmega = "";

	private IContainer components = null;

	private ListBox listBox1;

	private Label label1;

	private Button button1;

	private GroupBox groupBox1;

	private ComboBox comboBox2;

	private ComboBox comboBox1;

	private Label label2;

	private GroupBox groupBox2;

	private Label label3;

	private Button button2;

	private Label label6;

	private ComboBox comboBox3;

	private Label label5;

	private TextBox textBox2;

	private Label label4;

	private TextBox textBox1;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem rimuovereToolStripMenuItem;

	private Button button3;

	public ProgressBar progressBar1;

	private Button button4;

	private GroupBox groupBox3;

	private Button button5;

	private Label label7;

	private TextBox textBox3;

	private Button button7;

	private CheckBox checkBox1;

	private Label label8;

	private ComboBox comboBox4;

	public Button button6;

	private ComboBox comboBox5;

	private Label label9;

	private Label label10;

	private ComboBox comboBox6;

	private CheckBox checkBox2;

	private Label label11;

	private GroupBox groupBox4;

	private GroupBox groupBox5;

	private Button button8;

	public ListBox listBox2;

	private Label label12;

	public ProgressBar progressBar2;

	public ListBox listBox3;

	private WebBrowser webBrowser1;

	private Button button9;

	private Button button11;

	private GroupBox groupBox6;

	public CheckBox checkBox3;

	private Button button12;

	private Button button13;

	private GroupBox groupBox7;

	private Button button14;

	public ProgressBar progressBar3;

	private Button button15;

	private CheckBox checkBox4;

	private Button button16;

	private TabPage tabPage1;

	public TabControl tabControl1;

	public TabPage tabPage2;

	private GroupBox groupBox8;

	private Button button17;

	private Label label13;

	private Button button18;

	private TabPage tabPage3;

	private GroupBox groupBox10;

	private Button button19;

	private GroupBox groupBox9;

	private PictureBox pictureBox1;

	private Button button20;

	private Label label14;

	public TextBox textBox4;

	private GroupBox groupBox11;

	private Button button21;

	private GroupBox groupBox13;

	private GroupBox groupBox12;

	public RadioButton radioButton2;

	public RadioButton radioButton1;

	public RadioButton radioButton4;

	public RadioButton radioButton3;

	public CheckBox checkBox5;

	public Panel panel1;

	public Button button10;

	private StatusStrip statusStrip1;

	private ToolStripSplitButton toolStripSplitButton1;

	private ToolStripMenuItem ricercaPiùVistiToolStripMenuItem;

	private ToolStripMenuItem categorieToolStripMenuItem;

	private ToolStripMenuItem sportToolStripMenuItem;

	private ToolStripMenuItem umorismoToolStripMenuItem;

	private ToolStripMenuItem autoEVeicoliToolStripMenuItem;

	private ToolStripMenuItem educativiToolStripMenuItem;

	private ToolStripMenuItem intrattenimentoToolStripMenuItem;

	private ToolStripMenuItem filmToolStripMenuItem;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripMenuItem giochiToolStripMenuItem;

	private ToolStripMenuItem faiDaTeEStileToolStripMenuItem;

	private ToolStripMenuItem scienzeETecnologieToolStripMenuItem;

	private ToolStripMenuItem notizieEPoliticaToolStripMenuItem;

	private ToolStripMenuItem animaliToolStripMenuItem;

	private ToolStripMenuItem viaggiEdEventiToolStripMenuItem;

	private ToolStripMenuItem personeEBlogToolStripMenuItem;

	private ToolStripMenuItem creaListaRimozioneToolStripMenuItem;

	private TabPage tabPage4;

	private GroupBox groupBox14;

	private Button button23;

	private Button button22;

	public ListBox listBox4;

	private Label label15;

	public TextBox textBox5;

	public ProgressBar progressBar4;

	private TabPage tabPage5;

	private GroupBox groupBox16;

	private GroupBox groupBox15;

	private Button button25;

	private Label label17;

	private Button button26;

	private Button button24;

	private Label label16;

	public ProgressBar progressBar5;

	public ProgressBar progressBar6;

	private Button button28;

	private Button button27;

	public TextBox textBox7;

	public TextBox textBox6;

	private Button button29;

	public Label label19;

	public Label label18;

	private Button button30;

	private ContextMenuStrip contextMenuStrip2;

	private ToolStripMenuItem registraProgrammaSelezionatoToolStripMenuItem;

	private SplitContainer splitContainer1;

	private ToolStripMenuItem faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem;

	private TabPage tabPage6;

	private GroupBox groupBox17;

	public Label label20;

	private Button button33;

	private Label label21;

	public TextBox textBox8;

	private Button button32;

	private GroupBox groupBox18;

	public Label label22;

	private Button button34;

	private Label label23;

	public TextBox textBox9;

	private Button button31;

	public ProgressBar progressBar7;

	private ToolStripMenuItem rimuovereCanaleSelezionatoPerSempreToolStripMenuItem;

	private Button button35;

	private Button button36;

	public ManageCanali(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	// 2026-10-29: apre la finestra Canali Extra (RecTv), prima raggiungibile
	// solo dal tasto REC EXTRA del telecomando, ora spostata qui dentro.
	private void buttonExtraCanali_Click(object sender, EventArgs e)
	{
		try
		{
			RecTv recTv = new RecTv(mio);
			recTv.Show();
		}
		catch
		{
		}
	}

	private void groupBox1_Enter(object sender, EventArgs e)
	{
	}

	private void label3_Click(object sender, EventArgs e)
	{
	}

	public void filtra(string wex)
	{
		try
		{
			foreach (string item in listatotale)
			{
				if (item.ToLowerInvariant().IndexOf(wex.ToLowerInvariant()) >= 0)
				{
					listBox4.Items.Add(item);
				}
			}
		}
		catch
		{
		}
	}

	private void leggimioc()
	{
		try
		{
			listBox1.Items.Clear();
			listatotalecanali.Clear();
		}
		catch
		{
		}
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\propriotel.txt");
			string text = "";
			while ((text = streamReader.ReadLine()) != null)
			{
				listBox1.Items.Add(text);
				listatotalecanali.Add(text);
			}
			streamReader.Close();
		}
		catch
		{
		}
	}

	private void scrivimioc()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\propriotel.txt");
			string text = "";
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

	public void leggimionvc()
	{
		try
		{
			comboBox1.Items.Clear();
		}
		catch
		{
		}
		try
		{
			List<string> list = new List<string>();
			try
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\canaliesclusi.txt");
				string text = "";
				while ((text = streamReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				streamReader.Close();
			}
			catch (Exception)
			{
			}
			try
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\canaliesclusipersonali.txt");
				string text = "";
				while ((text = streamReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				streamReader.Close();
			}
			catch (Exception)
			{
			}
			StreamReader streamReader2 = new StreamReader(Program.pr + "\\nuovicanali.txt");
			string text2 = "";
			int num = 0;
			while ((text2 = streamReader2.ReadLine()) != null)
			{
				string item = streamReader2.ReadLine();
				if (!list.Contains(item))
				{
					comboBox1.Items.Add(text2);
					num++;
				}
			}
			num += 6;
			label2.Text = "Canale (totale attuale --> " + num + ")";
			label13.Text = num.ToString();
			streamReader2.Close();
			if (num > listBox1.Items.Count)
			{
				button6.BackColor = Color.Red;
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

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + mio.linguaprogramma + "MANAGE.txt");
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
			if (text2.IndexOf("groupBox4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox4.Text = text3;
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
			if (text2.IndexOf("groupBox7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox7.Text = text3;
			}
			if (text2.IndexOf("groupBox8") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("groupBox8"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				groupBox8.Text = text3;
			}
			if (text2.IndexOf("label1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label1.Text = text3;
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
			if (text2.IndexOf("label7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label7.Text = text3;
			}
			if (text2.IndexOf("label10") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label10"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label10.Text = text3;
			}
			if (text2.IndexOf("label11") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label11"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label11.Text = text3;
			}
			if (text2.IndexOf("label12") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label12"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label12.Text = text3;
			}
			if (text2.IndexOf("label13") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("label13"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				label13.Text = text3;
			}
			if (text2.IndexOf("button1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button1.Text = text3;
			}
			if (text2.IndexOf("button6") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button6"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button6.Text = text3;
			}
			if (text2.IndexOf("button2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button2.Text = text3;
			}
			if (text2.IndexOf("button3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button3.Text = text3;
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
			if (text2.IndexOf("button7") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button7"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button7.Text = text3;
			}
			if (text2.IndexOf("button13") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button13"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button13.Text = text3;
			}
			if (text2.IndexOf("button8") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button8"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button8.Text = text3;
			}
			if (text2.IndexOf("button9") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button9"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button9.Text = text3;
			}
			if (text2.IndexOf("button10") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button10"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button10.Text = text3;
			}
			if (text2.IndexOf("button11") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button11"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button11.Text = text3;
			}
			if (text2.IndexOf("button12") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button12"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button12.Text = text3;
			}
			if (text2.IndexOf("button14") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button14"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button14.Text = text3;
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
			if (text2.IndexOf("tabPage1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("tabPage1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				tabPage1.Text = text3;
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
			if (text2.IndexOf("checkBox3") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox3"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox3.Text = text3;
			}
			if (text2.IndexOf("checkBox2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox2.Text = text3;
			}
			if (text2.IndexOf("checkBox4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("checkBox4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				checkBox4.Text = text3;
			}
		}
		catch
		{
		}
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

	public void settatabgiusto()
	{
		tabControl1.SelectedTab = tabPage2;
	}

	private void scriviconf()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\conftubo");
			streamWriter.WriteLine(tabControl1.SelectedIndex.ToString());
			streamWriter.WriteLine(checkBox5.Checked.ToString());
			streamWriter.WriteLine(radioButton1.Checked.ToString());
			streamWriter.WriteLine(radioButton3.Checked.ToString());
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
	}

	private void leggiconftubo()
	{
		try
		{
			if (File.Exists(Program.pr + "\\conftubo"))
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\conftubo");
				string s = streamReader.ReadLine();
				int selectedIndex = int.Parse(s);
				tabControl1.SelectedIndex = selectedIndex;
				s = streamReader.ReadLine();
				bool flag = bool.Parse(s);
				checkBox5.Checked = flag;
				s = streamReader.ReadLine();
				flag = bool.Parse(s);
				radioButton1.Checked = flag;
				radioButton2.Checked = !flag;
				s = streamReader.ReadLine();
				flag = bool.Parse(s);
				radioButton3.Checked = flag;
				radioButton4.Checked = !flag;
			}
			else
			{
				scriviconf();
			}
		}
		catch (Exception)
		{
		}
	}

	private void ManageCanali_Load(object sender, EventArgs e)
	{
		try
		{
			if (!mio.root)
			{
				creaListaRimozioneToolStripMenuItem.Visible = false;
			}
			pannellotubo = new PannelloRicercaTubo(this);
			panel1.Controls.Add(pannellotubo);
			pannellotubo.Visible = false;
			panel1.Visible = false;
			leggiconftubo();
			if (File.Exists(Program.pr + "\\aggcanalesi"))
			{
				button5.Enabled = true;
			}
			if (File.Exists(Program.pr + "\\avvisaqnd"))
			{
				checkBox4.Checked = true;
			}
			cambialing();
			button10.BackColor = Color.Aqua;
			webBrowser1.ScriptErrorsSuppressed = true;
			mostrawbpal(0);
			leggimioc();
			leggimionvc();
			leggipal();
			for (int i = 0; i <= 900; i++)
			{
				comboBox2.Items.Add(i.ToString());
				comboBox3.Items.Add(i.ToString());
			}
			comboBox4.SelectedIndex = 0;
			partiprogr();
			if (File.Exists(Program.pr + "\\autoagg"))
			{
				partiagg();
			}
		}
		catch (Exception)
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			string text = comboBox1.SelectedItem.ToString();
			string text2 = comboBox2.SelectedItem.ToString();
			int num = 0;
			foreach (object item in listBox1.Items)
			{
				string text3 = item.ToString();
				text3 = text3.Substring(0, text3.IndexOf(" "));
				if (text3 == text2)
				{
					break;
				}
				num++;
			}
			if (listBox1.Items.Count != num)
			{
				listBox1.Items.Remove(listBox1.Items[num]);
			}
			List<string> list = new List<string>();
			foreach (object item2 in listBox1.Items)
			{
				list.Add(item2.ToString());
			}
			list.Add(text2 + " " + text);
			list = listaordinata(list);
			listBox1.Items.Clear();
			foreach (string item3 in list)
			{
				listBox1.Items.Add(item3);
			}
			scrivimioc();
		}
		catch
		{
		}
	}

	private List<string> listaordinata(List<string> ls)
	{
		for (int i = 0; i < ls.Count; i++)
		{
			for (int j = 0; j < ls.Count; j++)
			{
				int num = int.Parse(ls[i].Substring(0, ls[i].IndexOf(" ")));
				int num2 = int.Parse(ls[j].Substring(0, ls[j].IndexOf(" ")));
				if (num2 > num)
				{
					string value = ls[i];
					ls[i] = ls[j];
					ls[j] = value;
				}
			}
		}
		return ls;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			if (!File.Exists(Program.pr + "\\aggcanalesi"))
			{
				File.Create(Program.pr + "\\aggcanalesi");
				button5.Enabled = true;
			}
			textBox3.Text = "";
			string text = textBox1.Text;
			string text2 = textBox2.Text;
			string text3 = comboBox3.SelectedItem.ToString();
			string text4 = comboBox5.SelectedItem.ToString();
			text2 = "(" + text4 + ") " + text2;
			int num = 0;
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2))
			{
				return;
			}
			try
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\nuovicanali.txt", append: true);
				streamWriter.WriteLine(text2);
				if (comboBox4.SelectedIndex == 0)
				{
					streamWriter.WriteLine(text);
				}
				else
				{
					streamWriter.WriteLine("http:\\webtv\\|<-->|" + text);
				}
				streamWriter.Close();
			}
			catch
			{
			}
			foreach (object item in listBox1.Items)
			{
				string text5 = item.ToString();
				text5 = text5.Substring(0, text5.IndexOf(" "));
				if (text5 == text3)
				{
					break;
				}
				num++;
			}
			if (listBox1.Items.Count != num)
			{
				listBox1.Items.Remove(listBox1.Items[num]);
			}
			List<string> list = new List<string>();
			foreach (object item2 in listBox1.Items)
			{
				list.Add(item2.ToString());
			}
			list.Add(text3 + " " + text2);
			list = listaordinata(list);
			listBox1.Items.Clear();
			foreach (string item3 in list)
			{
				listBox1.Items.Add(item3);
			}
			scrivimioc();
			button6.BackColor = Color.Red;
			comboBox1.Items.Add(text2);
		}
		catch
		{
			MessageBox.Show("canale non aggiunto, prego completare tutti i campi prima di inserirlo");
		}
	}

	private void rimuovereToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			textBox3.Text = "";
			leggimioc();
			for (int i = 0; i < listBox1.Items.Count; i++)
			{
				string text2 = listBox1.Items[i].ToString();
				if (text2 == text)
				{
					listBox1.Items.Remove(listBox1.Items[i]);
					break;
				}
			}
			scrivimioc();
			leggimioc();
		}
		catch
		{
		}
	}

	private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			mio.label1.Text = text.Substring(0, text.IndexOf(" "));
			try
			{
				mio.canaleselezionato = int.Parse(mio.label1.Text);
			}
			catch (Exception)
			{
			}
			mio.aspettasionoperpartirefilm = true;
			mio.partiriccan();
		}
		catch
		{
		}
	}

	public void trovaora()
	{
		try
		{
			int num = 0;
			ListBox listBox = ((!palinsesto) ? listBox3 : listBox2);
			foreach (object item in listBox.Items)
			{
				string text = item.ToString();
				string text2 = text.Substring(0, text.IndexOf("-") - 1).Replace(".", ":");
				text2 = text2.Replace("Ore ", "");
				text2 = text2.Replace("Ora ", "");
				int num2 = int.Parse(text2.Substring(0, text2.IndexOf(":")));
				int num3 = int.Parse(text2.Substring(text2.IndexOf(":") + 1));
				DateTime now = DateTime.Now;
				if (num2 < 5 || now.Hour >= 5)
				{
					if (num2 < 5 && now.Hour >= 5)
					{
						break;
					}
					if (now.Hour == num2)
					{
						if (now.Minute < num3)
						{
							break;
						}
					}
					else if (now.Hour < num2)
					{
						break;
					}
				}
				num++;
			}
			if (num > 0)
			{
				num--;
			}
			if (palinsesto)
			{
				listBox2.SelectedItem = listBox2.Items[num];
				return;
			}
			listBox2.Items.Add("*** " + canaleguardare + " ***");
			listBox2.Items.Add("PROGRAMMA ATTUALE --> " + listBox.Items[num]);
			if (num + 1 < listBox.Items.Count)
			{
				listBox2.Items.Add("A SEGUIRE --> " + listBox.Items[num + 1]);
				if (num + 2 < listBox.Items.Count)
				{
					listBox2.Items.Add("A SEGUIRE --> " + listBox.Items[num + 2]);
				}
			}
			listBox2.Items.Add("");
		}
		catch
		{
		}
	}

	public void trovaora(bool txs)
	{
		try
		{
			int num = 0;
			ListBox listBox = ((!palinsesto) ? listBox3 : listBox2);
			foreach (object item in listBox.Items)
			{
				string text = item.ToString();
				string text2 = text.Substring(0, text.IndexOf("-") - 1).Replace(".", ":");
				text2 = text2.Replace("Ore ", "");
				text2 = text2.Replace("Ora ", "");
				int num2 = int.Parse(text2.Substring(0, text2.IndexOf(":")));
				int num3 = int.Parse(text2.Substring(text2.IndexOf(":") + 1));
				DateTime now = DateTime.Now;
				if (num2 < 5 || now.Hour >= 5)
				{
					if (txs && num2 < 5 && now.Hour >= 5)
					{
						break;
					}
					if (now.Hour == num2)
					{
						if (now.Minute < num3)
						{
							break;
						}
					}
					else if (now.Hour < num2)
					{
						break;
					}
				}
				num++;
			}
			if (num > 0)
			{
				num--;
			}
			if (palinsesto)
			{
				listBox2.SelectedItem = listBox2.Items[num];
				return;
			}
			listBox2.Items.Add("*** " + canaleguardare + " ***");
			listBox2.Items.Add("PROGRAMMA ATTUALE --> " + listBox.Items[num]);
			if (num + 1 < listBox.Items.Count)
			{
				listBox2.Items.Add("A SEGUIRE --> " + listBox.Items[num + 1]);
				if (num + 2 < listBox.Items.Count)
				{
					listBox2.Items.Add("A SEGUIRE --> " + listBox.Items[num + 2]);
				}
			}
			listBox2.Items.Add("");
		}
		catch
		{
		}
	}

	private void trovapalinsesto(string stringaric)
	{
		try
		{
			mostrawbpal(0);
			progressBar2.Value = 0;
			progressBar2.Maximum = 3;
			if (stringaric.ToLowerInvariant() == "(sport) sport italia" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/sportitalia/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(musica) virgin radio tv" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/virginradiotv/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(rai) rai 4" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rai4/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(rai) rai 5" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rai5/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(sport) euro sport" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/eurosport/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(regionale) primo canale" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vaiprimocanale);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(mediaset) la 5" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/la5/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(regionale) retesole " && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vairetesoleumbria);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(regionale) rete sole roma" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					Thread thread = new Thread(threadAltriCanali.vairetesoleroma);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(rai) rai 1" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiuno/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(rai) rai 2" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raidue/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(rai) rai 3" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raitre/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(mediaset) rete 4" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rete4/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) la 7 " && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/la7/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) rsi la 1" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://la1.rsi.ch/home/networks/la1/palinsesto.html";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) rsi la 2" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://la2.rsi.ch/home/networks/la2/palinsesto.html";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(musica) deejay tv" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/deejaytv/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) odeon tv" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/odeon/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) cielo" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/cielo/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(mediaset) canale 5" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/canale5/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			// RINASCITA 2026: canali con guida mymovies ritrovata
			if (stringaric.ToLowerInvariant() == "(religione) tv2000" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/tv2000/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(mediaset) focus" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/focus/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(mediaset) italia 1" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/italia1/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) 7 gold" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/7gold/";
					Thread thread = new Thread(threadAltriCanali.vaitutti);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(divertimento) rai sat yoyo" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatyoyo/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(cinema) rai cinema" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatcinema/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(sport) rai sport" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisport1/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(notiziari) rai news 24" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/rainews24/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(rai) raisat premium" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatpremium/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(cultura) rai storia" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raistoria/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(cultura) rai scuola" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raiscuola/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(divertimento) rai gulp" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raigulp/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) tv 2000" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/sat2000/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(generalista) la 7" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/la7/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			if (stringaric.ToLowerInvariant() == "(rai) rai sat extra" && palinsesto)
			{
				try
				{
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					urlpal = "http://www.mymovies.it/tv/raisatextra/";
					TTXVPAL = new Thread(threadAltriCanali.vaitutti);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
					return;
				}
				catch
				{
					return;
				}
			}
			string text = leggipalinternet(listBox1.SelectedItem.ToString());
			listBox2.Items.Clear();
			if (text != "")
			{
				mostrawbpal(1);
				if (dimensionipiu)
				{
					Size = new Size(929, 701);
				}
				webBrowser1.Navigate(text);
				listBox2.Items.Add("Palinsesto per il canale " + stringaric + " nel box sottostante");
				return;
			}
			mostrawbpal(0);
			bool flag = false;
			try
			{
				StreamReader streamReader = new StreamReader(Program.pr + "\\nuovicanali.txt");
				string text2 = streamReader.ReadToEnd();
				streamReader.Close();
				string text3 = listBox1.SelectedItem.ToString();
				text3 = text3.Substring(text3.IndexOf(" ") + 1);
				text2 = text2.Substring(text2.IndexOf(text3));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text4 = text2.Substring(0, text2.IndexOf(Environment.NewLine));
				if (text4.IndexOf("justin.tv") >= 0)
				{
					text4 = text4.Substring(text4.IndexOf("justin.tv"));
					text4 = "http://" + text4;
					canaleguardare = text3;
					urlpal = text4;
					flag = true;
					ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
					TTXVPAL = new Thread(threadAltriCanali.faipartireprogrammazionejustin);
					TTXVPAL.IsBackground = true;
					TTXVPAL.Priority = ThreadPriority.BelowNormal;
					TTXVPAL.Start();
				}
			}
			catch
			{
			}
			if (!flag)
			{
				Size = new Size(929, 572);
				listBox2.Items.Add("Palinsesto per il canale ricercato non ancora disponibile.");
				listBox2.Items.Add("Prego ricercarlo in internet con l'apposito tasto");
				listBox2.Items.Add("\"CERCA PALINSESTO INTERNET\"");
			}
		}
		catch
		{
		}
	}

	private string leggipalinternet(string parola)
	{
		string result = "";
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\palinternet");
			string text = "";
			parola = parola.Substring(parola.IndexOf("("));
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text.CompareTo(parola) == 0)
				{
					text = streamReader.ReadLine();
					result = text;
				}
			}
			streamReader.Close();
		}
		catch
		{
		}
		return result;
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				webBrowser1.Visible = false;
			if (!checkBox2.Checked)
			{
				return;
			}
			try
			{
				if (TTXXTV.IsAlive)
				{
					TTXXTV.Abort();
				}
			}
			catch
			{
			}
			try
			{
				if (TTXVPAL.IsAlive)
				{
					TTXVPAL.Abort();
				}
			}
			catch
			{
			}
			trovapalinsesto(listBox1.SelectedItem.ToString().Substring(listBox1.SelectedItem.ToString().IndexOf("(")));
			string text = listBox1.SelectedItem.ToString();
			text = text.Substring(text.IndexOf(")") + 1);
			label12.Text = text;
		}
		catch
		{
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		partiagg();
	}

	private void button4_Click(object sender, EventArgs e)
	{
		try
		{
			Process.Start(Program.pr + "\\nuovicanali.txt");
		}
		catch
		{
		}
	}

	private void button5_Click(object sender, EventArgs e)
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

	private void button6_Click(object sender, EventArgs e)
	{
		leggimionvc();
		button6.BackColor = Color.Green;
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\propriotel.txt");
			string text = "";
			int num = 7;
			streamWriter.WriteLine("1 (Rai) Rai 1");
			streamWriter.WriteLine("2 (Rai) Rai 2");
			streamWriter.WriteLine("3 (Rai) Rai 3");
			streamWriter.WriteLine("4 (Mediaset) Rete 4");
			streamWriter.WriteLine("5 (Mediaset) Canale 5");
			streamWriter.WriteLine("6 (Mediaset) Italia 1");
			IList<object> list = new List<object>();
			foreach (object item in comboBox1.Items)
			{
				if (item.ToString().IndexOf("(Mediaset)") >= 0)
				{
					list.Add(item);
				}
			}
			foreach (object item2 in comboBox1.Items)
			{
				if (item2.ToString().IndexOf("(Rai)") >= 0)
				{
					list.Add(item2);
				}
			}
			foreach (object item3 in comboBox1.Items)
			{
				if (item3.ToString().IndexOf("(Sport)") >= 0)
				{
					list.Add(item3);
				}
			}
			foreach (object item4 in comboBox1.Items)
			{
				if (item4.ToString().IndexOf("(Cinema)") >= 0)
				{
					list.Add(item4);
				}
			}
			foreach (object item5 in comboBox1.Items)
			{
				if (item5.ToString().IndexOf("(Divertimento)") >= 0)
				{
					list.Add(item5);
				}
			}
			foreach (object item6 in comboBox1.Items)
			{
				if (item6.ToString().IndexOf("(Generalista)") >= 0)
				{
					list.Add(item6);
				}
			}
			foreach (object item7 in comboBox1.Items)
			{
				if (item7.ToString().IndexOf("(Regionale)") >= 0)
				{
					list.Add(item7);
				}
			}
			foreach (object item8 in comboBox1.Items)
			{
				if (item8.ToString().IndexOf("(Musica)") >= 0)
				{
					list.Add(item8);
				}
			}
			foreach (object item9 in comboBox1.Items)
			{
				if (item9.ToString().IndexOf("(Notiziari)") >= 0)
				{
					list.Add(item9);
				}
			}
			foreach (object item10 in comboBox1.Items)
			{
				if (item10.ToString().IndexOf("(Cultura)") >= 0)
				{
					list.Add(item10);
				}
			}
			foreach (object item11 in comboBox1.Items)
			{
				if (item11.ToString().IndexOf("(Meteo)") >= 0)
				{
					list.Add(item11);
				}
			}
			foreach (object item12 in comboBox1.Items)
			{
				if (item12.ToString().IndexOf("(Tecnologia)") >= 0)
				{
					list.Add(item12);
				}
			}
			foreach (object item13 in comboBox1.Items)
			{
				if (item13.ToString().IndexOf("(Moda)") >= 0)
				{
					list.Add(item13);
				}
			}
			foreach (object item14 in comboBox1.Items)
			{
				if (item14.ToString().IndexOf("(Documentari)") >= 0)
				{
					list.Add(item14);
				}
			}
			foreach (object item15 in comboBox1.Items)
			{
				if (item15.ToString().IndexOf("(Arte)") >= 0)
				{
					list.Add(item15);
				}
			}
			foreach (object item16 in comboBox1.Items)
			{
				if (item16.ToString().IndexOf("(Televendita)") >= 0)
				{
					list.Add(item16);
				}
			}
			foreach (object item17 in comboBox1.Items)
			{
				if (item17.ToString().IndexOf("(Eventi)") >= 0)
				{
					list.Add(item17);
				}
			}
			foreach (object item18 in comboBox1.Items)
			{
				if (item18.ToString().IndexOf("(Religione)") >= 0)
				{
					list.Add(item18);
				}
			}
			foreach (object item19 in comboBox1.Items)
			{
				if (item19.ToString().IndexOf("(Fiera)") >= 0)
				{
					list.Add(item19);
				}
			}
			foreach (object item20 in comboBox1.Items)
			{
				if (item20.ToString().IndexOf("(Esteri)") >= 0)
				{
					list.Add(item20);
				}
			}
			foreach (object item21 in comboBox1.Items)
			{
				if (item21.ToString().IndexOf("(Hot)") >= 0)
				{
					list.Add(item21);
				}
			}
			foreach (object item22 in comboBox1.Items)
			{
				if (item22.ToString().IndexOf("(WebCam)") >= 0)
				{
					list.Add(item22);
				}
			}
			foreach (object item23 in comboBox1.Items)
			{
				if (item23.ToString().IndexOf("(Radio)") >= 0)
				{
					list.Add(item23);
				}
			}
			foreach (object item24 in comboBox1.Items)
			{
				bool flag = false;
				foreach (object item25 in list)
				{
					if (item24 == item25)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					list.Add(item24);
				}
			}
			foreach (object item26 in list)
			{
				streamWriter.WriteLine(num + " " + item26.ToString());
				num++;
			}
			streamWriter.Close();
			leggimioc();
		}
		catch
		{
		}
	}

	private void textBox3_TextChanged(object sender, EventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(textBox3.Text))
			{
				leggimioc();
				return;
			}
			string text = textBox3.Text;
			listBox1.Items.Clear();
			foreach (string item in listatotalecanali)
			{
				if (item.ToLowerInvariant().IndexOf(text.ToLowerInvariant()) >= 0)
				{
					listBox1.Items.Add(item);
				}
			}
		}
		catch
		{
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Substring(text.IndexOf(")") + 2);
				text = text.Replace(" ", "+");
				Process.Start("http://www.google.it/search?hl=it&source=hp&q=" + text + "+palinsesto&meta=&aq=f&oq=");
			}
			else
			{
				MessageBox.Show("Prima devi selezionare il canale per cui vuoi cercare il palinsesto");
			}
		}
		catch
		{
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (checkBox1.Checked)
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

	private void listBox1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyData.ToString() == "Space" || e.KeyData.ToString() == "Return")
		{
			listBox1_MouseDoubleClick(sender, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
		}
	}

	private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string text = comboBox6.SelectedItem.ToString();
			textBox3.Text = text;
		}
		catch
		{
		}
	}

	private void groupBox4_Enter(object sender, EventArgs e)
	{
	}

	private void label7_Click(object sender, EventArgs e)
	{
	}

	public void leggipal()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\palmanagecan");
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

	public void scrivipal()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\palmanagecan");
			if (checkBox2.Checked)
			{
				palinsesto = true;
				streamWriter.WriteLine("1");
			}
			else
			{
				palinsesto = false;
				mostrawbpal(0);
				listBox2.Items.Clear();
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
		scrivipal();
	}

	private void ManageCanali_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			TTXVPAL.Abort();
		}
		catch
		{
		}
		try
		{
			TTXX.Abort();
		}
		catch
		{
		}
	}

	private void button8_Click(object sender, EventArgs e)
	{
		webBrowser1.Visible = false;
		try
		{
			TTXVPAL.Abort();
		}
		catch
		{
		}
		try
		{
			checkBox2.Checked = false;
			progressBar2.Value = 0;
		}
		catch
		{
		}
		try
		{
			palinsesto = false;
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			urlpal = "http://www.mymovies.it/tv/raisatextra/";
			TTXVPAL = new Thread(threadAltriCanali.vaiemostraprogrammitv);
			TTXVPAL.IsBackground = true;
			TTXVPAL.Priority = ThreadPriority.BelowNormal;
			TTXVPAL.Start();
			listBox2.Items.Clear();
		}
		catch
		{
		}
	}

	private void mostrawbpal(int o)
	{
		if (o == 0)
		{
			webBrowser1.Visible = false;
			button9.Visible = false;
			button10.Visible = false;
			button11.Visible = false;
		}
		else
		{
			webBrowser1.Navigate("");
			webBrowser1.Visible = true;
			button9.Visible = true;
			button10.Visible = true;
			button11.Visible = true;
		}
	}

	private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void mettifiltro(string str)
	{
		try
		{
			string text = str;
			if (text.IndexOf("***") >= 0)
			{
				text = text.Substring(text.IndexOf("***") + 4);
				text = text.Substring(0, text.IndexOf("*") - 1);
				textBox3.Text = text;
			}
		}
		catch
		{
		}
	}

	private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			bool flag = false;
			string text = listBox2.SelectedItem.ToString();
			if (text.IndexOf("PROGRAMMA ATTUALE") >= 0)
			{
				text = listBox2.Items[listBox2.SelectedIndex - 1].ToString();
				flag = true;
			}
			if ((text.IndexOf("Rete 4") <= 0 && text.IndexOf("Canale 5") <= 0 && text.IndexOf("Italia 1") <= 0) || flag)
			{
				mettifiltro(text);
				if (flag && listBox2.Items.Count > 0)
				{
					listBox1.SelectedIndex = 0;
					listBox1_MouseDoubleClick(sender, e);
				}
			}
			else
			{
				mettifiltro("*** Mediaset ***");
			}
		}
		catch
		{
		}
	}

	private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
	{
	}

	private void button10_Click(object sender, EventArgs e)
	{
		tabControl1.Visible = true;
		button10.BackColor = Color.Aqua;
		button11.BackColor = Color.White;
		button9.BackColor = Color.White;
		dimensionipiu = false;
		Size = new Size(920, 514);
		webBrowser1.Location = new Point(449, 25);
		webBrowser1.Size = new Size(441, 198);
	}

	private void button9_Click(object sender, EventArgs e)
	{
		tabControl1.Visible = false;
		button9.BackColor = Color.Aqua;
		button10.BackColor = Color.White;
		button11.BackColor = Color.White;
		dimensionipiu = false;
		Size = new Size(920, 601);
		webBrowser1.Location = new Point(10, 25);
		webBrowser1.Size = new Size(883, 520);
	}

	private void button11_Click(object sender, EventArgs e)
	{
		tabControl1.Visible = false;
		button11.BackColor = Color.Aqua;
		button10.BackColor = Color.White;
		button9.BackColor = Color.White;
		dimensionipiu = true;
		Size = new Size(920, 701);
		webBrowser1.Location = new Point(10, 229);
		webBrowser1.Size = new Size(883, 420);
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
		mio.multipliwebtv = checkBox3.Checked;
	}

	private void button12_Click(object sender, EventArgs e)
		{
			// BONIFICA 2026-10-28: Extra_Canali (re-stream pirata) rimosso.
			MessageBox.Show("Sezione \"Canali Extra\" rimossa: conteneva sorgenti non autorizzati.");
		}

	private void button13_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox2.SelectedItem.ToString();
			if (!string.IsNullOrEmpty(text) && text.IndexOf(":") > 0)
			{
				text = text.Substring(text.LastIndexOf(":") + 2);
				try
				{
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\extraspecialtv", append: true);
					streamWriter.WriteLine(text);
					streamWriter.Close();
					MessageBox.Show("Steraming inserito --> " + text + Environment.NewLine + "Ricorda che puoi visualizzare le parole inserite in Opzioni-->Setta \"Avvisa quando si vede in TV...\"");
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

	private void groupBox5_Enter(object sender, EventArgs e)
	{
	}

	private void button14_Click(object sender, EventArgs e)
	{
		mio.creagioco();
	}

	private void button15_Click(object sender, EventArgs e)
	{
		Avvisa_quando_si_vede_in_Tv avvisa_quando_si_vede_in_Tv = new Avvisa_quando_si_vede_in_Tv(mio);
		avvisa_quando_si_vede_in_Tv.Show();
	}

	private void button17_Click(object sender, EventArgs e)
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

	private void button16_Click(object sender, EventArgs e)
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
			ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(mio);
			TTXVPALX = new Thread(threadSimileAltriCanali.vaiemostraprogrammitv2);
			TTXVPALX.IsBackground = true;
			TTXVPALX.Priority = ThreadPriority.BelowNormal;
			TTXVPALX.Start();
		}
		catch
		{
		}
	}

	private void button18_Click(object sender, EventArgs e)
	{
		settatabgiusto();
	}

	private void checkBox4_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (checkBox4.Checked)
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
					return;
				}
				catch
				{
					return;
				}
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

	private void button18_Click_1(object sender, EventArgs e)
	{
		try
		{
			Zapping zapping = new Zapping(mio);
			zapping.Show();
		}
		catch (Exception)
		{
		}
	}

	private void button19_Click(object sender, EventArgs e)
	{
		try
		{
			// BONIFICA 2026: il vecchio sito dell'autore 2011 non esiste piu'.
			MessageBox.Show("Il vecchio sito di TVOSA (2011) non esiste piu': il progetto e' riesumato nel 2026 su GitHub.");
		}
		catch (Exception)
		{
		}
	}

	private void button20_Click(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(textBox4.Text))
			{
				pg = 1;
				tubnormale = true;
				ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
				TTXMUSIC = new Thread(threadAltriCanali.cercamusica);
				TTXMUSIC.IsBackground = true;
				TTXMUSIC.Priority = ThreadPriority.BelowNormal;
				TTXMUSIC.Start();
			}
		}
		catch
		{
		}
	}

	private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			scriviconf();
			if (tabControl1.SelectedIndex == 3 && listBox4.Items.Count == 0)
			{
				button22_Click_1(sender, e);
			}
		}
		catch (Exception)
		{
		}
	}

	private void checkBox5_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			scriviconf();
		}
		catch (Exception)
		{
		}
	}

	private void radioButton1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			scriviconf();
		}
		catch (Exception)
		{
		}
	}

	private void radioButton2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			scriviconf();
		}
		catch (Exception)
		{
		}
	}

	private void radioButton4_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			scriviconf();
		}
		catch (Exception)
		{
		}
	}

	private void radioButton3_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			scriviconf();
		}
		catch (Exception)
		{
		}
	}

	private void button21_Click(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(textBox4.Text))
			{
				pg = 1;
				opzrice = 0;
				tubnormale = false;
				pannellotubo.label1.Text = "1";
				ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
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

	private void button22_Click(object sender, EventArgs e)
	{
	}

	private void button23_Click(object sender, EventArgs e)
	{
	}

	private void ricercaPiùVistiToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 1;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void sportToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 2;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void umorismoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 3;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void autoEVeicoliToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 4;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void educativiToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 5;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void intrattenimentoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 6;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void filmToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 7;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void giochiToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 8;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void faiDaTeEStileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 9;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void scienzeETecnologieToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 10;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void notizieEPoliticaToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 11;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void animaliToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 12;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void viaggiEdEventiToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 13;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void personeEBlogToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			pg = 1;
			opzrice = 14;
			tubnormale = false;
			pannellotubo.label1.Text = "1";
			ThreadAltriCanali threadAltriCanali = new ThreadAltriCanali(this);
			TTXMUSIC = new Thread(threadAltriCanali.preparaschermo);
			TTXMUSIC.IsBackground = true;
			TTXMUSIC.Priority = ThreadPriority.BelowNormal;
			TTXMUSIC.Start();
		}
		catch
		{
		}
	}

	private void textBox4_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyValue.ToString() == "13")
		{
			button20_Click(sender, new EventArgs());
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void button22_Click_1(object sender, EventArgs e)
	{
		try
		{
			TTXSPORTINFO.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(mio);
			TTXSPORTINFO = new Thread(threadSimileAltriCanali.aggiornaattualmenteinonda);
			TTXSPORTINFO.IsBackground = true;
			TTXSPORTINFO.Priority = ThreadPriority.BelowNormal;
			TTXSPORTINFO.Start();
		}
		catch (Exception)
		{
		}
	}

	private void textBox5_KeyUp(object sender, KeyEventArgs e)
	{
		listBox4.Items.Clear();
		try
		{
			if (string.IsNullOrEmpty(textBox5.Text))
			{
				foreach (string item in listatotale)
				{
					listBox4.Items.Add(item);
				}
				return;
			}
			filtra(textBox5.Text);
		}
		catch
		{
		}
	}

	private void button23_Click_1(object sender, EventArgs e)
	{
		try
		{
			TTXSPORTINFO.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(mio);
			TTXSPORTINFO = new Thread(threadSimileAltriCanali.prossimamentestreaming);
			TTXSPORTINFO.IsBackground = true;
			TTXSPORTINFO.Priority = ThreadPriority.BelowNormal;
			TTXSPORTINFO.Start();
		}
		catch (Exception)
		{
		}
	}

	private void button26_Click(object sender, EventArgs e)
	
	{
		// BONIFICA 2026: MegaUpload/Megavideo chiusi nel 2012, funzione rimossa.
		MessageBox.Show("MegaUpload/Megavideo non esistono piu\' dal 2012: questa funzione e\' stata rimossa nella bonifica 2026.");
	}

	private void button28_Click(object sender, EventArgs e)
	
	{
		// BONIFICA 2026: MegaUpload/Megavideo chiusi nel 2012, funzione rimossa.
		MessageBox.Show("MegaUpload/Megavideo non esistono piu\' dal 2012: questa funzione e\' stata rimossa nella bonifica 2026.");
	}

	private void button27_Click(object sender, EventArgs e)
	
	{
		// BONIFICA 2026: MegaUpload/Megavideo chiusi nel 2012, funzione rimossa.
		MessageBox.Show("MegaUpload/Megavideo non esistono piu\' dal 2012: questa funzione e\' stata rimossa nella bonifica 2026.");
	}

	private void button29_Click(object sender, EventArgs e)
	
	{
		// BONIFICA 2026: MegaUpload/Megavideo chiusi nel 2012, funzione rimossa.
		MessageBox.Show("MegaUpload/Megavideo non esistono piu\' dal 2012: questa funzione e\' stata rimossa nella bonifica 2026.");
	}

	private void button25_Click(object sender, EventArgs e)
	
	{
		// BONIFICA 2026: MegaUpload/Megavideo chiusi nel 2012, funzione rimossa.
		MessageBox.Show("MegaUpload/Megavideo non esistono piu\' dal 2012: questa funzione e\' stata rimossa nella bonifica 2026.");
	}

	private void button29_Click_1(object sender, EventArgs e)
	{
		// BONIFICA 2026: MegaUpload/Megavideo chiusi nel 2012, funzione rimossa.
		MessageBox.Show("MegaUpload/Megavideo non esistono piu' dal 2012: questa funzione e' stata rimossa nella bonifica 2026.");
	}


	private void button24_Click(object sender, EventArgs e)
	{
		// BONIFICA 2026: MegaUpload/Megavideo chiusi nel 2012, funzione rimossa.
		MessageBox.Show("MegaUpload/Megavideo non esistono piu' dal 2012: questa funzione e' stata rimossa nella bonifica 2026.");
	}


	private void progressBar6_Click(object sender, EventArgs e)
	{
	}

	public void button30_Click(object sender, EventArgs e)
	{
		linkvideodoc = mio.TVweb.docpres;
		tmplinkvideo = mio.TVweb.docpres;
		textBox6.Text = "";
		textBox7.Text = "";
		contatoremgupl = 0;
		contatoremgvd = 0;
		label18.Text = "0";
		label19.Text = "0";
		label18.ForeColor = Color.White;
		progressBar5.Value = 0;
		progressBar6.Value = 0;
	}

	private void textBox6_TextChanged(object sender, EventArgs e)
	{
		// BONIFICA 2026: accettazione link MegaUpload/Megavideo rimossa (servizi morti nel 2012).
	}


	private void registraProgrammaSelezionatoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			bool flag = false;
			string text = "";
			try
			{
				text = listBox2.SelectedItem.ToString();
				flag = true;
			}
			catch
			{
				MessageBox.Show("Devi prima selezionare il programma da registrare");
			}
			if (flag)
			{
				if (checkBox2.Checked)
				{
					string text2 = listBox1.SelectedItem.ToString();
					text2 = text2.Substring(text2.IndexOf("("));
					string text3 = text.Substring(text.IndexOf(":") + 1);
					string text4 = text.Substring(0, text.IndexOf(":"));
					string text5 = text4.Substring(0, text4.IndexOf("-"));
					text4 = text4.Substring(text4.IndexOf("-") + 1);
					RecTv recTv = new RecTv(mio);
					recTv.normale = false;
					recTv.textBox1.Text = text5;
					recTv.textBox2.Text = text4;
					recTv.textBox3.Text = text3;
					recTv.Show();
					recTv.comboBox1.SelectedItem = text2;
					if (mostrainvececherec)
					{
						recTv.comboBox2.SelectedIndex = 1;
					}
					recTv.button1_Click(new object(), new EventArgs());
					recTv.normale = true;
				}
				else
				{
					textBox3.Text = "";
					textBox3_TextChanged(sender, e);
					string text2 = listBox2.SelectedItem.ToString();
					if (text2.IndexOf("*** ") >= 0)
					{
						MessageBox.Show("Per utilizzare questa funzionalita' devi selezionare un programma non un canale, altrimenti puoi sempre settarla a mano in REC EXTRA");
					}
					else
					{
						int num = listBox2.SelectedIndex;
						string text6 = text2;
						while (text6.IndexOf("*** ") < 0)
						{
							num--;
							text6 = listBox2.Items[num].ToString();
						}
						text2 = "";
						text6 = text6.Replace("***", "");
						text6 = text6.Trim();
						foreach (string item in listBox1.Items)
						{
							if (item.IndexOf(text6) > 0)
							{
								text2 = item;
								break;
							}
						}
						text2 = text2.Substring(text2.IndexOf("("));
						text = text.Substring(text.IndexOf("-->") + 4);
						string text3 = text.Substring(text.IndexOf(":") + 1);
						string text4 = text.Substring(0, text.IndexOf(":"));
						string text5 = text4.Substring(0, text4.IndexOf("-"));
						text4 = text4.Substring(text4.IndexOf("-") + 1);
						RecTv recTv = new RecTv(mio);
						recTv.normale = false;
						recTv.textBox1.Text = text5;
						recTv.textBox2.Text = text4;
						recTv.textBox3.Text = text3;
						recTv.Show();
						recTv.comboBox1.SelectedItem = text2;
						if (mostrainvececherec)
						{
							recTv.comboBox2.SelectedIndex = 1;
						}
						recTv.button1_Click(new object(), new EventArgs());
						recTv.normale = true;
					}
				}
			}
			mostrainvececherec = false;
		}
		catch (Exception)
		{
		}
	}

	private void faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		mostrainvececherec = true;
		registraProgrammaSelezionatoToolStripMenuItem_Click(sender, e);
	}

	private void button33_Click(object sender, EventArgs e)
	{
		if (textBox8.Text.IndexOf("novamov") >= 0)
		{
			linkmega = textBox8.Text;
			try
			{
				TTXMEGA.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				mio.TTXSCARICAREVLC.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(mio);
				TTXMEGA = new Thread(threadSimileAltriCanali.partilinknovamov);
				TTXMEGA.IsBackground = true;
				TTXMEGA.Priority = ThreadPriority.BelowNormal;
				TTXMEGA.Start();
			}
			catch (Exception)
			{
			}
		}
	}

	private void button34_Click(object sender, EventArgs e)
	{
		if (textBox9.Text.IndexOf("movshare") >= 0)
		{
			linkmega = textBox9.Text;
			try
			{
				TTXMEGA.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				mio.TTXSCARICAREVLC.Abort();
			}
			catch (Exception)
			{
			}
			try
			{
				ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(mio);
				TTXMEGA = new Thread(threadSimileAltriCanali.partilinkmovshare);
				TTXMEGA.IsBackground = true;
				TTXMEGA.Priority = ThreadPriority.BelowNormal;
				TTXMEGA.Start();
			}
			catch (Exception)
			{
			}
		}
	}

	private void rimuovereCanaleSelezionatoPerSempreToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			bool flag = false;
			if (text.IndexOf("(") > 0)
			{
				text = text.Substring(text.IndexOf("("));
			}
			StreamReader streamReader = new StreamReader(Program.pr + "\\nuovicanali.txt");
			string text2 = "";
			int num = 0;
			string value = "";
			while ((text2 = streamReader.ReadLine()) != null)
			{
				if (text2 == text)
				{
					value = streamReader.ReadLine();
					flag = true;
				}
			}
			if (flag)
			{
				StreamWriter streamWriter = new StreamWriter(Program.pr + "\\canaliesclusipersonali.txt", append: true);
				streamWriter.WriteLine(value);
				streamWriter.Close();
				button6_Click(sender, e);
			}
			else
			{
				MessageBox.Show("Mi dispiace ma non si puo' eliminare il canale selezionato");
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Mi dispiace ma non si puo' eliminare il canale selezionato");
		}
	}

	private void button35_Click(object sender, EventArgs e)
	{
		Telegiornali telegiornali = new Telegiornali(mio);
		telegiornali.Show();
	}

	private void button31_Click(object sender, EventArgs e)
	{
		try
		{
			if (Directory.GetFiles(Program.pr).Length > 0)
			{
				Process.Start(Program.pr + "\\MM");
			}
			else
			{
				MessageBox.Show("Non hai nessuno Streaming gia salvato in precedenza");
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Non hai nessuno Streaming gia salvato in precedenza");
		}
	}

	private void button32_Click(object sender, EventArgs e)
	{
		try
		{
			if (DialogResult.Yes != MessageBox.Show("Sei SICURO di voler cancellare tutti i file scaricati?", "ATTENZIONE", MessageBoxButtons.YesNo))
			{
				return;
			}
			if (Directory.GetFiles(Program.pr).Length > 0)
			{
				string[] files = Directory.GetFiles(Program.pr + "\\MM");
				for (int i = 0; i < files.Length; i++)
				{
					try
					{
						File.Delete(files[i]);
					}
					catch (Exception)
					{
					}
				}
				MessageBox.Show("Cancellato tutto correttamente");
			}
			else
			{
				MessageBox.Show("Non hai nessuno Streaming gia salvato in precedenza");
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Non hai nessuno Streaming gia salvato in precedenza");
		}
	}

	private void button36_Click(object sender, EventArgs e)
	{
		try
		{
			TTXMEGA.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			mio.TTXSCARICAREVLC.Abort();
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.ManageCanali));
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.rimuovereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.rimuovereCanaleSelezionatoPerSempreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.creaListaRimozioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.label1 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.button6 = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.button2 = new System.Windows.Forms.Button();
		this.label6 = new System.Windows.Forms.Label();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button3 = new System.Windows.Forms.Button();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.button4 = new System.Windows.Forms.Button();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.button5 = new System.Windows.Forms.Button();
		this.label7 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.button7 = new System.Windows.Forms.Button();
		this.label10 = new System.Windows.Forms.Label();
		this.comboBox6 = new System.Windows.Forms.ComboBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.listBox2 = new System.Windows.Forms.ListBox();
		this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.registraProgrammaSelezionatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.label11 = new System.Windows.Forms.Label();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.button13 = new System.Windows.Forms.Button();
		this.progressBar2 = new System.Windows.Forms.ProgressBar();
		this.button8 = new System.Windows.Forms.Button();
		this.label12 = new System.Windows.Forms.Label();
		this.listBox3 = new System.Windows.Forms.ListBox();
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		this.button9 = new System.Windows.Forms.Button();
		this.button10 = new System.Windows.Forms.Button();
		this.button11 = new System.Windows.Forms.Button();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.button35 = new System.Windows.Forms.Button();
		this.button18 = new System.Windows.Forms.Button();
		this.button12 = new System.Windows.Forms.Button();
		this.button14 = new System.Windows.Forms.Button();
		this.groupBox7 = new System.Windows.Forms.GroupBox();
		this.button16 = new System.Windows.Forms.Button();
		this.progressBar3 = new System.Windows.Forms.ProgressBar();
		this.button15 = new System.Windows.Forms.Button();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.groupBox8 = new System.Windows.Forms.GroupBox();
		this.button17 = new System.Windows.Forms.Button();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.groupBox11 = new System.Windows.Forms.GroupBox();
		this.groupBox13 = new System.Windows.Forms.GroupBox();
		this.radioButton4 = new System.Windows.Forms.RadioButton();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.groupBox12 = new System.Windows.Forms.GroupBox();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.groupBox10 = new System.Windows.Forms.GroupBox();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.button19 = new System.Windows.Forms.Button();
		this.groupBox9 = new System.Windows.Forms.GroupBox();
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
		this.ricercaPiùVistiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.sportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.umorismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.autoEVeicoliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.educativiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.intrattenimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.filmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.giochiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.faiDaTeEStileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.scienzeETecnologieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.notizieEPoliticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.animaliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.viaggiEdEventiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.personeEBlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.button21 = new System.Windows.Forms.Button();
		this.button20 = new System.Windows.Forms.Button();
		this.label14 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.tabPage4 = new System.Windows.Forms.TabPage();
		this.progressBar4 = new System.Windows.Forms.ProgressBar();
		this.label15 = new System.Windows.Forms.Label();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.button23 = new System.Windows.Forms.Button();
		this.button22 = new System.Windows.Forms.Button();
		this.groupBox14 = new System.Windows.Forms.GroupBox();
		this.listBox4 = new System.Windows.Forms.ListBox();
		this.tabPage5 = new System.Windows.Forms.TabPage();
		this.button30 = new System.Windows.Forms.Button();
		this.groupBox15 = new System.Windows.Forms.GroupBox();
		this.label18 = new System.Windows.Forms.Label();
		this.progressBar6 = new System.Windows.Forms.ProgressBar();
		this.button26 = new System.Windows.Forms.Button();
		this.button24 = new System.Windows.Forms.Button();
		this.label16 = new System.Windows.Forms.Label();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.groupBox16 = new System.Windows.Forms.GroupBox();
		this.label19 = new System.Windows.Forms.Label();
		this.button28 = new System.Windows.Forms.Button();
		this.button27 = new System.Windows.Forms.Button();
		this.progressBar5 = new System.Windows.Forms.ProgressBar();
		this.button25 = new System.Windows.Forms.Button();
		this.label17 = new System.Windows.Forms.Label();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.button29 = new System.Windows.Forms.Button();
		this.tabPage6 = new System.Windows.Forms.TabPage();
		this.groupBox18 = new System.Windows.Forms.GroupBox();
		this.label22 = new System.Windows.Forms.Label();
		this.button34 = new System.Windows.Forms.Button();
		this.label23 = new System.Windows.Forms.Label();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.groupBox17 = new System.Windows.Forms.GroupBox();
		this.label20 = new System.Windows.Forms.Label();
		this.button33 = new System.Windows.Forms.Button();
		this.label21 = new System.Windows.Forms.Label();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.button32 = new System.Windows.Forms.Button();
		this.button31 = new System.Windows.Forms.Button();
		this.progressBar7 = new System.Windows.Forms.ProgressBar();
		this.label13 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.button36 = new System.Windows.Forms.Button();
		this.contextMenuStrip1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.contextMenuStrip2.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox7.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.groupBox8.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.tabPage3.SuspendLayout();
		this.groupBox11.SuspendLayout();
		this.groupBox13.SuspendLayout();
		this.groupBox12.SuspendLayout();
		this.groupBox10.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.groupBox9.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.tabPage4.SuspendLayout();
		this.groupBox14.SuspendLayout();
		this.tabPage5.SuspendLayout();
		this.groupBox15.SuspendLayout();
		this.groupBox16.SuspendLayout();
		this.tabPage6.SuspendLayout();
		this.groupBox18.SuspendLayout();
		this.groupBox17.SuspendLayout();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		base.SuspendLayout();
		this.listBox1.AccessibleName = "Canali attuali";
		this.listBox1.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
		this.listBox1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.listBox1.ForeColor = System.Drawing.Color.Gainsboro;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.HorizontalScrollbar = true;
		this.listBox1.ItemHeight = 15;
		this.listBox1.Location = new System.Drawing.Point(17, 32);
		this.listBox1.Margin = new System.Windows.Forms.Padding(2);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(424, 199);
		this.listBox1.TabIndex = 0;
		this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
		this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
		this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.rimuovereToolStripMenuItem, this.rimuovereCanaleSelezionatoPerSempreToolStripMenuItem, this.creaListaRimozioneToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(332, 70);
		this.rimuovereToolStripMenuItem.Name = "rimuovereToolStripMenuItem";
		this.rimuovereToolStripMenuItem.Size = new System.Drawing.Size(331, 22);
		this.rimuovereToolStripMenuItem.Text = "Rimuovere canale selezionato temporaneamente";
		this.rimuovereToolStripMenuItem.Click += new System.EventHandler(this.rimuovereToolStripMenuItem_Click);
		this.rimuovereCanaleSelezionatoPerSempreToolStripMenuItem.Name = "rimuovereCanaleSelezionatoPerSempreToolStripMenuItem";
		this.rimuovereCanaleSelezionatoPerSempreToolStripMenuItem.Size = new System.Drawing.Size(331, 22);
		this.rimuovereCanaleSelezionatoPerSempreToolStripMenuItem.Text = "Rimuovere canale selezionato per sempre";
		this.rimuovereCanaleSelezionatoPerSempreToolStripMenuItem.Click += new System.EventHandler(this.rimuovereCanaleSelezionatoPerSempreToolStripMenuItem_Click);
		this.creaListaRimozioneToolStripMenuItem.Name = "creaListaRimozioneToolStripMenuItem";
		this.creaListaRimozioneToolStripMenuItem.Size = new System.Drawing.Size(331, 22);
		this.creaListaRimozioneToolStripMenuItem.Text = "Crea Lista Rimozione";
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.label1.Location = new System.Drawing.Point(17, 15);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(243, 15);
		this.label1.TabIndex = 1;
		this.label1.Text = "Canali attuali (Doppio click per visualizzarli)";
		this.button1.AccessibleDescription = "";
		this.button1.AccessibleName = "Modifica Disposizione canale";
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.Location = new System.Drawing.Point(333, 35);
		this.button1.Margin = new System.Windows.Forms.Padding(2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(82, 24);
		this.button1.TabIndex = 2;
		this.button1.Text = "Modifica";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.groupBox1.Controls.Add(this.button6);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.comboBox2);
		this.groupBox1.Controls.Add(this.comboBox1);
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.ForeColor = System.Drawing.Color.White;
		this.groupBox1.Location = new System.Drawing.Point(6, 1);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox1.Size = new System.Drawing.Size(429, 114);
		this.groupBox1.TabIndex = 3;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Opzioni modifica disposizione canali";
		this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
		this.button6.BackColor = System.Drawing.Color.Green;
		this.button6.ForeColor = System.Drawing.Color.White;
		this.button6.Location = new System.Drawing.Point(6, 77);
		this.button6.Margin = new System.Windows.Forms.Padding(2);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(411, 24);
		this.button6.TabIndex = 7;
		this.button6.Text = "Programma automaticamente canali";
		this.button6.UseVisualStyleBackColor = false;
		this.button6.Click += new System.EventHandler(this.button6_Click);
		this.label3.AutoSize = true;
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(215, 16);
		this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(92, 15);
		this.label3.TabIndex = 6;
		this.label3.Text = "Numero canale";
		this.label3.Click += new System.EventHandler(this.label3_Click);
		this.label2.AutoSize = true;
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(7, 16);
		this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 15);
		this.label2.TabIndex = 5;
		this.label2.Text = "Canale";
		this.comboBox2.AccessibleName = "Numero canale";
		this.comboBox2.ForeColor = System.Drawing.Color.Black;
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(218, 35);
		this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(76, 23);
		this.comboBox2.TabIndex = 4;
		this.comboBox1.AccessibleName = "canale";
		this.comboBox1.ForeColor = System.Drawing.Color.Black;
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[6] { "Rai 1", "Rai 2", "Rai 3", "Rete 4", "Canale 5", "Italia 1" });
		this.comboBox1.Location = new System.Drawing.Point(10, 35);
		this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(177, 23);
		this.comboBox1.TabIndex = 3;
		this.groupBox2.Controls.Add(this.comboBox5);
		this.groupBox2.Controls.Add(this.label9);
		this.groupBox2.Controls.Add(this.label8);
		this.groupBox2.Controls.Add(this.comboBox4);
		this.groupBox2.Controls.Add(this.button2);
		this.groupBox2.Controls.Add(this.label6);
		this.groupBox2.Controls.Add(this.comboBox3);
		this.groupBox2.Controls.Add(this.label5);
		this.groupBox2.Controls.Add(this.textBox2);
		this.groupBox2.Controls.Add(this.label4);
		this.groupBox2.Controls.Add(this.textBox1);
		this.groupBox2.ForeColor = System.Drawing.Color.White;
		this.groupBox2.Location = new System.Drawing.Point(470, 1);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox2.Size = new System.Drawing.Size(423, 114);
		this.groupBox2.TabIndex = 4;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Aggiungi Nuovo canale";
		this.comboBox5.AccessibleName = "genere";
		this.comboBox5.ForeColor = System.Drawing.Color.Black;
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Items.AddRange(new object[23]
		{
			"Rai", "Sport", "Notiziari", "Cinema", "Cultura", "Divertimento", "Generalista", "Musica", "Meteo", "Regionale",
			"Mediaset", "Radio", "Tecnologia", "Moda", "Hot", "Documentari", "Arte", "Televendita", "Eventi", "Religione",
			"Fiera", "WebCam", "Esteri"
		});
		this.comboBox5.Location = new System.Drawing.Point(221, 78);
		this.comboBox5.Margin = new System.Windows.Forms.Padding(2);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(76, 23);
		this.comboBox5.TabIndex = 16;
		this.label9.ForeColor = System.Drawing.Color.White;
		this.label9.Location = new System.Drawing.Point(220, 62);
		this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(77, 15);
		this.label9.TabIndex = 15;
		this.label9.Text = "Genere";
		this.label8.ForeColor = System.Drawing.Color.White;
		this.label8.Location = new System.Drawing.Point(113, 62);
		this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(82, 15);
		this.label8.TabIndex = 14;
		this.label8.Text = "Tipo Link";
		this.comboBox4.AccessibleName = "tipo link";
		this.comboBox4.ForeColor = System.Drawing.Color.Black;
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Items.AddRange(new object[2] { "VLC", "WEBTV" });
		this.comboBox4.Location = new System.Drawing.Point(119, 78);
		this.comboBox4.Margin = new System.Windows.Forms.Padding(2);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(76, 23);
		this.comboBox4.TabIndex = 13;
		this.button2.AccessibleDescription = "";
		this.button2.AccessibleName = "Aggiungi nuovo canale";
		this.button2.ForeColor = System.Drawing.Color.Black;
		this.button2.Location = new System.Drawing.Point(318, 78);
		this.button2.Margin = new System.Windows.Forms.Padding(2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(90, 24);
		this.button2.TabIndex = 12;
		this.button2.Text = "Aggiungi";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.label6.AutoSize = true;
		this.label6.ForeColor = System.Drawing.Color.White;
		this.label6.Location = new System.Drawing.Point(12, 62);
		this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(92, 15);
		this.label6.TabIndex = 11;
		this.label6.Text = "Numero canale";
		this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.comboBox3.AccessibleName = "numero canale";
		this.comboBox3.ForeColor = System.Drawing.Color.Black;
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Location = new System.Drawing.Point(15, 78);
		this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(76, 23);
		this.comboBox3.TabIndex = 10;
		this.label5.AutoSize = true;
		this.label5.ForeColor = System.Drawing.Color.White;
		this.label5.Location = new System.Drawing.Point(206, 18);
		this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(81, 15);
		this.label5.TabIndex = 9;
		this.label5.Text = "Nome canale";
		this.textBox2.AccessibleName = "nome canale";
		this.textBox2.ForeColor = System.Drawing.Color.Black;
		this.textBox2.Location = new System.Drawing.Point(206, 35);
		this.textBox2.Margin = new System.Windows.Forms.Padding(2);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(202, 21);
		this.textBox2.TabIndex = 8;
		this.label4.AutoSize = true;
		this.label4.ForeColor = System.Drawing.Color.White;
		this.label4.Location = new System.Drawing.Point(12, 18);
		this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(63, 15);
		this.label4.TabIndex = 7;
		this.label4.Text = "Url canale";
		this.textBox1.AccessibleName = "url canale";
		this.textBox1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.textBox1.Location = new System.Drawing.Point(15, 35);
		this.textBox1.Margin = new System.Windows.Forms.Padding(2);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(174, 21);
		this.textBox1.TabIndex = 0;
		this.button3.AccessibleDescription = "";
		this.button3.AccessibleName = "Aggiorna lista Canali da internet";
		this.button3.ForeColor = System.Drawing.Color.Black;
		this.button3.Location = new System.Drawing.Point(1, 43);
		this.button3.Margin = new System.Windows.Forms.Padding(2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(422, 22);
		this.button3.TabIndex = 7;
		this.button3.Text = "Aggiorna Lista Canali da Internet";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.progressBar1.ForeColor = System.Drawing.Color.Black;
		this.progressBar1.Location = new System.Drawing.Point(1, 69);
		this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(422, 20);
		this.progressBar1.TabIndex = 8;
		this.button4.AccessibleDescription = "";
		this.button4.AccessibleName = "Esporta lista canali";
		this.button4.ForeColor = System.Drawing.Color.Black;
		this.button4.Location = new System.Drawing.Point(439, 43);
		this.button4.Margin = new System.Windows.Forms.Padding(2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(409, 22);
		this.button4.TabIndex = 13;
		this.button4.Text = "Esporta Lista Canali";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.groupBox3.Controls.Add(this.checkBox1);
		this.groupBox3.Controls.Add(this.checkBox3);
		this.groupBox3.Controls.Add(this.button5);
		this.groupBox3.Controls.Add(this.progressBar1);
		this.groupBox3.Controls.Add(this.button4);
		this.groupBox3.Controls.Add(this.button3);
		this.groupBox3.ForeColor = System.Drawing.Color.Blue;
		this.groupBox3.Location = new System.Drawing.Point(18, 636);
		this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox3.Size = new System.Drawing.Size(857, 107);
		this.groupBox3.TabIndex = 5;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Opzioni Canali Extra";
		this.groupBox3.Visible = false;
		this.checkBox1.AutoSize = true;
		this.checkBox1.ForeColor = System.Drawing.Color.Black;
		this.checkBox1.Location = new System.Drawing.Point(3, 19);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(175, 19);
		this.checkBox1.TabIndex = 15;
		this.checkBox1.Text = "Aggiorna lista ad ogni avvio";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
		this.checkBox3.AutoSize = true;
		this.checkBox3.ForeColor = System.Drawing.Color.Black;
		this.checkBox3.Location = new System.Drawing.Point(250, 19);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(112, 19);
		this.checkBox3.TabIndex = 0;
		this.checkBox3.Text = "Multiple WEBTV";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
		this.button5.AccessibleDescription = "";
		this.button5.AccessibleName = "condividi la tua lista canali";
		this.button5.Enabled = false;
		this.button5.ForeColor = System.Drawing.Color.Black;
		this.button5.Location = new System.Drawing.Point(439, 69);
		this.button5.Margin = new System.Windows.Forms.Padding(2);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(409, 22);
		this.button5.TabIndex = 14;
		this.button5.Text = "Condividi la tua Lista Canali";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.label7.AutoSize = true;
		this.label7.ForeColor = System.Drawing.Color.Black;
		this.label7.Location = new System.Drawing.Point(4, 22);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(86, 15);
		this.label7.TabIndex = 6;
		this.label7.Text = "Filtri su Canali";
		this.label7.Click += new System.EventHandler(this.label7_Click);
		this.textBox3.AccessibleName = "filtri su canali";
		this.textBox3.ForeColor = System.Drawing.Color.Black;
		this.textBox3.Location = new System.Drawing.Point(118, 19);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(121, 21);
		this.textBox3.TabIndex = 7;
		this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
		this.button7.AccessibleDescription = "";
		this.button7.AccessibleName = "Cerca Palinsesto in internet";
		this.button7.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button7.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button7.ForeColor = System.Drawing.Color.Gainsboro;
		this.button7.Location = new System.Drawing.Point(229, 59);
		this.button7.Margin = new System.Windows.Forms.Padding(2);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(218, 24);
		this.button7.TabIndex = 8;
		this.button7.Text = "Cerca Palinsesto Internet";
		this.button7.UseVisualStyleBackColor = false;
		this.button7.Click += new System.EventHandler(this.button7_Click);
		this.label10.AutoSize = true;
		this.label10.ForeColor = System.Drawing.Color.Black;
		this.label10.Location = new System.Drawing.Point(4, 46);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(103, 15);
		this.label10.TabIndex = 9;
		this.label10.Text = "Filtri Preimpostati";
		this.comboBox6.AccessibleName = "filtro preimpostato";
		this.comboBox6.ForeColor = System.Drawing.Color.Black;
		this.comboBox6.FormattingEnabled = true;
		this.comboBox6.Items.AddRange(new object[23]
		{
			"", "Rai", "Mediaset", "Sport", "Notiziari", "Cinema", "Cultura", "Divertimento", "Musica", "Meteo",
			"Generalista", "Regionale", "Radio", "Tecnologia", "Moda", "Documentari", "Arte", "Televendita", "Eventi", "Religione",
			"Fiera", "Hot", "Esteri"
		});
		this.comboBox6.Location = new System.Drawing.Point(118, 43);
		this.comboBox6.Name = "comboBox6";
		this.comboBox6.Size = new System.Drawing.Size(121, 23);
		this.comboBox6.TabIndex = 10;
		this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
		this.checkBox2.AutoSize = true;
		this.checkBox2.ForeColor = System.Drawing.Color.Black;
		this.checkBox2.Location = new System.Drawing.Point(8, 19);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(129, 19);
		this.checkBox2.TabIndex = 11;
		this.checkBox2.Text = "Guarda Palinsesto\r\n";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
		this.listBox2.AccessibleName = "palinsesto canali attuali";
		this.listBox2.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.listBox2.ContextMenuStrip = this.contextMenuStrip2;
		this.listBox2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.listBox2.ForeColor = System.Drawing.Color.Gainsboro;
		this.listBox2.FormattingEnabled = true;
		this.listBox2.HorizontalScrollbar = true;
		this.listBox2.ItemHeight = 15;
		this.listBox2.Location = new System.Drawing.Point(456, 30);
		this.listBox2.Margin = new System.Windows.Forms.Padding(2);
		this.listBox2.Name = "listBox2";
		this.listBox2.Size = new System.Drawing.Size(442, 199);
		this.listBox2.TabIndex = 12;
		this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
		this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
		this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.registraProgrammaSelezionatoToolStripMenuItem, this.faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem });
		this.contextMenuStrip2.Name = "contextMenuStrip2";
		this.contextMenuStrip2.Size = new System.Drawing.Size(333, 48);
		this.registraProgrammaSelezionatoToolStripMenuItem.Name = "registraProgrammaSelezionatoToolStripMenuItem";
		this.registraProgrammaSelezionatoToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
		this.registraProgrammaSelezionatoToolStripMenuItem.Text = "Registra Programma Selezionato";
		this.registraProgrammaSelezionatoToolStripMenuItem.Click += new System.EventHandler(this.registraProgrammaSelezionatoToolStripMenuItem_Click);
		this.faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem.Name = "faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem";
		this.faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
		this.faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem.Text = "Fai partire in automatico Programma Selezionato";
		this.faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem.Click += new System.EventHandler(this.faiPartireInAutomaticoProgrammaSelezionatoToolStripMenuItem_Click);
		this.label11.AutoSize = true;
		this.label11.ForeColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.label11.Location = new System.Drawing.Point(454, 15);
		this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(301, 15);
		this.label11.TabIndex = 13;
		this.label11.Text = "Palinsesto Canale selezionato (tasto destro per REC)";
		this.groupBox4.Controls.Add(this.label7);
		this.groupBox4.Controls.Add(this.textBox3);
		this.groupBox4.Controls.Add(this.label10);
		this.groupBox4.Controls.Add(this.comboBox6);
		this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.groupBox4.Location = new System.Drawing.Point(17, 247);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(244, 86);
		this.groupBox4.TabIndex = 14;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Filtri Canali";
		this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
		this.groupBox5.Controls.Add(this.button13);
		this.groupBox5.Controls.Add(this.progressBar2);
		this.groupBox5.Controls.Add(this.button8);
		this.groupBox5.Controls.Add(this.button7);
		this.groupBox5.Controls.Add(this.checkBox2);
		this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.groupBox5.Location = new System.Drawing.Point(451, 247);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(451, 86);
		this.groupBox5.TabIndex = 15;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Opzioni Palinsesto";
		this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
		this.button13.AccessibleDescription = "";
		this.button13.AccessibleName = "Ora in TV";
		this.button13.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button13.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button13.ForeColor = System.Drawing.Color.Gainsboro;
		this.button13.Location = new System.Drawing.Point(229, 35);
		this.button13.Margin = new System.Windows.Forms.Padding(2);
		this.button13.Name = "button13";
		this.button13.Size = new System.Drawing.Size(218, 24);
		this.button13.TabIndex = 18;
		this.button13.Text = "Aggiungi in \"Avvisa quando si vede\"";
		this.button13.UseVisualStyleBackColor = false;
		this.button13.Click += new System.EventHandler(this.button13_Click);
		this.progressBar2.ForeColor = System.Drawing.Color.Black;
		this.progressBar2.Location = new System.Drawing.Point(8, 43);
		this.progressBar2.Margin = new System.Windows.Forms.Padding(2);
		this.progressBar2.Name = "progressBar2";
		this.progressBar2.Size = new System.Drawing.Size(159, 34);
		this.progressBar2.Step = 1;
		this.progressBar2.TabIndex = 17;
		this.button8.AccessibleDescription = "";
		this.button8.AccessibleName = "Ora in TV";
		this.button8.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button8.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button8.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
		this.button8.Location = new System.Drawing.Point(229, 13);
		this.button8.Margin = new System.Windows.Forms.Padding(2);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(218, 24);
		this.button8.TabIndex = 12;
		this.button8.Text = "Ora in TV";
		this.button8.UseVisualStyleBackColor = false;
		this.button8.Click += new System.EventHandler(this.button8_Click);
		this.label12.AutoSize = true;
		this.label12.ForeColor = System.Drawing.Color.Black;
		this.label12.Location = new System.Drawing.Point(626, 10);
		this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(16, 15);
		this.label12.TabIndex = 16;
		this.label12.Text = "...";
		this.listBox3.ContextMenuStrip = this.contextMenuStrip1;
		this.listBox3.FormattingEnabled = true;
		this.listBox3.HorizontalScrollbar = true;
		this.listBox3.ItemHeight = 15;
		this.listBox3.Location = new System.Drawing.Point(473, 57);
		this.listBox3.Margin = new System.Windows.Forms.Padding(2);
		this.listBox3.Name = "listBox3";
		this.listBox3.Size = new System.Drawing.Size(159, 49);
		this.listBox3.TabIndex = 17;
		this.webBrowser1.Location = new System.Drawing.Point(457, 32);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(441, 199);
		this.webBrowser1.TabIndex = 18;
		this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
		this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
		this.button9.AccessibleDescription = "";
		this.button9.AccessibleName = "Aggiungi nuovo canale";
		this.button9.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button9.ForeColor = System.Drawing.Color.Black;
		this.button9.Location = new System.Drawing.Point(814, 4);
		this.button9.Margin = new System.Windows.Forms.Padding(2);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(40, 22);
		this.button9.TabIndex = 17;
		this.button9.Text = "+";
		this.button9.UseVisualStyleBackColor = true;
		this.button9.Click += new System.EventHandler(this.button9_Click);
		this.button10.AccessibleDescription = "";
		this.button10.AccessibleName = "Aggiungi nuovo canale";
		this.button10.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button10.ForeColor = System.Drawing.Color.Black;
		this.button10.Location = new System.Drawing.Point(858, 4);
		this.button10.Margin = new System.Windows.Forms.Padding(2);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(40, 22);
		this.button10.TabIndex = 19;
		this.button10.Text = "-";
		this.button10.UseVisualStyleBackColor = true;
		this.button10.Click += new System.EventHandler(this.button10_Click);
		this.button11.AccessibleDescription = "";
		this.button11.AccessibleName = "Aggiungi nuovo canale";
		this.button11.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button11.ForeColor = System.Drawing.Color.Black;
		this.button11.Location = new System.Drawing.Point(770, 4);
		this.button11.Margin = new System.Windows.Forms.Padding(2);
		this.button11.Name = "button11";
		this.button11.Size = new System.Drawing.Size(40, 22);
		this.button11.TabIndex = 20;
		this.button11.Text = "1/2";
		this.button11.UseVisualStyleBackColor = true;
		this.button11.Click += new System.EventHandler(this.button11_Click);
		this.buttonExtraCanali = new System.Windows.Forms.Button();
		this.buttonExtraCanali.Text = "Canali Extra (REC EXTRA)";
		this.buttonExtraCanali.Location = new System.Drawing.Point(10, 103);
		this.buttonExtraCanali.Size = new System.Drawing.Size(150, 23);
		this.buttonExtraCanali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.buttonExtraCanali.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
		this.buttonExtraCanali.AccessibleName = "Canali extra: registrazione e visione";
		this.buttonExtraCanali.Click += new System.EventHandler(this.buttonExtraCanali_Click);
		this.groupBox6.Controls.Add(this.buttonExtraCanali);
		this.groupBox6.Controls.Add(this.button35);
		this.groupBox6.Controls.Add(this.button18);
		this.groupBox6.Controls.Add(this.button12);
		this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.groupBox6.Location = new System.Drawing.Point(267, 247);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new System.Drawing.Size(174, 130);
		this.groupBox6.TabIndex = 21;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "Opzioni Extra";
		this.button35.AccessibleDescription = "";
		this.button35.AccessibleName = "Modifica Disposizione canale";
		this.button35.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button35.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button35.ForeColor = System.Drawing.Color.Aquamarine;
		this.button35.Location = new System.Drawing.Point(10, 77);
		this.button35.Margin = new System.Windows.Forms.Padding(2);
		this.button35.Name = "button35";
		this.button35.Size = new System.Drawing.Size(150, 23);
		this.button35.TabIndex = 10;
		this.button35.Text = "Telegiornali Regionali";
		this.button35.UseVisualStyleBackColor = false;
		this.button35.Click += new System.EventHandler(this.button35_Click);
		this.button18.AccessibleDescription = "";
		this.button18.AccessibleName = "Modifica Disposizione canale";
		this.button18.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button18.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button18.ForeColor = System.Drawing.Color.Gold;
		this.button18.Location = new System.Drawing.Point(10, 49);
		this.button18.Margin = new System.Windows.Forms.Padding(2);
		this.button18.Name = "button18";
		this.button18.Size = new System.Drawing.Size(150, 23);
		this.button18.TabIndex = 9;
		this.button18.Text = "Zapping";
		this.button18.UseVisualStyleBackColor = false;
		this.button18.Click += new System.EventHandler(this.button18_Click_1);
		this.button12.AccessibleDescription = "";
		this.button12.AccessibleName = "Modifica Disposizione canale";
		this.button12.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button12.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button12.ForeColor = System.Drawing.Color.YellowGreen;
		this.button12.Location = new System.Drawing.Point(10, 20);
		this.button12.Margin = new System.Windows.Forms.Padding(2);
		this.button12.Name = "button12";
		this.button12.Size = new System.Drawing.Size(150, 25);
		this.button12.TabIndex = 8;
		this.button12.Text = "Ricerca Canali Extra";
		this.button12.UseVisualStyleBackColor = false;
		this.button12.Click += new System.EventHandler(this.button12_Click);
		this.button14.AccessibleName = "Televideo";
		this.button14.ForeColor = System.Drawing.Color.Black;
		this.button14.Location = new System.Drawing.Point(14, 23);
		this.button14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button14.Name = "button14";
		this.button14.Size = new System.Drawing.Size(150, 26);
		this.button14.TabIndex = 19;
		this.button14.Text = "Giochi";
		this.button14.UseVisualStyleBackColor = true;
		this.button14.Click += new System.EventHandler(this.button14_Click);
		this.groupBox7.Controls.Add(this.button16);
		this.groupBox7.Controls.Add(this.progressBar3);
		this.groupBox7.Controls.Add(this.button15);
		this.groupBox7.Controls.Add(this.checkBox4);
		this.groupBox7.ForeColor = System.Drawing.Color.White;
		this.groupBox7.Location = new System.Drawing.Point(222, 6);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Size = new System.Drawing.Size(671, 95);
		this.groupBox7.TabIndex = 22;
		this.groupBox7.TabStop = false;
		this.groupBox7.Text = "Avvisi";
		this.button16.AccessibleName = "Televideo";
		this.button16.ForeColor = System.Drawing.Color.Black;
		this.button16.Location = new System.Drawing.Point(336, 22);
		this.button16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button16.Name = "button16";
		this.button16.Size = new System.Drawing.Size(317, 26);
		this.button16.TabIndex = 20;
		this.button16.Text = "Mostra tutti gli \"Avvisi\" di oggi";
		this.button16.UseVisualStyleBackColor = true;
		this.button16.Click += new System.EventHandler(this.button16_Click);
		this.progressBar3.Location = new System.Drawing.Point(336, 53);
		this.progressBar3.Name = "progressBar3";
		this.progressBar3.Size = new System.Drawing.Size(317, 23);
		this.progressBar3.Step = 1;
		this.progressBar3.TabIndex = 18;
		this.button15.AccessibleName = "Televideo";
		this.button15.ForeColor = System.Drawing.Color.Black;
		this.button15.Location = new System.Drawing.Point(9, 22);
		this.button15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button15.Name = "button15";
		this.button15.Size = new System.Drawing.Size(317, 26);
		this.button15.TabIndex = 17;
		this.button15.Text = "Setta \"Avvisa quando si vede in TV...\"";
		this.button15.UseVisualStyleBackColor = true;
		this.button15.Click += new System.EventHandler(this.button15_Click);
		this.checkBox4.ForeColor = System.Drawing.Color.White;
		this.checkBox4.Location = new System.Drawing.Point(10, 53);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(314, 34);
		this.checkBox4.TabIndex = 16;
		this.checkBox4.Text = "Attiva \"Avvisa quando si vede in TV..\"";
		this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Controls.Add(this.tabPage4);
		// BONIFICA 2026: il tab "Mega" (MegaUpload/Megavideo) non viene piu' aggiunto.
		this.tabControl1.Controls.Add(this.tabPage6);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl1.Location = new System.Drawing.Point(0, 0);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(913, 151);
		this.tabControl1.TabIndex = 23;
		this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
		this.tabPage1.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.tabPage1.Controls.Add(this.groupBox8);
		this.tabPage1.Controls.Add(this.groupBox7);
		this.tabPage1.ForeColor = System.Drawing.Color.White;
		this.tabPage1.Location = new System.Drawing.Point(4, 24);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(905, 123);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Extra";
		this.groupBox8.Controls.Add(this.button17);
		this.groupBox8.Controls.Add(this.button14);
		this.groupBox8.ForeColor = System.Drawing.Color.White;
		this.groupBox8.Location = new System.Drawing.Point(8, 6);
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.Size = new System.Drawing.Size(184, 95);
		this.groupBox8.TabIndex = 23;
		this.groupBox8.TabStop = false;
		this.groupBox8.Text = "Giochi / Chat";
		this.button17.AccessibleDescription = "";
		this.button17.AccessibleName = "Modifica Disposizione canale";
		this.button17.ForeColor = System.Drawing.Color.Black;
		this.button17.Location = new System.Drawing.Point(14, 53);
		this.button17.Margin = new System.Windows.Forms.Padding(2);
		this.button17.Name = "button17";
		this.button17.Size = new System.Drawing.Size(150, 26);
		this.button17.TabIndex = 8;
		this.button17.Text = "Chat";
		this.button17.UseVisualStyleBackColor = true;
		this.button17.Click += new System.EventHandler(this.button17_Click);
		this.tabPage2.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.tabPage2.Controls.Add(this.groupBox1);
		this.tabPage2.Controls.Add(this.groupBox2);
		this.tabPage2.ForeColor = System.Drawing.Color.White;
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(905, 125);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Manage Canali";
		this.tabPage3.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.tabPage3.Controls.Add(this.groupBox11);
		this.tabPage3.Controls.Add(this.groupBox10);
		this.tabPage3.Controls.Add(this.groupBox9);
		this.tabPage3.Location = new System.Drawing.Point(4, 22);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage3.Size = new System.Drawing.Size(905, 125);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "YouTube";
		this.groupBox11.Controls.Add(this.groupBox13);
		this.groupBox11.Controls.Add(this.groupBox12);
		this.groupBox11.ForeColor = System.Drawing.Color.White;
		this.groupBox11.Location = new System.Drawing.Point(465, 6);
		this.groupBox11.Name = "groupBox11";
		this.groupBox11.Size = new System.Drawing.Size(176, 100);
		this.groupBox11.TabIndex = 7;
		this.groupBox11.TabStop = false;
		this.groupBox11.Text = "Opzioni";
		this.groupBox13.Controls.Add(this.radioButton4);
		this.groupBox13.Controls.Add(this.radioButton3);
		this.groupBox13.ForeColor = System.Drawing.Color.White;
		this.groupBox13.Location = new System.Drawing.Point(11, 54);
		this.groupBox13.Name = "groupBox13";
		this.groupBox13.Size = new System.Drawing.Size(157, 39);
		this.groupBox13.TabIndex = 10;
		this.groupBox13.TabStop = false;
		this.groupBox13.Text = "Risoluzione";
		this.radioButton4.AutoSize = true;
		this.radioButton4.Location = new System.Drawing.Point(78, 14);
		this.radioButton4.Name = "radioButton4";
		this.radioButton4.Size = new System.Drawing.Size(76, 19);
		this.radioButton4.TabIndex = 9;
		this.radioButton4.Text = "Massima";
		this.radioButton4.UseVisualStyleBackColor = true;
		this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
		this.radioButton3.AutoSize = true;
		this.radioButton3.Checked = true;
		this.radioButton3.Location = new System.Drawing.Point(7, 14);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(65, 19);
		this.radioButton3.TabIndex = 8;
		this.radioButton3.TabStop = true;
		this.radioButton3.Text = "Minima";
		this.radioButton3.UseVisualStyleBackColor = true;
		this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
		this.groupBox12.Controls.Add(this.radioButton1);
		this.groupBox12.Controls.Add(this.radioButton2);
		this.groupBox12.ForeColor = System.Drawing.Color.White;
		this.groupBox12.Location = new System.Drawing.Point(11, 14);
		this.groupBox12.Name = "groupBox12";
		this.groupBox12.Size = new System.Drawing.Size(157, 39);
		this.groupBox12.TabIndex = 9;
		this.groupBox12.TabStop = false;
		this.groupBox12.Text = "Visualizza";
		this.radioButton1.AutoSize = true;
		this.radioButton1.Checked = true;
		this.radioButton1.Location = new System.Drawing.Point(6, 14);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(50, 19);
		this.radioButton1.TabIndex = 7;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "Web";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(78, 14);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(48, 19);
		this.radioButton2.TabIndex = 8;
		this.radioButton2.Text = "VLC";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
		this.groupBox10.Controls.Add(this.pictureBox1);
		this.groupBox10.Controls.Add(this.button19);
		this.groupBox10.ForeColor = System.Drawing.Color.White;
		this.groupBox10.Location = new System.Drawing.Point(669, 5);
		this.groupBox10.Name = "groupBox10";
		this.groupBox10.Size = new System.Drawing.Size(224, 100);
		this.groupBox10.TabIndex = 1;
		this.groupBox10.TabStop = false;
		this.groupBox10.Text = "Voglio di +";
		this.pictureBox1.Image = ZeroItaTV.Properties.Resources.simbolo;
		this.pictureBox1.Location = new System.Drawing.Point(145, 29);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(62, 51);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 1;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
		this.button19.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button19.Location = new System.Drawing.Point(10, 18);
		this.button19.Name = "button19";
		this.button19.Size = new System.Drawing.Size(206, 73);
		this.button19.TabIndex = 0;
		this.button19.Text = "Link a ZeroRadio\r\n(programma gratuito \r\nper ascoltare musica \r\nonline)";
		this.button19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button19.UseVisualStyleBackColor = false;
		this.button19.Click += new System.EventHandler(this.button19_Click);
		this.groupBox9.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.groupBox9.Controls.Add(this.statusStrip1);
		this.groupBox9.Controls.Add(this.checkBox5);
		this.groupBox9.Controls.Add(this.button21);
		this.groupBox9.Controls.Add(this.button20);
		this.groupBox9.Controls.Add(this.label14);
		this.groupBox9.Controls.Add(this.textBox4);
		this.groupBox9.ForeColor = System.Drawing.Color.White;
		this.groupBox9.Location = new System.Drawing.Point(7, 6);
		this.groupBox9.Name = "groupBox9";
		this.groupBox9.Size = new System.Drawing.Size(452, 100);
		this.groupBox9.TabIndex = 0;
		this.groupBox9.TabStop = false;
		this.groupBox9.Text = "Ricerca Video";
		this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripSplitButton1, this.toolStripStatusLabel1 });
		this.statusStrip1.Location = new System.Drawing.Point(265, 71);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(175, 22);
		this.statusStrip1.TabIndex = 8;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ricercaPiùVistiToolStripMenuItem, this.categorieToolStripMenuItem });
		this.toolStripSplitButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripSplitButton1.Image");
		this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripSplitButton1.Name = "toolStripSplitButton1";
		this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
		this.toolStripSplitButton1.Text = "toolStripSplitButton1";
		this.ricercaPiùVistiToolStripMenuItem.Name = "ricercaPiùVistiToolStripMenuItem";
		this.ricercaPiùVistiToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.ricercaPiùVistiToolStripMenuItem.Text = "Ricerca più visti";
		this.ricercaPiùVistiToolStripMenuItem.Click += new System.EventHandler(this.ricercaPiùVistiToolStripMenuItem_Click);
		this.categorieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[13]
		{
			this.sportToolStripMenuItem, this.umorismoToolStripMenuItem, this.autoEVeicoliToolStripMenuItem, this.educativiToolStripMenuItem, this.intrattenimentoToolStripMenuItem, this.filmToolStripMenuItem, this.giochiToolStripMenuItem, this.faiDaTeEStileToolStripMenuItem, this.scienzeETecnologieToolStripMenuItem, this.notizieEPoliticaToolStripMenuItem,
			this.animaliToolStripMenuItem, this.viaggiEdEventiToolStripMenuItem, this.personeEBlogToolStripMenuItem
		});
		this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
		this.categorieToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.categorieToolStripMenuItem.Text = "Categorie";
		this.sportToolStripMenuItem.Name = "sportToolStripMenuItem";
		this.sportToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.sportToolStripMenuItem.Text = "Sport";
		this.sportToolStripMenuItem.Click += new System.EventHandler(this.sportToolStripMenuItem_Click);
		this.umorismoToolStripMenuItem.Name = "umorismoToolStripMenuItem";
		this.umorismoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.umorismoToolStripMenuItem.Text = "Umorismo";
		this.umorismoToolStripMenuItem.Click += new System.EventHandler(this.umorismoToolStripMenuItem_Click);
		this.autoEVeicoliToolStripMenuItem.Name = "autoEVeicoliToolStripMenuItem";
		this.autoEVeicoliToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.autoEVeicoliToolStripMenuItem.Text = "Auto e Veicoli";
		this.autoEVeicoliToolStripMenuItem.Click += new System.EventHandler(this.autoEVeicoliToolStripMenuItem_Click);
		this.educativiToolStripMenuItem.Name = "educativiToolStripMenuItem";
		this.educativiToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.educativiToolStripMenuItem.Text = "Educativi";
		this.educativiToolStripMenuItem.Click += new System.EventHandler(this.educativiToolStripMenuItem_Click);
		this.intrattenimentoToolStripMenuItem.Name = "intrattenimentoToolStripMenuItem";
		this.intrattenimentoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.intrattenimentoToolStripMenuItem.Text = "Intrattenimento";
		this.intrattenimentoToolStripMenuItem.Click += new System.EventHandler(this.intrattenimentoToolStripMenuItem_Click);
		this.filmToolStripMenuItem.Name = "filmToolStripMenuItem";
		this.filmToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.filmToolStripMenuItem.Text = "Film e Animazione";
		this.filmToolStripMenuItem.Click += new System.EventHandler(this.filmToolStripMenuItem_Click);
		this.giochiToolStripMenuItem.Name = "giochiToolStripMenuItem";
		this.giochiToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.giochiToolStripMenuItem.Text = "Giochi";
		this.giochiToolStripMenuItem.Click += new System.EventHandler(this.giochiToolStripMenuItem_Click);
		this.faiDaTeEStileToolStripMenuItem.Name = "faiDaTeEStileToolStripMenuItem";
		this.faiDaTeEStileToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.faiDaTeEStileToolStripMenuItem.Text = "Fai da te e Stile";
		this.faiDaTeEStileToolStripMenuItem.Click += new System.EventHandler(this.faiDaTeEStileToolStripMenuItem_Click);
		this.scienzeETecnologieToolStripMenuItem.Name = "scienzeETecnologieToolStripMenuItem";
		this.scienzeETecnologieToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.scienzeETecnologieToolStripMenuItem.Text = "Scienze e Tecnologie";
		this.scienzeETecnologieToolStripMenuItem.Click += new System.EventHandler(this.scienzeETecnologieToolStripMenuItem_Click);
		this.notizieEPoliticaToolStripMenuItem.Name = "notizieEPoliticaToolStripMenuItem";
		this.notizieEPoliticaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.notizieEPoliticaToolStripMenuItem.Text = "Notizie e Politica";
		this.notizieEPoliticaToolStripMenuItem.Click += new System.EventHandler(this.notizieEPoliticaToolStripMenuItem_Click);
		this.animaliToolStripMenuItem.Name = "animaliToolStripMenuItem";
		this.animaliToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.animaliToolStripMenuItem.Text = "Animali";
		this.animaliToolStripMenuItem.Click += new System.EventHandler(this.animaliToolStripMenuItem_Click);
		this.viaggiEdEventiToolStripMenuItem.Name = "viaggiEdEventiToolStripMenuItem";
		this.viaggiEdEventiToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.viaggiEdEventiToolStripMenuItem.Text = "Viaggi ed Eventi";
		this.viaggiEdEventiToolStripMenuItem.Click += new System.EventHandler(this.viaggiEdEventiToolStripMenuItem_Click);
		this.personeEBlogToolStripMenuItem.Name = "personeEBlogToolStripMenuItem";
		this.personeEBlogToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.personeEBlogToolStripMenuItem.Text = "Persone e Blog";
		this.personeEBlogToolStripMenuItem.Click += new System.EventHandler(this.personeEBlogToolStripMenuItem_Click);
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(126, 17);
		this.toolStripStatusLabel1.Text = "Ricerche per Categorie";
		this.checkBox5.AutoSize = true;
		this.checkBox5.Location = new System.Drawing.Point(9, 69);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(140, 19);
		this.checkBox5.TabIndex = 7;
		this.checkBox5.Text = "Random tra i risultati";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
		this.button21.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button21.Location = new System.Drawing.Point(265, 45);
		this.button21.Name = "button21";
		this.button21.Size = new System.Drawing.Size(175, 23);
		this.button21.TabIndex = 6;
		this.button21.Text = "Ricerca Video";
		this.button21.UseVisualStyleBackColor = false;
		this.button21.Click += new System.EventHandler(this.button21_Click);
		this.button20.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button20.Location = new System.Drawing.Point(265, 20);
		this.button20.Name = "button20";
		this.button20.Size = new System.Drawing.Size(175, 23);
		this.button20.TabIndex = 4;
		this.button20.Text = "Mi sento Fortunato";
		this.button20.UseVisualStyleBackColor = false;
		this.button20.Click += new System.EventHandler(this.button20_Click);
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(6, 22);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(161, 15);
		this.label14.TabIndex = 1;
		this.label14.Text = "Inserisci Video da Ricercare";
		this.textBox4.Location = new System.Drawing.Point(9, 40);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(219, 21);
		this.textBox4.TabIndex = 0;
		this.textBox4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyUp);
		this.tabPage4.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.tabPage4.Controls.Add(this.progressBar4);
		this.tabPage4.Controls.Add(this.label15);
		this.tabPage4.Controls.Add(this.textBox5);
		this.tabPage4.Controls.Add(this.button23);
		this.tabPage4.Controls.Add(this.button22);
		this.tabPage4.Controls.Add(this.groupBox14);
		this.tabPage4.Location = new System.Drawing.Point(4, 24);
		this.tabPage4.Name = "tabPage4";
		this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage4.Size = new System.Drawing.Size(905, 123);
		this.tabPage4.TabIndex = 3;
		this.tabPage4.Text = "Sport";
		this.progressBar4.Location = new System.Drawing.Point(716, 98);
		this.progressBar4.Name = "progressBar4";
		this.progressBar4.Size = new System.Drawing.Size(172, 10);
		this.progressBar4.Step = 1;
		this.progressBar4.TabIndex = 9;
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(716, 75);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(36, 15);
		this.label15.TabIndex = 8;
		this.label15.Text = "Filtri :";
		this.textBox5.Location = new System.Drawing.Point(757, 71);
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(130, 21);
		this.textBox5.TabIndex = 7;
		this.textBox5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyUp);
		this.button23.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.button23.Location = new System.Drawing.Point(715, 45);
		this.button23.Name = "button23";
		this.button23.Size = new System.Drawing.Size(175, 23);
		this.button23.TabIndex = 6;
		this.button23.Text = "Eventi Sportivi Prossimi";
		this.button23.UseVisualStyleBackColor = false;
		this.button23.Click += new System.EventHandler(this.button23_Click_1);
		this.button22.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.button22.ForeColor = System.Drawing.Color.Black;
		this.button22.Location = new System.Drawing.Point(715, 20);
		this.button22.Name = "button22";
		this.button22.Size = new System.Drawing.Size(175, 23);
		this.button22.TabIndex = 5;
		this.button22.Text = "Eventi Sportivi Ora";
		this.button22.UseVisualStyleBackColor = false;
		this.button22.Click += new System.EventHandler(this.button22_Click_1);
		this.groupBox14.Controls.Add(this.listBox4);
		this.groupBox14.Location = new System.Drawing.Point(7, 6);
		this.groupBox14.Name = "groupBox14";
		this.groupBox14.Size = new System.Drawing.Size(686, 106);
		this.groupBox14.TabIndex = 0;
		this.groupBox14.TabStop = false;
		this.groupBox14.Text = "Eventi Sportivi";
		this.listBox4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listBox4.FormattingEnabled = true;
		this.listBox4.ItemHeight = 15;
		this.listBox4.Location = new System.Drawing.Point(3, 17);
		this.listBox4.Name = "listBox4";
		this.listBox4.Size = new System.Drawing.Size(680, 79);
		this.listBox4.TabIndex = 0;
		this.tabPage5.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.tabPage5.Controls.Add(this.button30);
		this.tabPage5.Controls.Add(this.groupBox15);
		this.tabPage5.Controls.Add(this.groupBox16);
		this.tabPage5.Controls.Add(this.button29);
		this.tabPage5.Location = new System.Drawing.Point(4, 24);
		this.tabPage5.Name = "tabPage5";
		this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage5.Size = new System.Drawing.Size(905, 123);
		this.tabPage5.TabIndex = 4;
		this.tabPage5.Text = "Mega";
		this.button30.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button30.ForeColor = System.Drawing.Color.White;
		this.button30.Location = new System.Drawing.Point(393, 70);
		this.button30.Name = "button30";
		this.button30.Size = new System.Drawing.Size(103, 40);
		this.button30.TabIndex = 14;
		this.button30.Text = "Azzera Conteggio";
		this.button30.UseVisualStyleBackColor = false;
		this.button30.Click += new System.EventHandler(this.button30_Click);
		this.groupBox15.Controls.Add(this.label18);
		this.groupBox15.Controls.Add(this.progressBar6);
		this.groupBox15.Controls.Add(this.button26);
		this.groupBox15.Controls.Add(this.button24);
		this.groupBox15.Controls.Add(this.label16);
		this.groupBox15.Controls.Add(this.textBox6);
		this.groupBox15.ForeColor = System.Drawing.Color.White;
		this.groupBox15.Location = new System.Drawing.Point(505, 5);
		this.groupBox15.Name = "groupBox15";
		this.groupBox15.Size = new System.Drawing.Size(388, 100);
		this.groupBox15.TabIndex = 0;
		this.groupBox15.TabStop = false;
		this.groupBox15.Text = "MegaVideo (su VLC scegliere \"Non Riparare\")";
		this.label18.AutoSize = true;
		this.label18.Location = new System.Drawing.Point(363, 20);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(14, 15);
		this.label18.TabIndex = 13;
		this.label18.Text = "0";
		this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.progressBar6.Location = new System.Drawing.Point(9, 75);
		this.progressBar6.Name = "progressBar6";
		this.progressBar6.Size = new System.Drawing.Size(183, 10);
		this.progressBar6.Step = 1;
		this.progressBar6.TabIndex = 11;
		this.progressBar6.Click += new System.EventHandler(this.progressBar6_Click);
		this.button26.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button26.Location = new System.Drawing.Point(9, 46);
		this.button26.Name = "button26";
		this.button26.Size = new System.Drawing.Size(183, 23);
		this.button26.TabIndex = 6;
		this.button26.Text = "Play Streaming via VLC";
		this.button26.UseVisualStyleBackColor = false;
		this.button26.Click += new System.EventHandler(this.button26_Click);
		this.button24.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button24.Location = new System.Drawing.Point(207, 46);
		this.button24.Name = "button24";
		this.button24.Size = new System.Drawing.Size(170, 23);
		this.button24.TabIndex = 5;
		this.button24.Text = "Rigenera Link";
		this.button24.UseVisualStyleBackColor = false;
		this.button24.Click += new System.EventHandler(this.button24_Click);
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(6, 20);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(94, 15);
		this.label16.TabIndex = 1;
		this.label16.Text = "Link MegaVideo";
		this.textBox6.Location = new System.Drawing.Point(106, 18);
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(241, 21);
		this.textBox6.TabIndex = 0;
		this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
		this.groupBox16.Controls.Add(this.label19);
		this.groupBox16.Controls.Add(this.button28);
		this.groupBox16.Controls.Add(this.button27);
		this.groupBox16.Controls.Add(this.progressBar5);
		this.groupBox16.Controls.Add(this.button25);
		this.groupBox16.Controls.Add(this.label17);
		this.groupBox16.Controls.Add(this.textBox7);
		this.groupBox16.ForeColor = System.Drawing.Color.White;
		this.groupBox16.Location = new System.Drawing.Point(7, 4);
		this.groupBox16.Name = "groupBox16";
		this.groupBox16.Size = new System.Drawing.Size(378, 100);
		this.groupBox16.TabIndex = 1;
		this.groupBox16.TabStop = false;
		this.groupBox16.Text = "MegaUpload (su VLC scegliere \"Non Riparare\")";
		this.label19.AutoSize = true;
		this.label19.Location = new System.Drawing.Point(345, 23);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(14, 15);
		this.label19.TabIndex = 14;
		this.label19.Text = "0";
		this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.button28.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button28.Location = new System.Drawing.Point(188, 44);
		this.button28.Name = "button28";
		this.button28.Size = new System.Drawing.Size(184, 23);
		this.button28.TabIndex = 12;
		this.button28.Text = "Mostra Vecchio Streaming";
		this.button28.UseVisualStyleBackColor = false;
		this.button28.Click += new System.EventHandler(this.button28_Click);
		this.button27.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button27.Location = new System.Drawing.Point(188, 68);
		this.button27.Name = "button27";
		this.button27.Size = new System.Drawing.Size(184, 23);
		this.button27.TabIndex = 11;
		this.button27.Text = "Cancella Vecchio Streaming";
		this.button27.UseVisualStyleBackColor = false;
		this.button27.Click += new System.EventHandler(this.button27_Click);
		this.progressBar5.Location = new System.Drawing.Point(9, 77);
		this.progressBar5.Name = "progressBar5";
		this.progressBar5.Size = new System.Drawing.Size(156, 10);
		this.progressBar5.Step = 1;
		this.progressBar5.TabIndex = 10;
		this.button25.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button25.Location = new System.Drawing.Point(6, 44);
		this.button25.Name = "button25";
		this.button25.Size = new System.Drawing.Size(159, 23);
		this.button25.TabIndex = 8;
		this.button25.Text = "Play Streaming via VLC";
		this.button25.UseVisualStyleBackColor = false;
		this.button25.Click += new System.EventHandler(this.button25_Click);
		this.label17.AutoSize = true;
		this.label17.Location = new System.Drawing.Point(8, 21);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(103, 15);
		this.label17.TabIndex = 7;
		this.label17.Text = "Link MegaUpload";
		this.textBox7.Location = new System.Drawing.Point(119, 19);
		this.textBox7.Name = "textBox7";
		this.textBox7.Size = new System.Drawing.Size(208, 21);
		this.textBox7.TabIndex = 6;
		this.button29.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button29.ForeColor = System.Drawing.Color.Gold;
		this.button29.Location = new System.Drawing.Point(393, 7);
		this.button29.Name = "button29";
		this.button29.Size = new System.Drawing.Size(103, 61);
		this.button29.TabIndex = 12;
		this.button29.Text = "Acquisisci link da WEBTVOSA";
		this.button29.UseVisualStyleBackColor = false;
		this.button29.Click += new System.EventHandler(this.button29_Click_1);
		this.tabPage6.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.tabPage6.Controls.Add(this.button36);
		this.tabPage6.Controls.Add(this.groupBox18);
		this.tabPage6.Controls.Add(this.groupBox17);
		this.tabPage6.Controls.Add(this.button32);
		this.tabPage6.Controls.Add(this.button31);
		this.tabPage6.Controls.Add(this.progressBar7);
		this.tabPage6.Location = new System.Drawing.Point(4, 24);
		this.tabPage6.Name = "tabPage6";
		this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage6.Size = new System.Drawing.Size(905, 123);
		this.tabPage6.TabIndex = 5;
		this.tabPage6.Text = "Other";
		this.groupBox18.Controls.Add(this.label22);
		this.groupBox18.Controls.Add(this.button34);
		this.groupBox18.Controls.Add(this.label23);
		this.groupBox18.Controls.Add(this.textBox9);
		this.groupBox18.ForeColor = System.Drawing.Color.White;
		this.groupBox18.Location = new System.Drawing.Point(14, 62);
		this.groupBox18.Name = "groupBox18";
		this.groupBox18.Size = new System.Drawing.Size(582, 54);
		this.groupBox18.TabIndex = 13;
		this.groupBox18.TabStop = false;
		this.groupBox18.Text = "MovShare (su VLC scegliere \"Non Riparare\")";
		this.label22.AutoSize = true;
		this.label22.Location = new System.Drawing.Point(345, 23);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(14, 15);
		this.label22.TabIndex = 14;
		this.label22.Text = "0";
		this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.button34.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button34.Location = new System.Drawing.Point(412, 19);
		this.button34.Name = "button34";
		this.button34.Size = new System.Drawing.Size(159, 23);
		this.button34.TabIndex = 8;
		this.button34.Text = "Play Streaming via VLC";
		this.button34.UseVisualStyleBackColor = false;
		this.button34.Click += new System.EventHandler(this.button34_Click);
		this.label23.AutoSize = true;
		this.label23.Location = new System.Drawing.Point(8, 21);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(87, 15);
		this.label23.TabIndex = 7;
		this.label23.Text = "Link MovShare";
		this.textBox9.Location = new System.Drawing.Point(119, 19);
		this.textBox9.Name = "textBox9";
		this.textBox9.Size = new System.Drawing.Size(208, 21);
		this.textBox9.TabIndex = 6;
		this.groupBox17.Controls.Add(this.label20);
		this.groupBox17.Controls.Add(this.button33);
		this.groupBox17.Controls.Add(this.label21);
		this.groupBox17.Controls.Add(this.textBox8);
		this.groupBox17.ForeColor = System.Drawing.Color.White;
		this.groupBox17.Location = new System.Drawing.Point(13, 4);
		this.groupBox17.Name = "groupBox17";
		this.groupBox17.Size = new System.Drawing.Size(582, 54);
		this.groupBox17.TabIndex = 2;
		this.groupBox17.TabStop = false;
		this.groupBox17.Text = "NovaMov (su VLC scegliere \"Non Riparare\")";
		this.label20.AutoSize = true;
		this.label20.Location = new System.Drawing.Point(345, 23);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(14, 15);
		this.label20.TabIndex = 14;
		this.label20.Text = "0";
		this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.button33.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button33.Location = new System.Drawing.Point(412, 19);
		this.button33.Name = "button33";
		this.button33.Size = new System.Drawing.Size(159, 23);
		this.button33.TabIndex = 8;
		this.button33.Text = "Play Streaming via VLC";
		this.button33.UseVisualStyleBackColor = false;
		this.button33.Click += new System.EventHandler(this.button33_Click);
		this.label21.AutoSize = true;
		this.label21.Location = new System.Drawing.Point(8, 21);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(82, 15);
		this.label21.TabIndex = 7;
		this.label21.Text = "Link NovaMov";
		this.textBox8.Location = new System.Drawing.Point(119, 19);
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(208, 21);
		this.textBox8.TabIndex = 6;
		this.button32.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button32.ForeColor = System.Drawing.Color.White;
		this.button32.Location = new System.Drawing.Point(691, 71);
		this.button32.Name = "button32";
		this.button32.Size = new System.Drawing.Size(184, 23);
		this.button32.TabIndex = 11;
		this.button32.Text = "Cancella Vecchio Streaming";
		this.button32.UseVisualStyleBackColor = false;
		this.button32.Click += new System.EventHandler(this.button32_Click);
		this.button31.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button31.ForeColor = System.Drawing.Color.White;
		this.button31.Location = new System.Drawing.Point(691, 48);
		this.button31.Name = "button31";
		this.button31.Size = new System.Drawing.Size(184, 23);
		this.button31.TabIndex = 12;
		this.button31.Text = "Mostra Vecchio Streaming";
		this.button31.UseVisualStyleBackColor = false;
		this.button31.Click += new System.EventHandler(this.button31_Click);
		this.progressBar7.Location = new System.Drawing.Point(691, 19);
		this.progressBar7.Name = "progressBar7";
		this.progressBar7.Size = new System.Drawing.Size(184, 23);
		this.progressBar7.Step = 1;
		this.progressBar7.TabIndex = 0;
		this.label13.ForeColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.label13.Location = new System.Drawing.Point(337, 15);
		this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(94, 15);
		this.label13.TabIndex = 24;
		this.label13.Text = "0";
		this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.panel1.BackColor = System.Drawing.Color.Black;
		this.panel1.Location = new System.Drawing.Point(7, 4);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(10, 371);
		this.panel1.TabIndex = 26;
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.IsSplitterFixed = true;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.panel1);
		this.splitContainer1.Panel1.Controls.Add(this.label1);
		this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
		this.splitContainer1.Panel1.Controls.Add(this.listBox1);
		this.splitContainer1.Panel1.Controls.Add(this.label13);
		this.splitContainer1.Panel1.Controls.Add(this.label11);
		this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
		this.splitContainer1.Panel1.Controls.Add(this.button11);
		this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
		this.splitContainer1.Panel1.Controls.Add(this.button10);
		this.splitContainer1.Panel1.Controls.Add(this.webBrowser1);
		this.splitContainer1.Panel1.Controls.Add(this.button9);
		this.splitContainer1.Panel1.Controls.Add(this.listBox2);
		this.splitContainer1.Panel1.Controls.Add(this.listBox3);
		this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
		this.splitContainer1.Size = new System.Drawing.Size(913, 534);
		this.splitContainer1.SplitterDistance = 379;
		this.splitContainer1.TabIndex = 28;
		this.button36.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button36.ForeColor = System.Drawing.Color.White;
		this.button36.Location = new System.Drawing.Point(691, 96);
		this.button36.Name = "button36";
		this.button36.Size = new System.Drawing.Size(184, 23);
		this.button36.TabIndex = 14;
		this.button36.Text = "Stop Download Streaming";
		this.button36.UseVisualStyleBackColor = false;
		this.button36.Click += new System.EventHandler(this.button36_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(913, 534);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.groupBox3);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "ManageCanali";
		base.Opacity = 0.0;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ManageCanali";
		base.Load += new System.EventHandler(this.ManageCanali_Load);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageCanali_FormClosed);
		this.contextMenuStrip1.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.contextMenuStrip2.ResumeLayout(false);
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		this.groupBox6.ResumeLayout(false);
		this.groupBox7.ResumeLayout(false);
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.groupBox8.ResumeLayout(false);
		this.tabPage2.ResumeLayout(false);
		this.tabPage3.ResumeLayout(false);
		this.groupBox11.ResumeLayout(false);
		this.groupBox13.ResumeLayout(false);
		this.groupBox13.PerformLayout();
		this.groupBox12.ResumeLayout(false);
		this.groupBox12.PerformLayout();
		this.groupBox10.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.groupBox9.ResumeLayout(false);
		this.groupBox9.PerformLayout();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.tabPage4.ResumeLayout(false);
		this.tabPage4.PerformLayout();
		this.groupBox14.ResumeLayout(false);
		this.tabPage5.ResumeLayout(false);
		this.groupBox15.ResumeLayout(false);
		this.groupBox15.PerformLayout();
		this.groupBox16.ResumeLayout(false);
		this.groupBox16.PerformLayout();
		this.tabPage6.ResumeLayout(false);
		this.groupBox18.ResumeLayout(false);
		this.groupBox18.PerformLayout();
		this.groupBox17.ResumeLayout(false);
		this.groupBox17.PerformLayout();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
