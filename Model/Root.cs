
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Root
    {
        public List<Contact> contactList { get; set; }
        public List<Sms> smsList { get; set; }
        public List<Chat> chatList { get; set; }
        public List<GroupChat> groupChatList { get; set; }

    }
}
