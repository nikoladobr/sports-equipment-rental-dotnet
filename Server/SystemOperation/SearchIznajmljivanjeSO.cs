using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class SearchIznajmljivanjeSO : SystemOperationBase
    {
        private readonly Iznajmljivanje krit;
        public List<Iznajmljivanje> Result { get; private set; } = new();

        public SearchIznajmljivanjeSO(Iznajmljivanje i)
        {
            krit = i ?? new Iznajmljivanje();
        }

        protected override void ExecuteConcreteOperation()
        {
            var cond = new List<string> { "1=1" };

            if (krit.Id > 0)
                cond.Add($"Iznajmljivanje.idIznajmljivanje = {krit.Id}");

            if (krit.Zaposleni != null && krit.Zaposleni.Id > 0)
                cond.Add($"Iznajmljivanje.idZaposleni = {krit.Zaposleni.Id}");

            if (krit.Osoba != null && krit.Osoba.Id > 0)
                cond.Add($"Iznajmljivanje.idOsoba = {krit.Osoba.Id}");

            // Oprema (preko stavke)
            var opremaId = krit.Stavke?.FirstOrDefault()?.Oprema?.Id ?? 0;
            if (opremaId > 0)
            {
                cond.Add(@$"EXISTS (
                    SELECT 1
                    FROM StavkaIznajmljivanja si
                    WHERE si.idIznajmljivanje = Iznajmljivanje.idIznajmljivanje
                      AND si.idOprema = {opremaId}
                )");
            }

            string condition = string.Join(" AND ", cond);

            var list = broker.GetByCondition(new Iznajmljivanje(), condition);
            Result = list.Cast<Iznajmljivanje>().ToList();
        }
    }
}
