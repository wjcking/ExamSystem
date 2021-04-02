namespace EFD.SysCenter
{
    partial class SubjectDetailWnd
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgList = new EFD.SysCenter.DataGridAdvanced(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContent = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.cChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MainSubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtExamInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnMedia = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ctxtMedia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnChoose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(462, 275);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(16, 50);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(496, 21);
            this.txtTitle.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(645, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 42);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.Location = new System.Drawing.Point(645, 34);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 41);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "第一个";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(645, 81);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 39);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 389);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(607, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "题目详细列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cChk,
            this.MainSubjectName,
            this.ctxtExamInfoName,
            this.SubjectDetailID,
            this.SubjectID,
            this.Title,
            this.MainSubjectID,
            this.SDContent,
            this.cbtnMedia,
            this.ctxtMedia,
            this.cbtnChoose});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgList.ExamQuery = null;
            this.dgList.Location = new System.Drawing.Point(3, 3);
            this.dgList.Name = "dgList";
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(601, 357);
            this.dgList.TabIndex = 0;
            this.dgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellClick);
            this.dgList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgList_DataBindingComplete);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtTitle);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.txtContent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "添加题目详细";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "内容：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "标题：";
            // 
            // txtContent
            // 
            this.txtContent.AllowDrop = true;
            this.txtContent.Location = new System.Drawing.Point(16, 104);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(496, 165);
            this.txtContent.TabIndex = 2;
            // 
            // cChk
            // 
            this.cChk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.cChk.HeaderText = "";
            this.cChk.Name = "cChk";
            this.cChk.Width = 5;
            // 
            // MainSubjectName
            // 
            this.MainSubjectName.DataPropertyName = "MainSubjectName";
            this.MainSubjectName.HeaderText = "大题名称";
            this.MainSubjectName.Name = "MainSubjectName";
            // 
            // ctxtExamInfoName
            // 
            this.ctxtExamInfoName.DataPropertyName = "ExamInfoName";
            this.ctxtExamInfoName.HeaderText = "试卷名";
            this.ctxtExamInfoName.Name = "ctxtExamInfoName";
            this.ctxtExamInfoName.Width = 70;
            // 
            // SubjectDetailID
            // 
            this.SubjectDetailID.DataPropertyName = "SubjectDetailID";
            this.SubjectDetailID.HeaderText = "SubjectDetailID";
            this.SubjectDetailID.Name = "SubjectDetailID";
            this.SubjectDetailID.Visible = false;
            // 
            // SubjectID
            // 
            this.SubjectID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SubjectID.DataPropertyName = "SubjectID";
            this.SubjectID.HeaderText = "题目ID";
            this.SubjectID.Name = "SubjectID";
            this.SubjectID.Width = 66;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "标题";
            this.Title.Name = "Title";
            this.Title.Width = 20;
            // 
            // MainSubjectID
            // 
            this.MainSubjectID.DataPropertyName = "MainSubjectID";
            this.MainSubjectID.HeaderText = "MainSubjectID";
            this.MainSubjectID.Name = "MainSubjectID";
            this.MainSubjectID.Visible = false;
            // 
            // SDContent
            // 
            this.SDContent.DataPropertyName = "SDContent";
            this.SDContent.HeaderText = "内容";
            this.SDContent.Name = "SDContent";
            // 
            // cbtnMedia
            // 
            this.cbtnMedia.HeaderText = "声音";
            this.cbtnMedia.Name = "cbtnMedia";
            // 
            // ctxtMedia
            // 
            this.ctxtMedia.DataPropertyName = "Media";
            this.ctxtMedia.HeaderText = "MediaExtentsion";
            this.ctxtMedia.Name = "ctxtMedia";
            this.ctxtMedia.Visible = false;
            // 
            // cbtnChoose
            // 
            this.cbtnChoose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cbtnChoose.DataPropertyName = "SubjectDetailID";
            this.cbtnChoose.HeaderText = "选择";
            this.cbtnChoose.Name = "cbtnChoose";
            this.cbtnChoose.Width = 32;
            // 
            // SubjectDetailWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 430);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnDelete);
            this.Name = "SubjectDetailWnd";
            this.Text = "SubjectDetailWnd";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridAdvanced dgList;
        private TextboxAdvanced txtContent;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainSubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtExamInfoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDContent;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnMedia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtMedia;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnChoose;
    }
}