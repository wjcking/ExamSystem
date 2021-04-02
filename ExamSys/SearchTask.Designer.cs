namespace ExamSys
{
    partial class SearchTask
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddHistory = new System.Windows.Forms.Button();
            this.drpPage = new System.Windows.Forms.ComboBox();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnCheckHistory = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFav = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cIncorrectNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCorrectionType = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExamInfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoCorrection = new System.Windows.Forms.RadioButton();
            this.rdoFav = new System.Windows.Forms.RadioButton();
            this.rdoIncorrect = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drpTopic = new System.Windows.Forms.ComboBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.drpExamInfo = new ExamSys.ComboAdvanced(this.components);
            this.btnAddHistoryTop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddHistory
            // 
            this.btnAddHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHistory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddHistory.Location = new System.Drawing.Point(317, 465);
            this.btnAddHistory.Name = "btnAddHistory";
            this.btnAddHistory.Size = new System.Drawing.Size(65, 23);
            this.btnAddHistory.TabIndex = 44;
            this.btnAddHistory.Text = "添加组卷";
            this.btnAddHistory.UseVisualStyleBackColor = true;
            this.btnAddHistory.Click += new System.EventHandler(this.btnAddHistory_Click);
            // 
            // drpPage
            // 
            this.drpPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.drpPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpPage.FormattingEnabled = true;
            this.drpPage.Location = new System.Drawing.Point(153, 467);
            this.drpPage.Name = "drpPage";
            this.drpPage.Size = new System.Drawing.Size(46, 20);
            this.drpPage.TabIndex = 43;
            this.drpPage.SelectedIndexChanged += new System.EventHandler(this.drpPage_SelectedIndexChanged);
            // 
            // numPageSize
            // 
            this.numPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numPageSize.Location = new System.Drawing.Point(71, 467);
            this.numPageSize.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numPageSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(42, 21);
            this.numPageSize.TabIndex = 42;
            this.numPageSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(502, 465);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 41;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnCheckHistory
            // 
            this.btnCheckHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckHistory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckHistory.Location = new System.Drawing.Point(388, 465);
            this.btnCheckHistory.Name = "btnCheckHistory";
            this.btnCheckHistory.Size = new System.Drawing.Size(108, 23);
            this.btnCheckHistory.TabIndex = 39;
            this.btnCheckHistory.Text = "查看组卷记录";
            this.btnCheckHistory.UseVisualStyleBackColor = true;
            this.btnCheckHistory.Click += new System.EventHandler(this.btnCheckHistory_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnter.Location = new System.Drawing.Point(583, 465);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(108, 23);
            this.btnEnter.TabIndex = 40;
            this.btnEnter.Text = "进入当前页试题";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chk,
            this.id,
            this.cSubject,
            this.cFav,
            this.cIncorrectNo,
            this.cCorrectionType,
            this.cKey,
            this.cExamInfoID});
            this.dgvData.Location = new System.Drawing.Point(15, 100);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(676, 359);
            this.dgvData.TabIndex = 38;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellClick);
            // 
            // Chk
            // 
            this.Chk.FalseValue = "";
            this.Chk.HeaderText = "选项";
            this.Chk.Name = "Chk";
            this.Chk.ReadOnly = true;
            this.Chk.Visible = false;
            this.Chk.Width = 36;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 55;
            // 
            // cSubject
            // 
            this.cSubject.DataPropertyName = "Subject";
            this.cSubject.HeaderText = "标题";
            this.cSubject.Name = "cSubject";
            this.cSubject.ReadOnly = true;
            this.cSubject.Width = 415;
            // 
            // cFav
            // 
            this.cFav.DataPropertyName = "Fav";
            this.cFav.FalseValue = "False";
            this.cFav.HeaderText = "收藏";
            this.cFav.Name = "cFav";
            this.cFav.ReadOnly = true;
            this.cFav.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cFav.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cFav.TrueValue = "True";
            this.cFav.Width = 55;
            // 
            // cIncorrectNo
            // 
            this.cIncorrectNo.DataPropertyName = "InCorrectNo";
            this.cIncorrectNo.HeaderText = "错误";
            this.cIncorrectNo.Name = "cIncorrectNo";
            this.cIncorrectNo.ReadOnly = true;
            this.cIncorrectNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cIncorrectNo.Width = 60;
            // 
            // cCorrectionType
            // 
            this.cCorrectionType.DataPropertyName = "CorrectionType";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "否";
            this.cCorrectionType.DefaultCellStyle = dataGridViewCellStyle1;
            this.cCorrectionType.HeaderText = "答案校正";
            this.cCorrectionType.Name = "cCorrectionType";
            this.cCorrectionType.ReadOnly = true;
            this.cCorrectionType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cCorrectionType.Text = "";
            this.cCorrectionType.Width = 70;
            // 
            // cKey
            // 
            this.cKey.DataPropertyName = "Key";
            this.cKey.HeaderText = "答案";
            this.cKey.Name = "cKey";
            this.cKey.ReadOnly = true;
            this.cKey.Visible = false;
            // 
            // cExamInfoID
            // 
            this.cExamInfoID.DataPropertyName = "ExamInfoID";
            this.cExamInfoID.HeaderText = "大题编号";
            this.cExamInfoID.Name = "cExamInfoID";
            this.cExamInfoID.ReadOnly = true;
            this.cExamInfoID.Visible = false;
            // 
            // rdoCorrection
            // 
            this.rdoCorrection.AutoSize = true;
            this.rdoCorrection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoCorrection.Location = new System.Drawing.Point(595, 66);
            this.rdoCorrection.Name = "rdoCorrection";
            this.rdoCorrection.Size = new System.Drawing.Size(86, 21);
            this.rdoCorrection.TabIndex = 36;
            this.rdoCorrection.Text = "已纠正试题";
            this.rdoCorrection.UseVisualStyleBackColor = true;
            // 
            // rdoFav
            // 
            this.rdoFav.AutoSize = true;
            this.rdoFav.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoFav.Location = new System.Drawing.Point(437, 67);
            this.rdoFav.Name = "rdoFav";
            this.rdoFav.Size = new System.Drawing.Size(74, 21);
            this.rdoFav.TabIndex = 35;
            this.rdoFav.Text = "我的收藏";
            this.rdoFav.UseVisualStyleBackColor = true;
            // 
            // rdoIncorrect
            // 
            this.rdoIncorrect.AutoSize = true;
            this.rdoIncorrect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoIncorrect.Location = new System.Drawing.Point(515, 67);
            this.rdoIncorrect.Name = "rdoIncorrect";
            this.rdoIncorrect.Size = new System.Drawing.Size(74, 21);
            this.rdoIncorrect.TabIndex = 34;
            this.rdoIncorrect.Text = "错题重做";
            this.rdoIncorrect.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoAll.Location = new System.Drawing.Point(357, 67);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(74, 21);
            this.rdoAll.TabIndex = 33;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "全部试题";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "检索条件";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(15, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 5);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(77, 68);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(207, 21);
            this.txtKey.TabIndex = 30;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGo.Location = new System.Drawing.Point(616, 40);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 29;
            this.btnGo.Text = "检索";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(12, 467);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "记录个数:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(116, 468);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "页数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "关键字:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(292, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "检索类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "题库选择:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(292, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "试题类型:";
            // 
            // drpTopic
            // 
            this.drpTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpTopic.FormattingEnabled = true;
            this.drpTopic.Items.AddRange(new object[] {
            "trrt",
            "trttt",
            "tttttf"});
            this.drpTopic.Location = new System.Drawing.Point(356, 40);
            this.drpTopic.Name = "drpTopic";
            this.drpTopic.Size = new System.Drawing.Size(184, 20);
            this.drpTopic.TabIndex = 22;
            // 
            // lbStatus
            // 
            this.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbStatus.Location = new System.Drawing.Point(0, 502);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(712, 18);
            this.lbStatus.TabIndex = 46;
            // 
            // drpExamInfo
            // 
            this.drpExamInfo.FormattingEnabled = true;
            this.drpExamInfo.Location = new System.Drawing.Point(78, 40);
            this.drpExamInfo.Name = "drpExamInfo";
            this.drpExamInfo.Size = new System.Drawing.Size(206, 20);
            this.drpExamInfo.TabIndex = 47;
            // 
            // btnAddHistoryTop
            // 
            this.btnAddHistoryTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddHistoryTop.Location = new System.Drawing.Point(546, 40);
            this.btnAddHistoryTop.Name = "btnAddHistoryTop";
            this.btnAddHistoryTop.Size = new System.Drawing.Size(65, 23);
            this.btnAddHistoryTop.TabIndex = 44;
            this.btnAddHistoryTop.Text = "添加组卷";
            this.btnAddHistoryTop.UseVisualStyleBackColor = true;
            this.btnAddHistoryTop.Click += new System.EventHandler(this.btnAddHistory_Click);
            // 
            // SearchTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(712, 520);
            this.Controls.Add(this.drpExamInfo);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnAddHistoryTop);
            this.Controls.Add(this.btnAddHistory);
            this.Controls.Add(this.drpPage);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnCheckHistory);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.rdoCorrection);
            this.Controls.Add(this.rdoFav);
            this.Controls.Add(this.rdoIncorrect);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drpTopic);
            this.KeyPreview = true;
            this.Name = "SearchTask";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "搜索试题";
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddHistory;
        private System.Windows.Forms.ComboBox drpPage;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnCheckHistory;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.RadioButton rdoCorrection;
        private System.Windows.Forms.RadioButton rdoFav;
        private System.Windows.Forms.RadioButton rdoIncorrect;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpTopic;
        private System.Windows.Forms.Label lbStatus;
        private ComboAdvanced drpExamInfo;
        private System.Windows.Forms.Button btnAddHistoryTop;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSubject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cFav;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIncorrectNo;
        private System.Windows.Forms.DataGridViewButtonColumn cCorrectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExamInfoID;

    }
}