// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using ZeroItaTV.Threadx;

namespace ZeroItaTV
{
	// MCP 2026: micro-server HTTP di controllo, bind SOLO 127.0.0.1 (localhost-only, niente token).
	// Tutte le azioni passano dalle catene ufficiali dell'app (WEBTV, RecorderService,
	// urlregistrazione, file-data 2011 in byte-mode CRLF).
	public static class ControlServer
	{
		private const int Port = 19831;

		private static HttpListener listener;

		private static Form1 mio;

		private static RecorderService recAgent;

		private static string recAgentUrl = "";

		private static string recAgentName = "";

		public static void Start(Form1 form)
		{
			if (listener != null)
			{
				return;
			}
			mio = form;
			listener = new HttpListener();
			listener.Prefixes.Add("http://127.0.0.1:" + Port + "/tvosa/");
			listener.Start();
			Thread th = new Thread(Loop);
			th.IsBackground = true;
			th.Start();
		}

		private static void Loop()
		{
			while (listener.IsListening)
			{
				HttpListenerContext ctx;
				try
				{
					ctx = listener.GetContext();
				}
				catch
				{
					return;
				}
				try
				{
					Handle(ctx);
				}
				catch (Exception ex)
				{
					Reply(ctx, 500, "{\"error\":\"" + Esc(ex.Message) + "\"}");
				}
			}
		}

		private static void Handle(HttpListenerContext ctx)
		{
			string path = ctx.Request.Url.AbsolutePath.TrimStart('/');
			path = path.Substring(Math.Min(path.IndexOf('/') + 1, path.Length)); // toglie 'tvosa'
			string method = ctx.Request.HttpMethod;
			string q = ctx.Request.QueryString.ToString().ToLowerInvariant();
			Dictionary<string, string> p = ParseQuery(ctx.Request.QueryString);
			try
			{
				if (path == "status" && method == "GET")
				{
					Status(ctx);
				}
				else if (path == "channels" && method == "GET")
				{
					List<Dictionary<string, string>> chans = new List<Dictionary<string, string>>();
					foreach (KeyValuePair<string, string> cp in ChannelPairs())
					{
						chans.Add(Dic("name", cp.Key, "url", UrlFromDbValue(cp.Value)));
					}
					Reply(ctx, 200, Arr(chans));
				}
				else if (path == "favorites" && method == "GET")
				{
					List<Dictionary<string, string>> favs = new List<Dictionary<string, string>>();
					foreach (string l in ReadLines(FavFile()))
					{
						if (l.Trim().Length > 0)
						{
							int sp = l.IndexOf(' ');
							favs.Add(Dic("number", l.Substring(0, Math.Max(sp, 0)), "name", l.Substring(Math.Min(sp + 1, l.Length))));
						}
					}
					Reply(ctx, 200, Arr(favs));
				}
				else if (path == "play" && method == "POST")
				{
					Play(ctx, p);
				}
				else if (path == "epg" && method == "GET")
				{
					Epg(ctx, Val(p, "channel"));
				}
				else if (path == "findfilm" && method == "GET")
				{
					FindFilm(ctx, Val(p, "title"), Val(p, "country"));
				}
				else if (path == "trailers" && method == "GET")
				{
					Trailers(ctx, Val(p, "mode"), Val(p, "genre"), Val(p, "type"), Val(p, "offset"), Val(p, "seed"), Val(p, "year"), Val(p, "seen"));
				}
				else if (path == "trailer" && method == "GET")
				{
					Trailer(ctx, Val(p, "title"), Val(p, "year"));
				}
				else if (path == "trailershow" && method == "GET")
				{
					TrailerShow(ctx, p);
				}
				else if (path == "record/start" && method == "POST")
				{
					RecordStart(ctx, p);
				}
				else if (path == "record/stop" && method == "POST")
				{
					RecordStop(ctx);
				}
				else if (path == "recordings" && method == "GET")
				{
					Recordings(ctx);
				}
				else if (path == "schedule" && method == "GET")
				{
					Reply(ctx, 200, Arr(ScheduleList()));
				}
				else if (path == "schedule" && method == "POST")
				{
					ScheduleAdd(ctx, p);
				}
				else if (path == "schedule" && method == "DELETE")
				{
					ScheduleDel(ctx, p);
				}
				else if (path == "channels" && method == "POST")
				{
					ChannelAdd(ctx, p);
				}
				else if (path == "channels" && method == "DELETE")
				{
					ChannelDel(ctx, p);
				}
				else if (path == "favorites" && method == "POST")
				{
					FavAdd(ctx, p);
				}
				else if (path == "favorites" && method == "DELETE")
				{
					FavDel(ctx, p);
				}
				else
				{
					Reply(ctx, 404, "{\"error\":\"endpoint sconosciuto: " + Esc(method + " " + path) + "\"}");
				}
			}
			catch (Exception ex)
			{
				Reply(ctx, 500, "{\"error\":\"" + Esc(ex.Message) + "\"}");
			}
		}

