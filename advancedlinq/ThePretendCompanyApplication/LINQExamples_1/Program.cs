using System.Collections;
using System.Collections.Generic;
using TCPData;

namespace LINQExamples_1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employees = Data.GetEmployees();
            List<Department> departments = Data.GetDepartments();

            useMethod01_SelectWhereJoin(employees, departments);
            useQueries01_SelectWhereJoin(employees, departments);

            
            Console.ReadLine();
        }

        

        private static void useQueries01_SelectWhereJoin(List<Employee> employees, List<Department> departments)
        {
            

            var resultList = from emp in employees
                             join dep in departments
                             on emp.DepartmentId equals dep.Id
                             where emp.AnnualSalary > 30000
                             select new     // Annonymous Type
                             {
                                 FullName = emp.FirstName + " " + emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Department = dep.LongName
                             };
            // determine lazy execute query
            employees.Add(new Employee
            {
                Id = 14,
                FirstName = "Lazy",
                LastName = "BongQuery",
                AnnualSalary = 99000.3m,
                IsManager = true,
                DepartmentId = 4
            });

            Console.WriteLine();
            Console.WriteLine("LINQ - Query Syntax");
            Console.WriteLine($"|{"FullName",-25}|{"AnnualSalary",15}|{"Department",25}|");
            foreach (var e in resultList) {
                Console.WriteLine($"|{e.FullName,-25}|{e.AnnualSalary,15}|{e.Department,25}|");
            }
        }

        static void useMethod01_SelectWhereJoin(List<Employee> employees, List<Department> departments)
        {
            
            var resultList = employees
                .Join(departments, emp => emp.DepartmentId, dep => dep.Id, (e, d) => new { e, d })
                .Where(x => x.e.AnnualSalary > 30000)
                .Select(x => new
                {
                    FullName = x.e.FirstName + " " + x.e.LastName,
                    AnnualSalary = x.e.AnnualSalary,
                    Department = x.d.LongName
                });

            // determine lazy execute query
            employees.Add(new Employee
            {
                Id = 15,
                FirstName = "Lazy",
                LastName = "BongMethod",
                AnnualSalary = 88000.3m,
                IsManager = true,
                DepartmentId = 6
            });

            Console.WriteLine();
            Console.WriteLine("LINQ - Method Syntax");
            Console.WriteLine($"|{"FullName",-25}|{"AnnualSalary",15}|{"Department",25}|");
            foreach (var e in resultList)
            {
                Console.WriteLine($"|{e.FullName,-25}|{e.AnnualSalary,15}|{e.Department,25}|");
            }

        }
    }
}