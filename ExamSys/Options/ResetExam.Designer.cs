namespace ExamSys.Options
{
    partial class ResetExam
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkResetOutlineKeyword = new System.Windows.Forms.CheckBox();
            this.chkResetExamInfoKeyword = new System.Windows.Forms.CheckBox();
            this.chkResetTestTime = new System.Windows.Forms.CheckBox();
            this.chkResetIncorrect = new System.Windows.Forms.CheckBox();
            this.chkResetUserAnswer = new System.Windows.Forms.CheckBox();
            this.chkResetFav = new System.Windows.Forms.CheckBox();
            this.chkResetResult = new System.Windows.Forms.CheckBox();
            this.drpExamInfo = new ExamSys.ComboAdvanced(this.components);
            this.SuspendLayout();
            // 
            // chkResetOutlineKeyword
            // 
            this.chkResetOutlineKeyword.AutoSize = true;
            this.chkResetOutlineKeyword.Location = new System.Drawing.Point(232, 76);
            this.chkResetOutlineKeyword.Name = "chkResetOutlineKeyword";
            this.chkResetOutlineKeyword.Size = new System.Drawing.Size(108, 16);
            this.chkResetOutlineKeyword.TabIndex = 0;
            this.chkResetOutlineKeyword.Text = "清空文档关键字";
            this.chkResetOutlineKeyword.UseVisualStyleBackColor = true;
            // 
            // chkResetExamInfoKeyword
            // 
            this.chkResetExamInfoKeyword.AutoSize = true;
            this.chkResetExamInfoKeyword.Location = new System.Drawing.Point(123, 76);
            this.chkResetExamInfoKeyword.Name = "chkResetExamInfoKeyword";
            this.chkResetExamInfoKeyword.Size = new System.Drawing.Size(108, 16);
            this.chkResetExamInfoKeyword.TabIndex = 0;
            this.chkResetExamInfoKeyword.Text = "清空试题关键字";
            this.chkResetExamInfoKeyword.UseVisualStyleBackColor = true;
            // 
            // chkResetTestTime
            // 
            this.chkResetTestTime.AutoSize = true;
            this.chkResetTestTime.Location = new System.Drawing.Point(17, 76);
            this.chkResetTestTime.Name = "chkResetTestTime";
            this.chkResetTestTime.Size = new System.Drawing.Size(96, 16);
            this.chkResetTestTime.TabIndex = 0;
            this.chkResetTestTime.Text = "重置考试次数";
            this.chkResetTestTime.UseVisualStyleBackColor = true;
            // 
            // chkResetIncorrect
            // 
            this.chkResetIncorrect.AutoSize = true;
            this.chkResetIncorrect.Location = new System.Drawing.Point(337, 50);
            this.chkResetIncorrect.Name = "chkResetIncorrect";
            this.chkResetIncorrect.Size = new System.Drawing.Size(96, 16);
            this.chkResetIncorrect.TabIndex = 0;
            this.chkResetIncorrect.Text = "重置做错试题";
            this.chkResetIncorrect.UseVisualStyleBackColor = true;
            // 
            // chkResetUserAnswer
            // 
            this.chkResetUserAnswer.AutoSize = true;
            this.chkResetUserAnswer.Location = new System.Drawing.Point(232, 50);
            this.chkResetUserAnswer.Name = "chkResetUserAnswer";
            this.chkResetUserAnswer.Size = new System.Drawing.Size(96, 16);
            this.chkResetUserAnswer.TabIndex = 0;
            this.chkResetUserAnswer.Text = "清空我的作答";
            this.chkResetUserAnswer.UseVisualStyleBackColor = true;
            // 
            // chkResetFav
            // 
            this.chkResetFav.AutoSize = true;
            this.chkResetFav.Location = new System.Drawing.Point(123, 50);
            this.chkResetFav.Name = "chkResetFav";
            this.chkResetFav.Size = new System.Drawing.Size(96, 16);
            this.chkResetFav.TabIndex = 0;
            this.chkResetFav.Text = "重置我的收藏";
            this.chkResetFav.UseVisualStyleBackColor = true;
            // 
            // chkResetResult
            // 
            this.chkResetResult.AutoSize = true;
            this.chkResetResult.Location = new System.Drawing.Point(17, 50);
            this.chkResetResult.Name = "chkResetResult";
            this.chkResetResult.Size = new System.Drawing.Size(96, 16);
            this.chkResetResult.TabIndex = 0;
            this.chkResetResult.Text = "清空考试记录";
            this.chkResetResult.UseVisualStyleBackColor = true;
            // 
            // drpExamInfo
            // 
            this.drpExamInfo.FormattingEnabled = true;
            this.drpExamInfo.Location = new System.Drawing.Point(17, 14);
            this.drpExamInfo.Name = "drpExamInfo";
            this.drpExamInfo.Size = new System.Drawing.Size(416, 20);
            this.drpExamInfo.TabIndex = 1;
            // 
            // ResetExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drpExamInfo);
            this.Controls.Add(this.chkResetOutlineKeyword);
            this.Controls.Add(this.chkResetExamInfoKeyword);
            this.Controls.Add(this.chkResetResult);
            this.Controls.Add(this.chkResetTestTime);
            this.Controls.Add(this.chkResetIncorrect);
            this.Controls.Add(this.chkResetFav);
            this.Controls.Add(this.chkResetUserAnswer);
            this.Name = "ResetExam";
            this.Size = new System.Drawing.Size(458, 117);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkResetOutlineKeyword;
        private System.Windows.Forms.CheckBox chkResetExamInfoKeyword;
        private System.Windows.Forms.CheckBox chkResetTestTime;
        private System.Windows.Forms.CheckBox chkResetIncorrect;
        private System.Windows.Forms.CheckBox chkResetUserAnswer;
        private System.Windows.Forms.CheckBox chkResetFav;
        private System.Windows.Forms.CheckBox chkResetResult;
        private ComboAdvanced drpExamInfo;
    }
}
