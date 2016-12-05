#region
using System;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
#endregion

namespace DagFan5
{
    internal static class Day
    {
        //MSDN exempel :)
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        private static void Main()
        {
            var input = Utilities.GetInput(5).ToString();
            var index = 0;
            string crypt = "";
            string password = "";
            string[] pw = new string[8];

            while (password.Length < 8)
            { 
                while (!crypt.StartsWith("00000"))
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        crypt = GetMd5Hash(md5Hash, input + index);
                    }
                    index++;
                }
                Console.WriteLine(crypt + "   " + index);
                string pos = crypt.Substring(5, 1);
                string inputC = crypt.Substring(6, 1);
                int posint;

                if (Regex.IsMatch(pos, @"\d")) 
                {
                    posint = int.Parse(pos);
                }
                else
                {
                    posint = 8;
                }
                
                if (posint < 8)
                {
                    if (pw[posint] == null)
                    {
                        pw[posint] = inputC;
                    }
                }
                //password = password + crypt.Substring(5, 1);
                password = pw[0] + pw[1] + pw[2] + pw[3] + pw[4] + pw[5] + pw[6] + pw[7];

                crypt = "";
                Console.WriteLine(password);
            }
            

            //Knuub
            Console.ReadKey();
        }
    }
}