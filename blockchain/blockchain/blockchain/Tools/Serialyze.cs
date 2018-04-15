using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace blockchain
{
    static public class Serialyze
    {
        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static DataMine UnserializeDataMine(string s)
        {
            return JsonConvert.DeserializeObject<DataMine>(s);
        }
        
        public static Blockchain UnserializeBlockchain(string s)
        {
            return JsonConvert.DeserializeObject<Blockchain>(s);
        }
        
        public static DataTransaction UnserializeDataTransaction(string s)
        {
            return JsonConvert.DeserializeObject<DataTransaction>(s);
        }

        public static Transaction UnserializeTransaction(string s)
        {
            return JsonConvert.DeserializeObject<Transaction>(s);
        }
        
        public static Block UnserializeBlock(string s)
        {
            return JsonConvert.DeserializeObject<Block>(s);
        }
        
        public static Wallet UnserializeWallet(string s)
        {
            return JsonConvert.DeserializeObject<Wallet>(s);
        }

        public static List<string> UnserializeStringList(string s)
        {
            return JsonConvert.DeserializeObject<List<string>>(s);
        }
    }
}