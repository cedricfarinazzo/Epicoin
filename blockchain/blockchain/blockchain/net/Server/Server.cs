using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using blockchain.blockchain;

namespace blockchain.net.server
{
    public class Server
    {
        public Server(int port, Blockchain chain)
        {
            UPnP upnp = new UPnP(port);
            DataServer.Initialize(IPAddress.Any, port, chain);
            this.Init();
        }

        public void Init()
        {
            DataServer._sock.Bind(new IPEndPoint(DataServer.Address, DataServer.Port));
            DataServer._sock.Listen(42);
        }

        public void Start()
        {
            Log(ConsoleColor.Green, "[", "S", "] Server Started.");
            Thread accept = new Thread(AcceptClients);
            accept.Priority = ThreadPriority.AboveNormal;
            accept.IsBackground = true;
            Thread tasks = new Thread(HandleTasks);
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
                Log(ConsoleColor.DarkRed, "[", "S", "] Exception during execution of the server");
                Console.WriteLine(e);
                throw;
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
                    Log(ConsoleColor.Green, "[", "S", "] Accept connection from " + clientSocket.RemoteEndPoint.ToString());
                    TcpClient client = new TcpClient
                    {
                        Client = clientSocket
                    };
                    DataServer.Clients.Add(new DataTcpClient(client));
                    
                }
                catch (Exception)
                {
                    break;
                }
            }
            return;
        }

        public void PollClients()
        {
            while (true)
            {
                int i = 0;
                while (i < DataServer.Clients.Count)
                {
                    try
                    {
                        var client = DataServer.Clients[i];
                        if (client == null || !client.Client.Connected)
                            DataServer.Clients.Remove(client);
                        else if (client.Available())
                        {
                            client.IsQueued = true;
                            DataServer.Tasks.Enqueue(client);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    i++;
                }
            }
            return;
        }

        public void HandleTasks()
        {
            while (true)
            {
                if (DataServer.Tasks.Count == 0)
                {
                    continue;
                }

                DataTcpClient client = DataServer.Tasks.Dequeue();

                try
                {
                    Thread requestTh = new Thread(() => this.HandleRequests(client)) { IsBackground = true};
                    requestTh.Start();
                }
                catch (Exception e)
                {
                    client.IsQueued = false;
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            return;
        }

        public void HandleRequests(DataTcpClient client)
        {

            Protocol msg = Receive(client.Client);
            Protocol resp;
            if (msg != null)
            {
                switch (msg.Type)
                {
                    case MessageType.AskBlocknumber:
                        resp = RequestServer.AskBlockNumber(msg);
                        break;
                            
                    case MessageType.AskBlockToMine:
                        resp = RequestServer.AskBlockToMine(msg);
                        break;
                        
                    case MessageType.AskChain:
                        resp = RequestServer.AskChain(msg);
                        break;
                        
                    case MessageType.AskLastestBlock:
                        resp = RequestServer.AskLastestBlock(msg);
                        break;
                        
                    case MessageType.AskPeer:
                        resp = RequestServer.AskPeer(msg);
                        break;
                        
                    case MessageType.MinedBlock:
                        resp = RequestServer.MinedBlock(msg);
                        break;
                        
                    case MessageType.Transaction:
                        resp = RequestServer.Transaction(msg);
                        break;
                        
                    default:
                        resp = new Protocol(MessageType.Error)
                            { Message = "You did something, but I don't know what." };
                        break;
                }
            }
            else
            {
                resp = new Protocol(MessageType.Error)
                    { Message = "You did something, but I don't know what." };
            }
            LogRequest(msg.Type, client);
            
            Send(client.Client, resp);
            client.IsQueued = false;
            return;
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

        private void Send(TcpClient client, Protocol protocol)
        {
            client.Client.Send(Formatter.ToByteArray(protocol));
            return;
        }

        public static void LogRequest(MessageType type, DataTcpClient client)
        {
            ConsoleColor c;
            string stype = "";
            if (type == null)
            {
                stype = "Unknown";
                c = ConsoleColor.Red;
            }
            else if (type == MessageType.Error)
            {
                c = ConsoleColor.Red;
                stype = type.ToString();
            }
            else
            {
                c = ConsoleColor.Green;
                stype = type.ToString();
            }
            Log(c, "[", "SINFO", "][" + stype + "] request from " + client.Client.Client.RemoteEndPoint.ToString());
        }
        
        public static void Log(ConsoleColor color, string pre, string middle, string suf)
        {
            Console.Write(pre);
            Console.ForegroundColor = color;
            Console.Write(middle);
            Console.ResetColor();
            Console.WriteLine(suf);
        }
        
    }
}