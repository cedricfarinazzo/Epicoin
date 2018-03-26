using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace blockchain
{
    static class Program
    {
        public static Blockchain Coin;

        public static bool _continue = true;
            
        private static Wallet ced;


        public static readonly string host = "127.0.0.1";
        public static readonly int mineport = 4246;
        public static readonly int transport = 4247;
        public static readonly int getport = 4248;
        

        public static void Main(string[] args)
        {
            Console.WriteLine("\n init worker ...\n");

            ced = new Wallet("ced");

            Thread c = new Thread(ClientMine);
            c.Start(ced);

            Console.Read();
            
            Thread.Sleep(1000);

        }
        
        // network

        public static void ClientMine(object worker)
        {
            ClientMine cminer = new ClientMine(Program.host, Program.mineport, (Wallet) worker);
            cminer.Work();
        }

        public static Blockchain ClientData()
        {
            ClientGet cget = new ClientGet(Program.host, Program.getport);
            cget.Get();
            return cget.chain;
        }

        public static void ClientTrans(DataTransaction trans)
        {
            blockchain.ClientTrans ctrans = new ClientTrans(Program.host, Program.transport, trans);
            ctrans.Send();
        }

        public static void Transaction(Wallet sender, string toAddress, int amount)
        {
            List<DataTransaction> listTrans = sender.GenTransactions(amount, toAddress);
            foreach (var trans in listTrans)
            {
                Program.ClientTrans(trans);
            }
        }
    }
}
