using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerWPF.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentVM { get; set; }

        private LoginViewModel _loginViewModel { get; set; }

        public MainViewModel()
        {
            _loginViewModel = new LoginViewModel();

            CurrentVM = _loginViewModel;
        }
    }
}
