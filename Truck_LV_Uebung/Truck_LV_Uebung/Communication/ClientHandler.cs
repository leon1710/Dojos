using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Truck_LV_Uebung.Communication
{
    //ClientHandler handelt Clients serverseitig -> muss Recieven
    internal class ClientHandler
    {
        private Socket socket;

        //buffer erstellen
        //jeder client braucht eigenen buffer
        private byte[] buffer = new byte[512];

        //delegate für gui
        Action<string> guiInformer;

        public ClientHandler(Socket socket, Action<string> guiInformer)
        {
            this.guiInformer = guiInformer;
            this.socket = socket;
            //Thread fürs empfangen
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            while (true)
            {
                //Recieve gibt int zurück!
                //Länge merken sonst immer 512
                int length;
                length = socket.Receive(buffer);
                //Delegate for GUI and MainVM
                guiInformer(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}