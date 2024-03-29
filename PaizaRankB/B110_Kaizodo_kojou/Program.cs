﻿namespace B110_Kaizodo_kojou
{
    internal class Program
    {
        static int H, W;
        static int[,] pixel1, pixel2;
        static void Main(string[] args)
        {
            ReadDataInput();

        }

        private static void ReadDataInput()
        {
            string[] HW = Console.ReadLine().Trim().Split(' ');
            H = int.Parse(HW[0]);
            W = int.Parse(HW[1]);
            pixel1 = new int[2 * H, 2 * W];
            pixel2 = new int[2 * H, 2 * W];
            string[] stArrayData;
            int pixel = 0, idx = 0;
            
            // 2 枚の画像を、ピクセル値をそのままに、それぞれ 2H * 2W 個のピクセルに分割する
            for (int h = 0; h < 2 * H; h += 2)
            {
                stArrayData = Console.ReadLine().Trim().Split(' ');
                pixel = 0; idx = 0;

                for (int w = 0; w < W; w++)
                {
                    idx = w*2;
                    pixel = int.Parse(stArrayData[w]);
                    pixel1[h, idx] = pixel;
                    pixel1[h+1, idx] = pixel;
                    pixel1[h, idx+1] = pixel;
                    pixel1[h+1, idx+1] = pixel;
                }
            }
            for (int h = 0; h < 2 * H; h += 2)
            {
                stArrayData = Console.ReadLine().Trim().Split(' ');
                pixel = 0; idx = 0;

                for (int w = 0; w < W; w++)
                {
                    idx = w * 2;
                    pixel = int.Parse(stArrayData[w]);
                    pixel2[h, idx] = pixel;
                    pixel2[h + 1, idx] = pixel;
                    pixel2[h, idx + 1] = pixel;
                    pixel2[h + 1, idx + 1] = pixel;
                }
            }

            // 2 枚目の画像を、1 枚目の画像に対して下方向に 1 ピクセル、右方向に 1 ピクセルずらして重ねる
            int h1 = 1; int w1 = 1;
            int h2 = 0; int w2 = 0;
            int[] res = new int[2*W-1];
            while (h1 < 2*H)// && h2++ < 2*H - 1)
            {
                w1 = 1; w2 = 0;
                while (w1 < 2*W)
                {
                    res[w2] = (int)((pixel1[h1, w1] + pixel2[h2, w2]) / 2);
                    w1++; w2++;
                }
                Console.WriteLine(string.Join(" ", res));

                h1++; h2++;

            }


        }

        private static int Avg_Pixel(int v1, int v2)
        {
            return (int)((v1+v2)/2);
        }
    }
}


