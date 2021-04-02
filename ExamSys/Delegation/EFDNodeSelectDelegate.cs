using System;
using Model;

namespace ExamSys.Agency
{
    public delegate void EFDNodeSelectEventHandler(object sender, EFDNodeSelectedEventArgs e);
    
    public class EFDNodeSelectedEventArgs : EventArgs //事件参数类
    {
        private ExamInfo selectedExamInfo;

        public ExamInfo SelectedExamInfo
        {
            get { return selectedExamInfo; }
            set { selectedExamInfo = value; }
        }
    }

}
