using System;
using System.Collections.Generic;

namespace blockchain
{
    class Program
    {
        public static Blockchain Coin;

        internal delegate void MineDelegate(string worker);

        public static MineDelegate mine;

        public static void Main(string[] args)
        {
            Console.WriteLine("\nBlockchain init ...\n");
            Init();
            SetDelegate();
            Evolve();
            Verify();
        }

        public static void Init()
        {
            Coin = new Blockchain();
        }

        public static void SetDelegate()
        {
            mine = new MineDelegate(Coin.MinePendingTransaction);
        }

        public static void Evolve()
        {
            Coin.AddTransaction(new Transaction("gen", "ced", 1));
            Coin.AddTransaction(new Transaction("gen", "alice", 10));
            Coin.AddTransaction(new Transaction("bob", "alice", 2));
            Coin.AddTransaction(new Transaction("alpha", "bob", 3));
            Coin.AddTransaction(new Transaction("bob", "alice", 1));
            Coin.AddTransaction(new Transaction("alpha", "beta", 0));
            Coin.AddTransaction(new Transaction("bob", "beta", 0));
            Coin.AddTransaction(new Transaction("alice", "beta", 1));
            Coin.AddTransaction(new Transaction("gen", "ced", 1));
            
            mine("ced");
            mine("ced");
            mine("ced");
            mine("ced");
            mine("ced");
            mine("ced");
            mine("ced"); 
        }

        public static void Verify()
        {
            Console.WriteLine("\nChain is valid : " + Coin.IsvalidChain());
            Console.WriteLine("gen amount : " + Coin.GetBalanceOfAddress("gen").ToString());
            Console.WriteLine("bob amount : " + Coin.GetBalanceOfAddress("bob").ToString());
            Console.WriteLine("alice amount : " + Coin.GetBalanceOfAddress("alice").ToString());
            Console.WriteLine("beta amount : " + Coin.GetBalanceOfAddress("beta").ToString());
            Console.WriteLine("alpha amount : " + Coin.GetBalanceOfAddress("alpha").ToString());
            Console.WriteLine("ced amount : " + Coin.GetBalanceOfAddress("ced").ToString());
        }
    }
}
