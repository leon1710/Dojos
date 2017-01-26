using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Communication
{
    public class Client
    {
        byte[] buffer = new byte[512];
        Socket clientSocket;
        Action<string> Texter;
        //Action Informer;

        public Client(Action<string> texter)
        {
            
                //Informer = informer;
                //Texter = texter;
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Loopback, 10100));
                clientSocket = client.Client;
                StartReceiving();
           
        }

        private void StartReceiving()
        {
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            string data = "";
            while (true)
            {
                int length = clientSocket.Receive(buffer);
                data = Encoding.UTF8.GetString(buffer, 0, length);

                //inform gui via delegate
                Texter(data);
            }

        }
    }
}
