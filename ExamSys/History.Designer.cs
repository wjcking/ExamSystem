namespace ExamSys
{
    partial class History
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExamInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExamInfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMainSubject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cMainSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSearchType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRecordCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPageNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTestway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSqlRecordCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSqlSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPubDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTestTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBtnEnter = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cBtnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnQuit = new System.Windows.Forms.Button();
            this.drpDisplayStyle = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbRecCount = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.drpTestWay = new System.Windows.Forms.ComboBox();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.listHistory = new System.Windows.Forms.ListBox();
            this.menuListHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.listMessage = new ExamSys.ListBoxAdvanced(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.menuListHistory.SuspendLayout();
            this.SuspendLayout();
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
            this.cID,
            this.cExamInfoName,
            this.cExamInfoID,
            this.cMainSubject,
            this.cMainSubjectID,
            this.cKeyword,
            this.cSearchType,
            this.cRecordCount,
            this.cPageNumber,
            this.cTestway,
            this.cSqlRecordCount,
            this.cSqlSearch,
            this.cScore,
            this.cPubDate,
            this.cTestTimes,
            this.cPercent,
            this.cBtnEnter,
            this.cBtnDelete});
            this.dgvData.Location = new System.Drawing.Point(17, 41);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(773, 327);
            this.dgvData.TabIndex = 14;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellClick);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "ID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Visible = false;
            // 
            // cExamInfoName
            // 
            this.cExamInfoName.DataPropertyName = "ExamInfoName";
            this.cExamInfoName.FillWeight = 150F;
            this.cExamInfoName.HeaderText = "试卷名";
            this.cExamInfoName.Name = "cExamInfoName";
            this.cExamInfoName.ReadOnly = true;
            this.cExamInfoName.Width = 115;
            // 
            // cExamInfoID
            // 
            this.cExamInfoID.DataPropertyName = "ExamInfoID";
            this.cExamInfoID.HeaderText = "ExamInfoID";
            this.cExamInfoID.Name = "cExamInfoID";
            this.cExamInfoID.ReadOnly = true;
            this.cExamInfoID.Visible = false;
            // 
            // cMainSubject
            // 
            this.cMainSubject.DataPropertyName = "MainSubject";
            this.cMainSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cMainSubject.HeaderText = "点击组卷";
            this.cMainSubject.Name = "cMainSubject";
            this.cMainSubject.ReadOnly = true;
            this.cMainSubject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cMainSubject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cMainSubjectID
            // 
            this.cMainSubjectID.DataPropertyName = "MainSubjectID";
            this.cMainSubjectID.HeaderText = "MainSubjectID";
            this.cMainSubjectID.Name = "cMainSubjectID";
            this.cMainSubjectID.ReadOnly = true;
            this.cMainSubjectID.Visible = false;
            // 
            // cKeyword
            // 
            this.cKeyword.DataPropertyName = "Keyword";
            this.cKeyword.HeaderText = "关键字";
            this.cKeyword.Name = "cKeyword";
            this.cKeyword.ReadOnly = true;
            this.cKeyword.Width = 68;
            // 
            // cSearchType
            // 
            this.cSearchType.DataPropertyName = "SearchType";
            this.cSearchType.HeaderText = "检索";
            this.cSearchType.Name = "cSearchType";
            this.cSearchType.ReadOnly = true;
            this.cSearchType.Width = 58;
            // 
            // cRecordCount
            // 
            this.cRecordCount.DataPropertyName = "RecordCount";
            this.cRecordCount.HeaderText = "试题个数";
            this.cRecordCount.Name = "cRecordCount";
            this.cRecordCount.ReadOnly = true;
            this.cRecordCount.Width = 80;
            // 
            // cPageNumber
            // 
            this.cPageNumber.DataPropertyName = "PageNumber";
            this.cPageNumber.HeaderText = "页码";
            this.cPageNumber.Name = "cPageNumber";
            this.cPageNumber.ReadOnly = true;
            this.cPageNumber.Width = 38;
            // 
            // cTestway
            // 
            this.cTestway.DataPropertyName = "TestWay";
            this.cTestway.HeaderText = "考试方式";
            this.cTestway.Name = "cTestway";
            this.cTestway.ReadOnly = true;
            this.cTestway.Visible = false;
            // 
            // cSqlRecordCount
            // 
            this.cSqlRecordCount.DataPropertyName = "SqlRecordCount";
            this.cSqlRecordCount.HeaderText = "SqlRecordCount";
            this.cSqlRecordCount.Name = "cSqlRecordCount";
            this.cSqlRecordCount.ReadOnly = true;
            this.cSqlRecordCount.Visible = false;
            // 
            // cSqlSearch
            // 
            this.cSqlSearch.DataPropertyName = "SqlSearch";
            this.cSqlSearch.HeaderText = "SqlSearch";
            this.cSqlSearch.Name = "cSqlSearch";
            this.cSqlSearch.ReadOnly = true;
            this.cSqlSearch.Visible = false;
            // 
            // cScore
            // 
            this.cScore.DataPropertyName = "Score";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            this.cScore.DefaultCellStyle = dataGridViewCellStyle1;
            this.cScore.HeaderText = "分数";
            this.cScore.Name = "cScore";
            this.cScore.ReadOnly = true;
            this.cScore.Width = 38;
            // 
            // cPubDate
            // 
            this.cPubDate.DataPropertyName = "PubDate";
            this.cPubDate.HeaderText = "时间";
            this.cPubDate.Name = "cPubDate";
            this.cPubDate.ReadOnly = true;
            this.cPubDate.Visible = false;
            this.cPubDate.Width = 75;
            // 
            // cTestTimes
            // 
            this.cTestTimes.DataPropertyName = "TestTimes";
            this.cTestTimes.HeaderText = "次数";
            this.cTestTimes.Name = "cTestTimes";
            this.cTestTimes.ReadOnly = true;
            this.cTestTimes.Width = 36;
            // 
            // cPercent
            // 
            this.cPercent.DataPropertyName = "Percent";
            this.cPercent.HeaderText = "正确率";
            this.cPercent.Name = "cPercent";
            this.cPercent.ReadOnly = true;
            this.cPercent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cPercent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cPercent.ToolTipText = "选择当前记录组卷";
            this.cPercent.Width = 48;
            // 
            // cBtnEnter
            // 
            this.cBtnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBtnEnter.HeaderText = "重考";
            this.cBtnEnter.Name = "cBtnEnter";
            this.cBtnEnter.ReadOnly = true;
            this.cBtnEnter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cBtnEnter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cBtnEnter.Text = "进入";
            this.cBtnEnter.UseColumnTextForButtonValue = true;
            this.cBtnEnter.Width = 38;
            // 
            // cBtnDelete
            // 
            this.cBtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBtnDelete.HeaderText = "删除";
            this.cBtnDelete.Name = "cBtnDelete";
            this.cBtnDelete.ReadOnly = true;
            this.cBtnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cBtnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cBtnDelete.Text = "删除";
            this.cBtnDelete.UseColumnTextForButtonValue = true;
            this.cBtnDelete.Width = 38;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(715, 505);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 16;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // drpDisplayStyle
            // 
            this.drpDisplayStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.drpDisplayStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpDisplayStyle.FormattingEnabled = true;
            this.drpDisplayStyle.Location = new System.Drawing.Point(112, 509);
            this.drpDisplayStyle.Name = "drpDisplayStyle";
            this.drpDisplayStyle.Size = new System.Drawing.Size(55, 20);
            this.drpDisplayStyle.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(14, 511);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "试题显示方式：";
            // 
            // lbRecCount
            // 
            this.lbRecCount.AutoSize = true;
            this.lbRecCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lbRecCount.Location = new System.Drawing.Point(6, 9);
            this.lbRecCount.Name = "lbRecCount";
            this.lbRecCount.Size = new System.Drawing.Size(0, 17);
            this.lbRecCount.TabIndex = 3;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.Location = new System.Drawing.Point(529, 7);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(160, 21);
            this.dateTimePicker.TabIndex = 21;
            this.dateTimePicker.Visible = false;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefreshAll.Location = new System.Drawing.Point(695, 6);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.Size = new System.Drawing.Size(95, 23);
            this.btnRefreshAll.TabIndex = 22;
            this.btnRefreshAll.Text = "刷新所有记录";
            this.btnRefreshAll.UseVisualStyleBackColor = true;
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(190, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "试题考试方式：";
            // 
            // drpTestWay
            // 
            this.drpTestWay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.drpTestWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpTestWay.FormattingEnabled = true;
            this.drpTestWay.Location = new System.Drawing.Point(288, 510);
            this.drpTestWay.Name = "drpTestWay";
            this.drpTestWay.Size = new System.Drawing.Size(85, 20);
            this.drpTestWay.TabIndex = 19;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteAll.Location = new System.Drawing.Point(614, 505);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(95, 23);
            this.btnDeleteAll.TabIndex = 22;
            this.btnDeleteAll.Text = "删除所有记录";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // listHistory
            // 
            this.listHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listHistory.ContextMenuStrip = this.menuListHistory;
            this.listHistory.Font = new System.Drawing.Font("宋体", 9F);
            this.listHistory.FormattingEnabled = true;
            this.listHistory.ItemHeight = 12;
            this.listHistory.Location = new System.Drawing.Point(17, 401);
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(265, 88);
            this.listHistory.TabIndex = 23;
            this.listHistory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listHistory_KeyUp);
            // 
            // menuListHistory
            // 
            this.menuListHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDelete,
            this.tsmViewDetail,
            this.tsmRemoveAll});
            this.menuListHistory.Name = "menuListHistory";
            this.menuListHistory.Size = new System.Drawing.Size(182, 70);
            this.menuListHistory.Text = "删除已选项";
            this.menuListHistory.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuListHistory_ItemClicked);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmDelete.Size = new System.Drawing.Size(181, 22);
            this.tsmDelete.Text = "删除已选项";
            // 
            // tsmViewDetail
            // 
            this.tsmViewDetail.Name = "tsmViewDetail";
            this.tsmViewDetail.Size = new System.Drawing.Size(181, 22);
            this.tsmViewDetail.Text = "查看详细";
            this.tsmViewDetail.Visible = false;
            // 
            // tsmRemoveAll
            // 
            this.tsmRemoveAll.Name = "tsmRemoveAll";
            this.tsmRemoveAll.Size = new System.Drawing.Size(181, 22);
            this.tsmRemoveAll.Text = "删除所有项";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(303, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "消息列表";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "组卷题目类型";
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnter.Location = new System.Drawing.Point(533, 505);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 16;
            this.btnEnter.Text = "进入试卷";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // listMessage
            // 
            this.listMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listMessage.FormattingEnabled = true;
            this.listMessage.ItemHeight = 12;
            this.listMessage.Location = new System.Drawing.Point(306, 401);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(484, 88);
            this.listMessage.TabIndex = 27;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(802, 542);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listHistory);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btnRefreshAll);
            this.Controls.Add(this.drpTestWay);
            this.Controls.Add(this.drpDisplayStyle);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRecCount);
            this.KeyPreview = true;
            this.Name = "History";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "试题检索历史记录，组卷考试";
            this.Activated += new System.EventHandler(this.History_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.menuListHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ComboBox drpDisplayStyle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbRecCount;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnRefreshAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpTestWay;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.ListBox listHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ContextMenuStrip menuListHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmViewDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveAll;
        private ListBoxAdvanced listMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExamInfoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExamInfoID;
        private System.Windows.Forms.DataGridViewButtonColumn cMainSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMainSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSearchType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRecordCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestway;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSqlRecordCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSqlSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPubDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPercent;
        private System.Windows.Forms.DataGridViewButtonColumn cBtnEnter;
        private System.Windows.Forms.DataGridViewButtonColumn cBtnDelete;
    }
}