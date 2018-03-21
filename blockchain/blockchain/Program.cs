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

        private static bool _continue = true;

        public static void Main(string[] args)
        {
            Console.WriteLine("\nBlockchain init ...\n");
            Init();
            
            Thread th11 = new Thread(Mine);
            th11.Start("ced");
            
            Thread th12 = new Thread(Mine);
            th12.Start("gen");
            Thread.Sleep(100);
            
            Thread th2 = new Thread(Evolve);
            th2.Start();
            
            Thread.Sleep(7000);

            _continue = false;
            
            Verify();
        }

        public static void Init()
        {
            Coin = new Blockchain();
        }

        public static void Evolve()
        {
            while (_continue)
            {
                Coin.AddTransaction(new Transaction("gen", "ced", 7));
                Coin.AddTransaction(new Transaction("gen", "ced", 1));
                Coin.AddTransaction(new Transaction("gen", "bob", 3));
                Coin.AddTransaction(new Transaction("gen", "alice", 10));
                Coin.AddTransaction(new Transaction("bob", "alice", 2));
                Coin.AddTransaction(new Transaction("alpha", "bob", 3));
                Coin.AddTransaction(new Transaction("bob", "alice", 1));
                Coin.AddTransaction(new Transaction("gen", "ced", 1));
                Thread.Sleep(1000);
            }
            
        }

        public static void Mine(object worker)
        {
            while (_continue)
            {
                Coin.MinePendingTransaction((string) worker);
            }
        }

        public static void Verify()
        {
            Console.WriteLine("\nChain is valid : " + Coin.IsvalidChain());
            Console.WriteLine("gen amount : " + Coin.GetBalanceOfAddress("gen").ToString());
            Console.WriteLine("bob amount : " + Coin.GetBalanceOfAddress("bob").ToString());
            Console.WriteLine("alice amount : " + Coin.GetBalanceOfAddress("alice").ToString());
            Console.WriteLine("ced amount : " + Coin.GetBalanceOfAddress("ced").ToString());
            Console.WriteLine("nb pending transactions : " + Coin.Pending.Count);
        }
    }
}
