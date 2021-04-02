namespace EFD.SysCenter
{
    partial class SysCenter
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExam = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSubjectDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTextProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOption = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.menuMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmExam,
            this.tsmTools,
            this.tsmHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(881, 25);
            this.menuStrip.TabIndex = 2;
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNew,
            this.tsmOpen,
            this.tsmOpenFolder,
            this.tsmClose,
            this.toolStripMenuItem7,
            this.tsmRecent,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmFile.Size = new System.Drawing.Size(58, 21);
            this.tsmFile.Text = "文件(&F)";
            this.tsmFile.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmNew
            // 
            this.tsmNew.Name = "tsmNew";
            this.tsmNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmNew.Size = new System.Drawing.Size(169, 22);
            this.tsmNew.Text = "新建(&N)";
            this.tsmNew.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsmOpen.Size = new System.Drawing.Size(169, 22);
            this.tsmOpen.Text = "打开(&O)";
            this.tsmOpen.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmOpenFolder
            // 
            this.tsmOpenFolder.Name = "tsmOpenFolder";
            this.tsmOpenFolder.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.tsmOpenFolder.Size = new System.Drawing.Size(169, 22);
            this.tsmOpenFolder.Text = "打开库文件夹";
            this.tsmOpenFolder.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(169, 22);
            this.tsmClose.Text = "关闭(&C)";
            this.tsmClose.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(166, 6);
            this.toolStripMenuItem7.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmRecent
            // 
            this.tsmRecent.Name = "tsmRecent";
            this.tsmRecent.Size = new System.Drawing.Size(169, 22);
            this.tsmRecent.Text = "最近的文件(&F)";
            this.tsmRecent.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(169, 22);
            this.tsmExit.Text = "退出(&X)";
            this.tsmExit.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmExam
            // 
            this.tsmExam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmManage,
            this.tsmSubjectDetail,
            this.tsmExport,
            this.toolStripMenuItem6,
            this.tsmLibrary});
            this.tsmExam.Name = "tsmExam";
            this.tsmExam.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmExam.Size = new System.Drawing.Size(59, 21);
            this.tsmExam.Text = "试题(&E)";
            this.tsmExam.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmManage
            // 
            this.tsmManage.Name = "tsmManage";
            this.tsmManage.Size = new System.Drawing.Size(136, 22);
            this.tsmManage.Text = "管理中心";
            this.tsmManage.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmSubjectDetail
            // 
            this.tsmSubjectDetail.Name = "tsmSubjectDetail";
            this.tsmSubjectDetail.Size = new System.Drawing.Size(136, 22);
            this.tsmSubjectDetail.Text = "试题详细";
            this.tsmSubjectDetail.Visible = false;
            this.tsmSubjectDetail.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmExport
            // 
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(136, 22);
            this.tsmExport.Text = "导出(&E)";
            this.tsmExport.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(133, 6);
            // 
            // tsmLibrary
            // 
            this.tsmLibrary.Name = "tsmLibrary";
            this.tsmLibrary.Size = new System.Drawing.Size(136, 22);
            this.tsmLibrary.Text = "试卷文档库";
            this.tsmLibrary.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmTools
            // 
            this.tsmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTextProcess,
            this.menuMaterial,
            this.tsmOption});
            this.tsmTools.Name = "tsmTools";
            this.tsmTools.Size = new System.Drawing.Size(59, 21);
            this.tsmTools.Text = "工具(&T)";
            this.tsmTools.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmTextProcess
            // 
            this.tsmTextProcess.Name = "tsmTextProcess";
            this.tsmTextProcess.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmTextProcess.Size = new System.Drawing.Size(152, 22);
            this.tsmTextProcess.Text = "文本处理";
            this.tsmTextProcess.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmOption
            // 
            this.tsmOption.Name = "tsmOption";
            this.tsmOption.Size = new System.Drawing.Size(152, 22);
            this.tsmOption.Text = "选项(&O)";
            this.tsmOption.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout});
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(61, 21);
            this.tsmHelp.Text = "帮助(&H)";
            this.tsmHelp.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(116, 22);
            this.tsmAbout.Text = "关于(&A)";
            this.tsmAbout.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStatus.Location = new System.Drawing.Point(0, 569);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(881, 18);
            this.lbStatus.TabIndex = 3;
            this.lbStatus.Text = "就绪";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(200, 100);
            this.tabPage3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(200, 100);
            this.tabPage4.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(200, 100);
            this.tabPage5.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(0, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(200, 100);
            this.tabPage6.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 25);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(881, 544);
            this.panelCenter.TabIndex = 4;
            // 
            // menuMaterial
            // 
            this.menuMaterial.Name = "menuMaterial";
            this.menuMaterial.Size = new System.Drawing.Size(152, 22);
            this.menuMaterial.Text = "大纲资料";
            this.menuMaterial.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // SysCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 587);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SysCenter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "试卷管理中心";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmExam;
        private System.Windows.Forms.ToolStripMenuItem tsmNew;
        private System.Windows.Forms.ToolStripMenuItem tsmManage;
        private System.Windows.Forms.ToolStripMenuItem tsmSubjectDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmTools;
        private System.Windows.Forms.ToolStripMenuItem tsmLibrary;
        private System.Windows.Forms.ToolStripMenuItem tsmRecent;
        private System.Windows.Forms.ToolStripMenuItem tsmTextProcess;
        private System.Windows.Forms.ToolStripMenuItem tsmOption;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Crownwood.Magic.Controls.TabPage tabPage5;
        private Crownwood.Magic.Controls.TabPage tabPage6;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem menuMaterial;
    }
}

