using System;

namespace Cryptography_Algorithms
{
    class TrithemiusCipher
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

                    Console.WriteLine("\nEnter initial shift (0 is default): ");
                    int initialShiftEnc = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nEncrypted message: " + Encrypt(encryptMessage.ToLower().ToCharArray(), initialShiftEnc));
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    Console.WriteLine("\nEnter initial shift (0 is default): ");
                    int initialShiftDec = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nDecrypted message: " + Decrypt(decryptMessage.ToLower().ToCharArray(), initialShiftDec));
                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    break;
            }

            Console.ReadLine();
        }

        static string Encrypt(char[] secretMessage, int shift)
        {
            char[] encryptedMessage = new char[secretMessage.Length];
            
            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] != ' ')
                {
                    encryptedMessage[i] = Alphabet.alphabet[(Array.IndexOf(Alphabet.alphabet, secretMessage[i]) + shift) % 26];
                    shift++;
                }
                else
                {
                    encryptedMessage[i] = secretMessage[i];
                }
            }

            return new string(encryptedMessage);
        }

        static string Decrypt(char[] secretMessage, int shift)
        {
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] != ' ')
                {
                    encryptedMessage[i] = Alphabet.alphabet[(Array.IndexOf(Alphabet.alphabet, secretMessage[i]) - shift + 26) % 26];
                    shift++;
                }
                else
                {
                    encryptedMessage[i] = secretMessage[i];
                }
            }

            return new string(encryptedMessage);
        }
    }

    static class Alphabet
    {
        public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}

