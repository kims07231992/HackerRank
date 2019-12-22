using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Cream_Parlor
{
    class Program
    {
        static int[] icecreamParlor(int m, int[] arr)
        {
            int[] result = new int[2];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int total = arr[i] + arr[j];
                    if (total == m)
                    {
                        result[0] = i + 1; // to match with starting number n
                        result[1] = j + 1; // to match with starting number n
                    }
                }
            }
            return result;
        }

        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                int n = Convert.ToInt32(Console.ReadLine());
                string[] arr_temp = Console.ReadLine().Split(' ');
                int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
                int[] result = icecreamParlor(m, arr);
                Console.WriteLine(String.Join(" ", result));
            }
        }
    }
}
