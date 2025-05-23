﻿using Domen;
using System.Data.SqlClient;
using System.Text;

namespace BrokerBP
{
    public class Broker
    {
        SqlConnection conn;
        public Broker()
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SportOpremaRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void OpenConn()
        {
            conn.Open();
        }
        public void CloseConn()
        {
            conn?.Close();
        }

        public List<TerminDezurstva> VratiListuSviTerminDezurstva()
        {
            List<TerminDezurstva> result = new();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from TerminDežurstva";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TerminDezurstva t = new();
                        t.IdTerminDezurstva = (int)reader["idTerminDezurstva"];
                        t.Smena = (int)reader["smena"];
                        result.Add(t);

                    }
                    return result;
                }
            }
        }

        public bool KreirajZaposleni(Zaposleni z)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Zaposleni (ime, prezime, korisnickoIme, sifra) " +
                                  "VALUES (@ime, @prezime, @korisnickoIme, @sifra)";
                cmd.Parameters.AddWithValue("@ime", z.Ime);
                cmd.Parameters.AddWithValue("@prezime", z.Prezime);
                cmd.Parameters.AddWithValue("@korisnickoIme", z.KorisnickoIme);
                cmd.Parameters.AddWithValue("@sifra", z.Sifra);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool PostojiKorisnickoIme(string korisnickoIme)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Zaposleni WHERE korisnickoIme = @korisnickoIme";
                cmd.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public Zaposleni PrijaviZaposleni(string korisnickoIme, string sifra)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Zaposleni WHERE korisnickoIme = @korisnickoIme AND sifra = @sifra";
                cmd.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                cmd.Parameters.AddWithValue("@sifra", sifra);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Zaposleni
                        {
                            IdZaposleni = (int)reader["idZaposleni"],
                            Ime = reader["ime"].ToString(),
                            Prezime = reader["prezime"].ToString(),
                            KorisnickoIme = reader["korisnickoIme"].ToString(),
                            Sifra = reader["sifra"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public List<KategorijaOsobe> VratiListuSviKategorijaOsobe()
        {
            List<KategorijaOsobe> result = new();
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from KategorijaOsobe";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KategorijaOsobe k = new();
                        k.IdKategorijaOsobe = (int)reader["idKategorijaOsobe"];
                        k.Naziv = reader["naziv"].ToString();
                        result.Add(k);
                    }
                    return result;
                }
            }           
        }

        public void KreirajOsobu(Osoba osoba)
        {
            using(SqlCommand cmd = conn.CreateCommand())
            {                
                    cmd.CommandText = "INSERT INTO Osoba (ime, prezime, email, idKategorijaOsobe) VALUES (@ime, @prezime, @email, @idKategorijaOsobe)";
                   
                    cmd.Parameters.AddWithValue("@ime", osoba.Ime);
                    cmd.Parameters.AddWithValue("@prezime", osoba.Prezime);
                    cmd.Parameters.AddWithValue("@email", osoba.Email);
                    cmd.Parameters.AddWithValue("@idKategorijaOsobe", osoba.Kategorija.IdKategorijaOsobe);

                    cmd.ExecuteNonQuery();                
            }
        }

        public List<Osoba> PretraziOsobe(Osoba osoba)
        {
            List<Osoba> rezultat = new();

            // Osiguranje da polja ne budu null
            osoba.Ime = osoba.Ime ?? "";
            osoba.Prezime = osoba.Prezime ?? "";
            osoba.Email = osoba.Email ?? "";
            osoba.Kategorija ??= new KategorijaOsobe { IdKategorijaOsobe = -1 };

            // Priprema parametara sa %
            string ime = osoba.Ime == "" ? "" : $"%{osoba.Ime}%";
            string prezime = osoba.Prezime == "" ? "" : $"%{osoba.Prezime}%";
            string email = osoba.Email == "" ? "" : $"%{osoba.Email}%";
            int katId = osoba.Kategorija.IdKategorijaOsobe;

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT * FROM Osoba 
            WHERE (@ime = '' OR ime LIKE @ime) 
              AND (@prezime = '' OR prezime LIKE @prezime) 
              AND (@email = '' OR email LIKE @email) 
              AND (@idKategorijaOsobe = -1 OR idKategorijaOsobe = @idKategorijaOsobe)";

                cmd.Parameters.AddWithValue("@ime", ime);
                cmd.Parameters.AddWithValue("@prezime", prezime);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@idKategorijaOsobe", katId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Osoba o = new Osoba
                        {
                            IdOsoba = reader["idOsoba"] != DBNull.Value ? (int)reader["idOsoba"] : 0,
                            Ime = reader["ime"] != DBNull.Value ? (string)reader["ime"] : "",
                            Prezime = reader["prezime"] != DBNull.Value ? (string)reader["prezime"] : "",
                            Email = reader["email"] != DBNull.Value ? (string)reader["email"] : "",
                            Kategorija = new KategorijaOsobe
                            {
                                IdKategorijaOsobe = reader["idKategorijaOsobe"] != DBNull.Value
                                    ? (int)reader["idKategorijaOsobe"]
                                    : -1
                            }
                        };

                        rezultat.Add(o);
                    }
                }
            }

            return rezultat;
        }

        public List<Osoba> VratiListuSviOsobe()
        {
            List<Osoba> result = new();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT o.idOsoba, o.ime, o.prezime, o.email,
                   ko.idKategorijaOsobe, ko.naziv AS nazivKategorije
            FROM Osoba o
            INNER JOIN KategorijaOsobe ko ON o.idKategorijaOsobe = ko.idKategorijaOsobe";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Osoba o = new Osoba
                        {
                            IdOsoba = (int)reader["idOsoba"],
                            Ime = reader["ime"].ToString(),
                            Prezime = reader["prezime"].ToString(),
                            Email = reader["email"].ToString(),
                            Kategorija = new KategorijaOsobe
                            {
                                IdKategorijaOsobe = (int)reader["idKategorijaOsobe"],
                                Naziv = reader["nazivKategorije"].ToString()
                            }
                        };

                        result.Add(o);
                    }
                    return result;
                }
            }
        }


        public bool ObrisiOsoba(Osoba o)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Osoba WHERE idOsoba = @id";
                cmd.Parameters.AddWithValue("@id", o.IdOsoba);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public void PromeniOsoba(Osoba osoba)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Osoba 
                            SET ime = @ime, prezime = @prezime, email = @email, idKategorijaOsobe = @idKat 
                            WHERE idOsoba = @id";
                cmd.Parameters.AddWithValue("@ime", osoba.Ime);
                cmd.Parameters.AddWithValue("@prezime", osoba.Prezime);
                cmd.Parameters.AddWithValue("@email", osoba.Email);
                cmd.Parameters.AddWithValue("@idKat", osoba.Kategorija.IdKategorijaOsobe);
                cmd.Parameters.AddWithValue("@id", osoba.IdOsoba);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Zaposleni> VratiListuSviZaposleni()
        {
            List<Zaposleni> result = new();
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from Zaposleni";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Zaposleni z = new();
                        z.Ime = reader["ime"].ToString();
                        z.Prezime = reader["prezime"].ToString();
                        z.IdZaposleni = (int)reader["idZaposleni"];
                        z.KorisnickoIme = reader["korisnickoIme"].ToString();
                        result.Add(z);
                    }
                    return result;
                }
            }
        }

        public List<Zaposleni> PretraziZaposlene(Zaposleni zaposleni, List<TerminDezurstva> izabraneSmene)
        {
            List<Zaposleni> rezultat = new List<Zaposleni>();

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText =
                    "SELECT DISTINCT z.* " +
                    "FROM Zaposleni z " +
                    "LEFT JOIN Zaposleni_TerminDežurstva ztd ON z.idZaposleni = ztd.idZaposleni " +
                    "LEFT JOIN TerminDežurstva td ON ztd.idTerminDezurstva = td.idTerminDezurstva " +
                    "WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(zaposleni.Ime))
                {
                    cmd.CommandText += " AND z.ime LIKE @ime";
                    cmd.Parameters.AddWithValue("@ime", "%" + zaposleni.Ime + "%");
                }

                if (!string.IsNullOrWhiteSpace(zaposleni.Prezime))
                {
                    cmd.CommandText += " AND z.prezime LIKE @prezime";
                    cmd.Parameters.AddWithValue("@prezime", "%" + zaposleni.Prezime + "%");
                }

                if (!string.IsNullOrWhiteSpace(zaposleni.KorisnickoIme))
                {
                    cmd.CommandText += " AND z.korisnickoIme LIKE @korime";
                    cmd.Parameters.AddWithValue("@korime", "%" + zaposleni.KorisnickoIme + "%");
                }

                if (izabraneSmene != null && izabraneSmene.Count > 0)
                {
                    cmd.CommandText += " AND td.idTerminDezurstva IN (";

                    for (int i = 0; i < izabraneSmene.Count; i++)
                    {
                        string paramName = "@smena" + i;
                        if (i > 0) cmd.CommandText += ", ";
                        cmd.CommandText += paramName;
                        cmd.Parameters.AddWithValue(paramName, izabraneSmene[i].IdTerminDezurstva);
                    }

                    cmd.CommandText += ")";
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Zaposleni z = new Zaposleni
                        {
                            IdZaposleni = (int)reader["idZaposleni"],
                            Ime = reader["ime"].ToString(),
                            Prezime = reader["prezime"].ToString(),
                            KorisnickoIme = reader["korisnickoIme"].ToString(),
                            Sifra = reader["sifra"].ToString()
                        };

                        rezultat.Add(z);
                    }
                }
            }

            return rezultat;
        }

        public int VratiIdZaposlenogPoKorisnickomImenu(string korisnickoIme)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT idZaposleni FROM Zaposleni WHERE korisnickoIme = @korime";
                cmd.Parameters.AddWithValue("@korime", korisnickoIme);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UbaciZaposleniTermin(ZaposleniTerminDezurstva ztd)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Zaposleni_TerminDežurstva " +
                                  "(idZaposleni, idTerminDezurstva, datumDezurstva) " +
                                  "VALUES (@idZap, @idTermin, @datum)";
                cmd.Parameters.AddWithValue("@idZap", ztd.IdZaposleni);
                cmd.Parameters.AddWithValue("@idTermin", ztd.IdTerminDezurstva);
                cmd.Parameters.AddWithValue("@datum", ztd.DatumDezurstva);

                cmd.ExecuteNonQuery();
            }
        }
    }
}