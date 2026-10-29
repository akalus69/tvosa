# SPEC — SELETTORE SERATA "TRAILER" (dove vedo cosa stasera)

Stato: APPROVATA DALL'UTENTE il 2026-10-29 dopo grilling (4 round) — non ancora implementata.
Fonte decisioni: intervista 2026-10-29 (Q1-Q19) + probe JustWatch/WebView2 dello stesso giorno.

## Glossario
- **Pozzo**: una delle 3 sorgenti di candidati (IN SALA, RECENTI, CAPOLAVORI).
- **Pool**: la finestra di 10 trailer correnti mostrati dal selettore; si estende infinito.
- **Selettore**: la finestra in-app che mostra 1 trailer alla volta con AVANTI/INDIETRO/MISCELA.
- **DOVE È**: pulsante che apre TROVA FILM compilato col titolo corrente.
- **GUARDALO ORA**: pulsante (F2) visibile solo se il titolo è su un abbonamento flaggato; apre la piattaforma sul film.
- **Abbonamento flaggato**: servizio di streaming che l'utente ha spuntato come "ce l'ho".

## Problem Statement
L'utente la sera vuole guardare un film/serie ma non sa cosa scegliere. Oggi TVOSA sa solo DOVE vede un titolo già deciso (TROVA FILM), ma non aiuta a DECIDERE: non esiste un modo per sfogliare per genere/piattaforma/periodo e guardare i trailer uno alla volta, e i capolavori vecchi non vengono mai proposti perché i filtri "per uscita" non li raggiungono.

## Solution
Un selettore a pozzi: l'utente (o l'agente) chiede "azione stasera" e TVOSA compone un pool infinito di 10 candidati alla volta (ricarica al 5°) pescando da 3 pozzi — in sala ora, usciti negli ultimi 12 mesi, capolavori da recensioni — mostrati uno alla volta come trailer ufficiale italiano dentro l'app (WebView2). Ogni trailer ha DOVE È (motore TROVA FILM esistente) e, dalla Fase 2, GUARDALO ORA se il titolo è disponibile su un abbonamento flaggato. Motore UNICO condiviso tra finestra, server ControlServer e tool MCP.

## User Stories
1. Come utente serale, voglio dire "ho voglia d'azione" e vedere subito un trailer, per decidere senza pensare.
2. Come utente, voglio un trailer alla volta con un click su AVANTI, per sfogliare come un flipper.
3. Come utente, voglio andare anche INDIETRO, per rivedere un candidato scartato troppo in fretta.
4. Come utente, voglio MISCELA per ricampionare quando il pool non mi ispira.
5. Come utente che guarda 30 trailer a serata, voglio che il pool si ricarichi da solo (al 5° arriva il prossimo blocco di 10), senza attese percettibili.
6. Come utente, voglio filtrare per genere (azione, giallo/thriller, commedia, orrore, sci-fi, dramma...).
7. Come utente, voglio scegliere tipo film / serie / tutto con un'unica finestra.
8. Come utente, voglio il pozzo "IN SALA ORA" per i film appena usciti al cinema in Italia.
9. Come utente, voglio il pozzo "RECENTI" = usciti negli ultimi ~12 mesi.
10. Come utente, voglio il pozzo "CAPOLAVORI" di film anche vecchi che non conosco (I soliti sospetti docet).
11. Come utente, senza specificare modalità, voglio il menù degustazione 60% recenti / 20% in sala / 20% capolavori.
12. Come utente, voglio una spunta "solo i miei abbonamenti" ben visibile, spenta di default.
13. Come utente, voglio che l'ultima posizione della spunta venga salvata e ripristinata al riavvio.
14. Come utente, voglio la lista dei servizi famosi (Netflix, Prime, Apple TV, Disney+, Paramount+, NOW, Sky Go, Infinity, Rai Play, MUBI, Crunchyroll, HBO Max...) con checkbox "ce l'ho".
15. Come utente, voglio che un capolavoro non disponibile oggi venga mostrato lo stesso, con chi chiarezza su dove è.
16. Come utente, mentre guardo un trailer che mi piace, voglio premere DOVE È e trovare TROVA FILM già compilato.
17. Come utente (F2), se il film è su un mio abbonamento voglio GUARDALO ORA e atterrare sulla pagina del film nella piattaforma.
18. Come utente (F2), voglio TROVA FILM e TRAILER nascosti dentro OPZIONI, senza barre colorate sul telecomando.
19. Come agente, voglio un endpoint del server per comporre pool di candidati con filtri, per rispondere in chat.
20. Come agente (F3), voglio un tool MCP che restituisca lista ordinata (titolo, anno, genere, dove vederlo, link trailer) e apra il trailer del primo nel browser.
21. Come utente, voglio trailer SEMPRE in italiano (fallback originale se non esiste).
22. Come utente, voglio vedere il trailer dentro l'app (WebView2), senza essere sbattuto fuori ogni volta.
23. Come sviluppatore, voglio che finestra, server e agente usino lo stesso identico motore, per non duplicare la logica.
24. Come sviluppatore, voglio che ogni pozzo sia testabile da CLI con output JSON, come tvosa_find.py.
25. Come utente, voglio che un canale/pezzo morto non blocchi mai il flusso: candidato senza trailer → si salta in silenzio.

