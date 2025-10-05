using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Iznajmljivanje : IEntity
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public double UkupanIznos { get; set; }
        public DateTime VremeOd { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public Osoba Osoba { get; set; }


        public string TableName => "Iznajmljivanje";

        public string Values => $"'{Opis}', '{UkupanIznos}', '{VremeOd}', {Zaposleni.Id}, {Osoba.Id}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> iznajmljivanja = new List<IEntity>();
            while (reader.Read())
            {
                Iznajmljivanje i = new Iznajmljivanje
                {
                    Id = (int)reader["id"],
                    Opis = (string)reader["opis"],
                    UkupanIznos = (double)reader["ukupanIznos"],
                    VremeOd = (DateTime)reader["vremeOd"],
                    Zaposleni = new Zaposleni
                    {
                        Id = (int)reader["id"],
                        Ime = (string)reader["ime"],
                        Prezime = (string)reader["prezime"],
                        KorisnickoIme = (string)reader["korisnickoIme"],
                        Sifra = (string)reader["sifra"]
                    },
                    Osoba = new Osoba
                    {
                        Id = (int)reader["id"],
                        Ime  = (string)reader["ime"],
                        Prezime = (string)reader["prezime"],
                        Email = (string)reader["email"],
                        KategorijaOsobe = new KategorijaOsobe
                        {
                            Id = (int)reader["id"],
                            Naziv = (string)reader["naziv"]
                        }
                    }
                };
                iznajmljivanja.Add(i);
            }
            return iznajmljivanja;
        }
    }
}
