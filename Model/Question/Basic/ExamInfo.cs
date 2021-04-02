using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ExamInfo : ExamSysInfo
    {
        private bool _ismaterial = false;
        private DateTime _pubdate;
        private bool _canrandom = true;
        private int _pid;        
        private int _id;
        private string keyword = "";

        public int CorrectCount
        { 
            get
            {
                try
                {
                    return TotalCount - (IncorrectCount + EmptyCount);
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int TotalCount { get; set; }
        public int IncorrectCount { get; set; }
        public int FavCount { get; set; }
        public int EmptyCount { get; set; }

        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        public ExamInfo()
        {

        }

        public ExamInfo(int id, int parentid, string name)
        {
            this.ID = id;
            this.PID = parentid;
            this.Name = name;
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
        public int PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
      

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private string name = string.Empty;
   
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int time = 120;

        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        private int score = 100;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private string content = "";

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string publishDate = string.Empty;

        public string PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }
        private string lastTestTime = string.Empty;

        public string LastTestTime
        {
            get { return lastTestTime; }
            set { lastTestTime = value; }
        }
        private int lastTestScore = 0;

        public int LastTestScore
        {
            get { return lastTestScore; }
            set { lastTestScore = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CanRandom
        {
            set { _canrandom = value; }
            get { return _canrandom; }
        }	/// <summary>
        /// 
        /// </summary>
        public bool IsMaterial
        {
            set { _ismaterial = value; }
            get { return _ismaterial; }
        }
        private int testTimes = 0;

        public int TestTimes
        {
            get { return testTimes; }
            set { testTimes = value; }
        }
      
    }
}
