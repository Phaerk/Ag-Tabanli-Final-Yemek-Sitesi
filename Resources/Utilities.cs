using System.Security.Cryptography;
using System.Text;
using Delicious_Food_Recipes.Models;

namespace Delicious_Food_Recipes.Resources
{
    public class Utilities
    {
        public static string EncryptKey(string key)
        {
            StringBuilder sk = new StringBuilder();

            using (SHA256 hash = SHA256.Create()) // Use SHA256.Create() instead of SHA256Managed
            {
                Encoding enc = Encoding.UTF8; // Encoding UTF8

                byte[] result = hash.ComputeHash(enc.GetBytes(key));

                foreach (byte b in result)
                {
                    sk.Append(b.ToString("x2")); // Concatenate the result in x2 hexadecimal format
                }
            }

            return sk.ToString();
        }
    }
}


