using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LINQOperators_1
{
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            if(x.Id == y.Id 
                && x.FirstName.ToLower() == y.FirstName.ToLower() 
                && x.LastName.ToLower() == y.LastName.ToLower() 
                //&& x.AnnualSalary == y.AnnualSalary && x.IsManager == y.IsManager
                //&& x.DepartmentId == y.DepartmentId
                )
                return true;
            return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
