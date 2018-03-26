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

        private byte[] GenData()
        {
            DataMine dataMine;
            byte[] datasend;
            if (this.Coin.BlockToMines.Count != 0)
            {
                dataMine = new DataMine(this.Coin.Difficulty, this.Coin.BlockToMines[0], null);
                datasend = Encoding.Default.GetBytes(Serialyze.serialize(dataMine));
            }
            else
            {
                dataMine = new DataMine(this.Coin.Difficulty, null, null);
                datasend = Encoding.Default.GetBytes(Serialyze.serialize(dataMine));
            }
            
            return datasend;
            
        }

        public void ClientManager(object o)
        {
            TcpClient tcpClient = (TcpClient)o;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] buffer = this.GenData();
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
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