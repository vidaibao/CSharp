using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinQ
{
    public class MyLinqObjOrderBy
    {
        public static void MyOrderbyTest01()
        {
            string[] presidents = MyLinqObjects.iniPresidentObjects();

            MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();
            // sorting by itself conditions, using compare interface
            IEnumerable<string> namesByVToCRatio = presidents
                //.OrderBy((s => s), myComp); //.OrderByDescending((s => s), myComp);
                .OrderBy(s => s.Length)
                .ThenByDescending((s => s), myComp);//.ThenBy((s => s), myComp);




            foreach (string item in namesByVToCRatio)
            {
                int vCount = 0;
                int cCount = 0;

                myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);
                double dRatio = (double)vCount / (double)cCount;

                Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
            }
        }



        public static void JoinTest01()
        {
            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees
                .Join(
                    empOptions,     //inner sequence
                    e => e.id,      // outerKeySelector
                    o => o.id,      // innerKeySelector  ?? intelisence no support? o.??
                    (e, o) => new   // resultSelector
                                {
                                    id = e.id,
                                    name = string.Format($"{e.firstName} {e.lastName}"),
                                    options = o.optionsCount
                                });

            foreach (var item in employeeOptions) Console.WriteLine(item);
        }

        /*GroupJoin
            The GroupJoin operator performs a grouped join on two sequences based on keys extracted from each
            element in the sequences.*/
        public static void GroupJoinTest01()
        {
            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees
                .GroupJoin(
                    empOptions,
                    e => e.id,
                    o => o.id,
                    (e, os) => new
                                {
                                    id = e.id,
                                    name = string.Format($"{e.firstName} {e.lastName}"),
                                    options = os.Sum(o => o.optionsCount)
                                });

            foreach (var item in employeeOptions) Console.WriteLine(item);
        }


        /*GroupBy
            The GroupBy operator is used to group elements of an input sequence.*/
        public static void GroupByTest01()
        {
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            IEnumerable<IGrouping<int, EmployeeOptionEntry>> outerSequence = empOptions.GroupBy(o => o.id);

            // First enumerate through the outer sequence of IGroupings.
            foreach (IGrouping<int, EmployeeOptionEntry> keyGroupSequence in outerSequence)
            {
                Console.WriteLine("Option records for employee: " + keyGroupSequence.Key);
                // Now enumerate through the grouping's sequence of EmployeeOptionEntry elements.
                foreach (EmployeeOptionEntry element in keyGroupSequence)
                    Console.WriteLine("id={0} : optionsCount={1} : dateAwarded={2:d}",
                        element.id, element.optionsCount, element.dateAwarded);
            }
            
        }





    }









    //Implementation of the IComparer Interface for an Example Calling the Second OrderBy Prototype
    public class MyVowelToConsonantRatioComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            int vCount1 = 0;
            int cCount1 = 0;
            int vCount2 = 0;
            int cCount2 = 0;
            GetVowelConsonantCount(s1, ref vCount1, ref cCount1);
            GetVowelConsonantCount(s2, ref vCount2, ref cCount2);
            double dRatio1 = (double)vCount1 / (double)cCount1;
            double dRatio2 = (double)vCount2 / (double)cCount2;
            if (dRatio1 < dRatio2)
                return (-1);
            else if (dRatio1 > dRatio2)
                return (1);
            else
                return (0);
        }
        // This method is public so our code using this comparer can get the values
        // if it wants.
        public void GetVowelConsonantCount(string s, ref int vowelCount, ref int consonantCount)
        {
            // DISCLAIMER: This code is for demonstration purposes only.
            // This code treats the letter 'y' or 'Y' as a vowel always,
            // which linguistically speaking, is probably invalid.
            string vowels = "AEIOUY";
            // Initialize the counts.
            vowelCount = 0;
            consonantCount = 0;
            // Convert to uppercase so we are case insensitive.
            string sUpper = s.ToUpper();
            foreach (char ch in sUpper)
            {
                if (vowels.IndexOf(ch) < 0)
                    consonantCount++;
                else
                    vowelCount++;
            }
            return;
        }
    }





}
