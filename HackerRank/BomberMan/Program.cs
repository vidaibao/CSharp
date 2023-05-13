using System.Text;

namespace BomberMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> grid = new List<string> 
            {   ".......", 
                "...O...", 
                "....O..", 
                ".......", 
                "OO.....", 
                "OO....."};
            int n = 3;
            
            foreach (string s in bomberMan(n, grid)) 
            {
                Console.WriteLine(s);
            }
        }




        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n == 1) return grid;

            if (n % 2 == 0)
            {
                plantGrid(grid);
            }
            else
            {
                List<string> bombMap = grid.ToList();
                plantGrid(grid);
                detonateGrid(grid, bombMap);
                if ((n - 1) % 4 == 0)
                {
                    bombMap = grid.ToList();
                    plantGrid(grid);
                    detonateGrid(grid, bombMap);
                }
            }

            return grid;
        }

        public static void detonateGrid(List<string> grid, List<string> bombMap)
        {
            int n = grid.Count;
            int m = grid[0].Length;
            char bomb = 'O';
            char empty = '.';

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (bombMap[i][j] == bomb)
                    {
                        grid[i] = replaceCharAtIndex(grid[i], j, '.');
                        if (i - 1 >= 0) grid[i - 1] = replaceCharAtIndex(grid[i - 1], j, empty);
                        if (j - 1 >= 0) grid[i] = replaceCharAtIndex(grid[i], j - 1, empty);
                        if (i + 1 < n) grid[i + 1] = replaceCharAtIndex(grid[i + 1], j, empty);
                        if (j + 1 < m) grid[i] = replaceCharAtIndex(grid[i], j + 1, empty);
                    }
                }
            }
        }

        public static void plantGrid(List<string> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i] = new string('O', grid[0].Length);
            }
        }

        public static string replaceCharAtIndex(string s, int i, char c)
        {
            StringBuilder sb = new StringBuilder(s);
            sb[i] = c;
            return sb.ToString();
        }





        ////////////////////////////////////////////////////////////////////////////////
        ///

        public static List<string> bomberMan00(int n, List<string> grid)
        {
            if (n == 1) return grid;

            // When n is 0, 2, 4, 6, 8...
            else if (n % 2 == 0) plantAll(grid);

            // When n is 5, 9, 13, 17...
            else if ((n - 1) % 4 == 0)
            {
                blast(grid);
                blast(grid);
            }

            // When n is 3, 7, 11, 15...
            else blast(grid);

            return grid;
        }

        private static void plantAll(List<string> grid)
        {
            int col = grid[0].Length;
            int row = grid.Count();
            var str = new string('O', col);
            for (int i = 0; i < row; ++i)
                grid[i] = str;
        }

        private static void blast(List<string> grid)
        {
            int colCount = grid[0].Length;
            int rowCount = grid.Count();

            var dic = new Dictionary<int, List<int>>();

            for (int i = 0; i < rowCount; ++i)
            {
                var r = grid[i];
                var allBombIndexes = r.Select((x, i) => x.Equals('O') ? i : -1)
                                    .Where(i => i != -1).ToList();

                dic.Add(i, allBombIndexes);
            }

            plantAll(grid);

            for (int i = 0; i < dic.Count(); ++i)
            {
                var item = dic[i];
                var row = grid[i];

                var currentRow = row.ToCharArray();

                for (int j = 0; j < item.Count(); ++j)
                {
                    var index = item[j];

                    currentRow[index] = '.';
                    if (index <= colCount - 2) currentRow[index + 1] = '.';
                    if (index > 0) currentRow[index - 1] = '.';

                    grid[i] = new string(currentRow);

                    if (i > 0)
                    {
                        var u = grid[i - 1];
                        var upperRow = u.ToCharArray();
                        upperRow[index] = '.';
                        grid[i - 1] = new string(upperRow);
                    }

                    if (i <= rowCount - 2)
                    {
                        var d = grid[i + 1];
                        var downRow = d.ToCharArray();
                        downRow[index] = '.';
                        grid[i + 1] = new string(downRow);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        ///



        public static List<string> bomberMan01(int n, List<string> grid)
        {
            if (n == 1) return grid;
            if ((n - 1) % 4 == 0) return flipped(flipped(grid));
            if (n % 2 == 0) return plant_all(grid);
            return flipped(grid);
        }

        private static List<string> plant_all(List<string> grid)
        {
            var gridCopy = grid;
            int r = grid.Count;
            int c = grid[0].Length;
            string temp = new string('O', c);
            for (int i = 0; i < r; i++) gridCopy[i] = temp;
            return gridCopy;
        }

        private static List<string> flipped(List<string> grid)
        {
            var gridCopy = grid;
            int r = grid.Count;
            int c = grid[0].Length;

            List<string> fgrid = new List<string>();
            for (int i = 0; i < r; i++)
            {
                string raw = "";
                for (int j = 0; j < c; j++)
                {
                    if (grid[i][j] == 'O' || grid[i][j] == '*' || (i - 1 >= 0 && grid[i - 1][j] == 'O') || (i + 1 < r && grid[i + 1][j] == 'O') || (j - 1 >= 0 && grid[i][j - 1] == 'O') || (j + 1 < c && grid[i][j + 1] == 'O')) raw += '*';
                    else raw += '.';
                }
                fgrid.Add(raw);
            }
            List<string> dgrid = new List<string>();
            for (int i = 0; i < r; i++)
            {
                string raw = "";
                for (int j = 0; j < c; j++)
                {
                    raw += fgrid[i][j] == '*' ? '.' : 'O';
                }
                dgrid.Add(raw);
            }
            return dgrid;
        }
    }
}