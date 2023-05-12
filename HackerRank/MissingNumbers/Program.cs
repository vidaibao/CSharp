namespace MissingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }





        public static List<int> missingNumbers(List<int> arr, List<int> brr)
        {
            arr.Sort();
            brr.Sort();
            // Consist of Tuple
            var arrCounts = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var brrCounts = brr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            List<int> missingNumbers = new List<int>();
            foreach (var number in brrCounts.Keys)
            {
                int arrCount = 0;
                arrCounts.TryGetValue(number, out arrCount);

                if (arrCount != brrCounts[number])
                {
                    missingNumbers.Add(number);
                }
            }

            return missingNumbers;
        }


        public static List<int> missingNumbers00(List<int> arr, List<int> brr)
        {
            arr.Sort();
            brr.Sort();
            var arrCounts = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var brrCounts = brr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            List<int> missingNumbers = new List<int>();
            foreach (var number in brrCounts.Keys)
            {
                int arrCount = 0;
                arrCounts.TryGetValue(number, out arrCount);

                if (arrCount != brrCounts[number])
                {
                    missingNumbers.Add(number);
                }
            }

            return missingNumbers;
        }

    }
}