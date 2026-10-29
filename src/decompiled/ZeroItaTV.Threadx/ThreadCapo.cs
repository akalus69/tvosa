// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ZeroItaTV.Threadx;

internal class ThreadCapo
{
	private Form1 mio;

	private Form miox;

	private Ringraziamenti mio2;

		// BONIFICA 2026-10-28: campo 'mio3' (GamesLink) rimosso.

		private string ric = "";

	private string canale = "";

	[DllImport("user32.dll")]
	private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("user32.dll")]
	private static extern bool SetForegroundWindow(IntPtr hWnd);

	public ThreadCapo(Form1 m)
	{
		mio = m;
	}

	public ThreadCapo(Ringraziamenti m, int ixs)
	{
		mio2 = m;
	}

	public ThreadCapo(Form m)
		{
			miox = m;
		}

		// BONIFICA 2026-10-28: ctor GamesLink rimosso (form giochi pirata eliminata).

		public ThreadCapo(Form1 m, string x, string c)
	{
		mio = m;
		ric = x;
		canale = c;
	}

	private void scriviparola(string p, Label x)
	{
		try
		{
			for (int i = 0; i < p.Length; i++)
			{
				x.Text += p[i];
				Thread.Sleep(20);
			}
		}
		catch
		{
		}
	}

	public void scaricafile()
	{
		try
		{
			string text = mio.filedascaricare.Substring(mio.filedascaricare.LastIndexOf("/") + 1);
			if (text.Length < 4)
			{
				text = "bubu.avi";
			}
			WebClient webClient = new WebClient();
			Uri address = new Uri(mio.filedascaricare);
			webClient.DownloadFile(address, Program.pr + "\\" + text);
			MessageBox.Show("Fatto padrone");
			Process.Start(Program.pr);
		}
		catch (Exception)
		{
		}
	}

	// BONIFICA 2026-10-28: scaricaimmaginetelefilm() rimosso (usava GamesLink, form eliminata).
	public void leggiaggiornamento()
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


	public void aggiornalistamediasetrai(Form1 miox)
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


	public void aggiornalistaopzioni(Form1 miox)
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


    // BONIFICA 2026-10-28: aggiornalistagiochi() rimosso (lista giochi Flash pirata).
	public void aggiornaplainternet(Form1 miox)
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


	public void aggiornacanaliesclusi(Form1 miox)
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


	public void aggiornacanalicripto(Form1 miox)
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


	public string cercaZR()
	{
		string result = "000";
		try
		{
			StreamReader streamReader = new StreamReader(Program.pr + "\\pl\\optzr");
			result = streamReader.ReadLine();
			streamReader.Close();
		}
		catch
		{
		}
		return result;
	}

	public void aggiornaZR()
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


	public void aggiorna()
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}


	public void invia()
	{
		// 2026 BONIFICA: la vecchia funzione spediva la lista via SMTP con
		// credenziali in codice nel sorgente. Rimossa: la lista e' un file
		// testuale nella cartella dell'app, ognuno la condivide come vuole.
		try
		{
			MessageBox.Show("La tua Lista Canali e' nel file nuovicanali.txt dentro la cartella di TVOSA: copiala e condividila come preferisci.");
		}
		catch
		{
		}
	}

	public void scrivi()
	{
		Thread.Sleep(1000);
		string text = "TVOSA: " + Environment.NewLine + "Questo programma ha l'intento di agevolare la visione della televisione da sorgenti ufficiali. Nel 2026 il progetto e' open: se conosci canali legali puoi aggiungerli modificando nuovicanali.txt nella cartella dell'app.";
		while (text.IndexOf(" ") >= 0)
		{
			string p = text.Substring(0, text.IndexOf(" ") + 1);
			text = text.Substring(text.IndexOf(" ") + 1);
			scriviparola(p, mio2.label1);
		}
		scriviparola(text, mio2.label1);
		mio2.linkLabel1.Visible = true;
	}

	public void scrivi2()
	{
		Thread.Sleep(1000);
		string text = "Openyourm: " + Environment.NewLine + "TVOSA nasce per facilitare la vita a tutti quegli utenti che vogliono vedere e registrare le proprie trasmissioni preferite.È un programma che cresce insieme a voi, più sarete più contenuti e canali verranno aggiunti. Per qualsiasi problema contattateci.";
		while (text.IndexOf(" ") >= 0)
		{
			string p = text.Substring(0, text.IndexOf(" ") + 1);
			text = text.Substring(text.IndexOf(" ") + 1);
			scriviparola(p, mio2.label2);
		}
		scriviparola(text, mio2.label2);
	}

	public void scrivi3()
	{
		Thread.Sleep(1000);
		string text = "Striller: " + Environment.NewLine + "L'idea alla base di TVOSA è la possibilità di avere a portata di mano (ops.. di clic), in maniera facile e veloce tutte le webTV presenti in rete, e non solo, così da creare una nuova televisione in cui è l'utente a scegliere i contenuti più appropriati per le proprie esigenze.";
		while (text.IndexOf(" ") >= 0)
		{
			string p = text.Substring(0, text.IndexOf(" ") + 1);
			text = text.Substring(text.IndexOf(" ") + 1);
			scriviparola(p, mio2.label3);
		}
		scriviparola(text, mio2.label3);
	}

	public void componi()
	{
		try
		{
			double num = 0.0;
			miox.Opacity = num;
			while (miox.Opacity < 1.0)
			{
				num += 0.1;
				miox.Opacity = num;
				Thread.Sleep(100);
			}
		}
		catch
		{
			try
			{
				mio.Opacity = 1.0;
			}
			catch (Exception)
			{
			}
		}
	}

	public void componiINV()
	{
		try
		{
			double num = 1.0;
			miox.Opacity = num;
			while (miox.Opacity > 0.0)
			{
				num -= 0.1;
				miox.Opacity = num;
				Thread.Sleep(100);
			}
			miox.Hide();
		}
		catch
		{
			mio.Opacity = 0.0;
		}
	}

	public void dissolvi()
	{
		double num = 1.0;
		miox.Opacity = num;
		while (miox.Opacity > 0.1)
		{
			num -= 0.1;
			miox.Opacity = num;
			Thread.Sleep(100);
		}
	}

	public void partieuccidiweb()
	{
		try
		{
			try
			{
				string text = ric.Substring(ric.IndexOf("|||") + 3);
				int num = int.Parse(text.Substring(0, text.IndexOf(":")));
				int num2 = int.Parse(text.Substring(text.IndexOf(":") + 1));
				DateTime now = DateTime.Now;
				num -= now.Hour;
				if (num2 > now.Minute)
				{
					num2 -= now.Minute;
				}
				else
				{
					num2 = num2 + 60 - now.Minute;
					num--;
					if (num < 0)
					{
						num = 0;
					}
				}
				Process[] processes = Process.GetProcesses();
				if (canale.IndexOf("rai1.txt") >= 0)
				{
					mio.TVweb.guarda(mio.raiunow);
					mio.TVweb.mostra();
				}
				else if (canale.IndexOf("rai2.txt") >= 0)
				{
					mio.TVweb.guarda(mio.raiduew);
					mio.TVweb.mostra();
				}
				else if (canale.IndexOf("rai3.txt") >= 0)
				{
					mio.TVweb.guarda(mio.raitrew);
					mio.TVweb.mostra();
				}
				else if (canale.IndexOf("cinque.txt") >= 0)
				{
					mio.TVweb.guarda(mio.cinquew);
					mio.TVweb.mostra();
				}
				else if (canale.IndexOf("italia.txt") >= 0)
				{
					mio.TVweb.guarda(mio.italia1w);
					mio.TVweb.mostra();
				}
				else if (canale.IndexOf("quattro.txt") >= 0)
				{
					mio.TVweb.guarda(mio.quattrow);
					mio.TVweb.mostra();
				}
				else
				{
					mio.TVweb.guarda(canale);
					mio.TVweb.mostra();
				}
				int num3 = num2 * 60 + num * 60 * 60;
				Thread.Sleep(9000);
				while (num3 > 0)
				{
					Thread.Sleep(1000);
					num3--;
				}
				Thread.Sleep(240000);
				mio.TVweb.distruggi();
			}
			catch (Exception)
			{
			}
		}
		catch
		{
		}
	}

	public void partieuccidi()
	{
		// BONIFICA 2026: catena di registrazione 2011 (VLC + pl/ZR.exe) disattivata:
		// nel 2026 le registrazioni passano da RecorderService + sidecar yt-dlp.
	}


	private void log(IList<string> x)
	{
		try
		{
			if (!File.Exists(Program.pr + "\\log.txt"))
			{
				return;
			}
			StreamWriter streamWriter = new StreamWriter(Program.pr + "\\log.txt", append: true);
			streamWriter.WriteLine("log ora :" + DateTime.Now.ToString());
			foreach (string item in x)
			{
				streamWriter.WriteLine(item);
			}
			streamWriter.Close();
		}
		catch
		{
		}
	}

	private string creafilebatregistrazione(string ch, string fl)
	{
		string text = "";
		try
		{
			if (!Directory.Exists(Program.pr + "\\pl\\tmp"))
			{
				Directory.CreateDirectory(Program.pr + "\\pl\\tmp");
			}
			for (int i = 0; i < 100; i++)
			{
				if (!File.Exists(Program.pr + "\\pl\\tmp\\tmp" + i + ".bat"))
				{
					text = Program.pr + "\\pl\\tmp\\tmp" + i + ".bat";
					break;
				}
			}
			StreamWriter streamWriter = new StreamWriter(text);
			streamWriter.WriteLine("set \"zatswf=http://zattoo.com/static/player.swf?\"");
			if (mio.tipoprocessore == "x86")
			{
				streamWriter.WriteLine("set \"vlc=c:\\progra~1\\videolan\\vlc\\vlc\"");
			}
			else
			{
				streamWriter.WriteLine("set \"vlc=c:\\progra~2\\videolan\\vlc\\vlc\"");
			}
			streamWriter.WriteLine("wget -q -O temp.txt \"http://zeroradio.altervista.org/zerol.php\"");
			streamWriter.WriteLine("find \"" + ch + "\"<temp.txt>chann.txt");
			streamWriter.WriteLine("erase temp.txt");
			streamWriter.WriteLine("set /p chan=<chann.txt");
			streamWriter.WriteLine("erase chann.txt");
			streamWriter.WriteLine("call flv -v -W \"%zatswf%\" -r \"%chan%\" -q > \"" + fl + "\"");
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
		return text;
	}

	private string creafilebatregistraziones(string ch, string fl)
	{
		string text = "";
		try
		{
			if (!Directory.Exists(Program.pr + "\\pl\\tmp"))
			{
				Directory.CreateDirectory(Program.pr + "\\pl\\tmp");
			}
			for (int i = 0; i < 100; i++)
			{
				if (!File.Exists(Program.pr + "\\pl\\tmp\\tmp" + i + ".bat"))
				{
					text = Program.pr + "\\pl\\tmp\\tmp" + i + ".bat";
					break;
				}
			}
			StreamWriter streamWriter = new StreamWriter(text);
			streamWriter.WriteLine("call flv -v -r " + ch + " -q > \"" + fl + "\"");
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
		return text;
	}

public void partieuccidireg()
	{
		try
		{
			IList<string> list = new List<string>();
			string text = ric.Substring(0, ric.IndexOf("|||"));
			DateTime now = DateTime.Now;
			text = now.Day + "_" + now.Month + "_" + now.Year + "_" + text;
			text = text.Replace("  ", "");
			text = text.Replace(" ", "_");
			text = text.Replace(":", "_");
			string text2 = ric.Substring(ric.IndexOf("|||") + 3);
			int num = int.Parse(text2.Substring(0, text2.IndexOf(":")));
			int num2 = int.Parse(text2.Substring(text2.IndexOf(":") + 1));
			DateTime end = now.Date.AddHours(num).AddMinutes(num2);
			if (end <= now)
			{
				end = end.AddDays(1.0);
			}
			list.Add("File video da salvare : " + text);
			list.Add("Tempo Fine : " + text2);
			string url = urlregistrazione(canale);
			if (url == "")
			{
				list.Add("Canale non registrabile con le sorgenti ufficiali attuali: " + canale);
				log(list);
				return;
			}
			RecorderService recorderService = new RecorderService();
			string error;
			if (!recorderService.Start(url, mio.dvreg, text, out error))
			{
				list.Add("Errore avvio registrazione: " + error);
				log(list);
				return;
			}
			list.Add("Registrazione avviata (motore yt-dlp, sorgente ufficiale): " + url);
			log(list);
			while (DateTime.Now < end && recorderService.IsRecording)
			{
				Thread.Sleep(5000);
			}
			recorderService.Stop();
			list.Clear();
			list.Add("Registrazione terminata : " + text);
			log(list);
		}
		catch
		{
		}
	}

	// BONIFICA 2026-10-28: mappatura SOLO sorgenti ufficiali (RaiPlay / RSI).
	// I vecchi rami Mediaset/cielo/la7 usavano re-stream o bat morti: rimossi.
	// MCP 2026: public perche' ControlServer la riusa per /record e /schedule.
public static string urlregistrazione(string canale)
	{
		if (canale == "")
		{
			return "";
		}
		if (canale.IndexOf("http") == 0 && (canale.IndexOf("raiplay.it") >= 0 || canale.IndexOf("rai.it") >= 0 || canale.IndexOf("rsi.ch") >= 0 || canale.IndexOf("youtube.com") >= 0))
		{
			return canale;
		}
		if (canale.IndexOf("rai1") >= 0 || canale.IndexOf("rai 1") >= 0)
		{
			return "https://www.raiplay.it/dirette/rai1";
		}
		if (canale.IndexOf("rai2") >= 0 || canale.IndexOf("rai 2") >= 0)
		{
			return "https://www.raiplay.it/dirette/rai2";
		}
		if (canale.IndexOf("rai3") >= 0 || canale.IndexOf("rai 3") >= 0)
		{
			return "https://www.raiplay.it/dirette/rai3";
		}
		if (canale.IndexOf("rainews") >= 0 || canale.IndexOf("rai news") >= 0)
		{
			return "https://www.raiplay.it/dirette/rainews24";
		}
		if (canale.IndexOf("raisport") >= 0 || canale.IndexOf("rai sport") >= 0)
		{
			return "https://www.raiplay.it/dirette/raisport";
		}
		// RINASCITA 2026: nuove reti RAI risolvibili da yt-dlp
		if (canale.IndexOf("rai4") >= 0 || canale.IndexOf("rai 4") >= 0)
		{
			return "https://www.raiplay.it/dirette/rai4";
		}
		if (canale.IndexOf("rai5") >= 0 || canale.IndexOf("rai 5") >= 0)
		{
			return "https://www.raiplay.it/dirette/rai5";
		}
		if (canale.IndexOf("movie") >= 0)
		{
			return "https://www.raiplay.it/dirette/raimovie";
		}
		if (canale.IndexOf("premium") >= 0)
		{
			return "https://www.raiplay.it/dirette/raipremium";
		}
		if (canale.IndexOf("yoyo") >= 0)
		{
			return "https://www.raiplay.it/dirette/raiyoyo";
		}
		if (canale.IndexOf("gulp") >= 0)
		{
			return "https://www.raiplay.it/dirette/raigulp";
		}
		if (canale.IndexOf("storia") >= 0)
		{
			return "https://www.raiplay.it/dirette/raistoria";
		}
		// RINASCITA 2026: canali ufficiali in diretta 24/7 su YouTube (registrabili)
		if (canale.IndexOf("sky tg24") >= 0 || canale.IndexOf("skytg24") >= 0)
		{
			return "https://www.youtube.com/@SkyTG24/live";
		}
		if (canale.IndexOf("euronews it") >= 0 || canale.IndexOf("euronews italia") >= 0)
		{
			return "https://www.youtube.com/@euronewsit/live";
		}
		if (canale.IndexOf("euronews") >= 0)
		{
			return "https://www.youtube.com/@euronews/live";
		}
		// RINASCITA 2026: tv estere ufficiali 24/7 su YouTube
		if (canale.IndexOf("sky news") >= 0)
		{
			return "https://www.youtube.com/@SkyNews/live";
		}
		// RINASCITA 2026: giro del mondo (piu' specifici prima dei generici)
		if (canale.IndexOf("abc news australia") >= 0)
		{
			return "https://www.youtube.com/@abcnewsaustralia/live";
		}
		if (canale.IndexOf("cbc") >= 0)
		{
			return "https://www.youtube.com/@CBCNews/live";
		}
		if (canale.IndexOf("rtve") >= 0)
		{
			return "https://www.youtube.com/@rtvenoticias/live";
		}
		if (canale.IndexOf("franceinfo") >= 0)
		{
			return "https://www.youtube.com/@franceinfo/live";
		}
		if (canale.IndexOf("tvp") >= 0)
		{
			return "https://www.youtube.com/@TVPinfo/live";
		}
		if (canale.IndexOf("nippon") >= 0)
		{
			return "https://www.youtube.com/@ntv_news/live";
		}
		if (canale.IndexOf("ytn") >= 0)
		{
			return "https://www.youtube.com/@ytnnews24/live";
		}
		if (canale.IndexOf("kbs") >= 0)
		{
			return "https://www.youtube.com/@kbsworldtv/live";
		}
		if (canale.IndexOf("republic") >= 0)
		{
			return "https://www.youtube.com/@RepublicWorld/live";
		}
		if (canale.IndexOf("hadath") >= 0)
		{
			return "https://www.youtube.com/@AlHadath/live";
		}
		if (canale.IndexOf("canal 26") >= 0 || canale.IndexOf("canal26") >= 0)
		{
			return "https://www.youtube.com/@canal26/live";
		}
		if (canale.IndexOf("ewtn") >= 0)
		{
			return "https://www.youtube.com/@EWTNLiveMass/live";
		}
		if (canale.IndexOf("nature") >= 0)
		{
			return "https://www.youtube.com/@RedSquirrelStudios/live";
		}
		if (canale.IndexOf("abc news") >= 0)
		{
			return "https://www.youtube.com/@ABCNews/live";
		}
		if (canale.IndexOf("nbc") >= 0)
		{
			return "https://www.youtube.com/@NBCNews/live";
		}
		if (canale.IndexOf("trt haber") >= 0)
		{
			return "https://www.youtube.com/@trthaber/live";
		}
		if (canale.IndexOf("trt") >= 0)
		{
			return "https://www.youtube.com/@trtworld/live";
		}
		if (canale.IndexOf("nhk") >= 0)
		{
			return "https://www.youtube.com/@NHKWorldJapan/live";
		}
		if (canale.IndexOf("france 24 fr") >= 0)
		{
			return "https://www.youtube.com/@FRANCE24/live";
		}
		if (canale.IndexOf("mubasher") >= 0)
		{
			return "https://www.youtube.com/@aljazeeramubasher/live";
		}
		if (canale.IndexOf("arabiya") >= 0)
		{
			return "https://www.youtube.com/@AlArabiya/live";
		}
		if (canale.IndexOf("cgtn") >= 0)
		{
			return "https://www.youtube.com/@cgtn/live";
		}
		if (canale.IndexOf("wion") >= 0)
		{
			return "https://www.youtube.com/@WION/live";
		}
		if (canale.IndexOf("lofi") >= 0)
		{
			return "https://www.youtube.com/@LofiGirl/live";
		}
		if (canale.IndexOf("france 24") >= 0 || canale.IndexOf("france24") >= 0)
		{
			return "https://www.youtube.com/france24/live";
		}
		if (canale.IndexOf("dw news") >= 0 || canale.IndexOf("dwnews") >= 0)
		{
			return "https://www.youtube.com/@dwnews/live";
		}
		if (canale.IndexOf("al jazeera") >= 0 || canale.IndexOf("aljazeera") >= 0)
		{
			return "https://www.youtube.com/@aljazeeraenglish/live";
		}
		if (canale.IndexOf("nasa") >= 0)
		{
			return "https://www.youtube.com/@NASA/live";
		}
		if (canale.IndexOf("bloomberg") >= 0)
		{
			return "https://www.youtube.com/@markets/live";
		}
		if (canale.IndexOf("tv2000") >= 0 || canale.IndexOf("tv 2000") >= 0)
		{
			return "https://www.youtube.com/@Tv2000it/live";
		}
		if (canale.IndexOf("deejay tv") >= 0 || canale.IndexOf("deejaytv") >= 0)
		{
			return "https://www.youtube.com/@mydeejay/live";
		}
		return "";
	}
	private string leggicanaleurl3(string url)
	{
		string result = "";
		try
		{
			Process.Start(Program.pr + "\\pl\\wget.exe", "--header=\"viaurl: www.rai.tv\" " + url + " -q --output-document=\"" + Program.pr + "\\pl\\can.txt\" - ");
			while (!File.Exists(Program.pr + "\\pl\\can.txt"))
			{
				Thread.Sleep(100);
			}
			Thread.Sleep(14000);
			StreamReader streamReader = new StreamReader(Program.pr + "\\pl\\can.txt");
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			File.Delete(Program.pr + "\\pl\\can.txt");
			if (text.IndexOf("HREF=") >= 0)
			{
				text = text.Substring(text.IndexOf("HREF=") + 6);
				result = text.Substring(0, text.IndexOf("\""));
			}
		}
		catch
		{
		}
		return result;
	}

	public static string EncodeTo64(string toEncode)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(toEncode);
		return Convert.ToBase64String(bytes);
	}

	private string leggicanaleurl(string url)
	{
		// BONIFICA 2026: risoluzione URL mms via pl/ZR.exe rimossa (2026 usa yt-dlp).
		return "";
	}


	private string leggicanaleurl5(string url)
	{
		string text = "";
		try
		{
			string text2 = url.Substring(url.LastIndexOf("=") + 1);
			try
			{
				Stream stream = null;
				WebRequest webRequest = WebRequest.Create("http://videowall.rai.it/cgi-bin/date");
				WebResponse response = webRequest.GetResponse();
				stream = response.GetResponseStream();
				StreamReader streamReader = new StreamReader(stream, Encoding.UTF7);
				text = streamReader.ReadToEnd();
				streamReader.Close();
				stream.Close();
			}
			catch
			{
			}
			string text3 = text2 + ";" + text;
			char[] array = text3.ToCharArray();
			string text4 = "";
			int num = 0;
			char[] array2 = array;
			foreach (char value in array2)
			{
				int num2 = Convert.ToInt32(value);
				num2 += num;
				text4 += Convert.ToChar(num2);
				num++;
			}
			string text5 = EncodeTo64(text4);
			Process process = new Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Verb = "tvosagetlab";
			process.StartInfo.FileName = Program.pr + "\\pl\\curl.exe";
			process.StartInfo.Arguments = "-A \"Mozilla/5.0 (Windows; U; Windows NT 6.1; it; rv:1.9.2) Gecko/20100115 Firefox/3.6\" -H \"Connection: keep-alive\" -H \"Keep-Alive: 300\" -H \"viaurl: www.rai.tv\" -H \"ttAuth: " + text5 + "\" -H \"Content-Lenght: 0\" " + url + " --output \"" + Program.pr + "\\pl\\can.txt\"";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			while (!File.Exists(Program.pr + "\\pl\\can.txt"))
			{
				Thread.Sleep(100);
			}
			for (int j = 0; j < 8; j++)
			{
				bool flag = false;
				Process[] processes = Process.GetProcesses();
				foreach (Process process2 in processes)
				{
					if (process2.ProcessName == "curl")
					{
						flag = true;
					}
				}
				if (!flag)
				{
					j = 8;
					break;
				}
				Thread.Sleep(1000);
			}
			StreamReader streamReader2 = new StreamReader(Program.pr + "\\pl\\can.txt");
			string text6 = streamReader2.ReadToEnd();
			streamReader2.Close();
			File.Delete(Program.pr + "\\pl\\can.txt");
			if (text6.IndexOf("HREF=") >= 0)
			{
				text6 = text6.Substring(text6.IndexOf("HREF=") + 6);
				text = text6.Substring(0, text6.IndexOf("\""));
			}
		}
		catch
		{
		}
		return text;
	}

	private string leggicanaleurl4(string url)
	{
		string result = "";
		try
		{
			Process process = new Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Verb = "tvosagetlab";
			process.StartInfo.FileName = Program.pr + "\\pl\\wget.exe";
			process.StartInfo.Arguments = "--header=\"viaurl: www.rai.tv\" " + url + " -q --output-document=\"" + Program.pr + "\\pl\\can.txt\" - ";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			while (!File.Exists(Program.pr + "\\pl\\can.txt"))
			{
				Thread.Sleep(100);
			}
			for (int i = 0; i < 8; i++)
			{
				bool flag = false;
				Process[] processes = Process.GetProcesses();
				foreach (Process process2 in processes)
				{
					if (process2.ProcessName == "wget")
					{
						flag = true;
					}
				}
				if (!flag)
				{
					i = 8;
					break;
				}
				Thread.Sleep(1000);
			}
			StreamReader streamReader = new StreamReader(Program.pr + "\\pl\\can.txt");
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			File.Delete(Program.pr + "\\pl\\can.txt");
			if (text.IndexOf("HREF=") >= 0)
			{
				text = text.Substring(text.IndexOf("HREF=") + 6);
				result = text.Substring(0, text.IndexOf("\""));
			}
		}
		catch
		{
		}
		return result;
	}

	private string leggicanaleurl2(string url)
	{
		string result = "";
		try
		{
			Stream stream = null;
			WebRequest webRequest = WebRequest.Create(url);
			WebResponse response = webRequest.GetResponse();
			stream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(stream, Encoding.UTF7);
			result = streamReader.ReadToEnd();
			streamReader.Close();
			stream.Close();
		}
		catch
		{
		}
		return result;
	}

	private void file(string x, string xbk)
	{
		// BONIFICA 2026: catena di registrazione 2011 (VLC + pl/ZR.exe) disattivata:
		// nel 2026 le registrazioni passano da RecorderService + sidecar yt-dlp.
	}


	public void vai()
	{
		// BONIFICA 2026: autoaggiornamento 2011 disattivato: scaricava liste (e un exe!)
		// dal vecchio sito dell'autore, oggi dominio morto che potrebbe essere rigenerato
		// da terzi. TVOSA 2026 usa solo i database locali in data/.
	}

}
