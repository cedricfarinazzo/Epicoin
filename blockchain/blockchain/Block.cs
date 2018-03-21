using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace blockchain
{
    public class Block
    {
        protected const int nb_trans = 20;
        
        protected int index;
        protected string timestamp;
        protected List<Transaction> data;
        protected string previousHash;
        protected string hashblock;
        public int nonce = -1;


        public int Index => index;

        public string Timestamp => timestamp;

        public List<Transaction> Data => data;

        public string PreviousHash => previousHash;

        public string Hashblock
        {
            get => hashblock;
            set => hashblock = value;
        }

        public Block(int index, string timestamp, List<Transaction> data, string previousHash = "")
        {
            this.index = index;
            this.timestamp = timestamp;
            this.data = data;
            this.previousHash = previousHash;
        }

        public string calculateHash()
        {
            string hash = Hash.Create(this.index.ToString() + this.timestamp + this.data.ToString() + this.previousHash + this.nonce);
            return hash;
        }

        public void addPreviousHash(string h)
        {
            this.previousHash = h;
        }

        public void mineBlock(int difficulty)
        {
            Console.WriteLine("Starting mining new block ...");
            string hash = this.calculateHash();
            string target = "";
            for (int i = 0; i < difficulty; i++)
            {
                target += "0";
            }

            while (hash.Substring(0, difficulty) != target)
            {
                this.nonce++;
                hash = this.calculateHash();
            }

            this.Hashblock = hash;
            
            Console.WriteLine("Block mined : " + this.Hashblock);
        }
        
    }
}