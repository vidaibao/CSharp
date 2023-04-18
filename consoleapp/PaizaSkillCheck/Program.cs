using System;
using System.Collections.Generic;
using System.Linq;
//using static EnumerableExtensions;

namespace PaizaSkillCheck
{


    



    class Program
    {

        

        static void Main(string[] args)
        {

            //C041();
            //C025();
            //C042();
            //C066();
            //C123();
            C100();
        }





        static void C100a()
        {
            List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8 };

            // Use LINQ to get the maximum number of elements from the list where the sum of the elements is less than 8
            int maxCount = numbers.TakeWhile(x => numbers.Take(numbers.IndexOf(x) + 1).Sum() < 15).Count();

            Console.WriteLine(maxCount);  // Output: 3
        }


        //public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        //{
        //    return k == 0 ? new[] { new T[0] } :
        //        elements.SelectMany((e, i) =>
        //            elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        //}


        //C100:選曲の方法
        static void C100()
        {
            string[] NMS = Console.ReadLine().Split(' ');
            int N = int.Parse(NMS[0]);
            int timeLimit = int.Parse(NMS[1]) * 60 + int.Parse(NMS[2]);
            List<int> times = new List<int>();

            for (int i = 0; i < N; i++)
            {
                var temp = Console.ReadLine().Split(' ');
                times.Add(int.Parse(temp[0]) * 60 + int.Parse(temp[1]));
            }

            //var songNums = times.Combi
            // Use LINQ to get the maximum number of elements from the list where the sum of the elements is less than 8
            int maxCount = times.TakeWhile(x => times.Take(times.IndexOf(x) + 1).Sum() <= timeLimit).Count();

            Console.WriteLine(maxCount);
        }



