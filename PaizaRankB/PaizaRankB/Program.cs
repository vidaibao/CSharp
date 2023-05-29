namespace PaizaRankB
{
    internal class Program
    {
        static int  N,  // 発言の件数
                    M,  // 監視する時間
                    T,  // バズ判定における対象期間
                    K;  // 「Good」アクションの回数 K
        static int[,] likes; // 整数 a_{i, j} は、 j 番目の発言における i - 1 時間後から i 時間後の間の「Good」アクションの増分


        static void Main(string[] args)
        {
            ReadDataInput();
            ViralFind();

        }

        private static void ViralFind()
        {
            for (int i = 0; i < N; i++)
            {
                bool YesNo = false;
                for (int j = 0; j <= M-T; j++)
                {
                    int sumK = 0;
                    for (int k = 0; k < T; k++)
                    {
                        sumK += likes[j+k, i];
                        if (sumK >= K)
                        {
                            Console.WriteLine($"yes {j + k + 1}");
                            YesNo = true;
                            break;
                        }
                    }
                    if ( YesNo ) { break; }
                }
                if (!YesNo)
                {
                    Console.WriteLine($"no 0");
                }
            }
        }

        private static void ReadDataInput()
        {
            string[] NMTK = Console.ReadLine().Trim().Split(' ');
            N = int.Parse(NMTK[0]);
            M = int.Parse(NMTK[1]);
            T = int.Parse(NMTK[2]);
            K = int.Parse(NMTK[3]);

            likes = new int[M, N];
            string[] stArrayData;
            for (int i = 0; i < M; i++)
            {
                stArrayData = Console.ReadLine().Trim().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    likes[i, j] = int.Parse(stArrayData[j]);
                }
            }
        }
    }
}


/*
 * あなたは Paiza SNS における発言監視ソフトを作っています。
Paiza SNS では、お気に入りの発言に「Good」アクションを行うことができます。
そこで、発言監視ソフトに、「Good」アクションをもとにして、「バズっている」と思われる発言を検出する機能を追加することにしました。

ここで、対象となる発言が N 件あるとします。
その後、各発言を M 時間だけ監視し、 1 時間ごとに「Good」アクションの増分を計測します。
そして、T 時間以内に K 回以上「Good」アクションが起こった発言を「バズっている」とします。

このとき、その期間内にバズったと思われる発言をすべて検出するプログラムを作成してください。
特に、バズった各発言について、初めてバズっていると判定されたタイミングも求めるようにしてください。
以下の図は、入力例 1 の様子を表しています。

Input
N M T K
a_{1,1} a_{1,2} ... a_{1,N}
a_{2,1} a_{2,2} ... a_{2,N}
...
a_{M,1} a_{M,2} ... a_{M,N}
入力はすべて整数からなります。
・1 行目には、発言の件数 N と監視する時間 M、バズ判定における対象期間 T および「Good」アクションの回数 K が、この順で空白区切りで与えられます。
・続く M 行のうち i 行目 (1 ≦ i ≦ M) には、N 個の整数 a_{i, 1} から a_{i, N} が空白区切りで与えられます。ここで、j 番目 (1 ≦ j ≦ N) の整数 a_{i, j} は、 j 番目の発言における i - 1 時間後から i 時間後の間の「Good」アクションの増分を表します。

Output
f_1 t_1
f_2 t_2
...
f_N t_N
・出力は N 行からなります。
・j 行目 (1 ≦ j ≦ N) には、j 番目の発言に関する判定結果を表す文字列 f_j と整数 t_j を、この順で空白区切りで出力します。ここで、j 番目の発言が i 時間後 (1 ≦ i ≦ M) に初めてバズっていると判定されたならば f_j は "yes" で t_j は i となり、そうでなければ f_j は "no" で t_j は 0 となります。
・出力最終行の末尾に改行を入れ、余計な文字、空行を含んではいけません。


Constrains
すべてのテストケースにおいて、以下の条件をみたします。

・1 ≦ N ≦ 100
・1 ≦ M ≦ 100
・1 ≦ T ≦ M
・1 ≦ K ≦ 10,000
・0 ≦ a_{i, j} ≦ 10,000 (1 ≦ i ≦ M, 1 ≦ j ≦ N)



入力例1
2 5 3 1000
100 100
500 200
60 300
100 500
10 1000

出力例1
no 0
yes 4

入力例2
4 4 4 12
1 1 1 1
1 2 3 4
1 3 6 10
1 4 10 20
出力例2
no 0
no 0
yes 4
yes 3

入力例3
3 5 3 1558
71 825 1537
775 640 2
64 3596 1
501 2442 8
11 2756 527
出力例3
no 0
yes 3
no 0
 */