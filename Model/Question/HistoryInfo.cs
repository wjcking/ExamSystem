using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class HistoryInfo
    {
        private int _id;
		private string _mainsubject;
		private string _examinfoname;
		private string _keyword;
		private string _searchtype;
		private string _recordcount;
		private string _pagenumber;
		private string _testway = "";
		private string _sqlrecordcount = "";
		private string _sqlsearch = "";
		private string _score = "";
        private string percent = "";

        public string Percent
        {
            get { return percent; }
            set { percent = value; }
        }
       
        private int mainSubjectID = 0;

        /// <summary>
        /// 当前检索记录试题总数，返回recordcount的整数形式，
        /// </summary>
        public int QuestionCount
        {
            get
            {
                return Convert.ToInt32(_recordcount);
            }
        }
        public int MainSubjectID
        {
            get { return mainSubjectID; }
            set { mainSubjectID = value; }
        }
        private int examInfoID = 0;

        public int ExamInfoID
        {
            get { return examInfoID; }
            set { examInfoID = value; }
        }
        private int testTimes = 0;

        public int TestTimes
        {
            get { return testTimes; }
            set { testTimes = value; }
        }


		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainSubject
		{
			set{ _mainsubject=value;}
			get{return _mainsubject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExamInfoName
		{
			set{ _examinfoname=value;}
			get{return _examinfoname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SearchType
		{
			set{ _searchtype=value;}
			get{return _searchtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordCount
		{
			set{ _recordcount=value;}
			get{return _recordcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PageNumber
		{
			set{ _pagenumber=value;}
			get{return _pagenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Testway
		{
			set{ _testway=value;}
			get{return _testway;}
		}
		/// <summary>
		/// 返回一条MainSubject表数据的sql
		/// </summary>
		public string SqlRecordCount
		{
			set{ _sqlrecordcount=value;}
			get{return _sqlrecordcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SqlSearch
		{
			set{ _sqlsearch=value;}
			get{return _sqlsearch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Score
		{
			set{ _score=value;}
			get{return _score;}
		}

        private DateTime pubdate = DateTime.Now;
        public DateTime PubDate { get {return pubdate;} set{pubdate = value;} }
    }
}
