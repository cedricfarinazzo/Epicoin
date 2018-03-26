using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace blockchain
{
    public class ClientTrans : BlockchainNetwork
    {
        protected TcpClient _tcpClient;

        protected DataTransaction DataTrans;
        
        public ClientTrans(string host, int port, DataTransaction datatrans)
            : base(host, port)
        {
            this.DataTrans = datatrans;
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

        public void Send()
        {

            byte[] datasend = Encoding.Default.GetBytes(Serialyze.Serialize(DataTrans));
            bool send = false;
            while (Program._continue && !send)
            {
                this.Init();
                Stream stm = this._tcpClient.GetStream();
                stm.Write(datasend, 0, datasend.Length);
                send = true;
                stm.Close();
                this._tcpClient.Close();
            }

            this.DataTrans = null;
        }
    }
}