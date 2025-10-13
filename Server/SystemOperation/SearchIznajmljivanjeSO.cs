using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class SearchIznajmljivanjeSO : SystemOperationBase
    {
        private readonly Iznajmljivanje i;
        public List<Iznajmljivanje> Result { get; private set; }

        public SearchIznajmljivanjeSO(Iznajmljivanje i)
        {
            this.i = i ?? new Iznajmljivanje();
        }

        protected override void ExecuteConcreteOperation()
        {
            var cond = new List<string>();

            if (i.Id > 0)
                cond.Add($"idIznajmljivanje = {i.Id}");

            if (i.Zaposleni != null && i.Zaposleni.Id > 0)
                cond.Add($"idZaposleni = {i.Zaposleni.Id}");

            if (i.Osoba != null && i.Osoba.Id > 0)
                cond.Add($"idOsoba = {i.Osoba.Id}");

            // Oprema
            var opremaId = i.Stavke?.FirstOrDefault()?.Oprema?.Id ?? 0;
            if (opremaId > 0)
                cond.Add($@"EXISTS (
                    SELECT 1 FROM StavkaIznajmljivanja s
                    WHERE s.idIznajmljivanje = Iznajmljivanje.idIznajmljivanje
                      AND s.idOprema = {opremaId}
                )");

            if (cond.Count == 0) throw new Exception("Унесите бар један критеријум.");

            string condition = string.Join(" AND ", cond);

            var list = broker.GetByCondition(new Iznajmljivanje(), condition);
            Result = list.Cast<Iznajmljivanje>().ToList();
        }
    }
}
