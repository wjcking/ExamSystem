using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ExamSys
{
    public partial class TreeviewAdvanced : Component
    {
        public TreeviewAdvanced()
        {
            InitializeComponent();
        }

        public TreeviewAdvanced(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
