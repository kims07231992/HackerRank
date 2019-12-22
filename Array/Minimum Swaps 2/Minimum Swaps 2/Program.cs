using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Swaps_2
{
    internal class Program
    {
        private static int minimumSwaps(int[] arr)
        {
            int totalSwap = 0;

            int i = 0;
            while (i < arr.Length - 1)
            {
                int currentValue = arr[i];
                int originalValue = i + 1;

                if (currentValue != originalValue)
                {
                    if (currentValue >= arr.Length) // Value more than length case
                    {
                        int j = arr.Length - 1;
                        while (j >= 0)
                        {
                            if (arr[j] < currentValue)
                            {
                                Swap(arr, i, j);
                                totalSwap++;
                                break;
                            }
                            j--;
                        }
                    }
                    else
                    {
                        int j = currentValue - 1; // Index of current value
                        Swap(arr, i, j);
                        totalSwap++;
                    }
                }
                else
                {
                    i++;
                }
            }

            return totalSwap;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            int res = minimumSwaps(arr);

            textWriter.WriteLine(res);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
