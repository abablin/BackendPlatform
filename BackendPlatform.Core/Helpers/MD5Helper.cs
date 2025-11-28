using System.Text;
using System.Security.Cryptography;

namespace BackendPlatform.Core.Helpers
{
    public static class MD5Helper
    {
        public static string Encrypt(string plainText)
        {
            return Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(plainText)));
        }
    }
}
