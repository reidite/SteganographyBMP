using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace SteganographyBMP
{
    class Crypto
    {
        public static byte[] Encrypt(byte[] message, string password)
        {
            return CommonMethod(message, password);
        }

        public static byte[] Decrypt(byte[] message, string password)
        {
            return CommonMethod(message, password);
        }

        private static byte[] CommonMethod(byte[] message, string password)
        {
            byte[] salt = { 35, 1, 76 };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);
            byte[] key = pdb.GetBytes(128);
            byte[] retMessage = new byte[message.Length];
            for(int i =0; i< message.Length;i++)
            {
                int index = i % key.Length;
                retMessage[i] = (Byte)(key[index] ^ message[i]);
            }
            return retMessage;
        }
    }
}
