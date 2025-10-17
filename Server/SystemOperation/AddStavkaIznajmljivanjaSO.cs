using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class AddStavkaIznajmljivanjaSO : SystemOperationBase
    {
        private readonly StavkaIznajmljivanja s;

        public AddStavkaIznajmljivanjaSO(StavkaIznajmljivanja s)
        {
            this.s = s;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (s.IdIznajmljivanje <= 0 && s.Iznajmljivanje != null)
                s.IdIznajmljivanje = s.Iznajmljivanje.Id;

            // nadji sledeci rb
            var last = broker.GetByCondition(
                new StavkaIznajmljivanja(),
                $"StavkaIznajmljivanja.idIznajmljivanje = {s.IdIznajmljivanje} ORDER BY rb DESC");

            s.Rb = last.Count == 0 ? 1 : ((StavkaIznajmljivanja)last[0]).Rb + 1;

            if (s.IdIznajmljivanje <= 0 && s.Iznajmljivanje != null)
                s.IdIznajmljivanje = s.Iznajmljivanje.Id;

            if (s.IdIznajmljivanje <= 0)
            {
                throw new Exception("ID iznajmljivanja za novu stavku nije postavljen.");
            }

            broker.Add(s);

            broker.Update(
                new Iznajmljivanje(),
                $"ukupanIznos = (SELECT COALESCE(SUM(iznos),0) FROM StavkaIznajmljivanja WHERE idIznajmljivanje = {s.IdIznajmljivanje})",
                $"idIznajmljivanje = {s.IdIznajmljivanje}");
        }
    }
}
