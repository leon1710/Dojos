﻿using ClientConsole.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(updater);
            string ship = "50|recorder,2000,25000|DVDPlayer,1000,20000|PCs,443,999";
            client.Send(ship);
            //Console.WriteLine(ship);   
        }

        private static void updater(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
