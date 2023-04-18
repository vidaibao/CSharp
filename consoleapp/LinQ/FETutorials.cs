using System;
using System.Collections.Generic;
using System.Text;

namespace LinQ
{
    class FETutorials
    {
        public static void ConvertDecimalToBinary(double d)
        {
            if (d%1==0) // Integer
            {
                int myInt = Int32.Parse(d.ToString());
                ConvertIntegerToBinary(myInt);
            }
        }

        public static void ConvertIntegerToBinary(int i)
        {
            i = 5 / 2;
        }
    }
}
