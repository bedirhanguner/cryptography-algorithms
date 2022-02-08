using System;

namespace Cryptography_Algorithms
{
    class VernamCipher
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

                    if (encryptMessage.Length == encryptKey.Length)
                    {
                        encryptMessage = encryptMessage.ToLower();
                        string encryptedMessage = Encrypt(encryptMessage.ToCharArray(), encryptKey.ToCharArray());

                        Console.WriteLine("\nEncrypted message: " + encryptedMessage);
                    }
                    else
                    {
                        Console.WriteLine("\nMessage and the key must have the same length.");
                    }
 
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    Console.WriteLine("Enter decryption key: ");
                    string decryptKey = Console.ReadLine();

                    if (decryptMessage.Length == decryptKey.Length)
                    {
                        decryptMessage = decryptMessage.ToLower();
                        string decryptedMessage = Decrypt(decryptMessage.ToCharArray(), decryptKey.ToCharArray());

                        Console.WriteLine("\nDecrypted message: " + decryptedMessage);
                    }
                    else
                    {
                        Console.WriteLine("\nMessage and the key must have the same length.");
                    }

                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    
                    break;

            }

            Console.ReadLine();
        }

        static string Encrypt(char[] secretMessage, char[] key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                encryptedMessage[i] = alphabet[((Array.IndexOf(alphabet, key[i]) + Array.IndexOf(alphabet, secretMessage[i])) % 26)];
            }

            return new string(encryptedMessage);
        }

        static string Decrypt(char[] secretMessage, char[] key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] decryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                decryptedMessage[i] = alphabet[((Array.IndexOf(alphabet, secretMessage[i]) - Array.IndexOf(alphabet, key[i]) + 26) % 26)];
            }

            return new string(decryptedMessage);
        }
    }
}
