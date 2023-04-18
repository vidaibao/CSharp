using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqWebGentle
{
    class ThenByLinq
    {
        public static void ThenBy_Linq()
        {
            List<Student> dataStudent = new List<Student>() {
                new Student()
                {
                    name = "Chich Bong",
                    yob = 2014,
                    gpa = 8.3
                },
                new Student()
                {
                    name = "Chich Choe",
                    yob = 2010,
                    gpa = 8.5
                },
                new Student()
                {
                    name = "Tran A",
                    yob = 2010,
                    gpa = 8.6
                },
                new Student()
                {
                    name = "Le Van B",
                    yob = 2014,
                    gpa = 8.2
                },
                new Student()
                {
                    name = "Ly Tu",
                    yob = 2009,
                    gpa = 8.1
                },
                new Student()
                {
                    name = "Truong Tam",
                    yob = 2009,
                    gpa = 8.2
                }
            };


            var queryYobName = (from student in dataStudent
                                orderby student.yob, student.name
                                select student).ToList();

            foreach (var item in queryYobName)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("------------------------------------------------");

            var methodYobName = dataStudent.OrderBy(st => st.yob).ThenBy(st => st.name).ToList();

            foreach (var item in methodYobName)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
