using System;

namespace Cryptography_Algorithms
{
    class HillCipher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEnter message to encrypt: ");
            string encryptMessage = Console.ReadLine();

            Console.WriteLine("Enter encryption key: ");
            string encryptKey = Console.ReadLine();
            encryptMessage = encryptMessage.ToLower();

            if (IsPerfectSquare(encryptKey.Length))
            {
                int[,] keyMatrix = GetKeyMatrix(encryptKey);
                int[,] messageMatrix = GetMessageMatrix(encryptKey, encryptMessage);
                string CipherText = Encrypt (keyMatrix, messageMatrix);

                Console.WriteLine("\nEncrypted message: " + CipherText);
            }
            else
            {
                Console.WriteLine("\nMessage should be an n*n matrix");
            }

            Console.ReadLine();
        }

        static bool IsPerfectSquare(int num)
        {
            double result = Math.Sqrt(num);
            bool isSquare = result % 1 == 0;

            return isSquare;
        }

        static int[,] GetKeyMatrix(string key)
        {
            int sqrtKey = (int)Math.Sqrt(key.Length);
            int[,] keyMatrix = new int[sqrtKey, sqrtKey];
            int k = 0;

            for (int i = 0; i < Math.Sqrt(key.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(key.Length); j++)
                {
                    keyMatrix[i, j] = Array.IndexOf(Alphabet.alphabet, key[k]);
                    k++;
                }
            }

            return keyMatrix;
        }

        static int[,] GetMessageMatrix(string key, string msg)
        {
            int sqrtKey = (int)Math.Sqrt(key.Length);
            int msgCol;

            if (msg.Length % sqrtKey == 0)
            {
                msgCol = (msg.Length) / sqrtKey;
            }
            else
            {
                msgCol = ((msg.Length) / sqrtKey) + 1;
            }

            int[,] messageMatrix = new int[sqrtKey, msgCol];
            char[] fullMsg = new char[(msgCol) * sqrtKey];
            int k = fullMsg.Length;

            for (int i = 0; i < msg.Length; i++)
            {
                fullMsg[i] = msg[i];
            }
            for (int i = msg.Length; i < fullMsg.Length; i++)
            {
                fullMsg[i] = ' ';
            }
            for (int i = 0; i <= msgCol; i++)
            {
                for (int j = 0; j < Math.Sqrt(key.Length); j++)
                {
                    if (k > 0)
                    {
                        messageMatrix[j, i] = Array.IndexOf(Alphabet.alphabet, fullMsg[fullMsg.Length - k]);
                        k--;
                    }
                }
            }

            return messageMatrix;
        }

        static string Encrypt(int[,] key, int[,] message)
        {
            int temp;
            string cipherText = "";
            int[,] cipher = new int[message.GetLength(0), message.GetLength(1)];

            for (int i = 0; i < key.GetLength(0); i++)
            {
                for (int j = 0; j < message.GetLength(1); j++)
                {
                    temp = 0;

                    for (int k = 0; k < key.GetLength(1); k++)
                    {
                        temp += key[i, k] * message[k, j];
                    }

                    cipher[i,j] = temp%26;
                }
            }
            for (int i = 0; i < cipher.GetLength(1); i++)
            {
                for (int j = 0; j < cipher.GetLength(0); j++)
                {
                    cipherText += Alphabet.alphabet[cipher[j, i]];
                }
            }

            return cipherText;
        }
    }

    static class Alphabet
    {
        public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}
