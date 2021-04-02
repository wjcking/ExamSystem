namespace ExamSys
{
    partial class HandIn
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnToPlatform = new System.Windows.Forms.Button();
            this.lbHandinTime = new System.Windows.Forms.Label();
            this.lvResult = new System.Windows.Forms.ListView();
            this.cMainSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSubjectTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cEachPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCorrectNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cIncorrectNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTotalScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkRecordResult = new System.Windows.Forms.CheckBox();
            this.chkRecordUserAnswer = new System.Windows.Forms.CheckBox();
            this.btnRetry = new System.Windows.Forms.Button();
            this.chkRecordIncorrect = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(14, 21);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(101, 30);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "测试试卷";
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.Transparent;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.ForeColor = System.Drawing.Color.Black;
            this.btnQuit.Location = new System.Drawing.Point(581, 428);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(87, 25);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnToPlatform
            // 
            this.btnToPlatform.BackColor = System.Drawing.Color.Transparent;
            this.btnToPlatform.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToPlatform.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToPlatform.ForeColor = System.Drawing.Color.Black;
            this.btnToPlatform.Location = new System.Drawing.Point(675, 428);
            this.btnToPlatform.Name = "btnToPlatform";
            this.btnToPlatform.Size = new System.Drawing.Size(87, 25);
            this.btnToPlatform.TabIndex = 1;
            this.btnToPlatform.Text = "回到试题";
            this.btnToPlatform.UseVisualStyleBackColor = false;
            this.btnToPlatform.Click += new System.EventHandler(this.btnToPlatform_Click);
            // 
            // lbHandinTime
            // 
            this.lbHandinTime.AutoSize = true;
            this.lbHandinTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHandinTime.ForeColor = System.Drawing.Color.Black;
            this.lbHandinTime.Location = new System.Drawing.Point(14, 89);
            this.lbHandinTime.Name = "lbHandinTime";
            this.lbHandinTime.Size = new System.Drawing.Size(74, 19);
            this.lbHandinTime.TabIndex = 4;
            this.lbHandinTime.Text = "提交时间：";
            // 
            // lvResult
            // 
            this.lvResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cMainSubject,
            this.cSubjectTotal,
            this.cEachPoint,
            this.cCorrectNumber,
            this.cIncorrectNumber,
            this.cTotalScore,
            this.cScore,
            this.cPercent});
            this.lvResult.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvResult.Location = new System.Drawing.Point(14, 111);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(748, 276);
            this.lvResult.TabIndex = 15;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            // 
            // cMainSubject
            // 
            this.cMainSubject.Text = "大题";
            this.cMainSubject.Width = 193;
            // 
            // cSubjectTotal
            // 
            this.cSubjectTotal.Text = "试题总数";
            this.cSubjectTotal.Width = 65;
            // 
            // cEachPoint
            // 
            this.cEachPoint.Text = "每题分数";
            this.cEachPoint.Width = 65;
            // 
            // cCorrectNumber
            // 
            this.cCorrectNumber.Text = "正确个数";
            this.cCorrectNumber.Width = 65;
            // 
            // cIncorrectNumber
            // 
            this.cIncorrectNumber.Text = "错误";
            this.cIncorrectNumber.Width = 63;
            // 
            // cTotalScore
            // 
            this.cTotalScore.Text = "试题总分";
            this.cTotalScore.Width = 88;
            // 
            // cScore
            // 
            this.cScore.Text = "得分";
            this.cScore.Width = 80;
            // 
            // cPercent
            // 
            this.cPercent.Text = "正确率";
            this.cPercent.Width = 75;
            // 
            // chkRecordResult
            // 
            this.chkRecordResult.AutoSize = true;
            this.chkRecordResult.Checked = true;
            this.chkRecordResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecordResult.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkRecordResult.Location = new System.Drawing.Point(15, 431);
            this.chkRecordResult.Name = "chkRecordResult";
            this.chkRecordResult.Size = new System.Drawing.Size(106, 23);
            this.chkRecordResult.TabIndex = 18;
            this.chkRecordResult.Text = "记录考试结果";
            this.chkRecordResult.UseVisualStyleBackColor = true;
            // 
            // chkRecordUserAnswer
            // 
            this.chkRecordUserAnswer.AutoSize = true;
            this.chkRecordUserAnswer.Checked = true;
            this.chkRecordUserAnswer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecordUserAnswer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkRecordUserAnswer.Location = new System.Drawing.Point(137, 430);
            this.chkRecordUserAnswer.Name = "chkRecordUserAnswer";
            this.chkRecordUserAnswer.Size = new System.Drawing.Size(106, 23);
            this.chkRecordUserAnswer.TabIndex = 18;
            this.chkRecordUserAnswer.Text = "记录我的作答";
            this.chkRecordUserAnswer.UseVisualStyleBackColor = true;
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.Color.Transparent;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetry.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRetry.ForeColor = System.Drawing.Color.Black;
            this.btnRetry.Location = new System.Drawing.Point(486, 428);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(87, 25);
            this.btnRetry.TabIndex = 1;
            this.btnRetry.Text = "重新考试";
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // chkRecordIncorrect
            // 
            this.chkRecordIncorrect.AutoSize = true;
            this.chkRecordIncorrect.Checked = true;
            this.chkRecordIncorrect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecordIncorrect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkRecordIncorrect.Location = new System.Drawing.Point(260, 430);
            this.chkRecordIncorrect.Name = "chkRecordIncorrect";
            this.chkRecordIncorrect.Size = new System.Drawing.Size(106, 23);
            this.chkRecordIncorrect.TabIndex = 18;
            this.chkRecordIncorrect.Text = "记录错误次数";
            this.chkRecordIncorrect.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.progressBar.Location = new System.Drawing.Point(14, 393);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(748, 18);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 19;
            this.progressBar.Visible = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Red;
            this.btnSubmit.Location = new System.Drawing.Point(392, 428);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 25);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "提交官网";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // HandIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(776, 477);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.chkRecordIncorrect);
            this.Controls.Add(this.chkRecordUserAnswer);
            this.Controls.Add(this.chkRecordResult);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.lbHandinTime);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnToPlatform);
            this.Controls.Add(this.btnQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HandIn";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提交试卷";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnToPlatform;
        private System.Windows.Forms.Label lbHandinTime;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.CheckBox chkRecordResult;
        private System.Windows.Forms.CheckBox chkRecordUserAnswer;
        private System.Windows.Forms.ColumnHeader cMainSubject;
        private System.Windows.Forms.ColumnHeader cSubjectTotal;
        private System.Windows.Forms.ColumnHeader cCorrectNumber;
        private System.Windows.Forms.ColumnHeader cScore;
        private System.Windows.Forms.ColumnHeader cEachPoint;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.ColumnHeader cTotalScore;
        private System.Windows.Forms.CheckBox chkRecordIncorrect;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ColumnHeader cPercent;
        private System.Windows.Forms.ColumnHeader cIncorrectNumber;
        private System.Windows.Forms.Button btnSubmit;
    }
}