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
        public string Naziv { get; set; }
        public double Cena { get; set; }

        public string TableName => "Oprema";

        public string Values => $"'{Naziv}', '{Cena}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> opreme = new List<IEntity>();
            while (reader.Read())
            {
                Oprema o = new Oprema
                {
                    Id = (int)reader["id"],
                    Naziv = (string)reader["naziv"],
                    Cena = (double)reader["cena"]
                };
                opreme.Add(o);
            }
            return opreme;
        }
    }
}
