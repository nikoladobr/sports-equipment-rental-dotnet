using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class KategorijaOsobe : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string TableName => "KategorijaOsobe";
        public string Values => $"'{Naziv}'";
        

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> kategorije = new List<IEntity>();
            while (reader.Read())
            {
                KategorijaOsobe ko = new KategorijaOsobe
                {
                    Id = (int)reader["idKategorijaOsobe"],
                    Naziv = (string)reader["naziv"]
                };
                kategorije.Add(ko);
            }
            return kategorije;
        }
    }
}
