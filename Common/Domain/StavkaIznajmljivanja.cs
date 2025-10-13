using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class StavkaIznajmljivanja : IEntity
    {
        public int Rb { get; set; }
        public int IdIznajmljivanje { get; set; }

        public int Kolicina { get; set; }
        public decimal Cena { get; set; }
        public DateTime VremeDo { get; set; }
        public int Trajanje { get; set; }
        public decimal Iznos { get; set; }
        public Oprema Oprema { get; set; }

        [JsonIgnore]
        public Iznajmljivanje Iznajmljivanje { get; set; }

        public string TableName => "StavkaIznajmljivanja";

        public string Values => $"{IdIznajmljivanje}, {Rb}, {Cena.ToString(CultureInfo.InvariantCulture)}, '{VremeDo:yyyy-MM-dd HH:mm:ss}', {Trajanje}, {Iznos.ToString(CultureInfo.InvariantCulture)}, " +
            $"{Oprema.Id}, {Kolicina}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var stavke = new List<IEntity>();
            while (reader.Read())
            {
                int idIz = (int)reader["idIznajmljivanje"];

                var si = new StavkaIznajmljivanja
                {
                    IdIznajmljivanje = idIz,
                    Iznajmljivanje = new Iznajmljivanje { Id = idIz },

                    Rb = (int)reader["rb"],
                    Kolicina = (int)reader["kolicina"],
                    Cena = (decimal)reader["cena"],
                    VremeDo = (DateTime)reader["vremeDo"],
                    Trajanje = (int)reader["trajanje"],
                    Iznos = (decimal)reader["iznos"],
                    Oprema = new Oprema { Id = (int)reader["idOprema"] }
                };

                stavke.Add(si);
            }
            return stavke;
        }
    }
}
