
namespace SansaXOR
{


    internal class Program
    {
        static void Main(string[] args)
        {

            //List<int> arr = new List<int> { 4, 5, 7, 5 };
            List<int> arr = new List<int> { 3, 4, 5 };
            Console.WriteLine(sansaXor(arr));
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





        public static int sansaXor(List<int> arr)
        {
            int length = arr.Count;
            /*Phép XOR (Exclusive OR) giữa hai số chỉ trả về kết quả là 1 khi các bit 
             * tương ứng của hai số khác nhau. Ví dụ:
             *  1 XOR 1 = 0
                1 XOR 0 = 1
                0 XOR 1 = 1
                0 XOR 0 = 0
            Giả sử ta có n số nguyên dương là a1, a2, ..., an và đặt 
            S   = a1 XOR a2 XOR ... XOR an
                = (a1 XOR a2) XOR (a3 XOR a4) XOR ... XOR (an-1 XOR an)
 
            Ta cần chứng minh S = 0 khi n là số chẵn.

            Giả sử n = 2k với k là một số nguyên dương. Ta có:
            S = a1 XOR a2 XOR ... XOR an
              = (a1 XOR a2) XOR (a3 XOR a4) XOR ... XOR (an-1 XOR an)
            Với mỗi cặp số (ai, ai+1), ta có ba trường hợp:

            Nếu ai = ai+1, thì ai XOR ai+1 = 0.
            Nếu ai và ai+1 khác nhau, thì ai XOR ai+1 = 1.
            Nếu một trong hai số ai hoặc ai+1 bằng 0, thì ai XOR ai+1 = ai + ai+1.
            Trong trường hợp thứ ba, ta có thể coi ai và ai+1 là không đóng góp gì cho tổng S,
            vì S chỉ phụ thuộc vào các phần tử có giá trị khác 0. 
            Do đó, ta chỉ cần quan tâm đến các trường hợp đầu tiên và thứ hai.

            Nếu n là số chẵn, tức là k là số nguyên dương, ta có thể ghép các cặp số 
            (ai, ai+1) lại với nhau, sao cho không có số nào bị bỏ qua. 
            Vì vậy, trong mỗi cặp số, trường hợp thứ hai và thứ nhất đều xuất hiện một lần. 
            Do đó, tổng S của n số này là S = 0 XOR 0 XOR ... XOR 0 = 0.

            Vậy, ta đã chứng minh được rằng nếu n là số chẵn thì kết quả phép XOR của 
            n số nguyên dương sẽ luôn bằng 0.*/
            if (length % 2 == 0) return 0;

            int result = 0;
            for (int i = 0; i < length; i++)
                if (i % 2 == 0)
                    result ^= arr[i];

            return result;
        }


        static int sansaXor03(List<int> arr)
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

        static int sansaXor02(List<int> arr)
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