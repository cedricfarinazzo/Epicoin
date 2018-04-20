using System;

namespace blockchain
{
    public enum MessageType
    {
        Response,
        Error,      
        Transaction,
        AskChain,
        AskLastestBlock,
        AskBlocknumber,
        AskBlockToMine,
        MinedBlock,
        AskPeer,
        SendPeer
    }
    
    [Serializable]
    public class Protocol
    {
        public Protocol(MessageType type)
        {
            this.Type = type;
            this.Message = null;
            this.Transaction = null;
            this.Mine = null;
            this.Block = null;
            this.Chain = null;
        }
        
        public MessageType Type { get; set; }
        public string Message { get; set; }
        public DataTransaction Transaction { get; set; }
        public DataMine Mine { get; set; }
        public Block Block { get; set; }
        public Blockchain Chain { get; set; }
    }
}