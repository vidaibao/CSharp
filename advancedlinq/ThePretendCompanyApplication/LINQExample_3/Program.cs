using LINQOperators_1;
using System.Linq;
using System.Threading.Channels;
using TCPData;

namespace LINQExample_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Data.GetEmployees();
            //List<Department> departments = Data.GetDepartments();
            List<Department> departments = Data.GetDepartments(employees); // for Select


            //use_SequenceEqual(employees, departments);
            //use_Concatenation(employees, departments);
            //use_Aggregate(employees, departments);
            //use_Average(employees, departments);
            //use_Count_Generation(employees, departments);
            //use_Select_SelectMany(departments);
            use_Skip_Take(employees,departments);

            Console.ReadLine();
        }

        private static void use_Skip_Take(List<Employee> employees, List<Department> departments)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(string.Join(", ", arr));
            //int count = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                Console.WriteLine();
                Console.WriteLine($"i = {j}  - arr[{j}] = {arr[j]}");
                Console.WriteLine(string.Join(", ", arr.Take(j).ToList()));
                //count = arr.Take(j).Count();
                //Console.WriteLine($"Sum left = {(count>0?arr.Take(j).Aggregate((a,b)=>a+b):0)}");
                Console.WriteLine($"Sum left = {arr.Take(j).Sum()}");
                Console.WriteLine(string.Join(", ", arr.Skip(j+1).ToList()));
                //count = arr.Skip(j + 1).Count();
                //Console.WriteLine($"Sum right = {(count>0?arr.Skip(j+1).Aggregate((a, b) => a + b):0)}");
                Console.WriteLine($"Sum right = {arr.Skip(j + 1).Sum()}");
                
            }

        }

        private static void use_Select_SelectMany(List<Department> departments)
        {
            // Select
            var result = departments.Select(d => d.Employees);
            Console.WriteLine("var result = departments.Select(d => d.Employees);");
            foreach (var items in result)
                foreach (var item in items) 
                    Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager,-10} {item.DepartmentId,4}");

            // SelectMany
            var res = departments.SelectMany(d => d.Employees);
            Console.WriteLine("var res = departments.SelectMany(d => d.Employees);");
            foreach (var item in res)
                Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager,-10} {item.DepartmentId,4}");



        }

        private static void use_Count_Generation(List<Employee> employees, List<Department> departments)
        {

            // Count
            int countEmployee = employees.Count(e => e.IsManager);
            Console.WriteLine($"Number of employees (manager): {countEmployee}");
            

            // Max
            decimal maxSalary = employees.Max(e => e.AnnualSalary);
            Console.WriteLine();
            Console.WriteLine($"Max annual Salary is: {maxSalary}");


            // GENERATION
            
            // DefaultIfEmpty
            List<int> list = new List<int>();
            var newList = list.DefaultIfEmpty();

            Console.WriteLine();
            Console.WriteLine($"DefaultIfEmpty is: {newList.ElementAt(0)}");

            // Range
            List<int> intList = Enumerable.Range(22, 10).ToList();
            intList.ForEach(e => Console.WriteLine(e));

            // Repeat
            List<string> strList = Enumerable.Repeat("Aloha", 10).ToList();
            int i = 1;
            strList.ForEach(e => Console.WriteLine(e + (i++).ToString()) );

            // Set Operators - Distinct, Except, Interset, Union
            List<int> iList = new List<int> { 9, 2, 33, 4, 1, 5, 9, 33, 2, 4, 1, 7, 7, 33, 24};
            // Distinct
            var result = iList.Distinct();
            Console.WriteLine();
            Console.WriteLine("Original list: " + string.Join(", ", iList));
            Console.WriteLine("Distinct list: " + string.Join(", ", result));

            // Except - unique element required?
            List<int> iList2 = new List<int> {4, 1, 5, 24, 55 };
            result = iList.Except(iList2);
            Console.WriteLine();
            Console.WriteLine("exclude list: " + string.Join(", ", iList2));
            Console.WriteLine("Except list: " + string.Join(", ", result));

            // Except objects
            List<Employee> employees1 = new List<Employee>
            {
                new Employee { Id = 21, FirstName="fname01", LastName="lname01", AnnualSalary=35000.1m, IsManager=true, DepartmentId=3},
                new Employee
                {
                    Id = 9,
                    FirstName = "Tester06",
                    LastName = "Gregory",
                    AnnualSalary = 30000.1m,
                    IsManager = false,
                    DepartmentId = 3
                }

            };
            Console.WriteLine("exclude employees1");
            foreach (var item in employees1)
                Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager}");

            IEnumerable<Employee> res = employees.Except(employees1); // do nothing
            
            Console.WriteLine("original employees = IEnumerable<Employee> res = employees.Except(employees1);");
            foreach (var item in res)
                Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager}");
            
            res = employees.Except(employees1, new EmployeeComparer());
            
            Console.WriteLine("res = employees.Except(employees1, new EmployeeComparer());");
            foreach (var item in res)
                Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager}");


            // Intersect - 
            result = iList.Intersect(iList2);
            Console.WriteLine("result = iList.Intersect(iList2);");
            Console.WriteLine("Original list: " + string.Join(", ", iList));
            Console.WriteLine("ilist2: " + string.Join(", ", iList2));
            Console.WriteLine("Intersect list: " + string.Join(", ", result));


            // Union - 
            result = iList.Union(iList2);
            Console.WriteLine("result = iList.Union(iList2);");
            Console.WriteLine("Original list: " + string.Join(", ", iList));
            Console.WriteLine("ilist2: " + string.Join(", ", iList2));
            Console.WriteLine("Union list: " + string.Join(", ", result));



            // PARTITIONING - Skip, SkipWhile, Take, TakeWhile
            // Skip
            res = employees.Skip(2); // IEnumerable
            Console.WriteLine("res = employees.Skip(2); // IEnumerable");
            foreach (var item in res)
                Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager}");


            // TakeWhile - ?????????
            res = employees.TakeWhile(x => x.IsManager == true);
            Console.WriteLine("res = employees.TakeWhile(x => x.IsManager==false); // IEnumerable");
            foreach (var item in res)
                Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager}");
            res = employees.Where(x => x.IsManager == false).Select(e => e);
            Console.WriteLine("res = employees.TakeWhile(x => x.IsManager==false); // IEnumerable");
            foreach (var item in res)
                Console.WriteLine($"{item.Id,4} {item.FirstName,12} {item.LastName,10} {item.AnnualSalary,12} {item.IsManager}");



            //  Conversion - 
            // Dictionary
            Dictionary<int, Employee> myDict = employees
                .Where(e => e.AnnualSalary < 50000)
                .Select(e => e)
                .ToDictionary<Employee, int>(e => e.Id);
            Console.WriteLine(".ToDictionary<Employee, int>(e => e.Id);");
            foreach (var key in myDict.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {myDict[key].FirstName,12} {myDict[key].LastName,10}, {myDict[key].AnnualSalary} ");
            }


            // test groupby to Dict
            var dict = iList.GroupBy(x=>x).ToDictionary(x=>x.Key,x=>x.Count());
            Console.WriteLine("Original list: " + string.Join(", ", iList));
            foreach (var key in dict.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {dict[key]}");
            }
        }

        private static void use_Average(List<Employee> employees, List<Department> departments)
        {
            decimal average = employees.Where(e => e.DepartmentId == 3).Average(e => e.AnnualSalary);
            Console.WriteLine($"Average of DepartmentId == 3 annual salaries: {average.ToString("F2")}");
        }

        private static void use_Aggregate(List<Employee> employees, List<Department> departments)
        {
            decimal totalAnnualSalary = employees.Aggregate<Employee, decimal>(0, (total, e) =>
            {
                var bonus = e.IsManager ? 0.04m : 0.02m;
                total += e.AnnualSalary * (1 + bonus);
                return total;
            });

            Console.WriteLine($"Total Annual Salary of all employees (+bonus): {totalAnnualSalary}");


            string data = employees.Aggregate<Employee, string>("Employee annual salary (+bonus):\n",
                (s, e) => 
                {
                    var bonus = e.IsManager ? 0.04m : 0.02m;
                    s += $"{e.FirstName,-12} {e.LastName,-10} {e.AnnualSalary*(1+bonus),15}\n";
                    return s;
                });

            Console.WriteLine();
            Console.WriteLine(data);

            string data2 = employees.Aggregate<Employee, string, string>("Employee annual salary (+bonus) (+Substring):\n",
                (s, e) =>
                {
                    var bonus = e.IsManager ? 0.04m : 0.02m;
                    s += $"{e.FirstName,-12} {e.LastName,-10} {e.AnnualSalary * (1 + bonus),15}\n";
                    return s;
                }, s => s.Substring(0, s.Length-2)
                );

            Console.WriteLine();
            Console.WriteLine(data2);

        }

        private static void use_Concatenation(List<Employee> employees, List<Department> departments)
        {
            List<int> integerList1 = new List<int> { 1, 88, 2, 5, 9, 4, 55 };
            List<int> integerList2 = new List<int> { 1, 88, 2, 5, 9, 11, 4, 55 };

            IEnumerable<int> newIntList = integerList1.Concat(integerList2);
            foreach (int integer in newIntList)
                Console.WriteLine(integer);
            


            List<Employee> employees1 = new List<Employee> { 
                new Employee
                {
                    Id = 21,
                    AnnualSalary = 97000, DepartmentId = 5, 
                    FirstName="Mario", LastName="Puzo", IsManager = true
                },
                new Employee
                {
                    Id = 22,
                    AnnualSalary = 98000, DepartmentId = 6, 
                    FirstName="Marco", LastName="Rubio", IsManager = true
                }
            };

            IEnumerable<Employee> employees2 = employees.Concat(employees1);
            
            foreach (var item in employees2)
                Console.WriteLine(item.ToString());
            
        }

        private static void use_SequenceEqual(List<Employee> employees, List<Department> departments)
        {
            var integerList1 = new List<int> { 1, 88, 2, 5, 9, 4, 55};
            var integerList2 = new List<int> { 1, 88, 2, 5, 9, 11, 4, 55};

            // Equality Operator
            // SequenceEqual
            bool sequenceEqual = integerList1.SequenceEqual(integerList2);
            Console.WriteLine(sequenceEqual);

            //
            var empListCompare = Data.GetEmployees();
            bool empSE = employees.SequenceEqual(empListCompare, new EmployeeComparer());
            Console.WriteLine("Compare 2 empList is: {0}", empSE);


        }
    }
}