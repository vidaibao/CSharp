namespace SubarrayDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> s = new List<int> { 2, 2, 1, 3, 2 };
            //List<int> s = new List<int> { 4 };
            int d = 4;
            int m = 2;
            Console.WriteLine($"birthday(List<int> s = {string.Join(", ", s)}, int d = {d}, int m = {m}) return {birthday(s, d, m)}");

            Console.WriteLine(string.Join(", ",Enumerable.Range(0, s.Count - m + 1)));
        }



        /*
         *  int s[n]: the numbers on each of the squares of chocolate
            int d: Ron's birth day
            int m: Ron's birth month
         */
        public static int birthday(List<int> s, int d, int m)
        {
            var result = Enumerable.Range(0, s.Count - m + 1)
                        .Where(i => s.Skip(i).Take(m).Sum() == d)
                        .Select(i => s.Skip(i).Take(m));

            return result.Count();
            /*  Tạo một chuỗi số nguyên liên tiếp từ 0 đến độ dài của mảng s cộng thêm một, 
             *  đây là chỉ số của phần tử đầu tiên của các tổ hợp m phần tử liên tiếp trong mảng.
                Lọc các chỉ số thỏa mãn tổng của các phần tử trong một tổ hợp m phần tử bằng d.
                Chọn các phần tử trong mảng dựa trên chỉ số đã được lọc và trả về một danh sách các tổ hợp phù hợp.

            Khi sử dụng LINQ để giải quyết bài toán này, chúng ta sẽ sử dụng phương thức Enumerable.Range() 
            để tạo ra một chuỗi số nguyên liên tiếp từ 0 đến độ dài của mảng arr trừ đi số lượng phần tử trong mỗi tổ hợp 
            mà chúng ta đang tìm kiếm, cộng thêm một.
            Vì vậy, dãy các số nguyên liên tiếp từ 0 đến arr.Length - m là tập hợp các chỉ số đánh dấu vị trí 
            bắt đầu của các tổ hợp liên tiếp có độ dài m trong mảng arr, mà chúng ta sẽ sử dụng để lọc và trích xuất các tổ hợp này.
            Trong đoạn mã LINQ này, dãy các số nguyên liên tiếp từ 0 đến arr.Length - m đóng vai trò tương tự 
            như một biến đếm trong vòng lặp for, chỉ đơn giản là thay vì sử dụng vòng lặp, chúng ta 
            sử dụng phương thức Enumerable.Range để tạo ra một dãy các số nguyên liên tiếp và thực hiện các thao tác trên 
            dãy này bằng các phương thức của LINQ.

            Lý do chúng ta thực hiện điều này là để tạo ra một chuỗi các chỉ số mà chúng ta có thể sử dụng để 
            trích xuất ra các tổ hợp có độ dài m từ mảng arr. Cụ thể, chúng ta sử dụng phương thức Skip() để bỏ qua i 
            phần tử đầu tiên của mảng arr, sau đó sử dụng phương thức Take() để lấy ra m phần tử tiếp theo. 
            Vì vậy, nếu chúng ta không tăng giá trị trả về của phương thức Enumerable.Range() lên một, 
            chúng ta sẽ bỏ qua được một số tổ hợp có thể phù hợp.

            Ví dụ, nếu arr có 7 phần tử và chúng ta đang tìm kiếm các tổ hợp liên tiếp gồm 3 phần tử có tổng bằng A,
            thì chúng ta muốn tạo ra một chuỗi số nguyên liên tiếp từ 0 đến 5 (tức là arr.Length - m + 1),
            để có thể tìm kiếm các tổ hợp có thể bắt đầu từ vị trí 0, 1, 2, 3, 4, hoặc 5 trong mảng arr.
            Nếu chúng ta không tăng giá trị trả về của phương thức Enumerable.Range() lên một,
            chúng ta sẽ bỏ qua được tổ hợp có thể bắt đầu từ vị trí 5 trong mảng arr.
            */
        }


        public static int birthday00(List<int> s, int d, int m)
        {
            int count = 0;
            for (int i = 0; i <= s.Count - m; i++)
            {
                int sum = 0;
                for (int j = i; j < i + m; j++)
                {
                    sum += s[j];
                }
                if (sum == d)
                {
                    count++;
                }
            }
            return count;
        }


    }
}