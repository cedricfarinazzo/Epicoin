using System;

namespace blockchain.datacontainer
{
    [Serializable]
    public class DataTransaction
    {
        public string PubKey;
        public string EncodeFromAddress;
        public string ToAddress;
        public string Amount;
        
        public DataTransaction(string pubKey, string encodeFromAddress, string toAddress, string amount)
        {
            this.PubKey = pubKey;
            this.EncodeFromAddress = encodeFromAddress;
            this.ToAddress = toAddress;
            this.Amount = amount;
        }
    }
}