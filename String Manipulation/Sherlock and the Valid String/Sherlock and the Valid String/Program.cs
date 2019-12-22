using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sherlock_and_the_Valid_String
{
    internal class Program
    {
        private static string isValid(string s)
        {
            var arpabetsDictionary = new SortedDictionary<char, int>();
            foreach (char c in s)
            {
                if (arpabetsDictionary.ContainsKey(c))
                {
                    arpabetsDictionary[c]++;
                }
                else
                {
                    arpabetsDictionary.Add(c, 1);
                }
            }

            bool isFirstTime = true;
            int max = arpabetsDictionary.First().Value;
            foreach (var item in arpabetsDictionary)
            {
                if (item.Value != max)
                {
                    if (isFirstTime &&
                                ((arpabetsDictionary.Last().Key == item.Key && item.Value == 1) // Last element is 1 case
                                || (item.Value != max - 1))) // Difference case
                    {
                        isFirstTime = false;
                        continue;
                    }
                    return "NO";
                }
            }
            return "YES";
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = isValid(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
