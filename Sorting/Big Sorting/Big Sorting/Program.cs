using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_Sorting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] unsorted = new string[n];
            for (int unsorted_i = 0; unsorted_i < n; unsorted_i++)
            {
                unsorted[unsorted_i] = Console.ReadLine();
            }

            Array.Sort(unsorted, new StringNumberComparer());

            foreach (var s in unsorted)
            {
                Console.WriteLine(s);
            }
        }

        internal class StringNumberComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.Length != y.Length) // different number case
                    return x.Length - y.Length;

                // same length case
                for (int i = 0; i < x.Length; i++) // digit comparison
                {
                    char left = x[i];
                    char right = y[i];
                    if (left != right)
                        return left - right;
                }
                return 0; // same number case
            }
        }
    }
}
