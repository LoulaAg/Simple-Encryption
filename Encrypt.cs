using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Encryption
{
    class Encrypt
    {
        static void Main(string[] args)
        {
            string cipher;
            string message = Console.ReadLine();                                //get the message to be encrypted
            string keystring = Console.ReadLine();                              //get the key - must be 0 - 64
                                                                                //Should alter to allow for bigger keys
            byte key = Convert.ToByte(keystring);                               //convert the key to a byte
            //  string placement = Console.ReadLine();  get the block to put the key in

            byte[] asciiBytes = Encoding.ASCII.GetBytes(message);               //get an array of the ascii values
            byte[] encryptedAscii = new byte[asciiBytes.Length+1];

            int i = 0;
            while (i != (asciiBytes.Length -2))                                 //loop through the array of asciis
            {
                asciiBytes[i] = (byte)((asciiBytes[i] + key)%64);               //F = (key + byte) mod 64
                asciiBytes[i + 1] = (byte)(asciiBytes[i] ^ asciiBytes[i + 1]);  //F(first block) XOR second block
                i++;
            }

            encryptedAscii = asciiBytes;                                 //to store the encrypted blocks

            //to encrypt the first byte, but is this needed? 
            //make sure decryption holds with this
            //i = asciiBytes.Length - 1;
            asciiBytes[i] = (byte)((asciiBytes[i] + key) % 64);                 //F = (key + byte) mod 64
            encryptedAscii[0] = (byte)(asciiBytes[i] ^ asciiBytes[0]);      //F(last block) XOR first block

            encryptedAscii[encryptedAscii.Length-1]= key;

            foreach(byte ascii in encryptedAscii)
            {
                Console.Write(ascii.ToString());
            }

            Console.Read();

        }
    }
}
