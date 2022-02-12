using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography_Algorithms
{
    class BaconCipher
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

                    Console.WriteLine("\nEnter first key: ");
                    string firstKeyEnc = Console.ReadLine();

                    Console.WriteLine("\nEnter second key: ");
                    string secondKeyEnc = Console.ReadLine();

                    if (firstKeyEnc != secondKeyEnc)
                    {
                        Dictionary<char, string> baconAlphabetEnc = new Dictionary<char, string>();
                        baconAlphabetEnc = CreateAlphabetCodes(firstKeyEnc, secondKeyEnc);

                        Console.WriteLine("\nEncrypted message: " + Encrypt(encryptMessage.ToLower().ToCharArray(), baconAlphabetEnc));
                    }
                    else
                    {
                        Console.WriteLine("Keys must be different!");
                    }
                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();

                    string [] keys = FindKeys(decryptMessage);
                    string firstKeyDec = keys[0];
                    string secondKeyDec = keys[1];

                    string[] decryptMessageStr = decryptMessage.ToUpper().Split(' ');
                    Dictionary<char, string> baconAlphabetDec = new Dictionary<char, string>();
                    baconAlphabetDec = CreateAlphabetCodes(firstKeyDec.ToUpper(), secondKeyDec.ToUpper());

                    Console.WriteLine("\nEncrypted message: " + Decrypt(decryptMessageStr, baconAlphabetDec));
                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    break;
            }

            Console.ReadLine();
        }

        static string Encrypt(char[] secretMessage, Dictionary<char, string> baconAlphabet)
        {
            string encryptedMessage = "";

            foreach (char character in secretMessage)
            {
                if (baconAlphabet.ContainsKey(character))
                {
                    encryptedMessage += baconAlphabet[character];
                }
                else
                {
                    encryptedMessage += " ";
                }
            }

            return encryptedMessage.ToUpper();
        }

        static string Decrypt(string[] secretMessage, Dictionary<char, string> baconAlphabet)
        {
            string encryptedMessage = "";

            foreach (string character in secretMessage)
            {
                if (baconAlphabet.ContainsValue(character))
                {
                    encryptedMessage += baconAlphabet.FirstOrDefault(x => x.Value == character).Key;
                }
                else
                {
                    encryptedMessage += " ";
                }
            }

            return encryptedMessage;
        }

        static string[] FindKeys(string decryptMessage)
        {
            string[] keys = new string[2];
            keys[0] = Convert.ToString(decryptMessage[0]);

            for (int i = 1; i < decryptMessage.Length; i++)
            {
                if(decryptMessage[i].ToString() != keys[0] && decryptMessage[i].ToString() != " ")
                {
                    keys[1] = Convert.ToString(decryptMessage[i]);
                }
            }

            return keys;
        }

        static Dictionary<char, string> CreateAlphabetCodes(string firstKey, string secondKey)
        {
            string f = firstKey;
            string s = secondKey;

            Dictionary<char, string> codes = new Dictionary<char, string>()
            {
                { 'a', f+ f+ f+ f+ f},
                { 'b', f+ f+ f+ s+ f},
                { 'c', f+ f+ s+ f+ f},
                { 'd', f+ f+ s+ s+ f},
                { 'e', f+ s+ f+ f+ f},
                { 'f', f+ s+ f+ s+ f},
                { 'g', f+ s+ s+ f+ f},
                { 'h', f+ s+ s+ s+ f},
                { 'i', s+ f+ f+ f+ f},
                { 'j', s+ f+ f+ s+ f},
                { 'k', s+ f+ s+ f+ f},
                { 'l', s+ f+ s+ s+ f},
                { 'm', s+ s+ f+ f+ f},
                { 'n', f+ f+ f+ f+ s},
                { 'o', f+ f+ f+ s+ s},
                { 'p', f+ f+ s+ f+ s},
                { 'q', f+ f+ s+ s+ s},
                { 'r', f+ s+ f+ f+ s},
                { 's', f+ s+ f+ s+ s},
                { 't', f+ s+ s+ f+ s},
                { 'u', f+ s+ s+ s+ s},
                { 'v', s+ f+ f+ f+ s},
                { 'w', s+ f+ f+ s+ s},
                { 'x', s+ f+ s+ f+ s},
                { 'y', s+ f+ s+ s+ s},
                { 'z', s+ s+ f+ f+ s}
            };

            return codes;
        }
    }
}
