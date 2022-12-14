using System;
using System.Collections.Generic;

namespace PaizaSkillCheck
{
    class Program
    {

        

        static void Main(string[] args)
        {

            C041();

        }




        struct Medal : IComparable<Medal>
        {
            public int kinMedal;
            public int ginMedal;
            public int douMedal;
            public Medal(int kin, int gin, int dou)
            {
                kinMedal = kin;
                ginMedal = gin;
                douMedal = dou;
            }

            public int CompareTo(Medal other)
            {
                if (this.kinMedal < other.kinMedal) return 1;
                else if (this.kinMedal > other.kinMedal) return -1;
                else
                {
                    if (this.ginMedal < other.ginMedal) return 1;
                    else if (this.ginMedal > other.ginMedal) return -1;
                    else
                    {
                        if (this.douMedal < other.douMedal) return 1;
                        else if (this.douMedal > other.douMedal) return -1;
                        else return 0;
                        
                    }
                }
            }

            public string Show() => kinMedal + " " + ginMedal + " " + douMedal;
        }

        public static void C041()
        {
            var N = int.Parse(Console.ReadLine());
            List<Medal> arr = new List<Medal>();
            for (int i = 0; i < N; i++)
            {
                var temp = Console.ReadLine().Split(' ');
                arr.Add(new Medal(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2])));
            }


            //arr.OrderBy(x => x.kinMedal).ThenBy(x => x.ginMedal).ThenBy(x => x.douMedal);
            arr.Sort();
            arr.ForEach(a => Console.WriteLine(a.Show()));



        }
    }
}