/*
 * B110:解像度の向上
 * 
 * あなたは解像度が H * W の 2 枚の画像を用いることで、
 * 擬似的により細かい解像度の画像を得ることを考えました。
ただし、解像度が H * W の画像は縦に H 個、横に W 個で合計 H * W 個のピクセルを持っており、
それぞれのピクセルに「ピクセル値」と呼ばれる、
その画素の明るさを表す値が定義されています。
2 枚の画像を用いて新たな画像を得る際には、以下のようにして画像を構成します。

・2 枚の画像を、ピクセル値をそのままに、それぞれ 2H * 2W 個のピクセルに分割する
・2 枚目の画像を、1 枚目の画像に対して下方向に 1 ピクセル、右方向に 1 ピクセルずらして重ねる
・その後、2 枚両方の画像が重なる部分を抽出する。
・抽出された各ピクセル値は、2 枚の画像の対応する部分のピクセル値の平均をとる(小数点以下切り捨て)ことによって計算される

画像の構成の仕方は図のようになります。




この手続きによって、縦に 2 * H - 1、横に 2 * W - 1 のより解像度の高い画像を得ることができます。
2 枚の画像の情報が与えられるので、上記の手続きを経て新たに得られる画像を出力してください。

入力例 3 の場合は以下のようになります。







入力される値
入力は以下のフォーマットで与えられます。

 H W
I_{1,1,1} I_{1,1,2} ... I_{1,1,W}
I_{1,2,1} I_{1,2,2} ... I_{1,2,W}
...
I_{1,H,1} I_{1,H,2} ... I_{1,H,W}
I_{2,1,1} I_{2,1,2} ... I_{2,1,W}
I_{2,2,1} I_{2,2,2} ... I_{2,2,W}
...
I_{2,H,1} I_{2,H,2} ... I_{2,H,W}
・1 行目に画像の縦の解像度、横の解像度を表す整数 H, W がこの順で半角スペース区切りで与えられます。
・続く H 行のうちの i 行目 (1 ≦ i ≦ H) には W 個の整数が半角スペース区切りで与えられます。 i 行目の j 番目 (1 ≦ j ≦ W) の整数 I_{1, i, j} は 1 枚目の画像の i 行 j 列目のピクセル値を表します。
・続く H 行のうちの i 行目 (1 ≦ i ≦ H) には W 個の整数が半角スペース区切りで与えられます。 i 行目の j 番目 (1 ≦ j ≦ W) の整数 I_{2, i, j} は 2 枚目の画像の i 行 j 列目のピクセル値を表します。
・入力は合計で 2 * H + 1 行となり、入力値最終行の末尾に改行が 1 つ入ります。


期待する出力
2 枚の画像を用いて新たな画像を得た際の各ピクセルのピクセル値を、新たな画像の解像度を H' * W' として以下のフォーマットに従って出力してください。
J_{1,1} J_{1,2} ... J_{1,W'}
J_{2,1} J_{2,2} ... J_{2,W'}
...
J_{H',1} J_{H',2} ... J_{H',W'}
・i 行目 (1 ≦ i ≦ H') には W' 個の整数を半角スペース区切りで出力してください。 i 行目の j 番目 (1 ≦ j ≦ W') の整数 J_{i, j} は新たな画像の i 行 j 列目のピクセル値を表します。
・出力は全部で H' 行となります。末尾に改行を入れ、余計な文字、空行を含んではいけません。




条件
すべてのテストケースにおいて、以下の条件をみたします。

・1 ≦ H, W ≦ 300
・0 ≦ I_{id, i, j} ≦ 255 (1 ≦ id ≦ 2, 1 ≦ i ≦ H, 1 ≦ j ≦ W)




入力例1
2 3
0 255 255
0 255 255
0 0 0
255 255 255
出力例1
0 127 127 127 127
0 127 127 127 127
127 255 255 255 255


入力例2
1 3
0 200 100
100 100 100
出力例2
50 150 150 100 100



入力例3
7 7
0 0 0 167 0 0 0
0 0 167 167 167 0 0
0 167 167 167 167 167 0
167 167 167 167 167 167 167
0 167 167 167 167 167 0
0 0 167 167 167 0 0
0 0 0 167 0 0 0
0 0 0 167 0 0 0
0 0 167 167 167 0 0
0 167 167 167 167 167 0
167 167 167 167 167 167 167
0 167 167 167 167 167 0
0 0 167 167 167 0 0
0 0 0 167 0 0 0
出力例3
0 0 0 0 0 83 167 83 0 0 0 0 0
0 0 0 83 83 83 167 167 83 0 0 0 0
0 0 0 83 167 167 167 167 167 83 0 0 0
0 83 83 83 167 167 167 167 167 167 83 0 0
0 83 167 167 167 167 167 167 167 167 167 83 0
83 83 167 167 167 167 167 167 167 167 167 167 83
167 167 167 167 167 167 167 167 167 167 167 167 167
83 167 167 167 167 167 167 167 167 167 167 83 83
0 83 167 167 167 167 167 167 167 167 167 83 0
0 0 83 167 167 167 167 167 167 83 83 83 0
0 0 0 83 167 167 167 167 167 83 0 0 0
0 0 0 0 83 167 167 83 83 83 0 0 0
0 0 0 0 0 83 167 83 0 0 0 0 0
 */