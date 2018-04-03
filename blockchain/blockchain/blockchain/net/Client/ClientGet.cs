﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ClientGet : BlockchainNetwork
    {
        public Blockchain chain = null;

        public bool error = false;

        protected TcpClient _tcpClient;
        
        public ClientGet(string host, int port)
            : base(host, port)
        {
        }

        private void Init()
        {
            int timeout = 500;
            this._tcpClient = new TcpClient();
            while (!this._tcpClient.Connected && Epicoin.Continue && timeout >= 0 && !this.error)
            {
                try
                {
                    this._tcpClient.Connect(this.host, this.port);
                }
                catch (Exception e)
                {
                }

                timeout--;
            }
        }

        private void GetBlockchain(byte[] data)
        {
            string msgdata = Encoding.Default.GetString(data);
            try
            {
                this.chain = Serialyze.UnserializeBlockchain(msgdata);
            }
            catch (Exception e)
            {
                this.Reset();
            }
            
        }

        public void Get()
        {
            int timeout = 10000;
            this.Reset();
            while (Epicoin.Continue && this.chain == null && !error && timeout >= 0)
            {
                this.Init();
                Stream stm = this._tcpClient.GetStream();
                byte[] bufferlenght = new byte[4096];
                stm.Read(bufferlenght,0,4096);
                int bufferlen = int.Parse(Encoding.Default.GetString(bufferlenght));
                Thread.Sleep(250);
                byte[] buffer = new byte[bufferlen + 1000];
                stm.Read(buffer, 0, bufferlen + 1000);
                this.GetBlockchain(buffer);
                stm.Close();
                this._tcpClient.Close();
                timeout--;
            }

            if (timeout < 0 || this.chain == null)
            {
                this.error = true;
            }
        }

        public void Reset()
        {
            this.chain = null;
        }
    }
}