using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort
{
    internal class Program
    {
        private static void countSwaps(int[] a)
        {
            int count = BubbleSort(a);
            int firstElement = a[0];
            int lastElement = a[a.Length - 1];
            Console.WriteLine($"Array is sorted in {count} swaps.");
            Console.WriteLine($"First Element: {firstElement}");
            Console.WriteLine($"Last Element: {lastElement}");
        }

        private static int BubbleSort(int[] array)
        {
            if (array == null)
            {
                return 0;
            }

            bool flag = true; // Flag to prevent unnecessary loop
            int endIndex = array.Length - 1;
            int count = 0; // Swap count
            while (endIndex >= 0)
            {
                if (!flag) // If looped without swapping
                {
                    break;
                }

                flag = false;
                for (int i = 0; i < endIndex; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        Swap(array, i, i + 1);
                        flag = true;
                        count++;
                    }
                }
                endIndex--;
            }

            return count;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            countSwaps(a);
        }
    }
}
