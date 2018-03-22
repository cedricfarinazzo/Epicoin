using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace blockchain
{
    public class Client : BlockchainNetwork
    {
        protected Wallet Worker;
        protected Block BlockToMine;
        protected int difficulty;
        
        public Client(string host, int port, Wallet worker)
            : base(host, port)
        {
            this.Worker = worker;
        }

        public void WaitBlock()
        {
            UdpClient listener = null;
            try
            {
                listener = new UdpClient(this.port+1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't connet to port " + (this.port+1));
                WaitBlock();
            }

            listener.Client.ReceiveTimeout = 1000;
            
            bool continu = true;
            int start = 1000000;
            while (continu && start >= 0)
            {
                try
                {
                    IPEndPoint ip = null;
                    byte[] data = listener.Receive(ref ip);
                    if (ip.Address.ToString() == this.host)
                    {
                        string msgdata = Encoding.Default.GetString(data);
                        DataMine datamine = (DataMine)Serialyze.unserialize(msgdata);
                        this.difficulty = datamine.difficulty;
                        this.BlockToMine = datamine.b;
                        continu = false;
                    }
                }
                catch (Exception e)
                {
                }

                start--;
            }
            listener.Close();
            Console.WriteLine("Block received");
        }

        public void Work()
        {
            UdpClient client = new UdpClient();
            client.Connect(host, port);
            Console.WriteLine("Connected client");
            
            while (true)
            {
                string askmsg = "block";
                byte[] msg = Encoding.Default.GetBytes(askmsg);

                client.Send(msg, msg.Length);
                
                WaitBlock();
                
                this.BlockToMine.MineBlock(this.difficulty);
                
                DataMine datamine = new DataMine(this.difficulty, this.BlockToMine, this.Worker);
                byte[] bytedata = Encoding.Default.GetBytes(Serialyze.serialize(datamine));
                client.Send(bytedata, bytedata.Length);

            }
        }
    }
}