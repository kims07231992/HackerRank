using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Balanced_Brackets
{
    internal class Program
    {
        private static string isBalanced(string s)
        {
            var stack = new Stack<char>();

            foreach (char bracket in s)
            {
                if (IsLeft(bracket))
                {
                    stack.Push(bracket);
                }
                else // Right case
                {
                    if (stack.Count <= 0)
                    {   
                        return "NO";
                    }
                    char left = stack.Pop();
                    if (!IsPair(left, bracket))
                    {
                        return "NO";
                    }
                }
            }
            return stack.Count <= 0 ? "YES" : "NO";
        }

        private static bool IsLeft(char bracket)
        {
            char[] leftBrackets = new char[3] { '(', '{', '[' };

            return leftBrackets.Contains(bracket);
        }

        private static bool IsPair(char left, char right)
        {
            bool isPair = false;

            switch (left)
            {
                case '(':
                    isPair = right == ')';
                    break;
                case '[':
                    isPair = right == ']';
                    break;
                case '{':
                    isPair = right == '}';
                    break;
            }

            return isPair;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = Console.ReadLine();

                string result = isBalanced(s);
                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
