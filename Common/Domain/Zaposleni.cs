using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Zaposleni : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        public string TableName => "Zaposleni";

        public string Values => $"'{Ime}', '{Prezime}', '{KorisnickoIme}', '{Sifra}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> zaposleni = new List<IEntity>();
            while (reader.Read())
            {
                Zaposleni z = new Zaposleni
                {
                    Id = (int)reader["idZaposleni"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"]
                };
                zaposleni.Add(z);
            }
            return zaposleni;
        }
    }
}
