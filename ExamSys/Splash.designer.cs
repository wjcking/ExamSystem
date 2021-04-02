namespace ExamSys
{
    partial class Splash
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
            this.lblLastExamSubject = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lblCopyrights = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLastExamSubject
            // 
            this.lblLastExamSubject.AutoSize = true;
            this.lblLastExamSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblLastExamSubject.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastExamSubject.ForeColor = System.Drawing.Color.White;
            this.lblLastExamSubject.Location = new System.Drawing.Point(26, 109);
            this.lblLastExamSubject.Name = "lblLastExamSubject";
            this.lblLastExamSubject.Size = new System.Drawing.Size(121, 17);
            this.lblLastExamSubject.TabIndex = 0;
            this.lblLastExamSubject.Text = "EasyFound Ltd Co.";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(24, 69);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(353, 28);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "易方德平台 (EasyFound Platform)";
            // 
            // lblCopyrights
            // 
            this.lblCopyrights.AutoSize = true;
            this.lblCopyrights.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyrights.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCopyrights.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCopyrights.Location = new System.Drawing.Point(390, 231);
            this.lblCopyrights.Name = "lblCopyrights";
            this.lblCopyrights.Size = new System.Drawing.Size(0, 20);
            this.lblCopyrights.TabIndex = 0;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(453, 260);
            this.Controls.Add(this.lblCopyrights);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lblLastExamSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件加载中";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastExamSubject;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lblCopyrights;
    }
}