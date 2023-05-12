using System.Linq;

namespace MockAnagram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  aaabbb      3
                ab          1
                abc         -1
                mnop        2
                xyyx        0
                xaxbbbxx    1
                asdfjoieufoa        3
                fdhlvosfpafhalll    5
                mvdalvkiopaufl      5
            */
            string s = "mvdalvkiopaufl"; //"abccde";

            //Console.WriteLine($"so luong char f: {s.Select(c => c == 'f').Count()}");
            Console.WriteLine($"{s}  {s.Length}    {anagram(s)}");
        }




        public static int anagram(string s)
        {
            int res = -2;

            if (s.Length % 2 != 0)
            {
                res = -1;
            }
            else 
            {
                int len = s.Length / 2;
                var left = s.Substring(0, len).ToList();
                var right = s.Substring(len).ToList();

                foreach (var c in left)
                {
                    if (right.Contains(c))
                    {
                        //int cLeft = left.Count(x => x == c);
                        //int cRight = right.Count(x => x == c);
                        //len-= Math.Abs(cLeft - cRight);
                        //right.RemoveAll(x => x == c);
                        len--;
                        right.Remove(c);
                    }
                }
                res = len;
            }

            return res;
        }

    }
}