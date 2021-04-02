using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ExamSys.Util;

namespace ExamSys.Options
{
    public partial class PlatformStyle : UserControl
    {
        private string currentFontFamily = "FontFamily";
        private string currentForeColor = "ForeColor";
        private string currentBackColor = "BackColor";
        private string currentFontSize = "FontSize";
        private string currentFontWeight = "FontWeight";

        public const string PlatformFontFamily = "PlatformFontFamily";
        public const string PlatformForeColor = "PlatformForeColor";
        public const string PlatformBackColor = "PlatformBackColor";
        public const string PlatformFontSize = "PlatformFontSize";
        public const string PlatformFontWeight = "PlatformFontWeight";
        public const string PlatformOptionColor = "PlatformOptionColor";

        public const string OutlineFontFamily = "OutlineFontFamily";
        public const string OutlineForeColor = "OutlineForeColor";
        public const string OutlineBackColor = "OutlineBackColor";
        public const string OutlineFontSize = "OutlineFontSize";
        public const string OutlineFontWeight = "OutlineFontWeight";
        public const string OutlineIndex = "OutlineIndex";


        public const string MemoFontFamily = "MemoFontFamily";
        public const string MemoForeColor = "MemoForeColor";
        public const string MemoBackColor = "MemoBackColor";
        public const string MemoFontSize = "MemoFontSize";
        public const string MemoFontWeight = "MemoFontWeight";
        public const string MemoHighlightStyle = "MemoHighlightStyle";

        public const string SECTION_PLATFORM = "Platform";
        public const string SECTION_MEMO = "Memo";
        public const string SECTION_OUTLINE = "Outline";

        private const string SelectedFontFamily = "FontFamily";
        private const string SelectedForeColor = "ForeColor";
        private const string SelectedBackColor = "BackColor";
        private const string SelectedFontSize = "FontSize";
        private const string SelectedFontWeight = "FontWeight";
        private const string SelectedOptionColor = "OptionColor";

        private string sectionName = SECTION_PLATFORM;

        private string foreColor = "0,0,0";
        private string backColor = "234,234,234";
        private string optionColor = "255,0,0";

        public string SectionName
        {
            get { return sectionName; }
            set { sectionName = value; }
        }
        public PlatformStyle(string sectionName)
        {
            InitializeComponent();
            this.sectionName = sectionName;
            System.Drawing.Text.InstalledFontCollection installedFonts = new System.Drawing.Text.InstalledFontCollection();

            foreach (FontFamily f in installedFonts.Families)
            {
                drpFonts.Items.Add(f.Name);
            }

            GetStyle();
        }

        /// <summary>
        /// 初始化面板样式
        /// </summary>
        private void GetStyle()
        {
            if (sectionName == SECTION_PLATFORM)
            {
                labelOption.Visible = true;
                lbOptionColor.Visible = true;
            }

            currentFontFamily = sectionName + SelectedFontFamily;
            currentForeColor = sectionName + SelectedForeColor;
            currentBackColor = sectionName + SelectedBackColor;
            currentFontSize = sectionName + SelectedFontSize;
            currentFontWeight = sectionName + SelectedFontWeight;

            drpFonts.SelectedText = SysConfig.SettingsHelper.GetValue(currentFontFamily);
            numFontPxiel.Value = Convert.ToDecimal(SysConfig.SettingsHelper.GetValue(currentFontSize));
            chkBold.Checked = (SysConfig.SettingsHelper.GetValue(currentFontWeight) == "bold") ? true : false;
            FontStyle fs = (SysConfig.SettingsHelper.GetValue(currentFontWeight) == "bold") ? FontStyle.Bold : FontStyle.Regular;
            lbDisplay.Font = new System.Drawing.Font(SysConfig.SettingsHelper.GetValue(currentFontFamily), Convert.ToSingle(numFontPxiel.Value), fs);

            lbColor.BackColor = CssStyle.GetRgbColor(currentForeColor);
            lbOptionColor.BackColor = CssStyle.GetRgbColor(PlatformOptionColor);
            lbBackColor.BackColor = CssStyle.GetRgbColor(currentBackColor);
            lbDisplay.BackColor = CssStyle.GetRgbColor(currentBackColor);
            lbDisplay.ForeColor = lbColor.BackColor;

            drpFonts.Text = SysConfig.SettingsHelper.GetValue(currentFontFamily);
        }

