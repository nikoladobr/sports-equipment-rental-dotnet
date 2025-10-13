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
        public string ImeZ { get; set; }
        public string PrezimeZ { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        public override string ToString()
        {
            return $"{KorisnickoIme}";
        }
        public string TableName => "Zaposleni";

        public string Values => $"'{ImeZ}', '{PrezimeZ}', '{KorisnickoIme}', '{Sifra}'";

        public List<string> JoinConditions => new List<string>
        {
            "Zaposleni.idZaposleni=Iznajmljivanje.idZaposleni",
        };

        public List<string> JoinTableNames => null;

        public List<string> JoinColumnNames => null;

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> zaposleni = new List<IEntity>();
            while (reader.Read())
            {
                Zaposleni z = new Zaposleni
                {
                    Id = (int)reader["idZaposleni"],
                    ImeZ = (string)reader["imeZ"],
                    PrezimeZ = (string)reader["prezimeZ"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"]
                };
                zaposleni.Add(z);
            }
            return zaposleni;
        }
    }
}
