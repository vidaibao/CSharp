using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SansaXOR
{
    public static class Extensions
    {

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
                elements.SelectMany((e, i) =>
                    elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        /*
         * static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            var combinations = arr.Combinations(2);
            foreach (var combination in combinations)
            {
                Console.WriteLine("{" + string.Join(",", combination) + "}");
            }
        }
        */

        /*public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> source, int length)
        {
            if (length == 1)
            {
                foreach (var item in source)
                    yield return new T[] { item };
            }
            else
            {
                foreach (var item in source)
                {
                    var remainingItems = source.SkipWhile(x => !EqualityComparer<T>.Default.Equals(x, item)).Skip(1);
                    foreach (var subCombination in remainingItems.Combinations(length - 1))
                    {
                        yield return new T[] { item }.Concat(subCombination);
                    }
                }
            }
        }
        */
    }
}
