using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Coin_Change_Problem
{
    class Program
    {
        static long getWays(long n, long[] c, int m)
        {
            if (n == 0)
                return 1;

            if (n < 0)
                return 0;

            if (m <= 0 && n >= 1)
                return 0;

            return getWays(n, c, m - 1) +
                   getWays(n - c[m - 1], c, m);
        }

        static long getWaysDP(long n, long[] c, int m)
        {
            //Time complexity of this function: O(mn)
            //Space Complexity of this function: O(n)

            long[] table = new long[n + 1];

            table[0] = 1;
            for (long i = 0; i < m; i++)
                for (long j = c[i]; j <= n; j++)
                    table[j] += table[j - c[i]];

            return table[n];
        }

        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] c_temp = Console.ReadLine().Split(' ');
            long[] c = Array.ConvertAll(c_temp, Int64.Parse);
            // Print the number of ways of making change for 'n' units using coins having the values given by 'c'
            long ways = getWaysDP(n, c, m);
            Console.WriteLine(ways);
        }
    }
}
