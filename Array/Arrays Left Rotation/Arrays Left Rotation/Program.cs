using System;
using System.IO;

namespace Arrays_Left_Rotation
{
    internal class Program
    {
        private static int[] rotLeft(int[] a, int d)
        {
            int lengthLeft = a.Length - d;
            int lengthRight = d;
            int[] rotatedArray = new int[a.Length];

            Array.Copy(a, lengthRight, rotatedArray, 0, lengthLeft); // Copy right side to left side
            Array.Copy(a, 0, rotatedArray, lengthLeft, lengthRight); // Copy left side to right side

            return rotatedArray;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            int[] result = rotLeft(a, d);

            textWriter.WriteLine(string.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
