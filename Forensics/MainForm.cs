using BLL;
using Forensics.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forensics
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            
        }
        public DataForm mdiForm;

        private void MainForm_Load(object sender, EventArgs e)
        {
            string caseID = infoBLL.SqlQuery("Select * from Info Where Key='CaseID'").ToList().FirstOrDefault().Value;
            if (caseID != null || caseID != "")
            {
                StateInfo.CaseID = caseID;
            }
            mdiForm = new DataForm();
            mdiForm.MdiParent = this;
            mdiForm.Show();
            mdiForm.BringToFront();
            mdiForm.Activate();
            SetMenu();
        }
        private void SetMenu()
        {
            string currentLogin = infoBLL.SqlQuery("Select * from Info Where Key='CurrentLogin'").ToList().FirstOrDefault().Value;
            if (currentLogin == "user")
            {
                tsmiSetting.Visible = false;
                tsmiCaseManager.Visible = false;
                tsmiParser.Visible = false;
                tsmiFilter.Visible = false;
                tsmiDelete.Visible = false;
                tsmiSeperator1.Visible = false;
            }
        }
        InfoBLL infoBLL = new InfoBLL();
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
        public CaseForm caseForm;
        private void tsmiCaseManager_Click(object sender, EventArgs e)
        {
            /*Import import = new Import(this);
            import.ShowDialog();*/
            caseForm = new CaseForm(this);
            caseForm.ShowDialog();
        }


        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        MakeCount makeCount = new MakeCount();
        
        private void tsmiParser_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("确定开始分析数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                parser();
            }
        }
        public void parser()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("开始分析数据");
            splashScreenManager1.SetWaitFormDescription("请稍后...");
            Parser parser = new Parser();
            parser.makeContact();
            parser.makeSms();


            parser.makeChat();
            parser.makeFriend();
            parser.makeGroupFriend();
            parser.makeGroupChat();
            parser.makeChat();
            parser.makeGroupChat();
            parser.makeZone();
            parser.makeAffix();
            makeCount.MakeSmsCount();
            makeCount.MakeChatCount();
            makeCount.MakeGroupChatCount();
            mdiForm.clearTab();
            splashScreenManager1.CloseWaitForm();
        }
        private void tsmiFilter_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("确定开始过滤数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("开始分析数据");
                splashScreenManager1.SetWaitFormDescription("请稍后...");
                Clean clean = new Clean();
                clean.CleanTable("Sms");
                clean.CleanTable("Chat");
                clean.CleanTable("GroupChat");
                clean.CleanTable("Chat");
                clean.CleanTable("GroupChat");

                makeCount.MakeSmsCount();
                makeCount.MakeChatCount();
                makeCount.MakeGroupChatCount();
                makeCount.MakeChatCount();
                makeCount.MakeGroupChatCount();
                mdiForm.clearTab();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm();
            setting.ShowDialog();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("确定清除数据库所有数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("开始清除数据");
                splashScreenManager1.SetWaitFormDescription("请稍后...");
                DBTools.DeleteTable("Contact");
                DBTools.DeleteTable("Sms");
                DBTools.DeleteTable("Friend");
                DBTools.DeleteTable("GroupFriend");
                DBTools.DeleteTable("Chat");
                DBTools.DeleteTable("GroupChat");
                DBTools.DeleteTable("Zone");
                DBTools.DeleteTable("Affix");
                DBTools.DeleteTable("WA_MFORENSICS_010100");
                DBTools.DeleteTable("WA_MFORENSICS_010200");
                DBTools.DeleteTable("WA_MFORENSICS_010202");
                DBTools.DeleteTable("WA_MFORENSICS_010300");
                DBTools.DeleteTable("WA_MFORENSICS_010400");
                DBTools.DeleteTable("WA_MFORENSICS_010500");
                DBTools.DeleteTable("WA_MFORENSICS_010700");
                DBTools.DeleteTable("WA_MFORENSICS_020100");
                DBTools.DeleteTable("WA_MFORENSICS_020200");
                DBTools.DeleteTable("WA_MFORENSICS_020300");
                DBTools.DeleteTable("WA_MFORENSICS_020400");
                DBTools.DeleteTable("WA_MFORENSICS_020500");
                DBTools.DeleteTable("WA_MFORENSICS_020600");
                DBTools.DeleteTable("WA_MFORENSICS_020700");
                DBTools.DeleteTable("WA_MFORENSICS_090400");
                DBTools.Zip();
                mdiForm.setTree(); 
                mdiForm.clearTab(); 
                splashScreenManager1.CloseWaitForm();
            }

        }

        private void tsmiPassword_Click(object sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.ShowDialog();
        }
    }
}
