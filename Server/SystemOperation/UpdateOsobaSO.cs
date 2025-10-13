using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UpdateOsobaSO : SystemOperationBase
    {

        private readonly Osoba o;
        public UpdateOsobaSO(Osoba o) { this.o = o; }

        protected override void ExecuteConcreteOperation()
        {
            
            string set = $"ime = '{o.Ime}', prezime = '{o.Prezime}', email = '{o.Email}', idKategorijaOsobe = {(o.KategorijaOsobe?.Id.ToString() ?? "NULL")}";

            string condition = $"idOsoba = {o.Id}";

            broker.Update(o, set, condition);
        }
    }
}
