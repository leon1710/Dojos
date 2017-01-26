using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Communication
{
    public class Server
    {
        private Socket serverSocket;
        private List<ClientHandler> clients = new List<ClientHandler>();

        //delegate
        private Action<string> updater;

        public Server(Action<string> updater)
        {
            this.updater = updater;
            serverSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 10100));

            serverSocket.Listen(5);

            Task.Factory.StartNew(StartAccepting);
        }

        public void StartAccepting()
        {
            while (true)
            {
                clients.Add(new ClientHandler(serverSocket.Accept(), updater));
            }
        }
    }
}
