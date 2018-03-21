using System;
using System.Collections.Generic;

namespace blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blockchain");
            Blockchain coin = new Blockchain();
            coin.addBlock(new Block(coin.getLatestIndex() + 1, DateTime.Now.ToString(), new List<Transaction>()));
            coin.addBlock(new Block(coin.getLatestIndex() + 1, DateTime.Now.ToString(), new List<Transaction>()));
            coin.addBlock(new Block(coin.getLatestIndex() + 1, DateTime.Now.ToString(), new List<Transaction>()));
            coin.addBlock(new Block(coin.getLatestIndex() + 1, DateTime.Now.ToString(), new List<Transaction>()));
            coin.addBlock(new Block(coin.getLatestIndex() + 1, DateTime.Now.ToString(), new List<Transaction>()));
            coin.addBlock(new Block(coin.getLatestIndex() + 1, DateTime.Now.ToString(), new List<Transaction>()));
            Console.WriteLine(coin.IsvalidChain());
        }
    }
}
