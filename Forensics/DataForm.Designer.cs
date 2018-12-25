namespace Forensics
{
    partial class DataForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("联系人", 4, 4);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("短信息", 4, 4);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("微信好友", 4, 4);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("微信群", 4, 4);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("微信", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("QQ好友", 4, 4);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("QQ群", 4, 4);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("QQ", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("手机", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5,
            treeNode8});
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.tvList = new System.Windows.Forms.TreeView();
            this.xtcMain = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcMain)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "star.ico");
            this.imageList1.Images.SetKeyName(1, "Organ.ico");
            this.imageList1.Images.SetKeyName(2, "usergroup6.ico");
            this.imageList1.Images.SetKeyName(3, "rolekey.ico");
            this.imageList1.Images.SetKeyName(4, "user.ico");
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtcMain);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(864, 534);
            this.splitContainerControl1.SplitterPosition = 239;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(239, 534);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.tvList);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(235, 519);
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvList.ImageIndex = 0;
            this.tvList.ImageList = this.imageList1;
            this.tvList.Location = new System.Drawing.Point(0, 0);
            this.tvList.Name = "tvList";
            treeNode1.ImageIndex = 4;
            treeNode1.Name = "节点1";
            treeNode1.SelectedImageIndex = 4;
            treeNode1.Text = "联系人";
            treeNode2.ImageIndex = 4;
            treeNode2.Name = "节点2";
            treeNode2.SelectedImageIndex = 4;
            treeNode2.Text = "短信息";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "节点0";
            treeNode3.SelectedImageIndex = 4;
            treeNode3.Text = "微信好友";
            treeNode4.ImageIndex = 4;
            treeNode4.Name = "节点1";
            treeNode4.SelectedImageIndex = 4;
            treeNode4.Text = "微信群";
            treeNode5.ImageIndex = 2;
            treeNode5.Name = "节点3";
            treeNode5.SelectedImageIndex = 2;
            treeNode5.Text = "微信";
            treeNode6.ImageIndex = 4;
            treeNode6.Name = "节点2";
            treeNode6.SelectedImageIndex = 4;
            treeNode6.Text = "QQ好友";
            treeNode7.ImageIndex = 4;
            treeNode7.Name = "节点3";
            treeNode7.SelectedImageIndex = 4;
            treeNode7.Text = "QQ群";
            treeNode8.ImageIndex = 2;
            treeNode8.Name = "节点4";
            treeNode8.SelectedImageIndex = 2;
            treeNode8.Text = "QQ";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "节点0";
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Text = "手机";
            this.tvList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tvList.SelectedImageIndex = 0;
            this.tvList.Size = new System.Drawing.Size(235, 519);
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // xtcMain
            // 
            this.xtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcMain.Location = new System.Drawing.Point(0, 0);
            this.xtcMain.Name = "xtcMain";
            this.xtcMain.Size = new System.Drawing.Size(618, 534);
            this.xtcMain.TabIndex = 0;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 534);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "DataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtcMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.TreeView tvList;
        private DevExpress.XtraTab.XtraTabControl xtcMain;
    }
}