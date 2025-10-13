using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class GetIznajmljivanjeByIdSO : SystemOperationBase
    {
        private readonly int id;
        public Iznajmljivanje Result { get; private set; }

        public GetIznajmljivanjeByIdSO(int id)
        {
            this.id = id;
        }

        protected override void ExecuteConcreteOperation()
        {
            var headList = broker.GetByCondition(new Iznajmljivanje(), $"Iznajmljivanje.idIznajmljivanje = {id}");
            var header = headList.Cast<Iznajmljivanje>().FirstOrDefault();
            if (header == null) { Result = null; return; }

            var stavkeList = broker.GetByCondition(new StavkaIznajmljivanja(), $"Iznajmljivanje.idIznajmljivanje = {id}");
            header.Stavke = stavkeList.Cast<StavkaIznajmljivanja>().ToList();

            Result = header;
        }
    }
}
