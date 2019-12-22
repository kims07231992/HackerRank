using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Count_Triplets
{
    internal class Program
    {
        private static long countTriplets(List<long> arr, long r)
        {
            var countDictionary = new Dictionary<long, long>(); // Dictionary for count
            var tripletDictionary = new Dictionary<long, long>(); // Dictionary for triplet

            long count = 0;
            foreach (long number in arr)
            {
                // Step 1
                // If triplert has key, it means there are triplets from Step 2
                count += tripletDictionary.ContainsKey(number) ? tripletDictionary[number] : 0;

                // Step 2
                // If count has key, it means there was (number / r) from Step 3 
                if (countDictionary.ContainsKey(number))
                {
                    // By adding (number * r) to tripletDic, it will be part of (number / r /r) and (number / r)
                    // At the Step 1, it can be counted 
                    // Because being Step 1 and existing TripletDic mean it is complete triplet
                    if (tripletDictionary.ContainsKey(number * r))
                    {
                        tripletDictionary[number * r] += countDictionary[number];
                    }
                    else
                    {
                        tripletDictionary.Add(number * r, countDictionary[number]);
                    }
                }

                // Step 3
                // Add (number * r) to countDicnary
                if (countDictionary.ContainsKey(number * r))
                {
                    countDictionary[number * r]++;
                }
                else
                {
                    countDictionary.Add(number * r, 1);
                }
            }

            return count;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nr = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(nr[0]);

            long r = Convert.ToInt64(nr[1]);

            List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            long ans = countTriplets(arr, r);

            textWriter.WriteLine(ans);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
