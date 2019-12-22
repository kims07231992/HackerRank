using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Year_Chaos
{
    internal class Program
    {
        private static void minimumBribes(int[] q)
        {
            int totalBrides = 0;
            for (int i = q.Length - 1; i >= 0; i--)
            {
                int currentIndex = i;
                int originalIndex = q[i] - 1;

                if (q[i] - (i + 1) > 2) // More than 2 case
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
                for (int j = Math.Max(0, originalIndex -1); j < currentIndex; j++)
                {
                    if (q[i] < q[j])
                    {
                        totalBrides++;
                    }
                }
            }
            Console.WriteLine(totalBrides);
        }

        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));

                minimumBribes(q);
            }
        }
    }
}
