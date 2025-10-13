using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class GetOsobaByIdSO : SystemOperationBase
    {
        private readonly Osoba o;
        public Osoba Result { get; private set; }

        public GetOsobaByIdSO(Osoba o) 
        { 
            this.o = o; 
        }

        protected override void ExecuteConcreteOperation()
        {
            var list = broker.GetByCondition(o, $"idOsoba = {o.Id}");
            Result = list.Cast<Osoba>().FirstOrDefault();
        }
    }
}
