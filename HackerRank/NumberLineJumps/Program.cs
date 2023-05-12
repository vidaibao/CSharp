namespace NumberLineJumps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x1 = 2; int v1 = 1;
            int x2 = 1; int v2 = 2;
            Console.WriteLine($"Hello, World! {kangaroo(x1, v1, x2, v2)}");
        }



        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            return v1 > v2 && (x2 - x1) % (v1 - v2) == 0
                ? "YES"
                : "NO";
        }

    }
}