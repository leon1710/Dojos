using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Server.Communication
{
    internal class ClientHandler
    {
        private Socket clientSocket;
        private byte[] buffer = new byte[512];
        private Action<string> guiInformer;
        public String Name { get; set; }

        public ClientHandler(Socket socket, Action<string>guiInformer)
        {
            this.guiInformer = guiInformer;
            this.clientSocket = socket;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {

            while (true)
            {
                string msg = "";

                while (!msg.Contains("@quit"))
                {
                    int length = clientSocket.Receive(buffer);
                    msg = Encoding.UTF8.GetString(buffer, 0, length);

                    if (Name == null && msg.Contains(":"))
                    {
                        Name = msg.Split(':')[0];
                    }

                    guiInformer(msg);
                }
                
            }
            
        }

        

    }
}