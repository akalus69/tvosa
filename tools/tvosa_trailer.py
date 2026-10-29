# TvOsa - TV On SmartfOne App
# Copyright (C) 2011-2026 akalus69
# Licenza GNU GPLv3 - vedi LICENSE
#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
tvosa_trailer.py — motore "SELETTORE SERATA" di TVOSA (SPEC_TRAILER.md Fase 1).
3 pozzi JustWatch (sala/recenti/capolavori) + pool infinito + trailer IT via yt-dlp.
STESSA catena dei sidecar TVOSA: stdout JSON --json, testo leggibile senza.

Uso:
  py -3.13 tvosa_trailer.py --json --mode misto|sala|recenti|capolavori
                            [--genre azione] [--type film|serie|tutto]
                            [--offset 0] [--pool 10] [--seed N]
  py -3.13 tvosa_trailer.py --json --trailerfor "<titolo>" "<anno>"
"""
import json
import os
import random
import subprocess
import sys
import time
import urllib.request
import urllib.error

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
sys.stdout.reconfigure(encoding="utf-8")
from tvosa_mcp import jw_gql  # stessa rete JustWatch del motore TROVA FILM

GQL = "https://apis.justwatch.com/graphql"

POPULAR_TITLES = """query T($country: Country!, $language: Language!, $filter: TitleFilter!, $first: Int!) {
  popularTitles(country: $country, filter: $filter, first: $first, sortBy: POPULAR, sortRandomSeed: 0) {
    edges { node { id objectId
      content(country: $country, language: $language) { title originalReleaseYear genres { shortName } }
    } }
  }
}"""

RANKED_TITLES = """query T($country: Country!, $language: Language!, $filter: TitleFilter!, $first: Int!) {
  popularTitles(country: $country, filter: $filter, first: $first, sortBy: IMDB_SCORE, sortRandomSeed: 0) {
    edges { node { id objectId
      content(country: $country, language: $language) { title originalReleaseYear genres { shortName } }
    } }
  }
}"""

# generi italiani -> codici corti JustWatch IT (verificati 2026-10-29)
GENRES = {
    "azione": "act", "avventura": "act", "commedia": "cmy", "dramma": "drm",
    "thriller": "trl", "giallo": "crm", "crime": "crm", "poliziesco": "crm",
    "orrore": "hrr", "horror": "hrr", "romantico": "rma", "romance": "rma",
    "fantasy": "fnt", "fantascienza": "scf", "scifi": "scf", "scienza": "scf",
    "animazione": "ani", "cartoni": "ani", "storia": "hst", "guerra": "war",
    "famiglia": "fml", "bambini": "fml", "musica": "msc", "documentario": "doc",
    "western": "wsn", "sport": "spt",
}

MESI_RECENTI = 12


def jw_popular(filt, first=100, ranked=False):
    q = RANKED_TITLES if ranked else POPULAR_TITLES
    r = jw_gql(q, {"country": "IT", "language": "it", "filter": filt, "first": first}, "T")
    edges = (r.get("data") or {}).get("popularTitles", {}).get("edges", []) or []
    out = []
    for e in edges:
        n = e["node"]
        c = n.get("content") or {}
        if not c.get("title"):
            continue
        out.append({"id": n["id"], "objectId": n.get("objectId"),
                    "titolo": c["title"], "anno": c.get("originalReleaseYear"),
                    "genere": [g["shortName"] for g in (c.get("genres") or [])]})
    return out


def base_filter(mode_type, genre, year=None):
    f = {}
    if mode_type == "film":
        f["objectTypes"] = ["MOVIE"]
    elif mode_type == "serie":
        f["objectTypes"] = ["SHOW"]
    else:
        f["objectTypes"] = ["MOVIE", "SHOW"]
    if genre:
        codes = []
        for gg in genre.split(","):
            code = GENRES.get(gg.strip().lower())
            if code and code not in codes:
                codes.append(code)
        if codes:
            f["genres"] = codes
    if year:
        y = int(year)
        f["releaseYear"] = {"min": y, "max": y}  # IntFilter: min/max, NON range/eq
    return f


def well_sala(f):
    f2 = dict(f)
    f2["monetizationTypes"] = ["CINEMA"]
    return jw_popular(f2, 100)


def well_recenti(f):
    if "releaseYear" in f:
        return jw_popular(f, 100)  # anno gia' imposto lato JustWatch
    now = time.gmtime()
    min_year = now.tm_year - 1  # ~12 mesi (anno come proxy, JustWatch non ha range)
    out = []
    for t in jw_popular(f, 100):
        try:
            if int(t["anno"]) >= min_year:
                out.append(t)
        except (TypeError, ValueError):
            pass
    return out


def well_capolavori(f):
    # intersezione: ordinati per voto IMDb MA presenti nel POPULAR (serve a
    # togliere la spazzatura poco vista che vince a poche valutazioni)
    ranked = jw_popular(f, 60, ranked=True)
    popular_ids = set(t["id"] for t in jw_popular(f, 100))
    out = [t for t in ranked if t["id"] in popular_ids]
    return out


def pick_wells(mode, f):
    if mode == "sala":
        return {"sala": well_sala(f)}
    if mode == "recenti":
        return {"recenti": well_recenti(f)}
    if mode == "capolavori":
        return {"capolavori": well_capolavori(f)}
    return {"sala": well_sala(f), "recenti": well_recenti(f), "capolavori": well_capolavori(f)}


def blend(wells, pool_size, offset, seed):
    if len(wells) == 1:
        name, items = list(wells.items())[0]
        cand = [dict(t, pozzo=name) for t in items]
    else:
        # menù degustazione 60/20/20 (Q16): ogni blocco di 10 = 6 recenti, 2 sala, 2 capolavori
        quotas = {"recenti": 6, "sala": 2, "capolavori": 2}
        idx = {k: 0 for k in wells}
        cand = []
        while len(cand) < offset + pool_size + 20:
            added = False
            for name in ("recenti", "sala", "capolavori"):
                items = wells.get(name) or []
                for _ in range(quotas[name]):
                    if idx[name] < len(items):
                        cand.append(dict(items[idx[name]], pozzo=name))
                        idx[name] += 1
                        added = True
            if not added:
                break
    if seed is not None:
        rnd = random.Random(seed)
        rnd.shuffle(cand)
    return cand[offset:offset + pool_size], len(cand)


def find_trailer(title, year):
    py = sys.executable
    queries = ["%s %s trailer italiano ufficiale" % (title, year or ""),
               "%s %s trailer italiano" % (title, year or ""),
               "%s %s official trailer" % (title, year or "")]
    for q in queries:
        q = q.strip()
        try:
            r = subprocess.run([py, "-m", "yt_dlp", "--flat-playlist", "--print", "%(id)s",
                                "ytsearch1:" + q, "--no-warnings"],
                               capture_output=True, text=True, timeout=25)
            vid = (r.stdout or "").strip().splitlines()
            if r.returncode == 0 and vid and vid[0].strip():
                return vid[0].strip()
        except Exception:
            pass
    return None


def main():
    args = sys.argv[1:]
    raw = "--json" in args
    args = [a for a in args if a != "--json"]

    def opt(name, default=None):
        if name in args:
            i = args.index(name)
            if i + 1 < len(args):
                return args[i + 1]
        return default

    if "--trailerfor" in args:
        i = args.index("--trailerfor")
        title = args[i + 1] if i + 1 < len(args) else ""
        year = args[i + 2] if i + 2 < len(args) else ""
        vid = find_trailer(title, year)
        res = {"titolo": title, "youTubeId": vid,
               "embed": ("https://www.youtube.com/embed/%s?autoplay=1&rel=0&cc_load_policy=1" % vid) if vid else None}
        print(json.dumps(res, ensure_ascii=False))
        return

    mode = (opt("--mode") or "misto").lower()
    genre = (opt("--genre") or "").lower()
    tipo = (opt("--type") or "film").lower()
    offset = int(opt("--offset") or 0)
    pool_size = int(opt("--pool") or 10)
    seed_s = opt("--seed")
    seed = int(seed_s) if seed_s else None
    year = opt("--year")

    if genre and genre not in GENRES:
        bad = [x for x in genre.split(",") if x.strip() and x.strip().lower() not in GENRES]
        if bad:
            msg = "genere '%s' sconosciuto; disponibili: %s" % (genre, ", ".join(sorted(set(GENRES))))
            print(json.dumps({"error": msg}, ensure_ascii=False))
            return

    f = base_filter(tipo, genre, year)
    wells = pick_wells(mode, f)
    pool, total = blend(wells, pool_size, offset, seed)
    # mai candidati senza speranza: togli doppioni per titolo+anno
    seen = set()
    uniq = []
    for t in pool:
        k = (t["titolo"], t["anno"])
        if k in seen:
            continue
        seen.add(k)
        uniq.append(t)
    out = {"mode": mode, "genre": genre or None, "type": tipo, "offset": offset, "year": year or None,
           "pool": uniq, "next_offset": offset + len(uniq), "pozzi_esauriti": total <= offset + pool_size}
    if raw:
        print(json.dumps(out, ensure_ascii=False))
    else:
        for i, t in enumerate(uniq, 1):
            print("%2d. [%s] %s (%s) %s" % (offset + i, t["pozzo"], t["titolo"], t["anno"], ",".join(t["genere"])))
        print("-- next_offset=%d esauriti=%s" % (out["next_offset"], out["pozzi_esauriti"]))


if __name__ == "__main__":
    main()