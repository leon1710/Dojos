using Example2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example2.Communication
{
    public class Server
    {
        Socket serverSocket;
        public List<ClientHandler> clients = new List<ClientHandler>();
        private Action<string, Socket> informer;

        public Server(Action<string, Socket>informer)
        {
            this.informer = informer;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 10100));
            serverSocket.Listen(5);

            Task.Factory.StartNew(Accepting);
        }

        private void Accepting()
        {
            while (true)
            {
                clients.Add(new ClientHandler(serverSocket.Accept(), informer));
            }
        }

        
        
    }
}
