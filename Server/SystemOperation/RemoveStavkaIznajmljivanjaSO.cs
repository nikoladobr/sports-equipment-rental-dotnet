using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class RemoveStavkaIznajmljivanjaSO : SystemOperationBase
    {
        private readonly StavkaIznajmljivanja s;

        public RemoveStavkaIznajmljivanjaSO(StavkaIznajmljivanja s)
        {
            this.s = s;
        }

        protected override void ExecuteConcreteOperation()
        {
            // 1) Delete po kompozitnom ključu
            broker.Remove(
                s,
                $"idIznajmljivanje = {s.IdIznajmljivanje} AND rb = {s.Rb}"
            );

            // 2) Re-kalkuliši ukupan iznos glave
            broker.Update(
                new Iznajmljivanje(),
                $"ukupanIznos = (SELECT COALESCE(SUM(iznos), 0) FROM StavkaIznajmljivanja WHERE idIznajmljivanje = {s.IdIznajmljivanje})",
                $"idIznajmljivanje = {s.IdIznajmljivanje}"
            );
        }
    }
}
