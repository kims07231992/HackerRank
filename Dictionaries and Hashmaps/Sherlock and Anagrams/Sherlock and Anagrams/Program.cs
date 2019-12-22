using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sherlock_and_Anagrams
{
    internal class Program
    {
        private static int sherlockAndAnagrams(string s)
        {
            int pairs = 0;

            for (int i = 1; i < s.Length; i++) // Length of substring
            {
                var anagrams = new Dictionary<string, int>(); // Key: substring, Value: pair
                for (int j = 0; j <= s.Length - i; j++)
                {
                    string sub = string.Concat(s.Substring(j, i).OrderBy(c => c)); // Rearrange for an unique key
                    if (!anagrams.ContainsKey(sub))
                    {
                        anagrams.Add(sub, 1);
                    }
                    else
                    {        
                        pairs += anagrams[sub]++; // Part of (n * (n + 1)) / 2
                    }
                }
            }

            return pairs;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = sherlockAndAnagrams(s);
                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
