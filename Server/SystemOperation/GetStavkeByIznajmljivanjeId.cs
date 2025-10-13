using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetStavkeByIznajmljivanjeIdSO : SystemOperationBase
    {
        private readonly int idIznajmljivanje;
        public List<StavkaIznajmljivanja> Result { get; private set; }

        public GetStavkeByIznajmljivanjeIdSO(int idIznajmljivanje)
        {
            this.idIznajmljivanje = idIznajmljivanje;
        }

        protected override void ExecuteConcreteOperation()
        {
        
            var list = broker.GetByCondition(
                new StavkaIznajmljivanja(),
                $"StavkaIznajmljivanja.idIznajmljivanje = {idIznajmljivanje}"
            );

            Result = list.Cast<StavkaIznajmljivanja>().ToList();
        }
    }
}