using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqWebGentle
{
    class OrderByLinq
    {
        static public void OrderBy_Linq()
        {
            var dataSourceInt = new List<int>() { 5, 12, 13, 1, 7, 53, 100 };

            var dataSourceString = new List<string>() {
                    "Smith",
                    "Anderson",
                    "Wright",
                    "Mitchell",
                    "Thomas",
                    "Allen",
                    "Evan",
                    "Collins" };

            Console.WriteLine("----------------------- String -------------------------");


            var querySyntax1 = (from name in dataSourceString
                               // where name.Length > 4
                               orderby name
                               select name).ToList();

            foreach (var item in querySyntax1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------------------------");

            var methodSyntax1 = dataSourceString.Where(name => name.Length > 4).OrderBy(name => name).ToList();

            foreach (var item in methodSyntax1)
            {
                Console.WriteLine(item);
            }




            Console.WriteLine("----------------------- INT -------------------------");


            var querySyntax = (from num in dataSourceInt
                               where num > 10
                              orderby num
                              select num).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------------------------");

            var methodSyntax = dataSourceInt.Where(num => num > 10).OrderBy(num => num).ToList();

            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("------------------------ EMP ------------------------");


            //Employee===================================================

            List<Employee> dataSourceEmp = Employee.InitData();

            var querySyntaxEmp = (from emp in dataSourceEmp
                                  where emp.Id > 1
                                  orderby emp.Name
                                  select emp).ToList();

            foreach (var item in querySyntaxEmp)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("------------------------ ------------------------");

            var methodSyntaxEmp = dataSourceEmp.Where(emp => emp.Id > 1).OrderBy(emp => emp.Name).ToList();

            foreach (var item in methodSyntaxEmp)
            {
                Console.WriteLine(item.ToString());
            }




        }


    }
}
