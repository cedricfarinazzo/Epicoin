using System;

namespace blockchain
{
    [Serializable]
    public class DataMine
    {
        public int difficulty;
        public Block block;
        public string address;
        public long timemining;
        
        public DataMine(int difficulty, Block block, string address, long timeminig = 0)
        {
            this.difficulty = difficulty;
            this.block = block;
            this.address = address;
            this.timemining = timeminig;
        }
    }
}