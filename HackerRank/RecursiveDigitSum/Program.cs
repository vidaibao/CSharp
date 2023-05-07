using System.Numerics;

namespace RecursiveDigitSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(superDigit("9875", 4));
            BigInteger i = BigInteger.Pow(10, 100000) - 1;
            string s = i.ToString();
            Console.WriteLine(s);
            int k = (int)Math.Pow(10, 5);
            Console.WriteLine(k);
            Console.WriteLine(superDigit(s, k));
        }




        public static string sumDigit(string n)
        {
            
            while (n.Length > 1)
            {
                List<int> ints = n.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
                return ints.Sum().ToString();
            }
            return n;
        }

        public static int superDigit(string n, int k)
        {
            if (n.Length == 1) return int.Parse(n);

            List<int> ints = n.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();

            BigInteger sum = (BigInteger)ints[0];// k > 1 ? ints.Sum() * k : ints.Sum();
            for (int i = 1; i < ints.Count; i++)
                sum += (BigInteger)ints[i];
            
            if (k > 1) sum *= k;

            return superDigit(sum.ToString(), 1);
        }


        // OK
        public static int superDigit01(string n, int k)
        {
            if (n.Length == 1) return Convert.ToInt32(n);

            List<int> p = n.ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToList();
            BigInteger sum = (BigInteger)p[0];
            for (int i = 1; i < p.Count; i++)
            {
                sum = BigInteger.Add(sum, (BigInteger)p[i]);
            }

            if (k > 1) sum = BigInteger.Multiply(sum, k);

            return superDigit(sum.ToString(), 1);
        }

        public static int superDigit00(string n, int k)
        {
            if (n.Length==1) return int.Parse(n);
            string newString = n;
            for (int i = 1; i < k; i++) newString += n;
             
            int adding = 0;
            for (int i = 0; i < newString.Length; i++) adding += int.Parse(newString[i].ToString());
            return superDigit(adding.ToString(), 0);
        }
    }
}