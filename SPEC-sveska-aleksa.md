# Sveska za Aleksu: specifikacija

Ovaj dokument opisuje kako da napraviš novu svesku za Aleksu. **Funkcionalnost je ista kao u `lazicmilos/sveska`. Menja se samo dizajn.** Sve što piše ispod u delu „Funkcije“ je obavezno ponašanje. Deo „Dizajn“ je mesto gde imaš slobodu.

Pravilo za ceo projekat: ako nešto nije opisano ovde, ponašaj se kao originalna sveska. Ako originalna sveska ima bag (vidi deo 8), **nemoj ga kopirati**.

---

## 1. Šta je sveska

Statičan sajt na GitHub Pages, bez servera i bez build koraka. Ima dve vrste sadržaja:

1. **Zadaci sa slikom**: fotografija zadatka iz sveske ili sa table, uz naslov, predmet i napomenu.
2. **Zadaci sa kodom**: jedan ili više fajlova sa izvornim kodom (najčešće `Program.cs`), uz naslov i napomenu.

Podaci se nalaze u samom repozitorijumu (JSON indeksi i fajlovi). Uređivanje radi iz browsera preko GitHub API-ja, uz Personal Access Token koji ima samo vlasnik.

## 2. Stack i ograničenja

| Stavka | Odluka | Zašto |
|---|---|---|
| Hosting | GitHub Pages, grana `main`, root | Besplatno, nema servera, sadržaj je već u repou |
| Jezik | Čist HTML + CSS + vanilla JS | Nema build-a, nema `node_modules`, radi odmah posle push-a |
| Biblioteke | Samo sa cdnjs: highlight.js `11.9.0`, JSZip `3.10.1` (lenjo učitan) | Fiksne verzije, nema iznenađenja |
| Jezik interfejsa | Srpski (latinica), `lang="sr"` | |
| Datumi | `toLocaleDateString("sr-RS", { day: "2-digit", month: "short", year: "numeric" })` | |
| Bezbednost | Svaki tekst koji ide u HTML string prolazi kroz `esc()` | Stranice grade markup spajanjem stringova |

## 3. Struktura fajlova

```
/
├── index.html        # galerija zadataka sa slikom + lightbox
├── zadaci.html       # zadaci sa kodom: prikaz, kopiranje, preuzimanje
├── upload.html       # uređivanje (prijava tokenom, dodavanje, brisanje)
├── config.js         # owner, repo, grana, URL-ovi (jedini izvor istine)
├── common.js         # zajedničke funkcije za sve tri stranice
├── style.css         # NOV dizajn
├── entries.json      # indeks zadataka sa slikom
├── kod.json          # indeks zadataka sa kodom
├── images/<id>.jpg   # slike
├── kod/<id>/<putanja># fajlovi sa kodom, jedan folder po zadatku
└── sveska-link.md    # linkovi ka sajtu i stranici za uređivanje
```

Redosled učitavanja skripti na svakoj stranici: `config.js`, pa `common.js`, pa inline skripta stranice.

## 4. Konfiguracija (`config.js`)

Jedino mesto gde se pominje GitHub nalog. Sve ostalo čita odavde.

```js
const SITE = (function () {
  const owner = "<ALEKSIN_GITHUB_USERNAME>";
  const repo = "sveska";
  return Object.freeze({
    owner: owner,
    repo: repo,
    branch: "main",
    profileUrl: "https://github.com/" + owner,
    apiBase: "https://api.github.com/repos/" + owner + "/" + repo
  });
})();
```

Ključ za token u `localStorage` promeni u `sveska_aleksa_gh_token`, da se dve sveske ne sudaraju ako se otvaraju sa istog domena.

## 5. Model podataka

### 5.1 `entries.json` (zadaci sa slikom)

Niz objekata:

```json
{
  "id": "1789306559916-v5j70o",
  "title": "zadatak1",
  "subject": "c#",
  "note": "",
  "imagePath": "images/1789306559916-v5j70o.jpg",
  "createdAt": 1789306561584
}
```

