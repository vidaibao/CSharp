namespace SherlockValidstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abbac";
            //string s = TestData.s;
            Console.WriteLine($"\t\t{isValid(s)}");
        }




        public static string isValid00(string s)
        {
            var cCounts = s.GroupBy(x => x).ToDictionary(c => c.Key, c => c.Count());

            int num_occur = cCounts.Values.First();
            int diff_count = 0;

            var groupByValue = cCounts.GroupBy(x => x.Value)
                       .Select(g => new { Value = g.Key, Count = g.Count() });
            foreach (var item in groupByValue)
                Console.WriteLine($"Value: {item.Value}, Count: {item.Count}");
            if (groupByValue.Count() > 2) return "NO";
            else if (groupByValue.Count() == 2) 
            {

            }
            return "YES";
        }



        static string isValid(string s)
        {
            // Khởi tạo mảng đếm số lượng xuất hiện của mỗi kí tự trong chuỗi
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }

            // Đếm số lượng kí tự có số lượng xuất hiện khác nhau nhất
            int maxFreq = freq.Max();   // max
            int countMaxFreq = freq.Count(f => f == maxFreq);   //counter of max
            int minFreq = freq.Where(f => f > 0).Min();         // if no filter will get 0 min
            int countMinFreq = freq.Count(f => f == minFreq);
            int countAlphabet = freq.Count(n => n != 0);

            // Kiểm tra nếu chuỗi đã hợp lệ
            /*
             maxFreq là số lần xuất hiện của ký tự xuất hiện nhiều nhất trong chuỗi.
            countMinFreq là số lượng các ký tự khác nhau xuất hiện với tần suất bằng nhau nhỏ nhất.
            Nếu maxFreq bằng độ dài của chuỗi trừ đi 1 (tức là chỉ có 1 ký tự xuất hiện với tần suất khác nhau),
            và countMinFreq bằng 1 (tức là chỉ có 1 ký tự xuất hiện với tần suất bằng nhau nhỏ nhất), 
            thì ta có thể xóa đi 1 ký tự trong chuỗi để tạo ra một chuỗi mới hợp lệ. 
            Nếu không thể xóa bất kỳ ký tự nào trong chuỗi để tạo ra một chuỗi mới hợp lệ,
            thì chuỗi ban đầu không hợp lệ.
            */
            return (    maxFreq == minFreq  // 
                    || (maxFreq - minFreq == 1 && countMaxFreq == 1) 
                    || (countMaxFreq == countAlphabet - 1 && countMinFreq == 1)
                    )
                    ? "YES"
                    : "NO";
        }


    }
}