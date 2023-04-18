using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tcp Server";
            var listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 1308));
            listener.Listen(10);
            Console.WriteLine($"Server started at {listener.LocalEndPoint}");
            while (true)
            {
                var worker = listener.Accept();
                // khởi tạo object của NetworkStream từ tcp socket
                var stream = new NetworkStream(worker);
                // sử dụng bộ tiếp hợp StreamReader để đọc chuỗi truy vấn
                // vì truy vấn ở dạng chuỗi (theo quy ước giữa client và server), StreamReader sẽ giúp đọc chuỗi byte 
                // từ luồng NetworkStream và tự động chuyển đổi thành chuỗi ký tự Utf-8
                var reader = new StreamReader(stream);
                // sử dụng bộ tiếp học StreamWriter để ghi chuỗi phản hồi vào luồng NetworkStream
                // vì phản hồi ở dạng chuỗi theo quy ước giữa client và server, StreamWriter sẽ giúp biến đổi 
                // chuỗi ký tự (utf-8) thành mảng byte và đưa vào luồng NetworkStream
                // chú ý sử dụng AutoFlush = true để tự động flush luồng NetworkStream
                var writer = new StreamWriter(stream) { AutoFlush = true };
                // đọc thông qua bộ tiếp hợp thay vì đọc trực tiếp chuỗi byte từ luồng NetworkStream
                // phương thức ReadLine của StreamReader sẽ tự làm việc với NetworkStream bên trong để đọc ra 
                // chuỗi byte, sau đó tự động biến đổi thành chuỗi utf-8.
                // lưu ý: lệnh ReadLine sẽ đọc đến khi nào nhìn thấy cặp ký tự \r\n thì sẽ dừng lại. 
                // Trong kết quả trả về, ReadLine sẽ xóa bỏ hai ký tự thừa này. Vì vậy, ở client chúng ta phải 
                // tự bổ sung cặp \r\n vào cuối chuỗi truy vấn. Nếu không làm như vậy, ReadLine sẽ không dừng việc đọc.
                var request = reader.ReadLine();
                var response = string.Empty;
                switch (request.ToLower())
                {
                    case "date": response = DateTime.Now.ToLongDateString(); break;
                    case "time": response = DateTime.Now.ToLongTimeString(); break;
                    case "year": response = DateTime.Now.Year.ToString(); break;
                    case "month": response = DateTime.Now.Month.ToString(); break;
                    case "day": response = DateTime.Now.Day.ToString(); break;
                    case "dow": response = DateTime.Now.DayOfWeek.ToString(); break;
                    case "doy": response = DateTime.Now.DayOfYear.ToString(); break;
                    default: response = "UNKNOW COMMAND"; break;
                }
                // ghi thẳng chuỗi utf-8 vào luồng bằng phương thức WriteLine của StreamWriter 
                // thay vì tự biến đổi chuỗi sang mảng byte.
                // phương thức WriteLine tự thêm cặp \r\n vào cuối chuỗi, 
                // tự động biến đổi chuỗi này thành mảng byte và ghi vào stream.
                // vì lý do này, bên client sẽ phải tự mình cắt bỏ chuỗi \r\n trước khi in ra.
                // nếu sử dụng ReadLine của StreamReader thì không cần tự cắt bỏ \r\n 
                // vì ReadLine sẽ tự động xóa bỏ cặp ký tự này giúp.
                writer.WriteLine(response);
                // nếu không sử dụng AutoFlush thì phải tự mình gọi lệnh Flush
                //writer.Flush();
                // đóng socket sẽ đóng toàn bộ các luồng liên quan
                worker.Close();
            }
        }
    }
}