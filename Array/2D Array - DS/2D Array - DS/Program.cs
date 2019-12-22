using System;
using System.IO;

namespace _2D_Array___DS
{
    public class Program
    {
        static int hourglassSum(int[][] arr)
        {
            int? biggestSum = null;
            int rowLength = arr.Length;

            for (int i = 0; i < rowLength; i++)
            {
                if (i + 2 >= rowLength)
                {
                    break;
                }

                int columnLength = arr[i].Length;
                for (int j = 0; j < columnLength; j++)
                {
                    if (j + 2 >= columnLength)
                    {
                        break;
                    }

                    int sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + // First 3 rows
                        arr[i + 1][j + 1] + // Second 1 row
                        arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2]; // Thrid 3 rows

                    biggestSum = biggestSum == null 
                        ? sum 
                        : biggestSum > sum ? biggestSum : sum;
                }
            }

            return biggestSum.Value;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
