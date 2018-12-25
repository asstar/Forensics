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

namespace Forensics
{
    public partial class PasswordForm : DevExpress.XtraEditors.XtraForm
    {
        public PasswordForm()
        {
            InitializeComponent();
        }
        string currentLogin = null;
        InfoBLL infoBLL = new InfoBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentLogin == "admin")
            {
                if (txtNewPassword.Text != txtReEnter.Text)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("两次输入的密码不一致!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else
                {
                    string result= infoBLL.SqlQuery("Select * from Info Where Key='AdminPassword'").ToList().FirstOrDefault().Value;
                    if (txtOldPassword.Text != result)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("用户原密码输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    else
                    {
                        infoBLL.SqlCommand("Update Info Set Value='" + txtNewPassword.Text + "' Where Key='AdminPassword'");
                        DevExpress.XtraEditors.XtraMessageBox.Show("密码修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
            else
            {
                if (txtNewPassword.Text != txtReEnter.Text)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("两次输入的密码不一致!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else
                {
                    string result = infoBLL.SqlQuery("Select * from Info Where Key='UserPassword'").ToList().FirstOrDefault().Value;
                    if (txtOldPassword.Text != result)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("用户原密码输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    else
                    {
                        infoBLL.SqlCommand("Update Info Set Value='" + txtNewPassword.Text + "' Where Key='UserPassword'");
                        DevExpress.XtraEditors.XtraMessageBox.Show("密码修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            currentLogin = infoBLL.SqlQuery("Select * from Info Where Key='CurrentLogin'").ToList().FirstOrDefault().Value;
            lcUser.Text = currentLogin;
        }
    }
}