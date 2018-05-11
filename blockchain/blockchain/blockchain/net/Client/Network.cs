using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using blockchain.datacontainer;
using blockchain.blockchain;

namespace blockchain.net.client
{
    public static class Network
    {

        public static void Connect(string address, int port)
        {
            DataClient.Initialize(address, port);
            try
            {
                DataClient.Client.Client.Connect(DataClient.Address, DataClient.Port);
            }
            catch (Exception e)
            {
                DataClient.Client.Client.Connect(DataClient.IpAddressEntry.AddressList, port);
            }
        }
        
        private static Protocol ReceiveMessage()
        {
            while (DataClient.Client.Client.Connected && DataClient.Client.Client.Available <= 1)
            {
            }

            if (!DataClient.Client.Client.Connected)
                throw new Exception("Disconnected from server.");
            var message = new List<byte>();
            var stream = DataClient.Client.GetStream();

#pragma warning disable CS0652
            while (stream.DataAvailable)
                message.Add((byte) stream.ReadByte());
#pragma warning restore CS0652

            var msg = Formatter.ToObject<Protocol>(message.ToArray());
            return msg;
        }

        public static Block AskBlockNumber(int n)
        {
            Protocol reqProtocol = new Protocol(MessageType.AskBlocknumber) {Message = n.ToString()};
            byte[] buffer = Formatter.ToByteArray(reqProtocol);
            DataClient.Client.Client.Send(buffer, SocketFlags.None);
            Protocol receiveMessage = ReceiveMessage();
            if (receiveMessage.Type != MessageType.Response)
            {
                throw new Exception(receiveMessage.Message);
            }

            if (receiveMessage.Block == null)
            {
                return null;
            }

            return receiveMessage.Block;
        }
        
        public static DataMine AskBlockToMine()
        {
            Protocol reqProtocol = new Protocol(MessageType.AskBlockToMine);
            byte[] buffer = Formatter.ToByteArray(reqProtocol);
            DataClient.Client.Client.Send(buffer, SocketFlags.None);
            Protocol receiveMessage = ReceiveMessage();
            if (receiveMessage.Type != MessageType.Response)
            {
                throw new Exception(receiveMessage.Message);
            }

            if (receiveMessage.Mine == null)
            {
                return null;
            }

            return receiveMessage.Mine;
        }
        
        public static Blockchain AskChain()
        {
            Protocol reqProtocol = new Protocol(MessageType.AskChain);
            byte[] buffer = Formatter.ToByteArray(reqProtocol);
            DataClient.Client.Client.Send(buffer, SocketFlags.None);
            Protocol receiveMessage = ReceiveMessage();
            if (receiveMessage.Type != MessageType.Response)
            {
                throw new Exception(receiveMessage.Message);
            }

            if (receiveMessage.Chain == null)
            {
                return null;
            }

            return receiveMessage.Chain;
        }
        
        public static Block AskLatestBlock()
        {
            Protocol reqProtocol = new Protocol(MessageType.AskLastestBlock);
            byte[] buffer = Formatter.ToByteArray(reqProtocol);
            DataClient.Client.Client.Send(buffer, SocketFlags.None);
            Protocol receiveMessage = ReceiveMessage();
            if (receiveMessage.Type != MessageType.Response)
            {
                throw new Exception(receiveMessage.Message);
            }

            if (receiveMessage.Block == null)
            {
                return null;
            }

            return receiveMessage.Block;
        }
        
        public static string SendMinedBlock(DataMine mine)
        {
            Protocol reqProtocol = new Protocol(MessageType.MinedBlock) {Mine = mine};
            byte[] buffer = Formatter.ToByteArray(reqProtocol);
            DataClient.Client.Client.Send(buffer, SocketFlags.None);
            Protocol receiveMessage = ReceiveMessage();
            if (receiveMessage.Type != MessageType.Response)
            {
                throw new Exception(receiveMessage.Message);
            }

            return receiveMessage.Message;
        }

        public static string SendTransaction(DataTransaction trans)
        {
            Protocol reqProtocol = new Protocol(MessageType.Transaction) {Transaction = trans};
            byte[] buffer = Formatter.ToByteArray(reqProtocol);
            DataClient.Client.Client.Send(buffer, SocketFlags.None);
            Protocol receiveMessage = ReceiveMessage();
            if (receiveMessage.Type != MessageType.Response)
            {
                throw new Exception(receiveMessage.Message);
            }

            return receiveMessage.Message;
        }
    }
}