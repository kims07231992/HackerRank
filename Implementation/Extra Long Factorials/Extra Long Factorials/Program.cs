using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Extra_Long_Factorials
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            extraLongFactorials(n);
        }

        private static void extraLongFactorials(int n)
        {
            var result = GetBigIntegerFactorial(n);
            Console.WriteLine(result);
        }

        private static BigInteger GetBigIntegerFactorial(BigInteger n)
        {
            return n > 1 
                ? BigInteger.Multiply(n, GetBigIntegerFactorial(n - 1))
                : 1;
        }
    }
}
