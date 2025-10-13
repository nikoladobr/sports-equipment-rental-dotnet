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
    public class GetAllOsobaSO : SystemOperationBase
    {
        public BindingList<Osoba> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<Osoba> osoba = broker.GetAll(new Osoba()).Cast<Osoba>().ToList();
            Result = new BindingList<Osoba>(osoba);
        }
    }
}
