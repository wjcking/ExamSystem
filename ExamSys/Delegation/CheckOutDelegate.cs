using System;
using Model;

namespace ExamSys.Delegation
{
    public delegate void LocateItemEventHandler(object sender, LocateItemEventArgs e);
    public delegate void RefreshEventHandler(object sender, EventArgs e);

    public class LocateItemEventArgs : EventArgs //事件参数类
    {
        private ExamItemInfo selectedItem;

        public ExamItemInfo SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }
    }

}
