using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Linq;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new ApplicationContext();
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
                            var msg = reader.ReadLine();
                            string[] str = msg.Split(" - ");
                            Console.WriteLine(str[0]);
                            Console.WriteLine(str[1]);
                            var user = new User { Username = str[0], Password = str[1] };
                            if (db.Users.First(u=> u.Username == user.Username) != null)
                            {
                                if (db.Users.First(u=>u.Password == user.Password) != null)
                                {
                                    using (var writer = new StreamWriter(client.GetStream()))
                                    {
                                        writer.WriteLine("+");
                                        writer.Flush();
                                    }
                                }
                            }
                        }
                    }
                });
            }
        }
    }
}
