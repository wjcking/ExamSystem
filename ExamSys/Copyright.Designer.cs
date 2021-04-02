namespace ExamSys
{
    partial class Copyright
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelCopyright = new System.Windows.Forms.Panel();
            this.lbxRegisterInfo = new System.Windows.Forms.ListBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMachineID = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lbHomePage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSystemName = new System.Windows.Forms.Label();
            this.picEasyLogo = new System.Windows.Forms.PictureBox();
            this.panelCopyright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEasyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(17, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "警告：本计算机程序受著作权法和国际条约保护。如未经授权或擅自复制或传播本程序（或其中任何部分），将受到严厉的民事和刑事制裁，并在法律许可的最大限度内受到起诉";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(547, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelCopyright
            // 
            this.panelCopyright.BackColor = System.Drawing.SystemColors.Control;
            this.panelCopyright.Controls.Add(this.lbxRegisterInfo);
            this.panelCopyright.Controls.Add(this.btnHelp);
            this.panelCopyright.Controls.Add(this.btnMachineID);
            this.panelCopyright.Controls.Add(this.btnJoin);
            this.panelCopyright.Controls.Add(this.btnRegister);
            this.panelCopyright.Controls.Add(this.button1);
            this.panelCopyright.Controls.Add(this.lbHomePage);
            this.panelCopyright.Controls.Add(this.label3);
            this.panelCopyright.Controls.Add(this.label1);
            this.panelCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCopyright.Location = new System.Drawing.Point(0, 80);
            this.panelCopyright.Name = "panelCopyright";
            this.panelCopyright.Size = new System.Drawing.Size(634, 303);
            this.panelCopyright.TabIndex = 2;
            // 
            // lbxRegisterInfo
            // 
            this.lbxRegisterInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxRegisterInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbxRegisterInfo.FormattingEnabled = true;
            this.lbxRegisterInfo.ItemHeight = 17;
            this.lbxRegisterInfo.Location = new System.Drawing.Point(20, 42);
            this.lbxRegisterInfo.Name = "lbxRegisterInfo";
            this.lbxRegisterInfo.Size = new System.Drawing.Size(511, 189);
            this.lbxRegisterInfo.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHelp.Location = new System.Drawing.Point(547, 71);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "帮助";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnMachineID
            // 
            this.btnMachineID.BackColor = System.Drawing.Color.Transparent;
            this.btnMachineID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMachineID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMachineID.Location = new System.Drawing.Point(547, 129);
            this.btnMachineID.Name = "btnMachineID";
            this.btnMachineID.Size = new System.Drawing.Size(75, 23);
            this.btnMachineID.TabIndex = 1;
            this.btnMachineID.Text = "机器号";
            this.btnMachineID.UseVisualStyleBackColor = false;
            this.btnMachineID.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.Transparent;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJoin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJoin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnJoin.Location = new System.Drawing.Point(547, 100);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 1;
            this.btnJoin.Text = "加入会员";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRegister.Location = new System.Drawing.Point(547, 42);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lbHomePage
            // 
            this.lbHomePage.AutoSize = true;
            this.lbHomePage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHomePage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbHomePage.Location = new System.Drawing.Point(316, 11);
            this.lbHomePage.Name = "lbHomePage";
            this.lbHomePage.Size = new System.Drawing.Size(104, 17);
            this.lbHomePage.TabIndex = 0;
            this.lbHomePage.Text = "易方得官方网站：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "注册信息：";
            // 
            // lbSystemName
            // 
            this.lbSystemName.AutoSize = true;
            this.lbSystemName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSystemName.ForeColor = System.Drawing.Color.Black;
            this.lbSystemName.Location = new System.Drawing.Point(420, 23);
            this.lbSystemName.Name = "lbSystemName";
            this.lbSystemName.Size = new System.Drawing.Size(0, 17);
            this.lbSystemName.TabIndex = 0;
            // 
            // picEasyLogo
            // 
            this.picEasyLogo.Location = new System.Drawing.Point(38, 12);
            this.picEasyLogo.Name = "picEasyLogo";
            this.picEasyLogo.Size = new System.Drawing.Size(100, 50);
            this.picEasyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEasyLogo.TabIndex = 3;
            this.picEasyLogo.TabStop = false;
            // 
            // Copyright
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 383);
            this.Controls.Add(this.picEasyLogo);
            this.Controls.Add(this.panelCopyright);
            this.Controls.Add(this.lbSystemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Copyright";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册信息";
            this.panelCopyright.ResumeLayout(false);
            this.panelCopyright.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEasyLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCopyright;
        private System.Windows.Forms.ListBox lbxRegisterInfo;
        private System.Windows.Forms.Label lbSystemName;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMachineID;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label lbHomePage;
        private System.Windows.Forms.PictureBox picEasyLogo;
        private System.Windows.Forms.Button btnHelp;





    }
}