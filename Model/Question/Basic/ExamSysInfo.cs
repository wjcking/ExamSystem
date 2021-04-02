using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ExamSysInfo
    {
        private int index = 0;
        private string currentID = DateTime.Now.ToString("yyyyMMddHHmmss");

        public string CurrentID
        {
            get { return currentID; }
            set { currentID = value; }
        }
       

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
