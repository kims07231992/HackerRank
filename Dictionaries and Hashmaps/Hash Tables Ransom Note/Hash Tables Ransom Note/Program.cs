using System;
using System.Collections.Generic;

namespace Hash_Tables_Ransom_Note
{
    internal class Program
    {
        private static void checkMagazine(string[] magazine, string[] note)
        {
            var wordDic = new Dictionary<int, int>(); // Key: HashCode, Value: Count

            foreach (string word in magazine)
            {
                int hashCode = word.GetHashCode();
                wordDic[hashCode] = wordDic.ContainsKey(hashCode)
                    ? wordDic[hashCode] + 1 // Increase
                    : 1; // Default as 1
            }

            foreach (string word in note)
            {
                int hashCode = word.GetHashCode();
                if (wordDic.ContainsKey(hashCode) 
                    && wordDic[hashCode] != 0) // Already used case
                {
                    wordDic[hashCode]--;
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
        }

        private static void Main(string[] args)
        {
            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            string[] magazine = Console.ReadLine().Split(' ');

            string[] note = Console.ReadLine().Split(' ');

            checkMagazine(magazine, note);
        }
    }
}
