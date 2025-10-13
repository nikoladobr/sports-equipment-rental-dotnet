using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Oprema : IEntity
    {
        public int Id { get; set; }
        public string NazivO { get; set; }
        public decimal Cena { get; set; }

        public string TableName => "Oprema";

        public string Values => $"'{NazivO}', '{Cena}'";

        public List<string> JoinConditions => null;

        public List<string> JoinTableNames => null;

        public List<string> JoinColumnNames => null;

        public override string ToString()
        {
            return $"{NazivO}";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> opreme = new List<IEntity>();
            while (reader.Read())
            {
                Oprema o = new Oprema
                {
                    Id = (int)reader["idOprema"],
                    NazivO = (string)reader["nazivO"],
                    Cena = (decimal)reader["cena"]
                };
                opreme.Add(o);
            }
            return opreme;
        }
    }
}
