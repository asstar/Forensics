namespace Forensics
{
    partial class GroupChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.DGVMaster = new System.Windows.Forms.DataGridView();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.pager1 = new Forensics.Pager();
            this.DGVDetail = new System.Windows.Forms.DataGridView();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.pager2 = new Forensics.Pager();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.rtbDetail = new System.Windows.Forms.RichTextBox();
            this.dgvAffix = new System.Windows.Forms.DataGridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtKeyword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 63);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1315, 543);
            this.panelControl2.TabIndex = 5;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.DGVMaster);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl4);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.DGVDetail);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl5);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1311, 399);
            this.splitContainerControl1.SplitterPosition = 404;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // DGVMaster
            // 
            this.DGVMaster.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVMaster.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVMaster.Location = new System.Drawing.Point(0, 0);
            this.DGVMaster.Name = "DGVMaster";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGVMaster.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVMaster.RowTemplate.Height = 23;
            this.DGVMaster.Size = new System.Drawing.Size(404, 321);
            this.DGVMaster.TabIndex = 1;
            this.DGVMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMaster_CellClick);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.pager1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 321);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(404, 78);
            this.panelControl4.TabIndex = 0;
            // 
            // pager1
            // 
            this.pager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pager1.Location = new System.Drawing.Point(2, 2);
            this.pager1.Name = "pager1";
            this.pager1.PageIndex = 1;
            this.pager1.PageSize = 20;
            this.pager1.RecordCount = 0;
            this.pager1.Size = new System.Drawing.Size(400, 74);
            this.pager1.TabIndex = 0;
            // 
            // DGVDetail
            // 
            this.DGVDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetail.Location = new System.Drawing.Point(0, 0);
            this.DGVDetail.Name = "DGVDetail";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGVDetail.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVDetail.RowTemplate.Height = 23;
            this.DGVDetail.Size = new System.Drawing.Size(902, 321);
            this.DGVDetail.TabIndex = 1;
            this.DGVDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDetail_CellClick);
            this.DGVDetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVDetail_CellPainting);
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.pager2);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl5.Location = new System.Drawing.Point(0, 321);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(902, 78);
            this.panelControl5.TabIndex = 0;
            // 
            // pager2
            // 
            this.pager2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pager2.Location = new System.Drawing.Point(2, 2);
            this.pager2.Name = "pager2";
            this.pager2.PageIndex = 1;
            this.pager2.PageSize = 20;
            this.pager2.RecordCount = 0;
            this.pager2.Size = new System.Drawing.Size(898, 74);
            this.pager2.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.splitContainerControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 401);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1311, 140);
            this.panelControl3.TabIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.rtbDetail);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.dgvAffix);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1307, 136);
            this.splitContainerControl2.SplitterPosition = 386;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // rtbDetail
            // 
            this.rtbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDetail.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDetail.ForeColor = System.Drawing.Color.Blue;
            this.rtbDetail.Location = new System.Drawing.Point(0, 0);
            this.rtbDetail.Name = "rtbDetail";
            this.rtbDetail.Size = new System.Drawing.Size(916, 136);
            this.rtbDetail.TabIndex = 0;
            this.rtbDetail.Text = "";
            // 
            // dgvAffix
            // 
            this.dgvAffix.BackgroundColor = System.Drawing.Color.White;
            this.dgvAffix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAffix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAffix.Location = new System.Drawing.Point(0, 0);
            this.dgvAffix.Name = "dgvAffix";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvAffix.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAffix.RowTemplate.Height = 23;
            this.dgvAffix.Size = new System.Drawing.Size(386, 136);
            this.dgvAffix.TabIndex = 0;
            this.dgvAffix.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAffix_CellClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl6);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1315, 63);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnReset);
            this.panelControl6.Controls.Add(this.btnSearch);
            this.panelControl6.Controls.Add(this.txtKeyword);
            this.panelControl6.Controls.Add(this.labelControl1);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(2, 2);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(1311, 60);
            this.panelControl6.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(582, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(98, 34);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "清除";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(454, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 34);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(174, 16);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Properties.Appearance.Options.UseFont = true;
            this.txtKeyword.Size = new System.Drawing.Size(248, 26);
            this.txtKeyword.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(24, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(144, 19);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "请输入查询关键字：";
            // 
            // GroupChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 606);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "GroupChatForm";
            this.Text = "MicroMsgGroupForm";
            this.Load += new System.EventHandler(this.MicroMsgFriendForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.DataGridView DGVMaster;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private Pager pager1;
        private System.Windows.Forms.DataGridView DGVDetail;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private Pager pager2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtKeyword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private System.Windows.Forms.RichTextBox rtbDetail;
        private System.Windows.Forms.DataGridView dgvAffix;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}