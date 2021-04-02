using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OutlineInfo
    {
        public OutlineInfo()
        { 
        }
  
        private int _id;
        private int _pid;
        private DateTime _pubdate;
        private string _title;
        private string _content;
        private int contentType;
        private string keyword = "";

        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
        /// <summary>
        /// 0=txt,1 = htm , 2 =rtf;doc
        /// </summary>
        public int  ContentType
        {
            get { return contentType; }
            set { contentType = value; }
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
        public int PID
        {
            set { _pid = value; }
            get { return _pid; }
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        private int type = 0;

        /// <summary>
        /// 0 = sys 1= user 
        /// </summary>
        public int Type { 
            get {return type;}
            set { type=value;}
        }
    }
}
