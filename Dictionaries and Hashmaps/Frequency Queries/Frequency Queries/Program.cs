using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Frequency_Queries
{
    internal class Program
    {
        private static void IncreaseDictionary(Dictionary<int, int> dictionary, int key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key]++;
            }
            else
            {
                dictionary.Add(key, 1);
            }
        }

        private static void DecreaseDictionary(Dictionary<int, int> dictionary, int key)
        {
            if (dictionary.ContainsKey(key))
            {
                if (dictionary[key] > 1)
                {
                    dictionary[key]--;
                }
                else
                {
                    dictionary.Remove(key);
                }
            }
        }

        private static List<int> freqQuery(List<List<int>> queries)
        {
            var result = new List<int>();
            var counts = new Dictionary<int, int>(); // Key: element of query, Value: counts of query
            var frequencies = new Dictionary<int, int>(); // Key: count value of queries, Value: counts of key 

            foreach (var query in queries)
            {
                int operation = query[0];
                int element = query[1];

                if (operation == 1) // Increase
                {
                    if (counts.ContainsKey(element)) // At least one case before decrease
                    {
                        DecreaseDictionary(frequencies, counts[element]);
                    }
                    IncreaseDictionary(counts, element);
                    IncreaseDictionary(frequencies, counts[element]);
                }
                else if (operation == 2) // Decrease
                {
                    if (counts.ContainsKey(element))
                    {
                        DecreaseDictionary(frequencies, counts[element]);
                        DecreaseDictionary(counts, element);
                        if (counts.ContainsKey(element)) // At least one case after decrease
                        {
                            IncreaseDictionary(frequencies, counts[element]);
                        }
                    }
                }
                else // Search
                {
                    result.Add(frequencies.ContainsKey(element) ? 1 : 0);
                }
            }

            return result;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> ans = freqQuery(queries);

            textWriter.WriteLine(String.Join("\n", ans));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
