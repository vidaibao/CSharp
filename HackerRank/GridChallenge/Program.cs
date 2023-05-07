using System.Collections.Immutable;
using System.Threading.Channels;

namespace GridChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> grid = new List<string> { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" };

            var g = grid.Select(x => x.OrderBy(c => c).ToList()).ToList();















            //int length = grid.Count;
            //for (int i = 0; i < length; i++) 
            //{
            //    char[] temp = grid[i].OrderBy(x => x).ToArray();
            //    grid[i] = new string(temp);
            //}
            //grid.ForEach(x => Console.WriteLine(x));
            //Console.WriteLine(isAlphabet(grid)?"YES":"NO");
        }

        public static bool isAlphabet(List<string> grid) {
            
            int length = grid.Count;
            for (int col = 0; col < grid[0].Length; col++)
            {
                char prevChar = grid[0][col];
                for (int row = 1; row < length; row++)
                {
                    if (grid[row][col] < prevChar)
                    {
                        Console.WriteLine(string.Concat(prevChar, row.ToString(),col.ToString()));
                        return false;
                    }
                    prevChar = grid[row][col];
                }
            }
            return true;

        }



        public static string gridChallenge(List<string> grid)
        {
            //rearrange elements of each row alphabetically
            var g = grid.Select(x => x.OrderBy(c => c).ToList()).ToList();

            for (int i = 1; i < grid.Count; i++)
            {
                //get previous g[i-1] and current g[i] and substract colums value
                //if the sum is greater then 0 it means that in currentList there are smaller numbers (earlier alphanetical letter)
                if (g[i - 1].Zip(g[i], (previous, current) => (previous - current) > 0).Any(x => x))
                    return "NO";
            }

            return "YES";
        }

    }
}