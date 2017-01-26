using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Communication
{
    internal class ClientHandler
    {
        private Socket clientSocket;
        private byte[] buffer = new byte[512];
        
        private Action<string> guiInformer;

        public ClientHandler(Socket socket, Action<string> guiInformer)
        {
            this.guiInformer = guiInformer;
            this.clientSocket = socket;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            while (true)
            {
                int length;
                length = clientSocket.Receive(buffer);
                //Delegate for GUI and MainVM
                guiInformer(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}