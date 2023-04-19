using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LINQExamples_1
{
    public static class EnumerableCollectionExtensionMethods
    {
        public static IEnumerable<Employee> GetHighSalaryEmployees(this IEnumerable<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Accessing employee: {emp.FirstName + " " + emp.LastName}");
                if (emp.AnnualSalary >= 50000)
                    yield return emp;
            }

        }
    }
}
