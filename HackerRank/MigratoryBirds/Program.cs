namespace MigratoryBirds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> arr = new List<int> { 2, 2, 1, 1, 3 };
            List<int> arr = readDataFile();
            Console.WriteLine($"readDataFile {migratoryBirds(arr)}");
        }


        

        public static int migratoryBirds(List<int> arr)
        {
            if (arr == null) { Console.WriteLine("arr null"); return 0; }
            var resDict = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            //resList.Sort((y, x) => {    // (y, x) desc v , asc k
            //    int res = x.Value.CompareTo(y.Value);
            //    if (res == 0) x.Key.CompareTo(y.Key);
            //    return res;
            //});
            var resList = resDict.OrderByDescending(x => x.Value)
                                .ThenBy(x => x.Key);

            foreach (KeyValuePair<int, int> pair in resList)
                Console.WriteLine($"{pair.Key}  {pair.Value}");

            return resList.First().Key;
        }


        static List<int> readDataFile()
        {
            List<int> arr = new List<int>();
            //string filePath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data04.txt");
            //Console.WriteLine(filePath1);
            string filePath = "./data04.txt";

            // Kiểm tra xem file có tồn tại không
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} không tồn tại");
                return null;
            }

            // Đọc từng dòng của file
            var lines = File.ReadLines(filePath);

            int count_line = 1;
            foreach (var line in lines)
            {
                if (count_line > 1) arr = line.TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                count_line++;
            }
            //arr.Sort();
            return arr;
        }

    }
}