using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography_Algorithms
{
    class MorseCode
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
                    Console.WriteLine("\nEnter message to decrypt (use '/' for space): ");
                    string decryptMessage = Console.ReadLine();
                    
                    string[] decryptMessageStr = decryptMessage.ToLower().Split(' ');
                    Console.WriteLine("\nDecrypted message: " + Decrypt(decryptMessageStr));
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
                if (Code.codes.ContainsKey(character))
                {
                    encryptedMessage += Code.codes[character] + " ";
                }
                else if (character == ' ')
                {
                    encryptedMessage += "/ ";
                }
                else
                {
                    encryptedMessage += character + " ";
                }
            }

            return encryptedMessage;
        }

        static string Decrypt(string[] secretMessage)
        {
            string encryptedMessage = "";

            foreach (string character in secretMessage)
            {
                if (Code.codes.ContainsValue(character))
                {
                    
                    encryptedMessage += Code.codes.FirstOrDefault(x => x.Value == character).Key;
                }
                else if (character == "/")
                {
                    encryptedMessage += " ";
                }
                else
                {
                    encryptedMessage += character;
                }
            }

            return encryptedMessage;
        }
    }

    static class Code
    {
        public static Dictionary<char, string> codes = new Dictionary<char, string>()
        {
            {'a', ".-"},
            {'b', "-..."},
            { 'c', "-.-."},
            { 'd', "-.."},
            { 'e', "."},
            { 'f', "..-."},
            { 'g', "--."},
            { 'h', "...."},
            { 'i', ".."},
            { 'j', ".---"},
            { 'k', "-.-"},
            { 'l', ".-.."},
            { 'm', "--"},
            { 'n', "-."},
            { 'o', "---"},
            { 'p', ".--."},
            { 'q', "--.-"},
            { 'r', ".-."},
            { 's', "..."},
            { 't', "-"},
            { 'u', "..-"},
            { 'v', "...-"},
            { 'w', ".--"},
            { 'x', "-..-"},
            { 'y', "-.--"},
            { 'z', "--.."},
            { '0', "-----"},
            { '1', ".----"},
            { '2', "..---"},
            { '3', "...--"},
            { '4', "....-"},
            { '5', "....."},
            { '6', "-...."},
            { '7', "--..."},
            { '8', "---.."},
            { '9', "----."}
        };
    }
}
