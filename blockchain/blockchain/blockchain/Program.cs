using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace blockchain
{
    static class Program
    {  
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose between [S]Serveur, [M]Miner, [U]User");
            Console.Write("\n status : ");
            string status = Epicoin.ReadLine();
            if (status == "S" || status == "Serveur")
            {
                Epicoin.Serveur();
            }
            if (status == "M" || status == "Miner")
            {
                Epicoin.Miner();
            }
            if (status == "U" || status == "User")
            {
                Epicoin.User();
            }
        }
    }
}
