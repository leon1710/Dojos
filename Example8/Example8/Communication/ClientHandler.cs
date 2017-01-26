using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example8.Communication
{
    class ClientHandler
    {
        private Socket socket;
        private byte[] buffer = new byte[512];
        Action<string> informer;

        public ClientHandler(Socket socket, Action<string>informer)
        {
            this.socket = socket;
            this.informer = informer;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            while (true)
            {
                int length;
                length = socket.Receive(buffer);
                informer(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}
