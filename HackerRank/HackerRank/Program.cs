namespace HackerRank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<string>> arr = new();
            List<string> arr2 = inputData.TrimEnd().Split("\r\n").ToList();
            foreach (var item in arr2) 
            {
                arr.Add(item.TrimEnd().Split(' ').ToList());
            }

            Console.WriteLine(countSort(arr));
            Console.WriteLine(expectedResult);
            //if (countSort(arr).Equals(expectedResult)) Console.WriteLine("YES");
            //else Console.WriteLine("NO");
            
            string s1 = countSort(arr);
            string s2 = expectedResult;
            var diffs = s1.Zip(s2, (c1, c2) => new { Char1 = c1, Char2 = c2 })
            .Where(pair => pair.Char1 != pair.Char2)
            .ToList();

            Console.WriteLine($"Có {diffs.Count} ký tự khác nhau:");
            foreach (var diff in diffs)
            {
                Console.WriteLine($"- '{diff.Char1}' khác '{diff.Char2}'");
            }
            

        }





        public static string countSort(List<List<string>> arr)
        {
            //var temp = arr.OrderBy(a => a[0]);
            //Console.WriteLine(string.Join(" ", arr.Select(el => el[0] + el[1])));
            for (int i = 0; i < arr.Count; i++)
            {
                if (i < arr.Count / 2) arr[i][1] = "-";
                arr[i].Add(i.ToString());
            }
            //Console.WriteLine(string.Join(" ", arr.Select(el => el[0] + el[1])));
            
            //Console.WriteLine(string.Join(" ", arr.OrderBy(a => a[0]).Select(el => el[0] + el[1])));
            //arr.Sort((a, b) => int.Parse(a[0]) - int.Parse(b[0])); //
            //Console.WriteLine("arr.Sort((a, b) => Int32.Parse(a[2]).CompareTo(Int32.Parse(b[2])));");
            //arr.Sort((a, b) => Int32.Parse(a[2]).CompareTo(Int32.Parse(b[2])));
            //Console.WriteLine(string.Join(" ", arr.Select(el => el[0] + el[1] + el[2])));
            //var temp = arr.OrderBy(a => a[0]);//.ThenBy(a => a[1]);
            //Console.WriteLine(string.Join(" ", arr.Select(el => el[0] + el[1])));
            
            // Tạo một mảng mới chứa các đối tượng số/chuỗi
            //var sortedArr = arr.OrderBy(x => int.Parse(x[0])).ThenBy(x => x[1]).Select(x => new { Number = int.Parse(x[0]), Text = x[1] });

            // Trích xuất phần tử thứ hai của mỗi đối tượng trong mảng đã sắp xếp và nối chúng lại để tạo chuỗi kết quả
            //string result = string.Join(" ", sortedArr.Select(x => x.Text));
            //Console.WriteLine(result);
            
            
            return string.Join(" ", arr
                .OrderBy(el => int.Parse(el[0]))
                //.ThenBy((a,b) => int.Parse(a[2]).CompareTo(int.Parse(b[2])))
                .ThenBy(x => int.Parse(x[2]))
                .Select(el => el[1]));
        }






        public static string expectedResult = "- - - - - - - - - pq qy uz eb fo - - - - - mc yu no wf - - - - - sd wv dw cd hr qo tr zv ev - - - kx sd ot - - - - - - qd ou ew mx aq ai vm ux me - - - vj zh rt dq er - - - - - - - - uy xm hl cs pl - - - - - iz cc ja lx de gy cr zp ll - - - ot cx vr dk - - - - op vu un - - - - oe la dt im - - - - - - ek me mq el ud xz nn os xu - - - - - - - - ll nz - - - - - - no nn mr li - - iv qd - - - - - - - hp gf xl yl mh kp - - - - - fa dr rm nt rf gk - - - - - - wv jy oo qv we - - - - - - jh gh ej es is - - - - - - qs fr - - - - - mj rl wj - bq bo qh os jn - - - - - - - vx zi yw - - - - - rj bl xg - - - - - - - - av cq py up - - - - nq zh oj pc aj md ly - - - - bq jt hc fx - - - - - - cz ya co gr xa - - - - da rv qi qy - - - - - - - - - au hj wj be co lv - - - - - - - jp so if zf lg - - - - so og lv cx pz cg wo - - mn py nm jv oj lt - - - - - - - iy iv pz qb pj te lw - - - - - ry nt jx co am - - - - - - bz iy uj fk - - - - cw zx yv io - - - - - un zk hj rw - - - iv yw ft pf - - - kj to pq ki qi wd - - - - - - wf xz yg ru ts zo hv - - - - - - - - kj ol vs os ls ho - - - - - - - my du ut - - - di qk lf ud on kd bb - - - - ee bt qa pi wu - - - - - - ei vl eu qi yp tz - - - - - - - pu zq ys xu ng tz rk hk - - - ma lz jl nv - - - - rh io on ek op qk - - - - - xj mb - - sf wi mh oo - - - ul - fe qs ac kw yf go ps hi tw - - - - - - kn mg jj im di rl rs - - - - - - - - - nn ky lj ep sf kv - - vo xd uz - - - bd vh gw xp qf wx - - - - - - - - dv yy oq re bd iy bw - - - - ny ww fz yc - - - - - - - - - ku lh ts - - - - - hc ud va hu vn - - - - ku fm cc gc kb ed ne tl - - - - - - ev bk br en vo vn pz wc - - wb od dn ib xu pk fn - - - - bl sc jx - - - - ho sh gs - - - uc kl bd - - - - ft ci rk zh - - - sh fc sj - - - - - - - - - bv dx ty ur wq up ie hm ta qi eu - - - - bm hs or bu - - - zd mp ig ey wx - - - - - zo cp fu ul - - - - - - - - - - gj ad za rt - - - - - - uo mf gv xl hc yj pi - - - - - - - - ww ze zr zd ug jg - - - - - - cg yh pi - - - em gd bd jn ug tc ls - - - - - - - uw ht bq - - - do ls - - - - - - - bx rv zg py is hf fv - - - - ov gz vf - - - vk gu wk fj - - - - bx ee kc - - - - - ad me sp rn - - - - - - - hq kh gm vy it jy - - - - kw ng - - - - - ht jt ye gu hz vn - - - - - - - - - vd py go - - - - gc hb cv ia hz fb hd ql - - qo yk hh jp ds rg zl dz - - - - - - - - df vp xo sg yk hc bw wn dx la - - - - ms dd ut yb kl sd hq zh ga cj - - - - lx zk zh wr hf - - - - im by - - - - - jk uu fj aq bz - - nh wt - - - fe pv kk wf bk - - - - - sj xo - - - - - - jn cx nr xx";

        public static string inputData = "24 oz\r\n36 xr\r\n43 cu\r\n44 oq\r\n55 qf\r\n2 oz\r\n96 bk\r\n1 tv\r\n2 jy\r\n27 wy\r\n30 kj\r\n11 mn\r\n85 mp\r\n3 wu\r\n54 zq\r\n80 ee\r\n29 rv\r\n46 wi\r\n13 zu\r\n37 rv\r\n29 sc\r\n59 on\r\n76 ts\r\n86 wf\r\n49 gg\r\n9 yc\r\n2 gr\r\n46 ny\r\n56 ws\r\n15 jr\r\n74 lc\r\n50 ag\r\n77 vk\r\n16 er\r\n84 cf\r\n82 dn\r\n12 ss\r\n4 pe\r\n35 pm\r\n28 qo\r\n47 ym\r\n54 lr\r\n34 bx\r\n18 jm\r\n20 kn\r\n86 av\r\n17 rx\r\n35 zb\r\n14 il\r\n10 zo\r\n43 lk\r\n58 fk\r\n0 xs\r\n91 cn\r\n4 qq\r\n95 fw\r\n75 eo\r\n83 pr\r\n65 tc\r\n11 vd\r\n32 kr\r\n55 so\r\n24 dk\r\n51 br\r\n38 db\r\n19 sr\r\n91 ir\r\n76 fe\r\n60 hr\r\n0 jz\r\n44 ju\r\n26 td\r\n70 ki\r\n62 zd\r\n42 tb\r\n60 cg\r\n71 zj\r\n31 bw\r\n57 ti\r\n69 we\r\n28 ur\r\n24 pd\r\n24 tj\r\n65 dk\r\n94 cc\r\n27 az\r\n33 pm\r\n42 dp\r\n57 pz\r\n49 dt\r\n73 ia\r\n17 li\r\n69 rv\r\n39 hm\r\n41 vq\r\n4 br\r\n73 xo\r\n70 nr\r\n45 hv\r\n75 yl\r\n58 ah\r\n39 fv\r\n48 tw\r\n45 eb\r\n94 zy\r\n57 vo\r\n42 sq\r\n41 kn\r\n1 io\r\n13 iz\r\n29 yu\r\n21 tn\r\n91 ov\r\n75 jq\r\n91 yl\r\n46 br\r\n86 vc\r\n84 mm\r\n30 ls\r\n78 rf\r\n99 uj\r\n24 nk\r\n15 ln\r\n76 nn\r\n83 jw\r\n71 hm\r\n72 hm\r\n46 pz\r\n10 ms\r\n40 un\r\n96 vf\r\n62 cn\r\n87 hj\r\n6 kz\r\n41 bt\r\n78 qa\r\n97 yo\r\n26 qc\r\n1 gr\r\n61 eq\r\n7 gh\r\n73 dt\r\n7 zb\r\n88 at\r\n67 wq\r\n35 lo\r\n81 jw\r\n17 de\r\n24 vf\r\n75 eh\r\n79 mo\r\n68 ol\r\n41 gs\r\n31 pa\r\n22 ji\r\n80 nu\r\n82 jl\r\n95 ln\r\n15 fy\r\n57 xd\r\n91 jb\r\n85 pv\r\n84 ra\r\n73 qg\r\n73 lf\r\n51 py\r\n84 br\r\n68 nd\r\n13 ve\r\n98 xb\r\n24 xo\r\n0 sy\r\n15 dl\r\n28 oy\r\n94 el\r\n54 mf\r\n47 fu\r\n9 fb\r\n34 zg\r\n99 tb\r\n56 ho\r\n74 wy\r\n88 gb\r\n72 uh\r\n66 su\r\n83 qf\r\n59 zy\r\n69 ye\r\n35 tj\r\n63 du\r\n25 cw\r\n73 og\r\n62 bv\r\n6 gp\r\n92 ux\r\n16 eg\r\n27 vo\r\n19 vz\r\n94 ly\r\n17 ip\r\n23 bf\r\n28 wh\r\n62 tm\r\n87 jp\r\n87 la\r\n0 yv\r\n57 hq\r\n54 rd\r\n61 ga\r\n32 ss\r\n37 sn\r\n18 ft\r\n83 hm\r\n50 es\r\n72 mz\r\n41 ka\r\n0 ww\r\n30 wl\r\n62 dg\r\n4 ov\r\n85 ch\r\n58 fm\r\n41 bq\r\n81 rm\r\n92 ho\r\n22 sy\r\n49 gh\r\n19 zg\r\n25 fv\r\n58 mh\r\n25 tu\r\n5 km\r\n74 ob\r\n73 rv\r\n12 ia\r\n0 zp\r\n23 pt\r\n62 cw\r\n98 jc\r\n13 hp\r\n47 oz\r\n85 ye\r\n46 qi\r\n40 qf\r\n60 iy\r\n3 ie\r\n85 ab\r\n40 ro\r\n33 ym\r\n43 rg\r\n26 yc\r\n88 vu\r\n85 os\r\n54 el\r\n1 un\r\n10 ah\r\n93 fe\r\n78 zo\r\n78 xo\r\n14 hj\r\n20 ht\r\n88 px\r\n79 vv\r\n70 rn\r\n20 tc\r\n0 oh\r\n5 xh\r\n57 kt\r\n45 wb\r\n22 jt\r\n24 ke\r\n67 fc\r\n33 uk\r\n59 jz\r\n42 nk\r\n16 gb\r\n91 ba\r\n48 nl\r\n86 gz\r\n89 ae\r\n73 fa\r\n19 yi\r\n95 kt\r\n61 jv\r\n45 ue\r\n29 jq\r\n8 mz\r\n99 yr\r\n81 mp\r\n53 jw\r\n48 kb\r\n6 tj\r\n67 xt\r\n40 ou\r\n6 bc\r\n38 sa\r\n11 xk\r\n1 bq\r\n78 pf\r\n69 vr\r\n19 ex\r\n52 ij\r\n59 cl\r\n95 mj\r\n13 bk\r\n30 pe\r\n65 yf\r\n54 nh\r\n80 tl\r\n11 xp\r\n15 fx\r\n71 on\r\n18 rk\r\n12 vf\r\n54 dc\r\n59 ni\r\n99 su\r\n89 bl\r\n2 rm\r\n77 eu\r\n3 ur\r\n0 fu\r\n90 mh\r\n93 oc\r\n22 vu\r\n60 ax\r\n59 zk\r\n78 kl\r\n68 np\r\n29 nw\r\n98 yj\r\n88 qh\r\n36 vo\r\n40 za\r\n75 fv\r\n10 mu\r\n53 sp\r\n39 nb\r\n42 qe\r\n31 cv\r\n48 bq\r\n27 is\r\n88 qo\r\n27 un\r\n22 hp\r\n42 ui\r\n35 jb\r\n46 nm\r\n15 ed\r\n56 rn\r\n11 tn\r\n64 ro\r\n29 yd\r\n6 rj\r\n69 va\r\n53 cb\r\n13 tp\r\n23 ck\r\n59 bl\r\n45 co\r\n7 iw\r\n23 pv\r\n6 ec\r\n75 sp\r\n80 zm\r\n77 mk\r\n44 zo\r\n88 ha\r\n42 om\r\n41 po\r\n34 on\r\n5 le\r\n78 fm\r\n27 rv\r\n9 bk\r\n49 up\r\n75 nj\r\n20 hf\r\n41 wp\r\n18 lv\r\n91 aq\r\n95 np\r\n35 hu\r\n12 km\r\n29 qh\r\n19 zt\r\n25 ez\r\n33 us\r\n53 bo\r\n76 ki\r\n61 jd\r\n8 rp\r\n87 hb\r\n88 ok\r\n70 ay\r\n64 sn\r\n16 ty\r\n53 si\r\n18 om\r\n12 rs\r\n12 yv\r\n80 ft\r\n80 ll\r\n22 sj\r\n75 nc\r\n69 xx\r\n54 qx\r\n16 rz\r\n67 mr\r\n74 wb\r\n17 wf\r\n64 rk\r\n49 hq\r\n6 jw\r\n74 fa\r\n8 gl\r\n7 lx\r\n40 oo\r\n29 yk\r\n65 nc\r\n37 vm\r\n97 ir\r\n80 au\r\n2 ho\r\n30 xi\r\n91 rr\r\n9 jo\r\n89 zb\r\n51 dl\r\n98 vj\r\n81 cr\r\n59 dc\r\n7 rq\r\n17 sm\r\n64 ur\r\n36 de\r\n37 rh\r\n15 yt\r\n59 ah\r\n89 at\r\n82 yw\r\n73 ww\r\n34 ar\r\n46 xa\r\n92 fv\r\n33 oq\r\n88 ol\r\n85 cn\r\n29 sz\r\n44 cg\r\n33 no\r\n30 bv\r\n97 vs\r\n0 ou\r\n18 cg\r\n33 pm\r\n34 wn\r\n12 vd\r\n31 el\r\n4 ah\r\n69 ke\r\n98 lo\r\n69 hw\r\n4 ks\r\n23 ca\r\n72 yb\r\n72 ie\r\n57 qt\r\n66 sj\r\n74 vu\r\n45 hn\r\n76 gf\r\n26 oy\r\n92 kv\r\n53 ji\r\n66 sn\r\n84 pu\r\n60 kq\r\n37 ul\r\n54 gi\r\n93 gv\r\n12 pl\r\n6 by\r\n90 ux\r\n30 gj\r\n38 gl\r\n93 ja\r\n87 fu\r\n36 dk\r\n76 zz\r\n73 db\r\n79 rd\r\n11 qi\r\n63 oq\r\n22 fu\r\n57 wn\r\n99 cs\r\n99 hy\r\n69 wo\r\n20 zo\r\n69 bv\r\n43 di\r\n38 iv\r\n32 mn\r\n57 dv\r\n43 qk\r\n9 op\r\n71 zd\r\n34 ry\r\n67 ft\r\n25 nq\r\n52 fe\r\n0 pq\r\n43 lf\r\n80 bx\r\n91 df\r\n59 ku\r\n91 vp\r\n31 so\r\n60 hc\r\n4 qd\r\n30 jp\r\n27 cz\r\n25 zh\r\n39 kj\r\n18 jh\r\n8 ot\r\n16 fa\r\n76 cg\r\n17 wv\r\n38 yw\r\n45 ei\r\n11 ek\r\n48 rh\r\n83 bx\r\n62 ev\r\n36 cw\r\n7 iz\r\n95 jk\r\n61 ku\r\n89 gc\r\n17 jy\r\n52 qs\r\n43 ud\r\n26 bq\r\n21 bq\r\n66 uc\r\n4 ou\r\n20 mj\r\n3 kx\r\n55 vo\r\n42 my\r\n77 em\r\n95 uu\r\n4 ew\r\n50 sf\r\n31 og\r\n35 bz\r\n67 ci\r\n73 gj\r\n2 sd\r\n79 do\r\n5 vj\r\n85 hq\r\n47 ma\r\n6 uy\r\n44 ee\r\n58 ny\r\n63 wb\r\n48 io\r\n90 qo\r\n76 yh\r\n53 kn\r\n8 cx\r\n90 yk\r\n2 wv\r\n87 ht\r\n67 rk\r\n4 mx\r\n1 mc\r\n41 kj\r\n50 wi\r\n81 ov\r\n91 xo\r\n52 ac\r\n26 jt\r\n40 wf\r\n63 od\r\n91 sg\r\n87 jt\r\n75 ww\r\n61 fm\r\n16 dr\r\n71 mp\r\n50 mh\r\n46 pu\r\n69 dx\r\n17 oo\r\n53 mg\r\n3 sd\r\n74 uo\r\n0 qy\r\n39 to\r\n89 hb\r\n6 xm\r\n11 me\r\n47 lz\r\n6 hl\r\n43 on\r\n56 bd\r\n71 ig\r\n90 hh\r\n99 jn\r\n12 ll\r\n80 rv\r\n7 cc\r\n41 ol\r\n91 yk\r\n92 ms\r\n62 bk\r\n33 iy\r\n15 hp\r\n52 kw\r\n72 zo\r\n20 rl\r\n57 yy\r\n62 br\r\n34 nt\r\n29 au\r\n28 da\r\n3 ot\r\n50 oo\r\n44 bt\r\n97 fe\r\n45 vl\r\n86 kw\r\n97 pv\r\n9 vu\r\n23 rj\r\n83 ee\r\n69 ty\r\n89 cv\r\n11 mq\r\n39 pq\r\n93 lx\r\n25 oj\r\n18 gh\r\n71 ey\r\n40 xz\r\n55 xd\r\n64 bl\r\n21 bo\r\n15 gf\r\n98 sj\r\n10 oe\r\n2 dw\r\n28 rv\r\n31 lv\r\n40 yg\r\n72 cp\r\n63 dn\r\n45 eu\r\n64 sc\r\n63 ib\r\n87 ye\r\n43 kd\r\n53 jj\r\n41 vs\r\n85 kh\r\n39 ki\r\n46 zq\r\n32 py\r\n54 nn\r\n61 cc\r\n35 iy\r\n52 yf\r\n27 ya\r\n33 iv\r\n34 jx\r\n71 wx\r\n29 hj\r\n85 gm\r\n91 hc\r\n43 bb\r\n57 oq\r\n91 bw\r\n57 re\r\n26 hc\r\n13 no\r\n32 nm\r\n37 un\r\n44 qa\r\n64 jx\r\n99 cx\r\n29 wj\r\n37 zk\r\n69 ur\r\n61 gc\r\n91 wn\r\n33 pz\r\n11 el\r\n73 ad\r\n93 zk\r\n66 kl\r\n54 ky\r\n32 jv\r\n0 uz\r\n10 la\r\n97 kk\r\n27 co\r\n96 nh\r\n75 ze\r\n11 ud\r\n14 iv\r\n34 co\r\n80 zg\r\n21 qh\r\n58 ww\r\n6 cs\r\n61 kb\r\n74 mf\r\n5 zh\r\n69 wq\r\n62 en\r\n84 ad\r\n17 qv\r\n63 xu\r\n93 zh\r\n2 cd\r\n99 nr\r\n2 hr\r\n62 vo\r\n5 rt\r\n52 go\r\n54 lj\r\n57 bd\r\n0 eb\r\n19 qs\r\n53 im\r\n72 fu\r\n28 qi\r\n77 gd\r\n28 qy\r\n18 ej\r\n7 ja\r\n77 bd\r\n48 on\r\n76 pi\r\n93 wr\r\n94 im\r\n11 xz\r\n70 bm\r\n53 di\r\n36 zx\r\n15 xl\r\n18 es\r\n1 yu\r\n49 xj\r\n16 rm\r\n82 vk\r\n80 py\r\n94 by\r\n2 qo\r\n40 ru\r\n53 rl\r\n74 gv\r\n30 so\r\n52 ps\r\n82 gu\r\n53 rs\r\n35 uj\r\n41 os\r\n39 qi\r\n61 ed\r\n34 am\r\n89 ia\r\n65 ho\r\n90 jp\r\n62 vn\r\n91 dx\r\n60 ud\r\n69 up\r\n33 qb\r\n6 pl\r\n16 nt\r\n29 be\r\n7 lx\r\n29 co\r\n5 dq\r\n89 hz\r\n26 fx\r\n21 os\r\n25 pc\r\n25 aj\r\n8 vr\r\n56 vh\r\n18 is\r\n60 va\r\n10 dt\r\n4 aq\r\n62 pz\r\n27 gr\r\n25 md\r\n87 gu\r\n75 zr\r\n68 sh\r\n30 if\r\n95 fj\r\n33 pj\r\n74 xl\r\n11 nn\r\n2 tr\r\n82 wk\r\n69 ie\r\n25 ly\r\n61 ne\r\n92 dd\r\n47 jl\r\n46 ys\r\n5 er\r\n7 de\r\n70 hs\r\n59 lh\r\n46 xu\r\n22 vx\r\n21 jn\r\n48 ek\r\n48 op\r\n69 hm\r\n45 qi\r\n92 ut\r\n69 ta\r\n97 wf\r\n84 me\r\n96 wt\r\n90 ds\r\n90 rg\r\n22 zi\r\n32 oj\r\n10 im\r\n15 yl\r\n60 hu\r\n56 gw\r\n83 kc\r\n36 yv\r\n23 bl\r\n77 jn\r\n7 gy\r\n77 ug\r\n58 fz\r\n44 pi\r\n92 yb\r\n11 os\r\n92 kl\r\n1 no\r\n85 vy\r\n75 zd\r\n37 hj\r\n45 yp\r\n54 ep\r\n52 hi\r\n95 aq\r\n41 ls\r\n62 wc\r\n91 la\r\n56 xp\r\n31 cx\r\n32 lt\r\n2 zv\r\n12 nz\r\n44 wu\r\n51 ul\r\n66 bd\r\n29 lv\r\n92 sd\r\n24 av\r\n77 tc\r\n4 ai\r\n74 hc\r\n59 ts\r\n87 hz\r\n46 ng\r\n60 vn\r\n81 gz\r\n58 yc\r\n15 mh\r\n74 yj\r\n57 iy\r\n56 qf\r\n89 fb\r\n80 is\r\n73 za\r\n85 it\r\n81 vf\r\n74 pi\r\n88 vd\r\n23 xg\r\n40 ts\r\n27 xa\r\n67 zh\r\n30 zf\r\n48 qk\r\n54 sf\r\n9 un\r\n31 pz\r\n4 vm\r\n88 py\r\n80 hf\r\n77 ls\r\n78 uw\r\n73 rt\r\n70 or\r\n33 te\r\n13 nn\r\n75 ug\r\n0 fo\r\n42 du\r\n55 uz\r\n68 fc\r\n87 vn\r\n13 mr\r\n98 xo\r\n80 fv\r\n97 bk\r\n92 hq\r\n46 tz\r\n41 ho\r\n79 ls\r\n38 ft\r\n19 fr\r\n8 dk\r\n37 rw\r\n15 kp\r\n30 lg\r\n42 ut\r\n78 ht\r\n70 bu\r\n22 yw\r\n36 io\r\n35 fk\r\n52 tw\r\n78 bq\r\n56 wx\r\n7 cr\r\n92 zh\r\n4 ux\r\n24 cq\r\n33 lw\r\n38 pf\r\n88 go\r\n49 mb\r\n46 rk\r\n65 sh\r\n75 jg\r\n86 ng\r\n14 qd\r\n39 wd\r\n84 sp\r\n40 zo\r\n2 ev\r\n68 sj\r\n46 hk\r\n13 li\r\n16 rf\r\n16 gk\r\n84 rn\r\n72 ul\r\n7 zp\r\n31 cg\r\n90 zl\r\n63 pk\r\n69 qi\r\n95 bz\r\n24 py\r\n69 eu\r\n31 wo\r\n4 me\r\n85 jy\r\n92 ga\r\n1 wf\r\n99 xx\r\n90 dz\r\n63 fn\r\n11 xu\r\n89 hd\r\n61 tl\r\n89 ql\r\n24 up\r\n92 cj\r\n93 hf\r\n57 bw\r\n82 fj\r\n65 gs\r\n40 hv\r\n54 kv\r\n47 nv\r\n45 tz\r\n17 we\r\n20 wj\r\n7 ll";

        //public static string inputData = "0 ab\r\n6 cd\r\n0 ef\r\n6 gh\r\n4 ij\r\n0 ab\r\n6 cd\r\n0 ef\r\n6 gh\r\n0 ij\r\n4 that\r\n3 be\r\n0 to\r\n1 be\r\n5 question\r\n1 or\r\n2 not\r\n4 is\r\n2 to\r\n4 the";
    }



}