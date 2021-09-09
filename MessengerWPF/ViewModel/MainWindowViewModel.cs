using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerWPF.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : BaseViewModel
    {
        public BaseViewModel CurrentVM { get; set; }

        private LoginViewModel _loginViewModel { get; set; }
        private MainViewModel _mainViewModel { get; set; }

        
        public MainWindowViewModel()
        {
            _loginViewModel = new LoginViewModel(this);
            _mainViewModel = new MainViewModel();


            CurrentVM = _loginViewModel;
        }

        public void NavToMainView()
        {
            CurrentVM = _mainViewModel;
        }
    }
}
