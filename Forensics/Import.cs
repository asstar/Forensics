using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml.Linq;
using Forensics.Tools;
using Model;
using System.Threading;


namespace Forensics
{
    public partial class Import : DevExpress.XtraEditors.XtraForm
    {
        MainForm mainForm;
        public Import(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }


        private void runImport()
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory() + "\\Output";
                splashScreenManager1.SetWaitFormCaption("删除目录");
                if (Directory.Exists(path) == true)
                {//如果不存
                    FileAttributes attr = File.GetAttributes(path);
                    if (attr == FileAttributes.Directory)
                    {
                        Directory.Delete(path, true);
                    }
                    else
                    {
                        File.Delete(path);
                    }
                }

                splashScreenManager1.SetWaitFormCaption("解压数据包");
                ZipHelper.UnZip(txtPath.Text, System.IO.Directory.GetCurrentDirectory() + "\\Output");

                splashScreenManager1.SetWaitFormCaption("解析XML");
                string xmlFileName = System.IO.Directory.GetCurrentDirectory() + "\\Output\\GAB_ZIP_INDEX.xml";
                ImportData importData = new ImportData();
                Thread.Sleep(1000);
                XElement root = XElement.Load(xmlFileName);

                var query010100 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_010100" select b);
                splashScreenManager1.SetWaitFormCaption("导入手机基本信息");
                splashScreenManager1.SetWaitFormDescription("请稍后...");
                //importData.DeleteTable("WA_MFORENSICS_010100");
                foreach (var item in query010100)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_010100());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    StateInfo.CaseID = data.Rows[0][0].ToString();
                    importData.InsertData(data, "WA_MFORENSICS_010100");

                }

                var query010200 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_010200" select b);
                //importData.DeleteTable("WA_MFORENSICS_010200");
                foreach (var item in query010200)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_010200());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_010200");

                }

                var query010202 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_010202" select b);
                //importData.DeleteTable("WA_MFORENSICS_010202");
                foreach (var item in query010202)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_010202());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_010202");

                }

                var query010300 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_010300" select b);
                //importData.DeleteTable("WA_MFORENSICS_010300");
                foreach (var item in query010300)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_010300());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_010300");

                }
                var query010400 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_010400" select b);
                splashScreenManager1.SetWaitFormCaption("导入联系人");
                splashScreenManager1.SetWaitFormDescription("请稍后...");
                //importData.DeleteTable("WA_MFORENSICS_010400");
                foreach (var item in query010400)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_010400());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_010400");

                }
                splashScreenManager1.SetWaitFormCaption("导入联系电话");
                var query010500 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_010500" select b);
                //importData.DeleteTable("WA_MFORENSICS_010500");
                foreach (var item in query010500)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_010500());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_010500");
                }
                splashScreenManager1.SetWaitFormCaption("导入短信");
                var query010700 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_010700" select b);
                //importData.DeleteTable("WA_MFORENSICS_010700");
                foreach (var item in query010700)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_010700());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_010700");
                }

                splashScreenManager1.SetWaitFormCaption("导入社交账号");
                var query020100 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_020100" select b);
                //importData.DeleteTable("WA_MFORENSICS_020100");
                foreach (var item in query020100)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_020100());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_020100");
                }

                splashScreenManager1.SetWaitFormCaption("导入社交好友");
                var query020200 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_020200" select b);
                //importData.DeleteTable("WA_MFORENSICS_020200");
                foreach (var item in query020200)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value))
                    {
                        DataTable result = importData.MakeTable(new WA_MFORENSICS_020200());
                        DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);

                        importData.InsertData(data, "WA_MFORENSICS_020200");
                    }
                }
                splashScreenManager1.SetWaitFormCaption("导入社交圈好友");
                var query020300 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_020300" select b);
                //importData.DeleteTable("WA_MFORENSICS_020300");
                foreach (var item in query020300)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_020300());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_020300");
                }
                splashScreenManager1.SetWaitFormCaption("导入群信息");
                var query020400 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_020400" select b);
                //importData.DeleteTable("WA_MFORENSICS_020400");
                foreach (var item in query020400)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_020400());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_020400");
                }

                splashScreenManager1.SetWaitFormCaption("导入社交聊天");
                var query020500 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_020500" select b);
                //importData.DeleteTable("WA_MFORENSICS_020500");
                foreach (var item in query020500)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_020500());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_020500");
                }
                splashScreenManager1.SetWaitFormCaption("导入社交群聊");
                var query020600 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_020600" select b);
                //importData.DeleteTable("WA_MFORENSICS_020600");
                foreach (var item in query020600)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_020600());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_020600");
                }
                splashScreenManager1.SetWaitFormCaption("导入社交博客");
                var query020700 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_020700" select b);
                //importData.DeleteTable("WA_MFORENSICS_020700");
                foreach (var item in query020700)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_020700());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_020700");
                }
                splashScreenManager1.SetWaitFormCaption("导入附件数据");
                var query090400 = (from b in root.Descendants("ITEM") where (string)b.Attribute("val") == "WA_MFORENSICS_090400" select b);
                //importData.DeleteTable("WA_MFORENSICS_090400");
                foreach (var item in query090400)
                {
                    var parent = item.Parent;
                    var file = (from b in parent.Descendants("ITEM") where (string)b.Attribute("rmk") == "文件名" select b).FirstOrDefault();
                    DataTable result = importData.MakeTable(new WA_MFORENSICS_090400());
                    DataTable data = BcpHelper.bcp2dt(System.IO.Directory.GetCurrentDirectory() + "\\Output\\" + file.Attribute("val").Value, '\t', 0, result);
                    importData.InsertData(data, "WA_MFORENSICS_090400");
                }

                mainForm.parser();
                //Thread.Sleep(3000);
                 path = System.IO.Directory.GetCurrentDirectory() + "\\Output";
                 splashScreenManager1.SetWaitFormCaption("删除目录");
                 if (Directory.Exists(path) == true)
                 {//如果不存
                     FileAttributes attr = File.GetAttributes(path);
                     if (attr == FileAttributes.Directory)
                     {
                         Directory.Delete(path, true);
                     }
                     else
                     {
                         File.Delete(path);
                     }
                 }
                splashScreenManager1.CloseWaitForm();
                /*this.Invoke((EventHandler)(delegate { mainForm.dataForm.contact.RefreshForm(); }));
                this.Invoke((EventHandler)(delegate { mainForm.dataForm.sms.RefreshForm();}));
                this.Invoke((EventHandler)(delegate { mainForm.dataForm.mmf.RefreshForm();}));*/
                /*this.Invoke((EventHandler)(delegate { mainForm.parser(); }));
                this.Invoke((EventHandler)(delegate { mainForm.mdiForm.setTree(); }));
                this.Invoke((EventHandler)(delegate { mainForm.mdiForm.clearTab(); }));
                this.Invoke((EventHandler)(delegate { this.Close(); }));*/

                mainForm.parser();
                mainForm.caseForm.setTree();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
                DevExpress.XtraEditors.XtraMessageBox.Show("数据导入失败，请检查上传的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.Invoke((EventHandler)(delegate { this.Close(); }));
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("开始导入");
            splashScreenManager1.SetWaitFormDescription("");
            runImport();
            /*splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("开始录入");
            splashScreenManager1.SetWaitFormDescription("");
            Thread t = new Thread(runImport);
            t.Start();*/
        }
    }
}