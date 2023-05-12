namespace PickingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> a = new List<int>() { 1,1,2,2,4,4,5,5,5};
            //List<int> a = new List<int>() { 4,6,5,3,3,1};
            //List<int> a = new List<int>() { 1,2,2,3,1,2};
            List<int> a = new List<int>() { 66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66,
                                            66,66,66,66,66,66,66,66,66,66 };
            
            Console.WriteLine($"pickingNumbers: {pickingNumbers(a)}");

            int d = 4;
            List<int> arr = new List<int> { 1, 2, 3, 4, 5 };
            List<int> res = rotateLeft(d, arr);
            Console.WriteLine(string.Join(" ", res));
        }


        public static int pickingNumbers(List<int> a)
        {
            a.Sort();
            int[] res = new int[100];

            for (int i = 0; i < a.Count; i++)
            {
                res[a[i]]++;
            }

            int count_max = 2;
            int count = 0;

            for (int i = 1; i < 99; i++)
            {
                count = res[i] + res[i + 1];
                if ( count > count_max)
                    count_max = count;
            }

            return count_max;
             
        }



        public static List<int> rotateLeft(int d, List<int> arr)
        {
            return arr.Skip(d).Take(arr.Count - d).Concat(arr.Take(d)).ToList();
        
        }

    }
}