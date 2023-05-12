namespace DynamicArray
{
    internal class Program
    {
        /*
         * Declare a 2-dimensional array, lastAnswer, of n empty arrays. 
         * All arrays are zero indexed.
        Declare an integer, lastAnswer, and initialize it to .

        There are 2 types of queries, given as an array of strings for you to parse:
        1. Query: 1 x y
            Let idx = ((x^lastAnswer)%n).
            Append the integer y to arr[idx] .
        2. Query: 2 x y
            Let idx = ((x^lastAnswer)%n).
            Assign the value arr[idx][y%size(arr[idx])] to lastAnswer.
            Store the new value of lastAnswer to an answers array.
         */
        /*
         *  2 5
            1 0 5
            1 1 7
            1 0 3
            2 1 0
            2 1 1

            7
            3
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }




        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            int lastAnswer = 0;

            var arr = new List<List<int>>();
            var answers = new List<int>();

            for (int i = 0; i < n; i++)
                arr.Add(new List<int>());

            for (int i = 0; i < queries.Count; i++)
            {

                var idx = (queries[i][1] ^ lastAnswer) % n;
                var elements = arr.ElementAt(idx);
                // Query 1
                if (queries[i][0] == 1)
                {
                    elements.Add(queries[i][2]);
                }
                else if (queries[i][0] == 2)
                {
                    lastAnswer = elements.ElementAt(queries[i][2] % elements.Count());
                    answers.Add(lastAnswer);
                }
            }

            return answers;
        }
    }
}