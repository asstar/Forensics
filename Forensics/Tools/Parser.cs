using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forensics.Tools
{
    public class Parser
    {
        ContactBLL contactBLL = new ContactBLL();
        SmsBLL smsBLL = new SmsBLL();
        ChatBLL chatBLL = new ChatBLL();
        GroupChatBLL groupChatBLL = new GroupChatBLL();
        FriendBLL friendBLL = new FriendBLL();
        GroupFriendBLL groupFriendBLL = new GroupFriendBLL();
        ZoneBLL zoneBLL = new ZoneBLL();
        AffixBLL affixBLL = new AffixBLL();
        public void makeContact()
        {
            List<WA_MFORENSICS_010400> srcList10400 = new WA_MFORENSICS_010400BLL().GetAll().ToList();
            List<WA_MFORENSICS_010500> srcList10500 = new WA_MFORENSICS_010500BLL().GetAll().ToList();
            List<Contact> destList = new List<Contact>();
            foreach (var i in srcList10400)
            {
                Contact item = new Contact();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;

                item.Name = i.RELATIONSHIP_NAME;
                item.DeleteStatus = i.DELETE_STATUS;
                item.Seq = i.SEQUENCE_NAME;
                item.IsDeleted = "0";
                List<WA_MFORENSICS_010500> phoneList = (from c in srcList10500 where c.SEQUENCE_NAME == i.SEQUENCE_NAME select c).ToList();
                item.Account = "";
                foreach (var p in phoneList)
                {
                    item.Account = item.Account + p.RELATIONSHIP_ACCOUNT + "     ";
                }
                destList.Add(item);
            }
            contactBLL.SqlCommand("delete from contact");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            contactBLL.BulkAdd(destList);

        }
        public void makeSms()
        {
            List<WA_MFORENSICS_010700> srcList = new WA_MFORENSICS_010700BLL().GetAll().ToList();
            List<Sms> destList = new List<Sms>();
            foreach (var i in srcList)
            {
                Sms item = new Sms();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;
                item.Name = i.RELATIONSHIP_NAME;
                item.Account = i.RELATIONSHIP_ACCOUNT;
                switch (i.LOCAL_ACTION)
                {
                    case "01": item.Direction = "收到"; break;
                    case "02": item.Direction = "发送"; break;
                    case "99": item.Direction = "其他"; break;
                }
                //item.Direction = i.LOCAL_ACTION;
                item.SendTime = i.MAIL_SEND_TIME;
                item.Content = i.CONTENT;

                item.DeleteStatus = i.DELETE_STATUS;
                item.IsDeleted = "0";
                destList.Add(item);
            }
            smsBLL.SqlCommand("delete from Sms");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            smsBLL.BulkAdd(destList);
        }
        public void makeFriend()
        {
            List<WA_MFORENSICS_020200> srcList = new WA_MFORENSICS_020200BLL().SqlQuery("Select * From WA_MFORENSICS_020200").ToList();
            List<Friend> destList = new List<Friend>();
            foreach (var i in srcList)
            {
                Friend item = new Friend();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;
                item.AccountType = i.CONTACT_ACCOUNT_TYPE;
                item.Account = i.ACCOUNT;
                item.AccountID = i.ACCOUNT_ID;

                item.FriendAccount = i.FRIEND_ACCOUNT;
                item.FriendID = i.FRIEND_ID;

                item.FriendNickName = i.FRIEND_NICKNAME;
                if (i.FRIEND_NICKNAME == "")
                {
                    item.FriendNickName = i.FRIEND_ACCOUNT;
                }
                item.Name = i.NAME;
                item.Phone = i.MSISDN;
                item.Email = i.EMAIL_ACCOUNT;
                item.DeleteStatus = i.DELETE_STATUS;
                item.IsDeleted = "0";
                destList.Add(item);
            }
            friendBLL.SqlCommand("delete from Friend");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            friendBLL.BulkAdd(destList);
        }

        public void makeGroupFriend()
        {
            List<WA_MFORENSICS_020300> srcList = new WA_MFORENSICS_020300BLL().SqlQuery("Select * From WA_MFORENSICS_020300").ToList();
            List<GroupFriend> destList = new List<GroupFriend>();
            foreach (var i in srcList)
            {
                GroupFriend item = new GroupFriend();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;
                item.AccountType = i.CONTACT_ACCOUNT_TYPE;
                item.Account = i.ACCOUNT;
                item.AccountID = i.ACCOUNT_ID;

                item.GroupNum = i.GROUP_NUM;
                item.GroupName = i.GROUP_NAME;

                item.DeleteStatus = i.DELETE_STATUS;
                item.IsDeleted = "0";
                destList.Add(item);
            }
            groupFriendBLL.SqlCommand("delete from GroupFriend");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            groupFriendBLL.BulkAdd(destList);
        }
        public void makeChat()
        {
            List<WA_MFORENSICS_020500> srcList = new WA_MFORENSICS_020500BLL().SqlQuery("Select * From WA_MFORENSICS_020500").ToList();
            List<Chat> destList = new List<Chat>();
            foreach (var i in srcList)
            {
                Chat item = new Chat();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;
                item.AccountType = i.CONTACT_ACCOUNT_TYPE;
                item.Account = i.ACCOUNT;
                item.NickName = i.REGIS_NICKNAME;
                item.FriendAccount = i.FRIEND_ACCOUNT;
                item.FriendNickName = i.FRIEND_NICKNAME;
                if (i.FRIEND_NICKNAME == "")
                {
                    item.FriendNickName = i.FRIEND_ACCOUNT;
                }
                switch (i.LOCAL_ACTION)
                {
                    case "01": item.Direction = "收到"; break;
                    case "02": item.Direction = "发送"; break;
                    case "99": item.Direction = "其他"; break;
                }
                item.SendTime = i.MAIL_SEND_TIME;
                item.Content = i.CONTENT;

                item.DeleteStatus = i.DELETE_STATUS;
                item.IsDeleted = "0";
                destList.Add(item);
            }
            chatBLL.SqlCommand("delete from Chat");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            chatBLL.BulkAdd(destList);
        }

        public void makeGroupChat()
        {
            List<WA_MFORENSICS_020600> srcList = new WA_MFORENSICS_020600BLL().SqlQuery("Select * From WA_MFORENSICS_020600").ToList();
            List<GroupChat> destList = new List<GroupChat>();
            foreach (var i in srcList)
            {
                GroupChat item = new GroupChat();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;
                item.AccountType = i.CONTACT_ACCOUNT_TYPE;
                item.Account = i.ACCOUNT;
                if (i.GROUP_NUM.IndexOf("-") > 0)
                {
                    item.GroupNum = i.GROUP_NUM.Substring(0, i.GROUP_NUM.IndexOf("-"));
                    if (i.GROUP_NUM.IndexOf("-") + 2 > i.GROUP_NUM.Count())
                    {
                        item.FriendNickName = "";
                    }
                    else
                    {
                        item.FriendNickName = i.GROUP_NUM.Substring(i.GROUP_NUM.IndexOf("-") + 1);
                    }
                }
                else
                {
                    item.GroupNum = i.GROUP_NUM;
                    item.FriendNickName = i.FRIEND_NICKNAME;
                }

                int index = i.GROUP_NAME.IndexOf("-");
                if (index < 0)
                {
                    item.GroupName = i.GROUP_NAME;
                    if (i.GROUP_NAME == "")
                    {
                        item.GroupName = i.GROUP_NUM;
                    }
                    item.FriendAccount = i.FRIEND_ACCOUNT;
                }
                else
                {
                    item.GroupName = i.GROUP_NAME.Substring(0, index);


                    if (i.GROUP_NAME.IndexOf("-") + 2 > i.GROUP_NAME.Count())
                    {
                        item.FriendAccount = "";
                    }
                    else
                    {
                        item.FriendAccount = i.GROUP_NAME.Substring(i.GROUP_NAME.IndexOf("-") + 1);
                    }
                }
                switch (i.LOCAL_ACTION)
                {
                    case "01": item.Direction = "收到"; break;
                    case "02": item.Direction = "发送"; break;
                    case "99": item.Direction = "其他"; break;
                }
                item.SendTime = i.MAIL_SEND_TIME;
                item.Content = i.CONTENT;

                item.DeleteStatus = i.DELETE_STATUS;
                item.IsDeleted = "0";
                destList.Add(item);
            }
            groupChatBLL.SqlCommand("delete from GroupChat");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            groupChatBLL.BulkAdd(destList);
        }
        public void makeZone()
        {
            List<WA_MFORENSICS_020700> srcList = new WA_MFORENSICS_020700BLL().SqlQuery("Select * From WA_MFORENSICS_020700").ToList();
            List<Zone> destList = new List<Zone>();
            foreach (var i in srcList)
            {
                Zone item = new Zone();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;
                item.AccountType = i.CONTACT_ACCOUNT_TYPE;
                item.Account = i.ACCOUNT;
                item.AccountID = i.ACCOUNT_ID;

                item.FriendAccount = i.FRIEND_ACCOUNT;
                item.FriendNickName = i.FRIEND_NICKNAME;
                item.FriendID = i.FRIEND_ID;
                if (i.FRIEND_NICKNAME == "")
                {
                    item.FriendNickName = i.FRIEND_ACCOUNT;
                }
                item.SendTime = i.MAIL_SEND_TIME;
                item.Content = i.WEIBO_MESSAGE;

                item.DeleteStatus = i.DELETE_STATUS;
                item.IsDeleted = "0";
                destList.Add(item);
            }
            zoneBLL.SqlCommand("delete from Zone");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            zoneBLL.BulkAdd(destList);
        }
        public void makeAffix()
        {
            List<WA_MFORENSICS_090400> srcList = new WA_MFORENSICS_090400BLL().SqlQuery("Select * From WA_MFORENSICS_090400").ToList();
            List<Affix> destList = new List<Affix>();
            foreach (var i in srcList)
            {
                Affix item = new Affix();
                item.ID = i.ID;
                item.TargetID = i.COLLECT_TARGET_ID;
                item.Name = i.MIME_ORIGINAL_NAME;
                string file = System.Environment.CurrentDirectory + "\\Output\\Att\\" + i.MIME_ORIGINAL_NAME;
                string base64Str = string.Empty;
                if (File.Exists(file)) {
                    FileStream fs = new FileStream(file, FileMode.Open);

                    //StreamUtil su = new StreamUtil();
                    //byte[] buffer = su.StreamToBytes(fs);
                    byte[] buffer = StreamUtil.ReadFully(fs);
                    //base64Str = Convert.ToBase64String(buffer);
                    fs.Close();
                    item.Content = buffer;
                }
                else
                {
                    item.Content = null;
                }

                item.DeleteStatus = i.DELETE_STATUS;
                item.IsDeleted = "0";
                destList.Add(item);
            }
            affixBLL.SqlCommand("delete from Affix");
            new SQLiteHelper().ExecuteNonQuery("VACUUM");
            affixBLL.BulkAdd(destList);
        }
    }
}
