using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public IEnumerable<Employee> Employees { get; set; } // for Select/SelectMany


        public override string ToString()
        {
            return $"{Id,-5}|{ShortName,-5}|{LongName,-25}";
        }
    }
}
