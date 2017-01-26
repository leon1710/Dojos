using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Truck_LV_Uebung.Communication
{
    public class Server
    {
        private Socket serverSocket;

        private List<ClientHandler> clients = new List<ClientHandler>();
        //deleagate von ClientHandler
        private Action<string> informer;

        //Konstruktor
        public Server(Action<string> informer)
        {
            this.informer = informer;
            serverSocket = new Socket(
                           AddressFamily.InterNetwork, 
                           SocketType.Stream, 
                           ProtocolType.Tcp);

            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 8050));

            serverSocket.Listen(5);

            Task.Factory.StartNew(StartAccepting);

        }

        public void StartAccepting()
        {
            while (true)
            {
                //wenn er mehrere empfangen können soll braucht man eine Liste
                //zur Liste werden ClientHandler hinzugefügt
                clients.Add(new ClientHandler(serverSocket.Accept(), informer));
            }
        }
    }
}
