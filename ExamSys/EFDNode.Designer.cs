namespace ExamSys
{
    partial class EFDNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EFDNode));
            this.tvEFD = new System.Windows.Forms.TreeView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tvEFD
            // 
            this.tvEFD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvEFD.Location = new System.Drawing.Point(12, 65);
            this.tvEFD.Name = "tvEFD";
            this.tvEFD.Size = new System.Drawing.Size(270, 262);
            this.tvEFD.TabIndex = 0;
            this.tvEFD.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvEFD_AfterSelect);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(270, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // EFDNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 339);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tvEFD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 100);
            this.Name = "EFDNode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "试卷列表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvEFD;
        private System.Windows.Forms.ComboBox comboBox1;
         
    }
}