using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinQ
{
    class MyLinqObjects
    {
        public static string[] iniPresidentObjects()
        {
            return new string[] {"Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                            "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
                            "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                            "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                            "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
                            "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};
        }

        public static void MyLinqObj()
        {
            string[] presidents = iniPresidentObjects();
            //IEnumerable<string> items = presidents.Where(s => s.StartsWith("A"));
            IEnumerable<string> items = presidents.Where(s => Char.IsLower(s[4]));

            foreach (var item in items) Console.WriteLine(item);
            /* 
             * After the query.
                Adams
                Arthur
                Buchanan
                Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
             * Deferred   --   
             */
        }

        public static void MyLinqFuncDelegate()
        {
            string[] presidents = iniPresidentObjects();
            /* Func: Func<T in1, T in2, … , T result>. 
            * Function tương đương 1 delegate với kiểu trả về do ta khai báo (result), in1, in2 là các params nhận vào. 
            * Func bắt buộc phải trả ra giá trị, không thể trả void.*/
            Func<string, bool> LongerThan5 = i => i.Length > 5;
            IEnumerable<string> StringLongerThan5 = presidents.Where(LongerThan5);
            Console.WriteLine("StringLongerThan5:");
            foreach (var item in StringLongerThan5) Console.WriteLine(item);
        }



        // SELECT
        public static void SelectType01()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<int> nameLengths = presidents.Select(p => p.Length);
            Console.WriteLine("SelectMany(p => p.ToArray()):");
            foreach (var len in nameLengths) Console.WriteLine(len);
        }

        public static void SelectType01a()
        {
            string[] presidents = iniPresidentObjects();
            //anonymous types
            var nameObjs = presidents.Select(p => new { p, p.Length });
            Console.WriteLine("Select(p => new { p, p.Length });");
            foreach (var obj in nameObjs) Console.WriteLine(obj);   //{ p = Adams, Length = 5 } automatic field name 
            /*  we can’t control the names of the members of the
                dynamically generated anonymous class*/
        }

        public static void SelectType01b()
        {
            string[] presidents = iniPresidentObjects();
            var nameObjs = presidents.Select(p => new { LastName = p, Length = p.Length });
            Console.WriteLine("Select(p => new { LastName = p, Length = p.Length })");
            //foreach (var obj in nameObjs) Console.WriteLine(obj);   // { LastName = Madison, Length = 7 }
            foreach (var obj in nameObjs) Console.WriteLine($"{obj.LastName} is {obj.Length} characters long.");
        }

        public static void SelectType02()
        {
            string[] presidents = iniPresidentObjects();
            var nameObjs = presidents.Select((p, i) => new { index = i, LastName = p });
            Console.WriteLine("Select((p, i) => new { index = i, LastName = p })");
            foreach (var obj in nameObjs) Console.WriteLine($"{(obj.index + 1).ToString().PadLeft(3)}. {obj.LastName}");
        }



        // SELECT MANY  
        //The SelectMany operator is used to create a one-to-many output projection sequence over an input sequence
        public static void SelectManyType01()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<char> chars = presidents.SelectMany(p => p.ToArray());
            Console.WriteLine("SelectMany(p => p.ToArray()):");
            foreach (var c in chars) Console.WriteLine(c);
        }

        public static void SelectManyType01a()
        {
            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees
                .SelectMany(e => empOptions
                                .Where(eo => eo.id == e.id)
                                .Select(eo => new {
                                                    id = eo.id,
                                                    optionCount = eo.optionsCount }));

            foreach (var item in employeeOptions) Console.WriteLine(item);
            
        }

        public static void SelectManyType02()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<char> chars = presidents.SelectMany((p, i) => i < 5 ? p.ToArray() : new char[] { });
            Console.WriteLine("SelectMany((p, i) => i < 5 ? p.ToArray() : new char[] { })");
            foreach (var c in chars) Console.WriteLine(c);
        }

        /*
         * Take
            The Take operator returns a specified number of elements from the input sequence, starting from the
            beginning of the sequence.
         */

        public static void LinqTake()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> takes = presidents.Take(5);
            foreach (var t in takes) Console.WriteLine(t);
        }

        public static void LinqTake01()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<char> chars = presidents.Take(3).SelectMany(p => p.ToArray());
            foreach (var c in chars) Console.WriteLine(c);
        }

        public static void LinqTakeWhile()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = presidents.TakeWhile(p => p.Length < 10);
            //until we hit one ten or more characters long
            foreach (var name in names) Console.WriteLine(name);
        }

        public static void LinqTakeWhile02()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = presidents.TakeWhile((p, i) => p.Length < 10 && i < 5);
            /* will stop when an input element exceeds nine characters in length or when the sixth
                element is reached, whichever comes first*/
            foreach (var name in names) Console.WriteLine(name);
        }


        // SKIP
        /*The Skip operator is passed an input source sequence and an integer named count that specifies
            how many input elements should be skipped and returns an object that, when enumerated, will skip the
            first count elements and yield all subsequent elements*/
        public static void LinqSkip()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = presidents.Skip(1);
            Console.WriteLine(string.Join(", ", names));
        }


        // SKIPWHILE
        /* The SkipWhile operator will process an input sequence, skipping elements while a condition is true,
            and then yield the remaining elements into an output sequence.

           SkipWhile will only skip items in the BEGINNING of the IEnumerable<T>. 
           Once that condition isn't met it will happily take the rest of the elements. 
           Other elements that later match it down the road won't be skipped. 
         */
        public static void LinqSkipWhile()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = presidents.SkipWhile(p => p.StartsWith("A"));// if "B" then no working
            //Console.WriteLine(string.Join(", ", names));
            foreach (var name in names) Console.WriteLine(name);
        }

        public static void LinqSkipWhile02()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = presidents.SkipWhile((p, i) => p.StartsWith("B") && i < 5);
            //Console.WriteLine(string.Join(", ", names));
            foreach (var name in names) Console.WriteLine(name);
        }


        /*
         * Concat
         * 
            The Concat operator concatenates two input sequences and yields a single output sequence.
         */
        public static void LinqConcat()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = presidents.Take(5).Concat(presidents.Skip(5));
            //Console.WriteLine(string.Join(", ", names));
            foreach (var name in names) Console.WriteLine(name);
        }

        public static void LinqConcat01()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = new[] {presidents.Take(5), presidents.Skip(5)}.SelectMany(s => s);
            //When needing to concatenate more than two sequences together, consider using the SelectMany approach.
            foreach (var name in names) Console.WriteLine(name);
        }


        // ORDERBY
        public static void LinqOrderby01()
        {
            string[] presidents = iniPresidentObjects();
            IEnumerable<string> names = presidents.OrderBy(p => p.Length);
            foreach (var name in names) Console.WriteLine(name);
        }






    }



    

    // Deferred Operators
    public class Employee
    {
        public int id;
        public string firstName;
        public string lastName;
        public static Employee[] GetEmployeesArray()
        {
            Employee[] al = new Employee[]
            {
                new Employee { id = 1, firstName = "Joe", lastName = "Rattz" },
                new Employee { id = 2, firstName = "William", lastName = "Gates" },
                new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" },
                new Employee { id = 4, firstName = "David", lastName = "Lightman" },
                new Employee { id = 101, firstName = "Kevin", lastName = "Flynn" }
            };
            return (al);
        }
        //public static Employee[] GetEmployeesArray()
        //{
        //    return ((Employee[])GetEmployeesArrayList().ToArray());//can not cast type
        //}
    }

    public class EmployeeOptionEntry
    {
        public int id;
        public long optionsCount;
        public DateTime dateAwarded;
        public static EmployeeOptionEntry[] GetEmployeeOptionEntries()
        {
            EmployeeOptionEntry[] empOptions = new EmployeeOptionEntry[] {
                new EmployeeOptionEntry {
                id = 1,
                optionsCount = 2,
                dateAwarded = DateTime.Parse("1999/12/31") },
                new EmployeeOptionEntry {
                id = 2,
                optionsCount = 10000,
                dateAwarded = DateTime.Parse("1992/06/30") },
                new EmployeeOptionEntry {
                id = 2,
                optionsCount = 10000,
                dateAwarded = DateTime.Parse("1994/01/01") },
                new EmployeeOptionEntry {
                id = 3,
                optionsCount = 5000,
                dateAwarded = DateTime.Parse("1997/09/30") },
                new EmployeeOptionEntry {
                id = 2,
                optionsCount = 10000,
                dateAwarded = DateTime.Parse("2003/04/01") },
                new EmployeeOptionEntry {
                id = 3,
                optionsCount = 7500,
                dateAwarded = DateTime.Parse("1998/09/30") },
                new EmployeeOptionEntry {
                id = 3,
                optionsCount = 7500,
                dateAwarded = DateTime.Parse("1998/09/30") },
                new EmployeeOptionEntry {
                id = 4,
                optionsCount = 1500,
                dateAwarded = DateTime.Parse("1997/12/31") },
                new EmployeeOptionEntry {
                id = 101,
                optionsCount = 2,
                dateAwarded = DateTime.Parse("1998/12/31") }
            };
            return (empOptions);
        }
    }
}
