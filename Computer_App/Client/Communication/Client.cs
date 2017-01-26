using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Communication
{
    class Client
    {
        Socket clientSocket;
        private byte[] buffer = new byte[512];
        Action<string> informer;

        public Client(string ip, int port,Action<string>informer)
        {
            try
            {
                this.informer = informer;
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);
                clientSocket = client.Client;
                Task.Factory.StartNew(Receive);
             
            }
            catch
            {
                informer("Server offline");
            }
        }

        private void Receive()
        {
            string msg = "";

            int length = clientSocket.Receive(buffer);
            msg = Encoding.UTF8.GetString(buffer, 0, length);
        }

        public void Send(string msg)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(msg));
        }
    }
}
