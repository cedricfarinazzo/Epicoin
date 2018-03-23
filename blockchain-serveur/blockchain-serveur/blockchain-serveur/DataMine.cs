namespace blockchain
{
    public class DataMine
    {
        public int difficulty;
        public Block b;
        public Wallet w;
        public long timemining;
        
        public DataMine(int difficulty, Block b, Wallet w, long timeminig = 0)
        {
            this.difficulty = difficulty;
            this.b = b;
            this.w = w;
            this.timemining = timeminig;
        }
    }
}