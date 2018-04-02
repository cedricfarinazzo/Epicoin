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
            string PubKeySender = dataTransaction.PubKey;
            string SenderAddress = dataTransaction.EncodeFromAddress; //Rsa.Decrypt(PubKeySender, dataTransaction.EncodeFromAddress);
            string ToAddress = dataTransaction.ToAddress; // Rsa.Decrypt(PubKeySender, dataTransaction.ToAddress);
            string Amount = dataTransaction.Amount; //Rsa.Decrypt(PubKeySender, dataTransaction.Amount);
            int Amountint;
            try
            {
                Amountint = int.Parse(Amount);
            }
            catch (Exception e)
            {
                return;
            }
            
            if (Amountint <= 0)
            {
                return;
            }
            if (Hash.CpuGenerate(PubKeySender) != SenderAddress)
            {
                return;
            }

            Transaction newTransaction = new Transaction(SenderAddress, ToAddress, Amountint);
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
            while (Epicoin.Continue)
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