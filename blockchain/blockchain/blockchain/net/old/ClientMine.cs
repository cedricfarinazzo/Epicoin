﻿using System;
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

        public Logger log;
        
        public ClientMine(string host, int port, Wallet worker)
            : base(host, port)
        {
            this.Worker = worker;
            this.log = new Logger();
        }

        private void Init()
        {
            this._tcpClient = new TcpClient();
            while (!IsConnected(this._tcpClient) && Epicoin.Continue)
            {
                try
                {
                    this._tcpClient.Connect(this.host, this.port);
                }
                catch
                {}
            }
            this.log.Write("[CM] Worker connected");
            Console.WriteLine("[CM] Worker connected");
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
                    this.log.Write("[CM] Block received");
                    Console.WriteLine("[CM] Block received");
                }
            }
            catch
            {
                return;
            }
        }

        public byte[] SendBlock(long time)
        {
            DataMine dataMine = new DataMine(this.difficulty, this.BlockToMine, this.Worker.Address[0], time);
            byte[] datasend = Encoding.Default.GetBytes(Serialyze.Serialize(dataMine));
            return datasend;
        }

        public void Work()
        {
            this.log.Write("[CM] Start");
            Console.WriteLine("[CM] Start");
            this.Init();
            if (!this._tcpClient.Connected)
            {
                return;
            }
            Stream stm = this._tcpClient.GetStream();
            while (IsConnected(this._tcpClient) && Epicoin.Continue)
            {
                this.BlockToMine = null;
                this.difficulty = -1;
                byte[] buffer = new byte[4096];
                stm.Read(buffer,0,4096);
                stm.Flush();
                this.GetBlock(buffer);
                if (this.BlockToMine != null && this.difficulty != -1)
                {
                    this.log.Write("[CM] Mining ...");
                    Console.WriteLine("[CM] Mining ...");
                    long start = DateTime.Now.Ticks;
                    this.BlockToMine.MineBlock(this.difficulty);
                    long miningtime = DateTime.Now.Ticks - start;
                    this.log.Write("[CM] Creating Block " + this.BlockToMine.Index + " : " + this.BlockToMine.Hashblock
                                   + " : difficulty " + this.difficulty);
                    Console.WriteLine("[CM] Creating Block " + this.BlockToMine.Index + " : " + this.BlockToMine.Hashblock
                                      + " : difficulty " + this.difficulty);
                    byte[] datamine = this.SendBlock(miningtime);
                    this.log.Write("[CM] Sending block mined ...");
                    Console.WriteLine("[CM] Sending block mined ...");
                    stm.Write(datamine, 0, datamine.Length);
                }
            }
            this._tcpClient.Close();
            stm.Close();
            this._tcpClient = null;
            this.BlockToMine = null;
            this.log.Write("[CM] Disconnection ...");
            Console.WriteLine("[CM] Disconnection ...");
            if (Epicoin.Continue)
            {
                this.log.Write("[CM] Reconnection ...");
                Console.WriteLine("[CM] Reconnection ...");
                this.Work();
            }
            this.log.Write("[CM] Stop");
            Console.WriteLine("[CM] Stop");
            return;
        }
    }
}