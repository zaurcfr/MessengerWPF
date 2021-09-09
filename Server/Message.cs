using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Chat Chat { get; set; }
        public User User { get; set; }
    }
}
