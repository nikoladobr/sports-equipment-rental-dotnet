using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Osoba : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public KategorijaOsobe KategorijaOsobe { get; set; }

        

        public int KategorijaId => KategorijaOsobe?.Id ?? 0;

        public string TableName => "Osoba";

        public string Values => $"'{Ime}', '{Prezime}', '{Email}', {(KategorijaOsobe?.Id.ToString() ?? "NULL")}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> osobe = new List<IEntity>();
            while (reader.Read())
            {
                Osoba o = new Osoba
                {
                    Id = (int)reader["idOsoba"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Email = (string)reader["email"],
                    KategorijaOsobe = new KategorijaOsobe
                    {
                        Id = (int)reader["idKategorijaOsobe"],
                    }
                };
                osobe.Add(o);
            }
            return osobe;
        }
    }
}
