namespace ExamSys
{
    partial class EFDBrowser
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
            this.tvEFD = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPrintRreview = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPageSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTreeview = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKeyword = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvEFD
            // 
            this.tvEFD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.tvEFD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvEFD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEFD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvEFD.Location = new System.Drawing.Point(0, 0);
            this.tvEFD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tvEFD.Name = "tvEFD";
            this.tvEFD.ShowNodeToolTips = true;
            this.tvEFD.Size = new System.Drawing.Size(197, 533);
            this.tvEFD.TabIndex = 1;
            this.tvEFD.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvEFD_AfterSelect);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddMaterial,
            this.menuRename,
            this.menuDelMaterial});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(184, 70);
            // 
            // menuAddMaterial
            // 
            this.menuAddMaterial.Name = "menuAddMaterial";
            this.menuAddMaterial.Size = new System.Drawing.Size(183, 22);
            this.menuAddMaterial.Text = "添加新资料";
            // 
            // menuRename
            // 
            this.menuRename.Name = "menuRename";
            this.menuRename.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuRename.Size = new System.Drawing.Size(183, 22);
            this.menuRename.Text = "重命名";
            // 
            // menuDelMaterial
            // 
            this.menuDelMaterial.Name = "menuDelMaterial";
            this.menuDelMaterial.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelMaterial.Size = new System.Drawing.Size(183, 22);
            this.menuDelMaterial.Text = "删除选中资料";
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tvEFD);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer.Size = new System.Drawing.Size(784, 537);
            this.splitContainer.SplitterDistance = 201;
            this.splitContainer.TabIndex = 28;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(575, 533);
            this.webBrowser.TabIndex = 15;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // openFile
            // 
            this.openFile.Filter = "文本文档|*.txt|网页文档|*.htm|网页文档|*.html";
            this.openFile.RestoreDirectory = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 541);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(784, 21);
            this.label1.TabIndex = 30;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMain,
            this.menuView,
            this.menuTool});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 25);
            this.menuStrip.TabIndex = 31;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuMain
            // 
            this.MenuMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMyFile,
            this.menuMaterial,
            this.toolStripSeparator1,
            this.menuPrintRreview,
            this.menuPageSet,
            this.menuPrint,
            this.toolStripMenuItem2,
            this.menuQuit});
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(58, 21);
            this.MenuMain.Text = "文件(&F)";
            this.MenuMain.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuMyFile
            // 
            this.menuMyFile.Name = "menuMyFile";
            this.menuMyFile.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuMyFile.Size = new System.Drawing.Size(164, 22);
            this.menuMyFile.Text = "文档库";
            this.menuMyFile.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuMaterial
            // 
            this.menuMaterial.Name = "menuMaterial";
            this.menuMaterial.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuMaterial.Size = new System.Drawing.Size(164, 22);
            this.menuMaterial.Text = "大纲资料";
            this.menuMaterial.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // menuPrintRreview
            // 
            this.menuPrintRreview.Name = "menuPrintRreview";
            this.menuPrintRreview.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.menuPrintRreview.Size = new System.Drawing.Size(164, 22);
            this.menuPrintRreview.Text = "打印预览";
            this.menuPrintRreview.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuPageSet
            // 
            this.menuPageSet.Name = "menuPageSet";
            this.menuPageSet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.menuPageSet.Size = new System.Drawing.Size(164, 22);
            this.menuPageSet.Text = "页面设置";
            this.menuPageSet.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuPrint
            // 
            this.menuPrint.Name = "menuPrint";
            this.menuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuPrint.Size = new System.Drawing.Size(164, 22);
            this.menuPrint.Text = "打印";
            this.menuPrint.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // menuQuit
            // 
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(164, 22);
            this.menuQuit.Text = "退出(&Q)";
            this.menuQuit.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTreeview});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(60, 21);
            this.menuView.Text = "视图(&V)";
            // 
            // menuTreeview
            // 
            this.menuTreeview.Checked = true;
            this.menuTreeview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuTreeview.Name = "menuTreeview";
            this.menuTreeview.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuTreeview.Size = new System.Drawing.Size(157, 22);
            this.menuTreeview.Text = "导航栏";
            this.menuTreeview.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuTool
            // 
            this.menuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings,
            this.menuSetMaterial,
            this.menuKeyword});
            this.menuTool.Name = "menuTool";
            this.menuTool.Size = new System.Drawing.Size(59, 21);
            this.menuTool.Text = "工具(&T)";
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuSettings.Size = new System.Drawing.Size(173, 22);
            this.menuSettings.Text = "选项(&O)";
            this.menuSettings.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuSetMaterial
            // 
            this.menuSetMaterial.Name = "menuSetMaterial";
            this.menuSetMaterial.Size = new System.Drawing.Size(173, 22);
            this.menuSetMaterial.Text = "大纲资料样式";
            this.menuSetMaterial.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // menuKeyword
            // 
            this.menuKeyword.Name = "menuKeyword";
            this.menuKeyword.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.menuKeyword.Size = new System.Drawing.Size(173, 22);
            this.menuKeyword.Text = "关键字(&K)";
            this.menuKeyword.Click += new System.EventHandler(this.MenuMain_Click);
            // 
            // EFDBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Name = "EFDBrowser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浏览资料文件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EFDBrowser_FormClosing);
            this.contextMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvEFD;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAddMaterial;
        private System.Windows.Forms.ToolStripMenuItem menuRename;
        private System.Windows.Forms.ToolStripMenuItem menuDelMaterial;
        public System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuMain;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuTreeview;
        private System.Windows.Forms.ToolStripMenuItem menuTool;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuSetMaterial;
        private System.Windows.Forms.ToolStripMenuItem menuMyFile;
        private System.Windows.Forms.ToolStripMenuItem menuMaterial;
        private System.Windows.Forms.ToolStripMenuItem menuPrintRreview;
        private System.Windows.Forms.ToolStripMenuItem menuPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuPageSet;
        private System.Windows.Forms.ToolStripMenuItem menuKeyword;
    }
}