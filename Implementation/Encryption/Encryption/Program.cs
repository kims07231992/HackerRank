using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static string encryption(string s)
        {
            int length = s.Length;
            int arrayLength = ((int)Math.Sqrt(length) * (int)Math.Sqrt(length)) == length
                ? (int)Math.Sqrt(length) // No round case
                : (int)Math.Sqrt(length) + 1; // Round down case
            char[,] array = new char[arrayLength, arrayLength];

            int index = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    if (index > length - 1) // Out of length case
                        break;
                    array[i, j] = s[index++];
                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    if (array[j, i] == '\0') // Empty case
                        continue;
                    sb.Append(array[j, i]);
                }
                sb.Append(" ");
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = encryption(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
