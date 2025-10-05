using Common.Domain;
using DBBroker;
using Server.SystemOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private Broker broker;

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { broker = new Broker(); }

        public Zaposleni Login(Zaposleni zaposleni)
        {
            LoginSO so = new LoginSO(zaposleni);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal object GetAllKategorijaOsobe()
        {
           try
            {
                broker.OpenConnection();
                return broker.GetAll(new KategorijaOsobe()).Cast<KategorijaOsobe>().ToList();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        internal void AddPerson(Osoba osoba)
        {
            AddPersonSO addPerson = new AddPersonSO(osoba);
            addPerson.ExecuteTemplate();
        }

        internal object GetAllOsoba()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAll(new Osoba()).Cast<Osoba>().ToList();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        internal void RemoveOsoba(Osoba osoba)
        {
            RemovePersonSO removePerson = new RemovePersonSO(osoba);
            removePerson.ExecuteTemplate();
        }

        internal List<Osoba> SearchOsoba(Osoba o)
        {
            SearchPersonSO searchPerson = new SearchPersonSO(o);
            searchPerson.ExecuteTemplate();
            return searchPerson.Result;
        }

        internal Osoba GetOsobaById(Osoba o)
        {
            GetPersonByIdSO so = new GetPersonByIdSO(o);
            so.ExecuteTemplate();
            return so.Result;
        }
        internal void UpdateOsoba(Osoba o)
        {
            UpdatePersonSO so = new UpdatePersonSO(o);
            so.ExecuteTemplate();
        }
    }
}
