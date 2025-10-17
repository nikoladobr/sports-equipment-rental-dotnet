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
            var list = broker.GetByCondition(new Osoba(), "1=1"); // ovo aktivira JOIN iz Osoba
            Result = new BindingList<Osoba>(list?.Cast<Osoba>().ToList() ?? new List<Osoba>());
        }
    }
}
