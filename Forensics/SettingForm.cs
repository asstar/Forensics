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
using IBLL;
using BLL;
using Forensics.Tools;

namespace Forensics
{
    public partial class SettingForm : DevExpress.XtraEditors.XtraForm
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            infoBLL.SqlCommand("Update Info Set Value='" + txtUserName.Text + "' Where Key='UserName'");
            infoBLL.SqlCommand("Update Info Set Value='" + txtPassword.Text + "' Where Key='UserPassword'");
            infoBLL.SqlCommand("Update Info Set Value='" + txtCount.Text + "' Where Key='ErrorTotalCount'");
            infoBLL.SqlCommand("Update Info Set Value='" + deTime.Text + "' Where Key='EndTime'");
            if (ceDisk.Checked == true)
            {
                infoBLL.SqlCommand("Update Info Set Value='true' Where Key='DiskLock'");
                infoBLL.SqlCommand("Update Info Set Value='"+DiskInfo.GetCurrentDiskNo()+"' Where Key='DiskSerial'");
            }
            else
            {
                infoBLL.SqlCommand("Update Info Set Value='false' Where Key='DiskLock'");
            }
            this.Close();
        }
        InfoBLL infoBLL = new InfoBLL();
        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = infoBLL.SqlQuery("Select * from Info Where Key='UserName'").ToList().FirstOrDefault().Value;
            txtPassword.Text = infoBLL.SqlQuery("Select * from Info Where Key='UserPassword'").ToList().FirstOrDefault().Value;
            txtCount.Text = infoBLL.SqlQuery("Select * from Info Where Key='ErrorTotalCount'").ToList().FirstOrDefault().Value;
            deTime.Text = infoBLL.SqlQuery("Select * from Info Where Key='EndTime'").ToList().FirstOrDefault().Value;
            ceDisk.Checked = infoBLL.SqlQuery("Select * from Info Where Key='DiskLock'").ToList().FirstOrDefault().Value=="true";

        }
    }
}