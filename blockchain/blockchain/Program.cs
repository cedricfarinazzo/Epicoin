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
        public static bool _continue2 = true;
            

        private static Wallet creator;
        private static Wallet alice;
        private static Wallet bob;
        private static Wallet ced;


        public static readonly string host = "127.0.0.1";
        public static readonly int mineport = 4247;
        public static readonly int transport = 4248;
        public static readonly int getport = 4249;
        

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
            
            Thread st = new Thread(ServeurTrans);
            st.Start();
            Thread sm = new Thread(ServeurMine);
            sm.Start();
            Thread sd = new Thread(ServeurData);
            sd.Start();
            Thread.Sleep(50);
            Thread c = new Thread(ClientMine);
            c.Start(ced);
            Thread.Sleep(30000);

            Program._continue = false;
            
            Thread.Sleep(1000);
            
            Verify();
            
            Thread.Sleep(1000);
            Program._continue2 = false;
        }

        public static void Init()
        {
            Coin = new Blockchain(creator.Address[0]);
            Coin.AddBlock(Coin.CreateGenesisBlock());
        }

        // local 
        
        public static void Evolve()
        {
            while (Program._continue)
            {
                Transaction(creator, ced.Address[0], 7);
                Transaction(creator, ced.Address[0], 1);
                Transaction(creator, bob.Address[0], 3);
                Transaction(creator, alice.Address[0], 10);
                Transaction(bob, alice.Address[0], 2);
                Transaction(alice, bob.Address[0], 3);
                Transaction(bob, alice.Address[0], 1);
                Transaction(creator, ced.Address[0], 1);
                /*
                Coin.AddTransaction(new Transaction(creator.Address[0], ced.Address[0], 7));
                Coin.AddTransaction(new Transaction(creator.Address[0], ced.Address[0], 1));
                Coin.AddTransaction(new Transaction(creator.Address[0], bob.Address[0], 3));
                Coin.AddTransaction(new Transaction(creator.Address[0], alice.Address[0], 10));
                Coin.AddTransaction(new Transaction(bob.Address[0], alice.Address[0], 2));
                Coin.AddTransaction(new Transaction(alice.Address[0], bob.Address[0], 3));
                Coin.AddTransaction(new Transaction(bob.Address[0], alice.Address[0], 1));
                Coin.AddTransaction(new Transaction(creator.Address[0], ced.Address[0], 1));
                */
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
            Console.WriteLine(creator.Name + " ; amount : " +
                              creator.TotalAmount().ToString());
            Console.WriteLine(bob.Name + " ; amount : " +
                              bob.TotalAmount().ToString());
            Console.WriteLine(alice.Name + " ; amount : " +
                              alice.TotalAmount().ToString());
            Console.WriteLine(ced.Name + " ; amount : " +
                              ced.TotalAmount().ToString());
            Console.WriteLine("nb pending transactions : " + (Coin.Pending.Count + (Coin.BlockToMines.Count * Block.nb_trans)));
            Console.WriteLine("nb block : " + Coin.Chainlist.Count);
        }
        
        // network

        public static void ServeurMine()
        {
            blockchain.ServeurMine serveurMine = new ServeurMine(Program.Coin, Program.host, Program.mineport);
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

        public static void ServeurTrans()
        {
            blockchain.ServeurTrans serveurTrans = new ServeurTrans(Program.Coin, Program.host, Program.transport);
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
