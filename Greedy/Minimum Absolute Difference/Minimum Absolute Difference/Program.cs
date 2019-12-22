using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Absolute_Difference
{
    class Program
    {
        static int minimumAbsoluteDifference(int n, int[] arr)
        {
            Array.Sort(arr);
            int result = Math.Abs(arr[0] - arr[1]); // start value

            for (int i = 1; i < n - 1; i++)
            {
                int next = Math.Abs(arr[i] - arr[i + 1]);
                result = result < next ? result : next;
            }
            return result;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            int result = minimumAbsoluteDifference(n, arr);
            Console.WriteLine(result);
        }
    }
}