- `id`: `String(Date.now()) + "-" + Math.random().toString(36).slice(2, 8)`
- `subject`: ako je prazno, upisuje se `"Opšte"`
- Validan zapis za prikaz: ima `imagePath` i `title`

### 5.2 `kod.json` (zadaci sa kodom)

```json
{
  "id": "1793282404714-p7q4c7",
  "title": "zadatak2",
  "note": "",
  "files": [
    { "name": "Program.cs", "path": "kod/1793282404714-p7q4c7/Program.cs" }
  ],
  "createdAt": 1788459348681
}
```

- `name`: putanja koju čitalac vidi (npr. `Models/Student.cs`)
- `path`: stvarna putanja u repou, propuštena kroz `safePath()`
- Validan zapis: ima `title` i bar jedan fajl
- Nova sveska počinje prazna, pa **stari format** (`fileName` / `filePath` sa jednim fajlom) ne mora da postoji. Funkciju `codeFiles(e)` ipak zadrži, košta tri linije i štiti od ručno unetih zapisa.

Oba fajla mogu da ne postoje: 404 znači „nema zadataka“, ne grešku.

## 6. Funkcije

### 6.1 `common.js`

| Funkcija | Ponašanje |
|---|---|
| `esc(s)` | Escape-uje `& < > " '`. `null`/`undefined` postaju `""` |
| `fmtDate(ts)` | Datum u `sr-RS` formatu, `""` za neispravan timestamp |
| `mountGithubLink()` | Ubacuje GitHub ikonicu (link na `SITE.profileUrl`, `target="_blank" rel="noopener"`) kao prvi element u `.head-actions` |
| `loadIndex(path, isValid)` | `fetch(path + "?t=" + Date.now(), { cache: "no-store" })`. 404 vraća `[]`. Ne-niz baca grešku. Vraća validne zapise, **najnovije prvo** |
| `loadEntries()` | `loadIndex("entries.json", ...)` |
| `codeFiles(e)` | Vraća `e.files`, ili stari format kao niz od jednog fajla |
| `loadCode()` | `loadIndex("kod.json", ...)` |
| `plural(n, one, few, many)` | Srpska množina: 1 zadatak, 2 zadatka, 5 zadataka, 11 zadataka, 21 zadatak |

### 6.2 `index.html`: galerija slika

**Zaglavlje:** naslov „Sveska“ (ili „Aleksina sveska“), podnaslov, GitHub ikonica, linkovi „Prikaži zadatke“ (`zadaci.html`) i „Uredi zadatke“ (`upload.html`).

**Toolbar** (sakriven dok nema zadataka): brojač + polje za pretragu.

**Pretraga:** na svaki `input`, bez dugmeta. Ne razlikuje velika i mala slova. Traži u `title`, `subject` i `note`.

**Mreža kartica:** slika (`loading="lazy"`), naslov, oznaka predmeta, datum. Kartica je fokusabilna (`tabindex="0"`, `role="button"`) i otvara se klikom, `Enter` ili `Space`.

**Stanja:** „Učitavanje.“, „Nema još nijednog zadatka.“, „Nijedan zadatak ne odgovara pretrazi.“, „Ne mogu da učitam svesku. Osveži stranicu za koji trenutak.“

**Redosled:** najnovije prvo.

**Lightbox** (`role="dialog"`, `aria-modal="true"`):

- Gornja traka: naslov, predmet, datum, i alati: `−`, procenat zuma, `+`, „Uklopi“, „Original“ (otvara sliku u novom tabu), `×`.
- Ispod slike: napomena (samo ako postoji), pa kratko uputstvo za kontrole.
- Slika se uklapa u prostor i nikad ne uvećava iznad prirodne veličine na zumu 100%.
- Zum: od 1x do 8x, uvek oko tačke (kursor, centar štipanja, ili centar za dugmad).
  - točkić miša: korak 1.18
  - dugmad: korak 1.35
  - tastatura `+`/`=` i `-`/`_`: korak 1.3, `0` vraća na 100%
  - dupli klik: ako je zum veći od 1.05, vrati na 100%, inače zumiraj 2.6x na tački klika. Ne reaguje ako je pre toga bilo prevlačenje.
  - pinch sa dva prsta (Pointer Events)
