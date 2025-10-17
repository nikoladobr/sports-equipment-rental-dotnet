using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class AddTerminDezurstvaSO : SystemOperationBase
    {
        private readonly TerminDezurstva td;

        public AddTerminDezurstvaSO(TerminDezurstva td)
        {
            this.td = td;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(td);
        }
    }
}
