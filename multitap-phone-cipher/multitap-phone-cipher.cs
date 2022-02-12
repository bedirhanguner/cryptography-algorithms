using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography_Algorithms
{
    class T9Cipher
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

                    Console.WriteLine("\nEncrypted message: " + Encrypt(encryptMessage.ToLower().ToCharArray()));

                    break;

                case 2:
                    Console.WriteLine("\nEnter message to decrypt: ");
                    string decryptMessage = Console.ReadLine();
                    string[] decryptMessageStr = decryptMessage.ToUpper().Split(' ');

                    Console.WriteLine("\nEncrypted message: " + Decrypt(decryptMessageStr));
                    break;

                default:
                    Console.WriteLine("Enter a valid value.");
                    break;
            }

            Console.ReadLine();
        }

        static string Encrypt(char[] secretMessage)
        {
            string encryptedMessage = "";

            foreach (char character in secretMessage)
            {
                if (PhoneCode.codes.ContainsKey(character))
                {
                    encryptedMessage += PhoneCode.codes[character] + " ";
                }
            }

            return encryptedMessage.ToUpper();
        }

        static string Decrypt(string[] secretMessage)
        {
            string encryptedMessage = "";

            foreach (string character in secretMessage)
            {
                if (PhoneCode.codes.ContainsValue(character))
                {
                    encryptedMessage += PhoneCode.codes.FirstOrDefault(x => x.Value == character).Key;
                }
            }

            return encryptedMessage;
        }
    }

    static class PhoneCode
    {
        public static Dictionary<char, string> codes = new Dictionary<char, string>()
        {
            { 'a', "2"},
            { 'b', "22"},
            { 'c', "222"},
            { 'd', "3"},
            { 'e', "33"},
            { 'f', "333"},
            { 'g', "4"},
            { 'h', "44"},
            { 'i', "444"},
            { 'j', "5"},
            { 'k', "55"},
            { 'l', "555"},
            { 'm', "6"},
            { 'n', "66"},
            { 'o', "666"},
            { 'p', "7"},
            { 'q', "77"},
            { 'r', "777"},
            { 's', "7777"},
            { 't', "8"},
            { 'u', "88"},
            { 'v', "888"},
            { 'w', "9"},
            { 'x', "99"},
            { 'y', "999"},
            { 'z', "9999"},
            { ' ', "0" }
        };
    }
}