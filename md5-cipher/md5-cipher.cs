using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography_Algorithms
{
    class Md5Cipher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter message to encrypt: ");
            string encryptMessage = Console.ReadLine();

            string cipherText = Encrypt(encryptMessage);

            Console.WriteLine("\nEncrypted message: " + cipherText);
            Console.ReadLine();
        }

        static string Encrypt(string secretMessage)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(secretMessage);
                byte[] hashBytes = md5Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                return hash;
            }
        }
    }
}
