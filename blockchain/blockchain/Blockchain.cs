using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace blockchain
{
    public class Blockchain
    {
        public const string Name = "blockchain";
        
        protected int difficulty = 6;
        protected List<Block> Chain;

        protected List<Transaction> PendingTransactions;
        protected int miningReward = 10;

        public List<Transaction> Pending => PendingTransactions;

        public Blockchain()
        {
            this.Chain = new List<Block>();
            this.PendingTransactions = new List<Transaction>();
            this.Chain.Add(this.CreateGenesisBlock());
            
        }

        private Block CreateGenesisBlock()
        {
            Block genesisBlock = new Block(0, DateTime.Now.ToString());
            genesisBlock.AddTransaction(new Transaction(null, "gen", 42));
            genesisBlock.AddPreviousHash("");
            genesisBlock.MineBlock(this.difficulty);
            return genesisBlock;
        }

        public Block GetLatestBlock()
        {
            return this.Chain[this.Chain.Count - 1];
        }

        public int GetLatestIndex()
        {
            return this.GetLatestBlock().Index;
        }

        private void AddBlock(Block b)
        {
            this.Chain.Add(b);
        }
        
        private void SetBlock(Block b)
        {
            b.AddPreviousHash(this.GetLatestBlock().Hashblock);
        }

        public void MinePendingTransaction(string minerAdress)
        {
            if (this.PendingTransactions.Count < Block.nb_trans)
            {
                return;
            }
            Block b = new Block(this.GetLatestIndex() + 1, DateTime.Now.ToString());
            this.SetBlock(b);
            while (!b.IsFull())
            {
                if (this.PendingTransactions.Count != 0)
                {
                    b.AddTransaction(this.PendingTransactions[0]);
                    this.PendingTransactions.RemoveAt(0);
                }
            }
            
            b.MineBlock(this.difficulty);
            this.AddBlock(b);

            if (!this.IsvalidChain())
            {
                this.Validate();
                return;
            }
            
            Transaction reward = new Transaction(null, minerAdress, this.miningReward);
            
            this.AddTransaction(reward);
        }

        public bool AddTransaction(Transaction t)
        {
            Console.Write("transaction: " + (t.FromAddress ?? Blockchain.Name) + " - " + t.ToAddress + " : " + t.Amount);
            if (this.GetBalanceOfAddress(t.FromAddress) - t.Amount >= 0 || t.FromAddress == null)
            {
                this.PendingTransactions.Add(t);
                Console.Write(" : accepted\n");
                return true;
            }
            
            Console.Write(" : rejeted\n");
            return false;
        }

        public bool IsvalidChain()
        {
            for (int i = 1; i < this.Chain.Count; i++)
            {
                Block previousBlock = this.Chain[i - 1];
                Block currentBlock = this.Chain[i];

                if (currentBlock.Hashblock != currentBlock.CalculateHash())
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
                this.Chain.RemoveAt(this.Chain.Count - 1);
            }
        }

        public int GetBalanceOfAddress(string address)
        {
            int amount = 0;
            for (int i = 0; i < this.Chain.Count; i++)
            {
                for (int j = 0; j < this.Chain[i].Data.Count; j++)
                {
                    Transaction t = this.Chain[i].Data[j];
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