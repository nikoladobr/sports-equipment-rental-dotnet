using Common.Domain;
using System;
using System.Globalization;
using System.Linq;

namespace Server.SystemOperation
{
    public class UpdateIznajmljivanjeSO : SystemOperationBase
    {
        private readonly Iznajmljivanje i;

        public UpdateIznajmljivanjeSO(Iznajmljivanje i)
        {
            this.i = i ?? throw new ArgumentNullException(nameof(i));
        }

        protected override void ExecuteConcreteOperation()
        {
            if (i.Id <= 0)
                throw new InvalidOperationException("Недостаје ID изнајмљивања за измену.");
            if (i.Stavke == null || i.Stavke.Count == 0)
                throw new InvalidOperationException("Изнајмљивање мора имати бар једну ставку.");

            var inv = CultureInfo.InvariantCulture;

            // UPDATE headera
            string set =
                $"ukupanIznos = {i.UkupanIznos.ToString(inv)}, " +
                $"vremeOd = '{i.VremeOd:yyyy-MM-dd HH:mm:ss}', " +
                $"idZaposleni = {(i.Zaposleni?.Id ?? 0)}, " +
                $"idOsoba = {(i.Osoba?.Id ?? 0)}";

            string condition = $"idIznajmljivanje = {i.Id}";
            broker.Update(new Iznajmljivanje(), set, condition);

            broker.Remove(new StavkaIznajmljivanja(), $"idIznajmljivanje = {i.Id}");

            int rb = 1;
            foreach (var si in i.Stavke.OrderBy(x => x.Rb))
            {
                if (si == null)
                    throw new InvalidOperationException("Пронађена је невалидна ставка.");
                if (si.Oprema == null || si.Oprema.Id <= 0)
                    throw new InvalidOperationException("Молимо одаберите одговарајућу опрему за сваку ставку.");

                si.Iznajmljivanje = i;  
                si.IdIznajmljivanje = i.Id;
                si.Rb = rb++;

                broker.Add(si);
            }

            broker.Update(
                new Iznajmljivanje(),
                $"ukupanIznos = (SELECT COALESCE(SUM(iznos),0) FROM StavkaIznajmljivanja WHERE idIznajmljivanje = {i.Id})",
                $"idIznajmljivanje = {i.Id}"
            );
        }
    }
}
