using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinQ
{
    class MyLinq
    {
        



        public static bool IsOdd(int i)
        {
            return ((i & 1) == 1);
        }

        //public delegate bool IntFilter(int i);

        //public static int[] FilterArrayOfInts(int[] ints, IntFilter IsOdd)
        public static int[] FilterArrayOfInts(int[] ints, Predicate<int>IsOdd)
        {
            ArrayList aList = new ArrayList();
            foreach (var i in ints)
            {
                if (IsOdd(i))
                {
                    aList.Add(i);
                }
            }
            return ((int[])aList.ToArray(typeof(int)));
        }

    }
}
