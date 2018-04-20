using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ClientPeer : BlockchainNetwork
    {
        public bool error = false;

        protected TcpClient _tcpClient;

        protected List<string> peerList;

        protected byte[] data;

        protected int index = 0;
        
        public ClientPeer(int port, List<string> peerList) : base("", port)
        {
            this.peerList = peerList;
            this.data = Encoding.Default.GetBytes(Serialyze.Serialize(peerList));
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
            for (; this.index < this.peerList.Count; this.index++)
            {
                this.SendTo(this.peerList[this.index]);
            }
        }
    }
}