using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ClientTrans : BlockchainNetwork
    {
        protected TcpClient _tcpClient;

        protected DataTransaction DataTrans;

        public bool error = false;
        
        public ClientTrans(string host, int port, DataTransaction datatrans)
            : base(host, port)
        {
            this.DataTrans = datatrans;
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
                this.error = true;
            }
        }

        public void Send()
        {
            int timeout = 1000;
            byte[] datasend = Encoding.Default.GetBytes(Serialyze.Serialize(DataTrans));
            bool send = false;
            this.Init();
            while (IsConnected(this._tcpClient) && Epicoin.Continue && !send && timeout >= 0 && !this.error)
            {
                Stream stm = this._tcpClient.GetStream();
                stm.Write(datasend, 0, datasend.Length);
                send = true;
                stm.Close();
                timeout--;
            }
            this._tcpClient.Close();
            if (timeout < 0)
            {
                this.error = true;
            }
            this.DataTrans = null;
            return;
        }
    }
}