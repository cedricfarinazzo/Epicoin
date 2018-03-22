using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace blockchain
{
    public class Serveur : BlockchainNetwork
    {
        protected UdpClient ServeurChain;
        protected Blockchain Coin;
        
        public Serveur(Blockchain coin, string host, int port)
            : base(host, port)
        {
            this.Coin = coin;
            this.InitServeur();
        }

        private void InitServeur()
        {
            this.ServeurChain = new UdpClient(this.port);
            Console.WriteLine("Serveur started");
        }

        public void Listen()
        {
            while (true)
            {
                IPEndPoint client = null;
                byte[] data = ServeurChain.Receive(ref client);
                string msgdata = Encoding.Default.GetString(data);
                Console.WriteLine(msgdata);
                if (msgdata == "block")
                {
                    UdpClient ServeursendChain = new UdpClient();
                    Console.WriteLine("ask received");
                    DataMine dataMine = new DataMine(this.Coin.Difficulty, this.Coin.BlockToMine, null);
                    byte[] datasend = Encoding.Default.GetBytes(Serialyze.serialize(dataMine));
                    ServeursendChain.Send(datasend, datasend.Length, client.Address.ToString(), client.Port + 1);
                    ServeursendChain.Close();
                }
                else
                {
                    try
                    {
                        Console.WriteLine("Block received");
                        DataMine dataMine = (DataMine)Serialyze.unserialize(msgdata);
                        this.Coin.NetworkMinePendingTransaction(dataMine.w.Address, dataMine.b);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            this.ServeurChain.Close();
        }
    }
}