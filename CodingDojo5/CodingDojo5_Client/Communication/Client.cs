using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo5_Client.Communication
{
    class Client
    {
        byte[] buffer = new byte[512];
        Socket clientSock;
        Action<string> Messanger;
        Action Informer;

        public Client(string ip, int port, Action<string> messanger, Action informer)
        {
            try
            {
                Informer = informer;
                Messanger = messanger;
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);
                clientSock = client.Client;
                StartReceiving();
            }
            catch
            {
                Messanger("Server offline");
                Informer();
            }
        }

        public void StartReceiving()
        {
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            string msg = "";

            //as long es quit hasnt been entered
            while (!msg.Equals("@quit"))
            {
                int length = clientSock.Receive(buffer);
                msg = Encoding.UTF8.GetString(buffer, 0, length);

                //delegate to View
                Messanger(msg);
            }
            Close();
        }

        public void Send(string msg)
        {
            if (clientSock != null)
            {
                clientSock.Send(Encoding.UTF8.GetBytes(msg));
            }
        }
        public void Close()
        {
            clientSock.Close();
            //delegate to view
            Informer();
        }
    }
}
