using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tcp Client";
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Server Ip: ");
            var address = IPAddress.Parse(Console.ReadLine());
            var serverEndpoint = new IPEndPoint(address, 1308);
            while (true)
            {
                Console.Write("# Command > ");
                var request = Console.ReadLine();
                var client = new Socket(SocketType.Stream, ProtocolType.Tcp);
                client.Connect(serverEndpoint);
                // khởi tạo biến của NetworkStream từ tcp socket
                var stream = new NetworkStream(client);
                // lưu ý bổ sung \r\n vào cuối chuỗi truy vấn
                // do bên server sẽ sử dụng phương thức ReadLine của bộ tiếp hợp StreamReader,
                // nếu không bổ sung cặp \r\n thì ReadLine sẽ không thể dừng việc đọc
                var sendBuffer = Encoding.UTF8.GetBytes(request + "\r\n");
                // ghi mảng byte vào stream thay vì dùng phương thức Send của Socket
                stream.Write(sendBuffer, 0, sendBuffer.Length);
                // yêu cầu stream đẩy dữ liệu đi ngay
                // nếu không có lệnh này, dữ liệu sẽ nằm tại bộ nhớ tạm và tcp socket sẽ không nhận được
                stream.Flush();
                var receiveBuffer = new byte[1024];
                // đọc mảng byte từ stream thay vì dùng phương thức Receive của Socket
                var count = stream.Read(receiveBuffer, 0, 1024);
                var response = Encoding.UTF8.GetString(receiveBuffer, 0, count);
                // lưu ý cắt bỏ các ký tự thừa \r\n ở cuối chuỗi phản hồi trước khi in ra console
                // do bên server sẽ sử dụng phương thức WriteLine của bộ tiếp hop StreamWriter,
                // tất cả chuỗi gửi lên đường truyền đều tự động bổ sung cặp \r\n vào cuối, 
                // do đó chúng ta phải cắt bỏ trước khi in ra.
                Console.WriteLine(response.Trim());
                // đóng socket cũng đồng nghĩa với đóng và xóa bỏ các object của NetworkStream tạo ra từ socket này. 
                // Chúng ta cũng có thể gọi lệnh stream.Close() thay vì đóng socket. 
                // Khi đóng luồng mạng cũng sẽ tự đóng socket bên dưới
                client.Close();
            }
        }
    }
}