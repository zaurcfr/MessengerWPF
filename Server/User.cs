using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Message> Messages { get; set; }
    }
}
