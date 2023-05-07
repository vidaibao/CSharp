using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee 
            {
                Id = 1,
                FirstName = "Tester05",
                LastName = "Lander",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 2,
                FirstName = "Tester01",
                LastName = "LastOrder",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Tester02",
                LastName = "Jet",
                AnnualSalary = 60000.2m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 4,
                FirstName = "Tester03",
                LastName = "Ford",
                AnnualSalary = 70000.3m,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 5,
                FirstName = "Tester04",
                LastName = "Louis",
                AnnualSalary = 70000.1m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 6,
                FirstName = "Tester09",
                LastName = "Saint",
                AnnualSalary = 70000.2m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 7,
                FirstName = "Tester08",
                LastName = "Liverpool",
                AnnualSalary = 25000.3m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 8,
                FirstName = "Tester07",
                LastName = "Kennedy",
                AnnualSalary = 65000.2m,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 9,
                FirstName = "Tester06",
                LastName = "Gregory",
                AnnualSalary = 30000.1m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);

            employees.Add(new Employee
            {
                Id = 10,
                FirstName = "Tester10",
                LastName = "Boss",
                AnnualSalary = 90000.1m,
                IsManager = true,
                DepartmentId = 1
            });

            employees.Add(new Employee
            {
                Id = 11,
                FirstName = "PhD03",
                LastName = "November",
                AnnualSalary = 100000.3m,
                IsManager = true,
                DepartmentId = 4
            });

            employees.Add(new Employee
            {
                Id = 12,
                FirstName = "Saleman02",
                LastName = "December",
                AnnualSalary = 110000.1m,
                IsManager = true,
                DepartmentId = 5
            });

            employees.Add(new Employee
            {
                Id = 13,
                FirstName = "Accounting01",
                LastName = "Thirdteen",
                AnnualSalary = 100000.1m,
                IsManager = true,
                DepartmentId = 6
            });
            return employees;
        }



        //public static List<Department> GetDepartments()
        public static List<Department> GetDepartments(IEnumerable<Employee> employees) // for Select
        {
            List<Department> departments = new List<Department>();

            Department department = new Department 
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Humman Resources",
                Employees = from emp in employees //for Select
                            where emp.DepartmentId == 1
                            select emp
            };
            departments.Add(department);

            departments.Add(new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance",
                Employees = from emp in employees
                            where emp.DepartmentId == 2
                            select emp
            });

            departments.Add(new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology",
                Employees = from emp in employees
                            where emp.DepartmentId == 3
                            select emp
            });

            departments.Add(new Department
            {
                Id = 4,
                ShortName = "RD",
                LongName = "Research & Developement",
                Employees = from emp in employees
                            where emp.DepartmentId == 4
                            select emp
            });

            departments.Add(new Department
            {
                Id = 5,
                ShortName = "MKT",
                LongName = "Marketing",
                Employees = from emp in employees
                            where emp.DepartmentId == 5
                            select emp
            });

            departments.Add(new Department
            {
                Id = 6,
                ShortName = "ACC",
                LongName = "Accounting",
                Employees = from emp in employees
                            where emp.DepartmentId == 6
                            select emp
            });

            return departments;
        }


        public static ArrayList GetHeterogeneousDataCollection()
        {
            ArrayList arrList = new ArrayList();

            arrList.Add(100);
            arrList.Add("Bob John");
            arrList.Add(2000);
            arrList.Add(3000.3);
            arrList.Add("Bill Clinton");
            arrList.Add(new Employee {
                Id=15, FirstName="Anna", LastName="Hattaway", AnnualSalary=65000, IsManager=true, DepartmentId=3
            });
            arrList.Add(new Employee
            {
                Id = 16,
                FirstName = "Indiana",
                LastName = "John",
                AnnualSalary = 85000,
                IsManager = true,
                DepartmentId = 4
            });
            arrList.Add(new Department
            {
                Id=7,
                ShortName="TP",
                LongName="Transportation"
            });
            arrList.Add(new Department
            {
                Id = 8,
                ShortName = "PRD",
                LongName = "Production"
            });

            return arrList;

        }

    }
}
