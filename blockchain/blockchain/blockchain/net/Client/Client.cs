using System.Net;

namespace blockchain.Client
{
    public static class Client
    {
        public static void Init(IPAddress address, int port)
        {
            Network.Connect(address, port);
        }
    }
}