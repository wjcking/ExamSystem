using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Model;
using ExamSys.Util;
using System.Drawing;
using System.Collections.Generic;
using Cts;

namespace ExamSys
{
    [ComVisibleAttribute(true)]
    public partial class MainCategory : Form
    {

        private readonly string Url_Start = Environment.CurrentDirectory + @"\template\Start.htm";
        private readonly string Url_Exam = Environment.CurrentDirectory + @"\template\Exam.htm";
        private readonly string Url_Remote = Environment.CurrentDirectory + @"\template\Remote.htm";

        //试用版本次数

        private static int trialCount = 8;
        private TreeView treeFileView = new TreeView();
        private TemplateInfo templateInfo;

        public MainCategory()
        {

            InitializeComponent();
            Init();
        }

        // 初始化
        private void Init()
        {

            if (SysData.ExamInfoListWithoutCategory.Count == 0)
            {
                MessageBox.Show("没有试卷内容", Valid.AccessRegisterInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }

            if (SysData.ExamInfoCategoryList.Count == 0)
            {
                MessageBox.Show("没有试卷大题", Valid.AccessRegisterInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
            Settings.Misc.SkinSelected += new Delegation.SkinChangedHandler(Misc_SkinSelected);
            //皮肤
            skinEngine.SkinFile = Options.Misc.Skin_Current;

            if (!Valid.IsRegistered)
                Register.GetNewRegister();
            else
            {
                menuRegister.Text = "已注册";
                menuRegister.Enabled = false;
            }
            webBrowser.ObjectForScripting = this;
            webBrowser.Navigate(Url_Start);


            //系统标题设置
            Text = "[易方得]" + SysData.ExamSysUtil.RegisterInfo.ProductName + (!Valid.IsRegistered ? "(试用版)" : string.Empty);

            btnStartPage.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\StartPage.png");
            btnExam.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\exam.png");
            btnMaterial.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\material.png");
            btnMyFile.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\myfile.png");
            btnEfdWeb.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\efdweb.png");

            btnSettings.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\settings.png");
            btnSearch.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\search.png");
            btnChart.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\chart.png");
            btnHistory.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\history.png");
            btnRegroup.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\regroup.png");

            btnSettings.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\settings.png");
            btnBackup.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\backup.png");
            btnRestore.Image = Image.FromFile(Environment.CurrentDirectory + "\\images\\restore.png");
        }

        private void Misc_SkinSelected(object sender, Delegation.SkinSelectedArgs e)
        {
            skinEngine.Active = e.SkinName == "" ? false : true;
            skinEngine.SkinFile = e.SkinFile;
        }

        /// <summary>
        /// 网页端声音
        /// </summary>
        /// <param name="param"></param>
        public void Play(string param)
        {
            WavePlayer.Play(param);
        }
        public void Run(string jsonTemplateInfo)
        {

            Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonTemplateInfo);

            templateInfo = new TemplateInfo();
            templateInfo.ExamInfoID = Convert.ToInt32(values["ExamInfoID"]);

            if (!Valid.IsRegistered)
            {
                bool flag = false;
                foreach (ExamInfo ei in SysData.ExamInfoListWithoutCategory)
                {
                    if (ei.ID == templateInfo.ExamInfoID)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    Register.GetNewRegister("您好没有注册，无权执行此试卷");
                    lbStatus.Text = "您好没有注册，无权执行此试卷";
                    return;
                }

                if (trialCount < 2)
                {
                    Register.GetNewRegister("请注册正式版");
                    lbStatus.Text = "请注册正式版";
                    return;
                }
                trialCount--;
                Register.GetNewRegister("您还是剩下 " + trialCount.ToString() + "次测试机会,请注册正式版");
            }

            templateInfo.Title = values["Title"].ToString();
            templateInfo.FileName = values["ExamInfoID"].ToString();
            templateInfo.TemplatPath = SysConfig.TemplatePath();
            templateInfo.IsShowSelection = Convert.ToBoolean(values["IsShowSelection"]);
            templateInfo.IsShowJudgement = Convert.ToBoolean(values["IsShowJudgement"]);
            templateInfo.IsShowFill = Convert.ToBoolean(values["IsShowFill"]);
            templateInfo.IsShowQuestion = Convert.ToBoolean(values["IsShowQuestion"]);

            int testway = Convert.ToInt32(values["TestWay"]);

            templateInfo.TestWay = (ConstInfo.TestWay)testway;

            if (templateInfo.TestWay == ConstInfo.TestWay.计时考试)
                templateInfo.LimitedTime = Convert.ToInt32(SysConfig.SettingsHelper.GetValue(SysConfig.Option_LimitedTime));
            else
                templateInfo.LimitedTime = 0;

            int displayStyleSelectedValue = Convert.ToInt32(values["DisplayStyle"]);
            templateInfo.DisplayStyle = (ConstInfo.DisplayStyle)displayStyleSelectedValue;
            templateInfo.PlatformStyle = values["PlatformStyle"].ToString();
            templateInfo.WindowSize = WindowState.ToString();

            StringBuilder statusNotice = new StringBuilder();

            statusNotice.Append(templateInfo.TestWay);
            statusNotice.Append("(");
            statusNotice.Append(templateInfo.IsShowSelection ? "选择题" : "");
            statusNotice.Append(templateInfo.IsShowJudgement ? " 判断题" : "");
            statusNotice.Append(templateInfo.IsShowFill ? " 填空题" : "");
            statusNotice.Append(templateInfo.IsShowQuestion ? " 简答或论述类型题" : "");
            statusNotice.Append(")");

            statusNotice.Append("  ");
            statusNotice.Append(templateInfo.DisplayStyle);
            statusNotice.Append("模式");
            lbStatus.Text = statusNotice.ToString();
            SysData.SubmitInfo = new SubmitInfo();
            SysData.SubmitInfo.TemplateInfo = templateInfo;
            SysData.SubmitInfo.StartTime = DateTime.Now;
            SysData.SubmitInfo.OSVersion = Network.ClientOS;
            SysData.SubmitInfo.IsOneApp = Network.MyProcess.Count == 1 ? true : false;
            Platform.Activate(templateInfo);

        }
        // 顶部导航操作    
        public void Navigate(string id)
        {
            WavePlayer.Play(WavePlayer.Play_Item);
            switch (id)
            {
                case "menuExam":
                case "btnExam":
                    webBrowser.Navigate(Url_Exam);
                    return;
                case "menuStartPage":
                case "btnStartPage":
                    webBrowser.Navigate(Url_Start);
                    return;
                case "btnClose":
                case "menuQuit":
                    Environment.Exit(0);
                    return;
                case "menuHelp":
                    System.Diagnostics.Process.Start("help.chm");
                    return;
                case "btnMaterial":
                case "menuMaterial":
                    EFDBrowser.Activate(PopulateNode.NodeListType.Outline);

                    return;
                case "btnMyFile":
                case "menuMyFile":
                    //   EFDBrowser.Activate(PopulateNode.NodeListType.MyFile); 
                    // EFDBrowser efdMyFile = new EFDBrowser((PopulateNode.NodeListType.MyFile));
                    EFDBrowser.ActivateMyFile();
                    return;
                case "btnRegInfo":
                case "menuRegisterInfo":
                    Copyright copyright = new Copyright();
                    copyright.ShowDialog();
                    return;
                case "btnSettings":
                case "menuSettings":
                    Settings settings = new Settings();
                    settings.ShowDialog();
                    return;
                case "btnHistory":
                case "menuHistory":
                    SysConfig.Decorater.Activate(typeof(History));
                    return;
                case "btnChart":
                case "menuChart":
                    SysConfig.Decorater.Activate(typeof(EasyChart));
                    return;
                case "btnSearch":
                case "menuSearch":
                    SysConfig.Decorater.Activate(typeof(SearchTask));
                    return;
                case "menuRegister":
                    Register.GetNewRegister();
                    return;
                case "menuBackup":
                case "btnBackup":
                    using (SaveFileDialog fd = new SaveFileDialog())
                    {

                        fd.RestoreDirectory = true;
                        fd.Filter = "备份库(*.ebk)|*.ebk";

                        if (fd.ShowDialog() == DialogResult.OK)
                        {
                            Rijndael encryptFile = new Rijndael(SysConfig.Encrypt_Key);
                            encryptFile.Encrypt("EasyFound.dll", fd.FileName);
                            MessageBox.Show("试题数据备份完毕！");
                        }
                    }
                    return;
                case "menuRestore":
                case "btnRestore":
                    using (OpenFileDialog fd = new OpenFileDialog())
                    {
                        fd.RestoreDirectory = true;
                        fd.Filter = "备份库(*.ebk)|*.ebk";
                        DialogResult dr = fd.ShowDialog();

                        if (dr != DialogResult.OK)
                            return;

                        if (MessageBox.Show("您确定要还原已备份的试题数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            try
                            {
                                Rijndael encryptFile = new Rijndael(SysConfig.Encrypt_Key);
                                encryptFile.Decrypt(fd.FileName, "EasyFound.dll");
                                MessageBox.Show("试题数据还原完毕，重新启动中");
                            }
                            catch
                            {
                                MessageBox.Show("试题库还原出现问题，重新启动中");
                            }

                            Application.Restart();
                        }
                    }
                    return;
                case "menuRegroup":
                case "btnRegroup":
                    SysConfig.Decorater.Activate(typeof(Regroup));
                    return;

                case "btnEfdWeb":
                case "menuEfdWeb":
                    BeginInvoke(new InvokeDelegate(InvokeMethod));

                    return;
                case "btnNetResult":
                    Network.GetRemoteExamResult(); 
                    return;
            }
        }

        private void MainCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cts.Encrypt.EncryptAccess("EasyFound.dll", true);
            GC.Collect();
            Environment.Exit(0);
        }

        private void MenuMain_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            Navigate(menu.Name);
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Navigate(e.ClickedItem.Name);
        }
        private delegate void InvokeDelegate();
        private void InvokeMethod()
        {
            try
            {
                Application.DoEvents();
                Network.GetNetInitialization();
                Network.GetRemoteExamResult(); 
                //System.Threading.Thread.Sleep(400);
            }
            catch (Exception exp1)
            {
                lbStatus.Text = "[网络初始化失败]" + exp1.Message + "，请重新连接";
            }
            finally
            {
                webBrowser.Navigate(Url_Remote);
            }
        }

        private void MainCategory_Shown(object sender, EventArgs e)
        {
          
        }
    }
}