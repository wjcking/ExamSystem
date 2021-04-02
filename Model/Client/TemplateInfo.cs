using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TemplateInfo
    {

        public const string PlatformStyleCustoms = "customs";
        public const string PlatformStyleBlack = "black";//
        public const string PlatformStyleBlue = "blue";//
        public const string PlatformStyleHacker = "hacker";//
        public const string PlatformStyleWhite = "white";//

        public const int QueryStyle_Normal = 0;
        public const int QueryStyle_Search = 1;
        public const int QueryStyle_Regroup = 2;

        private ConstInfo.TestWay testWay = ConstInfo.TestWay.试题学习;
        private ConstInfo.DisplayStyle displayStyle = ConstInfo.DisplayStyle.列表;
        private string templatePath; 
        private string templateContent = "";
        private string fileName;    
        private string platformStyle = PlatformStyleCustoms;
        private int examInfoID = -1;
        private bool isShowSelection = true;
        private int limitedTime = -1;
        private string basePath;
        private string title = "";
        private string mainSubjectQuery = "";
        private string pagingQuery = "";
        private int recordCount  = 0;
        private int queryStyle = QueryStyle_Normal;
        private string windowSize;
        private List<HistoryInfo> examHistoryList = new List<HistoryInfo>();
        private string keyword = "";
        /// <summary>
        /// 模拟考试
        /// </summary>
        public List<RegroupQuery> RegroupQueryList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
        /// <summary>
        /// 组卷用，存放历史记录
        /// </summary>
        public List<HistoryInfo> ExamHistoryList
        {
            get { return examHistoryList; }
            set { examHistoryList = value; }
        }
        /// <summary>
        /// platform模板存放到只读静态变量
        /// </summary>
        public string TemplateContent
        {
            get { return templateContent; }
            set { templateContent = value; }
        }

       
        /// <summary>
        /// 考试方式
        /// </summary>
        public int ExamQueryStyle
        {
            get { return queryStyle; }
            set { queryStyle = value; }
        }

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }

     public string PagingQuery
        {
            get { return pagingQuery; }
            set { pagingQuery = value; }
        }
      public string MainSubjectQuery
        {
            get { return mainSubjectQuery; }
            set { mainSubjectQuery = value; }
        }

        public string WindowSize
        {
            get { return windowSize; }
            set { windowSize = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string BasePath
        {
            get { return basePath; }
            set { basePath = value; }
        }
        public int LimitedTime
        {
            get { return limitedTime; }
            set { limitedTime = value; }
        }

        public bool IsShowSelection
        {
            get { return isShowSelection; }
            set { isShowSelection = value; }
        }
        private bool isShowJudgement = true;

        public bool IsShowJudgement
        {
            get { return isShowJudgement; }
            set { isShowJudgement = value; }
        }
        private bool isShowFill = true;

        public bool IsShowFill
        {
            get { return isShowFill; }
            set { isShowFill = value; }
        }
        private bool isShowQuestion = true;

        public bool IsShowQuestion
        {
            get { return isShowQuestion; }
            set { isShowQuestion = value; }
        }

        public TemplateInfo()
        {
            templatePath = string.Empty;
            fileName = string.Empty;
            platformStyle = string.Empty;
            examInfoID = -1;
            testWay = ConstInfo.TestWay.试题学习;
            displayStyle = ConstInfo.DisplayStyle.列表;
        }

        public int ExamInfoID
        {
            get { return examInfoID; }
            set { examInfoID = value; }
        }

        public string PlatformStyle
        {
            get { return platformStyle; }
            set { platformStyle = value; }
        }
        public ConstInfo.DisplayStyle DisplayStyle
        {
            get { return displayStyle; }
            set { displayStyle = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string TemplatPath
        {
            get { return templatePath; }
            set { templatePath = value; }
        }

        public ConstInfo.TestWay TestWay
        {
            get { return testWay; }
            set { testWay = value; }
        }

        public HistoryInfo GetHistoryInfoByMainSubjectID(int mid)
        {
            //如果当前记录里面为1条，则直接返回
            if (examHistoryList.Count == 1)
                return examHistoryList[0];

            foreach (HistoryInfo hi in examHistoryList)
            {
                if (hi.MainSubjectID == mid)
                    return hi;
            }

            return new HistoryInfo();
        }

        public RegroupQuery GetRegroupQueryByMainSubjectID(int mid)
        {
            foreach (RegroupQuery rq in RegroupQueryList)
            {
                if (rq.MainSubjectID == mid)
                    return rq;
            }

            return null;
        }
        
    }
}
