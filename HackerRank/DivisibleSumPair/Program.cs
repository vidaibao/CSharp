namespace DivisibleSumPair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Given an array of integers and a positive integer k, determine the number of (i, j) pairs 
                where i < j  and ar[i] + ar[j]  is divisible by k.
            */
            
            List<int> ar = new List<int> { 1, 3, 2, 6, 1, 2 };  // 1<= ar[i] <=100
            int n = 6;  // 2<= n <=100
            int k = 3;  // 1<= k <=100
            /*
            List<int> ar = new List<int> { 1, 2, 3, 4, 5, 6 };  // 1<= ar[i] <=100
            int n = 6;  // 2<= n <=100
            int k = 5;  // 1<= k <=100
            */
            Console.WriteLine($"divisibleSumPairs(int n = {n}, int k = {k}, List<int> ar) = \"{string.Join(", ", ar)}\";\nreturn = {divisibleSumPairs(n, k, ar)}");
        }




        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            return ar.Select((x, i) => new[] { (x % k, 1), (k - x % k, -1) })
                  .SelectMany(x => x)
                  .GroupBy(x => x.Item1)
                  .Select(x => x.Sum(y => y.Item2))
                  .Where(x => x > 0)
                  .Sum(); 
        }


        public static int divisibleSumPairs00(int n, int k, List<int> ar)
        {
            int count = 0;
            for (int i = 0; i < n - 1; i++)
                for (int j = i+1; j < n; j++)
                    if ((ar[i] + ar[j]) % k == 0)
                        count++;
            
            return count;
        }



    }
}