using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ServeurSyncChain : BlockchainNetwork
    {
        protected TcpListener ServeurChain;
        
        protected List<TcpClient> ClientlList = new List<TcpClient>();
        
        public ServeurSyncChain(string host, int port)
            : base(host, port)
        {
            this.InitServeur();
            Thread serv = new Thread(this.Listen);
            serv.Start();
        }
        
        private void InitServeur()
        {
            this.ServeurChain = TcpListener.Create(this.port);
        }
        
        private Blockchain GetBlockchain(byte[] data)
        {
            string msgdata = Encoding.Default.GetString(data);
            try
            {
                return Serialyze.UnserializeBlockchain(msgdata);
            }
            catch
            {
                return null;
            }
            
        }
        
        public void ClientManager(object o)
        {
            this.maxthread--;
            TcpClient tcpClient = (TcpClient)o;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] buffer = new byte[8388608];
            clientStream.Read(buffer, 0, 8388608);
            Blockchain chain = this.GetBlockchain(buffer);
            if (chain != null)
            {
                Epicoin.Coin.Merge(chain);
            }
            clientStream.Close();
            tcpClient.Close();
            this.maxthread++;
            return;
        }
        
        private void Listen()
        {
            try
            {
                this.ServeurChain.Start();
            }
            catch (SocketException)
            { return;  }
            Console.WriteLine("[SS] SyncChain Serveur started");
            while (Epicoin.Continue)
            {
                if (this.maxthread > 0)
                {
                    TcpClient client = this.ServeurChain.AcceptTcpClient();
                    this.ClientlList.Add(client);
                    Thread clientThread = new Thread(new ParameterizedThreadStart(this.ClientManager));
                    clientThread.Start(client);
                }
            }
            foreach (var client in this.ClientlList)
            {
                client.Close();
            }
            this.ServeurChain.Stop();
            this.ServeurChain = null;
            Console.WriteLine("[SS] SyncChain Serveur closed");
            return;
        }
    }
}