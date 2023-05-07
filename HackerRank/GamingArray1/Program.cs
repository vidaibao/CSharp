namespace GamingArray1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int>() { 2, 3, 5, 4, 1};
            Console.WriteLine(gamingArray(arr));
        }


        public static string gamingArray(List<int> arr)
        {
            int count = 0;
            int currentMax = int.MinValue;
            foreach (int i in arr)
            {
                if (i > currentMax)
                {
                    currentMax = i;
                    count++;
                }
            }

            return count % 2 == 1 ? "BOB" : "ANDY";
        }



        public static string gamingArray02(List<int> arr)
        {
            Console.WriteLine(string.Join(", ", arr));
            int count = 0;
            int len = arr.Count;
            int[] ints = arr.ToArray();
            while (len > 0)
            {
                int idx = Array.IndexOf(ints, ints.Max());
                //Array.Copy(ints, idx, ints, 0, ints.Length - idx);
                int[] newArr = new int[idx];
                Array.Copy(ints, newArr, idx);
                ints = newArr;
                Console.WriteLine(string.Join(", ", ints));
                count++;
                len = ints.Length;
            }

            return count % 2 == 1 ? "BOB" : "ANDY";
        }

        public static string gamingArray01(List<int> arr)
        {
            int count = 0;
            int len = arr.Count;
            while (len > 0)
            {
                int idx = arr.IndexOf(arr.Max());
                arr = arr.Take(idx).ToList();
                count++;
                len = arr.Count;
            }

            return count % 2 == 1 ? "BOB" : "ANDY";
        }


        public static string gamingArray00(List<int> arr)
        {
            IEnumerable<int> ints = arr;
            
            Console.WriteLine(string.Join(", ", ints));
            int count = 0;
            
            while (ints.Count() > 0)
            {
                int idx = ints.ToList().IndexOf(ints.Max());
                ints = ints.Take(idx);
                Console.WriteLine(string.Join(", ", ints));
                count++;
            }

            return count%2==1?"BOB":"ANDY";
        }
    }
}