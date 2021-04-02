using System.Windows.Forms;
using ExamSys.Util;
using Model;
using System;
using System.Collections.Generic;
namespace ExamSys
{
    public partial class Regroup : Form
    {
        private ConstInfo.TestWay testWay = ConstInfo.TestWay.正式考试;
        private ConstInfo.DisplayStyle displayStyle = ConstInfo.DisplayStyle.列表;

        public Regroup()
        {
            InitializeComponent();
            categoryPicker.BindExamCategory();
            subjectNumberPicker.BindData();
            SysConfig.Decorater.FormCloseByKeyUp(this);

        }
        //注：选择题最多100个，填空题和判断题最多50个，问答题最多20个
        private void btnEnter_Click(object sender, System.EventArgs e)
        {
            lbStatus.Text = "";

            if (string.IsNullOrEmpty(categoryPicker.CategoryArray))
            {
                lbStatus.Text = "至少选择一个试题类型";
                return;
            }

            if (!Valid.IsRegistered)
            {
                Register.GetNewRegister();
                lbStatus.Text = "请注册正式版";
                return;
            }

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int rndNumber = rnd.Next();

            List<RegroupQuery> regroupQueryList = new List<RegroupQuery>();
            foreach (MainSubjectInfo msi in SysData.MainSubjectList)
            {
                int recordMax = subjectNumberPicker.GetSubjectNumber(msi.ID);
                
                if (recordMax <=0)
                    continue;

                RegroupQuery regroupQuery = new RegroupQuery();
                regroupQuery.RecordMax = recordMax;
                regroupQuery.RndNumber = rndNumber;
                regroupQuery.CategoryArray = categoryPicker.CategoryArray;
                regroupQuery.MainSubjectID = msi.ID;
                regroupQuery.QuestionType = (ConstInfo.QuestionType)msi.TopicTypeID;
                regroupQuery.TestWay = testWay;
                regroupQuery.DisplayStyle = displayStyle;
                regroupQuery = DataUtility.ExamSys.GetRegroupQuery(regroupQuery);

                if (regroupQuery != null)
                { 
                    regroupQuery.MainSubjectInfo = msi;
                    regroupQuery.MainSubjectInfo.SubjectSum = regroupQuery.RecordMax;
                    regroupQueryList.Add(regroupQuery);
                }

            }

            if (regroupQueryList.Count == 0)
            {
                lbStatus.Text = "目前试卷不存着试题，请重新选择组卷条件";
                return;
            }

            TemplateInfo template = new TemplateInfo();
            template.ExamInfoID = 0;
            template.TestWay = testWay;
            template.PlatformStyle = "customs";
            template.Title = String.Format("[{0}]模拟考试",testWay);
            template.TemplatPath = SysConfig.TemplatePath();
            template.LimitedTime = testWay == ConstInfo.TestWay.计时考试? Convert.ToInt32(numLimitedTIme.Value): 0;
            template.ExamQueryStyle = TemplateInfo.QueryStyle_Regroup;
            template.DisplayStyle = displayStyle;
            template.RegroupQueryList = regroupQueryList;
            lbStatus.Text = "正在进入试卷......";
            Platform.Activate(template);
            lbStatus.Text = "完毕";
        }

        private void rbTestWay_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            int tw = 1;

            switch (rb.Name)
            {
                case "rbTestWay2":
                    tw = 2;
                    break;
                case "rbTestWay3":
                    tw = 3;
                    break;
                case "rbTestWay5":
                    tw = 5;
                    break;
                case "rbTestWay6":
                    tw = 6;
                    break;
            }
            testWay = (ConstInfo.TestWay)tw;

            lbStatus.Text = testWay.ToString();
        }

        private void rbDisplayStyle_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbDisplayStyle0.Checked)
                displayStyle = ConstInfo.DisplayStyle.列表;
            else
                displayStyle = ConstInfo.DisplayStyle.逐个;

            lbStatus.Text = displayStyle.ToString();
        }
         
    }
}
