using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace blockchain
{
    public class Blockchain
    {
        public const string Name = "blockchain";
        
        protected int difficulty = 3;
        protected List<Block> Chain;

        protected List<Transaction> PendingTransactions;
        protected int miningReward = 10;

        protected string addressCreator;
        
        public List<Transaction> Pending => PendingTransactions;

        public int Difficulty => difficulty;

        public Block BlockToMine;
        
        public Blockchain(string addressCreator)
        {
            this.Chain = new List<Block>();
            this.PendingTransactions = new List<Transaction>();
            this.addressCreator = addressCreator;
            this.Chain.Add(this.CreateGenesisBlock());
        }

        private Block CreateGenesisBlock()
        {
            Block genesisBlock = new Block(0, DateTime.Now.ToString());
            genesisBlock.AddTransaction(new Transaction(null, this.addressCreator, 42));
            genesisBlock.AddTransaction(new Transaction(null, this.addressCreator, 500));
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

        public bool PrepareBlockToMine()
        {
            if (this.PendingTransactions.Count < Block.nb_trans)
            {
                return false;
            }
            this.BlockToMine = new Block(this.GetLatestIndex() + 1, DateTime.Now.ToString());
            this.SetBlock(this.BlockToMine);
            while (!this.BlockToMine.IsFull())
            {
                if (this.PendingTransactions.Count != 0)
                {
                    this.BlockToMine.AddTransaction(this.PendingTransactions[0]);
                    this.PendingTransactions.RemoveAt(0);
                }
            }

            return true;
        }
        
        public bool MinePendingTransaction(string minerAdress)
        {
            try
            {
                this.PrepareBlockToMine();
            
                this.BlockToMine.MineBlock(this.difficulty);
            
                this.AddBlock(this.BlockToMine);

                if (!this.IsvalidChain())
                {
                    this.Validate();
                    return false;
                }
            
                Transaction reward = new Transaction(null, minerAdress, this.miningReward);
                Console.WriteLine("Block mined " + this.BlockToMine.Index + " : " + this.BlockToMine.Hashblock + " by " + minerAdress);
                this.AddTransaction(reward);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool NetworkMinePendingTransaction(string minerAdress, Block b)
        {
            if (this.BlockToMine.Index != b.Index)
            {
                return false;
            }
            
            foreach (var block in this.Chain)
            {
                if (b.Index == block.Index)
                {
                    return false; 
                }
            }
            
            this.AddBlock(b);

            if (!this.IsvalidChain())
            {
                this.Validate();
                return false;
            }
            
            Transaction reward = new Transaction(null, minerAdress, this.miningReward);
            Console.WriteLine("Block mined " + b.Index + " : " + b.Hashblock + " by " + minerAdress);
            this.AddTransaction(reward);
            return true;
        }

        public bool AddTransaction(Transaction t)
        {
            try
            {
                Console.Write("transaction: " + (t.FromAddress ?? Blockchain.Name) + " - " + t.ToAddress + " : " + t.Amount);
                int amount = this.GetBalanceOfAddress(t.FromAddress);
                foreach (var pendingt in this.PendingTransactions)
                {
                    if (pendingt.FromAddress == t.FromAddress)
                    {
                        amount -= pendingt.Amount;
                    }
                }
                
                if (amount - t.Amount >= 0 || t.FromAddress == null)
                {
                    this.PendingTransactions.Add(t);
                    Console.Write(" : accepted\n");
                    return true;
                }
                
                Console.Write(" : rejeted\n");
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            
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