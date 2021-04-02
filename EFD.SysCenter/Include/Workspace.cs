using System.Collections;
using System.Windows.Forms;
using Crownwood.Magic.Docking;
using EFD.SysCenter.Include;
using Model;
using System;

namespace EFD.SysCenter.Include
{

    public partial class Workspace : ControlBase
    {

        private DockingManager dockManager;
        private readonly TabControl tabWorkspace = new TabControl();

        public readonly ControlBase ucMainSubject = new MainSubject();
        public readonly ControlBase ucAddChoice = new AddChoice();
        public readonly ControlBase ucModifyChoice = new ModifyChoice();
        public readonly ControlBase ucFillBlank = new FillBlank();
        public readonly ControlBase ucJudgement = new Judgement();
        public readonly ControlBase ucQuestion = new Question();
        public readonly ControlBase ucExport = new Export();
        public readonly ControlBase ucStatistic = new Statistic();
        public readonly ControlBase ucMedia = new Media();
        //试题列表 
        private readonly SysTreeNode sysTreeNode = new SysTreeNode();
        private readonly Hashtable controlList = new Hashtable();

        private TabPage tpMainSubject = new TabPage();
        private TabPage tpChoice = new TabPage();
        private TabPage tpModifyChoice = new TabPage();

        private TabPage tpFill = new TabPage();
        private TabPage tpJudge = new TabPage();
        private TabPage tpQuestion = new TabPage();
        private TabPage tpMedia = new TabPage();

        private TabPage tpExport = new TabPage();
        private TabPage tpStatistic = new TabPage();
        public Workspace()
        {
            InitializeComponent();
            Initialize();
        }


        // 初始化工作区
        public override void Initialize()
        {

            ucAddChoice.Dock = DockStyle.Fill;
            ucMainSubject.Dock = DockStyle.Fill;
            ucFillBlank.Dock = DockStyle.Fill;
            ucJudgement.Dock = DockStyle.Fill;
            ucQuestion.Dock = DockStyle.Fill;
            ucExport.Dock = DockStyle.Fill;
            ucModifyChoice.Dock = DockStyle.Fill;
            tabWorkspace.Dock = DockStyle.Fill;
            ucMedia.Dock = DockStyle.Fill;


            tpMainSubject.Text = "试卷大题";
            tpMainSubject.Controls.Add(ucMainSubject);

            tpChoice.Text = "添加选择题";
            tpChoice.Controls.Add(ucAddChoice);

            tpModifyChoice.Text = "修改选择题";
            tpModifyChoice.Controls.Add(ucModifyChoice);

            tpFill.Text = "填空题";
            tpFill.Controls.Add(ucFillBlank);

            tpJudge.Text = "判断题";
            tpJudge.Controls.Add(ucJudgement);

            tpQuestion.Text = "问答题";
            tpQuestion.Controls.Add(ucQuestion);

            tpMedia.Name = "tpMedia";
            tpMedia.Text = "多媒体";
            tpMedia.Controls.Add(ucMedia);

            tpExport.Text = "导出试题项";
            tpExport.Controls.Add(ucExport);

            tpStatistic.Text = "统计";
            tpStatistic.Controls.Add(ucStatistic);

            tpMainSubject.Name = "tpMainSubject";
            tpChoice.Name = "tpChoice";
            tpModifyChoice.Name = "tpModifyChoice";
            tpFill.Name = "tpFill";
            tpJudge.Name = "tpJudge";
            tpQuestion.Name = "tpQuestion";
            tpExport.Name = "tpExport";
            tpStatistic.Name = "tpStatistic";
            tpMedia.Name = "tpMedia";

            controlList.Add("tpMainSubject", ucMainSubject);
            controlList.Add("tpChoice", ucAddChoice);
            controlList.Add("tpModifyChoice", ucModifyChoice);
            controlList.Add("tpJudge", ucJudgement);
            controlList.Add("tpFill", ucFillBlank);
            controlList.Add("tpQuestion", ucQuestion);
            controlList.Add("tpMedia", ucMedia);
            controlList.Add("tpExport", ucExport);
            controlList.Add("tpStatistic", ucStatistic);


            tabWorkspace.TabPages.Add(tpMainSubject);
            tabWorkspace.TabPages.Add(tpChoice);
            tabWorkspace.TabPages.Add(tpModifyChoice);
            tabWorkspace.TabPages.Add(tpFill);
            tabWorkspace.TabPages.Add(tpJudge);
            tabWorkspace.TabPages.Add(tpQuestion);
            tabWorkspace.TabPages.Add(tpMedia);
            tabWorkspace.TabPages.Add(tpExport);
            tabWorkspace.TabPages.Add(tpStatistic);


            tabWorkspace.Selected += new TabControlEventHandler(tabWorkspace_Selected);

            Controls.Add(tabWorkspace);

            dockManager = new DockingManager(this, Crownwood.Magic.Common.VisualStyle.Plain);
            dockManager.OuterControl = this;
            dockManager.InnerControl = tabWorkspace;


            //初始化试卷
            sysTreeNode.BindExamInfoList();


            sysTreeNode.AfterSelect += new TreeViewEventHandler(sysTreeNode_AfterSelect);
            Content c = new Content(dockManager);
            c.DisplaySize = new System.Drawing.Size(250, sysTreeNode.Size.Height);
            c.FloatingSize = new System.Drawing.Size(250, Size.Height);
            c.Title = Exam.SelectedFileName;
            c.FullTitle = Exam.SelectedFileName;
            c.Control = sysTreeNode;
            dockManager.Contents.Add(c);

            WindowContent wc = dockManager.AddContentWithState(c, State.DockLeft);
            dockManager.AddContentToWindowContent(c, wc);

            tabWorkspace.SelectedIndex = 0;
            BindDataByTabName();

        }

