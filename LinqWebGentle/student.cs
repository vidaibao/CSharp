using System;
using System.Collections.Generic;
using System.Text;

namespace LinqWebGentle
{
    class Student
    {
        public string name { get; set; }
        public int yob { get; set; }
        public double gpa { get; set; }

        public override string ToString()
        {
            return $"Student: name= {name}, yob= {yob}, gpa= {gpa}";
        }
    }
}
