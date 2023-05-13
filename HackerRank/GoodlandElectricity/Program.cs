namespace GoodlandElectricity
{
    internal class Program
    {
        /*
         * 1 <= k, n <= 10^5
         * limits supply to cities where distance is less than k.
         */
        static void Main(string[] args)
        {
            int k = 3;
            List<int> arr = new List<int>() { 0, 1, 1, 1, 0, 0, 0 };    // -1
            //List<int> arr = new List<int>() { 0, 1, 1, 1, 1, 0 };// 2 2
            Console.WriteLine($"Hello, World!   {pylons(k, arr)}");
        }




         static int pylons(int k, List<int> arr)
        {
            int zero = 0; int count1 = 0; int plant = 0;
            int len = arr.Count;

            for (int i = 0; i < len; i++)
            {
                if (arr[i] == 0)
                    if (count1 == 0) {
                        zero++; 
                    } else { zero = 1; }
                else if (arr[i] == 1) 

            }
            return k;
        }

    }
}