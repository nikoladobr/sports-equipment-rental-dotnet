using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private JsonNetworkSerializer serializer;
        private Socket socket;
        private readonly Server server;

        public ClientHandler(Socket socket, Server server)
        {
            this.socket = socket;
            this.server = server;
            serializer = new JsonNetworkSerializer(socket);
        }

        public void HandleRequest()
        {
            try
            {
                while (true)
                {
                    Request req = serializer.Receive<Request>();
                    Response r = ProcessRequest(req);
                    serializer.Send(r);
                }
            }
            catch (SocketException)
            {
                Debug.WriteLine("Комуникација са клијентом је прекинута");
            }
            catch (IOException)
            {
                Debug.WriteLine("Комуникација са клијентом је прекинута");
            }
            finally
            {
                if (socket.Connected)
                {
                    socket.Close();
                }
                server.RemoveClient(this);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response r = new Response();
            try
            {
                switch (req.Operation)
                {
                    
                    case Operation.CreateOsoba:
                        Controller.Instance.AddPerson(serializer.ReadType<Osoba>(req.Argument));
                        break;
                    case Operation.Login:
                        r.Result = Controller.Instance.Login(serializer.ReadType<Zaposleni>(req.Argument));
                        break;
                    case Operation.GetAllKategorijaOsobe:
                        r.Result = Controller.Instance.GetAllKategorijaOsobe();
                        break;
                    case Operation.GetAllOsoba:
                        r.Result = Controller.Instance.GetAllOsoba();
                        break;
                    case Operation.RemoveOsoba:
                        Controller.Instance.RemoveOsoba(serializer.ReadType<Osoba>(req.Argument));
                        break;
                    case Operation.SearchOsoba:
                        r.Result = Controller.Instance.SearchOsoba(serializer.ReadType<Osoba>(req.Argument));
                        break;
                    case Operation.GetOsobaById:
                        r.Result = Controller.Instance.GetOsobaById(serializer.ReadType<Osoba>(req.Argument));
                        break;
                    case Operation.UpdateOsoba:
                        Controller.Instance.UpdateOsoba(serializer.ReadType<Osoba>(req.Argument));
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(r.ExceptionMessage);
                r.ExceptionMessage = ex.Message;
            }
            return r;
        }

        internal void CloseSocket()
        {
            socket.Close();
        }
    }
}
