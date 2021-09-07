using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);

            TcpListener server = new TcpListener(endPoint);
            server.Start();
            Console.WriteLine("Server is running");


            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client is connected");

                Task.Run(() =>
                {
                    using (var stream = client.GetStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            while (true)
                            {
                                var msg = reader.ReadLine();
                                if (msg == "exit")
                                {
                                    break;
                                }
                                Console.WriteLine(msg);
                            }
                        }
                    }
                });
            }
        }
    }
}
