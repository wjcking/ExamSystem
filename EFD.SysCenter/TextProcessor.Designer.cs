namespace EFD.SysCenter
{
    partial class TextProcessor
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.listItems = new System.Windows.Forms.ListBox();
            this.txtKeyExpression = new System.Windows.Forms.TextBox();
            this.txtAnalysisExpression = new System.Windows.Forms.TextBox();
            this.btnGetKey = new System.Windows.Forms.Button();
            this.btnGetAnalysis = new System.Windows.Forms.Button();
            this.btnClearQuestion = new System.Windows.Forms.Button();
            this.cbxClear = new System.Windows.Forms.ComboBox();
            this.txtOutput = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.listFiles = new EFD.SysCenter.ListFile(this.components);
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(125, 199);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "打开文档";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // listItems
            // 
            this.listItems.FormattingEnabled = true;
            this.listItems.ItemHeight = 12;
            this.listItems.Location = new System.Drawing.Point(221, 21);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(141, 172);
            this.listItems.TabIndex = 0;
            this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
            // 
            // txtKeyExpression
            // 
            this.txtKeyExpression.Location = new System.Drawing.Point(389, 23);
            this.txtKeyExpression.Name = "txtKeyExpression";
            this.txtKeyExpression.Size = new System.Drawing.Size(244, 21);
            this.txtKeyExpression.TabIndex = 3;
            this.txtKeyExpression.Text = "正确答案.*?故选[A-D]。";
            // 
            // txtAnalysisExpression
            // 
            this.txtAnalysisExpression.Location = new System.Drawing.Point(389, 69);
            this.txtAnalysisExpression.Name = "txtAnalysisExpression";
            this.txtAnalysisExpression.Size = new System.Drawing.Size(244, 21);
            this.txtAnalysisExpression.TabIndex = 5;
            this.txtAnalysisExpression.Text = "解题思路.*?故选[A-D]。";
            // 
            // btnGetKey
            // 
            this.btnGetKey.Location = new System.Drawing.Point(639, 21);
            this.btnGetKey.Name = "btnGetKey";
            this.btnGetKey.Size = new System.Drawing.Size(43, 23);
            this.btnGetKey.TabIndex = 7;
            this.btnGetKey.Text = "答案";
            this.btnGetKey.UseVisualStyleBackColor = true;
            this.btnGetKey.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnGetAnalysis
            // 
            this.btnGetAnalysis.Location = new System.Drawing.Point(639, 67);
            this.btnGetAnalysis.Name = "btnGetAnalysis";
            this.btnGetAnalysis.Size = new System.Drawing.Size(43, 23);
            this.btnGetAnalysis.TabIndex = 8;
            this.btnGetAnalysis.Text = "分析";
            this.btnGetAnalysis.UseVisualStyleBackColor = true;
            this.btnGetAnalysis.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnClearQuestion
            // 
            this.btnClearQuestion.Location = new System.Drawing.Point(639, 111);
            this.btnClearQuestion.Name = "btnClearQuestion";
            this.btnClearQuestion.Size = new System.Drawing.Size(43, 23);
            this.btnClearQuestion.TabIndex = 8;
            this.btnClearQuestion.Text = "清理";
            this.btnClearQuestion.UseVisualStyleBackColor = true;
            this.btnClearQuestion.Click += new System.EventHandler(this.Btn_Click);
            // 
            // cbxClear
            // 
            this.cbxClear.FormattingEnabled = true;
            this.cbxClear.Location = new System.Drawing.Point(389, 114);
            this.cbxClear.Name = "cbxClear";
            this.cbxClear.Size = new System.Drawing.Size(244, 20);
            this.cbxClear.TabIndex = 11;
            // 
            // txtOutput
            // 
            this.txtOutput.AllowDrop = true;
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(24, 228);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(658, 229);
            this.txtOutput.TabIndex = 10;
            // 
            // listFiles
            // 
            this.listFiles.Content = null;
            this.listFiles.FileInfo = null;
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 12;
            this.listFiles.Location = new System.Drawing.Point(24, 23);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(191, 172);
            this.listFiles.TabIndex = 9;
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
            // 
            // TextProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 469);
            this.Controls.Add(this.cbxClear);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.btnClearQuestion);
            this.Controls.Add(this.btnGetAnalysis);
            this.Controls.Add(this.btnGetKey);
            this.Controls.Add(this.txtAnalysisExpression);
            this.Controls.Add(this.txtKeyExpression);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.listItems);
            this.Name = "TextProcessor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextProcessor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ListBox listItems;
        private System.Windows.Forms.TextBox txtKeyExpression;
        private System.Windows.Forms.TextBox txtAnalysisExpression;
        private System.Windows.Forms.Button btnGetKey;
        private System.Windows.Forms.Button btnGetAnalysis;
        private System.Windows.Forms.Button btnClearQuestion;
        private ListFile listFiles;
        private TextboxAdvanced txtOutput;
        private System.Windows.Forms.ComboBox cbxClear;
    }
}