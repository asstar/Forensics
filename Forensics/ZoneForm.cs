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
    public partial class ZoneForm : DevExpress.XtraEditors.XtraForm
    {
        public ZoneForm()
        {
            InitializeComponent();
            LoadMasterData();
        }
        GroupChatBLL qqGroupBLL = new GroupChatBLL();
        private void MicroMsgFriendForm_Load(object sender, EventArgs e)
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
            List<GroupChat> result;
            if (keyword == null || keyword == "")
            {
                result = qqGroupBLL.SqlQuery("select * from Zone  where IsDeleted<>'1' group by GroupNum order by count desc").ToList();
            }
            else
            {
                result = qqGroupBLL.SqlQuery("select * from Zone  where IsDeleted<>'1' AND (Content Like '%" + keyword + "%' OR FriendAccount Like '%" + keyword + "%') group by GroupNum order by count desc").ToList();
            }
            //var result = qqGroupBLL.SqlQuery("select * from GroupChat  where IsDeleted<>'1' group by GroupNum order by count desc");
            count = result.Count();
            var display = result.ToList().Skip((pager1.PageIndex - 1) * pager1.PageSize).Take(pager1.PageSize);
            pager1.DrawControl(count);
            DGVMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            var temp = ListToDatatableHelper.ToDataTable<GroupChat>(display.ToList());

            DGVMaster.DataSource = temp;
            temp.Columns["GroupName"].ColumnName = "群名称";
            temp.Columns["Account"].ColumnName = "账号";
            temp.Columns["Count"].ColumnName = "数量";
            for (int i = 0; i < DGVMaster.Columns.Count; i++)
            {
                DGVMaster.Columns[i].Visible = false;
            }
            DGVMaster.Columns["群名称"].Visible = true;
            DGVMaster.Columns["账号"].Visible = true;
            DGVMaster.Columns["数量"].Visible = true;

        }
        string groupNum;
        void LoadDetailData()
        {

            int count;
            //var result = qqGroupBLL.SqlQuery("Select * From GroupChat where GroupNum='" + groupNum + "' And IsDeleted<>'1' ").ToList();
            List<GroupChat> result;
            if (keyword == null || keyword == "")
            {
                result = qqGroupBLL.SqlQuery("Select * From Zone where GroupNum='" + groupNum + "' And IsDeleted<>'1'  Order By SendTime").ToList();
            }
            else
            {
                result = qqGroupBLL.SqlQuery("Select * From Zone where GroupNum='" + groupNum + "' And IsDeleted<>'1' AND (Content Like '%" + keyword + "%' OR FriendAccount Like '%" + keyword + "%')  Order By SendTime").ToList();
            }
            for (int i = 0; i < result.Count(); i++)
            {
                result[i].SendTime = ConvertStringToDateTime(result[i].SendTime).ToString();
            }
            count = result.Count();
            var display = result.ToList().Skip((pager2.PageIndex - 1) * pager2.PageSize).Take(pager2.PageSize);
            pager2.DrawControl(count);
            DGVDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            var temp = ListToDatatableHelper.ToDataTable<GroupChat>(display.ToList());

            DGVDetail.DataSource = temp;
            temp.Columns["Direction"].SetOrdinal(0);
            temp.Columns["SendTime"].SetOrdinal(1);
            temp.Columns["Content"].SetOrdinal(2);
            temp.Columns["Content"].ColumnName = "群聊内容";
            temp.Columns["SendTime"].ColumnName = "收发时间";
            temp.Columns["Direction"].ColumnName = "收发方向";
            for (int i = 0; i < DGVMaster.Columns.Count; i++)
            {
                DGVDetail.Columns[i].Visible = false;
            }
            DGVDetail.Columns["收发方向"].Visible = true;
            DGVDetail.Columns["群聊内容"].Visible = true;
            DGVDetail.Columns["收发时间"].Visible = true;
            DGVDetail.Columns["群聊内容"].Width = 400;
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
        private void DGVMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(this.DGVMaster.CurrentRow.Cells["GroupNum"].Value.ToString());
            groupNum = this.DGVMaster.CurrentRow.Cells["GroupNum"].Value.ToString();
            pager2.PageIndex = 1;
            pager2.PageSize = 25;
            LoadDetailData();

        }
        private DateTime ConvertStringToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        public void RefreshForm()
        {
            LoadMasterData();
        }

        private void DGVDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RTBDetail.Text = this.DGVDetail.CurrentRow.Cells["群聊内容"].Value.ToString();
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
