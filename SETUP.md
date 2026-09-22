# Kako napraviti svoju kopiju sveske

Sveska je statičan sajt: `index.html` čita `entries.json` i slike iz `images/`,
a `upload.html` upisuje nove zadatke direktno preko GitHub API-ja, sa tokenom
koji ostaje u browseru. Nema servera i nema baze, pa je cela kopija zapravo nov
repozitorijum sa istim fajlovima.

Ništa se ne deli između dve sveske: svako ima svoj repo, svoj GitHub Pages sajt
i svoj token. **Token se nikada ne šalje drugome** — svako pravi svoj.

Kod ne sadrži korisničko ime. `config.js` čita vlasnika i repo iz adrese
(`https://<nalog>.github.io/<repo>/`), pa kopija radi bez ijedne izmene.

## 1. Preuzmi fajlove

Na stranici originalnog repozitorijuma: **Code → Download ZIP**, pa raspakuj.

Potrebno je tačno pet fajlova:

```
index.html
upload.html
style.css
config.js
common.js
```

Sve ostalo (`images/`, `entries.json`, `sveska-link.md`) je sadržaj tuđe
sveske i ne ide u kopiju.

## 2. Napravi repozitorijum

Na svom nalogu: **New repository**.

- Ime: `sveska`
- Vidljivost: **Public** (GitHub Pages na besplatnom nalogu traži javan repo)
- Bez README, bez .gitignore, bez licence

Zatim **Add file → Upload files**, prevuci onih pet fajlova i potvrdi commit.

## 3. Dodaj prazan `entries.json`

**Add file → Create new file**, ime `entries.json`, sadržaj:

```json
[]
```

Ovo je lista zadataka. Prazna lista znači prazna sveska. Folder `images/`
ne treba praviti ručno — nastaje sam pri prvom otpremanju slike.

## 4. Uključi GitHub Pages

**Settings → Pages → Build and deployment**

- Source: `Deploy from a branch`
- Branch: `main`, folder `/ (root)`

Za minut-dva sajt je na `https://<nalog>.github.io/sveska/`.

## 5. Napravi token

`upload.html` piše u repo, pa mu treba dozvola. Token ide na:

**github.com/settings/personal-access-tokens → Generate new token**

- Token name: `sveska`
- Expiration: 90 dana (posle isteka se pravi nov)
- Repository access: **Only select repositories** → `sveska`
- Repository permissions → **Contents: Read and write**

Ostale dozvole ostaju na `No access`. Token se prikazuje samo jednom.

## 6. Prvi zadatak

Otvori `https://<nalog>.github.io/sveska/upload.html`, nalepi token, sačuvaj
zadatak. Sveska se osvežava kad GitHub Pages objavi commit, obično za minut.

## Šta treba znati

- **Repo je javan.** Svako može da vidi slike zadataka. Ne slikaj ništa lično.
- **Token je lozinka za repo.** Ne šalje se porukom, ne stavlja se u kod, ne
  ostaje na tuđem računaru. Ako procuri: `Settings → Developer settings →
  Personal access tokens → Revoke`.
- **Token stoji u `localStorage`.** Sve stranice na `<nalog>.github.io` dele
  isti origin, pa bilo koji drugi sajt objavljen sa tog naloga može da ga
  pročita. Ne objavljuj tuđi kod na istom nalogu.
- **Zaboravljena odjava.** Na tuđem računaru obavezno `Odjavi se sa ovog
  uređaja` — dugme briše token iz browsera.

## Ako sajt stoji na custom domenu

Tada u adresi nema `<nalog>.github.io`, pa detekcija ne radi. U `config.js`
popuni:

```js
const OVERRIDE_OWNER = "nalog";
const OVERRIDE_REPO = "sveska";
```
