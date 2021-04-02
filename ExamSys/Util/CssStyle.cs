using System.Text;
using System.Drawing;

namespace ExamSys.Util
{
    public static class CssStyle
    {

        /// <summary>
        /// 获得rgb颜色
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static Color GetRgbColor(string elementName)
        {
            try
            {
                string[] rgb = SysConfig.SettingsHelper.GetValue(elementName).Split(',');

                int r = int.Parse(rgb[0]);
                int g = int.Parse(rgb[1]);
                int b = int.Parse(rgb[2]);

                return Color.FromArgb(r, g, b);
            }
            catch
            {
                return Color.White;
            }
        }

        /// <summary>
        /// 根据文档类型设置css样式
        /// </summary>
        /// <param name="nt"></param>
        /// <returns></returns>
        public static string CustomerCssStyle(PopulateNode.NodeListType nt)
        {
            string currentFontFamily = "FontFamily";
            string currentForeColor = "ForeColor";
            string currentBackColor = "BackColor";
            string currentFontSize = "FontSize";
            string currentFontWeight = "FontWeight";

            if (nt == PopulateNode.NodeListType.ExamInfo)
            {
                currentFontFamily = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontFamily);
                currentForeColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformForeColor);
                currentBackColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformBackColor);
                currentFontSize = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontSize);
                currentFontWeight = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontWeight);
            }
            else if (nt == PopulateNode.NodeListType.Outline)
            {
                currentFontFamily = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.OutlineFontFamily);
                currentForeColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.OutlineForeColor);
                currentBackColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.OutlineBackColor);
                currentFontSize = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.OutlineFontSize);
                currentFontWeight = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.OutlineFontWeight);
            }
            else if (nt == PopulateNode.NodeListType.Memo)
            {
                currentFontFamily = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoFontFamily);
                currentForeColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoForeColor);
                currentBackColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoBackColor);
                currentFontSize = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoFontSize);
                currentFontWeight = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoFontWeight);
            }
            else if (nt == PopulateNode.NodeListType.MyFile)
            {
                //currentFontFamily = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle);
                //currentForeColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoForeColor);
                //currentBackColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoBackColor);
                //currentFontSize = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoFontSize);
                //currentFontWeight = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoFontWeight);
            }

            StringBuilder custStyle = new StringBuilder();

            custStyle.Append("body");
            custStyle.Append("   {");
            custStyle.AppendFormat(" font-size: {0}px;", currentFontSize);
            custStyle.AppendFormat(" font-weight:{0};", currentFontWeight);
            custStyle.AppendFormat(" font-family: {0}, 黑体;", currentFontFamily);
            custStyle.AppendFormat(" color:rgb({0});", currentForeColor);
            custStyle.AppendFormat(" background-color:rgb({0});", currentBackColor);

            if (nt == PopulateNode.NodeListType.ExamInfo || nt == PopulateNode.NodeListType.Memo)
            {

                custStyle.AppendFormat(" scrollbar-arrow-color:rgb({0});", currentBackColor);
                custStyle.AppendFormat("scrollbar-3d-light-color:rgb({0});", currentBackColor);
                custStyle.AppendFormat(" scrollbar-shadow-color:rgb({0});", currentBackColor);
                custStyle.AppendFormat(" scrollbar-dark-shadow-color:rgb({0});", currentBackColor);
                custStyle.AppendFormat(" scrollbar-face-color:rgb({0});", currentBackColor);
                custStyle.AppendFormat(" scrollbar-base-color:rgb({0});", currentBackColor);
                custStyle.AppendFormat("  scrollbar-highlight-color:rgb({0});", currentBackColor);
            }

            custStyle.Append("    } ");

            return custStyle.ToString();
        }       
    }
}
