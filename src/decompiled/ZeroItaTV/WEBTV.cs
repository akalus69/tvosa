// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using ZeroItaTV.Properties;
using ZeroItaTV.Threadx;

namespace ZeroItaTV;

public class WEBTV : Form
{
	private int grandezzax = 0;

	private int grandezzay = 0;

	private string urlx = "";

	private bool apertospecial = false;

	private int alle = 0;

	private Thread TTXMEGA;

	private Point mouseOffset;

	private Point locx;

	private bool aperto = false;

	public string docwb2 = "";

	public Pubblicit ln1 = new Pubblicit();

	public Pubblicit ln2 = new Pubblicit();

	private bool isMouseDown = false;

	public string docpres = "";

	private IContainer components = null;

	private TextBox textBox1;

	private Button button1;

	private SplitContainer splitContainer1;

	private Label label1;

	public WebBrowser webBrowser1;

	private LinkLabel linkLabel1;

	private Panel panel1;

	private Label label3;

	private Label label2;

	private TextBox textBox2;

	private ComboBox comboBox5;

	private Button button4;

	private Panel panel2;

	private LinkLabel linkLabel2;

	public Button button2;

	public Button button3;

	private LinkLabel linkLabel3;

	private CheckBox checkBox1;

	public SplitContainer splitContainer2;

	public GroupBox groupBox1;

	public WebBrowser webBrowser2;

	public Button button5;

	public Button button6;

	public ToolTip toolTip1;

	public Button button7;

	public Button button8;

	public Button button9;

	public WEBTV()
	{
		InitializeComponent();
	}

