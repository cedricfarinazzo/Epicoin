using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace blockchain.tools
{
    public class Hash
    {
        public static string CpuGenerate(string data)
        {
            var hash = (new SHA256Managed()).ComputeHash(Encoding.UTF8.GetBytes(data));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        public static string GpuGenerate(string data)
        {
            
            return "";
        }
    }
}