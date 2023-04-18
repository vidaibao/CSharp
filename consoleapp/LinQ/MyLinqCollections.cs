using System;
using System.Collections.Generic;
using System.Text;

namespace LinQ
{
    class MyLinqCollections
    {
        
        public static List<Student> iniStudentData()
        {
            return new List<Student> {
                new Student {Id = "AX123456", Name = "Chich Bong", Yob = 2014, Gpa = 8.8f },
                new Student {Id = "BS145623", Name = "Chich Choe", Yob = 2010, Gpa = 8.8f },
                new Student {Id = "SF562341", Name = "Nguyen An", Yob = 2012, Gpa = 8.6f },
                new Student {Id = "GF145622", Name = "Tran Nhi", Yob = 2011, Gpa = 8.5f },
                new Student {Id = "HJ623154", Name = "Truong Tam", Yob = 2013, Gpa = 8.9f },
            };
            
        }


        public static List<Club> iniClubList()
        {
            return new List<Club>
            {
                new Club {ClubId = "COMP", ClubName = "Computer Experts"},
                new Club {ClubId = "DRAW", ClubName = "Drawing Painter"},
                new Club {ClubId = "CAMP", ClubName = "Campping Lovers"},
            };
        }


        

    }




    

    public class Club
    {
        public string ClubId { get; set; }
        public string ClubName { get; set; }
    }


    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Yob { get; set; }
        public float Gpa { get; set; }

        public override string ToString()
        {
            return Id.PadRight(12) + Name.PadRight(14) + Yob.ToString().PadRight(8) + Gpa.ToString().PadRight(4);
        }
    }
}
