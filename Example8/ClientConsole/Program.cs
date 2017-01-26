using ClientConsole.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //string ship = "50@recorder,2000,25000|DVDPlayer,1000,20000|PCs,443,999";
            //client.Send(ship);
            //Console.WriteLine(ship);  

            while (true)
            {
                string message = "4@recorder,20000,25000|DVDPlayer,10000,20000|PC,50000,200000";
                client.Send(message);
                Console.WriteLine(message);
                Thread.Sleep(5000);
            }
        }

        
    }
}
