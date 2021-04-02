namespace ExamSys
{
    partial class Keyword
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
            this.lbSystemName = new System.Windows.Forms.Label();
            this.openCab = new System.Windows.Forms.OpenFileDialog();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnRemark = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // openCab
            // 
            this.openCab.DefaultExt = "cab";
            this.openCab.FileName = "reg.cab";
            this.openCab.Filter = "cab文件|*.cab|所有文件|*.*";
            this.openCab.RestoreDirectory = true;
            this.openCab.Title = "打开易方得系统注册文件";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(15, 12);
            this.txtKeyword.Multiline = true;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeyword.Size = new System.Drawing.Size(429, 160);
            this.txtKeyword.TabIndex = 9;
            this.txtKeyword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyUp);
            // 
            // btnRemark
            // 
            this.btnRemark.BackColor = System.Drawing.Color.Transparent;
            this.btnRemark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemark.ForeColor = System.Drawing.Color.Black;
            this.btnRemark.Location = new System.Drawing.Point(404, 187);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Size = new System.Drawing.Size(40, 23);
            this.btnRemark.TabIndex = 7;
            this.btnRemark.Text = "标注";
            this.btnRemark.UseVisualStyleBackColor = false;
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(357, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "关键字(按空格分开，每个关键字不少于2个字符)";
            // 
            // Keyword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(467, 233);
            this.ControlBox = false;
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnRemark);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSystemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Keyword";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关键字";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSystemName;
        private System.Windows.Forms.OpenFileDialog openCab;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnRemark;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}