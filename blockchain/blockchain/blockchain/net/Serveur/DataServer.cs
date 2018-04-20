using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Sockets;
using SimpleHttpServer.Helper;

namespace blockchain
{
    public static class DataServer
    {
        public static IPAddress Address { get; set; }
        public static int Port { get; set; }
        
        public static bool Continue { get; set; }

        public static List<DataClient> Clients { get; set; }
        public static List<DataClient> Tasks { get; set; }

        public static Socket _sock { get; set; }

        public static void Initialize(IPAddress hosAddress, int port)
        {
            Address = hosAddress;
            Port = port;
            Continue = true;
            Clients = new List<DataClient>();
            Tasks = new List<DataClient>();
            _sock = new Socket(hosAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }


    }
}