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


        private static readonly string host = "127.0.0.1";
        private static readonly int mineport = 4240;
        private static readonly int transport = 4241;
        private static readonly int getport = 4242;
        

        public static void Main(string[] args)
        {
            Console.WriteLine("\nBlockchain init ...\n");
            
            
            creator = new Wallet("creator");
            Init();
            
            bob = new Wallet("bob");
            alice = new Wallet("alice");
            ced = new Wallet("ced");
            
            Thread th0 = new Thread(CreateBlock);
            Thread th2 = new Thread(Evolve);

            
            th0.Start();
            Thread.Sleep(100);
            th2.Start();            
            

            
            
            Thread s = new Thread(ServeurMine);
            s.Start();
            Thread.Sleep(50);
            Thread c = new Thread(ClientMine);
            c.Start(creator);
            Thread.Sleep(20000);

            Program._continue = false;
            
            Thread.Sleep(1000);
            
            Verify();
        }

        public static void Init()
        {
            Coin = new Blockchain(creator.Address);
        }

        // local 
        
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
        
        // verify

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
        
        // network

        public static void ServeurMine()
        {
            blockchain.ServeurMine serveurMine = new ServeurMine(Coin, Program.host, Program.mineport);
        }

        public static void ClientMine(object worker)
        {
            ClientMine cminer = new ClientMine(Program.host, Program.mineport, (Wallet) worker);
            cminer.Work();
        }

        public static void ServeurData()
        {
            blockchain.ServeurGet serveurGet= new ServeurGet(Program.Coin, Program.host, Program.getport);
        }

        public static Blockchain ClientData()
        {
            ClientGet cget = new ClientGet(Program.host, Program.getport);
            cget.Get();
            return cget.chain;
        }
    }
}
