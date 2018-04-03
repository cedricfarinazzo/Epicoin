using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading;

namespace blockchain
{
    public class Epicoin
    {
        public static Blockchain Coin = null;
        
        public static bool Continue = true;

        public static readonly string host = "accer.ddns.net"; //IPAddress.Loopback.ToString(); //"accer.ddns.net";
        public static readonly int mineport = 4246;
        public static readonly int transport = 4247;
        public static readonly int getport = 4248;

        public static readonly string walletfile = "wallet.epi";
        public static readonly string blockchainfile = "blockchain.epi";

        public static Wallet Wallet = null;
        
        public static void Serveur(string namearg = null)
        {
            Console.WriteLine("\n\n        Blochain Epicoin Serveur \n\n");
            
            ImportWallet();
            if (Wallet == null)
            {
                string name = "";
                if (namearg == null)
                {
                    Console.Write("Your name : ");
                    name = ReadLine();
                }
                else
                {
                    name = namearg;
                }

                CreateWallet(name);   
                ExportWallet();
            }
            
            
            Console.WriteLine("\nYour epicoin address : " + Wallet.Address[0] + "\n\n");
            
            
            Console.WriteLine("Init Blockchain ...");
            ImportChain();
            if (Coin == null)
            {
                Init();
            }
            
            Thread block = new Thread(CreateBlock);
            Thread data = new Thread(ServeurData);
            Thread mine = new Thread(ServeurMine);
            Thread transaction = new Thread(ServeurTrans);
            Thread saveChain = new Thread(SaveBlockchain);
            
            block.Start();
            data.Start();
            mine.Start();
            transaction.Start();
            Thread.Sleep(1000);
            saveChain.Start();
            Console.WriteLine("\nAll serveur online\n\n\n");
            
            
            while (Continue)
            {
                Console.WriteLine("\n      MENU SERVEUR");
                Console.WriteLine();
                Console.WriteLine("1 : stop and exit");
                Console.WriteLine("2 : Export blochain");
                Console.WriteLine("3 : Export wallet");
                Console.WriteLine("4 : Get Chain Stats");
                Console.WriteLine("5 : Get Wallet Stats");
                Console.WriteLine("6 : Create Transaction");
                Console.WriteLine();
                
                Console.Write("action : ");
                string action = ReadLine();
                
                Console.WriteLine();
                if (action == "1")
                {
                    Continue = false;
                    ExportChain();
                    ExportWallet();
                    break;
                }
                else if (action == "2")
                {
                    ExportChain();
                    Console.WriteLine("Blockchain exported in " + Epicoin.blockchainfile);
                }
                else if (action == "3")
                {
                    ExportWallet();
                    Console.WriteLine("Wallet exported in " + Epicoin.walletfile);
                }
                else if (action == "4")
                {
                    Console.WriteLine("     Chain " + Blockchain.Name);
                    Console.WriteLine("Chain is valid : " + Coin.IsvalidChain());
                    Console.WriteLine("Chain lenght : " + Coin.Chainlist.Count);
                    Console.WriteLine("Chain difficulty : " + Coin.Difficulty);
                    Block last = Coin.GetLatestBlock();
                    Console.WriteLine("Last Block " + last.Index + " : " + last.Hashblock);
                    Console.WriteLine("pending Transaction : " + (Coin.Pending.Count + (Coin.BlockToMines.Count * Block.nb_trans)));
                }
                else if (action == "5")
                {
                    Console.WriteLine("     Wallet : " + Wallet.Name);
                    Console.WriteLine("Your epicoin address : " + Wallet.Address[0]);
                    Console.WriteLine("Epicoin amount : " + Wallet.TotalAmount());
                }
                else if (action == "6")
                {
                    Console.Write("ToAddress : ");
                    string ToAddress = ReadLine();
                    Console.Write("\nAmount : ");
                    string Samount = ReadLine();
                    int amount = 0;
                    try
                    {
                        amount = int.Parse(Samount);
                        if (amount <= 0)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid amount");
                        continue;
                    }

                    List<DataTransaction> ltrans = Wallet.GenTransactions(amount, ToAddress);
                    bool error = false;
                    foreach (var trans in ltrans)
                    {
                        error = error || ClientTrans(trans);
                    }

                    if (error)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        Console.WriteLine("Transaction sended");
                    }
                }
                else
                {
                    Console.WriteLine("Entrée incorrect");
                }
                action = "";
            }
            Console.WriteLine("\nbye!");
        }

        public static void Miner(string namearg = null)
        {
            Console.WriteLine("\n\n        Blochain Epicoin Miner Client \n\n");
            
            ImportWallet();
            if (Wallet == null)
            {
                string name = "";
                if (namearg == null)
                {
                    Console.Write("Your name : ");
                    name = ReadLine();
                }
                else
                {
                    name = namearg;
                }

                CreateWallet(name);  
                ExportWallet();
            }

            Console.WriteLine("\nYour epicoin address : " + Wallet.Address[0] + "\n\n");
            
            
            Console.WriteLine("\n\n Enter to stop miner ...\n");
            
            Console.WriteLine("Start miner ...");
            
            Thread worker = new Thread(ClientMine);
            worker.Start(Wallet);

            ReadLine();
            
            Continue = false;
            
            Console.WriteLine("\nbye!");
        }

