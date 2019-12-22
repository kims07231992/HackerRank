using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Digit_Sum
{
    internal class Program
    {
        // https://www.hackerrank.com/challenges/recursive-digit-sum/problem
        private static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            string n = tokens_n[0];
            int k = Convert.ToInt32(tokens_n[1]);
            int result = superDigit(n, k);
            Console.WriteLine(result);
        }

        private static int superDigit(string n, int k)
        {
            double sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                sum += Int32.Parse(n[i].ToString());
            }
            sum *= k;
            return sum < 10 ? (int)sum : superDigit(sum.ToString(), 1);
        }
    }
}
