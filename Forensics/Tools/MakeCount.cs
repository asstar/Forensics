using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forensics.Tools
{
    public class MakeCount
    {
        ContactBLL contactBLL = new ContactBLL();
        SmsBLL smsBLL = new SmsBLL();
        ChatBLL wxFriendBLL = new ChatBLL();
        GroupChatBLL wxGroupBLL = new GroupChatBLL();
        GroupChatBLL qqGroupBLL = new GroupChatBLL();
        ChatBLL qqFriendBLL = new ChatBLL();
        public void MakeSmsCount()
        {
            var result = smsBLL.SqlQuery("select * from sms where IsDeleted<>'1' group by name order by id").ToList();
            var list = smsBLL.SqlQuery("select * from Sms where IsDeleted<>'1'").ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                int count = list.Count(x => x.Account == result[i].Account);
                smsBLL.SqlCommand("Update sms set Count=" + count + " Where Account='" + result[i].Account + "' And IsDeleted<>'1'");

            }
        }
        public void MakeChatCount()
        {
            var result = wxFriendBLL.SqlQuery("select * from Chat where IsDeleted<>'1'  group by FriendAccount order by id").ToList();
            var list = wxFriendBLL.SqlQuery("select * from Chat where IsDeleted<>'1'").ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                int count = list.Count(x => x.FriendAccount == result[i].FriendAccount);
                wxFriendBLL.SqlCommand("Update Chat set Count=" + count + " Where FriendAccount='" + result[i].FriendAccount + "' And IsDeleted<>'1'");

            }
        }

        public void MakeGroupChatCount()
        {
            var result = wxGroupBLL.SqlQuery("select * from GroupChat where IsDeleted<>'1'  group by GroupNum order by id").ToList();
            var list = wxGroupBLL.SqlQuery("select * from GroupChat where IsDeleted<>'1'").ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                int count = list.Count(x => x.GroupNum == result[i].GroupNum);
                wxGroupBLL.SqlCommand("Update GroupChat set Count=" + count + " Where GroupNum='" + result[i].GroupNum + "'  And IsDeleted<>'1' ");
            }
        }

    }
}
