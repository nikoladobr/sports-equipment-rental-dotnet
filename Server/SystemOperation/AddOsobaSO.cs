using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class AddOsobaSO : SystemOperationBase
    {
        private readonly Osoba o;

        public AddOsobaSO(Osoba o)
        {
            this.o = o;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(o);
        }
    }
}
