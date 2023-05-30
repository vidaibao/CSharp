namespace SuperReducedString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abba";
            Console.WriteLine(superReducedString(s));
        }



        public static string superReducedString(string s)
        {
            bool reduced = true;

            while (reduced)
            {
                reduced = false;
                int i = 0;

                while (i < s.Length - 1)
                {
                    if (s[i] == s[i + 1])
                    {
                        s = s.Remove(i, 2);
                        reduced = true;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return s.Length == 0
                    ? "Empty String"
                    : s;
        }
    }
}