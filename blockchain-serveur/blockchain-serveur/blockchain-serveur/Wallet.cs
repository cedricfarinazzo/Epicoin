using System;
using System.Runtime.CompilerServices;

namespace blockchain
{
    public class Wallet
    {
        protected string name;

        protected string address;
        
        public Wallet(string name)
        {
            this.name = name;
            this.GenAddress();
        }

        public void GenAddress()
        {
            Random r = new Random();
            int randomint = 0;
            for (int i = 0; i < 100; i++)
            {
                randomint += (i * 10) * r.Next();
            }

            this.address = Hash.Create(this.name + DateTime.Now.ToString() + randomint.ToString());
        }

        public string Address
        {
            get => address;
        }

        public string Name => name;
    }
}