using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class AddPersonSO : SystemOperationBase
    {
        private readonly Osoba o;

        public AddPersonSO(Osoba o)
        {
            this.o = o;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(o);
        }
    }
}