        /// <summary>
        /// 文字颜色
        /// </summary> 
        private void lbColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                foreColor = cd.Color.R.ToString() + "," + cd.Color.G.ToString() + "," + cd.Color.B.ToString();
                lbColor.BackColor = cd.Color;
                lbDisplay.ForeColor = lbColor.BackColor;
            }
        }
        /// <summary>
        /// 背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                backColor = cd.Color.R.ToString() + "," + cd.Color.G.ToString() + "," + cd.Color.B.ToString();
                lbBackColor.BackColor = cd.Color;
                lbDisplay.BackColor = lbBackColor.BackColor;
            }
        }
        //字体大小
        private void numFontPxiel_ValueChanged(object sender, EventArgs e)
        {


            FontStyle fs = chkBold.Checked ? FontStyle.Bold : FontStyle.Regular;
                
            lbDisplay.Font = new System.Drawing.Font(drpFonts.Text, Convert.ToSingle(numFontPxiel.Value), fs);
        }

        /// <summary>
        /// 字体
        /// </summary> 
        private void drpFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FontFamily font = drpFonts.SelectedItem as FontFamily;
                //drpFonts.Text
                if (string.IsNullOrEmpty(drpFonts.Text))
                    return;


                FontStyle fs = chkBold.Checked ? FontStyle.Bold : FontStyle.Regular;
                

                lbDisplay.Font = new System.Drawing.Font(drpFonts.Text, Convert.ToSingle(numFontPxiel.Value), fs);
            }
            catch// (Exception exp)
            {
                //     MessageBox.Show(exp.Message);
            }
        }

        /// <summary>
        /// 粗体
        /// </summary> 
        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {

            FontStyle fs = chkBold.Checked? FontStyle.Bold : FontStyle.Regular;

            lbDisplay.Font = new System.Drawing.Font(drpFonts.Text, Convert.ToSingle(numFontPxiel.Value), fs);
        }

        /// <summary>
        /// 选项色
        /// </summary> 
        private void lbOptionColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                optionColor = cd.Color.R.ToString() + "," + cd.Color.G.ToString() + "," + cd.Color.B.ToString();
                lbOptionColor.BackColor = cd.Color;
            }
        }


        public void Save()
        {
            //文字颜色
            SysConfig.SettingsHelper.SetValue(currentForeColor, foreColor);
            //背景色
            SysConfig.SettingsHelper.SetValue(currentBackColor, backColor);
            //选项色
            SysConfig.SettingsHelper.SetValue(PlatformOptionColor, optionColor);
            //粗体
            if (chkBold.Checked)
                SysConfig.SettingsHelper.SetValue(currentFontWeight, "bold");
            else
                SysConfig.SettingsHelper.SetValue(currentFontWeight, "normal");
            //字体
            SysConfig.SettingsHelper.SetValue(currentFontFamily, drpFonts.Text);
            //字体大小
            SysConfig.SettingsHelper.SetValue(currentFontSize, numFontPxiel.Value.ToString());

            //如果为考试平台则返回
            if (sectionName == SECTION_PLATFORM || sectionName == SECTION_MEMO)
                return;

            string outlineBody = CssStyle.CustomerCssStyle(PopulateNode.NodeListType.Outline);
            string myFileBody = CssStyle.CustomerCssStyle(PopulateNode.NodeListType.MyFile);

            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\template\\style\\Outline.css", outlineBody, Encoding.GetEncoding("GB2312"));
           // System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\template\\style\\MyFile.css", myFileBody, Encoding.GetEncoding("GB2312"));
        }




    }
}
