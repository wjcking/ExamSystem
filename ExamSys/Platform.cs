using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Cts;
using DataUtility;
using Model;
using ExamSys.Util;
using System.Media;
namespace ExamSys
{
    [ComVisibleAttribute(true)]
    public partial class Platform : Form
    {

        private TemplateInfo templateInfo;
        private static readonly ExamResult examResult = new ExamResult();
        private readonly string tempCssPath = Application.StartupPath + @"\template\css\";
        private readonly string tempImagePath = Application.StartupPath + @"\template\images\";

        private static readonly string templateCurrent = SysConfig.TemplateCurrentPath + "current.htm";
        private static readonly string TemplateContent = File.ReadAllText(SysConfig.TemplatePath() + @"images\pts.gif", System.Text.Encoding.Default);
        public static bool IsDisplayedKey = false;
        private static Platform platform = null;
        private CheckOut checkExam = null;
        //解码试卷操作的js代码字符

        public Platform(TemplateInfo templateInfo)
        {

            InitializeComponent();
            web.ObjectForScripting = this;

            if (SysConfig.DEBUGE_CODE == SysConfig.DebugHtmlCode)
                templateInfo.TemplateContent = File.ReadAllText(SysConfig.TemplatePath() + @"images\pts.gif", System.Text.Encoding.Default);
            else
                templateInfo.TemplateContent = TemplateContent;
            
            this.templateInfo = templateInfo;
            BuildPaper();

        }

        public static void Activate(TemplateInfo templateInfo)
        {
            if (platform == null)
            {
                platform = new Platform(templateInfo);
                platform.Show();
            }
            else
            {
                platform.WindowState = (platform.WindowState == FormWindowState.Minimized) ? FormWindowState.Normal : platform.WindowState;
                platform.Activate();
            }
        }

        /// <summary>
        /// 是否激活或显示窗体
        /// </summary>
        public static bool IsActivated
        {
            get { return platform == null ? false : true; }
        }

