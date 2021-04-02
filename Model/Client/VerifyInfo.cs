using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class VerifyInfo
    {
        public string ProductName { get; set; }
     
        public string CategoryID { get; set; }
        public string Version { get; set; }
        public string VoiceInfo { get; set; }
        public string PubTime { get; set; }
        public string MachineID { get; set; }

        public string SelectionCount { get; set; }
        public string JudgementCount { get; set; }
        public string FillCount { get; set; }
        public string QuestionCount { get; set; }
        public string ExamPaperCount { get; set; }
    }
}
