using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RegroupQuery
    {
        /// <summary>
        /// 问题类型
        /// </summary>
        public ConstInfo.QuestionType QuestionType { get; set; }
        public ConstInfo.TestWay TestWay     { get; set; }
        public ConstInfo.DisplayStyle DisplayStyle   { get; set; }
        /// <summary>
        /// 最大记录个数
        /// </summary>
        public int RecordMax { get; set; }

        public int RndNumber
        {
            get;
            set;
        }

        public int MainSubjectID { get; set; }
        /// <summary>
        /// 父类id列表
        /// </summary>
        public string CategoryArray { get; set; }

        public string SqlQuery { get; set; }

        public MainSubjectInfo MainSubjectInfo { get; set; }
    }
}
