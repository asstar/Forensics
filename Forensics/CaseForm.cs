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
using Model;

namespace Forensics
{
    public partial class CaseForm : DevExpress.XtraEditors.XtraForm
    {
        MainForm mainForm;
        public CaseForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Import import = new Import(mainForm);
            import.ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvCase.CurrentRow == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请选择要打开的案件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StateInfo.CaseID = dgvCase.CurrentRow.Cells["COLLECT_TARGET_ID"].Value.ToString();
                mainForm.mdiForm.setTree();
                mainForm.mdiForm.clearTab();
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvCase.CurrentRow == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请选择要导出的案件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StateInfo.CaseID = dgvCase.CurrentRow.Cells["COLLECT_TARGET_ID"].Value.ToString();
                Export export = new Export(mainForm);
                export.ShowDialog();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (dgvCase.CurrentRow == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请选择要上传的案件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StateInfo.CaseID = dgvCase.CurrentRow.Cells["COLLECT_TARGET_ID"].Value.ToString();
                UploadForm uploadForm = new UploadForm();
                uploadForm.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("确定清除该用户所有数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                StateInfo.CaseID = dgvCase.CurrentRow.Cells["COLLECT_TARGET_ID"].Value.ToString();
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("开始清除数据");
                splashScreenManager1.SetWaitFormDescription("请稍后...");
                DBTools.DeleteCase("Contact");
                DBTools.DeleteCase("Sms");
                DBTools.DeleteCase("Friend");
                DBTools.DeleteCase("GroupFriend");
                DBTools.DeleteCase("Chat");
                DBTools.DeleteCase("GroupChat");
                DBTools.DeleteCase("Zone");
                DBTools.DeleteCase("Affix");
                DBTools.DeleteWACase("WA_MFORENSICS_010100");
                DBTools.DeleteWACase("WA_MFORENSICS_010200");
                DBTools.DeleteWACase("WA_MFORENSICS_010202");
                DBTools.DeleteWACase("WA_MFORENSICS_010300");
                DBTools.DeleteWACase("WA_MFORENSICS_010400");
                DBTools.DeleteWACase("WA_MFORENSICS_010500");
                DBTools.DeleteWACase("WA_MFORENSICS_010700");
                DBTools.DeleteWACase("WA_MFORENSICS_020100");
                DBTools.DeleteWACase("WA_MFORENSICS_020200");
                DBTools.DeleteWACase("WA_MFORENSICS_020300");
                DBTools.DeleteWACase("WA_MFORENSICS_020400");
                DBTools.DeleteWACase("WA_MFORENSICS_020500");
                DBTools.DeleteWACase("WA_MFORENSICS_020600");
                DBTools.DeleteWACase("WA_MFORENSICS_020700");
                DBTools.DeleteWACase("WA_MFORENSICS_090400");
                DBTools.Zip();
                splashScreenManager1.CloseWaitForm();
                StateInfo.CaseID = null;
                setTree();
            }
        }
        WA_MFORENSICS_010100BLL inst010100 = new WA_MFORENSICS_010100BLL();
        private void CaseForm_Load(object sender, EventArgs e)
        {
            /*DataGridViewCheckBoxColumn ChCol = new DataGridViewCheckBoxColumn();
            ChCol.Name = "选项";
            ChCol.HeaderText = "选项";
            ChCol.Width = 50;
            ChCol.TrueValue = "1";
            ChCol.FalseValue = "0";
            dgvCase.Columns.Insert(0, ChCol);*/
            setTree();
            }
        public void setTree()
        {
            var result = inst010100.GetAll();
            dgvCase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            var temp = ListToDatatableHelper.ToDataTable<WA_MFORENSICS_010100>(result.ToList());

            dgvCase.DataSource = temp;
            temp.Columns["CERTIFICATE_TYPE"].ColumnName = "对象名称";
            temp.Columns["SEXCODE"].ColumnName = "案件名称";
            for (int i = 0; i < dgvCase.Columns.Count; i++)
            {
                dgvCase.Columns[i].Visible = false;
            }
            //dgvCase.Columns["选项"].Visible = true;
            dgvCase.Columns["对象名称"].Visible = true;
            dgvCase.Columns["案件名称"].Visible = true;
            dgvCase.Columns["对象名称"].FillWeight = 35;
            //dgvCase.Columns["选项"].FillWeight = 20;


            //header.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCase.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        private void dgvCase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

                /*for (int i = 0; i < dgvCase.Rows.Count; )
                {

                    int j = i;
                    dgvCase.Rows[j].Cells["选项"].Value = false;
                    i++;

                }*/

                dgvCase.CurrentRow.Cells["选项"].Value = true;
        }

        private void dgvCase_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        InfoBLL infoBLL = new InfoBLL();
        private void dgvCase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCase.CurrentRow == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请选择要打开的案件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StateInfo.CaseID = dgvCase.CurrentRow.Cells["COLLECT_TARGET_ID"].Value.ToString();
                infoBLL.SqlCommand("Update Info Set Value='" + StateInfo.CaseID + "' Where Key='CaseID'");
                mainForm.mdiForm.setTree();
                mainForm.mdiForm.clearTab();
                Close();
            }
        }
    }
}