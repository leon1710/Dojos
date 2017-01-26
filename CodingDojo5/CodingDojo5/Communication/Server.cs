using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingDojo5.Communication
{
    class Server
    {
        Socket serverSock;
        List<ClientHandler> allClients = new List<ClientHandler>();
        Action<string> updater;
        Thread acceptClients;

        public Server(string ip, int port, Action<string> updater)
        {
            this.updater = updater;
            //create Socket
            serverSock = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream,
                                    ProtocolType.Tcp);
            //Bind Socket to IPAddress
            serverSock.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            serverSock.Listen(5);    
        }

        public void Accepting()
        {
            acceptClients = new Thread(new ThreadStart(Accept));
            acceptClients.IsBackground = true;
            acceptClients.Start();
        }

        private void Accept()
        {
            while (acceptClients.IsAlive)
            {
                try
                {
                    allClients.Add(new ClientHandler(serverSock.Accept(), new Action<string, Socket>(Informer)));
                }
                catch
                {

                }
            }
        }

        //Nachricht an alle Clients senden -> kommt von ClientHandler update()
        private void Informer(string arg1, Socket arg2)
        {
            updater(arg1);

            foreach(var item in allClients)
            {
                if(item.ClientSock != arg2)
                {
                    item.Send(arg1);
                }
            }
        }

        public void StopAccepting()
        {
            serverSock.Close();
            acceptClients.Abort(); 
            foreach (var item in allClients)
            {
                item.Close();
            }
            
            allClients.Clear();

        }

        public void DisconnectSpecificClient(string name)
        {
            foreach (var item in allClients)
            {
                if (item.Name.Equals(name))
                {
                    item.Close();
                    allClients.Remove(item);
                    break;
                }
            }
        }


    }
}
