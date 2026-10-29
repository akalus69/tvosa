# TVOSA — rinascita 2026

**TVOSA** (TV On SmartfOne App) è un tuner software per Windows nato nel 2011: un
telecomando virtuale con cui guardare la televisione in streaming, registrare i
programmi e consultare i palinsesti. Questa è la versione recuperata e
modernizzata nel 2026: il codice originale WinForms/.NET è stato decompilato e
ricostruito con funzionalità aggiornate.

> ⚖️ **Nota**: l'applicazione si collega **esclusivamente a sorgenti ufficiali
> e legali** (RaiPlay, RSI, Mediaset Infinity via browser, YouTube, emittenti
> estere free-to-air). Nessun bypass DRM è previsto o supportato.

## Cosa fa

- 📺 **Telecomando virtuale** con preferiti, zapping e televideo
- 🗓️ **EPG** giornaliera (fonte mymovies.it) con prenotazione registrazioni
- ⏺️ **Registrazione** dei live via `yt-dlp` + `ffmpeg` (solo sorgenti ufficiali)
- 🔎 **TROVA FILM** — "dove vedo X stasera?": consultazione catalogo IT (JustWatch)
- 🎬 **TRAILER** — selettore serata: pozzi "in sala", "usciti di recente",
  "capolavori", filtri per genere/anno/tipo, trailer YouTube nel pannello
- 🤖 **MCP server** integrato (`http://127.0.0.1:19831/tvosa/`, localhost-only):
  18 tool per controllarla da assistenti AI (canali, EPG, registrazioni, trailer)

## Provala senza compilare

Nella root del repository c'è **`TvOsa.zip`**: scaricalo, estrai tutto in una
cartella e avvia `TvOsa.exe` (le dipendenze sono già dentro, `tools/` dei
sidecar incluso).

## Requisiti

- Windows con .NET Framework 4.8
- `python 3.13` con `yt-dlp` (registrazioni e motore trailer)
- `ffmpeg` nei PATH (remux registrazioni)
- WebView2 Runtime (finestra TRAILER; incluso in Windows 10/11 recenti)

## Build

```
cd src/decompiled
dotnet build -c Release TvOsa.csproj
```

Binario: `src/decompiled/bin/Release/net48/TvOsa.exe`

## Server MCP locale (controllo da AI)

Appena TVOSA è avviata espone un server di controllo **solo su localhost**
(nessuna porta aperta verso la rete):

```
http://127.0.0.1:19831/tvosa/status
```

Endpoint principali: `status`, `channels`, `favorites`, `play`, `epg?channel=`,
`record_start`/`record_stop`, `recordings`, `schedule`, `findfilm?title=`,
`trailers`/`trailer`/`trailershow`.

Per collegarla a un client MCP (es. Hermes) usa il bridge `tools/tvosa_mcp.py`
(Python 3.13, solo libreria standard, 18 tool `tvosa_*`):

```
hermes mcp add tvosa --command C:\Windows\py.exe --args -3.13 <percorso>\tools\tvosa_mcp.py
```

oppure, in una configurazione MCP generica (JSON):

```json
{ "mcpServers": { "tvosa": { "command": "py", "args": ["-3.13", "tools/tvosa_mcp.py"] } } }
```

Il bridge parla con l'app via l'endpoint locale; i tool `tvosa_find_film` e
`tvosa_trailers`/`tvosa_trailer` funzionano anche con l'app spenta (fallback
diretto sui sidecar).

## Struttura

| Cartella | Contenuto |
|---|---|
| `TvOsa.zip` | build pronta all'uso (eseguibile + dipendenze + sidecar) |
| `src/decompiled/` | sorgente C# (WinForms, .NET 4.8) |
| `tools/` | sidecar Python: `tvosa_recorder.py`, `tvosa_find.py`, `tvosa_trailer.py`, `tvosa_mcp.py` (bridge MCP) |
| `docs/` | `SPEC_MCP.md`, `SPEC_TRAILER.md` |
| `data/` | database canali e configurazioni (sorgenti ufficiali) |

## Fonti dei canali

Le liste in `data/` puntano solo a stream ufficiali e free-to-air: RaiPlay, RSI,
RSI rete due, Sky TG24 web, France24, DW, Al Jazeera, NHK, NASA TV+, Lofi Girl e
altri canali YouTube ufficiali, radio/video-TV italiane. Aggiungere canali è
libero: sei tu responsabile della legalità delle sorgenti che aggiungi.

## Storia

2011: TVOSA 2.9f viene pubblicata come progetto gratuito. 2026: l'autore
recupera il solo eseguibile, lo decompila e ricostruisce il progetto con
registrazione legale, EPG aggiornata, motore "dove vederlo", selettore trailer
e controllo via MCP.

## Licenza

TVOSA è distribuito con licenza **GNU GPLv3** — vedi `LICENSE`.

> TVOSA — TV On SmartfOne App
> Copyright (C) 2011-2026 akalus69
>
> Questo programma è software libero: potete ridistribuirlo e/o modificarlo
> nei termini della GNU General Public License pubblicata dalla Free Software
> Foundation (versione 3). Il programma è distribuito nella speranza che sia
> utile, ma SENZA ALCUNA GARANZIA.

In pratica: chiunque pubblichi una TVOSA modificata è obbligato a condividere
il sorgente con la stessa licenza.