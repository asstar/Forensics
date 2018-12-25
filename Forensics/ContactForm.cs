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
    public partial class ContactForm : DevExpress.XtraEditors.XtraForm
    {
        public ContactForm()
        {
            InitializeComponent();
        }
        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        ContactBLL contactBLL = new ContactBLL();
        void LoadData()
        {
            int count;
            //SQLiteHelper inst = new SQLiteHelper();
            //string sql = "SELECT DISTINCT RELATIONSHIP_NAME AS '联系人姓名',WA_MFORENSICS_010400.SEQUENCE_NAME AS SEQUENCE_NAME FROM WA_MFORENSICS_010400 WHERE RELATIONSHIP_NAME<>'' ";
            //var result = inst.ExecuteQuery(sql);
            //var result = new ContactBLL().GetAll().ToList();
            List<Contact> result;
            if (keyword == null || keyword == "")
            {
                result = contactBLL.SqlQuery("Select * From Contact Order By Seq").ToList();
            }
            else
            {
                result = contactBLL.SqlQuery("Select * From Contact where  IsDeleted<>'1' AND (Name Like '%" + keyword + "%' OR Account Like '%" + keyword + "%')  Order By Seq").ToList();
            }
            count = result.Count;
            //var display = inst.GetPagedTable(result, pager1.PageIndex, pager1.PageSize);
            var display = result.ToList().Skip((pager1.PageIndex - 1) * pager1.PageSize).Take(pager1.PageSize);
            pager1.DrawControl(count);
            dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            var temp = ListToDatatableHelper.ToDataTable<Contact>(display.ToList());

            temp.Columns["Name"].ColumnName = "联系人姓名";
            temp.Columns["Account"].ColumnName = "联系方式";
            dgvList.DataSource = temp;
            for (int i = 0; i < dgvList.Columns.Count; i++)
            {
                dgvList.Columns[i].Visible = false;
            }
            dgvList.Columns["联系人姓名"].Visible = true;
            dgvList.Columns["联系方式"].Visible = true;

        }
        public void RefreshForm()
        {
            LoadData();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            pager1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            pager1.PageSize = 25;
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Text = "";
        }
        string keyword = null;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            keyword = txtKeyword.Text;
            LoadData();
        }
    }
}