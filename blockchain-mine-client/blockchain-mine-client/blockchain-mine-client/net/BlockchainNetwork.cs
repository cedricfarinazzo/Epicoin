using System.Threading;

namespace blockchain
{
    public class BlockchainNetwork
    {
        protected string host;
        protected int port;

        public BlockchainNetwork(string host, int port)
        {
            this.host = host;
            this.port = port;
        }
    }
}