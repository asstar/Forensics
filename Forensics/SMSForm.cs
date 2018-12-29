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
    public partial class SMSForm : DevExpress.XtraEditors.XtraForm
    {
        public SMSForm()
        {
            InitializeComponent();
            LoadMasterData();
        }
        SmsBLL smsBLL = new SmsBLL();
        private void SMSForm_Load(object sender, EventArgs e)
        {
            pager1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            pager1.PageSize = 25;
            pager2.OnPageChanged += new EventHandler(pagerControl2_OnPageChanged);
            pager2.PageSize = 25;
            LoadMasterData();
        }
        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadMasterData();
        }
        void pagerControl2_OnPageChanged(object sender, EventArgs e)
        {
            LoadDetailData();
        }
        void LoadMasterData()
        {
            int count;

            //var result = smsBLL.SqlQuery("select * from sms  where IsDeleted<>'1' group by name order by count desc");

            List<Sms> result;
            if (keyword == null || keyword == "")
            {
                result = smsBLL.SqlQuery("select * from sms  where IsDeleted<>'1' AND TargetID='" + StateInfo.CaseID + "' group by name order by count desc").ToList();
            }
            else
            {
                result = smsBLL.SqlQuery("select * from sms  where IsDeleted<>'1' AND (Content Like '%" + keyword + "%' OR Name Like '%" + keyword + "%') AND TargetID='" + StateInfo.CaseID + "' group by name order by count desc").ToList();
            }
            count = result.Count();
            var display = result.Skip((pager1.PageIndex - 1) * pager1.PageSize).Take(pager1.PageSize);
            pager1.DrawControl(count);
            DGVMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            var temp = ListToDatatableHelper.ToDataTable<Sms>(display.ToList());


            DGVMaster.DataSource = temp;
            temp.Columns["Name"].ColumnName = "联系人姓名";
            temp.Columns["Account"].ColumnName = "联系方式";
            temp.Columns["Count"].ColumnName = "数量";
            for (int i = 0; i < DGVMaster.Columns.Count; i++)
            {
                DGVMaster.Columns[i].Visible = false;
            }
            DGVMaster.Columns["联系人姓名"].Visible = true;
            DGVMaster.Columns["联系方式"].Visible = true;
            DGVMaster.Columns["数量"].Visible = true;
            //DGVMaster.DataSource = display;
        }
        void LoadDetailData()
        {
            int count;
            //var result = smsBLL.SqlQuery("Select * From Sms where Account='" + account + "'  And IsDeleted<>'1' ").ToList();
            List<Sms> result;
            if (keyword == null || keyword == "")
            {
                result = smsBLL.SqlQuery("Select * From Sms where Account='" + account + "'  And IsDeleted<>'1'  Order By SendTime  ").ToList();
            }
            else
            {
                result = smsBLL.SqlQuery("Select * From Sms where Account='" + account + "'  And IsDeleted<>'1' AND (Content Like '%" + keyword + "%' OR Name Like '%" + keyword + "%')   Order By SendTime ").ToList();
            }
            for (int i = 0; i < result.Count(); i++)
            {
                result[i].SendTime = ConvertStringToDateTime(result[i].SendTime).ToString();
            }     
            count = result.Count();
            var display = result.ToList().Skip((pager2.PageIndex - 1) * pager2.PageSize).Take(pager2.PageSize);
            pager2.DrawControl(count);
            DGVDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            var temp = ListToDatatableHelper.ToDataTable<Sms>(display.ToList());

            DGVDetail.DataSource = temp;
            temp.Columns["Direction"].SetOrdinal(0);
            temp.Columns["SendTime"].SetOrdinal(1);
            temp.Columns["Content"].SetOrdinal(2);
            temp.Columns["Content"].ColumnName = "短信内容";
            temp.Columns["SendTime"].ColumnName = "收发时间";
            temp.Columns["Direction"].ColumnName = "收发方向";
            for (int i = 0; i < DGVMaster.Columns.Count; i++)
            {
                DGVDetail.Columns[i].Visible = false;
            }
            DGVDetail.Columns["收发方向"].Visible = true;
            DGVDetail.Columns["短信内容"].Visible = true;
            DGVDetail.Columns["收发时间"].Visible = true;
            DGVDetail.Columns["短信内容"].Width = 400;
            DGVDetail.Columns["收发时间"].Width = 120;
            DGVDetail.Columns["收发方向"].Width = 80;
        }
        private void DGVDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int intGrade = Convert.ToInt32(this.DGVDetail.Rows[e.RowIndex].Cells["DeleteStatus"].Value);
                if (intGrade == 0)
                {
                    DGVDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else if (intGrade == 1)
                {
                    DGVDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    DGVDetail.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private string account;
        private void DGVMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(this.DGVMaster.CurrentRow.Cells["联系方式"].Value.ToString());
            account = this.DGVMaster.CurrentRow.Cells["联系方式"].Value.ToString();
            pager2.PageIndex = 1;
            pager2.PageSize = 25;
            LoadDetailData();

        }
        private DateTime ConvertStringToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp+"0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        public void RefreshForm()
        {
            LoadMasterData();
        }

        private void DGVDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RTBDetail.Text = this.DGVDetail.CurrentRow.Cells["短信内容"].Value.ToString();
        }
        string keyword = null;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            keyword = txtKeyword.Text;
            LoadMasterData();
            LoadDetailData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Text = "";
        }
    }
}