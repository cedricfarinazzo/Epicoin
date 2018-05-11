using System.Net;
using System.Net.Sockets;
using blockchain.tools;

namespace blockchain.net.client
{
    public static class DataClient
    {
        public static string Address { get; set; }
        public static IPHostEntry IpAddressEntry { get; set; }
        public static int Port { get; set; }
        
        public static bool Continue { get; set; }

        public static TcpClient Client { get; set; }

        public static Logger log;
        
        public static void Initialize(string hosAddress, int port)
        {
            Address = hosAddress;
            IpAddressEntry = Dns.Resolve(hosAddress);
            Port = port;
            Continue = true;
            Socket _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Client = new TcpClient() {Client = _sock};
            log = new Logger();
        }
    }
}