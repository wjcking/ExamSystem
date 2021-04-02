using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MainSubjectInfo : ExamSysInfo
    {
       

        private int _id; 
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private short _topictypeid;
        public short TopicTypeID
        {
            set { _topictypeid = value; }
            get { return _topictypeid; }
        }
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
     
     
        private float eachPoint = 0;

        public float EachPoint
        {
            get { return eachPoint; }
            set { eachPoint = value; }
        }

        //总分
        private float scoreSum;

        public float ScoreSum
        {
            get { return scoreSum; }
            set { scoreSum = value; }
        }
        //总个数
        
        private int subjectSum;
        /// <summary>
        /// 检索记录，模拟考试试题总数
        /// </summary>
        public int SubjectSum
        {
            get { return subjectSum; }
            set { subjectSum = value; }
        }

        private int count = 0;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public MainSubjectInfo()
        {
            
        }

        private string content = string.Empty;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string note = string.Empty;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        private string analysis = string.Empty;

        public string Analysis
        {
            get { return analysis; }
            set { analysis = value; }
        }

        private int type =0;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private int sort = 1;
        /// <summary>
        /// 大题显示排序 正序
        /// </summary>
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        public ConstInfo.QuestionType QuestionType
        {
            get {
                if ( TopicTypeID == 0)
                    return ConstInfo.QuestionType.MainSubject;

                return (ConstInfo.QuestionType)TopicTypeID;
            }
        }
    }
}
