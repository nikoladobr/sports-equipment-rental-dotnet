using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class Communication
    {
        private static Communication _instance;
        public static Communication Instance
        {
            get
            {
                if (_instance == null) _instance = new Communication();
                return _instance;
            }
        }
        private Communication()
        {
        }

        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        internal Response Login(Zaposleni zap)
        {
            Request req = new Request
            {
                Argument = zap,
                Operation = Operation.Login
            };
            serializer.Send(req);
            Response response = serializer.Receive<Response>();
            response.Result = serializer.ReadType<Zaposleni>(response.Result);
            return response;
        }

        internal List<KategorijaOsobe> GetAllKategorijaOsobe()
        {
            Request request = new Request
            {
                Operation = Operation.GetAllKategorijaOsobe
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<KategorijaOsobe>>(response.Result);
        }

        internal Response CreateOsoba(Osoba o)
        {
            Request request = new Request
            {
                Argument = o,
                Operation = Operation.CreateOsoba
            };
            serializer.Send(request);

            Response response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
            {
                throw new Exception(response.ExceptionMessage);
            }
            return response;
        }

        internal List<Osoba> GetAllOsoba()
        {
            Request request = new Request
            {
                Operation = Operation.GetAllOsoba
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Osoba>>(response.Result);
        }

        internal List<Zaposleni> GetAllZaposleni()
        {
            Request request = new Request
            {
                Operation = Operation.GetAllZaposleni
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Zaposleni>>(response.Result);
        }

        internal Response RemoveOsoba(Osoba osoba)
        {
            Request request = new Request
            {
                Argument = osoba,
                Operation = Operation.RemoveOsoba
            };
            serializer.Send(request);

            Response response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
            {
                throw new Exception(response.ExceptionMessage);
            }
            return response;
        }

        internal List<Osoba> SearchOsoba(Osoba o)
        {
            var request = new Request
            {
                Argument = o,
                Operation = Operation.SearchOsoba
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<List<Osoba>>(response.Result);
        }

        internal Osoba GetOsobaById(Osoba o)
        {
            var request = new Request { Argument = o, Operation = Operation.GetOsobaById };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null) throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<Osoba>(response.Result);
        }

        internal Response UpdateOsoba(Osoba o)
        {
            var request = new Request
            {
                Argument = o,
                Operation = Operation.UpdateOsoba
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            return response;
        }

        internal List<Oprema> GetAllOprema()
        {
            Request request = new Request
            {
                Operation = Operation.GetAllOprema
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Oprema>>(response.Result);
        }

        internal Response CreateIznajmljivanje(Iznajmljivanje i)
        {
            var request = new Request 
            { 
                Argument = i, 
                Operation = Operation.CreateIznajmljivanje 
            };
            serializer.Send(request);
            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null) 
                throw new Exception(response.ExceptionMessage);
            return response;
        }

        internal List<Iznajmljivanje> SearchIznajmljivanje(Iznajmljivanje kriterijum)
        {
            Request request = new Request
            {
                Operation = Operation.SearchIznajmljivanje,
                Argument = kriterijum
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);
            return serializer.ReadType<List<Iznajmljivanje>>(response.Result);
        }

        internal Iznajmljivanje GetIznajmljivanjeById(int id)
        {
            var request = new Request 
            { 
                Argument = new Iznajmljivanje 
                { 
                    Id = id 
                }, 
                Operation = Operation.GetIznajmljivanjeById 
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            var el = (JsonElement)response.Result;
            return el.Deserialize<Iznajmljivanje>();
        }

        internal List<StavkaIznajmljivanja> GetStavkeByIznajmljivanjeId(int id)
        {
            var request = new Request
            {
                Argument = new Iznajmljivanje { Id = id },
                Operation = Operation.GetStavkeByIznajmljivanjeId
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<List<StavkaIznajmljivanja>>(response.Result);
        }
    }
}