	public void guarda(string x)
	{
		cambialing();
				apertospecial = false;
				urlx = x;
				// BONIFICA 2026: i live ufficiali (RaiPlay, RSI, Mediaset Infinity) richiedono browser
				// moderni con Widevine: il WebBrowser interno e' IE e non puo' riprodurli.
				// Li apriamo nel browser predefinito del sistema, come farebbe un utente nel 2026.
				if (urlx.IndexOf("raiplay.it", StringComparison.OrdinalIgnoreCase) >= 0 || urlx.IndexOf("www.rai.it", StringComparison.OrdinalIgnoreCase) >= 0 || urlx.IndexOf("rsi.ch", StringComparison.OrdinalIgnoreCase) >= 0 || urlx.IndexOf("mediaset.it", StringComparison.OrdinalIgnoreCase) >= 0 || urlx.IndexOf("youtube.com", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					try
									{
										ProcessStartInfo processStartInfo = new ProcessStartInfo(urlx);
										processStartInfo.UseShellExecute = true;
										System.Diagnostics.Process.Start(processStartInfo);
									}
									catch (Exception ex)
									{
										try
										{
											System.IO.File.AppendAllText(Program.pr + "\\dbg_ext.txt", "EST " + urlx + " -> " + ex.Message + "\r\n");
										}
										catch
										{
										}
									}
					webBrowser1.DocumentText = "<html><body style='font-family:Segoe UI;padding:24px;font-size:15px'>Live ufficiale aperto nel browser predefinito.<br>Il browser interno (Internet Explorer) non puo' riprodurre RaiPlay o Mediaset Infinity: servono Chrome o Edge.</body></html>";
					return;
				}
				if (string.IsNullOrEmpty(urlx))
				{
					MessageBox.Show("Nessuna sorgente live disponibile nel 2026 per questo canale: la pagina del 2011 e' chiusa. Prova i canali RAI (1, 2, 3...) ora su RaiPlay, oppure aggiungine uno nuovo con 'Aggiungi nuovo canale'.", "TVOSA 2026", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
		if (urlx.IndexOf("justin.") >= 0 || urlx.IndexOf("livestream.") >= 0)
		{
			panel2.Visible = true;
		}
		else
				{
					panel2.Visible = false;
				}
				// BONIFICA 2026: le sorgenti live del 2011 (mms://, player esterni, pagine morte)
				// ora producono un avviso leggibile invece di una pagina d'errore del browser.
				if (urlx.IndexOf("mms://", StringComparison.OrdinalIgnoreCase) == 0 || urlx.IndexOf("mmst://", StringComparison.OrdinalIgnoreCase) == 0 || urlx.IndexOf("mmsh://", StringComparison.OrdinalIgnoreCase) == 0)
				{
					MessageBox.Show("Questa sorgente live del 2011 usava il protocollo streaming mms://, scomparso da anni. Per i canali RAI usa la numerazione ufficiale (1, 2, 3...) che ora apre RaiPlay.", "TVOSA 2026", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (urlx.StartsWith("http", StringComparison.OrdinalIgnoreCase))
				{
					try
					{
						HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(urlx);
						httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
						httpWebRequest.Method = "HEAD";
						httpWebRequest.Timeout = 6000;
						httpWebRequest.AllowAutoRedirect = true;
						using (httpWebRequest.GetResponse())
						{
						}
					}
					catch
					{
						MessageBox.Show("La pagina live di questo canale ('" + urlx + "') non esiste piu' nel 2026. I siti TV del 2011 hanno chiuso o cambiato indirizzo: prova i canali RAI (1, 2, 3...) ora su RaiPlay, oppure aggiungi un canale nuovo con 'Aggiungi nuovo canale'.", "TVOSA 2026", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				webBrowser1.Navigate(urlx);
			}

	private void cambialing()
	{
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\LENG" + Program.mio.linguaprogramma + "WEB.txt");
			string text = streamReader.ReadToEnd();
			string text2 = text;
			streamReader.Close();
			if (text2.IndexOf("linkLabel2") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("linkLabel2"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				linkLabel2.Text = text3;
			}
			if (text2.IndexOf("linkLabel1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("linkLabel1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				linkLabel1.Text = text3;
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
			if (text2.IndexOf("button1") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button1"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button1.Text = text3;
			}
			if (text2.IndexOf("button4") >= 0)
			{
				text2 = text2.Substring(text2.IndexOf("button4"));
				text2 = text2.Substring(text2.IndexOf(Environment.NewLine) + 2);
				string text3 = text2.Substring(0, text2.IndexOf("****->"));
				text3 = text3.Replace(Environment.NewLine, "");
				button4.Text = text3;
			}
		}
		catch
		{
		}
	}

	private void WEBTV_Load(object sender, EventArgs e)
	{
		try
		{
			button9.Visible = false;
			groupBox1.Visible = false;
			panel1.Visible = false;
			panel2.Visible = false;
			webBrowser1.ScriptErrorsSuppressed = true;
			webBrowser2.ScriptErrorsSuppressed = true;
			webBrowser2.Visible = false;
			settatooltip();
		}
		catch
		{
		}
	}

	public void mostra()
	{
		try
		{
			if (!Visible)
			{
				Show();
				ThreadCapo threadCapo = new ThreadCapo(this);
				Thread thread = new Thread(threadCapo.componi);
				thread.IsBackground = true;
				thread.Priority = ThreadPriority.BelowNormal;
				thread.Start();
			}
		}
		catch
		{
		}
	}

	public void distruggi()
	{
		try
		{
			webBrowser1.Navigate("");
			apertospecial = false;
			ThreadCapo threadCapo = new ThreadCapo(this);
			Thread thread = new Thread(threadCapo.componiINV);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		webBrowser1.Navigate(textBox1.Text);
	}

	private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			int num = -e.X - SystemInformation.FrameBorderSize.Width;
			int num2 = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
			mouseOffset = new Point(num, num2);
			isMouseDown = true;
		}
	}

	private void splitContainer1_Panel1_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			isMouseDown = false;
		}
	}

	private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
	{
		if (isMouseDown)
		{
			Point mousePosition = Control.MousePosition;
			mousePosition.Offset(mouseOffset.X, mouseOffset.Y);
			Location = mousePosition;
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		urlx = "";
		webBrowser1.Navigate(urlx);
		panel1.Visible = false;
		distruggi();
	}

	private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (!aperto)
		{
			int num = int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString());
			int num2 = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
			Size = new Size(num2 - 10, num - 10);
			locx = Location;
			button2.Location = new Point(num2 - 60, button2.Location.Y);
			button3.Location = new Point(num2 - 100, button3.Location.Y);
			checkBox1.Location = new Point(num2 - 100, checkBox1.Location.Y);
			Location = new Point(5, 0);
			splitContainer2.SplitterDistance = num - 130;
			aperto = true;
		}
		else
		{
			aperto = false;
			Size = new Size(687, 711);
			button3.Location = new Point(592, 3);
			button2.Location = new Point(635, 3);
			checkBox1.Location = new Point(581, 23);
			Location = locx;
		}
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		panel2.Visible = false;
		panel1.Visible = true;
		try
		{
			string text = webBrowser1.DocumentText.Substring(webBrowser1.DocumentText.ToLowerInvariant().IndexOf("<title>"));
			text = text.Substring(text.IndexOf(">") + 1);
			text = text.Substring(0, text.IndexOf("<"));
		}
		catch (Exception)
		{
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		try
		{
			if (!File.Exists(Program.pr + "\\aggcanalesi"))
			{
				File.Create(Program.pr + "\\aggcanalesi");
			}
			string text = webBrowser1.Url.ToString();
			if (apertospecial)
			{
				text = urlx;
			}
			string text2 = textBox2.Text;
			string text3 = "0";
			string text4 = comboBox5.SelectedItem.ToString();
			text2 = "(" + text4 + ") " + text2;
			int num = 0;
			if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
			{
				try
				{
					StreamWriter streamWriter = new StreamWriter(Program.pr + "\\nuovicanali.txt", append: true);
					streamWriter.WriteLine(text2);
					streamWriter.WriteLine("http:\\webtv\\|<-->|" + text);
					streamWriter.Close();
				}
				catch
				{
					MessageBox.Show("canale non aggiunto, prego completare tutti i campi prima di inserirlo");
				}
				textBox2.Text = "";
				panel1.Visible = false;
				MessageBox.Show("Canale Aggiunto correttamente, premere su \"Programma automaticamente Canali\" in CANALI per trovarlo nella lista");
			}
			else
			{
				MessageBox.Show("canale non aggiunto, prego completare tutti i campi prima di inserirlo");
			}
		}
		catch
		{
			MessageBox.Show("canale non aggiunto, prego completare tutti i campi prima di inserirlo");
		}
	}

	public void ingrandiscirimpicciodr(int opz)
	{
		try
		{
			HtmlElementCollection all = webBrowser1.Document.All;
			if (all.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < all.Count; i++)
			{
				HtmlElement htmlElement = all[i];
				string name = htmlElement.Name;
				string tagName = htmlElement.TagName;
				if (tagName == "HTML")
				{
					string text = tagName;
				}
				if (tagName.ToLowerInvariant() == "div" && htmlElement.Id == "player")
				{
					switch (opz)
					{
					case 0:
						htmlElement.Style = "position:fixed;top:0px;left:0;height:142px;width:253px;";
						break;
					case 1:
						htmlElement.Style = "position:fixed;top:0px;left:0;height:112px;width:253px;";
						break;
					case 10:
						htmlElement.Style = "position:fixed;top:0px;left:0;height:" + grandezzay + "px;width:" + grandezzax + "px;";
						break;
					default:
						htmlElement.Style = null;
						break;
					}
				}
			}
			webBrowser1.ScrollBarsEnabled = false;
		}
		catch
		{
		}
	}

	private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		docpres = webBrowser1.DocumentText;
		linkLabel3.Text = webBrowser1.Url.ToString();
		if (webBrowser1.Url.ToString().IndexOf("justin") >= 0)
		{
		}
		if (webBrowser1.Url.ToString().IndexOf("directon.tv") >= 0 && Program.mio.modificavideo)
		{
			grandezzax = Width + 20;
			grandezzay = Height + 20;
		}
		// BONIFICA 2026: i link MegaUpload/Megavideo non sono piu' supportati (servizi morti nel 2012)
		if (false)
		{
			button9.Visible = true;
		}
		else
		{
			button9.Visible = false;
		}
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			string documentText = webBrowser1.DocumentText;
			documentText = documentText.Substring(documentText.IndexOf("&lt;object"));
			string text = "";
			if (webBrowser1.Url.ToString().IndexOf("justin") >= 0)
			{
				text = documentText.Substring(0, documentText.IndexOf("\""));
			}
			else if (webBrowser1.Url.ToString().IndexOf("livestream") >= 0)
			{
				text = documentText.Substring(0, documentText.IndexOf("'"));
			}
			text = text.Replace("&lt;", "<");
			text = text.Replace("&gt;", ">");
			text = text.Replace("&quot;", "\"");
			int num = Height - 100;
			int num2 = Width - 30;
			if (webBrowser1.Url.ToString().IndexOf("justin") >= 0)
			{
				string text2 = text.Substring(0, text.IndexOf("height="));
				text2 = text2 + "height=\"" + num + "\"";
				string text3 = text.Substring(text.IndexOf("height="));
				text3 = text3.Substring(text3.IndexOf("\"") + 1);
				text3 = text3.Substring(text3.IndexOf("\"") + 1);
				string text4 = text3;
				text3 = text3.Substring(0, text3.IndexOf("width="));
				text4 = text4.Substring(text4.IndexOf("width="));
				text4 = text4.Substring(text4.IndexOf("\"") + 1);
				text4 = text4.Substring(text4.IndexOf("\"") + 1);
				text = text2 + text3 + "width=\"" + num2 + "\"" + text4;
				text = text.Replace("auto_play=false", "auto_play=true");
				if (text.IndexOf("</object>") >= 0)
				{
					text = text.Substring(0, text.IndexOf("</object>") + 9);
				}
			}
			else
			{
				string text2 = text.Substring(0, text.IndexOf("width="));
				text2 = text2 + "width=\"" + num2 + "\"";
				string text3 = text.Substring(text.IndexOf("width="));
				text3 = text3.Substring(text3.IndexOf("\"") + 1);
				text3 = text3.Substring(text3.IndexOf("\"") + 1);
				string text4 = text3;
				text3 = text3.Substring(0, text3.IndexOf("height="));
				text4 = text4.Substring(text4.IndexOf("height="));
				text4 = text4.Substring(text4.IndexOf("\"") + 1);
				text4 = text4.Substring(text4.IndexOf("\"") + 1);
				text = text2 + text3 + "height=\"" + num + "\"" + text4;
				text = text.Replace("autoPlay=false", "autoPlay=true");
				if (text.IndexOf("</object>") >= 0)
				{
					text = text.Substring(0, text.IndexOf("</object>") + 9);
				}
			}
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\tmpjustin");
			streamWriter.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"DTD/xhtml1-transitional.dtd\">");
			streamWriter.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
			streamWriter.WriteLine("<body>");
			streamWriter.WriteLine(text);
			streamWriter.WriteLine("<a href=\"" + webBrowser1.Url.ToString() + "\" target=\"_blank\">Apri pagina justin con Webbrowser predefinito</a>");
			streamWriter.WriteLine("</body>");
			streamWriter.WriteLine("</html>");
			streamWriter.Close();
			webBrowser1.Navigate(Program.pr + "\\tmpjustin");
			apertospecial = true;
		}
		catch
		{
			Process.Start(webBrowser1.Url.ToString());
		}
	}

	private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(linkLabel3.Text);
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		TopMost = checkBox1.Checked;
	}

	private void WEBTV_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void WEBTV_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (FormBorderStyle != FormBorderStyle.Sizable)
		{
			e.Cancel = true;
		}
	}

	private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
	{
	}

	private void WEBTV_Resize(object sender, EventArgs e)
	{
		try
		{
			button2.Location = new Point(Size.Width - 75, button2.Location.Y);
			button3.Location = new Point(button2.Location.X - (button3.Size.Width + 7), button2.Location.Y);
			checkBox1.Location = new Point(button2.Location.X - (button3.Size.Width + 7), button2.Location.Y + 23);
			if (webBrowser1.Url.ToString().IndexOf("directon.tv") >= 0 && Program.mio.modificavideo)
			{
				grandezzax = Width;
				grandezzay = Height - 10;
			}
		}
		catch (Exception)
		{
		}
	}

	private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
	{
	}

	private void settatooltip()
	{
		try
		{
			toolTip1.AutoPopDelay = 8000;
			toolTip1.InitialDelay = 1000;
			toolTip1.ReshowDelay = 500;
			toolTip1.ShowAlways = true;
			toolTip1.SetToolTip(button5, ln1.extra);
			toolTip1.SetToolTip(button6, ln2.extra);
		}
		catch (Exception)
		{
		}
	}

	private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		docwb2 = webBrowser2.DocumentText;
	}

	private void button5_Click(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(ln1.link))
			{
				Offerte offerte = new Offerte();
				offerte.webBrowser1.Navigate(ln1.link);
				offerte.Show();
			}
		}
		catch (Exception)
		{
		}
	}

	private void button5_MouseLeave(object sender, EventArgs e)
	{
		settatooltip();
	}

	private void button6_Leave(object sender, EventArgs e)
	{
	}

	private void button6_MouseLeave(object sender, EventArgs e)
	{
		settatooltip();
	}

	private void button6_Click(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(ln2.link))
			{
				Offerte offerte = new Offerte();
				offerte.webBrowser1.Navigate(ln2.link);
				offerte.Show();
			}
		}
		catch (Exception)
		{
		}
	}

	private void button8_Click(object sender, EventArgs e)
	{
		try
		{
			Program.mio.canaleselezionato++;
			Program.mio.label1.Text = Program.mio.canaleselezionato.ToString();
			Program.mio.aspettasionoperpartirefilm = true;
			Program.mio.partiriccan();
		}
		catch (Exception)
		{
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		try
		{
			if (Program.mio.canaleselezionato > 0)
			{
				Program.mio.canaleselezionato--;
			}
			Program.mio.label1.Text = Program.mio.canaleselezionato.ToString();
			Program.mio.aspettasionoperpartirefilm = true;
			Program.mio.partiriccan();
		}
		catch (Exception)
		{
		}
	}

	private void button9_Click(object sender, EventArgs e)
	{
		bool flag = true;
		try
		{
			if (Program.mio.managecan.Visible)
			{
				flag = false;
			}
		}
		catch (Exception)
		{
		}
		if (flag)
		{
			Program.mio.managecan = new ManageCanali(Program.mio);
			Program.mio.managecan.Show();
		}
		else
		{
			Program.mio.managecan.button30_Click(sender, e);
		}
		try
		{
			TTXMEGA.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			Program.mio.TTXSCARICAREVLC.Abort();
		}
		catch (Exception)
		{
		}
		try
		{
			ThreadSimileAltriCanali threadSimileAltriCanali = new ThreadSimileAltriCanali(Program.mio);
			TTXMEGA = new Thread(threadSimileAltriCanali.partieparsa2);
			TTXMEGA.IsBackground = true;
			TTXMEGA.Priority = ThreadPriority.BelowNormal;
			TTXMEGA.Start();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroItaTV.WEBTV));
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.linkLabel3 = new System.Windows.Forms.LinkLabel();
		this.panel2 = new System.Windows.Forms.Panel();
		this.linkLabel2 = new System.Windows.Forms.LinkLabel();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.panel1 = new System.Windows.Forms.Panel();
		this.button4 = new System.Windows.Forms.Button();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.button3 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.splitContainer2 = new System.Windows.Forms.SplitContainer();
		this.button9 = new System.Windows.Forms.Button();
		this.button7 = new System.Windows.Forms.Button();
		this.button8 = new System.Windows.Forms.Button();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.webBrowser2 = new System.Windows.Forms.WebBrowser();
		this.button6 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.panel2.SuspendLayout();
		this.panel1.SuspendLayout();
		this.splitContainer2.Panel1.SuspendLayout();
		this.splitContainer2.Panel2.SuspendLayout();
		this.splitContainer2.SuspendLayout();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.webBrowser1.Location = new System.Drawing.Point(0, 0);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(687, 629);
		this.webBrowser1.TabIndex = 0;
		// BONIFICA 2026: contatore pubblicitario 2011 dell'autore, ora pagina vuota
			this.webBrowser1.Url = new System.Uri("about:blank");
		this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
		this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
		this.textBox1.Location = new System.Drawing.Point(-121, 5);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(396, 20);
		this.textBox1.TabIndex = 1;
		this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.button1.Location = new System.Drawing.Point(0, 31);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "button1";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
		this.splitContainer1.Panel1.Controls.Add(this.linkLabel3);
		this.splitContainer1.Panel1.Controls.Add(this.panel2);
		this.splitContainer1.Panel1.Controls.Add(this.linkLabel1);
		this.splitContainer1.Panel1.Controls.Add(this.panel1);
		this.splitContainer1.Panel1.Controls.Add(this.button3);
		this.splitContainer1.Panel1.Controls.Add(this.label1);
		this.splitContainer1.Panel1.Controls.Add(this.button2);
		this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.White;
		this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
		this.splitContainer1.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseMove);
		this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseDown);
		this.splitContainer1.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseUp);
		this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
		this.splitContainer1.Panel2.Controls.Add(this.button1);
		this.splitContainer1.Panel2.Controls.Add(this.textBox1);
		this.splitContainer1.Size = new System.Drawing.Size(687, 711);
		this.splitContainer1.SplitterDistance = 42;
		this.splitContainer1.TabIndex = 3;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(581, 23);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(97, 17);
		this.checkBox1.TabIndex = 5;
		this.checkBox1.Text = "Sempre Visibile";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
		this.linkLabel3.AutoSize = true;
		this.linkLabel3.LinkColor = System.Drawing.Color.White;
		this.linkLabel3.Location = new System.Drawing.Point(5, 23);
		this.linkLabel3.Name = "linkLabel3";
		this.linkLabel3.Size = new System.Drawing.Size(18, 13);
		this.linkLabel3.TabIndex = 4;
		this.linkLabel3.TabStop = true;
		this.linkLabel3.Text = "url";
		this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
		this.panel2.BackColor = System.Drawing.Color.Transparent;
		this.panel2.Controls.Add(this.linkLabel2);
		this.panel2.Location = new System.Drawing.Point(216, 2);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(218, 23);
		this.panel2.TabIndex = 3;
		this.linkLabel2.AutoSize = true;
		this.linkLabel2.LinkColor = System.Drawing.Color.White;
		this.linkLabel2.Location = new System.Drawing.Point(5, 5);
		this.linkLabel2.Name = "linkLabel2";
		this.linkLabel2.Size = new System.Drawing.Size(207, 13);
		this.linkLabel2.TabIndex = 1;
		this.linkLabel2.TabStop = true;
		this.linkLabel2.Text = "CREA PLAYER GRANDEZZA FINESTRA";
		this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.LinkColor = System.Drawing.Color.White;
		this.linkLabel1.Location = new System.Drawing.Point(89, 7);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(123, 13);
		this.linkLabel1.TabIndex = 0;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "Salva link pagina attuale";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
		this.panel1.Controls.Add(this.button4);
		this.panel1.Controls.Add(this.comboBox5);
		this.panel1.Controls.Add(this.label3);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Controls.Add(this.textBox2);
		this.panel1.Location = new System.Drawing.Point(222, 0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(354, 25);
		this.panel1.TabIndex = 3;
		this.button4.ForeColor = System.Drawing.Color.Black;
		this.button4.Location = new System.Drawing.Point(307, 5);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(35, 19);
		this.button4.TabIndex = 18;
		this.button4.Text = "ok";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.comboBox5.ForeColor = System.Drawing.Color.Black;
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Items.AddRange(new object[23]
		{
			"Rai", "Sport", "Notiziari", "Cinema", "Cultura", "Divertimento", "Generalista", "Musica", "Meteo", "Regionale",
			"Mediaset", "Radio", "Tecnologia", "Moda", "Hot", "Documentari", "Arte", "Televendita", "Eventi", "Religione",
			"Fiera", "WebCam", "Esteri"
		});
		this.comboBox5.Location = new System.Drawing.Point(199, 3);
		this.comboBox5.Margin = new System.Windows.Forms.Padding(2);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(93, 21);
		this.comboBox5.TabIndex = 17;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(152, 7);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(42, 13);
		this.label3.TabIndex = 2;
		this.label3.Text = "Genere";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 6);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(35, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "Nome";
		this.textBox2.Location = new System.Drawing.Point(42, 3);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(100, 20);
		this.textBox2.TabIndex = 0;
		this.button3.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button3.BackgroundImage = ZeroItaTV.Properties.Resources.tutto_schermo;
		this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button3.Location = new System.Drawing.Point(592, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(37, 22);
		this.button3.TabIndex = 2;
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(3, 7);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(68, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "WEBTVOSA";
		this.button2.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button2.BackgroundImage = ZeroItaTV.Properties.Resources.chiudi;
		this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button2.Location = new System.Drawing.Point(635, 2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(37, 22);
		this.button2.TabIndex = 0;
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer2.IsSplitterFixed = true;
		this.splitContainer2.Location = new System.Drawing.Point(0, 0);
		this.splitContainer2.Name = "splitContainer2";
		this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer2.Panel1.Controls.Add(this.webBrowser1);
		this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.splitContainer2.Panel2.Controls.Add(this.button9);
		this.splitContainer2.Panel2.Controls.Add(this.button7);
		this.splitContainer2.Panel2.Controls.Add(this.button8);
		this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
		this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
		this.splitContainer2.Size = new System.Drawing.Size(687, 665);
		this.splitContainer2.SplitterDistance = 629;
		this.splitContainer2.TabIndex = 3;
		this.button9.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button9.ForeColor = System.Drawing.Color.DarkSalmon;
		this.button9.Location = new System.Drawing.Point(104, 5);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(159, 22);
		this.button9.TabIndex = 5;
		this.button9.Text = "Guarda Su VLC";
		this.button9.UseVisualStyleBackColor = false;
		this.button9.Click += new System.EventHandler(this.button9_Click);
		this.button7.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button7.BackgroundImage = ZeroItaTV.Properties.Resources.Step_Back_Pressed_Blue_icon;
		this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button7.Location = new System.Drawing.Point(3, 5);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(37, 22);
		this.button7.TabIndex = 4;
		this.button7.UseVisualStyleBackColor = false;
		this.button7.Click += new System.EventHandler(this.button7_Click);
		this.button8.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button8.BackgroundImage = ZeroItaTV.Properties.Resources.Step_Forward_Pressed_Blue_icon;
		this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button8.Location = new System.Drawing.Point(46, 5);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(37, 22);
		this.button8.TabIndex = 3;
		this.button8.UseVisualStyleBackColor = false;
		this.button8.Click += new System.EventHandler(this.button8_Click);
		this.groupBox1.Controls.Add(this.webBrowser2);
		this.groupBox1.Controls.Add(this.button6);
		this.groupBox1.Controls.Add(this.button5);
		this.groupBox1.ForeColor = System.Drawing.Color.White;
		this.groupBox1.Location = new System.Drawing.Point(621, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(637, 37);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Attuali offerte che potrebbero interessarti..";
		this.webBrowser2.Location = new System.Drawing.Point(611, 12);
		this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser2.Name = "webBrowser2";
		this.webBrowser2.Size = new System.Drawing.Size(20, 20);
		this.webBrowser2.TabIndex = 2;
		this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
		this.button6.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button6.ForeColor = System.Drawing.Color.White;
		this.button6.Location = new System.Drawing.Point(318, 13);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(289, 20);
		this.button6.TabIndex = 1;
		this.button6.UseVisualStyleBackColor = false;
		this.button6.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
		this.button6.Click += new System.EventHandler(this.button6_Click);
		this.button6.Leave += new System.EventHandler(this.button6_Leave);
		this.button5.BackColor = System.Drawing.Color.FromArgb(87, 107, 156);
		this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button5.ForeColor = System.Drawing.Color.White;
		this.button5.Location = new System.Drawing.Point(9, 13);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(289, 20);
		this.button5.TabIndex = 0;
		this.button5.UseVisualStyleBackColor = false;
		this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.toolTip1.IsBalloon = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(687, 711);
		base.ControlBox = false;
		base.Controls.Add(this.splitContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "WEBTV";
		base.Opacity = 0.0;
		this.Text = "WEBTVOSA";
		base.Load += new System.EventHandler(this.WEBTV_Load);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WEBTV_FormClosed);
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WEBTV_FormClosing);
		base.Resize += new System.EventHandler(this.WEBTV_Resize);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		this.splitContainer1.ResumeLayout(false);
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.splitContainer2.Panel1.ResumeLayout(false);
		this.splitContainer2.Panel2.ResumeLayout(false);
		this.splitContainer2.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
