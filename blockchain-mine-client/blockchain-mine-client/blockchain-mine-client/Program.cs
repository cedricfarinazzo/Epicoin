using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace blockchain
{
    static class Program
    {

        public static bool _continue = true;


        private static Wallet ced;
        

        public static void Main(string[] args)
        {
            Console.WriteLine("\nB Miner client start  ...\n");
            
            ced = new Wallet("ced");
            

            Thread miner1 = new Thread(Worker);
            miner1.Start(ced);

            Console.Read();

            Program._continue = false;
        }

        public static void Worker(object worker)
        {
            Client c = new Client("127.0.0.1", 4242, (Wallet) worker);
            c.Work();
        }
    }
}
