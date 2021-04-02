namespace ExamSys
{
    partial class CheckOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dgExamItem = new System.Windows.Forms.DataGridView();
            this.cIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cMainSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUserAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHandIn = new System.Windows.Forms.Button();
            this.chkLocationStyle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgExamItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTitle.Location = new System.Drawing.Point(12, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(121, 17);
            this.lbTitle.TabIndex = 9;
            this.lbTitle.Text = "题目定位（鼠标双击)";
            // 
            // dgExamItem
            // 
            this.dgExamItem.AllowUserToAddRows = false;
            this.dgExamItem.AllowUserToDeleteRows = false;
            this.dgExamItem.AllowUserToResizeRows = false;
            this.dgExamItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgExamItem.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExamItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgExamItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIndex,
            this.cID,
            this.cMark,
            this.cMainSubject,
            this.cSubject,
            this.cUserAnswer,
            this.cKey});
            this.dgExamItem.GridColor = System.Drawing.SystemColors.Control;
            this.dgExamItem.Location = new System.Drawing.Point(15, 33);
            this.dgExamItem.MultiSelect = false;
            this.dgExamItem.Name = "dgExamItem";
            this.dgExamItem.ReadOnly = true;
            this.dgExamItem.RowHeadersVisible = false;
            this.dgExamItem.RowTemplate.Height = 20;
            this.dgExamItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExamItem.Size = new System.Drawing.Size(669, 384);
            this.dgExamItem.TabIndex = 11;
            this.dgExamItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExamItem_CellDoubleClick);
            // 
            // cIndex
            // 
            this.cIndex.DataPropertyName = "Index";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.cIndex.DefaultCellStyle = dataGridViewCellStyle4;
            this.cIndex.HeaderText = "题号";
            this.cIndex.Name = "cIndex";
            this.cIndex.ReadOnly = true;
            this.cIndex.Width = 36;
            // 
            // cID
            // 
            this.cID.DataPropertyName = "ID";
            this.cID.HeaderText = "";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Visible = false;
            // 
            // cMark
            // 
            this.cMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cMark.HeaderText = "标记";
            this.cMark.Name = "cMark";
            this.cMark.ReadOnly = true;
            this.cMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cMark.Width = 36;
            // 
            // cMainSubject
            // 
            this.cMainSubject.HeaderText = "大题";
            this.cMainSubject.Name = "cMainSubject";
            this.cMainSubject.ReadOnly = true;
            // 
            // cSubject
            // 
            this.cSubject.HeaderText = "题目";
            this.cSubject.Name = "cSubject";
            this.cSubject.ReadOnly = true;
            this.cSubject.Width = 400;
            // 
            // cUserAnswer
            // 
            this.cUserAnswer.HeaderText = "作答";
            this.cUserAnswer.Name = "cUserAnswer";
            this.cUserAnswer.ReadOnly = true;
            this.cUserAnswer.Width = 60;
            // 
            // cKey
            // 
            this.cKey.DataPropertyName = "Key";
            this.cKey.HeaderText = "答案";
            this.cKey.Name = "cKey";
            this.cKey.ReadOnly = true;
            this.cKey.Visible = false;
            this.cKey.Width = 60;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(614, 423);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 24);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "回到试题";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHandIn
            // 
            this.btnHandIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHandIn.BackColor = System.Drawing.Color.Transparent;
            this.btnHandIn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHandIn.Location = new System.Drawing.Point(538, 423);
            this.btnHandIn.Name = "btnHandIn";
            this.btnHandIn.Size = new System.Drawing.Size(70, 24);
            this.btnHandIn.TabIndex = 13;
            this.btnHandIn.Text = "提交试卷";
            this.btnHandIn.UseVisualStyleBackColor = false;
            this.btnHandIn.Click += new System.EventHandler(this.btnHandIn_Click);
            // 
            // chkLocationStyle
            // 
            this.chkLocationStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLocationStyle.AutoSize = true;
            this.chkLocationStyle.Location = new System.Drawing.Point(15, 423);
            this.chkLocationStyle.Name = "chkLocationStyle";
            this.chkLocationStyle.Size = new System.Drawing.Size(144, 16);
            this.chkLocationStyle.TabIndex = 14;
            this.chkLocationStyle.Text = "双击试题后关闭该窗口";
            this.chkLocationStyle.UseVisualStyleBackColor = true;
            this.chkLocationStyle.CheckedChanged += new System.EventHandler(this.chkLocationStyle_CheckedChanged);
            // 
            // CheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(702, 453);
            this.Controls.Add(this.chkLocationStyle);
            this.Controls.Add(this.btnHandIn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgExamItem);
            this.Controls.Add(this.lbTitle);
            this.Name = "CheckOut";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "试题检查";
            this.Activated += new System.EventHandler(this.CheckOut_Activated);
            this.Load += new System.EventHandler(this.CheckOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgExamItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridView dgExamItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHandIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMainSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUserAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKey;
        private System.Windows.Forms.CheckBox chkLocationStyle;

    }
}