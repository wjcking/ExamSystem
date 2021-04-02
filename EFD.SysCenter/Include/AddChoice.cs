using System.Windows.Forms;
using Model;
using System.Collections;
using System;

namespace EFD.SysCenter.Include
{
    public partial class AddChoice : ControlBase
    {
        private int breakType = 1;
        public AddChoice()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, System.EventArgs e)
        {
            Button b = sender as Button;
            switch (b.Name)
            {
                case "btnGenerate":
                    if (cbBreak.Checked)
                        txtChoices.OrganizeChoice();
                    int count = 0;
                    webChoice.DocumentText = txtChoices.GetTextChoicesHtml(cbMultiple.Checked, breakType, ref count);
                    StatusEventArgs sea = new StatusEventArgs();
                    sea.Title = count.ToString() + "行受影响";

                    OnStatus(sea);
                    break;
                case "btnOrganize":
                    txtChoices.OrganizeChoice();
                    break;
            }
        }

        public override ExamQuery ExamQuery
        {
            get
            {
                return base.ExamQuery;
            }
            set
            {

                base.ExamQuery = value;
            }
        }
        private void rbBreakType_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            switch (rb.Name)
            {
                case "rbBreakType0":
                    breakType = 0;
                    return;

                case "rbBreakType1":
                    breakType = 1;
                    return;

                case "rbBreakType2":
                    breakType = 2;
                    return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SelectionInfo[] list = txtChoices.GetTextChoices(cbMultiple.Checked, breakType);

            if (list.Length < 0)
                return;

            MainSubjectBoard msb = new MainSubjectBoard(ConstInfo.QuestionType.Selection);
            DialogResult dr = Decorator.ShowDialog(msb);

            if (dr != DialogResult.OK)
                return;

            foreach (SelectionInfo si in list)
            {
                si.MainSubjectID = msb.SelectedMainSubjectID;
                si.ExamInfoID = ExamQuery.ExamInfoID;
                Exam.Choice.Add(si);
            }
            StatusEventArgs sea = new StatusEventArgs();
            sea.Title = list.Length.ToString() + "行添加成功";
            sea.IsHighlighted = true;
            OnStatus(sea);
            txtChoices.Clear();
        }
    }
}
