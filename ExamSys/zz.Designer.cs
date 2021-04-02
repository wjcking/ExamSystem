namespace ExamSys
{
    partial class Material
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.tabWeb = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.cbxEncoding = new System.Windows.Forms.ComboBox();
            this.chkOutlineType = new System.Windows.Forms.CheckBox();
            this.contextMenu.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.tabWeb.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.ContextMenuStrip = this.contextMenu;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView.LabelEdit = true;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView.Name = "treeView";
            this.treeView.Scrollable = false;
            this.treeView.Size = new System.Drawing.Size(214, 425);
            this.treeView.TabIndex = 1;
            this.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_AfterLabelEdit);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyUp);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddMaterial,
            this.menuRename,
            this.menuDelMaterial});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(194, 70);
            // 
            // menuAddMaterial
            // 
            this.menuAddMaterial.Name = "menuAddMaterial";
            this.menuAddMaterial.Size = new System.Drawing.Size(193, 22);
            this.menuAddMaterial.Text = "添加新资料";
            this.menuAddMaterial.Click += new System.EventHandler(this.menu_Click);
            // 
            // menuRename
            // 
            this.menuRename.Name = "menuRename";
            this.menuRename.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuRename.Size = new System.Drawing.Size(193, 22);
            this.menuRename.Text = "重命名";
            this.menuRename.Click += new System.EventHandler(this.menu_Click);
            // 
            // menuDelMaterial
            // 
            this.menuDelMaterial.Name = "menuDelMaterial";
            this.menuDelMaterial.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelMaterial.Size = new System.Drawing.Size(193, 22);
            this.menuDelMaterial.Text = "删除选中资料";
            this.menuDelMaterial.Click += new System.EventHandler(this.menu_Click);
            // 
            // txtMaterial
            // 
            this.txtMaterial.AcceptsReturn = true;
            this.txtMaterial.AcceptsTab = true;
            this.txtMaterial.AllowDrop = true;
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaterial.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaterial.Location = new System.Drawing.Point(3, 3);
            this.txtMaterial.Multiline = true;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMaterial.Size = new System.Drawing.Size(533, 393);
            this.txtMaterial.TabIndex = 2;
            this.txtMaterial.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMaterial_DragDrop);
            this.txtMaterial.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtMaterial_DragEnter);
            this.txtMaterial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyUp);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Maroon;
            this.panelTop.Controls.Add(this.lbTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 57);
            this.panelTop.TabIndex = 3;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(10, 19);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(152, 27);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "编辑我的资料库";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(525, 527);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 23);
            this.btnImport.TabIndex = 20;
            this.btnImport.Text = "导入文档";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(601, 527);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(53, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.BackColor = System.Drawing.Color.Transparent;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.ForeColor = System.Drawing.Color.Black;
            this.btnQuit.Location = new System.Drawing.Point(660, 527);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(53, 23);
            this.btnQuit.TabIndex = 22;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 84);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(765, 425);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 28;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEdit);
            this.tabControl1.Controls.Add(this.tabWeb);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 425);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.txtMaterial);
            this.tabEdit.Location = new System.Drawing.Point(4, 22);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(539, 399);
            this.tabEdit.TabIndex = 0;
            this.tabEdit.Text = "编辑";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // tabWeb
            // 
            this.tabWeb.Controls.Add(this.webBrowser);
            this.tabWeb.Location = new System.Drawing.Point(4, 22);
            this.tabWeb.Name = "tabWeb";
            this.tabWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeb.Size = new System.Drawing.Size(539, 399);
            this.tabWeb.TabIndex = 1;
            this.tabWeb.Text = "浏览";
            this.tabWeb.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(700, 557);
            this.webBrowser.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(719, 526);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "应用";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "文本文档|*.txt|网页文档|*.htm|网页文档|*.html";
            this.openFile.RestoreDirectory = true;
            // 
            // cbxEncoding
            // 
            this.cbxEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEncoding.FormattingEnabled = true;
            this.cbxEncoding.Location = new System.Drawing.Point(434, 530);
            this.cbxEncoding.Name = "cbxEncoding";
            this.cbxEncoding.Size = new System.Drawing.Size(85, 20);
            this.cbxEncoding.TabIndex = 29;
            // 
            // chkOutlineType
            // 
            this.chkOutlineType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOutlineType.AutoSize = true;
            this.chkOutlineType.Location = new System.Drawing.Point(320, 534);
            this.chkOutlineType.Name = "chkOutlineType";
            this.chkOutlineType.Size = new System.Drawing.Size(108, 16);
            this.chkOutlineType.TabIndex = 30;
            this.chkOutlineType.Text = "存储为系统资料";
            this.chkOutlineType.UseVisualStyleBackColor = true;
            // 
            // Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.chkOutlineType);
            this.Controls.Add(this.cbxEncoding);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.panelTop);
            this.Name = "Material";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浏览，编辑我的大纲/资料";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Material_FormClosing);
            this.contextMenu.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabEdit.ResumeLayout(false);
            this.tabEdit.PerformLayout();
            this.tabWeb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ComboBox cbxEncoding;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TabPage tabWeb;
        private System.Windows.Forms.CheckBox chkOutlineType;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAddMaterial;
        private System.Windows.Forms.ToolStripMenuItem menuRename;
        private System.Windows.Forms.ToolStripMenuItem menuDelMaterial;
    }
}