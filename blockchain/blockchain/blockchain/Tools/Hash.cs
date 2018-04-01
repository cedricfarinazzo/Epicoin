using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace blockchain
{
    public class Hash
    {
        public static string Create(string data)
        {
            var hash = (new SHA256Managed()).ComputeHash(Encoding.UTF8.GetBytes(data));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        public static string GpuCreate(string data)
        {
            
            return "";
        }
    }
}