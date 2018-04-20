﻿using System.Net;
using System.Net.Sockets;

namespace blockchain.Client
{
    public static class DataClient
    {
        public static IPAddress Address { get; set; }
        public static int Port { get; set; }
        
        public static bool Continue { get; set; }

        public static TcpClient Client { get; set; }

        public static Logger log;
        
        public static void Initialize(IPAddress hosAddress, int port)
        {
            Address = hosAddress;
            Port = port;
            Continue = true;
            Socket _sock = new Socket(hosAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Client = new TcpClient() {Client = _sock};
            log = new Logger();
        }
    }
}