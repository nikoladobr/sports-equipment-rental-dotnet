using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class RemovePersonSO : SystemOperationBase
    {
        private readonly Osoba o;

        public RemovePersonSO(Osoba o)
        {
            this.o = o;
            
        }
        protected override void ExecuteConcreteOperation()
        {
            string condition = $"idOsoba = {o.Id}";
            broker.Remove(o, condition);
        }
    }
}
