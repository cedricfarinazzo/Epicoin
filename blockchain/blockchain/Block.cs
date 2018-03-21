using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace blockchain
{
    public class Block
    {
        public const int nb_trans = 3;
        
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

        public Block(int index, string timestamp, List<Transaction> data = null, string previousHash = "")
        {
            this.index = index;
            this.timestamp = timestamp;
            this.data = data == null ? new List<Transaction>() : data;
            this.previousHash = previousHash;
        }

        public string calculateHash()
        {
            string serialyzedata = "{";
            for (int i = 0; i < this.data.Count; i++)
            {
                serialyzedata += this.data[i].ToString();
                if (i < this.data.Count - 1)
                {
                    serialyzedata += " ; ";
                }
            }

            serialyzedata += "}";
            
            string hash = Hash.Create(this.index.ToString() + this.timestamp + serialyzedata + this.previousHash + this.nonce);
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

        public void addTransaction(Transaction t)
        {
            if (this.data.Count < Block.nb_trans)
            {
                this.data.Add(t);
            }
            
        }

        public bool IsFull()
        {
            return this.data.Count == Block.nb_trans;
        }
    }
}