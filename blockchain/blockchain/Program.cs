using System;
using System.Collections.Generic;

namespace blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBlockchain init ...\n");
            Blockchain coin = new Blockchain();
            coin.AddTransaction(new Transaction("gen", "ced", 1));
            coin.AddTransaction(new Transaction("gen", "alice", 10));
            coin.AddTransaction(new Transaction("bob", "alice", 2));
            coin.AddTransaction(new Transaction("alpha", "bob", 3));
            coin.AddTransaction(new Transaction("bob", "alice", 1));
            coin.AddTransaction(new Transaction("alpha", "beta", 0));
            coin.AddTransaction(new Transaction("bob", "beta", 0));
            coin.AddTransaction(new Transaction("alice", "beta", 1));
            coin.AddTransaction(new Transaction("gen", "ced", 1));
            
            coin.minePendingTransaction("ced");
            coin.minePendingTransaction("ced");
            coin.minePendingTransaction("ced");
            coin.minePendingTransaction("ced");
            coin.minePendingTransaction("ced");
            coin.minePendingTransaction("ced");

            Console.WriteLine("\nChain is valid : " + coin.IsvalidChain());
            Console.WriteLine("gen amount : " + coin.getBalanceOfAddress("gen").ToString());
            Console.WriteLine("bob amount : " + coin.getBalanceOfAddress("bob").ToString());
            Console.WriteLine("alice amount : " + coin.getBalanceOfAddress("alice").ToString());
            Console.WriteLine("beta amount : " + coin.getBalanceOfAddress("beta").ToString());
            Console.WriteLine("alpha amount : " + coin.getBalanceOfAddress("alpha").ToString());
            Console.WriteLine("ced amount : " + coin.getBalanceOfAddress("ced").ToString());
            
            
        }
    }
}
