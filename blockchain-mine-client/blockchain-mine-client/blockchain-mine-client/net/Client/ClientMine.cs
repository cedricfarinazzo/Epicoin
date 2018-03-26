using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ClientMine : BlockchainNetwork
    {
        protected Wallet Worker;
        protected Block BlockToMine;
        protected int difficulty;

        protected TcpClient _tcpClient;
        
        public ClientMine(string host, int port, Wallet worker)
            : base(host, port)
        {
            this.Worker = worker;
        }

        private void Init()
        {
            this._tcpClient = new TcpClient();
            while (!this._tcpClient.Connected)
            {
                try
                {
                    this._tcpClient.Connect(this.host, this.port);
                }
                catch (Exception e)
                {
                }
                
            }
            //Console.WriteLine("Worker connected");
        }

        public void GetBlock(byte[] data)
        {
            try
            {
                string msgdata = Encoding.Default.GetString(data);
                var datamine = Serialyze.UnserializeDataMine(msgdata);
    
                this.BlockToMine = null;
                this.difficulty = datamine.difficulty;
                if (datamine.block != null)
                {
                    this.BlockToMine = new Block(datamine.block.Index, datamine.block.Timestamp, datamine.block.Data, datamine.block.PreviousHash);
                }
            }
            catch (Exception e)
            {
                return;
            }
           
            //Console.WriteLine("Block received");
        }

        public byte[] SendBlock(long time)
        {
            DataMine dataMine = new DataMine(this.difficulty, this.BlockToMine, this.Worker.Address[0], time);
            byte[] datasend = Encoding.Default.GetBytes(Serialyze.Serialize(dataMine));
            return datasend;
        }

        public void Work()
        {
            while (Program._continue)
            {
                this.BlockToMine = null;
                this.Init();
                Stream stm = this._tcpClient.GetStream();
                byte[] buffer = new byte[4096];
                stm.Read(buffer,0,4096);
                this.GetBlock(buffer);
                if (this.BlockToMine != null)
                {
                    Console.WriteLine("[CM] Mining ...");
                    long start = DateTime.Now.Ticks;
                    this.BlockToMine.MineBlock(this.difficulty);
                    long miningtime = DateTime.Now.Ticks - start;
                    byte[] datamine = this.SendBlock(miningtime);
                    Console.WriteLine("[M] Block mined " + this.BlockToMine.Index + " : " + this.BlockToMine.Hashblock);
                    Console.WriteLine("[CM] Sending block mined ...");
                    stm.Write(datamine, 0, datamine.Length);
                }
                
                stm.Close();
                this._tcpClient.Close();
            }
            
        }
    }
}