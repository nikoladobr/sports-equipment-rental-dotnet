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
        public decimal Cena { get; set; }

        public string TableName => "Oprema";

        public string Values => $"'{Naziv}', '{Cena}'";

        public override string? ToString()
        {
            return Naziv;
        }


        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> opreme = new List<IEntity>();
            while (reader.Read())
            {
                Oprema o = new Oprema
                {
                    Id = (int)reader["idOprema"],
                    Naziv = (string)reader["naziv"],
                    Cena = (decimal)reader["cena"]
                };
                opreme.Add(o);
            }
            return opreme;
        }
    }
}
