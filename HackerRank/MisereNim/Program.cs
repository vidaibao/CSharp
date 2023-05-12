namespace MisereNim
{
    internal class Program
    {
        /*
         * Two people are playing game of Misère Nim. The basic rules for this game are as follows:

        The game starts with n piles of stones indexed from 0 to n-1. Each pile i (where 0<= i <n) 
        has si stones.
        The players move in alternating turns. During each move, the current player must remove one or
        more stones from a single pile.
        The player who removes the last stone loses the game.
        Given the value of n and the number of stones in each pile, determine whether the person 
        who wins the game is the first or second person to move. 
        If the first player to move wins, print First on a new line; otherwise, print Second. 
        Assume both players move optimally.
        
        Constraints
        1<= n <=100
        1<= s[i] <=10^9

         */
        static void Main(string[] args)
        {
            List<int> s = new List<int>() { 2, 1, 3 }; //{ 1,2,2 };
            Console.WriteLine($"Hello, World!  {misereNim(s)}");
        }



        /*
         * Nếu xor của một dãy số nguyên dương bằng 0, ta có thể suy ra một số tính chất của dãy này:

Dãy không có phần tử trùng nhau: Nếu có phần tử trùng nhau thì xor của dãy sẽ không bằng 0.

Dãy có số lượng phần tử chẵn: Vì mỗi phần tử sẽ xuất hiện đúng 2 lần trong các phép tính xor và giá trị xor của các phần tử giống nhau sẽ bằng 0. Nếu dãy có số lượng phần tử lẻ, thì ít nhất một phần tử sẽ không được sử dụng trong các phép tính xor và xor của dãy sẽ khác 0.

Dãy có các phần tử khác nhau: Nếu tất cả các phần tử đều giống nhau, thì xor của dãy sẽ khác 0.

Tóm lại, nếu một dãy số nguyên dương có giá trị xor bằng 0, thì dãy đó phải có số lượng phần tử chẵn và các phần tử khác nhau.
         */
        public static string misereNim(List<int> s)
        {
            int l1 = 0;
            foreach(int i in s)
                l1 ^= i;
            
            return l1 == 0 && s.Max() > 1 || l1 == 1 && s.Max() == 1
                    ? "Second"
                    : "First";
        }

    }
}