- Pomeranje prevlačenjem (pointer capture). Pomeranje se ograničava: kad je slika manja od prostora, centrirana je. Kad je veća, ivica ne sme da uđe u prostor.
- `Escape` zatvara. Dok je otvoren, `body` ne skroluje. Na `resize` slika se ponovo uklapa. Pri otvaranju fokus ide na `×`. Pri zatvaranju se uklanjaju svi listeneri (`keydown`, `resize`).

### 6.3 `zadaci.html`: kod

**Zaglavlje:** naslov „Zadaci“, GitHub ikonica, link „Nazad na svesku“.

**Učitavanje:** `loadCode()`, pa **obrni redosled (najstarije prvo, redosled sa časa)**, pa paralelno učitaj sadržaj svih fajlova (`fetch(path + "?t=" + createdAt)`, `createdAt` služi kao verzija za keš). Fajl koji ne može da se učita dobija `code: null`.

**Toolbar:** brojač preko `plural()` + pretraga po naslovu, napomeni, imenima fajlova i **sadržaju koda**.

**Kartica zadatka:**

- Naslov, oznaka (ime fajla ako je jedan, „3 fajla“ ako ih je više), datum, napomena ako postoji.
- Tabovi (`role="tablist"`, `aria-selected`) samo kad ima više fajlova.
- Kod sa highlight.js. Jezik po ekstenziji ako ga hljs zna (`cs`, `py`, `cpp`...), inače `highlightAuto`. Ako hljs nije učitan, kod ide kao `textContent`.
- Dugmad:
  - **Kopiraj kod**: `navigator.clipboard.writeText` za aktivni tab
  - **Preuzmi fajl**: `<a download>` za aktivni tab
  - **Preuzmi sve (.zip)**: samo kad ima više fajlova. JSZip se učitava tek na prvi klik. ZIP sadrži folder nazvan po zadatku, ime arhive je naslov bez znakova `\ / : * ? " < > |`
- Povratna informacija stoji na samom dugmetu: „Kopirano“ / „Preuzeto“ / „Nije uspelo“, pa vraćanje natpisa posle 1.6 s. Dugme je onemogućeno dok akcija traje.
- Fajl koji se nije učitao: umesto koda poruka „Fajl nije dostupan…“, a „Kopiraj kod“ je onemogućeno.

### 6.4 `upload.html`: uređivanje

#### Prijava

- Forma sa `password` poljem za GitHub PAT.
- Provera: `GET SITE.apiBase` sa tokenom. Tek ako uspe, token se čuva u `localStorage`.
- Pri otvaranju stranice: ako token postoji, proveri ga. Ako više ne važi, obriši ga i prikaži „Prethodni token više ne važi. Unesi novi.“
- „Odjavi se sa ovog uređaja“ (uz `confirm`) briše token i osvežava stranicu.
- Token: **fine-grained**, samo repo `sveska`, dozvola *Contents: Read and write*. Ništa više.

Zaglavlja za svaki API poziv:

```
Authorization: Bearer <token>
Accept: application/vnd.github+json
X-GitHub-Api-Version: 2022-11-28
```

Poruke grešaka (`ghError`): 401 token istekao, 403 nema dozvolu ili limit, 404 repo nije nađen, 409/422 fajl je u međuvremenu promenjen, ostalo „GitHub greška N“ + prvih 160 znakova odgovora.

#### Novi zadatak sa kodom

Polja: naslov (opciono, podrazumevano ime foldera, pa ime jedinog fajla, pa „Zadatak“), napomena (opciono), izbor **foldera** (`webkitdirectory`) ili **fajlova**.

Filtriranje izbora (`readCodePick`):

