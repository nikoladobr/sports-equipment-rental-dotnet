# Iznajmljivanje sportske opreme (.NET)

Ovaj projekat predstavlja **softverski sistem za iznajmljivanje sportske opreme** razvijen u **.NET okruženju** koristeći **WinForms** i **klijent-server arhitekturu**.

## 🚀 Funkcionalnosti

Implementirani slučajevi korišćenja:
- **Prijavi zaposleni** (login sistema)
- **Kreiraj osoba** (dodavanje nove osobe)
- **Promeni osoba** (izmena postojećih podataka)
- **Pretraži osoba** (pretraga po kriterijumima)
- **Obriši osoba** (brisanje osobe iz sistema)

## 🏗️ Arhitektura

Projekat je podeljen na više slojeva:

- **Client** – klijentska WinForms aplikacija koju koriste zaposleni za rad sa sistemom.
- **Server** – serverska WinForms aplikacija koja obrađuje zahteve klijenata i komunicira sa bazom.
- **Common** – zajedničke klase (domen, komunikacija, request/response modeli).
- **DBBroker** – broker za pristup bazi podataka i izvršavanje SQL upita.

Komunikacija između klijenta i servera realizovana je pomoću **TCP socket-a** i prilagođenih `Request` / `Response` objekata.

## ⚙️ Tehnologije

- C# / .NET 8
- WinForms
- SQL Server (SSMS baza podataka)
- TCP Socket komunikacija
- DBBroker (Broker pattern) + System Operation (SO)
- System Operation pattern (SO)

## 📂 Struktura rešenja

- `Client/` – korisnički interfejs i kontroleri
- `Server/` – serverska aplikacija i sistemske operacije
- `Common/` – zajednički domen i komunikacione klase
- `DBBroker/` – broker za rad sa bazom

## Instalacija baze
1) Otvoriti `Database/create_database.sql` u SQL Server Management Studio (SSMS).
2) Kliknuti **Execute** – skripta će napraviti bazu `Projekat` i ubaciti početne podatke.
3) Login u aplikaciji:
   - korisničko ime: `admin`
   - šifra: `Admin1234`

## ▶️ Pokretanje

1. Pokrenuti **Server** aplikaciju (`FrmServer`).
2. Pokrenuti **Client** aplikaciju (`FrmLogin`).
3. Ulogovati se sa default nalogom:
   - Korisničko ime: `admin`
   - Lozinka: `Admin1234`

## 📌 Napomena

Ovaj projekat je izrađen kao akademski rad iz predmeta *Projektovanje softvera*. Glavni cilj je prikaz arhitekture i implementacije osnovnih funkcionalnosti sistema za iznajmljivanje sportske opreme.