        public static void User(string namearg = null)
        {
            Console.WriteLine("\n\n        Blochain Epicoin Client \n\n");
            
            ImportWallet();
            if (Wallet == null)
            {
                string name = "";
                if (namearg == null)
                {
                    Console.Write("Your name : ");
                    name = ReadLine();
                }
                else
                {
                    name = namearg;
                }

                CreateWallet(name);
                ExportWallet();
            }

            Console.WriteLine("\nYour epicoin address : " + Wallet.Address[0] + "\n\n");

            while (Continue)
            {
                Console.WriteLine("\n      MENU Client");
                Console.WriteLine();
                Console.WriteLine("1 : exit");
                Console.WriteLine("2 : Export wallet");
                Console.WriteLine("3 : Get Chain Stats");
                Console.WriteLine("4 : Get Wallet Stats");
                Console.WriteLine("5 : Create Transaction");   
                Console.WriteLine();
                
                Console.Write("action : ");
                string action = ReadLine();
                
                Console.WriteLine();
                
                if (action == "1")
                {
                    Continue = false;
                    ExportWallet();
                    break;
                }
                else if (action == "2")
                {
                    ExportWallet();
                    Console.WriteLine("Wallet exported in " + Epicoin.walletfile);
                }
                else if (action == "3")
                {
                    Blockchain chain = ClientData();
                    if (chain != null)
                    {
                        Console.WriteLine("     Chain " + Blockchain.Name);
                        Console.WriteLine("Chain is valid : " + chain.IsvalidChain());
                        Console.WriteLine("Chain lenght : " + chain.Chainlist.Count);
                        Console.WriteLine("Chain difficulty : " + chain.Difficulty);
                        Block last = chain.GetLatestBlock();
                        Console.WriteLine("Last Block " + last.Index + " : " + last.Hashblock);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                }
                else if (action == "4")
                {
                    Console.WriteLine("     Wallet : " + Wallet.Name);
                    Console.WriteLine("Your epicoin address : " + Wallet.Address[0]);
                    Console.WriteLine("Epicoin amount : " + Wallet.TotalAmount());
                }
                else if (action == "5")
                {
                    Console.Write("ToAddress : ");
                    string ToAddress = ReadLine();
                    Console.Write("\nAmount : ");
                    string Samount = ReadLine();
                    int amount = 0;
                    try
                    {
                        amount = int.Parse(Samount);
                        if (amount <= 0)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid amount");
                        continue;
                    }

                    List<DataTransaction> ltrans = Wallet.GenTransactions(amount, ToAddress);
                    bool error = false;
                    foreach (var trans in ltrans)
                    {
                        error = error || ClientTrans(trans);
                    }

                    if (error)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        Console.WriteLine("Transaction sended");
                    }
                    
                    
                }
                else
                {
                    Console.WriteLine("Entrée incorrect");
                }
                action = "";
            }
            Console.WriteLine("\nbye!");
        }

        public static string ReadLine()
        {
            string data = "";
            while ((data = Console.ReadLine()) == "");
            return data;
        }
        
        public static void Init()
        {
            Coin = new Blockchain(Wallet.Address[0]);
            Coin.AddBlock(Coin.CreateGenesisBlock());
        }        

        public static void CreateBlock()
        {
            while (Continue)
            {
                Coin.CreateBlock();
                Thread.Sleep(Coin.timebtwblock * 1000);
                
            }
        }
        
        // network

        public static void ServeurMine()
        {
            blockchain.ServeurMine serveurMine = new ServeurMine(Coin, host, mineport);
        }

        public static void ClientMine(object worker)
        {
            ClientMine cminer = new ClientMine(host, mineport, (Wallet) worker);
            cminer.Work();
        }

        public static void ServeurData()
        {
            blockchain.ServeurGet serveurGet= new ServeurGet(Coin, host, getport);
        }

        public static Blockchain ClientData()
        {
            ClientGet cget = new ClientGet(host, getport);
            cget.Get();
            return cget.chain;
        }

        public static void ServeurTrans()
        {
            blockchain.ServeurTrans serveurTrans = new ServeurTrans(Coin, host, transport);
        }

        public static bool ClientTrans(DataTransaction trans)
        {
            blockchain.ClientTrans ctrans = new ClientTrans(host, transport, trans);
            ctrans.Send();
            return ctrans.error;
        }

        public static void Transaction(Wallet sender, string toAddress, int amount)
        {
            List<DataTransaction> listTrans = sender.GenTransactions(amount, toAddress);
            foreach (var trans in listTrans)
            {
                ClientTrans(trans);
            }
        }

        public static void CreateWallet(string name)
        {
            ImportWallet();
            if (Wallet == null)
            {
                Wallet = new Wallet(name);
                Wallet.GenNewAddress();
            }
        }
        
        public static void ExportWallet()
        {
            string w = Wallet.Export();
            File.WriteAllText(Epicoin.walletfile, w);
        }

        public static void ImportWallet()
        {
            if (File.Exists(Epicoin.walletfile))
            {
                string wa = File.ReadAllText(Epicoin.walletfile);
                Wallet w = Serialyze.UnserializeWallet(wa);
                Wallet = w;
            }
        }

        public static void ExportChain()
        {
            string chain = Serialyze.Serialize(Coin);
            File.WriteAllText(Epicoin.blockchainfile, chain);
        }

        public static void ImportChain()
        {
            if (File.Exists(Epicoin.blockchainfile))
            {
                string chain = File.ReadAllText(Epicoin.blockchainfile);
                Blockchain c = Serialyze.UnserializeBlockchain(chain);
                Coin = c;
            }
        }

        public static void SaveBlockchain()
        {
            int time = 5 * 60 * 1000;
            while (Continue)
            {
                try
                {
                    ExportChain();
                }
                catch (Exception e)
                {
                }
                
                Thread.Sleep(time);
            }
        }
    }
}