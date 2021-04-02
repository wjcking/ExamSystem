using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class StatisticInfo
    {
        public int ID { get; set; }
        public string Subject{get;set;}
        public int Total { get; set; }

        public string DisplayText
        {
            get { return String.Format("{0}总数 {1} ",   Subject, Total); }
        }

        public int this[string subject]
        {
            get
            {
                if (subject == Subject)
                    return Total;

                return -1;
            }
        }
    }
}
