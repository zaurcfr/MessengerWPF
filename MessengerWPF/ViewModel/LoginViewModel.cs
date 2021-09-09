using MessengerWPF.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MessengerWPF.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : BaseViewModel
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }
        private MainViewModel _mainViewModel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public LoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            _mainViewModel = new MainViewModel();

            LoginCommand = new RelayCommand(Login);


        }

        void Login(object obj)
        {
            var passwordBox = obj as PasswordBox;
            Password = passwordBox.Password;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
            TcpClient client = new TcpClient();

            client.Connect(endPoint);
            using (var writer = new StreamWriter(client.GetStream()))
            {
                var username = Username;
                var password = Password;
                writer.WriteLine(username + " - " + password);
                writer.Flush();
            }
            
            Task.Run(() =>
            {
                using (var stream = client.GetStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var data = new Byte[256];

                        // String to store the response ASCII representation.
                        String responseData = String.Empty;

                        // Read the first batch of the TcpServer response bytes.
                        Int32 bytes = stream.Read(data, 0, data.Length); //(**This receives the data using the byte method**)
                        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    }
                }
            });
            //MainWindowViewModel.NavToMainView();
        }

    }
}
