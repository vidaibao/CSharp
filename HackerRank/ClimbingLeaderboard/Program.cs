using System.Security.Cryptography;

namespace ClimbingLeaderboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> ranked = new List<int>() { 100,100,50,40,20,10 };
            //List<int> player = new List<int>() { 5,25,50,120 }; // 6 4 2 1
            List<int> ranked = new List<int>() { 100, 90, 90, 80, 75, 60 };
            List<int> player = new List<int>() { 50, 65, 77, 90, 102 }; // 6 5 4 2 1
            Console.WriteLine($"List<int> ranked =  {{ {string.Join(",", ranked)} }}");
            Console.WriteLine($"List<int> player =  {string.Join(",", player)}");
            Console.WriteLine($"return =  {{ {string.Join(",", climbingLeaderboard(ranked,player))} }}");

        }




        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> leaderboard = new List<int>();
            List<int> unique_ranked = ranked.Distinct().ToList();
            // >> 100,50,40,20,10   
            int n = unique_ranked.Count;

            foreach (int player_score in player)
            {
                int left = 0; int right = n - 1; 
                bool while_break = false;

                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (unique_ranked[mid] == player_score)
                    {
                        leaderboard.Add(mid + 1);
                        while_break = true;
                        break;
                    }
                    else if (unique_ranked[mid] > player_score)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                if (!while_break)
                {
                    leaderboard.Add(left + 1);
                }
            }

            return leaderboard;
        }

    }
}