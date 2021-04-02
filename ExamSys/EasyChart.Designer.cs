namespace ExamSys
{
    partial class EasyChart
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
            this.chart = new FanG.Chartlet();
            this.drpMsi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drpChartType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drpExamInfo = new ExamSys.ComboAdvanced(this.components);
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Alpha3D = ((byte)(255));
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder;
            this.chart.AutoBarWidth = true;
            this.chart.BackColor = System.Drawing.Color.Transparent;
            this.chart.Background.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(238)))));
            this.chart.Background.Lowlight = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.chart.Background.Paper = System.Drawing.SystemColors.Control;
            this.chart.ChartTitle.BackColor = System.Drawing.Color.White;
            this.chart.ChartTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.chart.ChartTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chart.ChartTitle.OffsetY = -30;
            this.chart.ChartTitle.Show = false;
            this.chart.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            this.chart.ChartType = FanG.Chartlet.ChartTypes.Bar;
            this.chart.ClientClick = "";
            this.chart.ClientMouseMove = "";
            this.chart.ClientMouseOut = "";
            this.chart.ClientMouseOver = "";
            this.chart.ClientUseMap = "";
            this.chart.Colorful = true;
            this.chart.ColorGuider.BackColor = System.Drawing.Color.White;
            this.chart.ColorGuider.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chart.ColorGuider.ForeColor = System.Drawing.Color.Black;
            this.chart.ColorGuider.Show = true;
            this.chart.CopyrightText = "EasyFound Chart";
            this.chart.Crystal.Contraction = 1;
            this.chart.Crystal.CoverFull = true;
            this.chart.Crystal.Direction = FanG.Chartlet.Direction.TopBottom;
            this.chart.Crystal.Enable = true;
            this.chart.Depth3D = 10;
            this.chart.Dimension = FanG.Chartlet.ChartDimensions.Chart2D;
            this.chart.Fill.Color1 = System.Drawing.Color.Empty;
            this.chart.Fill.Color2 = System.Drawing.Color.Empty;
            this.chart.Fill.Color3 = System.Drawing.Color.Empty;
            this.chart.Fill.ColorStyle = FanG.Chartlet.ColorStyles.Aurora;
            this.chart.Fill.ShiftStep = 0;
            this.chart.Fill.TextureEnable = false;
            this.chart.Fill.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chart.GroupSize = 0;
            this.chart.ImageBorder = 0;
            this.chart.ImageFolder = "Chartlet";
            this.chart.ImageStyle = "";
            this.chart.InflateBottom = 0;
            this.chart.InflateLeft = 0;
            this.chart.InflateRight = 0;
            this.chart.InflateTop = 0;
            this.chart.LineConnectionRadius = 10;
            this.chart.LineConnectionType = FanG.Chartlet.LineConnectionTypes.Round;
            this.chart.Location = new System.Drawing.Point(19, 58);
            this.chart.MaxValueY = 0D;
            this.chart.MinValueY = 0D;
            this.chart.Name = "chart";
            this.chart.OutputFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            this.chart.RootPath = "C:\\\\";
            this.chart.RoundRadius = 2;
            this.chart.RoundRectangle = false;
            this.chart.Shadow.Alpha = ((byte)(192));
            this.chart.Shadow.Angle = 60F;
            this.chart.Shadow.Color = System.Drawing.Color.Black;
            this.chart.Shadow.Distance = 0;
            this.chart.Shadow.Enable = true;
            this.chart.Shadow.Hollow = false;
            this.chart.Shadow.Radius = 3;
            this.chart.ShowCopyright = true;
            this.chart.ShowErrorInfo = true;
            this.chart.Size = new System.Drawing.Size(761, 403);
            this.chart.Stroke.Color1 = System.Drawing.Color.Empty;
            this.chart.Stroke.Color2 = System.Drawing.Color.Empty;
            this.chart.Stroke.Color3 = System.Drawing.Color.Empty;
            this.chart.Stroke.ColorStyle = FanG.Chartlet.ColorStyles.None;
            this.chart.Stroke.ShiftStep = 0;
            this.chart.Stroke.TextureEnable = false;
            this.chart.Stroke.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chart.Stroke.Width = 0;
            this.chart.TabIndex = 0;
            this.chart.Tips.BackColor = System.Drawing.Color.White;
            this.chart.Tips.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chart.Tips.ForeColor = System.Drawing.Color.Black;
            this.chart.Tips.Show = true;
            this.chart.XLabels.BackColor = System.Drawing.Color.White;
            this.chart.XLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chart.XLabels.ForeColor = System.Drawing.Color.Black;
            this.chart.XLabels.RotateAngle = 0F;
            this.chart.XLabels.SampleSize = 1;
            this.chart.XLabels.Show = true;
            this.chart.XLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chart.XLabels.UnitText = "";
            this.chart.XLabels.ValueFormat = "0.0";
            this.chart.YLabels.BackColor = System.Drawing.Color.White;
            this.chart.YLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chart.YLabels.ForeColor = System.Drawing.Color.Black;
            this.chart.YLabels.Show = true;
            this.chart.YLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chart.YLabels.UnitText = "";
            this.chart.YLabels.ValueFormat = "0";
            // 
            // drpMsi
            // 
            this.drpMsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpMsi.FormattingEnabled = true;
            this.drpMsi.Location = new System.Drawing.Point(408, 24);
            this.drpMsi.Name = "drpMsi";
            this.drpMsi.Size = new System.Drawing.Size(186, 20);
            this.drpMsi.TabIndex = 1;
            this.drpMsi.SelectedIndexChanged += new System.EventHandler(this.drpMsi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "近期考试记录：";
            // 
            // drpChartType
            // 
            this.drpChartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.drpChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpChartType.FormattingEnabled = true;
            this.drpChartType.Location = new System.Drawing.Point(479, 487);
            this.drpChartType.Name = "drpChartType";
            this.drpChartType.Size = new System.Drawing.Size(303, 20);
            this.drpChartType.TabIndex = 1;
            this.drpChartType.SelectedIndexChanged += new System.EventHandler(this.drpChartType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(405, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "图表类型：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(19, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 2);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(26, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 2);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // drpExamInfo
            // 
            this.drpExamInfo.FormattingEnabled = true;
            this.drpExamInfo.Location = new System.Drawing.Point(116, 23);
            this.drpExamInfo.Name = "drpExamInfo";
            this.drpExamInfo.Size = new System.Drawing.Size(286, 20);
            this.drpExamInfo.TabIndex = 7;
            this.drpExamInfo.SelectedIndexChanged += new System.EventHandler(this.drpExamInfo_SelectedIndexChanged);
            // 
            // EasyChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(802, 524);
            this.Controls.Add(this.drpExamInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drpChartType);
            this.Controls.Add(this.drpMsi);
            this.Controls.Add(this.chart);
            this.Name = "EasyChart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试结果图表统计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FanG.Chartlet chart;
        private System.Windows.Forms.ComboBox drpMsi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpChartType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComboAdvanced drpExamInfo;
    }
}