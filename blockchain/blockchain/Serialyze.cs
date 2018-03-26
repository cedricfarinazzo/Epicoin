using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace blockchain
{
    static public class Serialyze
    {
        public static string serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static DataMine unserializeDataMine(string s)
        {
            return JsonConvert.DeserializeObject<DataMine>(s);
        }
        
        public static Blockchain unserializeBlockchain(string s)
        {
            return JsonConvert.DeserializeObject<Blockchain>(s);
        }
        
    }
}