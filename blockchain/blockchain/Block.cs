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
        protected int[] data;
        protected string previousHash;
        protected string hashblock;


        public int Index => index;

        public string Timestamp => timestamp;

        public int[] Data => data;

        public string PreviousHash => previousHash;

        public string Hashblock
        {
            get => hashblock;
            set => hashblock = value;
        }

        public Block(int index, string timestamp, int[] data, string previousHash = "")
        {
            this.index = index;
            this.timestamp = timestamp;
            this.data = data;
            this.previousHash = previousHash;
        }

        public string calculateHash()
        {
            string hash = Hash.Create(this.index.ToString() + this.timestamp + this.data.ToString() + this.previousHash);
            return hash;
        }

        public void addPreviousHash(string h)
        {
            this.previousHash = h;
        }
        
    }
}