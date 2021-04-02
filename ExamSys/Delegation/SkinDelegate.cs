using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSys.Delegation
{
    public delegate void SkinChangedHandler(object sender, SkinSelectedArgs e);

    public class SkinSelectedArgs : EventArgs //事件参数类
    {
        public string SkinName { get; set; }
        public string SkinFile { get; set; }      
    }
   
}
