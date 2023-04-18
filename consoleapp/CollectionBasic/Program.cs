using System;
using System.Collections.Generic;

namespace CollectionBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection01();

        }



        static void Collection01()
        {
            String[] myStrings = { "Hello", "Today", "Goodbye", "Tomorrow", "Yesterday" };
            IEnumerator<string> stringEnum = (IEnumerator<string>)new List<string>(myStrings).GetEnumerator();

            while ((string)stringEnum.Current != "Hello")
                stringEnum.MoveNext();

            int sum = 0, count = 0;
            foreach (var thisString in stringEnum) //error 
            {

            }

            //public static class Extensions
            //{
            //    public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> enumerator) => enumerator;
            //}


        }



    }


    

}


