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
            int timeout = 10;
            this._tcpClient = new TcpClient();
            while (!IsConnected(this._tcpClient) && Epicoin.Continue && timeout >= 0 && !this.error)
            {
                try
                {
                    this._tcpClient.Connect(this.host, this.port);
                }
                catch
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
            catch
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
                try
                {
                    this.Init();
                    if (!IsConnected(this._tcpClient))
                    {
                        break;
                    }
                    Stream stm = this._tcpClient.GetStream();
                    Thread.Sleep(500);
                    /*
                    byte[] bufferlenght = new byte[512];
                    stm.Read(bufferlenght,0,512);
                    string slenght = Encoding.Default.GetString(bufferlenght);
                    int bufferlen = int.Parse(slenght);
                    Thread.Sleep(100);
                    */
                    byte[] buffer = new byte[8388608];
                    stm.Read(buffer, 0, 8388608);
                    this.GetBlockchain(buffer);
                    stm.Close();
                    this._tcpClient.Close();
                }
                catch
                {
                }
                timeout--;
            }
            
            if (timeout < 0 || this.chain == null)
            {
                this.error = true;
            }
            return;
        }

        public void Reset()
        {
            this.chain = null;
        }
    }
}