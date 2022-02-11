using System;

namespace Cryptography_Algorithms
{
    class PlayfairCipher
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
                    encryptMessage = encryptMessage.Replace(" ", "");

                    Console.WriteLine("\nWhich letter do you want to cut from the alphabet? ");
                    char missedEncKey = Convert.ToChar(Console.ReadLine());

                    char [,] alphabetMatrixEnc = CreateAlphabetMatrix(missedEncKey);

                    string encryptedMessage = Encrypt(encryptMessage.ToCharArray(), alphabetMatrixEnc);

                    Console.WriteLine("\nEncrypted message: " + encryptedMessage);
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    decryptMessage = decryptMessage.ToLower();
                    decryptMessage = decryptMessage.Replace(" ", "");

                    Console.WriteLine("\nWhich letter do you want to cut from the alphabet? ");
                    char missedDecKey = Convert.ToChar(Console.ReadLine());

                    char[,] alphabetMatrixDec = CreateAlphabetMatrix(missedDecKey);

                    string decryptedMessage = Decrypt(decryptMessage.ToCharArray(), alphabetMatrixDec);
                    Console.WriteLine("\nDecrypted message: " + decryptedMessage);
                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    break;

            }

            Console.ReadLine();
        }

        static char[,] CreateAlphabetMatrix(char key)
        {
            char[,] alphabetMatrix = new char[5, 5];
            int num = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(Alphabet.alphabet[num] == key)
                    {
                        num++;
                    }

                    alphabetMatrix[i, j] = Alphabet.alphabet[num];
                    num++;
                }
            }
            return alphabetMatrix;
        }

        static string Encrypt(char[] secretMessage, char[,] alphabet)
        {
            string cipherText = "";
            int[] indexes = new int[4];
            for (int i = 0; i < secretMessage.Length; i += 2)
            {
                if (secretMessage.Length % 2 == 1 && i == secretMessage.Length-1)
                {
                    FindKey(secretMessage[i], 'x', alphabet, indexes);
                    cipherText += SolveEncrypt(secretMessage[i], 'x', alphabet, indexes);
                }
                else
                {
                    FindKey(secretMessage[i], secretMessage[i + 1], alphabet, indexes);
                    cipherText += SolveEncrypt(secretMessage[i], secretMessage[i + 1], alphabet, indexes);
                }
            }
            
            return cipherText;
        }


        static string Decrypt(char[] secretMessage, char[,] alphabet)
        {
            string cipherText = "";
            int[] indexes = new int[4];

            for (int i = 0; i < secretMessage.Length; i += 2)
            {
                if (secretMessage.Length % 2 == 1 && i == secretMessage.Length - 1)
                {
                    FindKey(secretMessage[i], 'x', alphabet, indexes);
                    cipherText += SolveDecrypt(secretMessage[i], 'x', alphabet, indexes);
                }
                else
                {
                    FindKey(secretMessage[i], secretMessage[i + 1], alphabet, indexes);
                    cipherText += SolveDecrypt(secretMessage[i], secretMessage[i + 1], alphabet, indexes);
                }
            }

            return cipherText;
        }

        static int[] FindKey(char char1, char char2, char[,] alphabet, int[] indexes)
        {
            for (int i = 0, x = 0; i < 5; i++, x++)
            {
                for (int j = 0, y = 0; j < 5; j++, y++)
                {
                    if (alphabet[i, j] == char1)
                    {
                        indexes[0] = i;
                        indexes[1] = j;
                    }
                    if (alphabet[x, y] == char2)
                    {
                        indexes[2] = x;
                        indexes[3] = y;
                    }
                }
            }

            return indexes;
        }

        static string SolveEncrypt(char char1, char char2, char[,] alphabet, int[] indexes) 
        {
            int char1i = indexes[0], char1j = indexes[1], char2i = indexes[2], char2j = indexes[3];

            if (char1j == char2j)
            {
                if (char1i + 1 <= 4)
                    char1 = alphabet[char1i + 1, char1j];
                else
                    char1 = alphabet[0, char1j];

                if (char2i + 1 <= 4)
                    char2 = alphabet[char2i + 1, char2j];
                else
                    char2 = alphabet[0, char2j];
            }
            else if (char1i == char2i)
            {
                if (char1j + 1 <= 4)
                    char1 = alphabet[char1i, char1j + 1];
                else
                    char1 = alphabet[char1i, 0];

                if (char2j + 1 <= 4)
                    char2 = alphabet[char2i, char2j + 1];
                else
                    char2 = alphabet[char2i, 0];
            }
            else
            {
                char1 = alphabet[char1i, char2j];
                char2 = alphabet[char2i, char1j];
            }

            return (char1.ToString() + char2.ToString());
        }

        static string SolveDecrypt(char char1, char char2, char[,] alphabet, int[] indexes)
        {
            int char1i = indexes[0], char1j = indexes[1], char2i = indexes[2], char2j = indexes[3];
            
            if (char1j == char2j)
            {
                if (char1i - 1 >= 0)
                    char1 = alphabet[char1i - 1, char1j];
                else
                    char1 = alphabet[4, char1j];

                if (char2i - 1 >= 0)
                    char2 = alphabet[char2i - 1, char2j];
                else
                    char2 = alphabet[4, char2j];
            }
            else if (char1i == char2i)
            {
                if (char1j - 1 >= 0)
                    char1 = alphabet[char1i, char1j - 1];
                else
                    char1 = alphabet[char1i, 4];

                if (char2j + 1 >= 0)
                    char2 = alphabet[char2i, char2j - 1];
                else
                    char2 = alphabet[char2i, 4];
            }
            else
            {
                char1 = alphabet[char1i, char2j];
                char2 = alphabet[char2i, char1j];
            }

            return (char1.ToString() + char2.ToString());
        }
    }

    static class Alphabet
    {
        public static char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}
