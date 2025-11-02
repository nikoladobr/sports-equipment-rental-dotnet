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

        //Get
        internal object GetAllKategorijaOsobe()
        {
            GetAllKategorijaOsobeSO so = new();
            so.ExecuteTemplate();
            return so.Result;
        }
        internal object GetAllOsoba()
        {
            GetAllOsobaSO so = new();
            so.ExecuteTemplate();
            return so.Result;
        }
        internal object GetAllOprema()
        {
            GetAllOpremaSO so = new();
            so.ExecuteTemplate();
            return so.Result;
        }
        internal object GetAllZaposleni()
        {
            GetAllZaposleniSO so = new();
            so.ExecuteTemplate();
            return so.Result;
        }

        //GetBy
        internal Osoba GetOsobaById(Osoba o)
        {
            GetOsobaByIdSO so = new GetOsobaByIdSO(o);
            so.ExecuteTemplate();
            return so.Result;
        }
        internal object GetIznajmljivanjeById(Iznajmljivanje i)
        {
            var so = new GetIznajmljivanjeByIdSO(i.Id);
            so.ExecuteTemplate();
            return so.Result;
        }

        //Add
        internal void AddOsoba(Osoba osoba)
        {
            AddOsobaSO addOsoba = new AddOsobaSO(osoba);
            addOsoba.ExecuteTemplate();
        }
        internal void AddIznajmljivanje(Iznajmljivanje iznajmljivanje)
        {
            AddIznajmljivanjeSO addIznajmljivanje = new AddIznajmljivanjeSO(iznajmljivanje);
            addIznajmljivanje.ExecuteTemplate();
        }
        internal void AddTerminDezurstva(TerminDezurstva terminDezurstva)
        {
            AddTerminDezurstvaSO addTerminDezurstva = new AddTerminDezurstvaSO(terminDezurstva);
            addTerminDezurstva.ExecuteTemplate();
        }

        //Remove
        internal void RemoveOsoba(Osoba osoba)
        {
            RemoveOsobaSO removePerson = new RemoveOsobaSO(osoba);
            removePerson.ExecuteTemplate();
        }

        //Search
        internal List<Osoba> SearchOsoba(Osoba o)
        {
            SearchOsobaSO searchPerson = new SearchOsobaSO(o);
            searchPerson.ExecuteTemplate();
            return searchPerson.Result;
        }
        internal object SearchIznajmljivanje(Iznajmljivanje krit)
        {
            var so = new SearchIznajmljivanjeSO(krit);
            so.ExecuteTemplate();
            return so.Result;
        }

        //Update
        internal void UpdateOsoba(Osoba o)
        {
            UpdateOsobaSO so = new UpdateOsobaSO(o);
            so.ExecuteTemplate();
        }
        internal void UpdateIznajmljivanje(Iznajmljivanje iznajmljivanje)
        {
            var so = new UpdateIznajmljivanjeSO(iznajmljivanje);
            so.ExecuteTemplate();
        }

        internal object GetStavkeByIznajmljivanjeId(Iznajmljivanje i)
        {
            var so = new GetStavkeByIznajmljivanjeIdSO(i.Id);
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