		// ---------- status ----------
		private static void Status(HttpListenerContext ctx)
		{
			bool recording = recAgent != null && recAgent.IsRecording;
			StringBuilder sb = new StringBuilder();
			sb.Append("{");
			sb.Append("\"app\":\"TVOSA rinascita 2026\",");
			sb.Append("\"time\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",");
			sb.Append("\"windows_open\":" + (mio != null && !mio.IsDisposed ? "true" : "false") + ",");
			sb.Append("\"agent_recording\":" + (recording ? "true" : "false") + ",");
			sb.Append("\"agent_rec_url\":\"" + Esc(recAgentUrl) + "\",");
			sb.Append("\"agent_rec_name\":\"" + Esc(recAgentName) + "\",");
			sb.Append("\"schedule_today\":" + ScheduleList().Count + ",");
			sb.Append("\"channels\":" + ChannelPairs().Count + ",");
			sb.Append("\"favorites\":" + ReadLines(FavFile()).Count + ",");
			sb.Append("\"reg_dir\":\"" + Esc(RegDir()) + "\"");
			sb.Append("}");
			Reply(ctx, 200, sb.ToString());
		}

		// ---------- play ----------
		// "Dove vedo un film": delegate al sidecar Python (stessa identica logica
		// JustWatch della finestra TROVA FILM e del tool MCP) in modalita' --json.
		private static void FindFilm(HttpListenerContext ctx, string title, string country)
		{
			if (title == "")
			{
				Reply(ctx, 400, "{\"error\":\"serve title (titolo del film/serie)\"}");
				return;
			}
			if (country == "")
			{
				country = "IT";
			}
			try
			{
				ProcessStartInfo psi = new ProcessStartInfo("py", "-3.13 \"" + Program.pr + "\\tools\\tvosa_find.py\" --json \"" + title.Replace("\"", "") + "\" " + country.ToUpperInvariant());
				psi.WorkingDirectory = Program.pr;
				psi.UseShellExecute = false;
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;
				psi.CreateNoWindow = true;
				psi.StandardOutputEncoding = Encoding.UTF8;
				Process p = Process.Start(psi);
				string stdout = p.StandardOutput.ReadToEnd();
				string stderr = p.StandardError.ReadToEnd();
				if (!p.WaitForExit(45000))
				{
					try
					{
						p.Kill();
					}
					catch
					{
					}
				}
				if (stdout.Trim() == "")
				{
					Reply(ctx, 500, "{\"error\":\"motore di ricerca muto: " + Esc(stderr.Substring(0, Math.Min(stderr.Length, 200))) + "\"}");
					return;
				}
				Reply(ctx, 200, stdout);
			}
			catch (Exception ex)
			{
				Reply(ctx, 500, "{\"error\":\"ricerca film fallita: " + Esc(ex.Message) + "\"}");
			}
		}

		// ---------- selettore serata ----------
		// Pool di candidati (pozzi JustWatch) e trailer YouTube: stesso motore
		// Python della finestra TRAILER e del futuro tool MCP (sidecar tvosa_trailer.py).
		private static void Trailers(HttpListenerContext ctx, string mode, string genre, string tipo, string offset, string seed, string year, string seen)
		{
			if (mode == "")
			{
				mode = "misto";
			}
			if (tipo == "")
			{
				tipo = "film";
			}
			if (offset == "")
			{
				offset = "0";
			}
			string args = "-3.13 \"" + Program.pr.Replace("\\", "/") + "/tools/tvosa_trailer.py\" --json --mode " + mode + " --type " + tipo + " --offset " + offset;
			if (genre != "")
			{
				args = args + " --genre " + genre;
			}
			if (seed != "")
			{
				args = args + " --seed " + seed;
			}
			if (year != "")
			{
				args = args + " --year " + year;
			}
			if (seen != "")
			{
				// lista id separata da virgole: un solo token per il sidecar
				args = args + " --seen " + seen.Replace(" ", "").Replace("\"", "");
			}
			RunSidecar(ctx, args, 60000, "motore trailer muto");
		}

		private static void Trailer(HttpListenerContext ctx, string title, string year)
		{
			if (title == "")
			{
				Reply(ctx, 400, "{\"error\":\"serve title (titolo del film/serie)\"}");
				return;
			}
			string args = "-3.13 \"" + Program.pr.Replace("\\", "/") + "/tools/tvosa_trailer.py\" --json --trailerfor \"" + title.Replace("\"", "") + "\" \"" + year + "\"";
					RunSidecar(ctx, args, 90000, "ricerca trailer muta");
				}

		// apre il pannello TRAILER dell'app. CON filtri (mode/genre/type/year) configura
		// la finestra come un CARICA fatto dall'utente: pool navigabile con
		// AVANTI/INDIETRO fino a esaurimento pozzi, e se passi anche title si parte
		// da quel titolo. SENZA filtri mostra il singolo trailer (MostraDiretto).
		private static void TrailerShow(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			string title = Val(p, "title");
			string year = Val(p, "year");
			string mode = Val(p, "mode");
			string genre = Val(p, "genre");
			string tipo = Val(p, "type");
			bool filtro = mode != "" || genre != "" || tipo != "" || year != "";
			if (title == "" && !filtro)
			{
				Reply(ctx, 400, "{\"error\":\"serve title oppure un filtro (mode/genre/type/year)\"}");
				return;
			}
			if (mio == null || mio.IsDisposed)
			{
				Reply(ctx, 503, "{\"error\":\"UI non disponibile\"}");
				return;
			}
			string embed = null;
			if (!filtro && title != "")
			{
				string a2 = "-3.13 \"" + Program.pr.Replace("\\", "/") + "/tools/tvosa_trailer.py\" --json --trailerfor \"" + title.Replace("\"", "") + "\" \"" + year + "\"";
				try
				{
					ProcessStartInfo psi = new ProcessStartInfo("py", a2);
					psi.WorkingDirectory = Program.pr;
					psi.UseShellExecute = false;
					psi.RedirectStandardOutput = true;
					psi.RedirectStandardError = true;
					psi.CreateNoWindow = true;
					psi.StandardOutputEncoding = Encoding.UTF8;
					Process proc = Process.Start(psi);
					string stdout = proc.StandardOutput.ReadToEnd();
					proc.StandardError.ReadToEnd();
					if (!proc.WaitForExit(90000))
					{
						try
						{
							proc.Kill();
						}
						catch
						{
						}
					}
					stdout = (stdout ?? "").Trim();
					if (stdout.StartsWith("{"))
					{
						object parsed = new System.Web.Script.Serialization.JavaScriptSerializer().DeserializeObject(stdout);
						object em;
						if (parsed is Dictionary<string, object> && ((Dictionary<string, object>)parsed).TryGetValue("embed", out em) && em != null)
						{
							embed = em.ToString();
						}
					}
				}
				catch (Exception ex)
				{
					Reply(ctx, 500, "{\"error\":\"" + Esc(ex.Message) + "\"}");
					return;
				}
			}
			try
			{
				SelettoreTrailers st = (SelettoreTrailers)mio.Invoke(new Func<SelettoreTrailers>(delegate
				{
					SelettoreTrailers s = mio.ApriTrailers();
					if (!s.Visible)
					{
						s.Show();
					}
					else
					{
						s.Activate();
					}
					return s;
				}));
				string emb2 = embed;
				if (filtro)
				{
					st.BeginInvoke((MethodInvoker)delegate
					{
						st.ApriConFiltro(mode, genre, tipo, year, title);
					});
				}
				else
				{
					st.BeginInvoke((MethodInvoker)delegate
					{
						st.MostraDiretto(title, emb2);
					});
				}
				Reply(ctx, 200, "{\"ok\":true,\"opened_in_panel\":true,\"titolo\":\"" + Esc(title) + "\",\"embed\":" + (embed == null ? "null" : "\"" + Esc(embed) + "\"") + "}");
			}
			catch (Exception ex)
			{
				Reply(ctx, 500, "{\"error\":\"" + Esc(ex.Message) + "\"}");
			}
		}
		private static void RunSidecar(HttpListenerContext ctx, string args, int timeoutMs, string errMsg)
		{
			try
			{
				ProcessStartInfo psi = new ProcessStartInfo("py", args);
				psi.WorkingDirectory = Program.pr;
				psi.UseShellExecute = false;
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;
				psi.CreateNoWindow = true;
				psi.StandardOutputEncoding = Encoding.UTF8;
				Process p = Process.Start(psi);
				string stdout = p.StandardOutput.ReadToEnd();
				string stderr = p.StandardError.ReadToEnd();
				if (!p.WaitForExit(timeoutMs))
				{
					try
					{
						p.Kill();
					}
					catch
					{
					}
				}
				if (stdout.Trim() == "")
				{
					Reply(ctx, 500, "{\"error\":\"" + errMsg + ": " + Esc(stderr.Substring(0, Math.Min(stderr.Length, 200))) + "\"}");
					return;
				}
				Reply(ctx, 200, stdout);
			}
			catch (Exception ex)
			{
				Reply(ctx, 500, "{\"error\":\"" + Esc(ex.Message) + "\"}");
			}
		}

		private static void Play(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			string url = Val(p, "url");
			string name = Val(p, "name");
			if (url == "" && name != "")
			{
				foreach (KeyValuePair<string, string> cp in ChannelPairs())
				{
					if (cp.Key.ToLowerInvariant().Contains(name.ToLowerInvariant()))
					{
						url = UrlFromDbValue(cp.Value);
						name = cp.Key;
						break;
					}
				}
			}
			if (url == "")
			{
				Reply(ctx, 404, "{\"error\":\"canale non trovato nel database\"}");
				return;
			}
			if (url.IndexOf("mms://") == 0 || url.IndexOf("mmst://") == 0 || url.IndexOf("mmsh://") == 0)
			{
				Reply(ctx, 400, "{\"error\":\"protocollo morto nel 2026: " + Esc(url) + "\"}");
				return;
			}
			// catena ufficiale: la stessa di WEBTV.guarda (browser esterno per le sorgenti moderne)
			try
			{
				if (mio != null && mio.TVweb != null)
				{
					string u = url;
					mio.BeginInvoke((MethodInvoker)delegate
					{
						try
						{
							mio.TVweb.guarda(u);
						}
						catch
						{
						}
					});
				}
				else
				{
					Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
				}
				Reply(ctx, 200, "{\"ok\":true,\"opened\":\"" + Esc(url) + "\",\"name\":\"" + Esc(name) + "\"}");
			}
			catch (Exception ex)
			{
				Reply(ctx, 500, "{\"error\":\"" + Esc(ex.Message) + "\"}");
			}
		}

		// ---------- epg ----------
		private static string EpgSlug(string channel)
		{
			string c = (channel ?? "").ToLowerInvariant();
			if (c.IndexOf("raiuno") >= 0 || c.IndexOf("rai 1") >= 0 || c.IndexOf("raiuno") >= 0)
			{
				return "raiuno";
			}
			if (c.IndexOf("raidue") >= 0 || c.IndexOf("rai 2") >= 0)
			{
				return "raidue";
			}
			if (c.IndexOf("raitre") >= 0 || c.IndexOf("rai 3") >= 0)
			{
				return "raitre";
			}
			if (c.IndexOf("rete4") >= 0 || c.IndexOf("rete 4") >= 0)
			{
				return "rete4";
			}
			if (c.IndexOf("canale 5") >= 0 || c.IndexOf("canale5") >= 0)
			{
				return "canale5";
			}
			if (c.IndexOf("italia 1") >= 0 || c.IndexOf("italia1") >= 0)
			{
				return "italia1";
			}
			if (c.IndexOf("la7") >= 0 || c.IndexOf("la 7") >= 0)
			{
				return "la7";
			}
			if (c.IndexOf("rai4") >= 0 || c.IndexOf("rai 4") >= 0)
			{
				return "rai4";
			}
			if (c.IndexOf("rai5") >= 0 || c.IndexOf("rai 5") >= 0)
			{
				return "rai5";
			}
			if (c.IndexOf("la5") >= 0 || c.IndexOf("la 5") >= 0)
			{
				return "la5";
			}
			if (c.IndexOf("rai storia") >= 0)
			{
				return "raistoria";
			}
			if (c.IndexOf("rai sport") >= 0)
			{
				return "raisport1";
			}
			if (c.IndexOf("cielo") >= 0)
			{
				return "cielo";
			}
			if (c.IndexOf("tv2000") >= 0)
			{
				return "tv2000";
			}
			if (c.IndexOf("focus") >= 0)
			{
				return "focus";
			}
			return "";
		}

		private static void Epg(HttpListenerContext ctx, string channel)
		{
			string slug = EpgSlug(channel);
			if (slug == "")
			{
				Reply(ctx, 200, "{\"available\":false,\"reason\":\"mymovies.it nel 2026 pubblica la griglia solo per i canali principali\"}");
				return;
			}
			List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();
			try
			{
				HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.mymovies.it/tv/" + slug + "/");
				wr.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
				string text;
				using (WebResponse resp = wr.GetResponse())
				{
					using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
					{
						text = sr.ReadToEnd();
					}
				}
				string[] chunks = text.Split(new string[1] { "schedine-separa" }, StringSplitOptions.None);
				List<string> raw = new List<string>();
				for (int i = 0; i < chunks.Length; i++)
				{
					MatchCollection orari = Regex.Matches(chunks[i], "calendario2[^>]*>\\s*<div[^>]*></div>\\s*([0-9]{1,2}:[0-9]{2})\\s*<div");
					MatchCollection titoli = Regex.Matches(chunks[i], "schedine-titolo\\\">\\s*([^<]+?)\\s*</div>");
					int n = Math.Min(orari.Count, titoli.Count);
					for (int j = 0; j < n; j++)
					{
						raw.Add(orari[j].Groups[1].Value + "|" + Regex.Replace(WebUtility.HtmlDecode(titoli[j].Groups[1].Value), "\\s+", " ").Trim());
					}
				}
				for (int k = 0; k < raw.Count; k++)
				{
					string inizio = raw[k].Substring(0, raw[k].IndexOf('|'));
					string titolo = raw[k].Substring(raw[k].IndexOf('|') + 1);
					string fine = (k < raw.Count - 1) ? raw[k + 1].Substring(0, raw[k + 1].IndexOf('|')) : "06:00";
					items.Add(Dic("start", inizio, "end", fine, "title", titolo));
				}
			}
			catch (Exception ex)
			{
				Reply(ctx, 500, "{\"error\":\"guida non raggiungibile: " + Esc(ex.Message) + "\"}");
				return;
			}
			Reply(ctx, 200, "{\"available\":true,\"channel\":\"" + Esc(slug) + "\",\"programs\":" + Arr(items) + "}");
		}

		// ---------- record ----------
		private static void RecordStart(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			if (recAgent != null && recAgent.IsRecording)
			{
				Reply(ctx, 409, "{\"error\":\"registrazione gia' attiva: " + Esc(recAgentName) + "\"}");
				return;
			}
			string channel = Val(p, "channel");
			string url = Val(p, "url");
			if (url == "")
			{
				// match case-insensitive: l'agente/utente passa il nome cosi' com'e' nel DB
				string ch = channel.ToLowerInvariant();
				url = ThreadCapo.urlregistrazione(ch);
			}
			if (url == "")
			{
				foreach (KeyValuePair<string, string> cp in ChannelPairs())
				{
					if (cp.Key.ToLowerInvariant().Contains(channel.ToLowerInvariant()))
					{
						url = UrlFromDbValue(cp.Value);
						break;
					}
				}
			}
			if (url == "")
			{
				Reply(ctx, 400, "{\"error\":\"canale non registrabile con sorgenti ufficiali: " + Esc(channel) + "\"}");
				return;
			}
			string name = Val(p, "name");
			if (name == "")
			{
				name = "agent_" + DateTime.Now.ToString("HHmm");
			}
			name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_") + name.Replace(" ", "_");
			RecorderService rs = new RecorderService();
			string error;
			if (!rs.Start(url, RegDir(), name, out error))
			{
				Reply(ctx, 500, "{\"error\":\"avvio fallito: " + Esc(error) + "\"}");
				return;
			}
			recAgent = rs;
			recAgentUrl = url;
			recAgentName = name;
			Reply(ctx, 200, "{\"ok\":true,\"name\":\"" + Esc(name) + "\",\"url\":\"" + Esc(url) + "\"}");
		}

		private static void RecordStop(HttpListenerContext ctx)
		{
			if (recAgent == null || !recAgent.IsRecording)
			{
				Reply(ctx, 404, "{\"error\":\"nessuna registrazione agent attiva\"}");
				return;
			}
			recAgent.Stop();
			Reply(ctx, 200, "{\"ok\":true,\"stopped\":\"" + Esc(recAgentName) + "\"}");
		}

		private static void Recordings(HttpListenerContext ctx)
		{
			List<Dictionary<string, string>> files = new List<Dictionary<string, string>>();
			string dir = RegDir();
			if (Directory.Exists(dir))
			{
				foreach (string f in Directory.GetFiles(dir))
				{
					FileInfo fi = new FileInfo(f);
					files.Add(Dic("file", fi.Name, "bytes", fi.Length.ToString(), "mtime", fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm")));
				}
			}
			Reply(ctx, 200, Arr(files));
		}

		// ---------- schedule ----------
		private static string TodayFolder()
		{
			DateTime now = DateTime.Now;
			return Program.pr + "\\" + now.Day + "_" + now.Month + "_" + now.Year;
		}

		private static string[] ScheduleFiles()
		{
			return new string[7] { "rai1.txt", "rai2.txt", "rai3.txt", "cinque.txt", "italia.txt", "quattro.txt", "canaliagg.txt" };
		}

		private static List<Dictionary<string, string>> ScheduleList()
		{
			List<Dictionary<string, string>> res = new List<Dictionary<string, string>>();
			try
			{
				string folder = TodayFolder();
				if (!Directory.Exists(folder))
				{
					return res;
				}
				int idx = 0;
				foreach (string fname in ScheduleFiles())
				{
					string path = folder + "\\" + fname;
					if (!File.Exists(path))
					{
						continue;
					}
					List<string> lines = new List<string>(File.ReadAllLines(path));
					for (int i = 0; i < lines.Count - 1; i++)
					{
						string l = lines[i];
						string nx = lines[i + 1];
						if (l.Length > 10 && l.IndexOf("!$!") < 0 && (nx.StartsWith("REC") || nx.StartsWith("SHOW")))
						{
							res.Add(Dic("index", idx.ToString(), "file", fname, "line", l, "marker", nx.Substring(0, 3)));
							idx++;
							i++;
						}
					}
				}
			}
			catch
			{
			}
			return res;
		}

		private static void ScheduleAdd(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			string title = Val(p, "title");
			string time = Val(p, "time"); // hh:mm
			string channel = Val(p, "channel");
			string end = Val(p, "end");
			if (title == "" || time.IndexOf(":") < 0 || channel == "")
			{
				Reply(ctx, 400, "{\"error\":\"servono title, time (hh:mm), channel\"}");
				return;
			}
			if (end.IndexOf(":") < 0)
			{
				DateTime t0 = DateTime.Today.AddHours(int.Parse(time.Substring(0, time.IndexOf(":")))).AddMinutes(int.Parse(time.Substring(time.IndexOf(":") + 1)));
				end = t0.AddHours(1).ToString("HH:mm");
			}
			string url = Val(p, "url");
			if (url == "")
			{
				// match case-insensitive: l'agente/utente passa il nome cosi' com'e' nel DB
				string ch = channel.ToLowerInvariant();
				url = ThreadCapo.urlregistrazione(ch);
			}
			if (url == "")
			{
				foreach (KeyValuePair<string, string> cp in ChannelPairs())
				{
					if (cp.Key.ToLowerInvariant().Contains(channel.ToLowerInvariant()))
					{
						url = UrlFromDbValue(cp.Value);
						break;
					}
				}
			}
			if (url == "")
			{
				Reply(ctx, 400, "{\"error\":\"canale sconosciuto/non registrabile: " + Esc(channel) + "\"}");
				return;
			}
			string folder = TodayFolder();
			Directory.CreateDirectory(folder);
			string path = folder + "\\canaliagg.txt";
			// formato ufficiale 2011 (catena RICORDA/ProgrammiTV): riga programma + marker
			string timeDot = time.Replace(":", ".");
			string line1 = timeDot + " " + title + "    |||" + end;
			string line2 = "REC |||" + channel + "!$!" + url + "|<-->|" + url;
			using (StreamWriter sw = new StreamWriter(path, true))
			{
				sw.WriteLine(line1);
				sw.WriteLine(line2);
			}
			Reply(ctx, 200, "{\"ok\":true,\"file\":\"canaliagg.txt\",\"line\":\"" + Esc(line1) + "\"}");
		}

		private static void ScheduleDel(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			int want;
			List<Dictionary<string, string>> all = ScheduleList();
			if (!int.TryParse(Val(p, "index"), out want) || want < 0 || want >= all.Count)
			{
				Reply(ctx, 400, "{\"error\":\"index non valido (0.." + (all.Count - 1) + ")\"}");
				return;
			}
			string fname = all[want]["file"];
			string line = all[want]["line"];
			string path = TodayFolder() + "\\" + fname;
			List<string> lines = new List<string>(File.ReadAllLines(path));
			int pos = lines.IndexOf(line);
			if (pos >= 0)
			{
				lines.RemoveAt(pos);
				if (pos < lines.Count && (lines[pos].StartsWith("REC") || lines[pos].StartsWith("SHOW")))
				{
					lines.RemoveAt(pos);
				}
				File.WriteAllLines(path, lines.ToArray());
				Reply(ctx, 200, "{\"ok\":true,\"removed\":\"" + Esc(line) + "\"}");
			}
			else
			{
				Reply(ctx, 404, "{\"error\":\"riga non trovata\"}");
			}
		}

		// ---------- canali DB ----------
		private static string DbFile()
		{
			return Program.pr + "\\nuovicanali.txt";
		}

		private static string FavFile()
		{
			return Program.pr + "\\propriotel.txt";
		}

		private static List<string> ReadLines(string path)
		{
			List<string> res = new List<string>();
			try
			{
				if (File.Exists(path))
				{
					string[] all = File.ReadAllLines(path);
					foreach (string l in all)
					{
						res.Add(l);
					}
				}
			}
			catch
			{
			}
			return res;
		}

		private static List<KeyValuePair<string, string>> ChannelPairs()
		{
			List<KeyValuePair<string, string>> res = new List<KeyValuePair<string, string>>();
			List<string> lines = ReadLines(DbFile());
			for (int i = 0; i + 1 < lines.Count; i += 2)
			{
				if (lines[i].Trim().Length > 0)
				{
					res.Add(new KeyValuePair<string, string>(lines[i], lines[i + 1]));
				}
			}
			return res;
		}

		private static string UrlFromDbValue(string v)
		{
			if (v.IndexOf("|<-->|") >= 0)
			{
				return v.Substring(0, v.IndexOf("|<-->|"));
			}
			return v;
		}

		private static void BackupDbFiles()
		{
			string dir = Program.pr + "\\data_backup";
			Directory.CreateDirectory(dir);
			string ts = DateTime.Now.ToString("yyyyMMdd_HHmmss");
			try
			{
				File.Copy(DbFile(), dir + "\\nuovicanali_" + ts + ".txt", true);
				File.Copy(FavFile(), dir + "\\propriotel_" + ts + ".txt", true);
			}
			catch
			{
			}
		}

		private static void WritePairs(string path, List<string> lines)
		{
			// byte-mode CRLF: il parser 2011 legge a coppie con ReadLine
			StringBuilder sb = new StringBuilder();
			foreach (string l in lines)
			{
				sb.Append(l);
				sb.Append("\r\n");
			}
			File.WriteAllBytes(path, Encoding.UTF8.GetBytes(sb.ToString()));
		}

		private static void ChannelAdd(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			string name = Val(p, "name");
			string url = Val(p, "url");
			if (name == "" || url.IndexOf("http") != 0)
			{
				Reply(ctx, 400, "{\"error\":\"servono name e url http\"}");
				return;
			}
			BackupDbFiles();
			List<string> lines = ReadLines(DbFile());
			while (lines.Count > 0 && lines[lines.Count - 1].Trim() == "")
			{
				lines.RemoveAt(lines.Count - 1);
			}
			lines.Add(name);
			lines.Add(url + "|<-->|" + url);
			WritePairs(DbFile(), lines);
			Reply(ctx, 200, "{\"ok\":true,\"channels\":" + ChannelPairs().Count + "}");
		}

		private static void ChannelDel(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			string name = Val(p, "name");
			List<string> lines = ReadLines(DbFile());
			int pos = -1;
			for (int i = 0; i + 1 < lines.Count; i += 2)
			{
				if (lines[i].Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					pos = i;
					break;
				}
			}
			if (pos < 0)
			{
				Reply(ctx, 404, "{\"error\":\"canale non trovato: " + Esc(name) + "\"}");
				return;
			}
			BackupDbFiles();
			lines.RemoveAt(pos + 1);
			lines.RemoveAt(pos);
			WritePairs(DbFile(), lines);
			Reply(ctx, 200, "{\"ok\":true,\"channels\":" + ChannelPairs().Count + "}");
		}

		private static void FavAdd(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			string name = Val(p, "name");
			if (name == "")
			{
				Reply(ctx, 400, "{\"error\":\"serve name\"}");
				return;
			}
			BackupDbFiles();
			List<string> lines = ReadLines(FavFile());
			while (lines.Count > 0 && lines[lines.Count - 1].Trim() == "")
			{
				lines.RemoveAt(lines.Count - 1);
			}
			lines.Add((lines.Count + 1) + " " + name);
			WritePairs(FavFile(), lines);
			Reply(ctx, 200, "{\"ok\":true,\"favorites\":" + lines.Count + "}");
		}

		private static void FavDel(HttpListenerContext ctx, Dictionary<string, string> p)
		{
			string name = Val(p, "name");
			List<string> lines = ReadLines(FavFile());
			int pos = -1;
			for (int i = 0; i < lines.Count; i++)
			{
				int sp = lines[i].IndexOf(' ');
				if (sp > 0 && lines[i].Substring(sp + 1).Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					pos = i;
					break;
				}
			}
			if (pos < 0)
			{
				Reply(ctx, 404, "{\"error\":\"preferito non trovato: " + Esc(name) + "\"}");
				return;
			}
			BackupDbFiles();
			lines.RemoveAt(pos);
			for (int i = 0; i < lines.Count; i++)
			{
				int sp = lines[i].IndexOf(' ');
				if (sp > 0)
				{
					lines[i] = (i + 1) + lines[i].Substring(sp);
				}
			}
			WritePairs(FavFile(), lines);
			Reply(ctx, 200, "{\"ok\":true,\"favorites\":" + lines.Count + "}");
		}

		// ---------- helper ----------
		private static string RegDir()
		{
			string d = (mio != null) ? mio.dvreg : "";
			if (d == "")
			{
				d = Program.pr + "\\REG";
			}
			Directory.CreateDirectory(d);
			return d;
		}

		private static Dictionary<string, string> ParseQuery(NameValueCollection q)
		{
			Dictionary<string, string> d = new Dictionary<string, string>();
			foreach (string k in q.AllKeys)
			{
				if (k != null)
				{
					d[k.ToLowerInvariant()] = q[k] ?? "";
				}
			}
			return d;
		}

		private static string Val(Dictionary<string, string> d, string k)
		{
			string v;
			return d.TryGetValue(k, out v) ? v.Trim() : "";
		}

		private static Dictionary<string, string> Dic(params string[] kv)
		{
			Dictionary<string, string> d = new Dictionary<string, string>();
			for (int i = 0; i + 1 < kv.Length; i += 2)
			{
				d[kv[i]] = kv[i + 1];
			}
			return d;
		}

		private static string Esc(string s)
		{
			if (s == null)
			{
				return "";
			}
			StringBuilder sb = new StringBuilder();
			foreach (char c in s)
			{
				switch (c)
				{
				case '"':
					sb.Append("\\\"");
					break;
				case '\\':
					sb.Append("\\\\");
					break;
				case '\n':
					sb.Append("\\n");
					break;
				case '\r':
					break;
				case '\t':
					sb.Append("\\t");
					break;
				default:
					if (c < ' ')
					{
						sb.Append(string.Format("\\u{0:x4}", (int)c));
					}
					else
					{
						sb.Append(c);
					}
					break;
				}
			}
			return sb.ToString();
		}

		private static string Obj(Dictionary<string, string> d)
		{
			StringBuilder sb = new StringBuilder("{");
			bool first = true;
			foreach (KeyValuePair<string, string> kv in d)
			{
				if (!first)
				{
					sb.Append(",");
				}
				first = false;
				sb.Append("\"" + Esc(kv.Key) + "\":");
				long num;
				sb.Append(long.TryParse(kv.Value, out num) ? kv.Value : "\"" + Esc(kv.Value) + "\"");
			}
			sb.Append("}");
			return sb.ToString();
		}

		private static string Arr(List<Dictionary<string, string>> items)
		{
			StringBuilder sb = new StringBuilder("[");
			for (int i = 0; i < items.Count; i++)
			{
				if (i > 0)
				{
					sb.Append(",");
				}
				sb.Append(Obj(items[i]));
			}
			sb.Append("]");
			return sb.ToString();
		}

		private static void Reply(HttpListenerContext ctx, int code, string json)
		{
			byte[] buf = Encoding.UTF8.GetBytes(json);
			ctx.Response.StatusCode = code;
			ctx.Response.ContentType = "application/json; charset=utf-8";
			ctx.Response.ContentLength64 = buf.Length;
			ctx.Response.OutputStream.Write(buf, 0, buf.Length);
			ctx.Response.Close();
		}
	}
}