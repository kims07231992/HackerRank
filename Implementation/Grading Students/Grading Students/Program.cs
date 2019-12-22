using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grading_Students
{
    class Program
    {
        static int[] solve(int[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 38)
                    continue;
                else
                {
                    int nextNum = (grades[i] / 5) * 5 + 5;
                    grades[i] = nextNum - grades[i] < 3 ? nextNum : grades[i];
                }
            }
            return grades;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[n];
            for (int grades_i = 0; grades_i < n; grades_i++)
            {
                grades[grades_i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] result = solve(grades);
            Console.WriteLine(String.Join("\n", result));


        }
    }
}
