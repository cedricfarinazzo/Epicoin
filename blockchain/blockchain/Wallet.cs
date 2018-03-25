using System;
using System.Runtime.CompilerServices;

namespace blockchain
{
    public class Wallet
    {
        public string Name;

        public string Address;

        public string PrivKey;
        public string PubKey;
        
        public Wallet(string name)
        {
            this.Name = name;
            this.GenNewAddress();
        }

        public void GenNewAddress()
        {
            string[] data = Rsa.GenKey(2048);
            this.PrivKey = data[0];
            this.PubKey = data[1];
            this.Address = Hash.Create(this.PubKey);
        }
    }
}