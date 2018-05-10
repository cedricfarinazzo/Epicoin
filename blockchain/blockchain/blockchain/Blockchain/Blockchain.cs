using System;
using System.Collections.Generic;

namespace blockchain
{
    public class Blockchain
    {
        public static readonly string Name = "epicoin";
        
        protected int difficulty = 5;
        protected List<Block> Chain = null;

        public List<Transaction> PendingTransactions;
        
        protected int miningReward = 10;
        
        public List<Block> BlockToMines;
        public Block BlockToMine;

        public readonly int timebtwblock = 42;
        
        protected string addressCreator;
        
        public List<Transaction> Pending => PendingTransactions;

        public int Difficulty => difficulty;

        public List<Block> Chainlist
        {
            get => Chain;
            set => Chain = value;
        }

        public Blockchain(string addressCreator)
        {
            this.Chain = new List<Block>();
            this.PendingTransactions = new List<Transaction>();
            this.addressCreator = addressCreator;
            this.BlockToMines =  new List<Block>();                
        }

        public Block CreateGenesisBlock()
        {
            Block genesisBlock = new Block(0, DateTime.Now.Ticks);
            genesisBlock.AddTransaction(new Transaction(null, this.addressCreator, 42));
            genesisBlock.AddTransaction(new Transaction(null, this.addressCreator, 500));
            genesisBlock.AddPreviousHash("");
            genesisBlock.MineBlock(this.difficulty);
            //Console.WriteLine("[B] Add genesis block");
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

        public void AddBlock(Block b)
        {
            this.Chain.Add(b);
        }
        
        private void SetBlock(Block b)
        {
            b.AddPreviousHash(this.GetLatestBlock().Hashblock);
        }

        private bool PrepareBlockToMine()
        {
            if (this.PendingTransactions.Count < Block.nb_trans)
            {
                return false;
            }

            int index = 0;
            if (this.BlockToMines.Count == 0)
            {
                index = this.GetLatestIndex();
            }
            else
            {
                index = this.BlockToMines[this.BlockToMines.Count - 1].Index;
            }
            
            this.BlockToMine = new Block(index + 1, DateTime.Now.Ticks);
            this.SetBlock(this.BlockToMine);
            while (!this.BlockToMine.IsFull() && Epicoin.Continue)
            {
                if (this.PendingTransactions.Count != 0)
                {
                    this.BlockToMine.AddTransaction(this.PendingTransactions[0]);
                    this.PendingTransactions.RemoveAt(0);
                }
            }
            
            this.BlockToMines.Add(this.BlockToMine);

            return true;
        }

        public void CreateBlock()
        {
            if (this.PrepareBlockToMine())
            {
                //Console.WriteLine("[C] Creating Block " + this.BlockToMine.Index + " with difficulty " + this.Difficulty);
                this.BlockToMine = null;
            }
        }

        public void NextBlock()
        {
            if (this.BlockToMines.Count != 0)
            {
                this.BlockToMines[0].PreviousHash = this.GetLatestBlock().Hashblock;
                this.BlockToMines[0].Timestamp = DateTime.Now.Ticks;
                //Console.WriteLine("[NB] Next to block " + this.BlockToMines[0].Index + " with difficulty " + this.Difficulty);
            }
        }
        
        
        public bool MinePendingTransaction(string minerAdress)
        {
            try
            {
                Block mineblock = new Block(
                                                this.BlockToMines[0].Index, 
                                                this.BlockToMines[0].Timestamp, 
                                                this.BlockToMines[0].Data, 
                                                this.BlockToMines[0].PreviousHash
                                            );
                long start = DateTime.Now.Ticks;
                mineblock.MineBlock(this.difficulty);
                long miningtime = DateTime.Now.Ticks - start;

                foreach (var block in this.Chain)
                {
                    if (block.Index == mineblock.Index)
                    {
                        return false;
                    }
                }
                
                this.AddBlock(mineblock);
                this.BlockToMines.RemoveAt(0);
                this.ManageDifficulty(miningtime);
                this.NextBlock();


                if (!this.IsvalidChain())
                {
                    this.Validate();
                    return false;
                }
            
                Transaction reward = new Transaction(null, minerAdress, this.miningReward);
                //Console.WriteLine("[M] Block mined " + mineblock.Index + " : " + mineblock.Hashblock + " by " + minerAdress);
                this.AddTransaction(reward);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void ManageDifficulty(long miningtime)
        {
            if (miningtime <= this.timebtwblock * 1000000)
            {
                this.difficulty++;
            }
            else
            {
                this.difficulty--;
                this.difficulty = this.difficulty < 0 ? 0 : this.difficulty;
            }
        }

        
        public bool NetworkMinePendingTransaction(string minerAdress, Block b, long miningtime, int difficuty)
        {
            try
            {
                foreach (var block in this.Chain)
                {
                    if (block.Index == b.Index)
                    {
                        return false;
                    }
                }
                
                string target = "";
                for (int i = 0; i < difficulty; i++)
                {
                    target += "0";
                }

                if (target != b.Hashblock.Substring(0, difficuty))
                {
                    return false;
                }
                
                this.AddBlock(b);
                this.ManageDifficulty(miningtime);



                if (!this.IsvalidChain())
                {
                    this.Validate();
                    return false;
                }
                
                this.BlockToMines.RemoveAt(0);
                this.NextBlock();
                
                Transaction reward = new Transaction(null, minerAdress, this.miningReward);
                //Console.WriteLine("[M] Block mined " + b.Index + " : " + b.Hashblock + " by " + minerAdress);
                this.AddTransaction(reward);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddTransaction(Transaction t)
        {
            try
            {
                //Console.Write("[T] transaction: " + (t.FromAddress ?? Blockchain.Name) + " - " + t.ToAddress + " : " + t.Amount);
                int amount = this.GetBalanceOfAddress(t.FromAddress);
                foreach (var pendingt in this.PendingTransactions)
                {
                    if (pendingt.FromAddress == t.FromAddress)
                    {
                        amount -= pendingt.Amount;
                    }
                }

                foreach (var block in this.BlockToMines)
                {
                    foreach (var pendingt in block.Data)
                    {
                        if (pendingt.FromAddress == t.FromAddress)
                        {
                            amount -= pendingt.Amount;
                        }
                    }
                }
                
                if (amount - t.Amount >= 0 || t.FromAddress == null)
                {
                    this.PendingTransactions.Add(t);
                    //Console.Write(" : accepted\n");
                    return true;
                }
                
                //Console.Write(" : rejeted\n");
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

                if (previousBlock.Index + 1 != currentBlock.Index)
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

        public void Merge(Blockchain newChain)
        {
            if (!newChain.IsvalidChain())
            {
                return;
            }
            if (newChain.Chainlist.Count > this.Chain.Count)
            {
                this.Chain = newChain.Chainlist;
                this.Validate();
            }
            else if (newChain.Chainlist.Count == this.Chain.Count)
            {
                int i;
                for (i = 0; i < this.Chain.Count; i++)
                {
                    if (this.Chain[i].Index != newChain.Chainlist[i].Index)
                    {
                        break;
                    }
                    
                    if (this.Chain[i].nonce != newChain.Chainlist[i].nonce)
                    {
                        break;
                    }
                    
                    if (this.Chain[i].PreviousHash != newChain.Chainlist[i].PreviousHash)
                    {
                        break;
                    }
                    
                    if (this.Chain[i].Hashblock != newChain.Chainlist[i].Hashblock)
                    {
                        break;
                    }
                    
                    if (this.Chain[i].Timestamp != newChain.Chainlist[i].Timestamp)
                    {
                        break;
                    }
                    
                    if (this.Chain[i].Data != newChain.Chainlist[i].Data)
                    {
                        break;
                    }
                }

                if (i < this.Chain.Count)
                {
                    for (; i < this.Chain.Count; i++)
                    {
                        List<Transaction> transList = this.Chain[i].Data;
                        this.Chain[i] = newChain.Chainlist[i];
                        foreach (var e in transList)
                        {
                            this.AddTransaction(e);
                        }
                    }
                    
                }
                this.Validate();
            }
            else
            {
                return;
            }
        }
    }
}