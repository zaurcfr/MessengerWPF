using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerWPF.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; set; }
    }
}
