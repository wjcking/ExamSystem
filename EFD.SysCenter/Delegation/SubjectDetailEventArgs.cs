using System;
using System.Collections.Generic;
using System.Text;

namespace EFD.SysCenter
{
    public delegate void SubjectDetailEventHandler(object sender, SubjectDetailEventArgs e);

    public class SubjectDetailEventArgs
    {
        public SubjectDetailEventArgs()
        {
        }
        private bool isReset = false;

        public bool IsReset
        {
            get { return isReset; }
            set { isReset = value; }
        }
        public bool IsFirst { get; set; }
        public Model.SubjectDetailInfo SubjectDetailInfo { get; set; }
    }
}
