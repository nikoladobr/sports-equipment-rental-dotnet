using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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

        internal Response CreatePerson(Osoba o)
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

        internal Response RemovePerson(Osoba osoba)
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

        internal List<Osoba> SearchPerson(Osoba o)
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

        internal Osoba GetPersonById(Osoba o)
        {
            var request = new Request { Argument = o, Operation = Operation.GetOsobaById };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null) throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<Osoba>(response.Result);
        }

        internal Response UpdatePerson(Osoba o)
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
    }
}
