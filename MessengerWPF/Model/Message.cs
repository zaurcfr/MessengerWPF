using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerWPF.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Chat Chat { get; set; }
    }
}
