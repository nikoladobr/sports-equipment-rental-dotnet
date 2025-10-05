using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class TerminDezurstva : IEntity
    {
        public int Id { get; set; }
        public int Smena { get; set; }



        public string TableName => "TerminDezurstva";

        public string Values => $"'{Smena}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> termini = new List<IEntity>();
            while (reader.Read())
            {
                TerminDezurstva td = new TerminDezurstva
                {
                    Id = (int)reader["id"],
                    Smena = (int)reader["smena"]
                };
                termini.Add(td);
            }
            return termini;
        }
    }
}
