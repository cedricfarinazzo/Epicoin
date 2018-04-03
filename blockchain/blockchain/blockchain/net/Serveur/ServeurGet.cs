﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class ServeurGet : BlockchainNetwork
    {
        protected TcpListener ServeurChain;
        protected Blockchain Coin;
        
        public ServeurGet(Blockchain coin, string host, int port)
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
            return Encoding.Default.GetBytes(Serialyze.Serialize(this.Coin));
        }

        public void ClientManager(object o)
        {
            this.maxthread--;
            TcpClient tcpClient = (TcpClient)o;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] buffer = this.GenData();
            byte[] bufferlenght = Encoding.Default.GetBytes(buffer.Length.ToString());
            clientStream.Write(bufferlenght, 0, bufferlenght.Length);
            Thread.Sleep(150);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Close();
            tcpClient.Close();
            this.maxthread++;
            return;
        }

        private void Listen()
        {
            this.ServeurChain.Start();
            Console.WriteLine("[SG] GetData Serveur started");
            while (Epicoin.Continue)
            {
                if (this.maxthread > 0)
                {
                    TcpClient client = this.ServeurChain.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(this.ClientManager));
                    clientThread.Start(client);
                }
            }
            this.ServeurChain.Stop();
            Console.WriteLine("[SG] GetData Serveur closed");
        }
    }
}