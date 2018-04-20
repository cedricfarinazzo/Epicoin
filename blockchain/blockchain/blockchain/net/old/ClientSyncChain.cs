using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace blockchain
{
    public class ClientSyncChain : BlockchainNetwork
    {
        public bool error = false;

        protected TcpClient _tcpClient;

        protected byte[] data;

        protected int index = 0;
        
        public ClientSyncChain(int port, Blockchain chain) : base("", port)
        {
            this.data = Encoding.Default.GetBytes(Serialyze.Serialize(chain));
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

            if (timeout < 0)
            {
                error = true;
                try
                {
                    Epicoin.PeerList.Remove(host);
                }
                catch (Exception e)
                {}
            }
        }
        
        private void SendTo(string host)
        {
            this.host = host;
            this.error = false;
            this._tcpClient = null;
            this.Init();
            if (IsConnected(this._tcpClient) && !error)
            {
                Stream stm = this._tcpClient.GetStream();
                stm.Write(this.data, 0, this.data.Length);
                stm.Close();
            }
            this._tcpClient.Close();
            return;
        }

        public void Send()
        {
            List<string> hosts = Epicoin.PeerList;
            for (int i = 0; i < hosts.Count; i++)
            {
                this.SendTo(hosts[i]);
            }
        }
    }
}