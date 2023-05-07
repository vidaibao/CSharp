namespace SherlockArray
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = { 1, 2, 3, 4, 5 };
            int sum = numbers.Where(x => x%2==1).Aggregate((x, y) =>  x + y);

            Console.WriteLine(sum);
            /*
             2
            3
            1 2 3
            4
            1 2 3 3
            */
        }

        public static string balancedSums(List<int> arr)
        {
            if (arr.Count == 1) return "YES";
            long left = 0;
            long right = arr.Sum();
            for (int i = 1; i < arr.Count; i++)
            {
                if (i > 0) left += arr[i - 1];
                right -= arr[i];
                if (left == right) return "YES";
                 


                /*if (arr.Take(j).Sum() == arr.Skip(j + 1).Sum()){
                    result = "YES";
                    break;
                } */
            }
            return "NO";
        }
    }
}