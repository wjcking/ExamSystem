using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class QuestionInfo : ExamItemInfo
    {           
        public QuestionInfo()
        {
           
        }

        public override string Key
        {
            get
            {
                return base.Key;//.Replace("\r\n", ""); ;
            }
           
        }
    }
}
