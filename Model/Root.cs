
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
        public List<Chat> wxFriendList { get; set; }
        public List<GroupChat> wxGroupList { get; set; }
        public List<Chat> qqFriendList { get; set; }
        public List<GroupChat> qqGroupList { get; set; }
    }
}
