using System.Numerics;

namespace CounterGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            long n = long.MaxValue - 1;
            Console.WriteLine(n.ToString());
            Console.WriteLine(counterGame(n));
        }






        public static string counterGame(long n)
        {
            if (n == 1) return "Richard";
            int turn = 1;

            while (n > 1)
            {
                double logpow = Math.Log(n, 2);
                if (logpow % 1 == 0)
                {
                    turn += (int)logpow;
                    break;
                }
                else
                {
                    n -= (long)Math.Pow(2, Math.Floor(logpow));
                    turn++;
                }
            }

            return turn % 2 == 0 ? "Louise" : "Richard";
        }


        public static string counterGame00(long n)
        {
            double pow = BigInteger.Log(n, 2);
            


            return pow.ToString();
        }
    }
}