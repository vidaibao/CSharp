using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LinqWebGentle
{
    class OrderDescending
    {
        public static void OrderByDescending_Linq()
        {
            var dataSourceInt = new List<int>() { 5, 12, 13, 1, 7, 53, 100 };

            //var methodSyntax = dataSourceInt.OrderByDescending(num => num).ToList();

            var querySyntax = (from num in dataSourceInt
                               orderby num descending
                               select num).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------------------------");
        }

    }
}
