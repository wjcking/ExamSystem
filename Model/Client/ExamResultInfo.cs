using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ExamResultInfo
    {
        public ExamResultInfo()
        { 
        }
    

        private int _id;
        private int _examinfoid;
        private DateTime _pubdate;
        private string _name;
        private string _testway;
        private string _content = "";
        private bool _islimitedtime;
        private short _displaystyle;

        private string testedSubject = String.Empty;

        public string TestedSubject
        {
            get { return testedSubject; }
            set { testedSubject = value; }
        }
        private string testedScore = String.Empty;

        public string TestedScore
        {
            get { return testedScore; }
            set { testedScore = value; }
        }
        private string correctNum = String.Empty;

        public string CorrectNum
        {
            get { return correctNum; }
            set { correctNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ExamInfoID
        {
            set { _examinfoid = value; }
            get { return _examinfoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PubDate
        {
            set { _pubdate = value; }
            get { return _pubdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestWay
        {
            set { _testway = value; }
            get { return _testway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLimitedTime
        {
            set { _islimitedtime = value; }
            get { return _islimitedtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public short DisplayStyle
        {
            set { _displaystyle = value; }
            get { return _displaystyle; }
        }

        public string JsonPubDate {
            get { return _pubdate.ToString("yy-MM-dd H:m"); }
        }
    }
}
