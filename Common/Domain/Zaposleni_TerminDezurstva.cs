using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Zaposleni_TerminDezurstva : IEntity
    {
        public Zaposleni Zaposleni { get; set; }
        public TerminDezurstva TerminDezurstva { get; set; }
        public DateOnly DatumDezurstva { get; set; }


        public string TableName => "Zaposleni_TerminDezurstva";

        public string Values => $"{Zaposleni.Id}, {TerminDezurstva.Id}, '{DatumDezurstva}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> zaposlenitermini = new List<IEntity>();
            while (reader.Read())
            {
                Zaposleni_TerminDezurstva zt = new Zaposleni_TerminDezurstva
                {
                    Zaposleni = new Zaposleni
                    {
                        Id = (int)reader["id"],
                        Ime = (string)reader["ime"],
                        Prezime = (string)reader["prezime"],
                        KorisnickoIme = (string)reader["korisnickoIme"],
                        Sifra = (string)reader["sifra"]
                    },
                    TerminDezurstva = new TerminDezurstva
                    {
                        Id = (int)reader["id"],
                        Smena = (int)reader["smena"]
                    },
                    DatumDezurstva = (DateOnly)reader["datumDezurstva"]
                };
                zaposlenitermini.Add(zt);
            }
            return zaposlenitermini;
        }
    }
}
