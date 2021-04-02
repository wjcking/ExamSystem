using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Model;
using ExamSys.Util;

namespace ExamSys
{
    public partial class SubjectNumberPicker : FlowLayoutPanel
    {
        private NumericUpDown[] numerics;

        public int GetSubjectNumber(int mainSubjectID)
        {
            if (numerics == null)
                return 0;

            foreach (NumericUpDown num in numerics)
            {
                if (num.Name == mainSubjectID.ToString())
                    return Convert.ToInt32(num.Value);
            }

            return 0;
        }
        public SubjectNumberPicker()
        {
            InitializeComponent();
        }

        public SubjectNumberPicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void BindData()
        {
            Controls.Clear();
          //  NumericUpDown
            Label[] labels = new Label[SysData.MainSubjectList.Count];
            numerics   = new NumericUpDown[SysData.MainSubjectList.Count];

            for (int i = 0; i < SysData.MainSubjectList.Count; i++)
            {
                labels[i] = new Label();
                labels[i].Size = new System.Drawing.Size(120, 25);
           

                labels[i].TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                labels[i].Text = SysData.MainSubjectList[i].Subject + "：";

                Controls.Add(labels[i]);

                numerics[i] = new NumericUpDown();
                numerics[i].Width = 45;
                numerics[i].TabIndex = i + 1;
                switch ((ConstInfo.QuestionType)SysData.MainSubjectList[i].TopicTypeID)
                {
                    case ConstInfo.QuestionType.Question:
                        numerics[i].Value = 0;
                        numerics[i].Maximum = 20;
                        break;

                    default:
                        numerics[i].Value = 10;
                        numerics[i].Maximum = 100;
                        break;
                }

                numerics[i].Name = SysData.MainSubjectList[i].ID.ToString(); 
                Controls.Add(numerics[i]);
            }
        }

    }
}
