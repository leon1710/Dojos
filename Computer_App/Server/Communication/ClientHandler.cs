using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Communication
{
    internal class ClientHandler
    {
        private byte[] buffer = new byte[512];

        private Action<string, Socket> informer;
        private Socket socket;

        public ClientHandler(Socket socket, Action<string,Socket> informer)
        {
            this.Socket = socket;
            this.informer = informer;

            Task.Factory.StartNew(Receive);
        }

        public Socket Socket
        {
            get
            {
                return socket;
            }

            set
            {
                socket = value;
            }
        }

        private void Receive()
        {
            while (true)
            {
                int length;
                length = Socket.Receive(buffer);
                informer(Encoding.UTF8.GetString(buffer), Socket);
            }
        }

        public void Send(string msg)
        {
            Socket.Send(Encoding.UTF8.GetBytes(msg));
        }
    }
}