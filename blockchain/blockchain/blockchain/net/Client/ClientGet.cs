using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ClientGet : BlockchainNetwork
    {
        public Blockchain chain = null;

        protected TcpClient _tcpClient;
        
        public ClientGet(string host, int port)
            : base(host, port)
        {
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
        }

        private void GetBlockchain(byte[] data)
        {
            string msgdata = Encoding.Default.GetString(data);
            this.chain = Serialyze.UnserializeBlockchain(msgdata);
        }

        public void Get()
        {
            this.Reset();
            while (Epicoin.Continue && this.chain == null)
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
            }
        }

        public void Reset()
        {
            this.chain = null;
        }
    }
}