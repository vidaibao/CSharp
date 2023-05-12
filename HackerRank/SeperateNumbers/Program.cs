namespace SeperateNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "10111213141516171819202122232427"; 
            //"101103"; //"1234"; // "91011" "99100"    1<=|s|<=32
            separateNumbers(s);
        }




        public static void separateNumbers(string s)
        {
            List<string> seq = new List<string>();
            
            for (int i = 1; i < (int) (s.Length / 2) + 1; i++)
            {
                seq.Add(s.Substring(0, i));
                ulong num = Convert.ToUInt64(s.Substring(0, i));

                while (seq.Select(x => x.Length).Sum() < s.Length)
                {
                    seq.Add((Convert.ToUInt64(++num).ToString()));
                }

                if (string.Join("", seq).Equals(s))
                {
                    Console.WriteLine($"YES {seq[0]}");
                    return;
                }

                seq.Clear();
            }

            Console.WriteLine("NO");
        }

    }
}