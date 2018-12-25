namespace Forensics
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiParser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Forensics.Waiting), true, true);
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1198, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiOutput,
            this.tsmiSeperator1,
            this.tsmiParser,
            this.tsmiFilter,
            this.tsmiSeperator2,
            this.tsmiSetting,
            this.tsmiDelete,
            this.tsmiSeperator3,
            this.tsmiPassword,
            this.tsmiExit});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(152, 26);
            this.tsmiImport.Text = "导入";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiOutput
            // 
            this.tsmiOutput.Name = "tsmiOutput";
            this.tsmiOutput.Size = new System.Drawing.Size(152, 26);
            this.tsmiOutput.Text = "导出";
            this.tsmiOutput.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // tsmiSeperator1
            // 
            this.tsmiSeperator1.Name = "tsmiSeperator1";
            this.tsmiSeperator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiParser
            // 
            this.tsmiParser.Name = "tsmiParser";
            this.tsmiParser.Size = new System.Drawing.Size(152, 26);
            this.tsmiParser.Text = "数据分析";
            this.tsmiParser.Click += new System.EventHandler(this.tsmiParser_Click);
            // 
            // tsmiFilter
            // 
            this.tsmiFilter.Name = "tsmiFilter";
            this.tsmiFilter.Size = new System.Drawing.Size(152, 26);
            this.tsmiFilter.Text = "智能过滤";
            this.tsmiFilter.Click += new System.EventHandler(this.tsmiFilter_Click);
            // 
            // tsmiSeperator2
            // 
            this.tsmiSeperator2.Name = "tsmiSeperator2";
            this.tsmiSeperator2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiSetting
            // 
            this.tsmiSetting.Name = "tsmiSetting";
            this.tsmiSetting.Size = new System.Drawing.Size(152, 26);
            this.tsmiSetting.Text = "用户设置";
            this.tsmiSetting.Click += new System.EventHandler(this.tsmiSetting_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(152, 26);
            this.tsmiDelete.Text = "清空数据";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiSeperator3
            // 
            this.tsmiSeperator3.Name = "tsmiSeperator3";
            this.tsmiSeperator3.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiPassword
            // 
            this.tsmiPassword.Name = "tsmiPassword";
            this.tsmiPassword.Size = new System.Drawing.Size(152, 26);
            this.tsmiPassword.Text = "修改密码";
            this.tsmiPassword.Click += new System.EventHandler(this.tsmiPassword_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 26);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(112, 26);
            this.tsmiAbout.Text = "关于";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上传ToolStripMenuItem});
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 上传ToolStripMenuItem
            // 
            this.上传ToolStripMenuItem.Name = "上传ToolStripMenuItem";
            this.上传ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.上传ToolStripMenuItem.Text = "上传";
            // 
            // MainForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 733);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电子数据调查阅读器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiOutput;
        private System.Windows.Forms.ToolStripSeparator tsmiSeperator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiParser;
        private System.Windows.Forms.ToolStripSeparator tsmiSeperator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        private System.Windows.Forms.ToolStripSeparator tsmiSeperator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiPassword;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传ToolStripMenuItem;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

    }
}

