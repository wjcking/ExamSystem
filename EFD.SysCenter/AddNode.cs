using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace EFD.SysCenter
{
    public partial class AddNode : Form
    {
        private ExamInfo examInfo = null;
        public AddNode(int examInfoID)
        {

            InitializeComponent();
            examInfo = Exam.ExamSys.GetModel(examInfoID);
            string material = examInfo.IsMaterial ? "[试卷]" : "[分类]";

            Text = material + examInfo.Name;
            if (examInfo.IsMaterial)
                btnOK.Enabled = false;

        }

        private void cbIsBatch_CheckedChanged(object sender, EventArgs e)
        {
            txtName.Multiline = cbIsBatch.Checked;

            if (txtName.Multiline)
            {
                txtName.Size = new Size(196, 58);
                txtName.ScrollBars = ScrollBars.Vertical;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!cbIsBatch.Checked)
            {
                ExamInfo ei = new ExamInfo();
                ei.CanRandom = cbRand.Checked;
                //如果是试卷的话则添加到这个试卷分类下，否则就添加到当前分类下
                ei.PID = examInfo.ID;
                ei.IsMaterial = (rbExam.Checked) ? true : false;
                ei.Name = txtName.Text;
                Exam.ExamSys.Add(ei);
            }
            else
            {
                if (txtName.Lines.Length < 0)
                    return;

                string[] names = txtName.Lines;
                foreach (string name in names)
                {
                    if (string.IsNullOrEmpty(name))
                        continue;

                    ExamInfo ei = new ExamInfo();
                    ei.CanRandom = cbRand.Checked;
                    //如果是试卷的话则添加到这个试卷分类下，否则就添加到当前分类下
                    ei.PID = examInfo.ID;
                    ei.IsMaterial = (rbExam.Checked) ? true : false;
                    ei.Name = name;
                    Exam.ExamSys.Add(ei);
                }

            }
        }
    }
}
