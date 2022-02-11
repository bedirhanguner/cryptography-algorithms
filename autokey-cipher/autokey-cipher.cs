using System;

namespace Cryptography_Algorithms
{
    class AutokeyCipher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to Encrypt or Decrypt?\n1. Encrypt\n2. Decrypt\n");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("\nEnter message to encrypt: ");
                    string encryptMessage = Console.ReadLine();

                    Console.WriteLine("Enter encryption key: ");
                    string encryptKey = Console.ReadLine();

                    encryptMessage = encryptMessage.ToLower();

                    string encryptedMessage = Encrypt(encryptMessage.ToCharArray(), encryptKey);

                    Console.WriteLine("\nEncrypted message: " + encryptedMessage);
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    Console.WriteLine("Enter decryption key: ");
                    string decryptKey = Console.ReadLine();

                    decryptMessage = decryptMessage.ToLower();

                    string decryptedMessage = Decrypt(decryptMessage.ToCharArray(), decryptKey);

                    Console.WriteLine("\nDecrypted message: " + decryptedMessage);
                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    break;
            }

            Console.ReadLine();
        }

        static string Encrypt(char[] secretMessage, string key)
        {
            char[] encryptedMessage = new char[secretMessage.Length];
            char[] tempArr = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length - key.Length; i++)
            {
                tempArr[i + key.Length] = secretMessage[i];
            }

            for (int i = 0; i < key.Length; i++)
            {
                tempArr[i] = key[i];
            }

            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] != ' ')
                {
                    encryptedMessage[i] = Alphabet.alphabet[(Array.IndexOf(Alphabet.alphabet, secretMessage[i]) + Array.IndexOf(Alphabet.alphabet, tempArr[i])) % 26];
                }
                else
                {
                    encryptedMessage[i] = secretMessage[i];
                }
            }

            return new string(encryptedMessage);
        }

        static string Decrypt(char[] secretMessage, string key)
        {
            char[] decryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] != ' ')
                {
                    decryptedMessage[i] = Alphabet.alphabet[(Array.IndexOf(Alphabet.alphabet, secretMessage[i]) - Array.IndexOf(Alphabet.alphabet, key[i]) + 26) % 26];
                }
                else
                {
                    decryptedMessage[i] = secretMessage[i];
                }
            }

            return new string(decryptedMessage);
        }
    }

    static class Alphabet
    {
        public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}
