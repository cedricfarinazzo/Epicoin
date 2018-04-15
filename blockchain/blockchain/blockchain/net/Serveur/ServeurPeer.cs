using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ServeurPeer : BlockchainNetwork
    {
        protected TcpListener ServeurChain;
        
        protected List<TcpClient> ClientlList = new List<TcpClient>();
        
        public ServeurPeer(string host, int port)
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
        
        public void ClientManager(object o)
        {
            this.maxthread--;
            TcpClient tcpClient = (TcpClient)o;
            NetworkStream clientStream = tcpClient.GetStream();
            if (!Epicoin.PeerList.Contains(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString()))
            {
                Epicoin.PeerList.Add(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString());
            }
            byte[] buffer = new byte[8096];
            clientStream.Read(buffer, 0, buffer.Length);
            List<string> address = Serialyze.UnserializeStringList(Encoding.Default.GetString(buffer));
            for (int i = 0; i < address.Count; i++)
            {
                if (Epicoin.PeerList.Contains(address[i]))
                {
                    Epicoin.PeerList.Add(address[i]);
                }
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
            Console.WriteLine("[SP] Peer Serveur started");
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
            Console.WriteLine("[SP] Peer Serveur closed");
            return;
        }
    }
}