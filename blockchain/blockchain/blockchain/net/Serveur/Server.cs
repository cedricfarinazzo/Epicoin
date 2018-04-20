using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Mono.Ssdp;

namespace blockchain
{
    public class Server
    {
        public Server(int port)
        {
            DataServer.Initialize(IPAddress.Any, port);
        }

        public void Init()
        {
            DataServer._sock.Bind(new IPEndPoint(DataServer.Address, DataServer.Port));
        }

        public void Start()
        {
            Console.WriteLine("[S] Server Started.");
            Thread accept = new Thread(AcceptClients);
            accept.Priority = ThreadPriority.AboveNormal;
            accept.IsBackground = true;
            Thread tasks = new Thread(HandleRequest);
            tasks.Priority = ThreadPriority.Highest;
            tasks.IsBackground = true;
            Thread poll = new Thread(PollClients);
            poll.Priority = ThreadPriority.Highest;
            poll.IsBackground = true;

            try
            {
                accept.Start();
                tasks.Start();
                poll.Start();
                poll.Join();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("[S] Exception during execution of the server");
                Console.WriteLine(e);
            }
            return;
        }

        public void AcceptClients()
        {
            while (DataServer.Continue)
            {
                try
                {
                    Socket clientSocket = DataServer._sock.Accept();
                    TcpClient client = new TcpClient
                    {
                        Client = clientSocket
                    };
                    DataServer.Clients.Add(new DataClient(client));
                    
                }
                catch (Exception)
                {
                    break;l
                }
            }
        }

        public void PollClients()
        {
            
        }

        public void HandleTasks()
        {
            
        }

        public void HandleRequest()
        {
            
        }

        private Protocol Receive(TcpClient client)
        {
            var message = new List<byte>();
            NetworkStream stream = client.GetStream();

            while (stream.DataAvailable)
            {
                message.Add((byte) stream.ReadByte());
            }

            return Formatter.ToObject<Protocol>(message.ToArray());
        }
        
    }
}