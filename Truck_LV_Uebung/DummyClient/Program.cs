using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DummyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler h = new Handler();

            while (true)
            {
                h.sendMessage("S1-A54AB@Graz@Ladung1@10@4@Ladung2@100@400");
                Thread.Sleep(5000);
            }
        }
    }
}
