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
        private static Wallet ced;
        

        public static void Main(string[] args)
        {
            Console.WriteLine("\nBlockchain init ...\n");
            
            
            creator = new Wallet("creator");
            Init();
            
            bob = new Wallet("bob");
            alice = new Wallet("alice");
            ced = new Wallet("ced");
            
            Thread th0 = new Thread(CreateBlock);/*
            Thread th11 = new Thread(Mine);     
            Thread th12 = new Thread(Mine);        
            Thread th13 = new Thread(Mine);*/
            Thread th2 = new Thread(Evolve);

            
            th0.Start();
            Thread.Sleep(5000);/*
            th11.Start(ced.Address);
            Thread.Sleep(72);
            th12.Start(creator.Address);
            Thread.Sleep(70);
            th13.Start(bob.Address);*/
            th2.Start();            
            

            
            
            Thread s = new Thread(ServeurMine);
            s.Start();
            Thread.Sleep(50);
            Thread c = new Thread(Worker);
            c.Start(creator);
            Thread.Sleep(1000);

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
                Coin.AddTransaction(new Transaction(creator.Address, ced.Address, 7));
                Coin.AddTransaction(new Transaction(creator.Address, ced.Address, 1));
                Coin.AddTransaction(new Transaction(creator.Address, bob.Address, 3));
                Coin.AddTransaction(new Transaction(creator.Address, alice.Address, 10));
                Coin.AddTransaction(new Transaction(bob.Address, alice.Address, 2));
                Coin.AddTransaction(new Transaction(alice.Address, bob.Address, 3));
                Coin.AddTransaction(new Transaction(bob.Address, alice.Address, 1));
                Coin.AddTransaction(new Transaction(creator.Address, ced.Address, 1));
                Thread.Sleep(2500);
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
            Console.WriteLine(ced.Name + " " + ced.Address + " amount : " +
                              Coin.GetBalanceOfAddress(ced.Address).ToString());
            Console.WriteLine("nb pending transactions : " + (Coin.Pending.Count + (Coin.BlockToMines.Count * Block.nb_trans)));
            Console.WriteLine("nb block : " + Coin.Chainlist.Count);
        }

        public static void ServeurMine()
        {
            blockchain.ServeurMine serveurMine = new ServeurMine(Coin, "127.0.0.1", 4243);
        }

        public static void Worker(object worker)
        {
            ClientMine cminer = new ClientMine("127.0.0.1", 4243, (Wallet) worker);
            cminer.Work();
        }
    }
}
