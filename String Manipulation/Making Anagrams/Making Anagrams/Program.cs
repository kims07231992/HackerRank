using System;
using System.IO;
using System.Linq;

namespace Making_Anagrams
{
    internal class Program
    {
        static int makeAnagram(string a, string b)
        {
            var arpabets = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int count = 0;
            foreach (char arpabet in arpabets)
            {
                int countOfA = a.Count(c => c == arpabet); // Get number of letter in a
                int countOfB = b.Count(c => c == arpabet); // Get number of letter in b
                count += Math.Abs(countOfA - countOfB);
            }

            return count;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string a = Console.ReadLine();

            string b = Console.ReadLine();

            int res = makeAnagram(a, b);

            textWriter.WriteLine(res);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