- Uzimaju se samo ekstenzije: `cs vb fs c h cpp hpp cc java kt py js ts jsx tsx html css sql php go rs rb swift sh ps1`
- Preskaču se folderi: `bin obj Debug Release x64 packages Properties .vs .vscode .idea .git node_modules __pycache__ venv .venv`
- Najviše 30 fajlova i 500 KB ukupno. Fajl sa `\u0000` nije tekstualni i odbija se.
- `stripCommonDirs`: zajednički početni folderi se skidaju (`zadatak1/zadatak1/Program.cs` postaje `Program.cs`).
- Sortiranje: ulazna tačka prva (`program|main|index|app.<ext>`), ostalo abecedno.
- Ispod dugmadi: lista izabranih fajlova i poruka „N fajlova sa kodom, preskočeno ostalih: M“.

`safePath(name)`: po segmentu skida dijakritike (NFD), sve što nije `A-Za-z0-9._-` menja sa `-`, skida `-` i `.` sa početka, prazan segment postaje `fajl`.

**Snimanje mora biti jedan atomski commit** (Git Data API), da zadatak sa više fajlova nikad ne ostane napola snimljen:

1. `GET /git/ref/heads/main`, pa commit na vrhu, pa `kod.json` na tom commitu
2. `build(entries)` vraća nove zapise i listu fajlova (`content: null` znači brisanje)
3. `POST /git/trees` sa `base_tree`, pa `POST /git/commits` sa jednim roditeljem
4. `PATCH /git/refs/heads/main` **bez** `force`. Ako je u međuvremenu stigao drugi commit (409/422), ponovi od koraka 1, do 4 pokušaja, pauza `250 ms × pokušaj`

Commit poruka: `Dodaj zadatak sa kodom: <naslov>`.

#### Lista zadataka sa kodom

Čita `kod.json` preko API-ja (ne preko Pages, da se odmah vidi promena), najnovije prvo, brojač „Kod: N“. Svaki red ima naslov, oznaku, datum i dugme **Obriši** (uz `confirm`). Brisanje je jedan atomski commit koji uklanja zapis i sve njegove fajlove: `Ukloni zadatak sa kodom: <naslov>`.

#### Novi zadatak sa slikom

Polja: naslov (obavezan), predmet (opciono, podrazumevano „Opšte“), napomena (opciono), slika.

- Kompresija u browseru: najduža strana najviše 1400 px, JPEG kvalitet 0.75, bela pozadina (zbog PNG providnosti).
- Pregled sa dugmetom `×` za uklanjanje i porukom „Spremno, oko N KB.“
- Dugme za snimanje pokazuje spinner i fazu.
- Posle uspeha: forma se prazni, „Sačuvano.“ 4 sekunde, lista se osvežava.

#### Lista zadataka sa slikom

Mreža kartica sa dugmetom **Obriši** na svakoj, plus „Osveži listu“. Brisanje uklanja zapis i sliku.

## 7. Dizajn: šta je slobodno, a šta nije

### Ne sme da se menja

- ID-jevi elemenata koje JS koristi i `data-*` atributi (`data-i`, `data-act`, `data-tab`, `data-id`). Ako ih preimenuješ, preimenuj dosledno u HTML-u i JS-u.
- Pristupačnost: fokusabilne kartice, `aria-label` na dugmadima sa ikonicom, `role="dialog"`, vidljiv fokus (`:focus-visible`).
- Radi na telefonu od 360 px širine bez horizontalnog skrola. Lightbox i pinch moraju raditi na dodir.
- Kontrast teksta najmanje 4.5:1.

### Treba da se menja (cilj: da se odmah vidi da je druga sveska)

Original je mirna, „papirna“ neutralna tema: topla bela (`#faf9f7`), skoro crn tekst, sistemski font, širina 860 px, tanke ivice i blage senke. Aleksina treba da ima **svoj karakter**. Izaberi jedan pravac i drži ga se do kraja:

- **Boja:** izaberi jedan akcenat (npr. tamnoplava, zelena, ljubičasta) i koristi ga za linkove, primarna dugmad, oznaku predmeta i aktivan tab. Ne dodaj tri akcenta.
- **Tipografija:** jedan font za naslove sa Google Fonts (npr. Space Grotesk ili Fraunces) i jedan za tekst. Za kod monospace (JetBrains Mono ili sistemski).
- **Tema za kod:** druga highlight.js tema (npr. `atom-one-dark` ili `github-dark`), usklađena sa ostatkom.
- **Kartice:** drugačiji oblik (veći radijus, ili oštre ivice sa debljim okvirom), drugačiji raspored meta podataka.
- **Tamni režim:** original ga nema. Ovde ga dodaj preko `prefers-color-scheme: dark`, uz istu listu tokena.

