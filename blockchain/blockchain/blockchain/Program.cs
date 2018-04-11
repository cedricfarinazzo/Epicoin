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
            string status = args.Length >= 1 ? args[0] : null;
            string namearg = args.Length >= 2 ? args[1] : null;

            if (status == null)
            {
                Console.WriteLine("Choose between [S]Serveur, [SW] Serveur without menu, [M]Miner, [U]User");
                Console.Write("\n status : ");
                status = Epicoin.ReadLine();
            }
            
            if (status == "S" || status == "Serveur")
            {
                Epicoin.Serveur(namearg);
            }
            if (status == "M" || status == "Miner")
            {
                Epicoin.Miner(namearg);
            }
            if (status == "U" || status == "User")
            {
                Epicoin.User(namearg);
            }
            if (status == "SW")
            {
                Epicoin.ServeurWithMenu(namearg);
            }
            
            Environment.Exit(Environment.ExitCode);
        }
    }
}
