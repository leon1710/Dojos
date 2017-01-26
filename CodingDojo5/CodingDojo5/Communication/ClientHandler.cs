using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingDojo5.Communication
{
    class ClientHandler
    {
        private byte[] buffer = new byte[512];
        private Action<string, Socket> updater;
        private Thread clientThread;

        private string name;
        private Socket clientSock;

        #region properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Socket ClientSock
        {
            get
            {
                return clientSock;
            }

            set
            {
                clientSock = value;
            }
        }
        #endregion

        public ClientHandler(Socket sock, Action<string, Socket> updater)
        {
            ClientSock = sock;
            this.updater = updater;
            clientThread = new Thread(Receive);
            clientThread.Start();    
        }

        private void Receive()
        {
            string msg = "";

            while (!msg.Contains("@quit"))
            {
                int length = ClientSock.Receive(buffer);
                msg = Encoding.UTF8.GetString(buffer, 0, length);

                if(Name == null && msg.Contains(":"))
                {
                    Name = msg.Split(':')[0];
                }

                //nachricht an Server dass an alle gesendet werden soll
                updater(msg, ClientSock);
            }
            Close();
        }

        public void Send(string msg)
        {
            ClientSock.Send(Encoding.UTF8.GetBytes(msg));
        }

        public void Close()
        {
            Send("you have been disconnected.");
            ClientSock.Close(1);
            clientThread.Abort();
        }
    }
}
