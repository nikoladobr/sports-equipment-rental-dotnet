using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class StavkaIznajmljivanja : IEntity
    {
        public int Id { get; set; }
        public int Rb { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }
        public DateTime VremeDo { get; set; }
        public int Trajanje { get; set; }
        public double Iznos { get; set; }
        public Oprema Oprema { get; set; }





        public string TableName => "StavkaIznajmljivanja";

        public string Values => $"'{Rb}', '{Naziv}', '{Kolicina}', '{Cena}', '{VremeDo}', '{Trajanje}', '{Iznos}', {Oprema.Id}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> stavke = new List<IEntity>();
            while (reader.Read())
            {
                StavkaIznajmljivanja si = new StavkaIznajmljivanja
                {
                    Id = (int)reader["id"],
                    Rb = (int)reader["rb"],
                    Naziv = (string)reader["naziv"],
                    Kolicina = (int)reader["kolicina"],
                    Cena = (double)reader["cena"],
                    VremeDo = (DateTime)reader["vremeDo"],
                    Trajanje = (int)reader["trajanje"],
                    Iznos = (double)reader["iznos"],
                    Oprema = new Oprema
                    {
                        Id = (int)reader["id"],
                        Naziv = (string)reader["naziv"],
                        Cena = (double)reader["cena"]
                    }
                };
                stavke.Add(si);
            }
            return stavke;
        }
    }
}