        private void sysTreeNode_AfterSelect(object sender, TreeViewEventArgs e)
        {   //事件，主窗体调用 
            statusEventArgs.Title = e.Node.Text;
            OnStatus(base.statusEventArgs);

            BindDataByTabName();
        }


        public void BindDataByTabName()
        {

            //if (sysTreeNode.SelectedNode == null)
            //    return;

            //bool isMaterial = Convert.ToBoolean(sysTreeNode.SelectedNode.Tag);

            ////  tabWorkspace.TabPages.Clear();

            //foreach (TabPage tp in tabWorkspace.TabPages)
            //    tp.Hide();
            //if (isMaterial)
            //{

            //    tpMainSubject.Show();
            //    tpChoice.Show();
            //    tpModifyChoice.Show();
            //    tpJudge.Show();
            //    tpFill.Show();
            //    tpQuestion.Show();
            //    tpMedia.Show();     tpExport.Show();
            //    tpStatistic.Show();
            //}
            //else
            //{
            //    tpExport.Show();
            //    tpStatistic.Show();
            //}

            ControlBase controlBase = controlList[tabWorkspace.SelectedTab.Name] as ControlBase;

            if (!controlBase.IsInitialized)
                controlBase.Initialize();

            ExamQuery eq = new ExamQuery();
            eq.ExamInfoID = sysTreeNode.SelectedNodeID;


            switch (tabWorkspace.SelectedTab.Name)
            {
                case "tpMainSubject":
                    break;
                case "tpChoice":
                    eq.QuestionType = ConstInfo.QuestionType.Selection;
                    controlBase.ExamQuery = eq;
                    break;
                case "tpModifyChoice":
                    eq.QuestionType = ConstInfo.QuestionType.Selection;
                    controlBase.ExamQuery = eq;
                    break;
                case "tpFill":
                    eq.QuestionType = ConstInfo.QuestionType.Fill;
                    controlBase.ExamQuery = eq;
                    break;
                case "tpJudge":
                    eq.QuestionType = ConstInfo.QuestionType.Judgement;
                    controlBase.ExamQuery = eq;
                    break;
                case "tpQuestion":
                    eq.QuestionType = ConstInfo.QuestionType.Question;
                    controlBase.ExamQuery = eq;
                    break;
                case "tpMedia":
                    controlBase.ExamQuery = eq;
                    break;
                case "tpExport":
                    break;
                case "tpStatistic":
                    break;
            }

        }

        private void tabWorkspace_Selected(object sender, TabControlEventArgs e)
        {
            BindDataByTabName();

        }

    }
}
