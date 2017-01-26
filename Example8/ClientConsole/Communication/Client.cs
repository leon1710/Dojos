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

        public Client(Action<string>updater)
        {
            this.updater = updater;
            try { 
            TcpClient client = new TcpClient();
            Console.WriteLine("connecting..");
            client.Connect(IPAddress.Loopback, 10100);
            Console.WriteLine("client connected to "+ IPAddress.Loopback);
            clientSocket = client.Client;
            }
            catch
            {
                updater("Server offline");
            }
        }

        public void Send(string ship)
        {
            int length;

            while (true)
            {
                length = clientSocket.Send(buffer);
                clientSocket.Send(Encoding.UTF8.GetBytes(ship));
                //ship = Encoding.UTF8.GetString(buffer, 0, length);
                //updater(ship);
                Console.WriteLine(ship);
                Thread.Sleep(5000);
            }

        }
    }
}
