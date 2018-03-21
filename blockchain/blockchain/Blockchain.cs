using System;
using System.Collections.Generic;
using System.Dynamic;

namespace blockchain
{
    public class Blockchain
    {
        protected int difficulty = 4;
        protected List<Block> chain;

        protected List<Transaction> pendingTransactions;
        protected int miningReward = 10;

        public Blockchain()
        {
            this.chain = new List<Block>();
            this.pendingTransactions = new List<Transaction>();
            this.chain.Add(this.createGenesisBlock());
            
        }

        private Block createGenesisBlock()
        {
            Block genesisBlock = new Block(0, DateTime.Now.ToString(), new List<Transaction>(), "");
            genesisBlock.mineBlock(this.difficulty);
            return genesisBlock;
        }

        public Block getLatestBlock()
        {
            return this.chain[this.chain.Count - 1];
        }

        public int getLatestIndex()
        {
            return this.getLatestBlock().Index;
        }

        public void addBlock(Block b)
        {
            b.addPreviousHash(this.getLatestBlock().Hashblock);
            b.mineBlock(this.difficulty);
            this.chain.Add(b);
        }

        public bool IsvalidChain()
        {
            for (int i = 1; i < this.chain.Count; i++)
            {
                Block previousBlock = this.chain[i - 1];
                Block currentBlock = this.chain[i];

                if (currentBlock.Hashblock != currentBlock.calculateHash())
                {
                    return false;
                }

                if (previousBlock.Hashblock != currentBlock.PreviousHash)
                {
                    return false;
                }
            }

            return true;
        }

        public void Validate()
        {
            while (!this.IsvalidChain())
            {
                this.chain.RemoveAt(this.chain.Count - 1);
            }
        }
    }
}