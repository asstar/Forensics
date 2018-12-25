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
using Data.Entity;
using BLL;

namespace Forensics
{
    public partial class Export : DevExpress.XtraEditors.XtraForm
    {
        public Export(XtraForm mainForm)
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = saveFileDialog1.FileName;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("导出数据");
            splashScreenManager1.SetWaitFormDescription("请稍后...");
            Root root = new Root();
            root.contactList = new ContactBLL().GetAll().ToList();
            root.smsList = new SmsBLL().GetAll().ToList();
            root.wxFriendList = new ChatBLL().GetAll().ToList();
            root.wxGroupList = new GroupChatBLL().GetAll().ToList();
            root.qqFriendList = new ChatBLL().GetAll().ToList();
            root.qqGroupList = new GroupChatBLL().GetAll().ToList();
            string xmlFile = XmlUtility.SerializeToXml(root);
            xmlFile = XmlUtility.FormatXml(xmlFile);
            System.IO.File.WriteAllText(txtPath.Text, xmlFile);
            splashScreenManager1.CloseWaitForm();
            this.Invoke((EventHandler)(delegate { this.Close(); }));
        }
    }
}