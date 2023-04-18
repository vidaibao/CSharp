using TCPData;

namespace LINQExamples_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Data.GetEmployees();
            List<Department> departments = Data.GetDepartments();

            var resultList = employees.Select(e => new 
            {
                FullName = e.FirstName + " " + e.LastName,
                AnnualSalary = e.AnnualSalary
            }).Where(e => e.AnnualSalary > 30000);

            foreach (var e in resultList)
            {
                Console.WriteLine($"|{e.FullName, -25}|{e.AnnualSalary, -10}|");
            }



        }


    }
}