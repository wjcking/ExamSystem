using System;
using System.Windows.Forms;
using ExamSys.Util;
using Model;
namespace ExamSys
{
    
   [System.Runtime.InteropServices.ComVisible(true)]
    public partial class EFDBrowser : Form
    {       private static readonly string templateCurrent = SysConfig.TemplateCurrentPath + "current.htm";
  
        private static EFDBrowser browserMyFile = null;
        private static PopulateNode populateNode;
        private EFDDocument.DocumentType documentType = EFDDocument.DocumentType.Direct;
        private string redirectPath;

        public EFDBrowser()
        {
            InitializeComponent();
            Init();
        }

        public void Print(string title, string content)
        {
            Text = "打印试卷 - " + title;
            splitContainer.Panel1Collapsed = true;
            splitContainer.Panel1.Enabled = false;
            menuView.Visible = false;
            menuTool.Visible = false;
            menuSettings.Visible = false;
            menuMaterial.Visible = false;
            menuMyFile.Visible = false;
            menuTreeview.Visible = false;
            menuSetMaterial.Visible = false;
         //   webBrowser.Navigate(templateCurrent);
            System.Text.StringBuilder printInfo = new System.Text.StringBuilder();
            printInfo.Append("<html>");
            printInfo.Append("<head>");

            printInfo.Append("</head>");
            printInfo.AppendFormat("<body style='font-family:{0},黑体; font-size:{1}'>", SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontFamily), SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontSize));

            printInfo.Append(title + "<br />");
            printInfo.Append("<br />");
            printInfo.Append(Cts.StrTool.StrToHtm(content));
            //   printInfo.Append( (content));

            printInfo.Append("<script type=\"text/javascript\">");
            printInfo.Append(SysConfig.JS_ForbiddenContextMenu + SysConfig.JS_ForbiddenSelectStart);
            printInfo.Append("</script>");
            printInfo.Append("</body>");
            printInfo.Append("</html>");

            webBrowser.DocumentText = printInfo.ToString();
            label1.Text = "快捷键 Ctrl + P 打印";

