using System;

namespace blockchain
{
    public class Transaction
    {
        public string FromAddress;
        public string ToAddress;
        public int Amount;
        public string Timestamp;

        /*
        public string FromAddress => fromAddress;

        public string ToAddress => toAddress;

        public int Amount => amount;

        public string Timestamp => timestamp;
        */

        public Transaction(string fromAddress, string toAddress, int amount)
        {
            this.FromAddress = fromAddress;
            this.ToAddress = toAddress;
            this.Amount = amount;
            this.Timestamp = DateTime.Now.ToString();
        }

        public override string ToString()
        {
            return "(Transaction){ at " + this.Timestamp + " from " + (FromAddress ?? Blockchain.Name) + " ; to " + this.ToAddress + " : " + this.Amount + " }";
        }
    }
}