using System;

namespace blockchain
{
    public class Transaction
    {
        protected string fromAddress;
        protected string toAddress;
        protected int amount;
        protected string timestamp;

        public string FromAddress => fromAddress;

        public string ToAddress => toAddress;

        public int Amount => amount;

        public string Timestamp => timestamp;

        public Transaction(string fromAddress, string toAddress, int amount)
        {
            this.fromAddress = fromAddress;
            this.toAddress = toAddress;
            this.amount = amount;
            this.timestamp = DateTime.Now.ToString();
        }

        public override string ToString()
        {
            return "(Transaction){ at " + this.Timestamp + " from " + (FromAddress ?? Blockchain.Name) + " ; to " + this.ToAddress + " : " + this.Amount + " }";
        }
    }
}