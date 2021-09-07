using MessengerWPF.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessengerWPF.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand((e) =>
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
                TcpClient client = new TcpClient();

                client.Connect(endPoint);
                using (var writer = new StreamWriter(client.GetStream()))
                {
                    while (true)
                    {
                        var msg = Username;
                        writer.WriteLine(msg);
                        writer.Flush();
                    }
                }
            });

            
        }

    }
}
