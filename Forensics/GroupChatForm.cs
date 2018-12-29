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
using System.IO;

namespace Forensics
{
    public partial class GroupChatForm : DevExpress.XtraEditors.XtraForm
    {
        public GroupChatForm()
        {
            InitializeComponent();
            LoadMasterData();
        }
        GroupChatBLL wxGroupBLL = new GroupChatBLL();
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
        GroupFriendBLL groupFriendBLL = new GroupFriendBLL();
        void LoadMasterData()
        {
            int count;

            //var result = wxGroupBLL.SqlQuery("select * from GroupChat  where IsDeleted<>'1' group by GroupNum order by count desc").ToList();

            List<GroupFriend> result;
            if (keyword == null || keyword == "")
            {
                result = groupFriendBLL.SqlQuery("select * from GroupFriend  where IsDeleted<>'1' AND AccountType='" + StateInfo.ChatType + "' And Account='" + StateInfo.Account + "' AND TargetID='" + StateInfo.CaseID + "' And Count>0   order by count desc").ToList();
                //result = wxGroupBLL.SqlQuery("select * from GroupChat  where IsDeleted<>'1' AND AccountType='" + StateInfo.ChatType + "'  And Account='" + StateInfo.Account + "' AND TargetID='" + StateInfo.CaseID + "' group by GroupNum order by count desc").ToList();
            }
            else
            {
                result = groupFriendBLL.SqlQuery("Select GroupFriend.* from GroupChat,GroupFriend where GroupChat.IsDeleted<>'1' AND GroupChat.AccountType='" + StateInfo.ChatType + "' And GroupChat.Account='" + StateInfo.Account + "' AND GroupChat.TargetID='" + StateInfo.CaseID + "' And GroupFriend.Count>0  And (Content Like '%" + keyword + "%' OR GroupFriend.GroupNum Like '%" + keyword + "%')  And GroupFriend.GroupNum=GroupChat.GroupNum group by GroupFriend.GroupNum order by GroupFriend.count desc").ToList();
                //result = groupFriendBLL.SqlQuery("select * from GroupFriend  where IsDeleted<>'1' AND AccountType='" + StateInfo.ChatType + "' And Account='" + StateInfo.Account + "' AND TargetID='" + StateInfo.CaseID + "' And Count>0   order by count desc").ToList();
                //result = wxGroupBLL.SqlQuery("select * from GroupChat  where IsDeleted<>'1' AND AccountType='" + StateInfo.ChatType + "' And Account='" + StateInfo.Account + "' AND (Content Like '%" + keyword + "%' OR FriendAccount Like '%" + keyword + "%') AND TargetID='" + StateInfo.CaseID + "' group by GroupNum order by count desc").ToList(); 
            }
            count = result.Count();
            var display = result.Skip((pager1.PageIndex - 1) * pager1.PageSize).Take(pager1.PageSize);
            pager1.DrawControl(count);
            DGVMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            var temp = ListToDatatableHelper.ToDataTable<GroupFriend>(display.ToList());

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
            DGVMaster.Columns["数量"].FillWeight = 30;

        }
        string groupNum;
        void LoadDetailData()
        {

            int count;
            List<GroupChat> result;
            if (keyword == null || keyword == "")
            {
                result = wxGroupBLL.SqlQuery("Select * From GroupChat where GroupNum='" + groupNum + "' AND AccountType='" + StateInfo.ChatType + "' And Account='" + StateInfo.Account + "' And IsDeleted<>'1'  Group By SendTime Order By SendTime ").ToList();
            }
            else
            {
                result = wxGroupBLL.SqlQuery("Select * From GroupChat where GroupNum='" + groupNum + "' AND AccountType='" + StateInfo.ChatType + "'  And Account='" + StateInfo.Account + "' And IsDeleted<>'1' AND (Content Like '%" + keyword + "%' OR FriendAccount Like '%" + keyword + "%') Group By SendTime  Order By SendTime").ToList();
            }
            //var result = wxGroupBLL.SqlQuery("Select * From GroupChat where GroupNum='" + groupNum + "' And IsDeleted<>'1' ").ToList();

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
            for (int i = 0; i < DGVDetail.Columns.Count; i++)
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
            //rtbDetail.Text = this.DGVDetail.CurrentRow.Cells["群聊内容"].Value.ToString();
            string text = this.DGVDetail.CurrentRow.Cells["群聊内容"].Value.ToString();
            rtbDetail.Text = text;
            List<AffixFile> fileList = new List<AffixFile>();
            try
            {
                while (text.IndexOf("(Att/") >= 0)
                {
                    string file = text.Substring(text.IndexOf("(Att/"));
                    int index = file.IndexOf(")");
                    int count = file.Count();
                    if (file.IndexOf(")") + 1 < file.Count())
                    {
                        text = file.Substring(text.IndexOf(")"));
                    }
                    else
                    {
                        text = "";
                    }
                    int i = file.IndexOf(")");
                    file = file.Substring(5, i - 5);
                    AffixFile item = new AffixFile();
                    item.Name = file;
                    fileList.Add(item);
                }
            }
            catch (Exception ex) { }
            var temp = ListToDatatableHelper.ToDataTable<AffixFile>(fileList);
            dgvAffix.DataSource = temp;
            dgvAffix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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

        AffixBLL affixBLL = new AffixBLL();
        private void dgvAffix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string fileName = this.dgvAffix.CurrentRow.Cells["Name"].Value.ToString();
            Affix item = affixBLL.SqlQuery("Select * From Affix Where Name='" + fileName + "'").FirstOrDefault();
            try
            {
                if (item.Content != null)
                {
                    if (fileName.IndexOf(".pic") >= 0)
                    {
                        PictureForm form = new PictureForm();
                        MemoryStream ms = new MemoryStream(item.Content);//把照片读到MemoryStream里  
                        Image imageBlob = Image.FromStream(ms, true);//用流创建Image  
                        form.pbShow.Image = imageBlob;
                        form.ShowDialog();
                    }
                    else
                    {
                        saveFileDialog1.FileName = fileName;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog1.FileName;
                            //保存
                            using (FileStream fsWrite = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                byte[] buffer = item.Content;
                                fsWrite.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }

                }
            }catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("附件不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }


        }

    }
}
