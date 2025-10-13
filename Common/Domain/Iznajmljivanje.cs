using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Iznajmljivanje : IEntity
    {
        public int Id { get; set; }
        public decimal UkupanIznos { get; set; }
        public DateTime VremeOd { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public Osoba Osoba { get; set; }
        public List<StavkaIznajmljivanja> Stavke { get; set; } = new List<StavkaIznajmljivanja>();


        public string TableName => "Iznajmljivanje";

        public string Values => $"{UkupanIznos.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{VremeOd:yyyy-MM-dd HH:mm:ss}', {(Zaposleni?.Id ?? 0)}, {(Osoba?.Id ?? 0)}";
        public List<string> JoinTableNames => new List<string> { "Osoba", "Zaposleni" };
        public List<string> JoinColumnNames => null;
        public List<string> JoinConditions => new List<string>
        {
            "Iznajmljivanje.idOsoba = Osoba.idOsoba",
            "Iznajmljivanje.idZaposleni = Zaposleni.idZaposleni"
        };
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> iznajmljivanja = new List<IEntity>();
            while (reader.Read())
            {
                Iznajmljivanje i = new Iznajmljivanje
                {
                    Id = (int)reader["idIznajmljivanje"],
                    UkupanIznos = (decimal)reader["ukupanIznos"],
                    VremeOd = (DateTime)reader["vremeOd"],
                    Zaposleni = new Zaposleni
                    {
                        Id = (int)reader["idZaposleni"],
                        KorisnickoIme = (string)reader["korisnickoIme"]
                    },
                    Osoba = new Osoba
                    {
                        Id = (int)reader["idOsoba"],
                        Email = (string)reader["email"]
                    }
                };
                iznajmljivanja.Add(i);
            }
            return iznajmljivanja;
        }
    }
}
