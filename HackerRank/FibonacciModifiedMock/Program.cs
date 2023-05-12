using System.Numerics;

namespace FibonacciModifiedMock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t1 = 0;
            int t2 = 1;
            int n = 10; // 84266613096281243382112
            Console.WriteLine($"fibonacciModified {fibonacciModified(t1, t2, n)}");
            Console.WriteLine(ulong.MaxValue);
        }


        //    p  n           
        // 0  1  1  2  5   27....
        // 0,1,1,2,6,42,1806
        public static BigInteger fibonacciModified(int t1, int t2, int n)
        {
            BigInteger next = (BigInteger)t2;
            BigInteger prev = (BigInteger)t1;
            for (int i = 3; i <= n; i++)
            {
                BigInteger temp = next;
                next = prev + BigInteger.Pow(next, 2);
                prev = temp;
            }
            return next;
        }

    }
}