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
    public class GetAllZaposleniSO : SystemOperationBase
    {
        public BindingList<Zaposleni> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<Zaposleni> zaposleni = broker.GetAll(new Zaposleni()).Cast<Zaposleni>().ToList();
            Result = new BindingList<Zaposleni>(zaposleni);
        }
    }
}