        //C123:節分ロボット
        public static void C123()
        {
            // 参加者の数を読み込む
            int n = int.Parse(Console.ReadLine());

            // 参加者の年齢を読み込む
            int[] y = new int[n];
            for (int i = 0; i < n; i++)
            {
                y[i] = int.Parse(Console.ReadLine());
            }

            // 命令の数を読み込む
            int m = int.Parse(Console.ReadLine());

            // 参加者の持つ豆の数を初期化する
            int[] d = new int[n];

            // 命令を読み込んで実行する
            for (int i = 0; i < m; i++)
            {
                // 命令を読み込む
                string[] input = Console.ReadLine().Split(' ');
                int a = int.Parse(input[0]) - 1; // 1番目の人を0番目とする
                int b = int.Parse(input[1]) - 1; // 1番目の人を0番目とする
                int c = int.Parse(input[2]);

                // 命令を実行する
                for (int j = a; j <= b; j++)
                {
                    // 年齢以上の豆をもらわないようにする
                    if (c <= y[j])
                    {
                        d[j] += c;
                    }
                }
            }

            // 参加者の持つ豆の数を出力する
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(d[i]);
            }
        }


        //C066:金魚すくい
        public static void C066()
        {
            string[] MNx = Console.ReadLine().Split(' ');
            int goldfishNum = int.Parse(MNx[0]);
            int poiNum = int.Parse(MNx[1]);
            int durableValue = int.Parse(MNx[2]);

            int weightFish, sukuiFish = 0, poi = 1;
            for (int i = 0; i < goldfishNum; i++)
            {
                weightFish = int.Parse(Console.ReadLine());
                durableValue -= weightFish;
                if (durableValue > 0)
                {
                    if (sukuiFish + 1 > goldfishNum) break;
                    else sukuiFish++;
                }
                else
                {
                    if (i == 0) poi++;//1 匹目の金魚をすくおうとして 2 つのポイが壊れてしまいます
                    if (poi + 1 > poiNum)
                        break;
                    else
                    {
                        poi++;
                        durableValue = int.Parse(MNx[2]); //reset new durable
                    }
                }
            }


            Console.WriteLine(sukuiFish);



            /*5 2 10
5
5
3
1
4

 = 4
 
             5 2 4
4
3
5
2
2

 = 0
 */













            /*あなたはお祭りで金魚すくいをすることにしました。 そこのお店では耐久値が x のポイがあります。 ポイは重量 w の金魚をすくったとき耐久値が w 減り、耐久値が 0 になった瞬間壊れます。ポイが壊れた場合、そのときの金魚はすくうことができません。

            あなたは N 個のポイを順に使って 1 番目の金魚から M 番目までを順番にすくうことにしました。 すべてのポイが壊れるまでにすくうことのできる金魚の数を答えるプログラムを作成してください。

            入力例 1 では 1 つ目のポイで 1 匹目をすくい耐久値が 5 になります。2 匹目をすくおうとすると耐久値が 0 になるためポイが壊れます。同様にして 2 つ目のポイで金魚をすくっていき、最終的に以下の図のように 4 匹の金魚をすくうことができます。

            図1
            1 匹目の金魚をすくおうとして 2 つのポイが壊れてしまいます。*/
        }


















        //C042:リーグ表の作成
        public static void C042()
        {
            int N = int.Parse(Console.ReadLine());
            int battleNum = N * (N - 1) / 2;
            string[,] resultWL = new string[N, N];
            for (int i = 0; i < battleNum; i++)
            {
                var temp = Console.ReadLine().Split(' ');
                resultWL[int.Parse(temp[0]) - 1, int.Parse(temp[1]) - 1] = "W";
                resultWL[int.Parse(temp[1]) - 1, int.Parse(temp[0]) - 1] = "L";
            }

            string records;
            for (int i = 0; i < N; i++)
            {
                records = "";
                for (int j = 0; j < N; j++)
                {
                    if (i == j) records += "-";
                    else records += resultWL[i, j];

                    if (j < N - 1) records += " ";
                }
                Console.WriteLine(records);
            }






            /*3
1 3
2 1
2 3

 - L W
W - W
L L -

 
             5
5 2
1 4
2 3
3 4
1 5
2 4
1 2
5 3
1 3
5 4
         
            - W W W W
L - W W L
L L - W L
L L L - L
L W W W -
             */




            /*
             あなたはとあるゲーム大会の事務係になりました。あなたの仕事は各試合の結果報告をまとめ、勝敗の結果がひと目で分かる表をつくることです。これを自動化するプログラムをつくりましょう。

この大会は総当りのリーグ戦なのですべての参加者どうしが試合を行います。なお、このゲームに引き分けは存在しません。

例)

参加者数: 3 (参加者 1 ~ 3)
結果報告:
参加者 1 と 3 が試合を行い、参加者 1 の勝利
参加者 1 と 2 が試合を行い、参加者 2 の勝利
参加者 2 と 3 が試合を行い、参加者 2 の勝利

これをまとめると以下のような表にすることができます。ここで、i 行 j 列目 (i ≠ j) は参加者 i から見た参加者 j との試合の結果を表し、勝利なら "W"、敗北なら "L" となります。i 行 i 列目は「参加者 i と参加者 i の試合」という存在しない試合に対応するので半角ハイフン ("-") で埋めます。

これは入力例 1 に対応しています。

図1

参加者の数と各試合の結果の情報が与えられるので、上のような表の内部 (参加者番号を除いた部分) を出力してください。*/
        }

















        struct FaxTimePaper
        {
            public int hh;
            public int mm;
            public int papers;

            public FaxTimePaper(int hh, int mm, int papers)
            {
                this.hh = hh;
                this.mm = mm;
                this.papers = papers;
            }

            public string Show() => hh + " " + mm + " " + papers;
        }

        //C025:ファックスの用紙回収
        public static void C025()
        {
            int Max1time = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            string[] temp = new string[3];
            List<FaxTimePaper> arr = new List<FaxTimePaper>();
            for (int i = 0; i < N; i++)
            {
                temp = Console.ReadLine().Split(' ');
                arr.Add(new FaxTimePaper(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2])));
            }

            //arr.Sort();
            //arr.ForEach(a => Console.WriteLine(a.Show()));
            var result = arr
                .GroupBy(a => a.hh)
                .Select(g => new
                {
                    Key = g.First().hh,     //The use of First() here to get the hh assumes that every hh with the same hh has the same hh
                    Value = g.Sum(s => s.papers)
                }).ToList();

            //result.ForEach(r => Console.WriteLine(r.Key + " " + r.Value));
            int timePickUpPaper = 0;
            foreach (var r in result)
            {
                if (r.Value % Max1time != 0)
                    timePickUpPaper += r.Value / Max1time + 1; 
                else
                    timePickUpPaper += r.Value / Max1time;
            }

            Console.WriteLine(timePickUpPaper);

            /*
                50
                5
                3 20 70
                3 40 170
                3 59 90
                4 5 55
                4 25 40
                = 9
                
             5
            10
            1 10 1
            1 20 1
            1 30 1
            1 40 1
            1 50 1
            2 10 1
            2 20 2
            2 30 3
            2 40 4
            2 50 5
             = 4
             
             
             
             
             */
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
                if (this.kinMedal < other.kinMedal) return 1;// this up
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
