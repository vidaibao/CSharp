// See https://aka.ms/new-console-template for more information
using TCPData;
using TCPExtensions;


List<Employee> empList = Data.GetEmployees();
List<Department> deptList = Data.GetDepartments();


//string strSQL = "SELECT e.FIRSTNAME, e.LASTNAME, e.ANNUALSALARY, e.ISMANAGER, d.LONGNAME" +
//    "FROM EMPLOYEE e" +
//    "INNER JOIN DEPARTMENT d" +
//    "ON e.DEPARTMENTID = d.ID";

var resultList = from emp in empList
                 join dept in deptList
                 on emp.DepartmentId equals dept.Id
                 where emp.AnnualSalary > 30000
                 select new     // Annonymous Type
                 {
                     FirstName = emp.FirstName, 
                     LastName = emp.LastName, 
                     AnnualSalary = emp.AnnualSalary, 
                     Manager = emp.IsManager,
                     Department = dept.LongName
                 };

foreach (var item in resultList)
{
    Console.WriteLine(item.ToString());
}
Console.WriteLine();

var averageSalary = resultList.Average(a => a.AnnualSalary);
Console.WriteLine($"averageSalary: {averageSalary}");
var maxSalary = resultList.Max(a => a.AnnualSalary);
Console.WriteLine($"maxSalary: {maxSalary}");
var minSalary = resultList.Min(m => m.AnnualSalary);
Console.WriteLine($"minSalary: {minSalary}");








//List<Employee> empList = Data.GetEmployees();

//var filterredEmployees = empList.Filter(emp => emp.IsManager == true);

//filterredEmployees.ForEach(emp => {
//    /*
//    Console.WriteLine($"FirstName:      {emp.FirstName}");
//    Console.WriteLine($"LastName:       {emp.LastName}");
//    Console.WriteLine($"Annual Salary:  {emp.AnnualSalary}");
//    Console.WriteLine($"Is Manager:     {emp.IsManager}");
//    Console.WriteLine($"DeptId:         {emp.DepartmentId}");
//    */
//    Console.WriteLine(emp.ToString());
//});
//Console.WriteLine();

//List<Department> deptList = Data.GetDepartments();

//var filterredDepartments = deptList.Filter(dept => dept.ShortName == "HR" || dept.ShortName == "FN");

//filterredDepartments.ForEach(dept => Console.WriteLine(dept.ToString()));



