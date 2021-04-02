namespace EFD.SysCenter.Include
{
    partial class Export
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
            this.btnExecuteQuery = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.ctxtCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdrpSkin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ctxtMachineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnXml = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnDebugPath = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbIsEncrypted = new System.Windows.Forms.CheckBox();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFillXml = new System.Windows.Forms.Button();
            this.btnTotalCount = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecuteQuery
            // 
            this.btnExecuteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteQuery.Location = new System.Drawing.Point(501, 36);
            this.btnExecuteQuery.Name = "btnExecuteQuery";
            this.btnExecuteQuery.Size = new System.Drawing.Size(87, 25);
            this.btnExecuteQuery.TabIndex = 1;
            this.btnExecuteQuery.Text = "执行";
            this.btnExecuteQuery.UseVisualStyleBackColor = true;
            this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.DarkBlue;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.ForeColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(693, 386);
            this.txtOutput.TabIndex = 3;
            // 
            // dgList
            // 
            this.dgList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtCategory,
            this.ctxtSubCategory,
            this.ctxtNumber,
            this.ctxtName,
            this.ctxtCreateTime,
            this.cdrpSkin,
            this.ctxtMachineID,
            this.cbtnXml,
            this.cbtnDebugPath});
            this.dgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgList.Location = new System.Drawing.Point(12, 37);
            this.dgList.Name = "dgList";
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(614, 197);
            this.dgList.TabIndex = 4;
            this.dgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellClick);
            // 
            // ctxtCategory
            // 
            this.ctxtCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ctxtCategory.DataPropertyName = "CategoryID";
            this.ctxtCategory.HeaderText = "主分类";
            this.ctxtCategory.Name = "ctxtCategory";
            this.ctxtCategory.Width = 74;
            // 
            // ctxtSubCategory
            // 
            this.ctxtSubCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ctxtSubCategory.DataPropertyName = "SubCategoryID";
            this.ctxtSubCategory.HeaderText = "子分类";
            this.ctxtSubCategory.Name = "ctxtSubCategory";
            this.ctxtSubCategory.Width = 74;
            // 
            // ctxtNumber
            // 
            this.ctxtNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ctxtNumber.DataPropertyName = "Number";
            this.ctxtNumber.HeaderText = "编号";
            this.ctxtNumber.Name = "ctxtNumber";
            this.ctxtNumber.Width = 60;
            // 
            // ctxtName
            // 
            this.ctxtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ctxtName.DataPropertyName = "ExamName";
            this.ctxtName.HeaderText = "库名";
            this.ctxtName.Name = "ctxtName";
            this.ctxtName.Width = 21;
            // 
            // ctxtCreateTime
            // 
            this.ctxtCreateTime.DataPropertyName = "CreationTime";
            this.ctxtCreateTime.HeaderText = "创建时间";
            this.ctxtCreateTime.Name = "ctxtCreateTime";
            this.ctxtCreateTime.Visible = false;
            // 
            // cdrpSkin
            // 
            this.cdrpSkin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdrpSkin.HeaderText = "皮肤";
            this.cdrpSkin.Name = "cdrpSkin";
            this.cdrpSkin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cdrpSkin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cdrpSkin.Width = 60;
            // 
            // ctxtMachineID
            // 
            this.ctxtMachineID.HeaderText = "机器号";
            this.ctxtMachineID.Name = "ctxtMachineID";
            // 
            // cbtnXml
            // 
            this.cbtnXml.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cbtnXml.HeaderText = "注册码";
            this.cbtnXml.Name = "cbtnXml";
            this.cbtnXml.Text = "生成";
            this.cbtnXml.UseColumnTextForButtonValue = true;
            this.cbtnXml.Width = 55;
            // 
            // cbtnDebugPath
            // 
            this.cbtnDebugPath.HeaderText = "导出";
            this.cbtnDebugPath.Name = "cbtnDebugPath";
            this.cbtnDebugPath.Text = "导出";
            this.cbtnDebugPath.UseColumnTextForButtonValue = true;
            // 
            // cbIsEncrypted
            // 
            this.cbIsEncrypted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIsEncrypted.AutoSize = true;
            this.cbIsEncrypted.Checked = true;
            this.cbIsEncrypted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsEncrypted.Location = new System.Drawing.Point(485, 13);
            this.cbIsEncrypted.Name = "cbIsEncrypted";
            this.cbIsEncrypted.Size = new System.Drawing.Size(131, 18);
            this.cbIsEncrypted.TabIndex = 5;
            this.cbIsEncrypted.Text = "是否加密cid文件";
            this.cbIsEncrypted.UseVisualStyleBackColor = true;
            // 
            // cbxQuery
            // 
            this.cbxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbxQuery.FormattingEnabled = true;
            this.cbxQuery.Items.AddRange(new object[] {
            "ALTER TABLE tablename DROP columnname",
            "",
            "ALTER TABLE tablename ADD 字段名 BIT ",
            "ALTER TABLE tablename ADD 字段名 VARCHAR(255) ",
            "ALTER TABLE tablename ADD 字段名 INT DEFAULT 0 ",
            "ALTER TABLE tablename ADD 字段名 TEXT ",
            "ALTER TABLE tablename ADD 字段名 DATETIME default Now() ",
            "ALTER TABLE tablename ADD 字段名 money ",
            "",
            "ALTER TABLE tablename ALTER COLUMN columnname BIT ",
            "ALTER TABLE tablename ALTER COLUMN columnname VARCHAR(255) ",
            "ALTER TABLE tablename ALTER COLUMN columnname INT default 0 ",
            "ALTER TABLE tablename ALTER COLUMN columnname TEXT ",
            "ALTER TABLE tablename ALTER COLUMN columnname DATETIME DEFAULT Now() ",
            "ALTER TABLE tablename ALTER COLUMN columnname money "});
            this.cbxQuery.Location = new System.Drawing.Point(6, 6);
            this.cbxQuery.Name = "cbxQuery";
            this.cbxQuery.Size = new System.Drawing.Size(478, 255);
            this.cbxQuery.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "题库列表:";
            // 
            // btnFillXml
            // 
            this.btnFillXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFillXml.Location = new System.Drawing.Point(632, 41);
            this.btnFillXml.Name = "btnFillXml";
            this.btnFillXml.Size = new System.Drawing.Size(87, 25);
            this.btnFillXml.TabIndex = 8;
            this.btnFillXml.Text = "填充Xml";
            this.btnFillXml.UseVisualStyleBackColor = true;
            this.btnFillXml.Click += new System.EventHandler(this.btnFillXml_Click);
            // 
            // btnTotalCount
            // 
            this.btnTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTotalCount.Location = new System.Drawing.Point(632, 86);
            this.btnTotalCount.Name = "btnTotalCount";
            this.btnTotalCount.Size = new System.Drawing.Size(87, 25);
            this.btnTotalCount.TabIndex = 9;
            this.btnTotalCount.Text = "填充总题数";
            this.btnTotalCount.UseVisualStyleBackColor = true;
            this.btnTotalCount.Click += new System.EventHandler(this.btnTotalCount_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 240);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 419);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtOutput);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(699, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "输出";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbxQuery);
            this.tabPage2.Controls.Add(this.btnExecuteQuery);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(699, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "模板";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnTotalCount);
            this.Controls.Add(this.btnFillXml);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbIsEncrypted);
            this.Controls.Add(this.dgList);
            this.Name = "Export";
            this.Size = new System.Drawing.Size(747, 684);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecuteQuery;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.CheckBox cbIsEncrypted;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFillXml;
        private System.Windows.Forms.Button btnTotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtSubCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtCreateTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn cdrpSkin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtMachineID;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnXml;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnDebugPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