Sve boje definiši kao CSS promenljive na `:root`, pa ih redefiniši za tamni režim. Nijedna boja ne sme biti ukucana direktno u pravilu.

## 8. Šta original radi loše: popravi u novoj verziji

Ovo nije opciono. Kopiranje bagova nije „ista funkcionalnost“.

1. **Brojač u `index.html` i `upload.html` je pogrešan za 2 do 4.** Kod `entries.length === 1 ? "1 zadatak" : n + " zadataka"` daje „2 zadataka“. `plural()` već postoji u `common.js`, koristi ga svuda.
2. **Upload slike nije atomski.** Original šalje sliku jednim commitom, pa `entries.json` drugim, i pokušava da obriše sliku ako drugi korak padne. Brisanje isto radi u dva koraka. Za kod već postoji `commitCodeChanges`. Uopšti ga u `commitChanges(indexPath, build, message)` i koristi ga za **oba** tipa zadataka. Slika ide u tree kao blob (`POST /git/blobs` sa `encoding: "base64"`, pa `sha` u tree). Rezultat: jedan commit, nema siročadi, briše se pola koda (`updateJsonFile`, `putFile`, `deleteFile`, `deleteRepoFile`).
3. **Dupliran kod za listu u `upload.html`.** `refreshList` i `refreshCodeList` rade isto (učitaj, filtriraj, sortiraj, prikaži stanja). Napravi jednu funkciju koja prima renderer reda.
4. **Inline stilovi** (`style="margin-top:28px"`, `style="min-width:0"`): prebaci u klase.
5. **Nedosledan redosled:** galerija je najnovije prvo, kod najstarije prvo. Ako Aleksa ne želi drugačije, odluči jednom i napiši zašto u komentaru, ili dodaj prekidač za sortiranje.

## 9. Postavljanje

1. Aleksa napravi javni repo `sveska` na svom nalogu.
2. Kopiraj strukturu iz dela 3, sa praznim `entries.json` i `kod.json` (`[]`) i praznim folderima (`images/.gitkeep`, `kod/.gitkeep`).
3. U `config.js` upiši Aleksin username.
4. *Settings → Pages → Deploy from branch → `main` / root.*
5. Napravi fine-grained token (samo taj repo, *Contents: Read and write*, rok trajanja do kraja školske godine).
6. Popuni `sveska-link.md` sa `https://<username>.github.io/sveska/` i `.../upload.html`.

## 10. Provera pre predaje

- [ ] Prazan repo: sve tri stranice prikazuju poruku „nema zadataka“, ne grešku
- [ ] Dodaj sliku: pojavljuje se u galeriji posle par minuta (Pages build), odmah u listi na `upload.html`
- [ ] U istoriji commitova: **jedan** commit po dodavanju i po brisanju, za oba tipa
- [ ] Dodaj ceo Visual Studio folder: ulaze samo `.cs` fajlovi, `bin/` i `obj/` su preskočeni, imena bez `zadatak1/zadatak1/`
- [ ] Zadatak sa 3 fajla: tabovi rade, kopiranje i preuzimanje važe za aktivni tab, ZIP sadrži sva tri
- [ ] Pretraga na `zadaci.html` nalazi reč koja postoji samo u kodu
- [ ] Brojač: 1 zadatak, 2 zadatka, 5 zadataka, 21 zadatak
- [ ] Lightbox: zum točkićem, duplim klikom, tasterima i pinch-om na telefonu, Escape zatvara
- [ ] Naslov sa `<script>` se prikazuje kao tekst
- [ ] Pogrešan token: jasna poruka, ništa se ne čuva
- [ ] 360 px širine: nema horizontalnog skrola
- [ ] Svetli i tamni režim su čitljivi
