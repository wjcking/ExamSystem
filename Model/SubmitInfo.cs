

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SubmitInfo 
    {
        public TemplateInfo TemplateInfo { get; set; }
        public CustomerInfo CustomerInfo { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan DurationTimeSpan
        {
            get
            {
                TimeSpan ts1 = new TimeSpan(StartTime.Ticks);
                TimeSpan ts2 = new TimeSpan(EndTime.Ticks);
                return ts1.Subtract(ts2).Duration();

            }
        }     public string Duration
        {
            get
            {

                return DurationTimeSpan.Minutes.ToString() + ":" + DurationTimeSpan.Seconds.ToString();
            }
        }
        public string Remark { get; set; }
   
        public int TotalNumber { get; set; }
        public int CorrectNumber { get; set; }
        public bool IsOneApp { get; set; }
        public string OSVersion { get; set; }

         
    }
}
