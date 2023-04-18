using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //udpClient();
            udpClientClassClient();
        }

        static void udpClientClassClient()
        {
            Console.Write("Server Ip: ");
            var ip = IPAddress.Parse(Console.ReadLine());
            var client = new UdpClient();
            //lệnh Connect này chỉ giúp lưu lại thông tin về đối tác trong object client 
            //chứ không phải thực hiện kết nối như trong tcp socket
            client.Connect(ip, 1308);
            while (true)
            {
                Console.Write("# Text >>> ");
                var text = Console.ReadLine();
                var buffer = Encoding.ASCII.GetBytes(text);
                client.Send(buffer, buffer.Length);
                var dumpEp = new IPEndPoint(0, 0);
                buffer = client.Receive(ref dumpEp);
                var response = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(response);
            }
        }

        static void udpClient()
        {
            Console.Title = "Udp Client";
            // request user input ip server
            /*Vì server đang nghe tất cả các giao diện mạng và client đang chạy trên cùng máy vật lý với server,
             client có thể sử dụng địa chỉ loopback 127.0.0.1 và cổng 1308 */
            Console.Write("Server IP Address: ");
            var serverIpStr = Console.ReadLine();
            // convert string to IP Address object
            var serverIp = IPAddress.Parse(serverIpStr);    // need system.Net
            // input server port 
            Console.Write("Input server port: ");
            var serverPortStr = Console.ReadLine();
            // convert string to integer
            var serverPort = int.Parse(serverPortStr);
            // this is "address" of server process in network. Each endpoint: ip of host & port of process
            var serverEndpoint = new IPEndPoint(serverIp, serverPort);
            var size = 1024;    // size of buffer
            var receiveBuffer = new byte[size]; // byte array for buffering
            while (true)
            {
                // user input a string
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Input some text: ");
                Console.ResetColor();
                var txt = Console.ReadLine();
                // initialize object of socket for using udp service
                // Notice: SocketType of Udp is Dgram (datagram)
                var socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
                // convert text to byte array
                var sendBuffer = Encoding.ASCII.GetBytes(txt);
                // send it to server process
                socket.SendTo(sendBuffer, serverEndpoint);
                // this endpoint only using while receiving data
                EndPoint dummyEndpoint = new IPEndPoint(IPAddress.Any, 0);
                // receive array byte from udp service then save to buffer
                // dummyEndpoint save address of resource process
                // but we know resource is Server now, so dummyEndpoint is unused here
                var length = socket.ReceiveFrom(receiveBuffer, ref dummyEndpoint);
                // convert array byte to string
                var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
                // clear buffer
                Array.Clear(receiveBuffer, 0, size);
                // close socket and release resource
                socket.Close();
                Console.WriteLine($"Received string is: {result}");
            }

        }
    }
}
