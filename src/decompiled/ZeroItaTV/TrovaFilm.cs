// TvOsa - TV On SmartfOne App
// Copyright (C) 2011-2026 akalus69
// Licenza GNU GPLv3 - vedi LICENSE
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ZeroItaTV
{
	// TROVA FILM 2026: "dove vedo un film stasera" — riusa la stessa identica
	// ricerca JustWatch (catalogo Italia) del tool MCP tvosa_find_film, via sidecar Python.
	public class TrovaFilm : Form
	{
		private TextBox txtTitolo;

		private Button btnCerca;

		private TextBox txtEsito;

		private Label lblTitolo;

		public TrovaFilm()
		{
			InitializeComponentUI();
		}

		// DOVE È del selettore trailer: apre gia' col titolo da cercare.
		public TrovaFilm(string titoloPrecompilato)
		{
			InitializeComponentUI();
			txtTitolo.Text = titoloPrecompilato ?? "";
			if (txtTitolo.Text != "")
			{
				OnCerca(this, EventArgs.Empty);
			}
		}

		private void InitializeComponentUI()
		{
			base.Text = "TROVA FILM - dove vederlo oggi";
			base.ClientSize = new Size(520, 440);
			BackColor = Color.FromArgb(24, 24, 28);
			ForeColor = Color.Gainsboro;
			Font = new Font("Microsoft Sans Serif", 8.25f);
			FormBorderStyle = FormBorderStyle.Sizable;
			MinimizeBox = false;
			StartPosition = FormStartPosition.CenterScreen;
			lblTitolo = new Label();
			lblTitolo.Text = "Titolo del film o serie:";
			lblTitolo.Location = new Point(12, 14);
			lblTitolo.Size = new Size(200, 18);
			txtTitolo = new TextBox();
			txtTitolo.Location = new Point(12, 36);
			txtTitolo.Size = new Size(380, 24);
			txtTitolo.BackColor = Color.FromArgb(40, 40, 46);
			txtTitolo.ForeColor = Color.White;
			txtTitolo.BorderStyle = BorderStyle.FixedSingle;
			btnCerca = new Button();
			btnCerca.Text = "CERCA";
			btnCerca.Location = new Point(402, 34);
			btnCerca.Size = new Size(104, 28);
			btnCerca.FlatStyle = FlatStyle.Flat;
			btnCerca.BackColor = Color.FromArgb(0, 120, 200);
			btnCerca.ForeColor = Color.White;
			btnCerca.FlatAppearance.BorderColor = Color.Gray;
			btnCerca.Click += OnCerca;
			txtEsito = new TextBox();
			txtEsito.Location = new Point(12, 74);
			txtEsito.Size = new Size(494, 352);
			txtEsito.Multiline = true;
			txtEsito.ReadOnly = true;
			txtEsito.ScrollBars = ScrollBars.Vertical;
			txtEsito.BackColor = Color.FromArgb(18, 18, 22);
			txtEsito.ForeColor = Color.Gainsboro;
			txtEsito.Font = new Font("Consolas", 9.5f);
			txtEsito.BorderStyle = BorderStyle.FixedSingle;
			txtEsito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			txtEsito.Text = "Cerca un titolo per sapere DOVE vederlo oggi in Italia\r\n(abbonamenti che hai, gratis, noleggio).\r\n\r\nSe un film esiste solo su Netflix ESTERO qui NON\r\nrisulta: catalogo italiano, niente VPN (per ora).";
			Controls.Add(lblTitolo);
			Controls.Add(txtTitolo);
			Controls.Add(btnCerca);
			Controls.Add(txtEsito);
			AcceptButton = btnCerca;
		}

		private void OnCerca(object sender, EventArgs e)
		{
			string titolo = txtTitolo.Text.Trim();
			if (titolo == "")
			{
				txtEsito.Text = "Digita prima un titolo!";
				return;
			}
			btnCerca.Enabled = false;
			txtEsito.Text = "Ricerca in corso su JustWatch (catalogo Italia)...";
			Thread th = new Thread(delegate()
			{
				string esito;
				try
				{
					ProcessStartInfo psi = new ProcessStartInfo("py", "-3.13 \"" + Program.pr + "\\tools\\tvosa_find.py\" \"" + titolo.Replace("\"", "") + "\"");
					psi.WorkingDirectory = Program.pr;
					psi.UseShellExecute = false;
					psi.RedirectStandardOutput = true;
					psi.CreateNoWindow = true;
					psi.StandardOutputEncoding = Encoding.UTF8;
					Process p = Process.Start(psi);
					esito = p.StandardOutput.ReadToEnd();
					p.WaitForExit(30000);
					if (esito.Trim() == "")
					{
						esito = "Nessuna risposta dal motore di ricerca (py -3.13 funzionante?).";
					}
				}
				catch (Exception ex)
				{
					esito = "Errore: " + ex.Message;
				}
				try
				{
					BeginInvoke((MethodInvoker)delegate
					{
						txtEsito.Text = esito;
						btnCerca.Enabled = true;
					});
				}
				catch
				{
				}
			});
			th.IsBackground = true;
			th.Start();
		}
	}
}