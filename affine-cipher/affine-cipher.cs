using System;

namespace Cryptography_Algorithms
{
    class AffineCipher
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

                    Console.WriteLine("Enter two keys: ");
                    int firstEncryptKey = Convert.ToInt32(Console.ReadLine());
                    int secondEncryptKey = Convert.ToInt32(Console.ReadLine());

                    if (CalculateGcd(firstEncryptKey, 26) == 1)
                    {
                        encryptMessage = encryptMessage.ToLower();
                        string encryptedMessage = Encrypt(encryptMessage.ToCharArray(), firstEncryptKey, secondEncryptKey);

                        Console.WriteLine("\nEncrypted message: " + encryptedMessage);
                    }
                    else
                    {
                        Console.WriteLine(firstEncryptKey + " and 26 must be co-prime numbers.");
                    }
                        
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    Console.WriteLine("Enter two keys: ");
                    int firstDecryptKey = Convert.ToInt32(Console.ReadLine());
                    int secondDecryptKey = Convert.ToInt32(Console.ReadLine());

                    if (CalculateGcd(firstDecryptKey, 26) == 1)
                    {
                        decryptMessage = decryptMessage.ToLower();
                        string decryptedMessage = Decrypt(decryptMessage.ToCharArray(), firstDecryptKey, secondDecryptKey);

                        Console.WriteLine("\nDecrypted message: " + decryptedMessage);
                    }
                    else
                    {
                        Console.WriteLine(firstDecryptKey + " and 26 must be co-prime numbers.");
                    }

                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    break;

            }

            Console.ReadLine();
        }

        static int CalculateGcd(int a, int b)
        {
            if (a == 0)
                return 0;

            if (a == b)
                return a;

            if (a > b)
                return CalculateGcd(a - b, b);

            return CalculateGcd(a, b - a);
        }

        static string Encrypt(char[] secretMessage, int a, int b)
        {
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] != ' ')
                {
                    char letter = secretMessage[i];
                    char newLetter = Alphabet.alphabet[((a * Array.IndexOf(Alphabet.alphabet, letter)) + b) % 26];

                    encryptedMessage[i] = newLetter;
                }
                else
                {
                    encryptedMessage[i] = secretMessage[i];
                }
            }

            return new string(encryptedMessage);
        }

        static string Decrypt(char[] secretMessage, int a, int b)
        {
            char[] decryptedMessage = new char[secretMessage.Length];
            int inverseA = 0;
            int flag = 0;

            for (int i = 0; i < 26; i++)
            {
                flag = (a * i) % 26;

                if (flag == 1)
                {
                    inverseA = i;
                }
            }

            for (int i = 0; i < secretMessage.Length; i++)
            {
                if (secretMessage[i] != ' ')
                {
                    char letter = secretMessage[i];
                    char newLetter = Alphabet.alphabet[inverseA * ((Array.IndexOf(Alphabet.alphabet, letter) + 26) - b) % 26];

                    decryptedMessage[i] = newLetter;
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
