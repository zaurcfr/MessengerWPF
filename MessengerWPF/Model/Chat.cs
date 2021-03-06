using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerWPF.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> Users { get; set; }
    }
}
