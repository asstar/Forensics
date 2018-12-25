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
using BLL;
using Forensics.Tools;
using Iyond.Utility;
using System.Net;
using System.Xml;
using System.IO;
using System.Security.AccessControl;

namespace Forensics
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        InfoBLL infoBLL = new InfoBLL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string diskLock=infoBLL.SqlQuery("Select * from Info Where Key='DiskLock'").ToList().FirstOrDefault().Value;
            if (diskLock == "true")
            {
                string diskSerial=infoBLL.SqlQuery("Select * from Info Where Key='DiskSerial'").ToList().FirstOrDefault().Value;
                if (diskSerial != DiskInfo.GetCurrentDiskNo())
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("本软件禁止拷贝使用，系统将自动销毁！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormCaption("开始销毁数据");
                    splashScreenManager1.SetWaitFormDescription("请稍后...");
                    DBTools.DeleteTable("Contact");
                    DBTools.DeleteTable("Sms");
                    DBTools.DeleteTable("Chat");
                    DBTools.DeleteTable("GroupChat");
                    DBTools.DeleteTable("Chat");
                    DBTools.DeleteTable("GroupChat");
                    DBTools.DeleteTable("WA_MFORENSICS_010400");
                    DBTools.DeleteTable("WA_MFORENSICS_010500");
                    DBTools.DeleteTable("WA_MFORENSICS_010700");
                    DBTools.DeleteTable("WA_MFORENSICS_020400");
                    DBTools.DeleteTable("WA_MFORENSICS_020500");
                    DBTools.DeleteTable("WA_MFORENSICS_020600");
                    DBTools.Zip();
                    splashScreenManager1.CloseWaitForm();
                    Application.Exit();
                }
            }
            string userName = infoBLL.SqlQuery("Select * from Info Where Key='UserName'").ToList().FirstOrDefault().Value;
            string userPassword = infoBLL.SqlQuery("Select * from Info Where Key='UserPassword'").ToList().FirstOrDefault().Value;
            string adminName = infoBLL.SqlQuery("Select * from Info Where Key='AdminName'").ToList().FirstOrDefault().Value;
            string adminPassword = infoBLL.SqlQuery("Select * from Info Where Key='AdminPassword'").ToList().FirstOrDefault().Value;
            //if(txtUserName==userName&&txtPassoword)
            if (txtPassword.Text == adminPassword && txtUserName.Text == adminName)
            {
                infoBLL.SqlCommand("Update Info Set Value='admin' Where Key='CurrentLogin'");
                infoBLL.SqlCommand("Update Info Set Value='0' Where Key='ErrorCount'");
                StateInfo.IsLogin = true;
                this.Close();
            }
            else {
                if (txtPassword.Text == userPassword && txtUserName.Text == userName)
                {
                    infoBLL.SqlCommand("Update Info Set Value='user' Where Key='CurrentLogin'");
                    infoBLL.SqlCommand("Update Info Set Value='0' Where Key='ErrorCount'");
                    StateInfo.IsLogin = true;
                    this.Close();
                }
                else
                {
                    int errorCount = int.Parse(infoBLL.SqlQuery("Select * from Info Where Key='ErrorCount'").ToList().FirstOrDefault().Value);
                    int errorTotalCount = int.Parse(infoBLL.SqlQuery("Select * from Info Where Key='ErrorTotalCount'").ToList().FirstOrDefault().Value);
                    if (errorCount < errorTotalCount)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("密码输入错误！超过五次系统将自动销毁", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        errorCount++;
                        infoBLL.SqlCommand("Update Info Set Value='" + errorCount + "' Where Key='ErrorCount'");
                    }
                    else
                    {
                        splashScreenManager1.ShowWaitForm();
                        splashScreenManager1.SetWaitFormCaption("开始销毁数据");
                        splashScreenManager1.SetWaitFormDescription("请稍后...");
                        DBTools.DeleteTable("Contact");
                        DBTools.DeleteTable("Sms");
                        DBTools.DeleteTable("Chat");
                        DBTools.DeleteTable("GroupChat");
                        DBTools.DeleteTable("Chat");
                        DBTools.DeleteTable("GroupChat");
                        DBTools.DeleteTable("WA_MFORENSICS_010400");
                        DBTools.DeleteTable("WA_MFORENSICS_010500");
                        DBTools.DeleteTable("WA_MFORENSICS_010700");
                        DBTools.DeleteTable("WA_MFORENSICS_020400");
                        DBTools.DeleteTable("WA_MFORENSICS_020500");
                        DBTools.DeleteTable("WA_MFORENSICS_020600");
                        DBTools.Zip();
                        splashScreenManager1.CloseWaitForm();
                        Application.Exit();
                    }
                }
            }
            //if()
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            AddSecurityControll2File(System.IO.Directory.GetCurrentDirectory() + "\\DataBase.db");
            Application.EnableVisualStyles();
            //  Application.SetCompatibleTextRenderingDefault(false);

            AutoUpdater au = new AutoUpdater();
            try
            {
                au.Update();
            }
            catch (WebException exp)
            {
                MessageBox.Show(String.Format("无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (XmlException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException exp)
            {
                MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 为文件添加users，everyone用户组的完全控制权限
        /// </summary>
        /// <param name="filePath"></param>
        static void AddSecurityControll2File(string filePath)
        {

            //获取文件信息
            FileInfo fileInfo = new FileInfo(filePath);
            //获得该文件的访问权限
            System.Security.AccessControl.FileSecurity fileSecurity = fileInfo.GetAccessControl();
            //添加ereryone用户组的访问权限规则 完全控制权限
            fileSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            //添加Users用户组的访问权限规则 完全控制权限
            fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
            //设置访问权限
            fileInfo.SetAccessControl(fileSecurity);
        }
    }
}