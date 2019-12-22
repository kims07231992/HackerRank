using System;
using System.IO;

namespace Alternating_Characters
{
    internal class Program
    {
        private static int alternatingCharacters(string s)
        {
            int count = 0;
            char key = s[0];

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == key)
                {
                    count++;
                }
                else
                {
                    key = key == 'A' ? 'B' : 'A';
                }
            }

            return count;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = alternatingCharacters(s);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
