using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkAndToys
{
    internal class Program
    {
        private static int maximumToys(int[] prices, int k)
        {
            Array.Sort(prices);

            int sum = 0;
            int count = 0;
            foreach (int price in prices)
            {
                sum += price;
                if (sum >= k)
                {
                    break;
                }
                count++;
            }

            return count;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] prices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp));

            int result = maximumToys(prices, k);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
