namespace ExamSys
{
    partial class Submit
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lbExamInfoID = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ggg = new System.Windows.Forms.GroupBox();
            this.lbMyProcess = new System.Windows.Forms.Label();
            this.lbOS = new System.Windows.Forms.Label();
            this.gbExam = new System.Windows.Forms.GroupBox();
            this.lbCorrectCount = new System.Windows.Forms.Label();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.lbTestWay = new System.Windows.Forms.Label();
            this.lbDuration = new System.Windows.Forms.Label();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lkRegister = new System.Windows.Forms.LinkLabel();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.drpGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listArea = new ExamSys.ListBoxAdvanced(this.components);
            this.listProvince = new ExamSys.ListBoxAdvanced(this.components);
            this.listCity = new ExamSys.ListBoxAdvanced(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ggg.SuspendLayout();
            this.gbExam.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(619, 486);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 25);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutput.Location = new System.Drawing.Point(14, 359);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(698, 121);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "提交说明：如果您的网络连接正常则可以把成绩提交至我们的官网。排名规则为：\r\n1）只有易方得考试系统在任务栏中将突出显示（更能充分说明考试环境和实力）\r\n2）正确个" +
                "数，试题总数\r\n3）考试所用时间\r\n\r\n";
            // 
            // lbExamInfoID
            // 
            this.lbExamInfoID.BackColor = System.Drawing.Color.White;
            this.lbExamInfoID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbExamInfoID.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbExamInfoID.Location = new System.Drawing.Point(533, 28);
            this.lbExamInfoID.Name = "lbExamInfoID";
            this.lbExamInfoID.Size = new System.Drawing.Size(72, 55);
            this.lbExamInfoID.TabIndex = 5;
            this.lbExamInfoID.Text = "23";
            this.lbExamInfoID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(83, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(140, 22);
            this.txtUserName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "QQ：";
            // 
            // txtJob
            // 
            this.txtJob.Location = new System.Drawing.Point(331, 12);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(181, 22);
            this.txtJob.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "从事职业：";
            // 
            // txtQQ
            // 
            this.txtQQ.Location = new System.Drawing.Point(83, 44);
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(140, 22);
            this.txtQQ.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "署名：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(698, 339);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ggg);
            this.tabPage1.Controls.Add(this.gbExam);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(690, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "考试信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ggg
            // 
            this.ggg.Controls.Add(this.lbMyProcess);
            this.ggg.Controls.Add(this.lbOS);
            this.ggg.Location = new System.Drawing.Point(30, 161);
            this.ggg.Name = "ggg";
            this.ggg.Size = new System.Drawing.Size(630, 131);
            this.ggg.TabIndex = 6;
            this.ggg.TabStop = false;
            this.ggg.Text = "考试环境";
            // 
            // lbMyProcess
            // 
            this.lbMyProcess.Location = new System.Drawing.Point(27, 59);
            this.lbMyProcess.Name = "lbMyProcess";
            this.lbMyProcess.Size = new System.Drawing.Size(579, 55);
            this.lbMyProcess.TabIndex = 0;
            this.lbMyProcess.Text = "我运行的程序";
            // 
            // lbOS
            // 
            this.lbOS.AutoSize = true;
            this.lbOS.Location = new System.Drawing.Point(27, 33);
            this.lbOS.Name = "lbOS";
            this.lbOS.Size = new System.Drawing.Size(91, 14);
            this.lbOS.TabIndex = 0;
            this.lbOS.Text = "我的操作系统";
            // 
            // gbExam
            // 
            this.gbExam.Controls.Add(this.lbExamInfoID);
            this.gbExam.Controls.Add(this.lbCorrectCount);
            this.gbExam.Controls.Add(this.lbTotalCount);
            this.gbExam.Controls.Add(this.lbEndTime);
            this.gbExam.Controls.Add(this.lbTestWay);
            this.gbExam.Controls.Add(this.lbDuration);
            this.gbExam.Controls.Add(this.lbStartTime);
            this.gbExam.Location = new System.Drawing.Point(30, 17);
            this.gbExam.Name = "gbExam";
            this.gbExam.Size = new System.Drawing.Size(630, 126);
            this.gbExam.TabIndex = 6;
            this.gbExam.TabStop = false;
            this.gbExam.Text = "考试信息";
            // 
            // lbCorrectCount
            // 
            this.lbCorrectCount.AutoSize = true;
            this.lbCorrectCount.Location = new System.Drawing.Point(276, 83);
            this.lbCorrectCount.Name = "lbCorrectCount";
            this.lbCorrectCount.Size = new System.Drawing.Size(63, 14);
            this.lbCorrectCount.TabIndex = 0;
            this.lbCorrectCount.Text = "交卷时间";
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Location = new System.Drawing.Point(27, 83);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(63, 14);
            this.lbTotalCount.TabIndex = 0;
            this.lbTotalCount.Text = "交卷时间";
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(27, 56);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(63, 14);
            this.lbEndTime.TabIndex = 0;
            this.lbEndTime.Text = "交卷时间";
            // 
            // lbTestWay
            // 
            this.lbTestWay.AutoSize = true;
            this.lbTestWay.Location = new System.Drawing.Point(276, 56);
            this.lbTestWay.Name = "lbTestWay";
            this.lbTestWay.Size = new System.Drawing.Size(91, 14);
            this.lbTestWay.TabIndex = 0;
            this.lbTestWay.Text = "考试所用时间";
            // 
            // lbDuration
            // 
            this.lbDuration.AutoSize = true;
            this.lbDuration.Location = new System.Drawing.Point(276, 28);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(91, 14);
            this.lbDuration.TabIndex = 0;
            this.lbDuration.Text = "考试所用时间";
            // 
            // lbStartTime
            // 
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.Location = new System.Drawing.Point(27, 28);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(63, 14);
            this.lbStartTime.TabIndex = 0;
            this.lbStartTime.Text = "开始时间";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lkRegister);
            this.tabPage2.Controls.Add(this.linkLabel);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.drpGender);
            this.tabPage2.Controls.Add(this.txtUserName);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtRemark);
            this.tabPage2.Controls.Add(this.txtJob);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtQQ);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(690, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "个人基本信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lkRegister
            // 
            this.lkRegister.AutoSize = true;
            this.lkRegister.Location = new System.Drawing.Point(510, 276);
            this.lkRegister.Name = "lkRegister";
            this.lkRegister.Size = new System.Drawing.Size(63, 14);
            this.lkRegister.TabIndex = 23;
            this.lkRegister.TabStop = true;
            this.lkRegister.Text = "注册会员";
            this.lkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(579, 276);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(91, 14);
            this.linkLabel.TabIndex = 22;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "获得注册信息";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listArea);
            this.groupBox2.Controls.Add(this.listProvince);
            this.groupBox2.Controls.Add(this.listCity);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(27, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 173);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "所在区域";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(408, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 21);
            this.label5.TabIndex = 20;
            this.label5.Text = ">>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(183, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = ">>";
            // 
            // drpGender
            // 
            this.drpGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpGender.FormattingEnabled = true;
            this.drpGender.Items.AddRange(new object[] {
            "",
            "男",
            "女"});
            this.drpGender.Location = new System.Drawing.Point(602, 12);
            this.drpGender.Name = "drpGender";
            this.drpGender.Size = new System.Drawing.Size(66, 21);
            this.drpGender.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "我的留言：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(331, 44);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(336, 22);
            this.txtRemark.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(547, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "性别：";
            // 
            // listArea
            // 
            this.listArea.FormattingEnabled = true;
            this.listArea.Location = new System.Drawing.Point(449, 28);
            this.listArea.Name = "listArea";
            this.listArea.Size = new System.Drawing.Size(185, 134);
            this.listArea.TabIndex = 22;
            // 
            // listProvince
            // 
            this.listProvince.FormattingEnabled = true;
            this.listProvince.Location = new System.Drawing.Point(7, 28);
            this.listProvince.Name = "listProvince";
            this.listProvince.Size = new System.Drawing.Size(168, 134);
            this.listProvince.TabIndex = 24;
            this.listProvince.SelectedIndexChanged += new System.EventHandler(this.listProvince_SelectedIndexChanged);
            // 
            // listCity
            // 
            this.listCity.FormattingEnabled = true;
            this.listCity.Location = new System.Drawing.Point(224, 28);
            this.listCity.Name = "listCity";
            this.listCity.Size = new System.Drawing.Size(175, 134);
            this.listCity.TabIndex = 23;
            this.listCity.SelectedIndexChanged += new System.EventHandler(this.listCity_SelectedIndexChanged);
            // 
            // Submit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 530);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSubmit);
            this.Name = "Submit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提交成绩到官网";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ggg.ResumeLayout(false);
            this.ggg.PerformLayout();
            this.gbExam.ResumeLayout(false);
            this.gbExam.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lbExamInfoID;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox drpGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox ggg;
        private System.Windows.Forms.GroupBox gbExam;
        private System.Windows.Forms.GroupBox groupBox2;
        private ListBoxAdvanced listArea;
        private ListBoxAdvanced listProvince;
        private ListBoxAdvanced listCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMyProcess;
        private System.Windows.Forms.Label lbOS;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.Label lbDuration;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.Label lbTestWay;
        private System.Windows.Forms.Label lbCorrectCount;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.LinkLabel lkRegister;
    }
}