using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup1.BAL
{
    public static class Security
    {
        public static string Encrypt(string input)
        {
            return input + ", Encrypted";
        }

        public static string Decrypt(string input)
        {
            return input + ", Decrypted";
        }
    }
}
