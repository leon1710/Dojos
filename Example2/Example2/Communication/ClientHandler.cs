using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example2.Communication
{
    public class ClientHandler
    {
        //private Action<string> informer;
        private Socket socket;
        private Action<string, Socket> guiInformer;
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }



        private byte[] buffer = new byte[512];

        public ClientHandler(Socket socket, Action<string, Socket> guiInformer)
        {
            this.socket = socket;
            this.guiInformer = guiInformer;

            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            int length;
            string msg = "";

            while (true)
            {
                
                    length = socket.Receive(buffer);
                    msg += Encoding.UTF8.GetString(buffer, 0, length);

                if (msg.Contains("\r\n"))
                {
                    //Delegate for GUI and MainVM
                    guiInformer(msg, socket);
                    msg = "";
                }
                    
            }
        }
        



        private void Send(string v)
        {
            socket.Send(Encoding.UTF8.GetBytes(v));
        }
    }
}