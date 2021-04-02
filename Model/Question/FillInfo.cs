using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class FillInfo : ExamItemInfo
    {
        public FillInfo()
        {

        }
        
        private string analysis;

        public string Analysis
        {
            get { return analysis; }
            set { analysis = value; }
        }
    }
}
