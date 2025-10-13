using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class SearchOsobaSO : SystemOperationBase
    {
        private readonly Osoba o;
        public List<Osoba> Result { get; private set; }

        public SearchOsobaSO(Osoba o) 
        {
            this.o = o;
        }
        protected override void ExecuteConcreteOperation()
        {
            var cond = new List<string>();

            if (!string.IsNullOrWhiteSpace(o.Ime))
                cond.Add($"ime LIKE '{o.Ime}'");

            if (!string.IsNullOrWhiteSpace(o.Prezime))
                cond.Add($"prezime LIKE '{o.Prezime}'");

            if (!string.IsNullOrWhiteSpace(o.Email))
                cond.Add($"email LIKE '{o.Email}'");

            if (o.KategorijaOsobe != null && o.KategorijaOsobe.Id > 0)
                cond.Add($"idKategorijaOsobe = {o.KategorijaOsobe.Id}");

            if (cond.Count == 0) throw new Exception("Унесите бар један критеријум.");

            string condition = cond.Count > 0 ? string.Join(" AND ", cond) : "1=1";

            var list = broker.GetByCondition(o, condition);
            Result = list.Cast<Osoba>().ToList();
        }
    }
}
