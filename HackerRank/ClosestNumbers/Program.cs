namespace ClosestNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> arr = new List<int>() { 5,2,3,4,1 };
            List<int> arr = new List<int>() 
            { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854, -520, -470 };
            //{ -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854 };
            Console.WriteLine($"closestNumbers: {string.Join(",", closestNumbers(arr))}");
        }




        public static List<int> closestNumbers(List<int> arr)
        {
            int len = arr.Count;
            int minDiff = int.MaxValue;
            List<Tuple<int,int>> pairs = new List<Tuple<int,int>>();
            List<int> res = new List<int>();

            arr.Sort();

            for (int i = 0; i < len - 1; i++)
            {
                int diff = Math.Abs(arr[i] - arr[i+1]);
                if (diff < minDiff)
                {
                    pairs.Clear();
                    minDiff = diff;
                    pairs.Add(new Tuple<int, int>(arr[i], arr[i + 1]));//
                }
                else if (diff == minDiff)
                {
                    pairs.Add(new Tuple<int, int>(arr[i], arr[i + 1]));//
                }
            }

            foreach (var pair in pairs)
            {
                res.Add(pair.Item1);
                res.Add(pair.Item2);
            }

            return res;
        }

    }
}