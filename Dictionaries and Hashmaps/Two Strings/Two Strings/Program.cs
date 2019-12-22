using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Strings
{
    internal class Program
    {
        private static string twoStrings(string s1, string s2)
        {
            var arpabets = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            
            foreach(char c in arpabets)
            {
                if (s1.IndexOf(c) > -1 && s2.IndexOf(c) > -1)
                {
                    return "YES";
                }
            }
            return "NO";
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s1 = Console.ReadLine();

                string s2 = Console.ReadLine();

                string result = twoStrings(s1, s2);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
