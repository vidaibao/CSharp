namespace NewYearChaos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> q = new List<int>() { 1,5,2,3,4,6,7,8};

            minimumBribes(q);
        }




        public static void minimumBribes(List<int> q)
        {
            int bribes = 0;
            for (int i = q.Count - 1; i >= 0 ; i--)
            {
                if (q[i] != i + 1)
                {
                    if (q[i - 1] == i + 1)
                    {
                        bribes++;
                        Swap(q, i, i - 1);
                    } 
                    else if (q[i - 2] == i + 1)
                    {
                        bribes += 2;
                        Swap(q, i - 2, i - 1);
                        Swap(q, i, i - 1);
                    }
                    else
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }
            }
            Console.WriteLine(bribes);
        }

        static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

    }
}