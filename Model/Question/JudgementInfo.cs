using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class JudgementInfo : ExamItemInfo
    {
        
        public JudgementInfo()
        {


        }
        
        private string analysis;

        public string Analysis
        {
            get { return analysis; }
            set { analysis = value; }
        }

        public string KeyText {
            get { return base.Key.ToLower() == "true" ? "√" : "×"; }
        }
    }
}
