// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace ZeroItaTV
{
	// SELETTORE SERATA 2026 (SPEC_TRAILER.md Fase 1): un trailer alla volta dai
	// 3 pozzi JustWatch (sala/recenti/capolavori). Motore UNICO: stessa catena
	// del sidecar tvosa_trailer.py invocato dal proprio ControlServer (127.0.0.1).
	public class SelettoreTrailers : Form
	{
		private WebView2 web;

		private ComboBox comboModalita;

		private ComboBox comboGenere;

		private ComboBox comboTipo;

		private Button btnIndietro;

		private Button btnAvanti;

		private Button btnMix;

		private Button btnDove;

		private Label lblInfo;

		private static readonly string[] GEN_NAMES = new string[18] { "tutti i generi", "azione", "commedia", "dramma", "thriller", "giallo/crime", "orrore", "fantascienza", "fantasy", "animazione", "romantico", "famiglia", "documentario", "western", "storia", "guerra", "musica", "sport" };

		private static readonly string[] GEN_SLUGS = new string[18] { "", "azione", "commedia", "dramma", "thriller", "giallo", "orrore", "fantascienza", "fantasy", "animazione", "romantico", "famiglia", "documentario", "western", "storia", "guerra", "musica", "sport" };

		private static readonly string[] MODE_SLUGS = new string[4] { "misto", "sala", "recenti", "capolavori" };

		private static readonly string[] TYPE_SLUGS = new string[3] { "film", "serie", "tutto" };

		private List<Dictionary<string, object>> pool = new List<Dictionary<string, object>>();

		private Dictionary<int, string> trailerCache = new Dictionary<int, string>();

		private int idx = -1;

		private int nextOffset;

		private bool esauriti;
		// id dei trailer gia' mostrati nella sessione: non si ripetono mai piu'
		private List<string> visti = new List<string>();

		private int seed;

		private bool busy;

		private bool viewerReady;

		// trailer aperto dall'agente via /trailershow prima che il viewer sia pronto
		private string pendingEmbed;

		private string pendingTitolo;

		private string direttoTitolo;

		// filtri impostati dall'agente via /trailershow (pool navigabile)
		private string filtroAnno = "";

		private string filtroGenere = "";

		private string titoloTarget;

		// configura la finestra come un CARICA dell'utente: combo, anno e (opzionale)
		// primo titolo su cui posizionarsi; poi il pool si naviga con AVANTI/INDIETRO
		public void ApriConFiltro(string mode, string genre, string tipo, string anno, string titolo)
		{
			int mi = Array.IndexOf(MODE_SLUGS, mode ?? "");
			if (mi >= 0)
			{
				comboModalita.SelectedIndex = mi;
			}
			int gi = Array.IndexOf(GEN_SLUGS, genre ?? "");
			if (gi >= 0)
			{
				comboGenere.SelectedIndex = gi;
				filtroGenere = "";
			}
			else if (genre != null && genre != "")
			{
				// es. "giallo,thriller": la combo non ce l'ha, override diretto
				filtroGenere = genre;
			}
			int ti = Array.IndexOf(TYPE_SLUGS, tipo ?? "");
			if (ti >= 0)
			{
				comboTipo.SelectedIndex = ti;
			}
			filtroAnno = anno ?? "";
			titoloTarget = (titolo == null || titolo == "") ? null : titolo.ToLowerInvariant();
			direttoTitolo = null;
			busy = false;
			Ricomincia();
		}

		// chiamata dal ControlServer (thread HTTP) via BeginInvoke: mostra un trailer
		// qualsiasi nel pannello, anche senza pool caricato
		public void MostraDiretto(string titolo, string embed)
		{
			if (!viewerReady || web == null || web.CoreWebView2 == null)
			{
				pendingEmbed = embed;
				pendingTitolo = titolo;
				lblInfo.Text = "In arrivo: " + titolo + " ...";
				return;
			}
			direttoTitolo = titolo;
			btnDove.Enabled = true;
			if (embed == null)
			{
				Naviga(null, titolo);
				return;
			}
			Naviga(embed, titolo);
			lblInfo.Text = "APERTO DALL'AGENTE: " + titolo + "  ·  trailer dal motore di TVOSA";
		}

		public SelettoreTrailers()
		{
			InitializeComponentUI();
		}

		private void InitializeComponentUI()
		{
			base.Text = "TRAILER - cosa guardo stasera";
			base.ClientSize = new Size(940, 660);
			BackColor = Color.FromArgb(24, 24, 28);
			ForeColor = Color.Gainsboro;
			Font = new Font("Microsoft Sans Serif", 8.25f);
			FormBorderStyle = FormBorderStyle.Sizable;
			MinimizeBox = true;
			StartPosition = FormStartPosition.CenterScreen;
			MinimumSize = new Size(700, 520);
			int y = 12;
			comboModalita = new ComboBox();
			comboModalita.DropDownStyle = ComboBoxStyle.DropDownList;
			comboModalita.Items.AddRange(new object[] { "menù degustazione", "in sala ora", "usciti di recente", "capolavori" });
			comboModalita.SelectedIndex = 0;
			comboModalita.Location = new Point(12, y);
			comboModalita.Size = new Size(170, 24);
			comboGenere = new ComboBox();
			comboGenere.DropDownStyle = ComboBoxStyle.DropDownList;
			comboGenere.Items.AddRange(GEN_NAMES);
			comboGenere.SelectedIndex = 0;
			comboGenere.Location = new Point(192, y);
			comboGenere.Size = new Size(150, 24);
			comboTipo = new ComboBox();
			comboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
			comboTipo.Items.AddRange(new object[] { "film", "serie", "film+serie" });
			comboTipo.SelectedIndex = 0;
			comboTipo.Location = new Point(352, y);
			comboTipo.Size = new Size(100, 24);
			Button btnCarica = new Button();
			btnCarica.Text = "CARICA";
			btnCarica.Location = new Point(462, y - 1);
			btnCarica.Size = new Size(100, 26);
			btnCarica.FlatStyle = FlatStyle.Flat;
			btnCarica.BackColor = Color.FromArgb(0, 120, 200);
			btnCarica.ForeColor = Color.White;
			btnCarica.Click += delegate { filtroGenere = ""; Ricomincia(); };
			btnMix = new Button();
			btnMix.Text = "MISCELA";
			btnMix.Location = new Point(572, y - 1);
			btnMix.Size = new Size(100, 26);
			btnMix.FlatStyle = FlatStyle.Flat;
			btnMix.BackColor = Color.FromArgb(120, 76, 0);
			btnMix.ForeColor = Color.White;
			btnMix.Click += delegate { filtroGenere = ""; Ricomincia(); };
			web = new WebView2();
			web.Location = new Point(12, y + 34);
			web.Size = new Size(916, 470);
			web.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			lblInfo = new Label();
			lblInfo.Text = "Premi CARICA per pescare i primi trailer...";
			lblInfo.Location = new Point(12, 552);
			lblInfo.Size = new Size(916, 34);
			lblInfo.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
			lblInfo.TextAlign = ContentAlignment.MiddleLeft;
			lblInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			btnIndietro = new Button();
			btnIndietro.Text = "<< INDIETRO";
			btnIndietro.Location = new Point(12, 594);
			btnIndietro.Size = new Size(150, 50);
			btnIndietro.FlatStyle = FlatStyle.Flat;
			btnIndietro.BackColor = Color.FromArgb(60, 60, 66);
			btnIndietro.ForeColor = Color.White;
			btnIndietro.Enabled = false;
			btnIndietro.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
			btnIndietro.Click += delegate { Sposta(-1); };
			btnAvanti = new Button();
			btnAvanti.Text = "AVANTI >>";
			btnAvanti.Location = new Point(172, 594);
			btnAvanti.Size = new Size(150, 50);
			btnAvanti.FlatStyle = FlatStyle.Flat;
			btnAvanti.BackColor = Color.FromArgb(0, 150, 60);
			btnAvanti.ForeColor = Color.White;
			btnAvanti.Enabled = false;
			btnAvanti.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
			btnAvanti.Click += delegate { Sposta(1); };
			btnDove = new Button();
			btnDove.Text = "DOVE E'?";
			btnDove.Location = new Point(332, 594);
			btnDove.Size = new Size(150, 50);
			btnDove.FlatStyle = FlatStyle.Flat;
			btnDove.BackColor = Color.FromArgb(0, 120, 200);
			btnDove.ForeColor = Color.White;
			btnDove.Enabled = false;
			btnDove.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
			btnDove.Click += delegate { DoveE(); };
			Controls.Add(comboModalita);
			Controls.Add(comboGenere);
			Controls.Add(comboTipo);
			Controls.Add(btnCarica);
			Controls.Add(btnMix);
			Controls.Add(web);
			Controls.Add(lblInfo);
			Controls.Add(btnIndietro);
			Controls.Add(btnAvanti);
			Controls.Add(btnDove);
			Load += OnLoadInit;
		}

		private async void OnLoadInit(object sender, EventArgs e)
		{
			try
			{
				string userData = Path.Combine(Path.GetTempPath(), "TvOsaTrailer");
				CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, userData);
				await web.EnsureCoreWebView2Async(env);
				web.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
				web.CoreWebView2.Settings.IsStatusBarEnabled = false;
				// Errore 153 di YouTube: l'embed vuole un Referer valido. Serviamo una
				// pagina locale sotto virtual-host http://tvosa.local: l'iframe
				// partira' da quell'origine e YouTube accettera' l'embed.
				web.CoreWebView2.SetVirtualHostNameToFolderMapping("tvosa.local", Path.Combine(Path.GetTempPath(), "TvOsaTrailer"), CoreWebView2HostResourceAccessKind.Allow);
				viewerReady = true;
				if (pendingEmbed != null || pendingTitolo != null)
				{
					string pe = pendingEmbed;
					string pt = pendingTitolo;
					pendingEmbed = null;
					pendingTitolo = null;
					MostraDiretto(pt, pe);
				}
			}
			catch (Exception ex)
			{
				lblInfo.Text = "WebView2 non disponibile: " + ex.Message;
			}
		}

		// ---------- motore remoto (il proprio ControlServer: stessa porta del MCP) ----------
		private static string HttpGet(string url, int timeoutMs)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Timeout = timeoutMs;
			req.ReadWriteTimeout = timeoutMs;
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
				{
					return sr.ReadToEnd();
				}
			}
		}

		private static Dictionary<string, object> ParseJson(string json)
		{
			return (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(json);
		}

		private string PoolUrl(int offset)
		{
			string url = "http://127.0.0.1:19831/tvosa/trailers?mode=" + MODE_SLUGS[comboModalita.SelectedIndex]
				+ "&type=" + TYPE_SLUGS[comboTipo.SelectedIndex] + "&offset=" + offset;
			string gen = filtroGenere != "" ? filtroGenere : GEN_SLUGS[comboGenere.SelectedIndex];
			if (gen != "")
			{
				url = url + "&genre=" + gen;
			}
			if (seed > 0)
			{
				url = url + "&seed=" + seed;
			}
			if (filtroAnno != "")
			{
				url = url + "&year=" + filtroAnno;
			}
			if (visti.Count > 0)
			{
				// il motore esclude cio' che abbiamo gia' visto: niente doppioni tra blocchi
				int da = visti.Count > 400 ? visti.Count - 400 : 0;
				url = url + "&seen=" + string.Join(",", visti.GetRange(da, visti.Count - da).ToArray());
			}
			return url;
		}

		private void Ricomincia()
		{
			if (busy)
			{
				return;
			}
			seed = new Random().Next(1, 999999);
			pool.Clear();
			trailerCache.Clear();
			visti.Clear();
			idx = -1;
			nextOffset = 0;
			esauriti = false;
			CaricaPool();
		}

		private void CaricaPool()
		{
			if (busy || esauriti)
			{
				return;
			}
			busy = true;
			int offset = nextOffset;
			Thread th = new Thread(delegate()
			{
				string err = null;
				List<Dictionary<string, object>> nuovi = new List<Dictionary<string, object>>();
				bool fine = false;
				int noff = offset;
				try
				{
					Dictionary<string, object> root = ParseJson(HttpGet(PoolUrl(offset), 70000));
					if (root.ContainsKey("error"))
					{
						err = Convert.ToString(root["error"]);
					}
					else
					{
						object arr;
						if (root.TryGetValue("pool", out arr) && arr != null)
						{
							foreach (object o in (object[])arr)
							{
								nuovi.Add((Dictionary<string, object>)o);
							}
						}
						fine = root.ContainsKey("pozzi_esauriti") && Convert.ToBoolean(root["pozzi_esauriti"]);
						noff = Convert.ToInt32(root["next_offset"]);
					}
				}
				catch (Exception ex)
				{
					err = ex.Message;
				}
				try
				{
					BeginInvoke((MethodInvoker)delegate
					{
						busy = false;
						if (err != null)
						{
							lblInfo.Text = "Errore motore: " + err;
							return;
						}
						pool.AddRange(nuovi);
											foreach (Dictionary<string, object> d in nuovi)
											{
												string idd = d.ContainsKey("id") ? Convert.ToString(d["id"]) : "";
												if (idd != "" && !visti.Contains(idd))
												{
													visti.Add(idd);
												}
											}
											nextOffset = noff;
						esauriti = fine;
						if (idx < 0 && pool.Count > 0)
						{
							idx = 0;
							if (titoloTarget != null)
							{
								for (int k = 0; k < pool.Count; k++)
								{
									string tt = Convert.ToString(pool[k]["titolo"]).ToLowerInvariant();
									if (tt.Contains(titoloTarget) || titoloTarget.Contains(tt))
									{
										idx = k;
										break;
									}
								}
								titoloTarget = null;
							}
							MostraCurrente();
						}
						else if (pool.Count == 0)
						{
							lblInfo.Text = "Pozzi vuoti per questi filtri: cambia genere o tipo.";
						}
					});
				}
				catch
				{
				}
			});
			th.IsBackground = true;
			th.Start();
		}

		private void Sposta(int delta)
		{
			int nuovo = idx + delta;
			if (nuovo < 0 || nuovo >= pool.Count)
			{
				return;
			}
			idx = nuovo;
			// prefetch al 5° dal fondo del blocco (spec): arriva il prossimo prima del click
			if (delta > 0 && pool.Count - 1 - idx <= 4)
			{
				CaricaPool();
			}
			MostraCurrente();
		}

		private void MostraCurrente()
		{
			if (idx < 0 || idx >= pool.Count)
			{
				return;
			}
			Dictionary<string, object> t = pool[idx];
			string titolo = Convert.ToString(t["titolo"]);
			string anno = t["anno"] == null ? "" : Convert.ToString(t["anno"]);
			string pozzo = Convert.ToString(t["pozzo"]);
			string generi = "";
			object g;
			if (t.TryGetValue("genere", out g) && g != null)
			{
				foreach (object gg in (object[])g)
				{
					generi = generi + (generi == "" ? "" : "/") + gg;
				}
			}
			lblInfo.Text = (idx + 1) + ". " + titolo + (anno == "" ? "" : " (" + anno + ")") + "  ·  pozzo: " + pozzo + "  ·  " + generi;
			btnIndietro.Enabled = idx > 0;
			btnAvanti.Enabled = idx < pool.Count - 1 || !esauriti;
			btnDove.Enabled = true;
			string embed;
			if (trailerCache.TryGetValue(idx, out embed))
			{
				Naviga(embed, titolo);
				return;
			}
			lblInfo.Text = lblInfo.Text + "  ·  cerco il trailer...";
			int captured = idx;
			Thread th = new Thread(delegate()
			{
				string res = null;
				try
				{
					string u = "http://127.0.0.1:19831/tvosa/trailer?title=" + Uri.EscapeDataString(titolo) + "&year=" + Uri.EscapeDataString(anno);
					Dictionary<string, object> root = ParseJson(HttpGet(u, 100000));
					object e;
					if (root.TryGetValue("embed", out e) && e != null)
					{
						res = Convert.ToString(e);
					}
				}
				catch
				{
				}
				trailerCache[captured] = res;
				try
				{
					BeginInvoke((MethodInvoker)delegate
					{
						if (captured == idx)
						{
							Naviga(res, titolo);
						}
					});
				}
				catch
				{
				}
			});
			th.IsBackground = true;
			th.Start();
			// prefetch del successivo (niente attesa al prossimo AVANTI)
			if (!trailerCache.ContainsKey(idx + 1) && idx + 1 < pool.Count)
			{
				Dictionary<string, object> n = pool[idx + 1];
				string nt = Convert.ToString(n["titolo"]);
				string na = n["anno"] == null ? "" : Convert.ToString(n["anno"]);
				int ncaptured = idx + 1;
				Thread th2 = new Thread(delegate()
				{
					string res = null;
					try
					{
						string u = "http://127.0.0.1:19831/tvosa/trailer?title=" + Uri.EscapeDataString(nt) + "&year=" + Uri.EscapeDataString(na);
						Dictionary<string, object> root = ParseJson(HttpGet(u, 100000));
						object e;
						if (root.TryGetValue("embed", out e) && e != null)
						{
							res = Convert.ToString(e);
						}
					}
					catch
					{
					}
					trailerCache[ncaptured] = res;
				});
				th2.IsBackground = true;
				th2.Start();
			}
		}

		private void Naviga(string embed, string titolo)
		{
			if (!viewerReady || web.CoreWebView2 == null)
			{
				return;
			}
			if (embed == null)
			{
				lblInfo.Text = "Nessun trailer trovato per " + titolo + " — AVANTI al prossimo";
				web.CoreWebView2.Navigate("about:blank");
				return;
			}
			// pagina locale dentro il virtual-host: l'iframe eredita Referer valido
			string html = "<!DOCTYPE html><html><head><style>html,body{margin:0;height:100%;background:#000}"
				+ "iframe{border:0;width:100%;height:100%}</style></head><body>"
				+ "<iframe src=\"" + embed + "\" allow=\"autoplay; encrypted-media; picture-in-picture\" allowfullscreen></iframe>"
				+ "</body></html>";
			try
			{
				File.WriteAllText(Path.Combine(Path.GetTempPath(), "TvOsaTrailer", "player.html"), html, new UTF8Encoding(false));
			}
			catch
			{
				web.CoreWebView2.Navigate(embed);
				return;
			}
			web.CoreWebView2.Navigate("http://tvosa.local/player.html?n=" + DateTime.Now.Ticks);
		}

		private void DoveE()
		{
			string titolo = "";
			if (idx >= 0 && idx < pool.Count)
			{
				titolo = Convert.ToString(pool[idx]["titolo"]);
			}
			else if (direttoTitolo != null)
			{
				titolo = direttoTitolo;
			}
			if (titolo == "")
			{
				return;
			}
			new TrovaFilm(titolo).Show();
		}
	}
}