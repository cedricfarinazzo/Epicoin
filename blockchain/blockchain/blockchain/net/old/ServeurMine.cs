using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ServeurMine : BlockchainNetwork
    {
        protected TcpListener ServeurChain;
        protected Blockchain Coin;
        
                
        protected List<TcpClient> ClientlList = new List<TcpClient>();
        
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

        private bool AnalyzeMine(byte[] data)
        {
            DataMine dataMine;
            try
            {
                dataMine = Serialyze.UnserializeDataMine(Encoding.Default.GetString(data));
            }
            catch (Exception e)
            {
                return false;
            }
            
            //Console.WriteLine("[SM] Analyse bloc mined");
            if (dataMine == null)
            {
                return false;
            }

            if (dataMine.block == null)
            {
                return false;
            }

            if (dataMine.block.Data == null)
            {
                return false;
            }
            if (this.Coin.BlockToMines[0].Index != dataMine.block.Index)
            {
                return false;
            }

            if (this.Coin.BlockToMines[0].Timestamp != dataMine.block.Timestamp)
            {
                return false;
            }

            try
            {
                for (int i = 0; i < Block.nb_trans; i++)
                {
                    if (this.Coin.BlockToMines[0].Data[i].Amount != dataMine.block.Data[i].Amount)
                    {
                        return false;
                    }

                    if (this.Coin.BlockToMines[0].Data[i].FromAddress != dataMine.block.Data[i].FromAddress)
                    {
                        return false;
                    }

                    if (this.Coin.BlockToMines[0].Data[i].ToAddress != dataMine.block.Data[i].ToAddress)
                    {
                        return false;
                    }

                    if (this.Coin.BlockToMines[0].Data[i].Timestamp != dataMine.block.Data[i].Timestamp)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            

            if (this.Coin.BlockToMines[0].PreviousHash != dataMine.block.PreviousHash)
            {
                return false;
            }
            
            return this.Coin.NetworkMinePendingTransaction(dataMine.address, dataMine.block, dataMine.timemining);
        }

        public void ClientManager(object o)
        {
            this.maxthread--;
            TcpClient tcpClient = (TcpClient)o;
            byte[] bufferblock = new byte[4096];
            int bytesRead = 0;
            NetworkStream clientStream = tcpClient.GetStream();
            while (Epicoin.Continue && IsConnected(tcpClient))
            {
                while (this.Coin.BlockToMines.Count == 0 && Epicoin.Continue && IsConnected(tcpClient));
                if (!IsConnected(tcpClient))
                {
                    break;
                }
                byte[] buffer = this.GenData();
                try
                {
                    clientStream.Write(buffer, 0, buffer.Length);
                    buffer = null;
                    bytesRead = clientStream.Read(bufferblock, 0, 4096);
                    clientStream.Flush();
                    bool NotWrong = this.AnalyzeMine(bufferblock);
                    if (!NotWrong)
                    {
                        break;
                    }
                }
                catch
                { }
            }
            tcpClient.Client.Disconnect(true);
            tcpClient.Close();
            this.maxthread++;
            return;
        }

        private void Listen()
        {
            try
            {
                this.ServeurChain.Start();
            }
            catch (SocketException)
            { return; }
            Console.WriteLine("[SM] Miner Serveur started");
            while (Epicoin.Continue)
            {
                if (this.maxthread > 0)
                {
                    TcpClient client = this.ServeurChain.AcceptTcpClient();
                    this.ClientlList.Add(client);
                    Thread clientThread =
                        new Thread(new ParameterizedThreadStart(this.ClientManager)) {Priority = ThreadPriority.Lowest};
                    clientThread.Start(client);
                }
            }
            
            foreach (var client in this.ClientlList)
            {
                client.Close();
            }
            this.ServeurChain.Stop();
            this.ServeurChain = null;
            Console.WriteLine("[SM] Miner Serveur closed");
            return;
        }
    }
}