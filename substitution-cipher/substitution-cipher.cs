using System;

namespace Cryptography_Algorithms
{
    class SubstitutionCipher
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

                    encryptMessage = encryptMessage.ToLower();

                    string encryptedMessage = Encrypt(encryptMessage.ToCharArray());

                    Console.WriteLine("\nEncrypted message: " + encryptedMessage);
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    decryptMessage = decryptMessage.ToLower();

                    string decryptedMessage = Decrypt(decryptMessage.ToCharArray());

                    Console.WriteLine("\nDecrypted message: " + decryptedMessage);
                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    break;

            }

            Console.ReadLine();
        }

        static string Encrypt(char[] secretMessage)
        {
            //I used and random sample alphabet to encrypt and decrypt. Feel free to change it.
            char[] keyAlphabet = new char[] { 'g', 'o', 'v', 'a', 'y', 'p', 'q', 'i', 'r', 'x', 'f', 'c', 's', 'k', 'd', 'z', 'n', 'j', 't', 'm', 'w', 'l', 'u', 'h', 'b', 'e' };
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] == ' ')
                {
                    encryptedMessage[i] = ' ';
                    i++;
                }

                encryptedMessage[i] = keyAlphabet[Array.IndexOf(Alphabet.alphabet, secretMessage[i])];
            }

            return new string(encryptedMessage);
        }

        static string Decrypt(char[] secretMessage)
        {
            //I used and random sample alphabet to encrypt and decrypt. Feel free to change it.
            char[] keyAlphabet = new char[] { 'g', 'o', 'v', 'a', 'y', 'p', 'q', 'i', 'r', 'x', 'f', 'c', 's', 'k', 'd', 'z', 'n', 'j', 't', 'm', 'w', 'l', 'u', 'h', 'b', 'e' };
            char[] decryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] == ' ')
                {
                    decryptedMessage[i] = ' ';
                    i++;
                }

                decryptedMessage[i] = Alphabet.alphabet[Array.IndexOf(keyAlphabet, secretMessage[i])];
            }

            return new string(decryptedMessage);
        }
    }

    static class Alphabet
    {
        public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}
