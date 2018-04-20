using System.Net.Sockets;

namespace blockchain
{
    public class DataClient
    {
        public TcpClient Client { get; }
        
        public bool IsQueued { get; set; }

        public DataClient(TcpClient client)
        {
            this.Client = client;
            this.IsQueued = false;
        }

        public bool Available()
        {
            if (this.IsQueued)
            {
                return false;
            }

            return Client.Available > 0;
        }
    }
}