            webBrowser.DocumentCompleted += delegate
            {
                webBrowser.ShowPrintDialog();
            };
            ShowDialog();
        }
        public EFDBrowser(PopulateNode.NodeListType nodeListType)
        {
            InitializeComponent();
            Init();

            populateNode.DataBind(nodeListType);

        }
        public static void ActivateMyFile()
        {
            if (null == browserMyFile)
            {
                browserMyFile = new EFDBrowser(PopulateNode.NodeListType.MyFile);
                browserMyFile.Text = "我的文档库";
                browserMyFile.Show();
            }
            else
            {
                browserMyFile.Activate();
            }
        }
        public static void Activate(PopulateNode.NodeListType nodeListType)
        {
            SysConfig.Decorater.Activate(typeof(EFDBrowser));
            populateNode.DataBind(nodeListType);
            //  Text = populateNode.CurrentNodeType == PopulateNode.NodeListType.MyFile ? "文档库" : "大纲资料";

        }
        private void Init()
        {
            webBrowser.ObjectForScripting = this;
            populateNode = new PopulateNode(tvEFD);
            Load += delegate
            {
                if (populateNode.CurrentNodeType == PopulateNode.NodeListType.MyFile)
                    menuKeyword.Visible = false;
            };

        }

        /// <summary>
        /// html page 调用
        /// </summary>
        public void Setting()
        {
            Settings s = new Settings();
            s.ShowDialog();


            populateNode.DataBind(populateNode.CurrentNodeType);

        }
        public void MarkByKeyword()
        {
            if (populateNode.CurrentNodeType == PopulateNode.NodeListType.MyFile)
            {
                label1.Text = "请运行大纲资料来激活关键字";
                return;
            }

            if (tvEFD.SelectedNode == null)
                return;

            int examInfoID = Convert.ToInt32(tvEFD.SelectedNode.Name);
            if (examInfoID <= 0)
                return;

            try
            {
                KeywordInfo keywordInfo = new KeywordInfo();
                keywordInfo.Section = KeywordInfo.KeywordSection.Outline;
                keywordInfo.SectionID = Convert.ToInt32(examInfoID);

                Keyword keyword = new Keyword(keywordInfo);
                keyword.ShowDialog();


                webBrowser.Document.InvokeScript("highword", new object[] { keyword.KeywordInfo.Keyword.Replace("\r\n", ""), "Background" });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "搜索关键字", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void tvEFD_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!Valid.IsRegistered)
            {
                if (tvEFD.SelectedNode.Index % 2 == 0)
                {
                    webBrowser.DocumentText = "尊敬的用户，您尚未注册。不能执行该资料";
                    return;
                }
            }

            switch (populateNode.CurrentNodeType)
            {
                case PopulateNode.NodeListType.MyFile:
                    redirectPath = EFDDocument.Redirect(tvEFD.SelectedNode.Name, out documentType);
                    webBrowser.Navigate(redirectPath);
                    label1.Text = tvEFD.SelectedNode.Name;
                    return;

                case PopulateNode.NodeListType.Outline:
                    webBrowser.Navigate(Environment.CurrentDirectory + @"\template\Outline.htm");
                    label1.Text = tvEFD.SelectedNode.Text;
                    return;
            }


        }
        private void MenuMain_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            switch (menu.Name)
            {
                case "menuTreeview":
                    menuTreeview.Checked = menuTreeview.Checked ? false : true;
                    splitContainer.Panel1Collapsed = splitContainer.Panel1Collapsed ? false : true;
                    return;
                case "menuSettings":
                    Settings settings = new Settings();
                    settings.ShowDialog();
                    populateNode.DataBind(populateNode.CurrentNodeType);
                    return;
                case "menuQuit":
                    Close();
                    return;
                case "menuSetMaterial":
                    Settings setMaterial = new Settings(Settings.Option_PlatformOutline);
                    setMaterial.ShowDialog();
                    populateNode.DataBind(populateNode.CurrentNodeType);
                    //  webBrowser.Navigate(Environment.CurrentDirectory + @"\template\Outline.htm");
                    //  GetMaterial();
                    return;
                case "menuKeyword":
                    MarkByKeyword();
                    return;
                case "menuMaterial":
                    Activate(PopulateNode.NodeListType.Outline);
                    return;
                case "menuMyFile":
                    Activate(PopulateNode.NodeListType.MyFile);
                    return;
                case "menuPrint":
                    webBrowser.ShowPrintDialog();
                    return;
                case "menuPrintRreview":
                    webBrowser.ShowPrintPreviewDialog();
                    return;
                case "menuPageSet":
                    webBrowser.ShowPageSetupDialog();
                    return;
            }
        }
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            switch (populateNode.CurrentNodeType)
            {
                case PopulateNode.NodeListType.Outline:
                    GetMaterial();
                    return;

                case PopulateNode.NodeListType.MyFile:
                    if (documentType == EFDDocument.DocumentType.Media)
                    {
                        webBrowser.Document.InvokeScript("play", new object[] { tvEFD.SelectedNode.Name });
                    }
                    return;
            }
        }

        private void GetMaterial()
        {
            HtmlElement divContent = webBrowser.Document.GetElementById("divContent");
            HtmlElement efdTitle = webBrowser.Document.GetElementById("efdTitle");
            HtmlElement hidFamily = webBrowser.Document.GetElementById("hidFamily");

            int id = int.Parse(tvEFD.SelectedNode.Name);
            string fontFamily = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.OutlineFontFamily);
            hidFamily.SetAttribute("value", fontFamily);

            OutlineInfo oi = SysData.OutlineUtil.GetModel(id);

            efdTitle.InnerHtml = oi.Title;

            if (oi.Content == null)
                oi.Content = "";

            if (oi.ContentType == 0)
                divContent.InnerHtml = Cts.StrTool.StrToHtm(oi.Content);
            else
                divContent.InnerHtml = oi.Content;

        }

        private void EFDBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            browserMyFile = null;
        }
    }
}
