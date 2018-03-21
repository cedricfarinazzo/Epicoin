using System;

namespace blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Blockchain coin = new Blockchain();
            coin.addBlock(new Block(coin.getLatestIndex() + 1, DateTime.Now.ToString(), new []{5}));
            
        }
    }
}
