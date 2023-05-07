
namespace SansaXOR
{


    internal class Program
    {
        static void Main(string[] args)
        {

            //List<int> arr = new List<int> { 4, 5, 7, 5 };
            List<int> arr = new List<int> { 3, 4, 5 };
            Console.WriteLine(sansaXor01(arr));
            /*
             List<int> res = new List<int>();
             var combinations = GetCombinations(arr);
             foreach (var combination in combinations)
             {
                 int result = 0;
                 if (combination.Count() == 1) { 
                     result = combination.First();
                 }else if (combination.Count() > 1) { 
                     result = combination.Aggregate((a, b) => a ^ b);
                 }
                 if (result != 0)  res.Add(result);
                 Console.WriteLine($"XOR({string.Join(",", combination)}) = {result}");

             }
             int[] aaa = {3,4,5,7,1,2};
             int abc = aaa.Aggregate((a, b) => a ^ b);
             Console.WriteLine($"XOR({string.Join(",", aaa)}) = {abc}");
             //return res.Aggregate((a, b) => a ^ b);
            */
        }


        static int sansaXor(List<int> arr)
        {
            var combinations = arr.Combinations(2);

            foreach (var combo in combinations)
            {
                Console.WriteLine("{" + string.Join(",", combo) + "}");
            }

            return 0;
        }

        static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> elements)
        {
            return from n in Enumerable.Range(0, elements.Count() + 1)
                   from combination in elements.Combinations(n)
                   select combination;
        }

        static bool IsConsecutive(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1] + 1)
                {
                    return false;
                }
            }
            return true;
        }

        static int sansaXor1(List<int> arr)
        {
            //int[] arr = new int[] { 1, 2, 3, 5, 6, 7 };
            List<int> results = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                int xor = arr[i];
                if (i + 1 < arr.Count && arr[i + 1] - arr[i] == 1)
                {
                    for (int j = i + 1; j < arr.Count; j++)
                    {
                        xor ^= arr[j];
                        if (j - i > 0 && xor != 0)
                        {
                            results.Add(xor);
                        }
                    }
                }
                else if (xor != 0)
                {
                    results.Add(xor);
                }
            }

            int finalResult = results.Count > 0 ? results.Aggregate((a, b) => a ^ b) : 0;
            Console.WriteLine(finalResult); // In kết quả cuối cùng
            return 0;
        }


        static int sansaXor01(List<int> arr)
        {
            int length = arr.Count;
            if (length % 2 == 0) return 0;

            int result = 0;
            for (int i = 0; i < length; i++)
                if (i%2==0)
                    result ^= arr[i];
            
            return result;
        }
    }
}