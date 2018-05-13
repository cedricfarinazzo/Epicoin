using System;
using blockchain.blockchain;

namespace blockchain.datacontainer
{
    [Serializable]
    public class DataChainStats
    {
        public string Name;
        public bool Valid;
        public int Lenght;
        public int LastIndex;
        public string LastBlockHash;
        public int Pending;
        public int Difficulty;

        public DataChainStats()
        {
            
        }
    }
}