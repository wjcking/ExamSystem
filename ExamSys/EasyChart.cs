using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataUtility;
using Model;
using ExamSys.Util;
using System.Text;

namespace ExamSys
{
    public partial class EasyChart : Form
    {
        private List<ExamResultInfo> examResultList;
        private ExamResult exResult = new ExamResult();

        private const string CHARTTYPE_BAR = "Bar";
        private const string CHARTTYPE_PIE = "Pie";
        private const string CHARTTYPE_LINE = "Line";

        private string command = string.Empty;

        private readonly Random random = new Random();



        public EasyChart()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {

            SizeChanged += delegate { chart.Refresh(); };
            SysConfig.Decorater.FormCloseByKeyUp(this);
            drpExamInfo.BindExamInfo(false);

            //注册限制
            if (!Valid.IsRegistered)
            {
                drpChartType.Enabled = false;
                drpMsi.Enabled = false;
            }

            drpMsi.Items.Clear();

            List<MainSubjectInfo> mainSubjectList = new List<MainSubjectInfo>();;
            MainSubjectInfo msi = new MainSubjectInfo();
            msi.Subject = SysConfig.Subject_TotalName;
            mainSubjectList.Add( msi);
            mainSubjectList.AddRange(SysData.MainSubjectList);

            drpMsi.DataSource = mainSubjectList;
            drpMsi.DisplayMember = "Subject";


            GetChartType(CHARTTYPE_LINE, CHARTTYPE_BAR);
            GenerateChartByCorrectCount();
        }

        private void GetChartType(string typeA, string typeB)
        {
            if (typeA == typeB)
                return;

            drpChartType.Items.Clear();

            foreach (string s in Enum.GetNames(typeof(FanG.Chartlet.AppearanceStyles)))
            {
                string chartType = s.Substring(0, s.IndexOf("_"));

                if (chartType == typeA)
                    drpChartType.Items.Add(s);

                if (chartType == typeB)
                    drpChartType.Items.Add(s);
            }

            drpChartType.SelectedIndex = random.Next(0, drpChartType.Items.Count - 1);
        }

        /// <summary>
        /// 试题正确率
        /// </summary>
        private void GenerateChartByCorrectCount()
        {

            MainSubjectInfo msi = drpMsi.SelectedValue as MainSubjectInfo;
            ExamInfo ei = (drpExamInfo.SelectedItem as ListItemExamInfo).ExamInfo;

            if (ei == null)
                return;

            if (msi == null)
                return;

            ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msi.Type;
            int subjectNumber = 0;
            if (drpMsi.SelectedIndex <= 0)
                subjectNumber = SysData.StatisticUtil.GetTotalCountByExamInfoID(ei.ID);

            else
                subjectNumber = Convert.ToInt32(SysData.AccessHelper.ExecuteScalar(string.Format("SELECT COUNT(*) FROM {0} WHERE MainSubjectID= {1} AND ExamInfoID={2}", qt, msi.ID, ei.ID)));

            DataTable dt = new DataTable();

            DataColumn cTestDate = new DataColumn("测试日期", typeof(string));
            DataColumn cCorrectNum = new DataColumn("正确个数", typeof(string));

            dt.Columns.Add(cTestDate);
            dt.Columns.Add(cCorrectNum);

            string mainSubjectTitle = string.Empty;

            StringBuilder sqlCondition = new StringBuilder();
            sqlCondition.AppendFormat(" ExamInfoID = {0} ", ei.ID);
            sqlCondition.AppendFormat("AND TestWay <> '{0}' ", ConstInfo.TestWay.我的收藏);
            sqlCondition.AppendFormat("AND TestWay <> '{0}' ", ConstInfo.TestWay.错题重做);
            sqlCondition.Append(" ORDER BY ID DESC ");

            examResultList = exResult.GetListArrayByCount(SysConfig.ExamResultCount, sqlCondition.ToString());

            for (int i = examResultList.Count - 1; i > -1; i--)
            {
                mainSubjectTitle = examResultList[i].Name;

                string[] ts = examResultList[i].TestedSubject.Split(',');
                string[] cn = examResultList[i].CorrectNum.Split(',');

                for (int j = 0; j < ts.Length; j++)
                {
                    if (ts[j] != msi.Subject)
                        continue;

                    DataRow row = dt.NewRow();
                    row["测试日期"] = examResultList[i].PubDate.ToString("M-d h:m");
                    row["正确个数"] = cn[j];
                    dt.Rows.Add(row);
                    dt.AcceptChanges();
                }
            }

            chart.YLabels.UnitText = "试题总数";

            chart.MaxValueY = subjectNumber;
            chart.BindChartData(dt);
            chart.Refresh();
        }


        private void drpChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart.AppearanceStyle = (FanG.Chartlet.AppearanceStyles)Enum.Parse(typeof(FanG.Chartlet.AppearanceStyles), drpChartType.SelectedItem.ToString());
            chart.Refresh();
        }

        private void drpMsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateChartByCorrectCount();

        }

        private void drpExamInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateChartByCorrectCount();
        }


    }
}