## Implementation Decisions
### Architettura (motore unico, come TROVA FILM)
- Nuovo sidecar Python `tools/tvosa_trailer.py` (stdlib + yt-dlp solo per ricerca trailer): espone i 3 pozzi + composizione pool, output JSON; modalità `--json` per il server, modalità testo per debug CLI.
- `find_film`/ricerca JustWatch del bridge MCP resta il motore "dove è"; il motore trailer lo riusa per le offerte.
- ControlServer aggiunge `GET /trailers?mode=&genre=&type=&subs=&page=` che invoca il sidecar e rimanda JSON (pattern identico a /findfilm, 45s timeout).
- Nuova finestra WinForms `SelettoreTrailers` con WebView2 (runtime verificato v156): player, etichetta titolo/anno/genere, pulsanti AVANTI/INDIETRO/MISCELA/DOVE È; prefetch del blocco successivo quando l'indice arriva al 5°.
- csproj: pacchetto WebView2 (NuGet Microsoft.Web.WebView2, target net48 supportato) + Content copy dei nuovi sidecar.

### Pozzi (sorgente dati verificata 2026-10-29)
- IN SALA: JustWatch GraphQL `popularTitles` filtro `monetizationTypes:[CINEMA]` ✔ testato.
- RECENTI: `popularTitles` POPULAR, anno `originalReleaseYear >= oggi-12mesi` filtrato client-side (TitleFilter non espone range anno ✔ testato), paginando con `skip`.
- CAPOLAVORI: fusione mymovies.it (liste per genere + voto, scraping fragile DA ISOLARE in un solo parser), fallback JustWatch sortBy `IMDB_SCORE` ✔ validato. Include titoli NON disponibili oggi (decisione Q13).
- Default senza modalità: blend 60/20/20 (Q16).
- Generi: mappa italiano → codici corti JustWatch (`act`,`drm`,`cmy`,`scf` ✔; mapping completo giallo/thriller/horror da pescare all'implementazione; mymovies usa i propri).
- Tipo: film/serie/tutto → `objectTypes` MOVIE/SHOW.

### Trailer
- Ricerca `yt-dlp ytsearch1 "<titolo> <anno> trailer italiano"` (tecnica con canale world già rodata), fallback senza "italiano"; ID estratto → `https://www.youtube.com/embed/<id>?autoplay=1&cc_load_policy=1`.
- Candidato senza trailer trovato → scartato silenziosamente dal pool.

### Abbonamenti (F2)
- File dati nuovo `servizi.txt` (stile 2011, CRLF byte-mode) con righe `technicalName|clearName|flag`; seeded dal listino packages JustWatch IT (107 trovati, esposti ~25 famosi + estendibili).
- Flag "solo miei abbonamenti" persistito in file `preferenzetrailer` (ultimo stato, Q17).
- GUARDALO ORA: reindirizzamento JustWatch watched (URL API watched IT; formato esatto da verificare in implementazione) → fallback home piattaforma.
- Detective TV / canali Prime / "hmb-hbm": FUORI dalla v1 (non nel listino JustWatch) → v1.5 "servizi custom".

### UI
- F1: finestra raggiungibile temporaneamente dal pulsante TRAILER provvisorio (o menu debug) per collaudare.
- F2: TROVA FILM e TRAILER diventano voci della finestra OPZIONI; rimosso il pulsante blu "TROVA FILM" dal telecomando (era "orrendo graficamente").

### Fase 3 (agente)
- Bridge MCP: tool `tvosa_trailers` (mode/genre/type/subs) → chiama GET /trailers, fallback locale sidecar se app spenta (pattern find_film); risposta all'utente: lista ordinata + apertura browser del trailer del primo (Q5).

## Testing Decisions
- **Seam primario (uno solo)**: CLI del sidecar `tvosa_trailer.py` — JSON esteriore (campi: titoli, anni, generi, trailerId, posizione nel pool, blend 60/20/20, ricarica al 5°). Test = invocazioni CLI reali che asseriscono struttura e appartenenza al pozzo/filtro; niente test su funzioni interne.
- Server: smoke test curl su /trailers (stessa famiglia di test di /findfilm, /status, /schedule).
- Finestra: smoke test manuale via computer_use (click AVANTI/MISCELA/DOVE È, screenshot) come fatto per TROVA FILM.
- Reti reali: i test di pool/pozzi sono integration test (JustWatch/YouTube/mymovies); si accettano flop di rete con retry, NON si mockano i provider (coerente con i test sidecar esistenti).
- Prior art: test stdio del bridge MCP, curl dei ControlServer endpoint, test sidecar tvosa_find.py.

## Out of Scope
- Widevine/DRM, re-stream, pirateria (vincolo storico del progetto).
- Servizi non nel listino JustWatch (Detective TV, canali Prime custom) → v1.5.
- Profilazione/chronologia "già visti", like/dislike persistenti, suggerimenti personalizzati.
- Trailer dentro il telecomando principale; player diversi da WebView2.
- Cache offline dei trailer.
- Notifiche/autoplay notturno.

## Further Notes
- FATTI verificati 2026-10-29: WebView2 runtime 156.0.4314.50 presente; JustWatch packages IT = 107; filtro CINEMA ok; sortBy IMDB_SCORE accettato; generi enum = shortName (act/drm/cmy/scf ok; thr/mys/hor/CRIME/ACTION no); GraphQL non espone trailerId (campo assente) → ricerca YouTube obbligatoria; TitleFilter ignora releaseYearRange (422).
- Le pagine mymovies per i capolavori vanno ricognite in implementazione (parser isolato, testabile da solo).
- Regole di progetto invariate: nessun commit senza OK esplicito dell'utente; build Release "Errori: 0" prima di ogni collaudo; file dati in byte-mode CRLF.