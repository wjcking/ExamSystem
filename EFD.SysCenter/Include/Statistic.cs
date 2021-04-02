using System.Windows.Forms;
using Model;
using System.Collections.Generic;
using System;

namespace EFD.SysCenter.Include
{
    public partial class Statistic : ControlBase
    {
        public Statistic()
        {
            InitializeComponent();
        }
        public override void Initialize()
        {
            List<StatisticInfo> slist = DataUtility.StatisticDAL.GetList(Exam.SelectedFilePath);

            List<ExamInfo> elist = Exam.ExamSys.GetListArray("");

            txtOutput.AppendText("试卷分类包括：");
            foreach (ExamInfo ei in elist)
            {
                if (ei.IsMaterial == false)
                {
                    txtOutput.AppendText(ei.Name);
                    txtOutput.AppendText(",");
                }
            }
                txtOutput.AppendText(Environment.NewLine);
            foreach (StatisticInfo si in slist)
            {
                txtOutput.AppendText(si.DisplayText);
                txtOutput.AppendText(" ");
            }

            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("试卷名称包括：");
            txtOutput.AppendText(Environment.NewLine);
            foreach (ExamInfo ei in elist)
            {
                if (ei.IsMaterial)
                {
                    txtOutput.AppendText(ei.Name);
                    txtOutput.AppendText(Environment.NewLine);
                }
            }

            base.Initialize();
        }
    }
}