        private void BuildPaper()
        {
            //是否已经交卷
            SysConfig.IsHandedIn = false;
            //重置是否已经显示答案
            IsDisplayedKey = false;

            string currentExam = EPBuilder.Build(templateInfo);

            if (currentExam == string.Empty)
            {

                Text = "无试题";
                StringBuilder bufferString = new StringBuilder();
                bufferString.Append("<html>");
                bufferString.Append("<head>");
                bufferString.Append("<script type=\"text/javascript\">");
                bufferString.Append("setTimeout('window.external.HandleFromScript(0)',2000);");
                bufferString.Append(SysConfig.JS_ForbiddenContextMenu + SysConfig.JS_ForbiddenSelectStart);
                bufferString.Append("</script>");
                bufferString.Append("</head>");
                bufferString.Append("<body style='font-family:黑体; padding:10px 0 0 20px; background-color:rgb(234,234,234);'>");
                bufferString.AppendFormat("[<span style=\"color:red;\">{0}</span>]{1}", templateInfo.TestWay, templateInfo.Title);
                //bufferString.AppendFormat("您选择的考试试卷为：“{0}”<br/>", templateInfo.Title);
                //bufferString.AppendFormat("测试类型为：“{0}”<br/>", templateInfo.TestWay);
                bufferString.Append(" <br/>");
                bufferString.Append(" <br/>");
                bufferString.Append("该试卷下无试题,请重设考试类型,2秒钟后自动关闭<br/>");
                bufferString.Append("</body>");
                bufferString.Append("</html>");

                Width = 500;
                Height = 160;
                MaximizeBox = false;
                MinimizeBox = false;
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                web.DocumentText = bufferString.ToString();
                return;

            }

            Text = "试卷编号：" + templateInfo.ExamInfoID.ToString();
           
            //css地址
            currentExam = currentExam.Replace("[#temp.PlatformStyle#]", tempCssPath + templateInfo.PlatformStyle + ".css");

            //图片地址 [#TempImagePath#]
            currentExam = currentExam.Replace("[#TempPath#]", SysConfig.TemplatePath());
            currentExam = currentExam.Replace("[#TempImagePath#]", tempImagePath);

            string foreColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformForeColor);
            string backColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformBackColor);
            string optionColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformOptionColor);

            currentExam = currentExam.Replace("[#temp.custStyle#]", CssStyle.CustomerCssStyle(PopulateNode.NodeListType.ExamInfo));

            currentExam = currentExam.Replace("[#temp.ForeColor#]", string.Format("rgb({0})", foreColor));
            currentExam = currentExam.Replace("[#temp.BackColor#]", string.Format("rgb({0})", backColor));
            string rightOptionClass = ".rightOptions   { color: rgb(" + optionColor + ");  }";
            currentExam = currentExam.Replace("/*[#temp.OptionColor#]*/", rightOptionClass);

            //根据标签替换
            currentExam = currentExam.Replace("<%= temp.LimitedTime %>", templateInfo.LimitedTime.ToString());
            currentExam = currentExam.Replace("<%= TestWay %>", ((int)templateInfo.TestWay).ToString());
            currentExam = currentExam.Replace("<%= scriptVariants %>", EPBuilder.ScriptVariants);
            currentExam = currentExam.Replace("<%= DisplayStyle %>", ((int)templateInfo.DisplayStyle).ToString());

            //查看HTML
            if (SysConfig.DebugHtmlCode == SysConfig.DEBUGE_CODE)
            {
                currentExam = currentExam.Replace("<%= disablePlatform %>", String.Empty);
            }
            else
            { //屏蔽用户操作
                currentExam = currentExam.Replace("<%= disablePlatform %>", SysConfig.JS_ForbiddenContextMenu + SysConfig.JS_ForbiddenSelectStart);
            }

            if (!Directory.Exists(SysConfig.TemplateCurrentPath))
                Directory.CreateDirectory(SysConfig.TemplateCurrentPath);

            File.WriteAllText(templateCurrent, currentExam, Encoding.Default);
            web.Navigate(templateCurrent);

        }


        /// <summary>
        /// 执行脚本传过来的参数
        /// </summary>
        /// <param name="command"></param>
        public void HandleFromScript(string command)
        {
            Play(WavePlayer.Play_Item);
            command = command.ToLower();

            Register.GetNewRegister();
            switch (command)
            {
                case "handin":
                    HandinExam();
                    break;
                case "displaykey":
                    GetExamUserAnswer(true, true);
                    break;

                case "checkout":
                    CheckOut();
                    break;

                case "examagain":
                    if (MessageBox.Show("您确定要重新考试吗，这将会清除您当前的作答？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        templateInfo.WindowSize = this.WindowState.ToString();
                        BuildPaper();
                    }
                    break;
                case "settings":
                    Settings set = new Settings(Settings.Option_Platform);
                    if (set.ShowDialog() == DialogResult.OK)
                    {
                        string fontFamily = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontFamily);
                        string fontSize = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontSize);
                        string fontWeight = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontWeight);
                        //string foreColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformForeColor);
                        //string backColor = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformBackColor);


                        web.Document.InvokeScript("changeStyle", new object[] { fontFamily, fontSize, fontWeight, ColorParser.PlatformHexForeColor, ColorParser.PlatformHexBackColor });
                    }
                    break;
                case "keyword":
                    try
                    {
                        KeywordInfo ki = new KeywordInfo();
                        ki.SectionID = templateInfo.ExamInfoID;
                        ki.Section = KeywordInfo.KeywordSection.ExamInfo;

                        Keyword keyword = new Keyword(ki);
                        keyword.ShowDialog();
                        if (keyword.DialogResult == DialogResult.OK)
                            web.Document.InvokeScript("highword", new object[] { keyword.KeywordInfo.Keyword.Replace("\r\n", ""), keyword.KeywordInfo.HighlightStyle });
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "搜索关键字", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    return;
                case "print":
                    EFDBrowser browser = new EFDBrowser();

                    browser.Print(templateInfo.Title, web.Document.GetElementById("examArea").InnerText);
                    return;
                default:
                    Close();
                    break;
            }
        }
        /// <summary>
        /// 网页端声音
        /// </summary>
        /// <param name="param"></param>
        public void Play(string param)
        {
            WavePlayer.Play(param);
        }
        /// <summary>
        /// 交卷，记录作答结果，错误次数
        /// </summary>
        private void HandinExam()
        {
            GetExamUserAnswer(false, false);

            HandIn handin = new HandIn();
            handin.TemplateInfo = templateInfo;
            DialogResult dr = handin.ShowDialog();

            if (dr == DialogResult.Cancel)
                Close();
            else if (dr == DialogResult.Retry)
                BuildPaper();
            else if (dr == DialogResult.OK)
            {
                GetExamUserAnswer(true, true);
            }
        }

        /// <summary>
        /// 检查试题
        /// </summary>
        private void CheckOut()
        {
            GetExamUserAnswer(false, false);

            if (checkExam == null)
            {
                checkExam = new CheckOut(templateInfo);
                checkExam.LocateItemClick += new Delegation.LocateItemEventHandler(check_LocateItemClick);
                checkExam.RefreshClick += new Delegation.RefreshEventHandler(checkExam_RefreshClick);
                checkExam.FormClosing += delegate
                {
                    if (SysConfig.IsHandedIn)
                        GetExamUserAnswer(true, true);

                    checkExam = null;
                };
                checkExam.Show();
            }
            else
            {
                checkExam.CheckingOut();
                checkExam.Activate();
            }

        }

        private void checkExam_RefreshClick(object sender, EventArgs e)
        {
            GetExamUserAnswer(false, false);
        }

        /// <summary>
        /// 显示用户作答，显示正确答案
        /// </summary>
        /// <param name="displayKey">是否显示答案</param>
        /// <param name="markChoice">是否高亮正确选择题选项</param>
        private void GetExamUserAnswer(bool displayKey, bool markChoice)
        {
            //如果选择的使显示答案 并且 已经显示了 则退出
            if (displayKey && IsDisplayedKey)
                return;

            for (int i = 0; i < EPBuilder.CurrentExamItemList.Count; i++)
            {
                ExamItemInfo ei = EPBuilder.CurrentExamItemList[i];

                string seed = ei.MainSubject + ei.ID.ToString();
                string userAnswer = "userAnswerID" + ei.MainSubject + ei.ID.ToString();
                string mark = "Mark" + ei.MainSubject + ei.ID.ToString();
                string divKey = "divKey" + ei.MainSubject + ei.ID.ToString();
                string subject = "subject" + ei.MainSubject + ei.ID.ToString();
                string isMark = web.Document.GetElementById(mark).GetAttribute("checked");

                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)ei.CurrentMainSubject.Type;

                ei.Mark = isMark.ToLower() == "true" ? true : false;

                if (qt == ConstInfo.QuestionType.Selection || qt == ConstInfo.QuestionType.Judgement)
                    ei.UserAnswer = web.Document.GetElementById(userAnswer).InnerText;
                else
                    ei.UserAnswer = web.Document.GetElementById(userAnswer).GetAttribute("Value");

                if (!displayKey)
                    continue;
                //如果是全部显示答案，则先关闭声音, flag = 记录配置文件里面
             
                //显示答案 (只要没显示）
                //第二个参数如果有值，则不发声
                web.Document.InvokeScript("getKey", new object[] { seed, false });

                //标记错误主题
                if (!EPBuilder.CurrentExamItemList[i].IsCorrect)
                    web.Document.GetElementById(subject).SetAttribute("className", "wrongSubject");

                //只要不是选择类型题，就跳出出这次循环
                if (qt != ConstInfo.QuestionType.Selection)
                    continue;

                //如果答案还未显示并且选择要标记选项
                if (!markChoice)
                    continue;

                HtmlElementCollection choiceCollection = web.Document.GetElementsByTagName("input");
                string choiceKey = ei.Key.Trim().ToUpper();
                SelectionInfo si = ei as SelectionInfo;

                GetChoiceKey(si.Multiple, ei.MainSubject, si.ID.ToString(), choiceKey);
            }
            //已经显示了答案
            if (displayKey)
                IsDisplayedKey = true;
        }
        /// <summary>
        /// 获得选择题答案并高亮(系统以及html页面同时使用)
        /// </summary>
        /// <param name="isMultiple"></param>
        /// <param name="mid"></param>
        /// <param name="id"></param>
        /// <param name="choiceKey"></param>
        public void GetChoiceKey(bool isMultiple, string mid, string id, string choiceKey)
        {
            if (!isMultiple)
            {
                HtmlElement label = web.Document.GetElementById("Label_Choice_" + mid + "_" + id.ToString() + "_" + choiceKey);

                if (label != null)
                    label.SetAttribute("className", "rightOptions");
            }
            else
            {
                for (int m = 0; m < choiceKey.Length; m++)
                {
                    string currentLetter = choiceKey.Substring(m, 1);
                    HtmlElement label = web.Document.GetElementById("Label_Multi_" + mid + "_" + id.ToString() + "_" + currentLetter);

                    if (label != null)
                        label.SetAttribute("className", "rightOptions");
                }
            }
        }

        private void check_LocateItemClick(object sender, Delegation.LocateItemEventArgs e)
        {
            ExamItemInfo examItem = e.SelectedItem;

            if (templateInfo.DisplayStyle == ConstInfo.DisplayStyle.列表)
                web.Document.InvokeScript("LocateSubjectPanelByAnchor", new object[] { examItem.MainSubject, "#an" + examItem.MainSubject + examItem.ID });
            else
                web.Document.InvokeScript("LocateSubjectPanelByDiv", new object[] { examItem.MainSubject, "subjectPanel" + examItem.MainSubject + examItem.ID });
        }

        /// <summary>
        /// 加入收藏夹
        /// </summary>
        /// <param name="qt">试题类型</param>
        /// <param name="fav"></param>
        /// <param name="id">试题编号</param>
        public void UpdateFav(int qt, string fav, string id)
        {
            WavePlayer.Play(WavePlayer.Play_Fav);
            SysData.ExamSysUtil.UpdateFav((ConstInfo.QuestionType)qt, fav, id);
            //记录收藏个数
            int total = SysData.StatisticUtil.GetFavCountByExamInfoID(templateInfo.ExamInfoID);
            SysData.AccessHelper.ExecuteNonQuery(String.Format("UPDATE ExamInfo Set FavCount = {0} WHERE ID = {1}", total, templateInfo.ExamInfoID));

        }

        private void Platform_FormClosing(object sender, FormClosingEventArgs e)
        {

            File.WriteAllText(templateCurrent,String.Empty);
            SysData.GenerateJson();

            platform = null;

            if (checkExam != null)
                checkExam.Close();
        }

    }
}
