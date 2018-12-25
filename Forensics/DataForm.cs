using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Forensics.Tools;
using BLL;
using Model;

namespace Forensics
{
    public partial class DataForm : DevExpress.XtraEditors.XtraForm
    {
        public DataForm()
        {
            InitializeComponent();
            tvList.ExpandAll();
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Text != null)
            {
                //treeConditionSql = e.Node.Tag.ToString();
                
                    if (e.Node.Text == "联系人")
                    {
                        changeTab("通讯录", "Forensics.ContactForm");
                    }
                    if (e.Node.Text == "短信息")
                    {
                        changeTab("短信息", "Forensics.SMSForm");
                    }
                    if (e.Node.Text == "好友聊天")
                    {
                        if (e.Node.Parent.Parent.Text == "微信")
                        {
                            StateInfo.ChatType = "1030036";
                            StateInfo.Account = e.Node.Parent.Text;
                            changeTab("微信好友", "Forensics.ChatForm");
                        }
                        if (e.Node.Parent.Parent.Text == "QQ")
                        {
                            StateInfo.ChatType = "1030001";
                            StateInfo.Account = e.Node.Parent.Text;
                            changeTab("QQ好友", "Forensics.ChatForm");
                        }
                    }
                    if (e.Node.Text == "群聊")
                    {
                        if (e.Node.Parent.Parent.Text == "微信")
                        {
                            StateInfo.ChatType = "1030036";
                            StateInfo.Account = e.Node.Parent.Text;
                            changeTab("微信群", "Forensics.GroupChatForm");
                        }
                        if (e.Node.Parent.Parent.Text == "QQ")
                        {
                            StateInfo.ChatType = "1030001";
                            StateInfo.Account = e.Node.Parent.Text;
                            changeTab("QQ群", "Forensics.GroupChatForm");
                        }
                    }
                }
                /*switch (e.Node.Text)
                {
                    case "联系人": changeTab("通讯录", "Forensics.ContactForm"); break;// XTCMain.SelectedTabPage = XTPContact; break;
                    case "短信息": changeTab("短信息", "Forensics.SMSForm"); break;//XTCMain.SelectedTabPage=XTPSMS; break;
                    case "微信好友": StateInfo.ChatType = "1030036"; changeTab("微信好友", "Forensics.ChatForm"); break;//XTCMain.SelectedTabPage=XTPMicroMsgFriend; break;
                    case "微信群": StateInfo.ChatType = "1030036"; changeTab("微信群", "Forensics.GroupChatForm"); break;//XTCMain.SelectedTabPage = XTPMicroMsgGroup; break;
                    case "QQ好友": StateInfo.ChatType = "1030001"; changeTab("QQ好友", "Forensics.ChatForm"); break;//XTCMain.SelectedTabPage=XTPQQ; break;
                    case "QQ群": StateInfo.ChatType = "1030001"; changeTab("QQ群", "Forensics.GroupChatForm"); break;//XTCMain.SelectedTabPage=XTPQQ; break;
                }*/
            
        }
        public void setTree()
        {
            tvList.Nodes.Clear();
            tvList.ImageIndex = 4;
            tvList.SelectedImageIndex = 4;
            var root = new WA_MFORENSICS_010200BLL().GetAll().FirstOrDefault();
            
            if (root != null)
            {
                string rootName=root.MODEL;
                TreeNode rootNode = new TreeNode(rootName);
                this.tvList.Nodes.Add(rootNode);
                TreeNode contactNode = new TreeNode("联系人");
                TreeNode smsNode = new TreeNode("短信息");
                TreeNode wxNode = new TreeNode("微信");
                TreeNode qqNode = new TreeNode("QQ");
                rootNode.Nodes.Add(contactNode);
                rootNode.Nodes.Add(smsNode);
                rootNode.Nodes.Add(wxNode);
                rootNode.Nodes.Add(qqNode);

                var wxQuery = new WA_MFORENSICS_020100BLL().SqlQuery("Select * From WA_MFORENSICS_020100 Where CONTACT_ACCOUNT_TYPE='1030036' Group by Account");
                var qqQuery = new WA_MFORENSICS_020100BLL().SqlQuery("Select * From WA_MFORENSICS_020100 Where CONTACT_ACCOUNT_TYPE='1030001' Group by Account");

                foreach (var i in wxQuery)
                {
                    TreeNode item = new TreeNode(i.ACCOUNT);
                    wxNode.Nodes.Add(item);
                    TreeNode chat = new TreeNode("好友聊天");
                    TreeNode friend = new TreeNode("群聊");
                    item.Nodes.Add(chat);
                    item.Nodes.Add(friend);
                }
                foreach (var i in qqQuery)
                {
                    TreeNode item = new TreeNode(i.ACCOUNT);
                    qqNode.Nodes.Add(item);
                    TreeNode chat = new TreeNode("好友聊天");
                    TreeNode friend = new TreeNode("群聊");
                    item.Nodes.Add(chat);
                    item.Nodes.Add(friend);
                }



                tvList.ExpandAll();
            }
        }
        private void changeTab(string title, string formName)
        {
            //XTCMain.TabPages.Remove
            int tabCount = this.xtcMain.TabPages.Count;
            for (int i = tabCount - 1; i >= 0; i--)
            {
                this.xtcMain.TabPages.RemoveAt(i);
            }
            CreateForm.FormOper.AddTabpage(xtcMain, title, title, formName);
        }
        
        private void DataForm_Load(object sender, EventArgs e)
        {

            setTree();



        }
    }
}