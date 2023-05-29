namespace IceCreamParlor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cost = new List<int>() { 1, 4, 5, 3, 2 };
            int m = 6;
            var result = icecreamParlor(m, cost);
            if (result != null)
            {
                Console.WriteLine($"Index 1: {result[0]}, Index 2: {result[1]}");
            }
            else
            {
                Console.WriteLine("No two positions found with the given sum.");
            }
        }




        public static List<int> icecreamParlor(int m, List<int> arr)
        {
            var result = new List<int>();
            for (int i = 0; i < arr.Count-1; i++)
            {
                for (int j = i+1; j < arr.Count; j++)
                {
                    if (arr[i] + arr[j] == m)
                    {
                        result.Add(i + 1);
                        result.Add(j + 1);
                        break;
                    }
                }
            }
            return result;
        }



        public static List<int> icecreamParlor00(int m, List<int> cost)
        {
            var result = cost.Select((value, index) => new { value, index })
                         .Where(pair => cost.Skip(pair.index + 1).Contains(m - pair.value))
                         .Select(pair => new { Index1 = pair.index, Index2 = cost.LastIndexOf(m - pair.value) })
                         .FirstOrDefault();
            return new List<int>() { result.Index1+1, result.Index2+1 };
        }
    }
}









/*------------------------------------------------------------------
 * Two friends like to pool their money and go to the ice cream parlor. 
 * They always choose two distinct flavors and they spend all of their money.

Given a list of prices for the flavors of ice cream, select the two that will cost all of the money they have.

Example.  m = 6 cost = [1,3,4,5,6]

The two flavors that cost 1 and 5 meet the criteria. Using 1-based indexing, they are at indices 1 and 4.

Function Description

Complete the icecreamParlor function in the editor below.

icecreamParlor has the following parameter(s):

int m: the amount of money they have to spend
int cost[n]: the cost of each flavor of ice cream
Returns

int[2]: the indices of the prices of the two flavors they buy, sorted ascending
Input Format

The first line contains an integer, t, the number of trips to the ice cream parlor. 
The next t sets of lines each describe a visit.

Each trip is described as follows:

The integer m, the amount of money they have pooled.
The integer n, the number of flavors offered at the time.
n space-separated integers denoting the cost of each flavor: cost[cost[1], cost[2],..., cost[n]].
Note: The index within the cost array represents the flavor of the ice cream purchased.

Constraints
1 <= t <= 50
2 <= m <= 10^4
2 <= n <= 10^4
1 <= cost[i] <= 10^4, ∀ i in range(1,n)
There will always be a unique solution.


Sample Input

STDIN       Function
-----       --------
2           t = 2
4           k = 4
5           cost[] size n = 5
1 4 5 3 2   cost = [1, 4, 5, 3, 2]
4           k = 4
4           cost[] size n = 4
2 2 4 3     cost=[2, 2,4, 3]
Sample Output

1 4
1 2
Explanation

Sunny and Johnny make the following two trips to the parlor:

The first time, they pool together m = 4  dollars. Of the five flavors available that day,
flavors 1 and 4 have a total cost of 1+3= 4.
The second time, they pool together m = 4 dollars. Of the four flavors available that day, 
flavors 1 and 2 have a total cost of 2+2 = 4.
 */