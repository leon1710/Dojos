using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConsole.Communication
{
    class Client
    {
        Socket clientSocket;
        byte[] buffer = new byte[512];
        Action<string> updater;

        public Client()
        {
            //this.updater = updater;
            try { 
            TcpClient client = new TcpClient();
            Console.WriteLine("connecting..");
            client.Connect(IPAddress.Loopback, 10100);
            Console.WriteLine("client connected to "+ IPAddress.Loopback);
            clientSocket = client.Client;
            }
            catch
            {
                //updater("Server offline");
                Console.WriteLine("Keine Verbinung zum Server möglich");
            }
        }


        public void Send(string ship)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(ship));

        }
    }
}
