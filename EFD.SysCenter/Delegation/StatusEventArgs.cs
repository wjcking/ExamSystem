using System;
using System.Collections.Generic;
using System.Text;

namespace EFD.SysCenter
{
    public delegate void StatusEventHandler(object sender, StatusEventArgs e);

    public class StatusEventArgs
    {
        public StatusEventArgs()
        {

        }
        public bool IsHighlighted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
}
