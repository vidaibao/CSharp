namespace SumXor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = 10;// long.MaxValue;
            Console.WriteLine(sumXor(n));

            Console.WriteLine($"n = {n}; Convert.ToString(n, 2) = \"{Convert.ToString(n, 2)}\"");
            Console.WriteLine(string.Join(", ", Convert.ToString(n, 2).Split('0')));
            Console.WriteLine(Convert.ToString(n, 2).Split('0').Length);
        }




        public static long sumXor(long n)
        {
            if (n == 0) return 1;
            return Math.Log(n, 2) % 1 == 0
                    ? n
                    : (long)Math.Pow(2, Convert.ToString(n, 2).Split('0').Length - 1);
        }
        /*
        Hàm sumXor nhận đầu vào là một số nguyên dương n kiểu long và trả về kết quả là một số nguyên dương kiểu long.

        Để hiểu hàm này, trước hết chúng ta cần biết về phép toán XOR giữa hai số nguyên không âm. 
        Phép toán XOR (còn gọi là phép toán "hoặc loại trừ") giữa hai số nguyên không âm a và b là kết quả của 
        phép tính nhị phân khi mỗi bit tương ứng của a và b được so sánh.
        Cụ thể, kết quả của phép toán XOR giữa hai bit sẽ là 1 nếu hai bit tương ứng khác nhau và là 0 nếu hai bit tương ứng giống nhau.

        Trong hàm sumXor, trường hợp đơn giản là khi n bằng 0 thì trả về giá trị 1. 
        Trong trường hợp n khác 0, hàm kiểm tra xem n có phải là một lũy thừa của 2 hay không. 
        Nếu là lũy thừa của 2, hàm trả về n (vì theo định nghĩa, XOR giữa một số và chính nó là 0, nên n XOR n sẽ bằng n). 
        Nếu n không phải là lũy thừa của 2, hàm sẽ tính số bit 0 trong biểu diễn nhị phân của n và trả về 2 mũ số lượng bit 0 đó.

        Vì sao lại làm như vậy? Khi tính x XOR n, ta cần tìm giá trị x để phép toán này có giá trị bằng n + x. 
        Nếu n là lũy thừa của 2, giá trị của x phải là n (vì nếu không, phép XOR sẽ tạo ra các bit 1 và không thể bù vào n). 
        Nếu n không phải lũy thừa của 2, thì ta sẽ tìm giá trị x sao cho XOR giữa x và n không tạo ra bit 1 nào 
        (vì các bit 1 này không có trong n+x và không thể bù vào x). 
        Khi đó, XOR giữa x và n sẽ chỉ còn lại các bit 0, và tổng của nó sẽ bằng n+x.

        Để tìm giá trị x như vậy, ta có thể đếm số bit 0 trong biểu diễn nhị phân của n, 
        sau đó tạo một số x có các bit 1 tương ứng với các bit 0 trong n.

        (long)Math.Pow(2, Convert.ToString(n, 2).Split('0').Length - 1);
        Dòng lệnh này sử dụng phương thức Convert.ToString(n, 2) để chuyển đổi giá trị của số nguyên n sang chuỗi nhị phân. 
        Sau đó, sử dụng phương thức Split('0') để tách chuỗi nhị phân thành một mảng các chuỗi con, sử dụng ký tự "0" làm dấu phân tách.

        Ví dụ, nếu n có giá trị là 10, thì chuỗi nhị phân tương ứng là "1010". Sau khi áp dụng Split('0'), 
        mảng các chuỗi con sẽ là ["1", "1", ""].

        Tiếp theo, ta lấy độ dài của mảng trên trừ đi 1 và tính 2 mũ (độ dài này chính là số lượng các ký tự "1" 
        trong chuỗi nhị phân tương ứng với n). Cuối cùng, kết quả được ép kiểu về kiểu long và trả về.

        Ví dụ, với n có giá trị là 10 như trên, độ dài của mảng trên sẽ là 3, sau khi trừ đi 1 sẽ có giá trị là 2, 
        và 2 mũ 2 sẽ có giá trị là 4. Do đó, kết quả trả về của hàm sẽ là 4.
        */



        public static long sumXor00(long n)
        {
            long res = 0;
            for (long x = 0; x <= n; x++)
            {
                if (x + n == (x ^ n))
                {
                    res++;
                }
                    
            }

            return res;
        }

    }
}