namespace EFD.SysCenter
{
    partial class Database
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database));
            this.lvExam = new System.Windows.Forms.ListView();
            this.menuListStyle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmLarge = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTile = new System.Windows.Forms.ToolStripMenuItem();
            this.imageDatabase = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbDetail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuListStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvExam
            // 
            this.lvExam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvExam.ContextMenuStrip = this.menuListStyle;
            this.lvExam.LargeImageList = this.imageDatabase;
            this.lvExam.Location = new System.Drawing.Point(12, 37);
            this.lvExam.MultiSelect = false;
            this.lvExam.Name = "lvExam";
            this.lvExam.Size = new System.Drawing.Size(585, 208);
            this.lvExam.TabIndex = 0;
            this.lvExam.UseCompatibleStateImageBehavior = false;
            this.lvExam.View = System.Windows.Forms.View.SmallIcon;
            this.lvExam.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvExam_MouseDoubleClick);
            // 
            // menuListStyle
            // 
            this.menuListStyle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLarge,
            this.tsmSmall,
            this.tsmDetails,
            this.tsmList,
            this.tsmTile});
            this.menuListStyle.Name = "menuListStyle";
            this.menuListStyle.Size = new System.Drawing.Size(129, 114);
            // 
            // tsmLarge
            // 
            this.tsmLarge.Name = "tsmLarge";
            this.tsmLarge.Size = new System.Drawing.Size(128, 22);
            this.tsmLarge.Text = "大图标(&B)";
            this.tsmLarge.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmSmall
            // 
            this.tsmSmall.Name = "tsmSmall";
            this.tsmSmall.Size = new System.Drawing.Size(128, 22);
            this.tsmSmall.Text = "小图标(&S)";
            this.tsmSmall.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmDetails
            // 
            this.tsmDetails.Name = "tsmDetails";
            this.tsmDetails.Size = new System.Drawing.Size(128, 22);
            this.tsmDetails.Text = "明细(&D)";
            this.tsmDetails.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmList
            // 
            this.tsmList.Name = "tsmList";
            this.tsmList.Size = new System.Drawing.Size(128, 22);
            this.tsmList.Text = "列表(&L)";
            this.tsmList.Visible = false;
            this.tsmList.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmTile
            // 
            this.tsmTile.Name = "tsmTile";
            this.tsmTile.Size = new System.Drawing.Size(128, 22);
            this.tsmTile.Text = "Tile";
            this.tsmTile.Visible = false;
            this.tsmTile.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // imageDatabase
            // 
            this.imageDatabase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageDatabase.ImageStream")));
            this.imageDatabase.TransparentColor = System.Drawing.Color.Transparent;
         //   this.imageDatabase.Images.SetKeyName(0, "favicon.ico");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(14, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 5);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(522, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(439, 330);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lbDetail
            // 
            this.lbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDetail.Location = new System.Drawing.Point(14, 250);
            this.lbDetail.Multiline = true;
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.ReadOnly = true;
            this.lbDetail.Size = new System.Drawing.Size(583, 51);
            this.lbDetail.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "选择题库(&D)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 12;
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 364);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbDetail);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lvExam);
            this.MaximizeBox = false;
            this.Name = "Database";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Database";
            this.menuListStyle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvExam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox lbDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageDatabase;
        private System.Windows.Forms.ContextMenuStrip menuListStyle;
        private System.Windows.Forms.ToolStripMenuItem tsmLarge;
        private System.Windows.Forms.ToolStripMenuItem tsmSmall;
        private System.Windows.Forms.ToolStripMenuItem tsmDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmList;
        private System.Windows.Forms.ToolStripMenuItem tsmTile;
    }
}