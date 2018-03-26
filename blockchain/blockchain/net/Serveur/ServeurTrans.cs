using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ServeurTrans : BlockchainNetwork
    {
        protected TcpListener ServeurChain;
        protected Blockchain Coin;
        
        public ServeurTrans(Blockchain coin, string host, int port)
            : base(host, port)
        {
            this.Coin = coin;
            this.InitServeur();
            Thread serv = new Thread(this.Listen);
            serv.Start();
        }

        private void InitServeur()
        {
            this.ServeurChain = TcpListener.Create(this.port);
        }

        private void GetData(byte[] data)
        {
            DataTransaction dataTransaction = Serialyze.UnserializeDataTransaction(Encoding.Default.GetString(data));
            Console.WriteLine("[ST] Analyse transaction");
            string EncodeFrAd = Rsa.Encrypt(dataTransaction.PubKey, Hash.Create(dataTransaction.PubKey));
            if (EncodeFrAd != dataTransaction.EncodeFromAddress)
            {
                return;
            }

            string FromAddress = Hash.Create(dataTransaction.PubKey);
            Transaction newTransaction = new Transaction(FromAddress, dataTransaction.ToAddress, dataTransaction.Amount);
            this.Coin.AddTransaction(newTransaction);
        }

        public void ClientManager(object o)
        {
            TcpClient tcpClient = (TcpClient)o;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] bufferblock = new byte[4096];
            int bytesRead = 0;
            try
            {
                bytesRead = clientStream.Read(bufferblock, 0, 4096);
                this.GetData(bufferblock);  
            }
            catch
            {
            }
            clientStream.Close();
            tcpClient.Close();
        }

        private void Listen()
        {
            this.ServeurChain.Start();
            Console.WriteLine("[ST] Transaction Serveur started");
            while (Program._continue)
            {
                TcpClient client = this.ServeurChain.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(this.ClientManager));
                clientThread.Start(client);
            }
            this.ServeurChain.Stop();
            Console.WriteLine("[ST] Transaction Serveur closed");
        }
    }
}