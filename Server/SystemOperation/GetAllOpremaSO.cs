using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class GetAllOpremaSO : SystemOperationBase
    {
        public BindingList<Oprema> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<Oprema> oprema = broker.GetAll(new Oprema()).Cast<Oprema>().ToList();
            Result = new BindingList<Oprema>(oprema);
        }
    }
}
