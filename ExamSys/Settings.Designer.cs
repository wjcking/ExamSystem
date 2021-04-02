namespace ExamSys
{
    partial class Settings
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
            this.btnOk = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuPlatform = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOutline = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listOption = new System.Windows.Forms.ListBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.panelControl = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.contextMenu.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(450, 249);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(71, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "保存";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPlatform,
            this.menuOutline,
            this.menuMyFile,
            this.menuMemo});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(148, 92);
            // 
            // menuPlatform
            // 
            this.menuPlatform.Name = "menuPlatform";
            this.menuPlatform.Size = new System.Drawing.Size(32, 19);
            // 
            // menuOutline
            // 
            this.menuOutline.Name = "menuOutline";
            this.menuOutline.Size = new System.Drawing.Size(32, 19);
            // 
            // menuMyFile
            // 
            this.menuMyFile.Name = "menuMyFile";
            this.menuMyFile.Size = new System.Drawing.Size(32, 19);
            // 
            // menuMemo
            // 
            this.menuMemo.Name = "menuMemo";
            this.menuMemo.Size = new System.Drawing.Size(32, 19);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(527, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // listOption
            // 
            this.listOption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listOption.FormattingEnabled = true;
            this.listOption.ItemHeight = 12;
            this.listOption.Items.AddRange(new object[] {
            "文档库目录",
            "重置试题项",
            "试题分数",
            "考试平台样式",
            "大纲资料平台样式",
            "皮肤/声效/考试时间",
            "网络设置"});
            this.listOption.Location = new System.Drawing.Point(12, 12);
            this.listOption.Name = "listOption";
            this.listOption.Size = new System.Drawing.Size(120, 220);
            this.listOption.TabIndex = 21;
            this.listOption.SelectedIndexChanged += new System.EventHandler(this.listOption_SelectedIndexChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.panelControl);
            this.groupBox.Location = new System.Drawing.Point(151, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(443, 223);
            this.groupBox.TabIndex = 25;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "文档库目录";
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(3, 17);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(437, 203);
            this.panelControl.TabIndex = 25;
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(373, 249);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(71, 25);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(620, 290);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.listOption);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.contextMenu.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuPlatform;
        private System.Windows.Forms.ToolStripMenuItem menuOutline;
        private System.Windows.Forms.ToolStripMenuItem menuMyFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripMenuItem menuMemo;
        private System.Windows.Forms.ListBox listOption;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btnApply;

    }
}