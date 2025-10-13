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
            broker.Add(i);

            var list = broker.GetByCondition(new Iznajmljivanje(), "1=1 order by Iznajmljivanje.idIznajmljivanje DESC");
            if (list.Count == 0) throw new InvalidOperationException("Није могуће прочитати ID изнајмљивања");
            i.Id = ((Iznajmljivanje)list[0]).Id;
            foreach (var si in i.Stavke)
            {
                if (si.Oprema == null)
                {
                    throw new InvalidOperationException("Молимо одаберите одговарајућу опрему.");
                }
                si.Iznajmljivanje = i;
                broker.Add(si);
            }
        }
    }
}
