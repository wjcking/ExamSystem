namespace ExamSys
{
    partial class CorrectSubject
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
            this.txtCorrect = new System.Windows.Forms.TextBox();
            this.btnCorrect = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lbCorrectNotice = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbSubject = new System.Windows.Forms.Label();
            this.lbKey = new System.Windows.Forms.Label();
            this.lbTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCorrect
            // 
            this.txtCorrect.Location = new System.Drawing.Point(87, 271);
            this.txtCorrect.Multiline = true;
            this.txtCorrect.Name = "txtCorrect";
            this.txtCorrect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCorrect.Size = new System.Drawing.Size(413, 66);
            this.txtCorrect.TabIndex = 1;
            // 
            // btnCorrect
            // 
            this.btnCorrect.Location = new System.Drawing.Point(346, 365);
            this.btnCorrect.Name = "btnCorrect";
            this.btnCorrect.Size = new System.Drawing.Size(74, 23);
            this.btnCorrect.TabIndex = 2;
            this.btnCorrect.Text = "校正";
            this.btnCorrect.UseVisualStyleBackColor = true;
            this.btnCorrect.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(59, 54);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // lbCorrectNotice
            // 
            this.lbCorrectNotice.AutoSize = true;
            this.lbCorrectNotice.BackColor = System.Drawing.Color.Transparent;
            this.lbCorrectNotice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCorrectNotice.ForeColor = System.Drawing.Color.Black;
            this.lbCorrectNotice.Location = new System.Drawing.Point(85, 25);
            this.lbCorrectNotice.Name = "lbCorrectNotice";
            this.lbCorrectNotice.Size = new System.Drawing.Size(56, 17);
            this.lbCorrectNotice.TabIndex = 3;
            this.lbCorrectNotice.Text = "校正答案";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(219, 365);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(121, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "复制/提交信息";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(426, 365);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // lbSubject
            // 
            this.lbSubject.AutoEllipsis = true;
            this.lbSubject.BackColor = System.Drawing.Color.White;
            this.lbSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSubject.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubject.ForeColor = System.Drawing.Color.Black;
            this.lbSubject.Location = new System.Drawing.Point(87, 56);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(417, 49);
            this.lbSubject.TabIndex = 3;
            this.lbSubject.Text = "题干";
            // 
            // lbKey
            // 
            this.lbKey.AutoEllipsis = true;
            this.lbKey.BackColor = System.Drawing.Color.White;
            this.lbKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbKey.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbKey.ForeColor = System.Drawing.Color.Black;
            this.lbKey.Location = new System.Drawing.Point(86, 116);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(417, 109);
            this.lbKey.TabIndex = 3;
            this.lbKey.Text = "答案";
            // 
            // lbTip
            // 
            this.lbTip.AutoSize = true;
            this.lbTip.BackColor = System.Drawing.Color.Transparent;
            this.lbTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTip.ForeColor = System.Drawing.Color.Black;
            this.lbTip.Location = new System.Drawing.Point(85, 235);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(116, 17);
            this.lbTip.TabIndex = 3;
            this.lbTip.Text = "在这里输入正确答案";
            // 
            // CorrectSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(515, 400);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lbTip);
            this.Controls.Add(this.lbCorrectNotice);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCorrect);
            this.Controls.Add(this.txtCorrect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "CorrectSubject";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "试题答案校正";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCorrect;
        private System.Windows.Forms.Button btnCorrect;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbCorrectNotice;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.Label lbTip;
    }
}