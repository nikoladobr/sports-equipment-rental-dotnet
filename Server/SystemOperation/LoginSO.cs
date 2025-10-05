using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class LoginSO : SystemOperationBase
    {
        private readonly Zaposleni z;
        public Zaposleni Result { get; set; }

        public LoginSO(Zaposleni z)
        {
            this.z = z;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"korisnickoIme = '{z.KorisnickoIme}' AND sifra = '{z.Sifra}'";
            List<IEntity> lista = broker.GetByCondition(z, condition);

            Result = lista.Cast<Zaposleni>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Корисничко име и шифра нису исправни.");
            }
        }
    }
}
