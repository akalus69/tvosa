// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZeroItaTV.Threadx;

// BONIFICA/RINASCITA 2026-10-28: downloader del palinsesto per il "canale selezionato".
// Il corpo 2011 e' in quarantena (C:\Mio\TVOSA\quarantine\ThreadAltriCanali.cs): conteneva
// anche rami morti/pirata (justin.tv, retesole, primocanale) rimasti ora come no-op.
// vaitutti() e' reimplementato su mymovies.it (sorgente legale gia' usata nel 2011)
// con il markup 2026 (blocchi 'schedine-separa', orari 'calendario2', titoli 'schedine-titolo').
// Formato item preservato: "hh.mm - hh.mm : Titolo" (consumato da trovaora / REC tasto destro).
internal class ThreadAltriCanali
{
	private RecTv mio;

	private ManageCanali mio2;

	private bool rec = true;

	public ThreadAltriCanali(RecTv m)
	{
		mio = m;
	}

	public ThreadAltriCanali(ManageCanali m)
	{
		mio2 = m;
		rec = false;
	}

	public void vaitutti()
	{
		try
		{
			string url = rec ? mio.urlpal : mio2.urlpal;
			if (url == null || url.IndexOf("mymovies") < 0)
			{
				// BONIFICA: niente piu' sorgenti web-browser arbitrarie
				try
				{
					if (rec)
					{
						mio.listBox2.Items.Clear();
					}
					else
					{
						mio2.listBox2.Items.Clear();
						mio2.listBox3.Items.Clear();
					}
				}
				catch
				{
				}
				Msg("Palinsesto 2026 non disponibile per questo canale.");
				Msg("Le vecchie fonti del 2011 sono chiuse; mymovies.it pubblica");
				Msg("la guida solo per i canali principali (RAI, Mediaset, La7...).");
				return;
			}
			// evento futuro (solo RecTv ha il datepicker): mymovies usa gli slug /domani/ e /dopodomani/
			if (rec)
			{
				try
				{
					int delta = (int)(mio.dateTimePicker1.Value.Date - DateTime.Now.Date).TotalDays;
					if (delta == 1)
					{
						url += "domani/";
					}
					else if (delta >= 2)
					{
						url += "dopodomani/";
					}
				}
				catch
				{
				}
			}
			if (!rec && mio2.palinsesto)
			{
				try
				{
					mio2.progressBar2.PerformStep();
				}
				catch
				{
				}
			}
			WebRequest webRequest = WebRequest.Create(url);
			((HttpWebRequest)webRequest).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0 Safari/537.36";
			Stream stream = null;
			WebResponse response = webRequest.GetResponse();
			stream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			stream.Close();
			// parsing markup 2026
			List<string> list = new List<string>();
			string[] array = text.Split(new string[1] { "schedine-separa" }, StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				MatchCollection orari = Regex.Matches(array[i], "calendario2[^>]*>\\s*<div[^>]*></div>\\s*([0-9]{1,2}:[0-9]{2})\\s*<div");
				MatchCollection titoli = Regex.Matches(array[i], "schedine-titolo\\\">\\s*([^<]+?)\\s*</div>");
				int n = Math.Min(orari.Count, titoli.Count);
				for (int j = 0; j < n; j++)
				{
					string ora = orari[j].Groups[1].Value;
					string titolo = Regex.Replace(WebUtility.HtmlDecode(titoli[j].Groups[1].Value), "\\s+", " ").Trim();
					list.Add(ora.Replace(":", ".") + ":" + titolo);
				}
			}
			// coppia inizio-fine come nel 2011: "hh.mm - hh.mm : Titolo"
			List<string> list2 = new List<string>();
			for (int k = 0; k < list.Count; k++)
			{
				string inizio = list[k].Substring(0, list[k].IndexOf(":"));
				string nome = list[k].Substring(list[k].IndexOf(":") + 1);
				if (k < list.Count - 1)
				{
					string fine = list[k + 1].Substring(0, list[k + 1].IndexOf(":"));
					list2.Add(inizio + " - " + fine + " : " + nome);
				}
				else
				{
					list2.Add(inizio + " - 06.00 : " + nome);
				}
			}
			if (rec)
			{
				mio.listBox2.Items.Clear();
				foreach (string item in list2)
				{
					mio.listBox2.Items.Add(item);
				}
			}
			else
			{
				mio2.listBox2.Items.Clear();
				mio2.listBox3.Items.Clear();
				foreach (string item2 in list2)
				{
					if (mio2.palinsesto)
					{
						mio2.listBox2.Items.Add(item2);
					}
					else
					{
						mio2.listBox3.Items.Add(item2);
					}
				}
				if (mio2.palinsesto)
				{
					try
					{
						mio2.progressBar2.PerformStep();
					}
					catch
					{
					}
				}
			}
			if (list2.Count == 0)
			{
				Msg("Palinsesto 2026 non disponibile per questo canale.");
				Msg("mymovies.it non pubblica piu' la guida dei canali minori;");
				Msg("usa il tasto 'CERCA PALINSESTO INTERNET' come nel 2011.");
			}
		}
		catch (Exception ex)
		{
		}
	}

	private void Msg(string s)
	{
		try
		{
			if (rec)
			{
				mio.listBox2.Items.Add(s);
			}
			else if (mio2.palinsesto)
			{
				mio2.listBox2.Items.Add(s);
			}
			else
			{
				mio2.listBox3.Items.Add(s);
			}
		}
		catch
		{
		}
	}

	// ===== rami 2011 morti o non autorizzati: lasciati no-op (vedi quarantena) =====
	public void vairai4()
	{
	}

	public void vaiprimocanale()
	{
	}

	public void vairetesoleroma()
	{
	}

	public void vairetesoleumbria()
	{
	}

	public void vaicomingsoon()
	{
	}

	public void vaituttibk()
	{
	}

	public void preparaschermo()
	{
	}

	public void cercamusica()
	{
	}

	public void faipartireprogrammazionejustin()
	{
	}

	public void vaiemostraprogrammitv()
	{
	}

	public void trovarisultatitubo()
	{
	}

	public void scarica(string ricerca, PictureBox p)
	{
	}
}