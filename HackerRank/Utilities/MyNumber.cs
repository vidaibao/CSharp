using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class MyNumber
    {
        public static bool IsPrime(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // n is total number of prime number in range 2 to n
        public static List<int> FindPrimes(int total)
        {
            List<int> ints = new List<int>();
            int count = 0;
            int num = 2;

            while (count < total)
            {
                if (IsPrime(num))
                {
                    ints.Add(num);
                    count++;
                }
                num++;
            }

            return ints;
        }
    }
}
