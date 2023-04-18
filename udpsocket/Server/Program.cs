using System;
using System.Net;
using System.Net.Sockets;
using System.Text;  // Encoding class

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //udpServer();
            udpClientClassServer();
        }



        static void udpClientClassServer()
        {
            var server = new UdpClient(1308); // tự động bind với cổng
            while (true)
            {
                var remoteEp = new IPEndPoint(0, 0);
                var buffer = server.Receive(ref remoteEp);
                var text = Encoding.ASCII.GetString(buffer);
                var response = text.ToUpper();
                buffer = Encoding.ASCII.GetBytes(response);
                server.Send(buffer, buffer.Length, remoteEp);
            }
        }

        static void udpServer()
        {
            Console.Title = "Udp Server";
            // IPAddress.Any value correspondant to any ip of all Interface Network
            var localIp = IPAddress.Any;
            // server process use port 1308
            var localPort = 1308;
            // this variable receive "address" of process server on network
            var localEndpoint = new IPEndPoint(localIp, localPort);
            // request OS for using 1308 port
            // server will listening on all network this PC conneting
            // package data udp comming 1308 port the server process will catching
            // another overload of create socket. InterNetwork is a kind address of IPv4
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(localEndpoint);
            Console.WriteLine($"Local Socket bind to {localEndpoint}. Waitting for request....");

            var size = 1024;
            var receiveBuffer = new byte[size];
            while (true)
            {
                // this variable will get address of client process that send data package
                EndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
                // when receive data package then save address of client process
                var length = socket.ReceiveFrom(receiveBuffer, ref remoteEndpoint);
                var text = Encoding.ASCII.GetString(receiveBuffer, 0, length);
                Console.WriteLine($"Receive from {remoteEndpoint}: {text}");
                // upper string
                var result = text.ToUpper();
                var sendBuffer = Encoding.ASCII.GetBytes(result);
                // resend to client
                socket.SendTo(sendBuffer, remoteEndpoint);
                Array.Clear(receiveBuffer, 0, size);
            }
        }
    }
}
