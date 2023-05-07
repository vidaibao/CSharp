namespace MagicSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> ints = new List<List<int>> {
                new List<int> { 5, 3, 4 },
                new List<int> { 1, 5, 8 },
                new List<int> { 6, 4, 2 }
            };

            Console.WriteLine(formingMagicSquare(ints));
        }


        public static int formingMagicSquare(List<List<int>> s)
        {
            var allPermutations = getAllPermutations();
            var costs = new List<int>();

            var flat = new List<int>();
            for (int i = 0; i < s.Count(); ++i)
            {
                for (int j = 0; j < s[i].Count(); ++j)
                {
                    flat.Add(s[i][j]);
                }
            }

            for (int i = 0; i < allPermutations.Count(); ++i)
            {
                var c = 0;
                for (int j = 0; j < allPermutations[i].Length; ++j)
                {
                    c += Math.Abs(allPermutations[i][j] - flat[j]);
                }

                costs.Add(c);
            }

            return costs.Min();
        }

        public static List<int[]> getAllPermutations()
        {
            var flatPosibilities = new List<int[]>();
            var random = new Random();
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            while (true)
            {
                var alreadyExists = false;
                numbers = numbers.OrderBy(x => random.Next()).ToList();

                if ((numbers[0] + numbers[1] + numbers[2]) == 15 &&
                    (numbers[3] + numbers[4] + numbers[5]) == 15 &&
                    (numbers[6] + numbers[7] + numbers[8]) == 15 &&

                    (numbers[0] + numbers[3] + numbers[6]) == 15 &&
                    (numbers[1] + numbers[4] + numbers[7]) == 15 &&
                    (numbers[2] + numbers[5] + numbers[8]) == 15 &&

                    (numbers[0] + numbers[4] + numbers[8]) == 15 &&
                    (numbers[2] + numbers[4] + numbers[6]) == 15)
                {
                    if (flatPosibilities.Count() > 0)
                    {
                        foreach (var item in flatPosibilities)
                        {
                            if (item[0] == numbers[0] && item[1] == numbers[1] && item[2] == numbers[2] &&
                                item[3] == numbers[3] && item[5] == numbers[5] &&
                                item[6] == numbers[6] && item[7] == numbers[7] && item[8] == numbers[8])
                            {
                                alreadyExists = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        flatPosibilities.Add(numbers.ToArray());
                        alreadyExists = true;
                    }

                    if (!alreadyExists)
                        flatPosibilities.Add(numbers.ToArray());


                    if (flatPosibilities.Count() == 8)
                        break;
                }

            }

            return flatPosibilities;
        }
    }

}