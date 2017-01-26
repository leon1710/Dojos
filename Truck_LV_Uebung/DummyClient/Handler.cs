using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace DummyClient
{
    class Handler
    {
        TcpClient client = new TcpClient();
        Socket socket;

        public Handler()
        {
            client.Connect(new IPEndPoint(IPAddress.Loopback, 8050));
            socket = client.Client;
        }

        public void sendMessage(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
