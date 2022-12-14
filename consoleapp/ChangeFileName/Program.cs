using System;
using System.IO;

namespace ChangeFileName
{
    class Program
    {
        static void Main(string[] args)
        {
            //C037();
            //changeFilename();
            //hashFunction();
            XorEncrypt();
        }



        public static void XorEncrypt()
        {
            string[] stArrayData = Console.ReadLine().Trim().Split(' ');
            int N = int.Parse(stArrayData[0]), M = int.Parse(stArrayData[1]);
            var S = Console.ReadLine();

            if (N % M != 0)
            {
                S += new string('0', M - (N % M));
            }

            int chunkSize = M;
            int stringLength = S.Length;
            string[] dataS = new string[stringLength / M];
            int count = 0;
            for (int i = 0; i < stringLength; i += chunkSize)
            {
                if (i + chunkSize > stringLength) chunkSize = stringLength - i;
                dataS[count++] = S.Substring(i, chunkSize);
            }

            string result = "";
            byte Code = Convert.ToByte(dataS[0], 2), Key;
            for (int i = 1; i < dataS.Length; i++)
            {
                Key = Convert.ToByte(dataS[i], 2);
                result = Convert.ToString(Code ^ Key, 2);
                Code = Convert.ToByte(result, 2);
            }
            result = new string('0', M - result.Length) + result; 
            Console.WriteLine(result);
            //Console.WriteLine(Code.ToString("00"));

        }












        public static void hashFunction()
        {
            uint a = 1000; //0b_1111_1000;
            uint b = 1100; //0b_0001_1100;
            uint c = a ^ b;
            Console.WriteLine(Convert.ToString(c, toBase: 2));
            // Output:
            // 11100100
            int aa = int.Parse("1");
            int bb = int.Parse("1");
            int cc = aa ^ bb;
            Console.WriteLine(Convert.ToString(cc, toBase: 2));
        }





















        static void C037 ()
        {
            // 01/27 24:30   12/31 00:00
            // 12/31 25:01   02/31 73:59
            var line = Console.ReadLine();
            string[] stArrayDate = line.Trim().Split(' ');
            string[] dd = stArrayDate[0].Split('/'), hh = stArrayDate[1].Split(':');
            int M = int.Parse(dd[0]), d = int.Parse(dd[1]), h = int.Parse(hh[0]), m = int.Parse(hh[1]);

            if (h % 24 >= 0)
            {
                d += h / 24;
                h = h % 24;
            } 
            else
            {
                Console.WriteLine(line);
                return;
            }

            Console.WriteLine("{0}/{1} {2}:{3}", M.ToString("00"), d.ToString("00"), h.ToString("00"), m.ToString("00"));
        }

        static void setDate(int year, int month, int day)
        {
            DateTime Birthdate;
            try
            {
                Birthdate = new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                Birthdate = DateTime.Today;
            }
        }

        static void changeFilename()
        {
            DirectoryInfo d = new DirectoryInfo(@"H:\NAV\DEV_Books"); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories); //Getting All files
            string str = "";

            foreach (FileInfo file in Files)
            {
                str = file.FullName;

                if (str.Contains(" (z-lib.org)"))//|| file.Length == 0)
                {
                    str = str.Replace(" (z-lib.org)", "");
                    System.IO.File.Move(file.FullName, str);
                    //Console.WriteLine(file.Name);
                }
            }
        }
    }
}
