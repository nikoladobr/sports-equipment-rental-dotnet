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

        public string Values =>
    $"{((Iznajmljivanje != null && Iznajmljivanje.Id > 0) ? Iznajmljivanje.Id : IdIznajmljivanje)}, " +
    $"{Rb}, " +
    $"{Cena.ToString(CultureInfo.InvariantCulture)}, " +
    $"'{VremeDo:yyyy-MM-dd HH:mm:ss}', " +
    $"{Trajanje}, " +
    $"{Iznos.ToString(CultureInfo.InvariantCulture)}, " +
    $"{(Oprema?.Id ?? 0)}, " +
    $"{Kolicina}";
        public List<string> JoinTableNames => new List<string> { "Iznajmljivanje", "Oprema" };

        public List<string> JoinColumnNames => null;

        public List<string> JoinConditions => new List<string>
        {
            "StavkaIznajmljivanja.idIznajmljivanje = Iznajmljivanje.idIznajmljivanje",
            "StavkaIznajmljivanja.idOprema = Oprema.idOprema"
        };
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var stavke = new List<IEntity>();
            while (reader.Read())
            {
                var si = new StavkaIznajmljivanja
                {
                    Rb = (int)reader["rb"],
                    Trajanje = (int)reader["trajanje"],
                    Cena = (decimal)reader["cena"],
                    Kolicina = (int)reader["kolicina"],
                    Iznos = (decimal)reader["iznos"],
                    VremeDo = (DateTime)reader["vremeDo"],
                    Iznajmljivanje = new Iznajmljivanje
                    {
                        Id = (int)reader["idIznajmljivanje"]
                    },
                    Oprema = new Oprema
                    {
                        Id = (int)reader["idOprema"],
                        NazivO = (string)reader["nazivO"]
                    }
                };

                stavke.Add(si);
            }
            return stavke;
        }
    }
}
