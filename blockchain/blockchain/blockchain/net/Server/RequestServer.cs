using System;

namespace blockchain
{
    public static class RequestServer
    {
        public static Protocol Transaction(Protocol prot)
        {
            DataTransaction transaction = prot.Transaction;
            if (transaction == null)
            {
                return new Protocol(MessageType.Error) {Message = "Bad Transaction"};
            }

            if (transaction.EncodeFromAddress != Hash.CpuGenerate(transaction.PubKey))
            {
                return new Protocol(MessageType.Error) {Message = "Bad sender address"};
            }

            int TransAmount = 0;
            try
            {
                TransAmount = int.Parse(transaction.Amount);
            }
            catch (Exception e)
            {
                return new Protocol(MessageType.Error) {Message = "Bad amount"};
            }
            
            int amount =  DataServer.Chain.GetBalanceOfAddress(transaction.EncodeFromAddress);

            if (TransAmount > amount)
            {
                return new Protocol(MessageType.Error) {Message = "You do not have enough epicoins to do that!"};
            }
            
            blockchain.Transaction NewTransaction = new Transaction(transaction.EncodeFromAddress, transaction.ToAddress, TransAmount);
            bool success = DataServer.Chain.AddTransaction(NewTransaction);

            if (success)
            {
                return new Protocol(MessageType.Response) {Message = "Success"};
            }
            else
            {
                return new Protocol(MessageType.Response) {Message = "Failed to add transaction"};
            }
        }
        
        public static Protocol AskChain(Protocol prot)
        {
            Protocol resp = new Protocol(MessageType.Response);
            resp.Chain = DataServer.Chain;
            return resp;
        }
        
        public static Protocol AskLastestBlock(Protocol prot)
        {
            Protocol resp = new Protocol(MessageType.AskLastestBlock);
            resp.Block = DataServer.Chain.GetLatestBlock();
            return resp;
        }
        
        public static Protocol AskBlockNumber(Protocol prot)
        {
            if (string.IsNullOrEmpty(prot.Message))
            {
                return new Protocol(MessageType.Error) {Message = "Invalid block number"};
            }

            try
            {
                int number = int.Parse(prot.Message);
                Block b = DataServer.Chain.Chainlist[number];
                return new Protocol(MessageType.AskBlocknumber) {Block = b};
            }
            catch (Exception e)
            {
                return new Protocol(MessageType.Error) {Message = "Invalid block number"};
            }
        }        
        
        public static Protocol AskBlockToMine(Protocol prot)
        {
            if (DataServer.Chain.BlockToMines.Count == 0)
            {
                return new Protocol(MessageType.Error) {Message = "No Block to Mine"};
            }

            return new Protocol(MessageType.Response)
            {
                Mine = new DataMine(DataServer.Chain.Difficulty, DataServer.Chain.BlockToMines[0], null)
            };
        }
        
        public static Protocol MinedBlock(Protocol prot)
        {
            if (prot.Mine == null)
            {
                return new Protocol(MessageType.Error) {Message = "Empty block"};               
            }

            DataMine dataMine = prot.Mine;
            if (dataMine.block == null)
            {
                return new Protocol(MessageType.Error) {Message = "Empty block"};
            }
            
            if (dataMine.block.Data == null)
            {
                return new Protocol(MessageType.Error) {Message = "Block invalid"};
            }
            if (DataServer.Chain.BlockToMines[0].Index != dataMine.block.Index)
            {
                return new Protocol(MessageType.Error) {Message = "Block invalid"};
            }

            if (DataServer.Chain.BlockToMines[0].Timestamp != dataMine.block.Timestamp)
            {
                return new Protocol(MessageType.Error) {Message = "Block invalid"};
            }

            try
            {
                for (int i = 0; i < Block.nb_trans; i++)
                {
                    if (DataServer.Chain.BlockToMines[0].Data[i].Amount != dataMine.block.Data[i].Amount)
                    {
                        return new Protocol(MessageType.Error) {Message = "Block invalid"};
                    }

                    if (DataServer.Chain.BlockToMines[0].Data[i].FromAddress != dataMine.block.Data[i].FromAddress)
                    {
                        return new Protocol(MessageType.Error) {Message = "Block invalid"};
                    }

                    if (DataServer.Chain.BlockToMines[0].Data[i].ToAddress != dataMine.block.Data[i].ToAddress)
                    {
                        return new Protocol(MessageType.Error) {Message = "Block invalid"};
                    }

                    if (DataServer.Chain.BlockToMines[0].Data[i].Timestamp != dataMine.block.Data[i].Timestamp)
                    {
                        return new Protocol(MessageType.Error) {Message = "Block invalid"};
                    }
                }
            }
            catch (Exception e)
            {
                return new Protocol(MessageType.Error) {Message = "Block invalid"};
            }
            

            if (DataServer.Chain.BlockToMines[0].PreviousHash != dataMine.block.PreviousHash)
            {
                return new Protocol(MessageType.Error) {Message = "Block invalid"};
            }
            
            bool succes = DataServer.Chain.NetworkMinePendingTransaction(dataMine.address, dataMine.block, dataMine.timemining);
            if (succes)
            {
                return new Protocol(MessageType.Response) {Message = "Sucess"};
            }
            else
            {
                return new Protocol(MessageType.Error) {Message = "failed"};
            }
        }
        
        public static Protocol AskPeer(Protocol prot)
        {
            return new Protocol(MessageType.Response) {PeerList = DataServer.PeerList};
        }
    }
}