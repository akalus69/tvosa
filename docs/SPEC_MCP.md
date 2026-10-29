# SPEC — TVOSA MCP Control (v1)

## Obiettivo
Permettere a un agente (Hermes) di comandare TVOSA tramite MCP, usando le catene ufficiali dell'app.

## Architettura (decisioni grill 2026-10-28)
- **A**: micro-server HTTP `HttpListener` dentro TvOsa.exe su `http://127.0.0.1:19831/tvosa/` (niente token, bind localhost-only).
- Ponte MCP: sidecar Python `tools/tvosa_mcp.py` (FastMCP, stdio) che chiama le API HTTP.
- Registrazione: MCP locale nel profilo Hermes (tool `tvosa_*`).
- Ciclo di vita app: FUORI scope (non selezionato).

## Endpoint (dentro l'app)
| Metodo | Path | Azione |
|---|---|---|
| GET | /status | versione, finestre aperte, stato registrazione, prox. appuntamento |
| GET | /channels | coppie da nuovicanali.txt |
| GET | /favorites | numerati da proprietel.txt |
| POST | /play {name} | zapping: DB lookup → catena ufficiale (browser esterno via WEBTV) |
| POST | /playurl {url} | come sopra ma URL diretto |
| GET | /epg?channel=X | griglia mymovies col parser ufficiale dell'app (13 canali + tv2000/focus) |
| POST | /record/start {channel,name} | RecorderService.Launch con url = urlregistrazione(channel) |
| POST | /record/stop | stop sidecar |
| GET | /recordings | file in REG/ |
| GET | /schedule | prenotazioni scheduler |
| POST | /schedule {title,channel,time} | prenotazione via catena funzionilista (ric="titolo|||hh:mm") |
| DELETE | /schedule {index} | annulla |
| POST | /channels {name,url} | aggiungi canale (backup prima) |
| DELETE | /channels {name} | rimuovi canale |
| POST | /favorites {name} | aggiungi preferito |
| DELETE | /favorites {name} | rimuovi preferito |

## Regole
- Tutte le azioni passano dal codice dell'app (no click esterni, no coordinate).
- I file dati si scrivono in byte-mode CRLF (parser 2011 ReadLine a coppie).
- Ogni mutazione canali/preferiti: backup timestampato prima di scrivere.
- Il listener gira su thread proprio; le azioni UI passano da BeginInvoke su Form1.
- Nessun commit senza OK utente.

## Criteri di accettazione
1. `curl /status` risponde con JSON mentre l'app gira.
2. `tvosa_play` su un canale YouTube apre Chrome sullla diretta.
3. `tvosa_record_start`/`stop` produce mp4 registrato via sidecar.
4. `tvosa_schedule_add` compare nella lista prenotazioni dell'app e scatta all'ora.
5. `tvosa_channel_add/remove` aggiorna il DB con backup; la lista CANALI dell'app lo riflette.
6. Tool `tvosa_*` visibili e usabili in Hermes; test end-to-end verde.