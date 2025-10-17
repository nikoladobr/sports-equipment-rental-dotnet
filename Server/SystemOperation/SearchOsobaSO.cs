using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class SearchOsobaSO : SystemOperationBase
    {
        private readonly Osoba kriterijum;
        public List<Osoba> Result { get; private set; }

        public SearchOsobaSO(Osoba o)
        {
            kriterijum = o;
        }

        protected override void ExecuteConcreteOperation()
        {
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(kriterijum.Ime))
                parts.Add($"Osoba.ime LIKE '%{kriterijum.Ime}%'");

            if (!string.IsNullOrWhiteSpace(kriterijum.Prezime))
                parts.Add($"Osoba.prezime LIKE '%{kriterijum.Prezime}%'");

            if (!string.IsNullOrWhiteSpace(kriterijum.Email))
                parts.Add($"Osoba.email LIKE '%{kriterijum.Email}%'");

            if (kriterijum.KategorijaOsobe != null && kriterijum.KategorijaOsobe.Id > 0)
                parts.Add($"Osoba.idKategorijaOsobe = {kriterijum.KategorijaOsobe.Id}");

            var condition = parts.Count > 0 ? string.Join(" AND ", parts) : "1=1";

            var list = broker.GetByCondition(new Osoba(), condition);
            Result = list.Cast<Osoba>().ToList();
        }
    }
}
