using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;


namespace LinQ
{
    class Program
    {
        /* QUERY SYNTAX
         * var lists = from <Biến lưu thông tin từng phần tử> in <Nguồn dữ liệu>
                [<Phép toán truy vấn: where, join ... in, order by...> Biều thức lambda]
                select <Biến lưu thông tin từng phần tử>
         */

        static void Main(string[] args)
        {
            //var contacts = iniData();
            //linqWhere(contacts);
            //Console.WriteLine("\nList all elements");
            //foreach (var c in contacts) Console.WriteLine($"{c.FirstName.PadRight(12)} {c.LastName.PadRight(12)} {c.Address.PadRight(10)}");
            //linqSelect(contacts);

            //myLinqTestPredicate();
            //myLinqTestAnonymous();
            //myLinqTestLambda();
            //myLinqTestLinq();

            //MyLinqCollectionOrderby2fields();


            //myLinqSqlServer();

            //MyLinqObjs();

            LinqObjOrderBy();
        }

        private static void MyLinqObjs()
        {
            //MyLinqObjects.MyLinqFuncDelegate();
            //MyLinqObjects.SelectManyType01();
            //MyLinqObjects.SelectType01();
            //MyLinqObjects.SelectType01a();
            //MyLinqObjects.SelectType01b();
            //MyLinqObjects.SelectType02();
            //MyLinqObjects.SelectManyType01a();
            //MyLinqObjects.SelectManyType02();
            //MyLinqObjects.LinqTake01();
            //MyLinqObjects.LinqTakeWhile();
            //MyLinqObjects.LinqTakeWhile02();
            //MyLinqObjects.LinqSkip();
            //MyLinqObjects.LinqSkipWhile();
            //MyLinqObjects.LinqSkipWhile02();
            //MyLinqObjects.LinqConcat();
            //MyLinqObjects.LinqConcat01();
            MyLinqObjects.LinqOrderby01();
        }

        private static void LinqObjOrderBy()
        {
            //MyLinqObjOrderBy.MyOrderbyTest01();
            //MyLinqObjOrderBy.JoinTest01();
            //MyLinqObjOrderBy.GroupJoinTest01();
            MyLinqObjOrderBy.GroupByTest01();

        }








        private static void myLinqSqlServer()
        {
            SqlConnection cnn = DBUtils.SqlServerConnection();

            try
            {
                Console.WriteLine("Try openning connection....");
                cnn.Open();
                Console.WriteLine("Connection successful!");
                



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            
        }

        private static void MyLinqCollectionOrderby2fields()
        {
            List<Student> studentList = MyLinqCollections.iniStudentData();
            var stSortList = studentList
                .OrderByDescending(s => s.Gpa)
                .ThenByDescending(s => s.Yob);  // if Gpa == then compare Yob
            foreach (var st in stSortList) Console.WriteLine(st.ToString()); ;
        }

        private static void myLinqTestLinq()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //IEnumerable<int> oddNums = nums
            var oddNums = nums
                    .Where(i => i % 2 == 0)
                    .OrderByDescending(i => i);
            Console.WriteLine("\nUse IEnumerable<int> oddNums = nums.Where(i => i % 2 == 0).OrderByDescending(i => i)");
            //Console.WriteLine("string.Join(\" \", oddNums.Select(i => i.ToString()).ToArray())");
            Console.WriteLine(string.Join(" ", oddNums.Select(i => i.ToString()).ToArray()));
            //10 8 6 4 2
        }

