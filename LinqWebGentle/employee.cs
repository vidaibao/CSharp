using System;
using System.Collections.Generic;
using System.Text;

namespace LinqWebGentle
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Techs> Programming { get; set; }

        public static List<Employee> InitData()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 3,
                    Email = "smith@email.com",
                    Name = "Smith"
                },
                new Employee()
                {
                    Id = 2,
                    Email = "thomas@email.com",
                    Name = "Thomas"
                },
                new Employee()
                {
                    Id = 1,
                    Email = "allen@email.com",
                    Name = "Allen"
                },
                new Employee()
                {
                    Id = 4,
                    Email = "anderson@email.com",
                    Name = "Anderson"
                }
            };
        }

        public override string ToString()
        {
            //Console.WriteLine("----------------------------------------------------");
            return $"Employee: Id= {Id}; Email= {Email                      }; Name= {Name}";
        }
    }

    class Techs
    {
        public string Technology { get; set; }
    }
}
