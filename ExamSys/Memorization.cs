using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Cts;
using DataUtility;
using Model;
using ExamSys.Util;

namespace ExamSys
{
    [ComVisibleAttribute(true)]
    public partial class Memorization : Form
    {

        private TemplateInfo temp;
        private static readonly ExamResult examResult = new ExamResult();
        private readonly string tempCssMemoPath = Application.StartupPath + @"\template\cssmemo\";
        private readonly string tempImagePath = Application.StartupPath + @"\template\images\";
        //读取模板到内存  解码试卷操作的js代码  
        private static readonly string TemplateContent = File.ReadAllText(SysConfig.TemplatePath() + @"images\Memo.gif", System.Text.Encoding.Default);
        public static bool IsDisplayedKey = false;
        //解码试卷操作的js代码字符

        public Memorization(TemplateInfo temp)
        {
            InitializeComponent();
            web.ObjectForScripting = this;
            temp.TemplateContent = TemplateContent;
            this.temp = temp;
            Text = temp.Title;
            BuildPaper(); 

         
        }

        private void BuildPaper()
        {
            string currentExam = EPReader.Read(temp).Replace("\r\n", "<br/>");
            //web.DocumentText = Cts.EPReader.Read(temp).Replace("\r\n","<br/>");
            //return;
            if (currentExam == string.Empty)
            {
                string noneString = File.ReadAllText(SysConfig.TemplatePath("webpanel") + "none.htm");

                StringBuilder bufferString = new StringBuilder();
                bufferString.AppendFormat("<p>您选择的考试试卷为：“{0}”  </p>", temp.Title);
                bufferString.AppendFormat("<p>您选择的测试类型为：“{0}”  </p>", temp.TestWay);
                bufferString.Append("对不起，该试卷下无试题");

                noneString = noneString.Replace("[#Title#]", bufferString.ToString());
                web.DocumentText = noneString;
                return;
            }

            //css地址
            currentExam = currentExam.Replace("[#temp.PlatformStyle#]", tempCssMemoPath + "memo.css");
            //图片地址 [#TempImagePath#]
            currentExam = currentExam.Replace("[#TempImagePath#]", tempImagePath);
            //关键字
            ExamInfo ei = SysData.ExamSysUtil.GetModel(temp.ExamInfoID);

            string foreColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoForeColor);
            string backColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.MemoBackColor);
            //string optionColor = Settings.helper.GetSettingsElement(Settings.PlatformOptionColor);

            //页面样式
            currentExam = currentExam.Replace("[#temp.custStyle#]", CssStyle.CustomerCssStyle(PopulateNode.NodeListType.Memo));
            currentExam = currentExam.Replace("[#temp.ForeColor#]", string.Format("rgb({0})", foreColor));
            currentExam = currentExam.Replace("[#temp.BackColor#]", string.Format("rgb({0})", backColor));
            //根据标签替换 Js脚本
            currentExam = currentExam.Replace("<%= temp.LimitedTime%>", "0");
            currentExam = currentExam.Replace("<%= temp.WindowState%>", temp.WindowSize);
            currentExam = currentExam.Replace("<%= TestWay %>", ((int)temp.TestWay).ToString());
            currentExam = currentExam.Replace("<%= scriptVariants %>", MemoBuilder.ScriptVariants);
            currentExam = currentExam.Replace("<%= DisplayStyle %>", ((int)temp.DisplayStyle).ToString());

            //查看HTML
            if (SysConfig.DebugHtmlCode == SysConfig.DEBUGE_CODE)
            {
                currentExam = currentExam.Replace("<%= disablePlatform %>", String.Empty);
            }
            else
            {

                //屏蔽用户操作
                currentExam = currentExam.Replace("<%= disablePlatform %>", SysConfig.JS_ForbiddenContextMenu + SysConfig.JS_ForbiddenSelectStart);
            }
            web.DocumentText = currentExam;
        }

   


        /// <summary>
        /// 执行脚本传过来的参数
        /// </summary>
        /// <param name="commend"></param>
        public void HandleFromScript(string commend)
        {
            commend = commend.ToLower();

            switch (commend)
            {
                case "rebuild":
                    Register.GetNewRegister();
                    BuildPaper();
                    return;

                case "keyword":
                    KeywordInfo ki = new KeywordInfo();
                    ki.SectionID = temp.ExamInfoID;
                    ki.Section = KeywordInfo.KeywordSection.ExamInfo;

                    Keyword keyword = new Keyword(ki);
                    keyword.ShowDialog();
                    if (keyword.DialogResult == DialogResult.OK)
                        web.Document.InvokeScript("highword", new object[] { keyword.KeywordInfo.Keyword.Replace("\r\n", ""), keyword.KeywordInfo.HighlightStyle });
                    return;

                case "remark":
                    try
                    {
                        KeywordInfo kiRemark = new KeywordInfo();
                        kiRemark.SectionID = temp.ExamInfoID;
                        kiRemark.Section = KeywordInfo.KeywordSection.ExamInfo;
                        ExamInfo ei = SysData.ExamSysUtil.GetModel(kiRemark.SectionID);
                        kiRemark.Keyword = ei.Keyword;
                        web.Document.InvokeScript("highword", new object[] { kiRemark.Keyword.Replace("\r\n", ""), "Background" });
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "搜索关键字", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    return;
                case "settings":
                    Register.GetNewRegister();
                    Settings set = new Settings(4);

                    if (set.ShowDialog() == DialogResult.OK)
                        BuildPaper();

                    break;
                default:
                    Close();
                    return;
            }
        }

        public void UpdateFav(int qt, string fav, string id)
        {
            SysData.ExamSysUtil.UpdateFav((ConstInfo.QuestionType)qt, fav, id);
        }


    }
}
