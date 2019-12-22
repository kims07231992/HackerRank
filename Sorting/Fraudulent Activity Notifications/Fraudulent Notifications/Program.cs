using System;
using System.IO;

namespace Fraudulent_Notifications
{
    public class Program
    {
        private static int activityNotifications(int[] expenditure, int d)
        {
            bool isDayEven = (d & 1) == 0 ? true : false;
            int notice = 0;

            // Set counting array
            int range = 200;
            int[] countingArray = new int[range + 1];
            for (int i = 0; i < d - 1; i++)
            {
                countingArray[expenditure[i]]++;
            }

            int length = expenditure.Length - d;
            for (int i = 0; i < length; i++)
            {
                int sum = 0; // Sum of counts on array
                int previousNumber = 0; // Previous number before middle number
                Predicate<bool> medianCondition = s => s
                    ? sum >= d / 2
                    : sum >= (d / 2) + 1;

                countingArray[expenditure[i + d - 1]]++; // Queue
                for (int j = 0; j < countingArray.Length; j++)
                {
                    if (medianCondition(isDayEven))
                    {
                        double median = (isDayEven && sum == d / 2)
                            ? (double)(j + previousNumber) / 2
                            : j - 1;

                        if (median * 2 <= expenditure[i + d])
                        {
                            notice++;
                        }
                        break;
                    }

                    if (countingArray[j] > 0)
                    {
                        sum += countingArray[j];
                        previousNumber = j;
                    }
                }
                countingArray[expenditure[i]]--; // Dequeue
            }

            return notice;
        }

        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp));

            int result = activityNotifications(expenditure, d);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
