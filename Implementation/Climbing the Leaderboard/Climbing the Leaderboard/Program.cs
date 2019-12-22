using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing_the_Leaderboard
{
    class Program
    {
        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            var nonDuplicatedScores = scores.ToList().Distinct().ToArray();
            var result = new int[alice.Length];
            
            int index = nonDuplicatedScores.Length - 1;
            for (int i = 0; i < alice.Length; i++)
            {
                for (int j = index; j >= 0; j--)
                {
                    if (alice[i] <= nonDuplicatedScores[j])
                    {
                        result[i] = alice[i] == nonDuplicatedScores[j] ? j + 1 : j + 2;
                        index = j; // Mark endpoint
                        break;
                    }
                    else if (j == 0) // 1st case
                    {
                        result[i] = 1;
                    }
                }
            }
            return result.ToArray();
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int scoresCount = Convert.ToInt32(Console.ReadLine());
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int aliceCount = Convert.ToInt32(Console.ReadLine());
            int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp));
            int[] result = climbingLeaderboard(scores, alice);

            textWriter.WriteLine(string.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
