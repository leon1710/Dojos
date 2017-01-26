using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Server.Communication
{
    public class Server
    {
        Socket serverSocket;
        private List<ClientHandler> clients = new List<ClientHandler>();
        private Action<string> guiInformer;
        
        public Server(Action<string> guiInformer)
        {
            this.guiInformer = guiInformer;
            serverSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 10100));
            serverSocket.Listen(5);

            Task.Factory.StartNew(StartAccepting);
        }

        private void StartAccepting()
        {
            while (true)
            {
                clients.Add(new ClientHandler(serverSocket.Accept(),guiInformer));
            }
        }
    }
}
