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


        private static Wallet creator;
        private static Wallet alice;
        private static Wallet bob;
        

        public static void Main(string[] args)
        {
            Console.WriteLine("\nBlockchain init ...\n");
            
            
            creator = new Wallet("creator");
            Init();
            
            bob = new Wallet("bob");
            alice = new Wallet("alice");

            Thread th0 = new Thread(CreateBlock);
            Thread th1 = new Thread(Evolve);

            Thread s = new Thread(Serveur);
            s.Start();
            Thread.Sleep(50);
            th0.Start();
            th1.Start();
            
            Thread c = new Thread(Worker);
            c.Start(creator);

            Console.Read();

            Program._continue = false;
            
            Thread.Sleep(2000);
            
            Verify();
        }

        public static void Init()
        {
            Coin = new Blockchain(creator.Address);
        }

        public static void Evolve()
        {
            while (_continue)
            {
                Coin.AddTransaction(new Transaction(creator.Address, bob.Address, 3));
                Coin.AddTransaction(new Transaction(creator.Address, alice.Address, 10));
                Coin.AddTransaction(new Transaction(bob.Address, alice.Address, 2));
                Coin.AddTransaction(new Transaction(alice.Address, bob.Address, 3));
                Coin.AddTransaction(new Transaction(bob.Address, alice.Address, 1));
                Coin.AddTransaction(new Transaction(creator.Address, alice.Address, 1));
                Thread.Sleep(1500);
            }
            
        }

        public static void CreateBlock()
        {
            while (_continue)
            {
                Coin.CreateBlock();
                Thread.Sleep(Coin.timebtwblock * 1000);
                
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
            Console.WriteLine("\n\nChain is valid : " + Coin.IsvalidChain());
            Console.WriteLine(creator.Name + " " + creator.Address + " amount : " +
                              Coin.GetBalanceOfAddress(creator.Address).ToString());
            Console.WriteLine(bob.Name + " " + bob.Address + " amount : " +
                              Coin.GetBalanceOfAddress(bob.Address).ToString());
            Console.WriteLine(alice.Name + " " + alice.Address + " amount : " +
                              Coin.GetBalanceOfAddress(alice.Address).ToString());
            Console.WriteLine("nb pending transactions : " + Coin.Pending.Count);
            Console.WriteLine("nb block : " + (Coin.Chainlist.Count + Coin.BlockToMines.Count));
        }

        public static void Serveur()
        {
            blockchain.Serveur s = new Serveur(Coin, "127.0.0.1", 4242);
        }

        public static void Worker(object worker)
        {
            Client c = new Client("127.0.0.1", 4242, (Wallet) worker);
            c.Work();
        }
    }
}
