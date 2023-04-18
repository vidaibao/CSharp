using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //tcpServer();
            getDNS();
            //tcpServer_tcpListenerClass();
            receivePrimitiveData();
        }









        static void receivePrimitiveData()
        {
            var listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 1308));
            listener.Listen(10);
            while (true)
            {
                var client = listener.Accept();
                var buffer = new byte[8];
                // đọc 1 byte đầu tiên và chuyển thành biến bool
                client.Receive(buffer, 1, SocketFlags.None);
                var aBool = BitConverter.ToBoolean(buffer, 0);
                Console.WriteLine($"bool: {aBool}");
                // đọc 2 byte tiếp theo chuyển thành char
                client.Receive(buffer, 2, SocketFlags.None);
                var aChar = BitConverter.ToChar(buffer, 0);
                Console.WriteLine($"char: {aChar}");
                // đọc 8 byte tiếp theo chuyển thành double
                client.Receive(buffer, 8, SocketFlags.None);
                var aDouble = BitConverter.ToDouble(buffer, 0);
                Console.WriteLine($"double: {aDouble}");
                // đọc 4 byte tiếp theo chuyển thành int
                client.Receive(buffer, 4, SocketFlags.None);
                var anInt = BitConverter.ToInt32(buffer, 0);
                Console.WriteLine($"int: {anInt}");
                // đọc 8 byte tiếp theo chuyển thành long
                client.Receive(buffer, 8, SocketFlags.None);
                var aLong = BitConverter.ToInt64(buffer, 0);
                Console.WriteLine($"long: {aLong}");
                // đọc 2 byte tiếp theo chuyển thành short
                client.Receive(buffer, 2, SocketFlags.None);
                var aShort = BitConverter.ToInt16(buffer, 0);
                Console.WriteLine($"short: {aShort}");





                client.Close();
            }
        }




        static void tcpServer_tcpListenerClass()
        {
            var listener = new TcpListener(IPAddress.Any, 1308);
            listener.Start(10);
            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream) { AutoFlush = true };
                var text = reader.ReadLine();
                var response = text.ToUpper();
                writer.WriteLine(response);
                client.Close();
            }
        }

        static void getDNS()
        {
            // lấy tên máy cục bộ
            var hostName = Dns.GetHostName();
            Console.WriteLine($"Local host name: {hostName}");
            // Lấy các địa chỉ Ip mà tên miền google.com trỏ tới
            var addresses = Dns.GetHostAddresses("google.com");
            Console.WriteLine("Addresses:");
            foreach (var a in addresses)
            {
                Console.WriteLine(a);
            }
            // lấy tất cả thông tin về google.com
            var entry = Dns.GetHostEntry("google.com");
            Console.WriteLine("HostEntry of google.com");
            Console.WriteLine($"Host name: {entry.HostName}");
            Console.WriteLine("Addresses:");
            foreach (var a in entry.AddressList)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Aliases");
            foreach (var s in entry.Aliases)
            {
                Console.WriteLine(s);
            }
            //Console.ReadLine();
        }


        static void tcpServer()
        {
            Console.Title = "Tcp Server";
            // giá trị Any của IPAddress tương ứng với Ip của tất cả các giao diện mạng trên máy
            var localIp = IPAddress.Any;
            // tiến trình server sẽ sử dụng cổng tcp 1308
            var localPort = 1308;   // can change 1309...
            // biến này sẽ chứa "địa chỉ" của tiến trình server trên mạng
            var localEndPoint = new IPEndPoint(localIp, localPort);
            // tcp sử dụng đồng thời hai socket: 
            // một socket để chờ nghe kết nối, một socket để gửi/nhận dữ liệu
            // socket listener này chỉ làm nhiệm vụ chờ kết nối từ Client
            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // yêu cầu hệ điều hành cho phép chiếm dụng cổng tcp 1308
            // server sẽ nghe trên tất cả các mạng mà máy tính này kết nối tới
            // chỉ cần gói tin tcp đến cổng 1308, tiến trình server sẽ nhận được
            listener.Bind(localEndPoint);
            // bắt đầu lắng nghe chờ các gói tin tcp đến cổng 1308
            listener.Listen(10);
            Console.WriteLine($"Local socket bind to {localEndPoint}. Waiting for request ...");
            var size = 1024;
            var receiveBuffer = new byte[size];
            while (true)
            {
                // tcp đòi hỏi một socket thứ hai làm nhiệm vụ gửi/nhận dữ liệu
                // socket này được tạo ra bởi lệnh Accept
                var socket = listener.Accept();
                Console.WriteLine($"Accepted connection from {socket.RemoteEndPoint}");
                // nhận dữ liệu vào buffer
                var length = socket.Receive(receiveBuffer);
                // không tiếp tục nhận dữ liệu nữa
                socket.Shutdown(SocketShutdown.Receive);
                var text = Encoding.ASCII.GetString(receiveBuffer, 0, length);
                Console.WriteLine($"Received: {text}");
                // chuyển chuỗi thành dạng in hoa
                var result = text.ToUpper();
                var sendBuffer = Encoding.ASCII.GetBytes(result);
                // gửi kết quả lại cho client
                socket.Send(sendBuffer);
                Console.WriteLine($"Sent: {result}");
                // không tiếp tục gửi dữ liệu nữa
                socket.Shutdown(SocketShutdown.Send);
                // đóng kết nối và giải phóng tài nguyên
                Console.WriteLine($"Closing connection from {socket.RemoteEndPoint}rn");
                socket.Close();
                Array.Clear(receiveBuffer, 0, size);
            }
        }
    }
}