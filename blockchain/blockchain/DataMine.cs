namespace blockchain
{
    public class DataMine
    {
        public int difficulty;
        public Block b;
        public Wallet w;

        public DataMine(int difficulty, Block b, Wallet w)
        {
            this.difficulty = difficulty;
            this.b = b;
            this.w = w;
        }
    }
}