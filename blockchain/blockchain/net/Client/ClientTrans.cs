using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace blockchain
{
    public class ClientTrans : BlockchainNetwork
    {
        protected TcpClient _tcpClient;

        protected Wallet Sender;

        protected string ToAddress;

        protected int Amount;
        
        public ClientTrans(string host, int port, Wallet sender, string toAddressn, int amount)
            : base(host, port)
        {
            this.Sender = sender;
            this.ToAddress = ToAddress;
            this.Amount = amount;
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
            DataTransaction datatrans = new DataTransaction(
                            this.Sender.PubKey, 
                            Rsa.Encrypt(this.Sender.PrivKey, this.Sender.Address), 
                            Rsa.Encrypt(this.Sender.PrivKey, this.ToAddress), 
                            Rsa.Encrypt(this.Sender.PrivKey, this.Amount.ToString())
                        );
            byte[] datasend = Encoding.Default.GetBytes(Serialyze.serialize(datatrans));
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
        }
    }
}