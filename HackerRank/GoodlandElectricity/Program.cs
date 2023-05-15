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
            int k = 2;
            //List<int> arr = new List<int>() { 0, 1, 1, 1, 0, 0, 0 };    // 3 -1
            List<int> arr = new List<int>() { 0, 1, 1, 1, 1, 0 };// 2 2
            Console.WriteLine($"Hello, World!   {pylons(k, arr)}");
        }




         static int pylons(int k, List<int> arr)
        {
            int i = 0; int j = 0; int count = 0; int last_plant = -1;
            int n = arr.Count;
            // tìm vị trí xây trên toàn dãy 
            while ( i < n )
            {
                // tìm biên trên để xây plant 
                j = Math.Min(i + k - 1, n - 1);
                // khi không xây được và phía trên plant trước đó thì lùi lại 
                while (j > last_plant && arr[j] == 0 ) j--;
                // nếu lùi về vị trí plant trước thì coi như impossible 
                if (j == last_plant) return -1;
                // nếu ok thì 1 plant được xây tại vị trí j 
                count++;
                last_plant = j;
                // i >> 
                i = j + k;
            }

            return count;
        }

    }
}