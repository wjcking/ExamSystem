using System;
using System.Windows.Forms;
using ExamSys.Options;

namespace ExamSys
{
    [System.Runtime.InteropServices.GuidAttribute("2D37FCE0-4FA9-455A-806F-494317FDAFF4")]
    public partial class Settings : Form
    {
        public const string LastExamSubject = "LastExamSubject";

        public const string ExamItemLocationStyle = "ExamItemLocationStyle";
        public const string RecordResult = "RecordResult";
        public const string RecordUserAnswer = "RecordUserAnswer";
        public const string RecordIncorrect = "RecordIncorrect";
        public const string Google = "Google";
        public const string Baidu = "Baidu";
        public const string HomePage = "HomePage";
        public const string AddThreadUrl = "AddThreadUrl";
        public const string RegisterUrl = "RegisterUrl";

        public const string EditOutlineType = "EditOutlineType";

        public const int Option_Folder = 0;
        public const int Option_ResetExam = 1;
        public const int Option_Score = 2;
        public const int Option_Platform = 3;
        public const int Option_PlatformOutline = 4;
        public const int Option_Mist = 5;
        public const int Option_NetSet = 6;

        private static readonly FileFolder fileFolder = new FileFolder();
        private static readonly ResetExam resetExam = new ResetExam();
        private static readonly Score score = new Score();
        private static readonly PlatformStyle platformStyle = new PlatformStyle(PlatformStyle.SECTION_PLATFORM);
        private static readonly PlatformStyle platformMemo = new PlatformStyle(PlatformStyle.SECTION_MEMO);
        private static readonly PlatformStyle platformOutline = new PlatformStyle(PlatformStyle.SECTION_OUTLINE);
        public static readonly Misc Misc = new Misc();
        private static readonly NetSet netSet = new NetSet();
        public Settings()
        {
            InitializeComponent();
            SelectSection(0);
            Init();
        }

        public Settings(int section)
        {

            InitializeComponent();
            SelectSection(section);
            Init();
      
        }

        private void Init()
        {
            SysConfig.Decorater.FormCloseByKeyUp(this);
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK; 
        
        }

       
        private void SelectSection( int section)
        {
            panelControl.Controls.Clear();

            listOption.SelectedIndex =section;
            groupBox.Text = listOption.Text;
            switch (section)
            {
                case Option_Folder://文档库目录
                    
                    panelControl.Controls.Add(fileFolder);
                    return;
                case Option_ResetExam://重置试题项
                   
                    panelControl.Controls.Add(resetExam);
                    return;
                case Option_Score://试题分数 
                    score.Dock = DockStyle.Fill;
                    panelControl.Controls.Add(score);
                    return;
                case Option_Platform://考试平台样式 
                    
                    panelControl.Controls.Add(platformStyle);
                    return;
                //case 4://试题记忆平台样式
                //    panelControl.Controls.Add(platformMemo);
                //    return;
                case Option_PlatformOutline://大纲资料平台样式
                    panelControl.Controls.Add(platformOutline);
                    return;
              
                case 5: //杂项
                    panelControl.Controls.Add(Misc);
                    return;
                 case 6://
                    panelControl.Controls.Add(netSet);
                     return;
            }
        }
    
        
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (listOption.SelectedIndex)
            {
                case Option_Folder:
                    fileFolder.Save();
                    return;
                case Option_ResetExam:
                    resetExam.Save();
                    return;
                case Option_Score:
                    score.Save();
                    return;
                case Option_Platform:
                    platformStyle.Save();
                    return;
                //case Option_PlatformMemo:
                //    platformMemo.Save();
                //    return;
                case Option_PlatformOutline:
                    platformOutline.Save();
                    return;
                //case Option_PlatformMyFile:
                //    return;
                case Option_Mist:
                    Misc.Save();
                    return;
                case Option_NetSet:
                    netSet.Save();
                    return;
            }

        }

        private void listOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSection(listOption.SelectedIndex);
        }

   
     

    }
}
