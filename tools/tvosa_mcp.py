# TvOsa - TV On SmartfOne App
# Copyright (C) 2011-2026 akalus69
# Licenza GNU GPLv3 - vedi LICENSE
#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
TVOSA MCP bridge (stdio) — pure stdlib, zero dependencies.
Ponte tra agente MCP e il ControlServer HTTP dentro TvOsa.exe (127.0.0.1:19831).
Protocollo: JSON-RPC 2.0 newline-delimited (MCP stdio transport).
"""
import json
import sys
import urllib.error
import urllib.parse
import urllib.request

BASE = "http://127.0.0.1:19831/tvosa/"


def api(method, path, params=None):
    url = BASE + path
    if params:
        url += "?" + urllib.parse.urlencode(params)
    data = b"" if method == "POST" else None
    req = urllib.request.Request(url, data=data, method=method)
    try:
        with urllib.request.urlopen(req, timeout=60) as resp:
            return resp.read().decode("utf-8", "replace"), False
    except urllib.error.HTTPError as e:
        return e.read().decode("utf-8", "replace"), True
    except Exception as e:
        return "TVOSA non risponde (l'app e' aperta?): %s" % e, True


TOOLS = [
    ("tvosa_find_film", "Dove vedere un film o serie OGGI: cerca il titolo e dice su quali piattaforme e' disponibile in ITALIA (JustWatch). Include abbonamento/gratis/noleggio. Se c'e' solo all'estero, qui NON risulta.",
     {"title": {"type": "string", "description": "titolo del film/serie"},
      "country": {"type": "string", "description": "paese catalogo, default IT"}}, ["title"]),
    ("tvosa_status", "Stato di TVOSA: app viva, registrazione agent attiva, contatori canali/prenotazioni, cartella REG.", {}),
    ("tvosa_channels", "Lista completa dei canali nel database (nome + url).", {}),
    ("tvosa_favorites", "Lista preferiti del telecomando (numero + nome).", {}),
    ("tvosa_play", "Accende/un canale: cerca per nome nel DB (o url diretto) e lo apre col metodo ufficiale dell'app.",
     {"name": {"type": "string", "description": "nome canale (ricerca nel DB)"},
      "url": {"type": "string", "description": "oppure URL diretto"}}, []),
    ("tvosa_epg", "Palinsesto giornaliero del canale (via mymovies, la stessa fonte dell'app).",
     {"channel": {"type": "string"}}, ["channel"]),
    ("tvosa_record_start", "Avvia una registrazione ORA sul canale (motore yt-dlp, solo sorgenti ufficiali).",
     {"channel": {"type": "string", "description": "nome canale o URL"},
      "name": {"type": "string", "description": "nome base del file (opzionale)"}}, ["channel"]),
    ("tvosa_record_stop", "Ferma la registrazione avviata da tvosa_record_start.", {}),
    ("tvosa_recordings", "Elenca i file registrati nella cartella REG.", {}),
    ("tvosa_schedule_list", "Elenca le prenotazioni dello scheduler per oggi (indice, file, riga, marker).", {}),
    ("tvosa_schedule_add", "Prenota un programma nello scheduler ufficiale (formato 2011 riga+marker REC).",
     {"title": {"type": "string"},
      "time": {"type": "string", "description": "inizio hh:mm"},
      "channel": {"type": "string", "description": "nome canale o URL registrabile"},
      "end": {"type": "string", "description": "fine hh:mm (opzionale, default +1h)"},
      "url": {"type": "string", "description": "URL esplicito (opzionale)"}}, ["title", "time", "channel"]),
    ("tvosa_schedule_delete", "Annulla una prenotazione per indice (da tvosa_schedule_list).",
     {"index": {"type": "integer"}}, ["index"]),
    ("tvosa_channel_add", "Aggiunge un canale al database (backup automatico prima).",
     {"name": {"type": "string"}, "url": {"type": "string", "description": "URL http/https"}}, ["name", "url"]),
    ("tvosa_channel_delete", "Rimuove un canale dal database per nome esatto (backup automatico).",
     {"name": {"type": "string"}}, ["name"]),
    ("tvosa_favorite_add", "Aggiunge un canale esistente ai preferiti del telecomando.",
     {"name": {"type": "string"}}, ["name"]),
    ("tvosa_favorite_delete", "Rimuove un preferito per nome (ri-numera la lista).",
     {"name": {"type": "string"}}, ["name"]),
    ("tvosa_trailers", "Pool di titoli da guardare (motore selettore serata): pozzi misto/sala/recenti/capolavori, con genere e tipo. Ritorna JSON con 'pool'.",
     {"mode": {"type": "string", "description": "misto|sala|recenti|capolavori (default misto)"},
      "genre": {"type": "string", "description": "es. giallo, thriller, azione, commedia (vuoto = tutti)"},
      "type": {"type": "string", "description": "film|serie|tutto (default tutto)"},
      "offset": {"type": "integer"}, "pool": {"type": "integer", "description": "quanti titoli (default 10)"},
      "seed": {"type": "integer", "description": "per MISCELA reproducibile"},
      "year": {"type": "integer", "description": "anno di uscita esatto (es. 2025)"},
      "apri": {"type": "boolean", "description": "apre il pannello TRAILER di TVOSA con questi filtri (pool navigabile)"}}, []),
    ("tvosa_trailer", "Cerca il trailer italiano (fallback originale) su YouTube per titolo+anno. Ritorna youTubeId ed embed. Con apri=true lo apre DENTRO il pannello TRAILER dell'app TVOSA.",
     {"title": {"type": "string"}, "year": {"type": "integer"},
      "apri": {"type": "boolean", "description": "apri il trailer nel pannello TRAILER di TVOSA"}}, ["title"]),
]


def tool_defs():
    out = []
    for t in TOOLS:
        name, desc, props = t[0], t[1], t[2]
        req = t[3] if len(t) > 3 else []
        schema = {"type": "object", "properties": props}
        if req:
            schema["required"] = req
        out.append({"name": name, "description": desc, "inputSchema": schema})
    return out


JW_URL = "https://apis.justwatch.com/graphql"

JW_SEARCH = """
query GetSearchTitles($searchTitlesFilter: TitleFilter!, $country: Country!, $language: Language!, $first: Int!) {
  popularTitles(country: $country, filter: $searchTitlesFilter, first: $first, sortBy: POPULAR, sortRandomSeed: 0) {
    edges { node { id objectId objectType content(country: $country, language: $language) { title originalReleaseYear } } }
  }
}"""

JW_OFFERS = """
query GetTitleOffers($nodeId: ID!, $country: Country!, $filterBuy: OfferFilter!, $platform: Platform! = WEB) {
  node(id: $nodeId) {
    ... on MovieOrShowOrSeasonOrEpisode {
      o: offers(country: $country, platform: $platform, filter: $filterBuy) {
        presentationType monetizationType retailPriceValue currency
        package { clearName technicalName }
      }
    }
  }
}"""

MON_LABEL = {
    "FLATRATE": "in abbonamento",
    "FREE": "GRATIS (con pubblicita)",
    "PURE": "gratis (on demand gratuito)",
    "RENT": "noleggio",
    "BUY": "acquisto",
    "CINEMA": "al cinema",
}


def jw_gql(query, variables, op):
    body = json.dumps({"operationName": op, "query": query, "variables": variables}).encode("utf-8")
    req = urllib.request.Request(JW_URL, data=body, headers={
        "Content-Type": "application/json", "User-Agent": "Mozilla/5.0"})
    with urllib.request.urlopen(req, timeout=25) as resp:
        return json.loads(resp.read().decode("utf-8", "replace"))


def find_film(title, country="IT"):
    if not title:
        return "serve un titolo", True
    try:
        r = jw_gql(JW_SEARCH, {"searchTitlesFilter": {"searchQuery": title, "includeTitlesWithoutUrl": True},
                               "country": country, "language": "it", "first": 5}, "GetSearchTitles")
        edges = r.get("data", {}).get("popularTitles", {}).get("edges", [])
        if not edges:
            return "nessun risultato per '%s'" % title, True
        # il primo risultato POPULAR a volte e' un omonimo senza offerte (es. "Scream"
        # = serie MTV 2015): controllo ogni candidato e mostro TUTTI quelli disponibili.
        risultati = []
        for e in edges[:5]:
            node = e["node"]
            cat = node.get("content")
            if not cat:
                continue
            r2 = jw_gql(JW_OFFERS, {"nodeId": node["id"], "country": country, "filterBuy": {}}, "GetTitleOffers")
            offers = (r2.get("data", {}).get("node") or {}).get("o") or []
            grouped = {}
            for o in offers:
                mon = MON_LABEL.get(o.get("monetizationType"), o.get("monetizationType"))
                pkg = o["package"]["clearName"]
                prezzo = ""
                if o.get("retailPriceValue"):
                    prezzo = " %.2f %s" % (o["retailPriceValue"], o.get("currency") or "")
                grouped.setdefault(mon, set()).add(pkg + prezzo)
            if not grouped:
                continue
            risultati.append({"titolo": cat.get("title"), "anno": cat.get("originalReleaseYear"),
                              "tipo": "film" if node.get("objectType") == "MOVIE" else "serie",
                              "disponibilita": {k: sorted(v) for k, v in grouped.items()}})
            if len(risultati) >= 3:
                break
        out = {"paese_catalogo": country,
               "alternative_cercate": [e["node"]["content"].get("title") for e in edges[1:5] if e["node"].get("content")]}
        if risultati:
            primo = risultati[0]
            out["titolo"] = primo["titolo"]
            out["anno"] = primo["anno"]
            out["tipo"] = primo["tipo"]
            out["disponibilita"] = primo["disponibilita"]
            out["risultati"] = risultati
            if len(risultati) > 1:
                out["nota"] = "titolo ambiguo: mostrati %d risultati disponibili" % len(risultati)
        else:
            cat = (edges[0]["node"].get("content") or {})
            out["titolo"] = cat.get("title")
            out["anno"] = cat.get("originalReleaseYear")
            out["tipo"] = "film" if edges[0]["node"].get("objectType") == "MOVIE" else "serie"
            out["disponibilita"] = {}
            out["esito"] = "NON disponibile in %s oggi (ne' abbonamento, ne' gratis, ne' noleggio)" % country
        return json.dumps(out, ensure_ascii=False, indent=1), False
    except Exception as e:
        return "JustWatch non raggiungibile: %s" % e, True


def _trailer_args(args):
    out = []
    for k, flag in (("mode", "--mode"), ("genre", "--genre"), ("type", "--type"),
                    ("offset", "--offset"), ("pool", "--pool"), ("seed", "--seed")):
        v = args.get(k)
        if v not in (None, "", 0):
            out += [flag, str(v)]
    return out


def _sidecar_trailer(cli_args):
    # fallback app spenta: stesso motore, lanciato diretto (pattern RecorderService)
    import os
    import subprocess
    me = os.path.dirname(os.path.abspath(__file__))
    py = sys.executable or "py"
    try:
        r = subprocess.run([py, os.path.join(me, "tvosa_trailer.py")] + cli_args,
                           capture_output=True, timeout=120)
        txt = r.stdout.decode("utf-8", "replace").strip()
        if txt.startswith("{"):
            return txt, False
        return "motore trailer: " + (txt or r.stderr.decode("utf-8", "replace"))[:400], True
    except Exception as e:
        return "motore trailer fallito: %s" % e, True


def call_tool(name, args):
    args = args or {}
    g = lambda k: str(args.get(k, "") or "")
    if name == "tvosa_find_film":
        title = g("title")
        country = (g("country") or "IT").upper()
        # prima passa dal server TVOSA (endpoint /findfilm, motore unico dell'app);
        # se l'app e' spenta fallback locale, stessa funzione identica.
        res, err = api("GET", "findfilm", {"title": title, "country": country})
        if not err and res.strip().startswith("{"):
            return res, False
        return find_film(title, country)
    if name == "tvosa_trailers":
        p = {}
        for k in ("mode", "genre", "type"):
            if g(k):
                p[k] = g(k)
        for k in ("offset", "pool", "seed", "year"):
            if args.get(k) not in (None, "", 0):
                p[k] = str(int(args[k]))
        if args.get("apri") in (True, "true", "1", "si", "sì", "yes"):
            return api("GET", "trailershow", p)
        res, err = api("GET", "trailers", p)
        if not err and res.strip().startswith("{"):
            return res, False
        return _sidecar_trailer(["--json"] + _trailer_args(args))
    if name == "tvosa_trailer":
        t = g("title")
        if args.get("apri") in (True, "true", "1", "si", "sì", "yes"):
            return api("GET", "trailershow", {"title": t, "year": str(args.get("year", ""))})
        res, err = api("GET", "trailer", {"title": t, "year": str(args.get("year", ""))})
        if not err and res.strip().startswith("{"):
            return res, False
        y = str(args.get("year", "") or "")
        return _sidecar_trailer(["--json", "--trailerfor", t] + ([y] if y else []))
    if name == "tvosa_status":
        return api("GET", "status")
    if name == "tvosa_channels":
        return api("GET", "channels")
    if name == "tvosa_favorites":
        return api("GET", "favorites")
    if name == "tvosa_play":
        return api("POST", "play", {"name": g("name"), "url": g("url")})
    if name == "tvosa_epg":
        return api("GET", "epg", {"channel": g("channel")})
    if name == "tvosa_record_start":
        return api("POST", "record/start", {"channel": g("channel"), "name": g("name")})
    if name == "tvosa_record_stop":
        return api("POST", "record/stop")
    if name == "tvosa_recordings":
        return api("GET", "recordings")
    if name == "tvosa_schedule_list":
        return api("GET", "schedule")
    if name == "tvosa_schedule_add":
        p = {"title": g("title"), "time": g("time"), "channel": g("channel")}
        if g("end"):
            p["end"] = g("end")
        if g("url"):
            p["url"] = g("url")
        return api("POST", "schedule", p)
    if name == "tvosa_schedule_delete":
        return api("DELETE", "schedule", {"index": str(args.get("index", ""))})
    if name == "tvosa_channel_add":
        return api("POST", "channels", {"name": g("name"), "url": g("url")})
    if name == "tvosa_channel_delete":
        return api("DELETE", "channels", {"name": g("name")})
    if name == "tvosa_favorite_add":
        return api("POST", "favorites", {"name": g("name")})
    if name == "tvosa_favorite_delete":
        return api("DELETE", "favorites", {"name": g("name")})
    return "tool sconosciuto: " + name, True


def send(msg):
    sys.stdout.write(json.dumps(msg, ensure_ascii=False) + "\n")
    sys.stdout.flush()


def main():
    for line in sys.stdin:
        line = line.strip()
        if not line:
            continue
        try:
            req = json.loads(line)
        except ValueError:
            continue
        rid = req.get("id")
        method = req.get("method", "")
        if method == "initialize":
            send({"jsonrpc": "2.0", "id": rid, "result": {
                "protocolVersion": req.get("params", {}).get("protocolVersion", "2024-11-05"),
                "capabilities": {"tools": {}},
                "serverInfo": {"name": "tvosa", "version": "1.0.0"}}})
        elif method.startswith("notifications/"):
            continue
        elif method == "ping":
            send({"jsonrpc": "2.0", "id": rid, "result": {}})
        elif method == "tools/list":
            send({"jsonrpc": "2.0", "id": rid, "result": {"tools": tool_defs()}})
        elif method == "tools/call":
            p = req.get("params", {})
            text, is_err = call_tool(p.get("name", ""), p.get("arguments", {}))
            send({"jsonrpc": "2.0", "id": rid, "result": {
                "content": [{"type": "text", "text": text}], "isError": bool(is_err)}})
        elif rid is not None:
            send({"jsonrpc": "2.0", "id": rid,
                  "error": {"code": -32601, "message": "method non supportato: " + method}})


if __name__ == "__main__":
    main()