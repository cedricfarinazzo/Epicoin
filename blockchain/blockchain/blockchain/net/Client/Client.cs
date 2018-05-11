using System;
using System.Net;
using System.Threading;
using blockchain.datacontainer;
using blockchain.blockchain;

namespace blockchain.net.client
{    
    public class Client
    {
        public Client(string address, int port)
        {
            Network.Connect(address, port);
        }

        public string SendTransaction(DataTransaction trans)
        {
            try
            {
                return Network.SendTransaction(trans);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void Mine(string workerAddress)
        {
            while (DataClient.Continue)
            {
                Thread.Sleep(1000);
                DataMine data;
                try
                {
                    data = Network.AskBlockToMine();
                    int difficulty = data.difficulty;
                    Block block = data.block;
                    DataClient.log.Write("[CM] Mining ...");
                    Console.WriteLine("[CM] Mining ...");
                    long start = DateTime.Now.Ticks;
                    block.MineBlock(difficulty);
                    long miningtime = DateTime.Now.Ticks - start;
                    DataClient.log.Write("[CM] Creating Block " + block.Index + " : " + block.Hashblock
                                   + " : difficulty " + difficulty);
                    Console.WriteLine("[CM] Creating Block " + block.Index + " : " + block.Hashblock
                                      + " : difficulty " + difficulty);
                    DataClient.log.Write("[CM] Sending block mined ...");
                    Console.WriteLine("[CM] Sending block mined ...");
                    DataMine send = new DataMine(difficulty, block, workerAddress, miningtime);
                    string resp = Network.SendMinedBlock(send);
                    Console.WriteLine("[M] " + resp);
                }
                catch (Exception e)
                {
                    Console.WriteLine("[M] " + e.Message);
                    continue;
                }
            }
            return;
        }

        public Blockchain GetBlockchain()
        {
            try
            {
                return Network.AskChain();
            }
            catch (Exception e)
            {
                Console.WriteLine("[G] " + e.Message);
                return null;
            }
        }
        
        public Block GetLastestBlock()
        {
            try
            {
                return Network.AskLatestBlock();
            }
            catch (Exception e)
            {
                Console.WriteLine("[G] " + e.Message);
                return null;
            }
        }
        
        public Block GetBlockNumber(int index)
        {
            try
            {
                return Network.AskBlockNumber(index);
            }
            catch (Exception e)
            {
                Console.WriteLine("[G] " + e.Message);
                return null;
            }
        }

        public int GetAmount(string address)
        {
            try
            {
                Blockchain chain = GetBlockchain();
                return chain.GetBalanceOfAddress(address);
            }
            catch (Exception e)
            {
                Console.WriteLine("[G] " + e.Message);
                return 0;
            }
            
        }
        
        
    }
}