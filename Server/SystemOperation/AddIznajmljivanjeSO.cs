using Common.Domain;
using System;

namespace Server.SystemOperation
{
    public class AddIznajmljivanjeSO : SystemOperationBase
    {
        private readonly Iznajmljivanje i;

        public AddIznajmljivanjeSO(Iznajmljivanje i)
        {
            this.i = i;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (i.Zaposleni == null || i.Zaposleni.Id <= 0)
                throw new Exception("Изнајмљивање нема запосленог.");
            if (i.Osoba == null || i.Osoba.Id <= 0)
                throw new Exception("Изнајмљивање нема особу.");

            broker.Add(i);
           
            var list = broker.GetByCondition(new Iznajmljivanje(), "1=1 ORDER BY idIznajmljivanje DESC");
            if (list.Count == 0) throw new Exception("Грешка при учитавању изнајмљивања.");
            i.Id = ((Iznajmljivanje)list[0]).Id;

            int rb = 1;
            foreach (var s in i.Stavke)
            {
                if (s.Oprema == null || s.Oprema.Id <= 0)
                    throw new Exception("Ставка изнајмљивања нема опрему.");

                s.Rb = rb++;
                s.IdIznajmljivanje = i.Id;
                s.Iznajmljivanje = i;

                broker.Add(s);
            }
        }
    }
}
