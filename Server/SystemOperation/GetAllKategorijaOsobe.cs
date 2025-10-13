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
    public class GetAllKategorijaOsobeSO : SystemOperationBase
    {
        public BindingList<KategorijaOsobe> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<KategorijaOsobe> kategorije = broker.GetAll(new KategorijaOsobe()).Cast<KategorijaOsobe>().ToList();
            Result = new BindingList<KategorijaOsobe>(kategorije);
        }
    }
}