        private static void myLinqTestLambda()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] oddNums = MyLinq.FilterArrayOfInts(nums, i => (i % 2) == 0 );
            Console.WriteLine("\nUse lambda  i => (i % 2) == 0 ");
            Console.WriteLine(string.Join(" ", oddNums.Select(i => i.ToString()).ToArray()));
            //foreach (var i in oddNums) Console.WriteLine(i);
        }

        private static void myLinqTestAnonymous()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] oddNums = MyLinq.FilterArrayOfInts(nums, delegate (int i) { return ((i & 1) == 1); });
            Console.WriteLine("\nUse anonymous:  delegate (int i) { return ((i & 1) == 1); }");
            Console.WriteLine(string.Join(" ", oddNums.Select(i => i.ToString()).ToArray()));
            //foreach (var i in oddNums) Console.WriteLine(i);
        }

        static void myLinqTestPredicate()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] oddNums = MyLinq.FilterArrayOfInts(nums, MyLinq.IsOdd);
            Console.WriteLine("\nUse predicate");
            Console.WriteLine(string.Join(" ", oddNums.Select(i => i.ToString()).ToArray()));
        }





        
        private static void linqSelect(List<Contact> contacts)
        {
            Console.WriteLine("\nList full names");
            var fullNames = contacts.Select(c => $"{c.FirstName.PadRight(8)} {c.LastName.PadRight(8)}");
            foreach (var n in fullNames) Console.WriteLine(n);

            Console.WriteLine("\nList names younger 50");
            var youngers = contacts
                .Where(c => c.Age <= 50)
                .Select(c => $"{c.FirstName.PadRight(8)} {c.LastName.PadRight(8)} {c.Age}");
            foreach (var y in youngers) Console.WriteLine(y);
        }

        private static void linqWhere(List<Contact> contacts)
        {
            /*Overload thứ nhất tiếp nhận một biến thuộc kiểu delegate Func<Contact, bool>.
             Overload thứ hai tương tự như vậy nhưng trong phương thức tham số có thêm một biến đầu vào 
             kiểu int dùng để chứa index của phần tử.
             Nếu phương thức trả về kết quả true thì phần tử đó sẽ được thêm vào danh sách kết quả. 
             Kết quả trả về của phương thức */
            // Who has Address is Ha Noi
            Console.WriteLine("\nWho has Address is Ha Noi");
            var hn = contacts.Where(c => c.Address == "Ha Noi");    //IEnumerable
            foreach (var h in hn) Console.WriteLine($"{h.FirstName.PadRight(12)} {h.LastName.PadRight(12)}");

            // Who has Address is Sai Gon
            Console.WriteLine("\nWho has Address is Sai Gon");
            var sg = from item in contacts where item.Address == "Sai Gon" select item;
            foreach (var s in sg) Console.WriteLine($"{s.FirstName.PadRight(12)} {s.LastName.PadRight(12)} {s.Address}");

            /* Overload thứ hai có thêm tham số đầu vào thứ hai thuộc kiểu int. 
             * Tham số này chứa index của phần tử đang được duyệt. 
             * Khi có giá trị index chúng ta dễ dàng tính ra những phần tử ở vị trí lẻ.*/
            Console.WriteLine("\nAll records in odd index");
            var odd = contacts.Where((c, i) => i % 2 != 0);
            foreach (var o in odd) Console.WriteLine($"{o.FirstName.PadRight(12)} {o.LastName.PadRight(12)}");

        }




        private static List<Contact> iniData()
        {
            var contacts = new List<Contact>
            {
                new Contact{ Age = 11, FirstName = "Trump", LastName = "Donald", Address = "Ha Noi"},
                new Contact{ Age = 21, FirstName = "Omaba", LastName = "Barrack", Address = "Sai Gon"},
                new Contact{ Age = 31, FirstName = "Bush", LastName = "George", Address = "Ha Noi"},
                new Contact{ Age = 41, FirstName = "Bill", LastName = "Clinton", Address = "Da Nang"},
                new Contact{ Age = 51, FirstName = "Reagan", LastName = "Ronald", Address = "Da Nang"},
                new Contact{ Age = 61, FirstName = "Jimmy", LastName = "Carter", Address = "Sai Gon"},
                new Contact{ Age = 71, FirstName = "Gerald", LastName = "Ford", Address = "Ha Noi"},
                new Contact{ Age = 81, FirstName = "Nixon", LastName = "Richard", Address = "Ha Noi"},
            };
            return contacts;
        }



        // Extension Methods
        //Sử dụng
        public static void extensionMethod()
        {
            var student = new Student1 { Name = "Chich Bong", Age = 8 };
            student.Print();
        }



        // Delegate con trỏ hàm in C#
        public delegate void TangQuaDel(string qua);
        // delegate + return type void + delegate Name + argument name
        public void tangQua(string qua)
        {
            Console.WriteLine("Da tang " + qua);
        }

        public void oNha(TangQuaDel tangQua, string vo = "TiKeo")
        {
            var qua = vo + " Qua da nhan";
            tangQua(qua);
        }
        //-----------------------------------------------------
        public delegate void TangQuaDelegate(string qua);

        public static void tangQua2(string qua)
        {
            Console.Write("Da tang " + qua);
        }

        //Khi sử dụng:
        TangQuaDelegate dlg = tangQua2;
        //Truyền function vào, không phải thực thi function nên ko có dấu ()







        /* ===================================================================
         * ACTION, PREDICATE, FUNC     :  APF
         * 
         */

        /* Action: Action<T in1, T in2, …>. Action tương đương 1 delegate với kiểu trả về là void, 
         * với in1, in2 là các params nhận vào.
         * Predicate: Predicate<T in>. Predicate tương đương 1 delegate với kiểu trả về là bool, 
         * với in là các param nhận vào. Predicate chỉ có thể nhận vào 1 param duy nhất.
         * Func: Func<T in1, T in2, … , T result>. 
         * Function tương đương 1 delegate với kiểu trả về do ta khai báo (result), in1, in2 là các params nhận vào. 
         * Func bắt buộc phải trả ra giá trị, không thể trả void.*/


        /*
        DELEGATE	                                            ACTION	        PREDICATE	    FUNC
        delegate void VoidDelegate(int input1, bool input2)	    Action<int, bool>		
        delegate bool BoolDelegate(int input1)		                            Predicate<int>	Func<int, bool>
        delegate int intDelegate(bool input2)			                                        Func<bool, int>
        delegate void HelloWorldDelegate()	                    Action		
        delegate bool HelloWorldBoolDelegate()		                            Predicate	    Func<bool>
        */


        public void tangQua3(string qua)
        {
            Console.Write("Da tang " + qua);
        }

        public void oNha(Person vo, Action tangQua3)
        {
            var qua = "Quà đã nhận";
            tangQua(qua);
        }



        /* ===================== LAMBDA EXPRESSION ===========================================================
         * 
         * //Cách cũ
         * TangQuaDelegate dlg = delegate(string qua) { Console.WriteLine("Tặng quà" + qua); };
         * //Dùng lambda expression
         * TangQuaDelegate lamdaDlg = (qua) => { Console.WriteLine("Tặng quà: " + qua); }
         * //Câu lệnh đầy đủ của lambda expression.
         * //Dấu "=>" gọi là go-to
         * (parameters) => { statement }
         * 
         * 
         * 
         * 
         * //1. Có thể bỏ qua kiểu dữ liệu của parameter truyền vào
            (string qua) => {Console.WriteLine("Tặng quà: " + qua);}
            (qua) => {Console.WriteLine("Tặng quà: " + qua);}
 
            //2. Nếu không có parameter, bỏ dấu () trống
            () => {Console.WriteLine("Hello");}
 
            //3. Nếu chỉ có 1 parameter, có thể bỏ luôn dấu ()
            (x) => {Console.WriteLine("Hello " + x);}
            x => {Console.WriteLine("Hello " + x);}
 
            //4. Nếu có nhiều parameter, ngăn cách bằng dấu phẩy
            (x, y) => {Console.WriteLine("Hello " + x + y);}
 
            //5. Nếu anonymous function chỉ có 1 câu lệnh, có thể bỏ dấu {}
            x => { Console.WriteLine("Hello " + x); }
            x => Console.WriteLine("Hello " + x)
 
            //6. Nếu chỉ return 1 giá trị, có thể bỏ chữ return.
            //4 lambda expression sau tương đương nhau
            (x) => { return x > 4; }
            x => { return x > 4; }
            x => return x > 4
            x => x > 4
         */


        /* =========================== Lambda Expression và LINQ =============================
         * 
         * Đã có bao giờ bạn xem thử param truyền vào cho 1 hàm của LINQ như Where, First là gì chưa?. 
         * Vâng, nó chính là 1 delegate cho một function có kiểu trả về là bool (Xem thêm về Func ở bài trước).
         * 
         * Do đó, ta sử dụng lambda expression để truyền 1 anonymous function vào hàm Where hoặc First. 
         * Ví dụ, khi dùng hàm Where của LINQ để tìm những phần tử trong 1 mảng:
         * 
         * 

            var studentList = new List<Student>();
 
            //Thứ đẹp đẽ ngắn gọn này là lambda expression
            var students = studentList.Where(stu => stu.Age > 20);
 
            //Nếu không có nó, ta phải viết cái thứ vừa dài dòng vừa gớm ghiếc như sau
            var student = studentList.Where(new delegate(Student stu) { return stu.Age > 20; });
 
            //Hoặc tệ hơn
            public bool FindStudentWithAge(Student stu) { return stu.Age > 20; }
            var student = studentList.Where(FindStudentWithAge);


         */

        /* ================================ GENERIC ==================================
         * 
         * Generic là một vị anh hùng thầm lặng trong C#.NET (Dân gian còn gọi là anh hùng núp). 
         * Generic 1 trong “5 anh em siêu nhân” cấu thành LINQ (4 người còn lại là: 
         * Extension method, Delegate, Lambda Expression và yield). 
         * Anh núp trong 50% những dòng code chúng ta viết, đến nỗi chúng ta dùng 1 cách vô thức, 
         * không biết đến sự tồn tại hay tên gọi của anh.
         * 
         * 
         * //Một list chứa các object là Student
            List<Student> students = new List<Student>();
            students.Add(new Student()); //Code đúng
            students.Add(new Car()); //Compile lỗi
            //Lấy học sinh đầu tiên.
            //Compiler tự hiểu kết quả là Student
            Student first = students.First();
         * Generics núp trong 2 dấu ngoặc nhọn đấy bạn <>
         * 
         * Để dễ hiểu, ta hãy quay lại thời .NET 1.0, khi generic chưa xuất hiện:
         * //Không có generic
            //Một list chứa các object
            List students = new List();
            students.Add(new Student()); //Compile bình thường
            students.Add(new Car()); //Compile bình thường
            //Lấy object đầu tiên, phải ép kiểu sang Student
            Student first = (Student)students.First();
         * 
         * Không có generic, compiler không thể check lỗi lúc compiler. 
         * Do đó, ở dòng 2, ta có thể thêm 1 object Car và list gồm các object Student. 
         * Khi lấy 1 phần tử ra, ta cũng phải ép kiểu, vì compiler chỉ hiểu nó là 1 object. 
         * Vì những lý do đó, generic đã được thêm vào ở .NET 2.0. Tác dụng của generic:

            Giúp tái sử dụng code. Ví dụ: Ta chỉ cần viết class List<T>, T ở đây có thể là bất kì class gì.
            Hỗ trợ compiler bắt lỗi trong quá trình compiler (Hạn chế được tình trạng như dòng 2).
            Không còn phải ép kiểu từ object.
            …..
         * https://toidicodedao.com/2015/03/05/series-c-hay-ho-generic-la-cai-thu-chi-chi/
         * 
         * 
         * 
         * 
         * 
         * 
         * ================================ IENUMERABLE & YIELD   ===========================================
         * 
         * https://toidicodedao.com/2015/03/10/series-c-hay-ho-ienumerable-va-yield-tuong-don-gian-ma-lam-thu-phai-ban/
         * 
         * 
         * public IEnumerable<int> GetNumber()
             {
               yield return 5;
               yield return 10;
               yield return 15;
             }
            foreach (int i in GetNumber()) Console.WriteLine(i);  //5 10 15

         * 
         * public List<Student> ReadStudentsFromFile(string fileName)
            {
              string[] lines = File.ReadAllLines(fileName);
              List<Student> result = new List<Student>(); //Tạo một list trống
 
              foreach (var line in lines)
              {
                Student student = ParseTextToStudent(line);
                result.Add(student); //Thêm student vào list
              }
              return result; // Trả list ra
            }
 
            public IEnumerable<Student> YieldReadStudentsFromFile(string fileName)
            {
             string[] lines = File.ReadAllLines(fileName);
             foreach (var line in lines)
             {
               Student student = ParseTextToStudent(line);
               yield return student;
             }
            }
         * 
         * 
         * Ở method đầu, ta trả về kết quả sau khi đã chạy hết hàm for, đưa kết quả vào trong 1 list mới,
         * hàm ReadStudentsFromFile kết thúc.
         * Ở method thứ 2, kết quả được ngay sau khi parse được student đầu tiên,
         * với mỗi vòng lặp tiếp theo, chương trình sẽ chạy tiếp vào method YieldReadStudentsFromFile,
         * lấy kết quả ra dần dần.
         * Sau khi đã hiểu bản chất, ta có thể ứng dụng yield vào những trường hợp sau:
         * Cần method trả về một danh sách read-only, chỉ đọc, không được thêm bớt xóa sửa.
         * Như trường hợp trên, giả sử ta có 50 dòng, hàm ParseTextToStudent tốn 1s 1 lần. 
         * Với cách cũ, khi gọi hàm ReadStudentsFromFile, ta phảo đợi 50s. 
         * Với hàm YieldReadStudentsFromFile, hàm ParseTextToStudent chỉ được chạy mỗi khi ta đọc thông tin
         * của học sinh, đó đó tăng performance lên rất nhiều (Nếu ta chỉ lấy 5 học sinh đầu chỉ cần đợi 5s).
         * Trong một số trường hợp, danh sách trả về có vô hạn phần tử, hoăc lấy toàn bộ phần tử rất mất thời gian,
         * ta phải sử dụng yield để giải quyết.
         * 
         * 
         * 
         */

    }


    public class Person
    {
        string Name { get; set; }
    }




    // Extension Methods
    /* Có 1 số trường hợp, ta muốn thêm method cho một số class sealed, hoặc class từ các library khác.
     * Với một số ngôn ngữ, điều này là ko thể được, nhưng với C#, chúng ta có thể dùng extension method.
     * VD ở đây, chúng ta có class Student từ library khác, không thể sửa code. Ta muốn thêm method Print.
     * Chúng ta tạo 1 extenstion class, class này phải là static class, method cũng phải static, 
     * params đầu tiên truyền vào là class cần extention, với từ khóa this.*/
    public static class StudentExtension
    {
        public static void Print(this Student1 student)
        {
            Console.WriteLine(student.ToString());
        }
    }

    

    public class Student1
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Contact
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
