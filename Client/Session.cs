using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Session
    {
        private static Session _instance;
        public static Session Instance => _instance ??= new Session();

        public Zaposleni Zaposleni { get; set; }

        public int ZaposleniId => Zaposleni?.Id ?? 0;
        private Session() 
        {

        }
    }
}
