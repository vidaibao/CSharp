namespace BreakingRecords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> scores = new List<int> { 10, 5, 20, 20, 4, 5, 2, 25, 1 }; // 2, 4
            List<int> scores = new List<int> { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 }; // 4, 0
            List<int> results = breakingRecords(scores);
            Console.WriteLine(string.Join(", ", results));
        }




        public static List<int> breakingRecords(List<int> scores)
        {
            List<int> res = new List<int>();
            int maxPoint = scores[0];
            int minPoint = scores[0];
            int upperCount = 0; 
            int lowerCount = 0;
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > maxPoint)
                {
                    maxPoint = scores[i];
                    upperCount++;
                }
                else if (scores[i] < minPoint) 
                { 
                    minPoint = scores[i];
                    lowerCount++;
                }
            }
            res.Add(upperCount);
            res.Add(lowerCount);
            return res;
        }

    }
}