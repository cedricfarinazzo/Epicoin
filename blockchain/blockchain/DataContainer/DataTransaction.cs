namespace blockchain
{
    public class DataTransaction
    {
        public string PubKey;
        public string EncodeFromAddress;
        public string ToAddress;
        public int Amount;
        
        public DataTransaction(string pubKey, string encodeFromAddress, string toAddress, int amount)
        {
            this.PubKey = pubKey;
            this.EncodeFromAddress = encodeFromAddress;
            this.ToAddress = toAddress;
            this.Amount = amount;
        }
    }
}