using System.Threading;

namespace blockchain
{
    public class BlockchainNetwork
    {
        protected int maxthread = 50;
        
        protected string host;
        protected int port;

        public BlockchainNetwork(string host, int port)
        {
            this.host = host;
            this.port = port;
        }
    }
}