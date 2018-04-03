using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ServeurMine : BlockchainNetwork
    {
        protected TcpListener ServeurChain;
        protected Blockchain Coin;
        
        public ServeurMine(Blockchain coin, string host, int port)
            : base(host, port)
        {
            this.Coin = coin;
            this.InitServeur();
            Thread serv = new Thread(this.Listen);
            serv.Start();
        }

        private void InitServeur()
        {
            this.ServeurChain = TcpListener.Create(this.port);
        }

        private byte[] GenData()
        {
            DataMine dataMine;
            byte[] datasend;
            if (this.Coin.BlockToMines.Count != 0)
            {
                dataMine = new DataMine(this.Coin.Difficulty, this.Coin.BlockToMines[0], null);
                datasend = Encoding.Default.GetBytes(Serialyze.Serialize(dataMine));
            }
            else
            {
                dataMine = new DataMine(this.Coin.Difficulty, null, null);
                datasend = Encoding.Default.GetBytes(Serialyze.Serialize(dataMine));
            }
            
            return datasend;
            
        }

        private void AnalyzeMine(byte[] data)
        {
            DataMine dataMine = Serialyze.UnserializeDataMine(Encoding.Default.GetString(data));
            //Console.WriteLine("[SM] Analyse bloc mined");
            if (this.Coin.BlockToMines[0].Index != dataMine.block.Index)
            {
                return;
            }

            if (this.Coin.BlockToMines[0].Timestamp != dataMine.block.Timestamp)
            {
                return;
            }

            for (int i = 0; i < Block.nb_trans; i++)
            {
                if (this.Coin.BlockToMines[0].Data[i].Amount != dataMine.block.Data[i].Amount)
                {
                    return;
                }

                if (this.Coin.BlockToMines[0].Data[i].FromAddress != dataMine.block.Data[i].FromAddress)
                {
                    return;
                }

                if (this.Coin.BlockToMines[0].Data[i].ToAddress != dataMine.block.Data[i].ToAddress)
                {
                    return;
                }

                if (this.Coin.BlockToMines[0].Data[i].Timestamp != dataMine.block.Data[i].Timestamp)
                {
                    return;
                }
            }

            if (this.Coin.BlockToMines[0].PreviousHash != dataMine.block.PreviousHash)
            {
                return;
            }
            
            this.Coin.NetworkMinePendingTransaction(dataMine.address, dataMine.block, dataMine.timemining);
        }

        public void ClientManager(object o)
        {
            this.maxthread--;
            TcpClient tcpClient = (TcpClient)o;
            
            
            byte[] bufferblock = new byte[4096];
            int bytesRead = 0;
            NetworkStream clientStream = tcpClient.GetStream();
            while (Epicoin.Continue && tcpClient.Connected)
            {
                
                bytesRead = 0;

                try
                {
                    byte[] buffer = this.GenData();
                    clientStream.Write(buffer, 0, buffer.Length);
                    
                    bytesRead = clientStream.Read(bufferblock, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead > 0)
                {
                    try
                    {
                        this.AnalyzeMine(bufferblock);
                        Thread.Sleep(100);
                    }
                    catch (Exception e)
                    {
                    }
                    
                }
                
            }
            clientStream.Close();
            tcpClient.Close();
            this.maxthread++;
            return;
        }

        private void Listen()
        {
            this.ServeurChain.Start();
            Console.WriteLine("[SM] Miner Serveur started");
            while (Epicoin.Continue)
            {
                if (this.maxthread > 0)
                {
                    TcpClient client = this.ServeurChain.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(this.ClientManager));
                    clientThread.Start(client);
                }
            }
            this.ServeurChain.Stop();
            Console.WriteLine("[SM] Miner Serveur closed");
        }
    }
}