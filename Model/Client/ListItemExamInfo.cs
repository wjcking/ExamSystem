using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ListItemExamInfo
    {
        private int id;
        private string text;
        private  int index = 0;

        public ListItemExamInfo()
        {
            
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Text
        {
            get { return   text; }
            set { text = value; }
        }

        public   int Index
        {
            get { return index; }
            set { index = value; }
        }
        private ExamInfo examInfo;

        public ExamInfo ExamInfo
        {
            get { return examInfo; }
            set { examInfo = value; }
        }
    }
}
