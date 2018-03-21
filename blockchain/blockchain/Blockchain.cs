using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace blockchain
{
    public class Blockchain
    {
        public const string name = "blockchain";
        
        protected int difficulty = 2;
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
            Block genesisBlock = new Block(0, DateTime.Now.ToString());
            genesisBlock.addTransaction(new Transaction(null, "gen", 42));
            genesisBlock.addPreviousHash("");
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

        private void addBlock(Block b)
        {
            this.chain.Add(b);
        }
        
        private void setBlock(Block b)
        {
            b.addPreviousHash(this.getLatestBlock().Hashblock);
        }

        public void minePendingTransaction(string minerAdress)
        {
            if (this.pendingTransactions.Count < Block.nb_trans)
            {
                return;
            }
            Block b = new Block(this.getLatestIndex() + 1, DateTime.Now.ToString());
            this.setBlock(b);
            while (!b.IsFull())
            {
                if (this.pendingTransactions.Count != 0)
                {
                    b.addTransaction(this.pendingTransactions[0]);
                    this.pendingTransactions.RemoveAt(0);
                }
            }
            
            b.mineBlock(this.difficulty);
            this.addBlock(b);
            
            Transaction reward = new Transaction(null, minerAdress, this.miningReward);
            
            this.AddTransaction(reward);
        }

        public bool AddTransaction(Transaction t)
        {
            Console.Write("transaction: " + (t.FromAddress ?? Blockchain.name) + " - " + t.ToAddress + " : " + t.Amount);
            if (this.getBalanceOfAddress(t.FromAddress) - t.Amount >= 0 || t.FromAddress == null)
            {
                this.pendingTransactions.Add(t);
                Console.Write(" : accepted\n");
                return true;
            }
            
            Console.Write(" : rejeted\n");
            return false;
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

        public int getBalanceOfAddress(string address)
        {
            int amount = 0;
            for (int i = 0; i < this.chain.Count; i++)
            {
                for (int j = 0; j < this.chain[i].Data.Count; j++)
                {
                    Transaction t = this.chain[i].Data[j];
                    if (t.FromAddress == address)
                    {
                        amount -= t.Amount;
                    }

                    if (t.ToAddress == address)
                    {
                        amount += t.Amount;
                    }
                }
            }
            
            return amount;
        }
    }
}