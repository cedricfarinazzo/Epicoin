using System.Net.Sockets;
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
        
        public static bool IsConnected(TcpClient _tcpClient)
        {
            try
            {
                if (_tcpClient != null && _tcpClient.Client != null && _tcpClient.Client.Connected)
                {
                    if (_tcpClient.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (_tcpClient.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }
    }
}