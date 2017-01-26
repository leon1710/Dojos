using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Communication
{
    class Server
    {
        Socket serverSocket;
        List<ClientHandler> clients = new List<ClientHandler>();
        Action<string> informer;

        public Server(string ip, int port, Action<string> informer)
        {
            this.informer = informer;
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            serverSocket.Listen(5);

            Task.Factory.StartNew(Receive);

        }

        private void Receive()
        {
            while (true)
            {
                clients.Add(new ClientHandler(serverSocket.Accept(), new Action<string, Socket>(Informer)));
            }
        }

        //Nachricht an alle Clients senden -> kommt von ClientHandler update()
        private void Informer(string msg, Socket socket)
        {
            informer(msg);

            foreach (var item in clients)
            {
                if (item.Socket!= socket)
                {
                    item.Send(msg);
                }
            }
        }


    }
}
