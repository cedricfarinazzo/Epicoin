﻿using System;
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
            
            
            
            Thread th11 = new Thread(Mine);
            th11.Start(ced.Address);
            
            Thread th12 = new Thread(Mine);
            th12.Start(creator.Address);
            Thread.Sleep(100);
            
            Thread th2 = new Thread(Evolve);
            th2.Start();
            
            Thread.Sleep(7000);

            _continue = false;
            
            Thread.Sleep(1000);
            
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
                Thread.Sleep(1000);
            }
            
        }

        public static void Mine(object worker)
        {
            while (_continue)
            {
                Coin.MinePendingTransaction((string) worker);
                Thread.Sleep(500);
            }
        }

        public static void Verify()
        {
            Console.WriteLine("\nChain is valid : " + Coin.IsvalidChain());
            Console.WriteLine(creator.Name + " amount : " + Coin.GetBalanceOfAddress(creator.Address).ToString());
            Console.WriteLine(bob.Name + " amount : " + Coin.GetBalanceOfAddress(bob.Address).ToString());
            Console.WriteLine(alice.Name + " amount : " + Coin.GetBalanceOfAddress(alice.Address).ToString());
            Console.WriteLine(ced.Name + " amount : " + Coin.GetBalanceOfAddress(ced.Address).ToString());
            Console.WriteLine("nb pending transactions : " + Coin.Pending.Count);
        }
    }
}
