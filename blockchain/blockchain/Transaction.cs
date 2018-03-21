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

        public Transaction(string FromAddress, string ToAddress, int amount)
        {
            this.fromAddress = FromAddress;
            this.toAddress = ToAddress;
            this.amount = amount;
            this.timestamp = DateTime.Now.ToString();
        }

        public string ToString()
        {
            return "(Transaction){ at " + this.Timestamp + " from " + (FromAddress ?? Blockchain.name) + " ; to " + this.ToAddress + " : " + this.Amount + " }";
        }
    }
}