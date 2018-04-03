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

        public void Send()
        {
            int timeout = 10000;
            byte[] datasend = Encoding.Default.GetBytes(Serialyze.Serialize(DataTrans));
            bool send = false;
            while (Epicoin.Continue && !send && timeout >= 0 && !this.error)
            {
                this.Init();
                if (this._tcpClient.Connected)
                {
                    Stream stm = this._tcpClient.GetStream();
                    stm.Write(datasend, 0, datasend.Length);
                    send = true;
                    stm.Close();
                   
                }
                this._tcpClient.Close();
                timeout--;
            }

            if (timeout < 0)
            {
                this.error = true;
            }
            this.DataTrans = null;
        }
    }
}