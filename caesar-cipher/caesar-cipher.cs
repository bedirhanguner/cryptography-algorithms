using System;

namespace Cryptography_Algorithms
{
    class CaesarCipher
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
                    int encryptKey = Convert.ToInt32(Console.ReadLine());

                    encryptMessage = encryptMessage.ToLower();

                    string encryptedMessage = Encrypt(encryptMessage.ToCharArray(), encryptKey);

                    Console.WriteLine("\nEncrypted message: " + encryptedMessage);
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    Console.WriteLine("Enter decryption key: ");
                    int decryptKey = Convert.ToInt32(Console.ReadLine());

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

        static string Encrypt(char[] secretMessage, int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                char letter = secretMessage[i];
                char newLetter = alphabet[(key + Array.IndexOf(alphabet, letter)) % 26];

                encryptedMessage[i] = newLetter;
            }

            return new string(encryptedMessage);
        }

        static string Decrypt(char[] secretMessage, int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] decryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                char letter = secretMessage[i];
                char newLetter = alphabet[(Array.IndexOf(alphabet, letter) - key) % 26];

                decryptedMessage[i] = newLetter;
            }

            return new string(decryptedMessage);
        }
    }
}
