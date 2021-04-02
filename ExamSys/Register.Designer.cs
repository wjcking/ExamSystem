namespace ExamSys
{
    partial class Register
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnMachineID = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.l = new System.Windows.Forms.Label();
            this.lbSystemName = new System.Windows.Forms.Label();
            this.txtValidCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listMessage = new ExamSys.ListBoxAdvanced(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(243, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "试用";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnMachineID
            // 
            this.btnMachineID.BackColor = System.Drawing.Color.Transparent;
            this.btnMachineID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMachineID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineID.ForeColor = System.Drawing.Color.Black;
            this.btnMachineID.Location = new System.Drawing.Point(12, 209);
            this.btnMachineID.Name = "btnMachineID";
            this.btnMachineID.Size = new System.Drawing.Size(52, 23);
            this.btnMachineID.TabIndex = 1;
            this.btnMachineID.Text = "机器号";
            this.btnMachineID.UseVisualStyleBackColor = false;
            this.btnMachineID.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Location = new System.Drawing.Point(304, 209);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(52, 23);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l.ForeColor = System.Drawing.Color.Black;
            this.l.Location = new System.Drawing.Point(12, 4);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(44, 17);
            this.l.TabIndex = 0;
            this.l.Text = "注册码";
            // 
            // lbSystemName
            // 
            this.lbSystemName.AutoSize = true;
            this.lbSystemName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSystemName.ForeColor = System.Drawing.Color.Black;
            this.lbSystemName.Location = new System.Drawing.Point(444, 44);
            this.lbSystemName.Name = "lbSystemName";
            this.lbSystemName.Size = new System.Drawing.Size(0, 17);
            this.lbSystemName.TabIndex = 0;
            // 
            // txtValidCode
            // 
            this.txtValidCode.Location = new System.Drawing.Point(12, 24);
            this.txtValidCode.Name = "txtValidCode";
            this.txtValidCode.Size = new System.Drawing.Size(344, 21);
            this.txtValidCode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "消息列表";
            // 
            // listMessage
            // 
            this.listMessage.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listMessage.FormattingEnabled = true;
            this.listMessage.Items.AddRange(new object[] {
            "尊敬的用户：试用版只能使用部分功能及题库",
            "注册正式版请参考帮助文档或到官网直接注册。"});
            this.listMessage.Location = new System.Drawing.Point(12, 82);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(344, 121);
            this.listMessage.TabIndex = 7;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(373, 244);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.txtValidCode);
            this.Controls.Add(this.btnMachineID);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lbSystemName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Register";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbSystemName;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnMachineID;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.TextBox txtValidCode;
        private System.Windows.Forms.Label label2;
        private ListBoxAdvanced listMessage;





    }
}