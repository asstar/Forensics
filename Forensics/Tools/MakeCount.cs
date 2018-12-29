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
        ChatBLL chatBLL = new ChatBLL();
        GroupChatBLL groupBLL = new GroupChatBLL();
        GroupFriendBLL groupFriendBLL = new GroupFriendBLL();
        FriendBLL friendBLL = new FriendBLL();
        public void MakeSmsCount()
        {
            var result = smsBLL.SqlQuery("select * from sms where IsDeleted<>'1' AND TargetID='" + StateInfo.CaseID + "' group by name order by id").ToList();
            var list = smsBLL.SqlQuery("select * from Sms where IsDeleted<>'1'").ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                int count = list.Count(x => x.Account == result[i].Account);
                smsBLL.SqlCommand("Update sms set Count=" + count + " Where Account='" + result[i].Account + "' And IsDeleted<>'1'");

            }
        }
        public void MakeChatCount()
        {
            var result = friendBLL.SqlQuery("select * from Friend where IsDeleted<>'1' AND TargetID='" + StateInfo.CaseID + "' order by id").ToList();
            var list = chatBLL.SqlQuery("select * from Chat where IsDeleted<>'1'").ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                int count = list.Count(x => x.FriendAccount == result[i].FriendAccount);
                friendBLL.SqlCommand("Update Friend set Count=" + count + " Where FriendAccount='" + result[i].FriendAccount + "' And IsDeleted<>'1'");

            }
        }

        public void MakeGroupChatCount()
        {
            var result = groupFriendBLL.SqlQuery("select * from GroupFriend where IsDeleted<>'1' AND TargetID='" + StateInfo.CaseID + "' order by id").ToList();
            var list = groupBLL.SqlQuery("select * from GroupChat where IsDeleted<>'1'").ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                int count = list.Count(x => x.GroupNum == result[i].GroupNum);
                groupFriendBLL.SqlCommand("Update GroupFriend set Count=" + count + " Where GroupNum='" + result[i].GroupNum + "'  And IsDeleted<>'1' ");
            }
        }

    }
}
