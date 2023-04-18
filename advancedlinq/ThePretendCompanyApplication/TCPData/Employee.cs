using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }

        public override string ToString()
        {
            return $"{Id,-5}|{FirstName,-15}|{LastName,-15}|{AnnualSalary,-15:C}|{IsManager,-10}|{DepartmentId,-10}";
        }

    }
}
