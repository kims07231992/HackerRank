using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal
{
    // https://www.hackerrank.com/challenges/equal/problem
    internal class Program
    {
        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine()); // number of test case
            for (int i = 0; i < t; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine()); // number of colleagues
                string[] chocolates = Console.ReadLine().Split(' ');
                int[] colleagues = new int[n];
                for (int j = 0; j < colleagues.Length; j++) // default distribution
                {
                    colleagues[j] = Convert.ToInt32(chocolates[j]);
                }

                int count = 0;
                while (colleagues.Min() != colleagues.Max())
                {
                    int max = colleagues.Max();
                    int min = colleagues.Min();
                    int gap = max - min;
                    if (gap >= 5)
                    {
                        IncreaseN(colleagues, max, 5);
                    }
                    else if (gap >= 2)
                    {
                        IncreaseN(colleagues, max, 2);
                    }
                    else // 1
                    {
                        IncreaseN(colleagues, max, 1);
                    }
                    count++;
                }
                Console.WriteLine(count);
            }
        }

        private static void IncreaseN(int[] colleagues, int max, int n)
        {
            for (int i = 0; i < colleagues.Length; i++)
            {
                if (colleagues[i] == max)
                    continue;
                colleagues[i] += n;
            }
        }
    }
}
