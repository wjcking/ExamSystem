using Model;
using System.Windows.Forms;
using System;

namespace EFD.SysCenter.Include
{
    public partial class Question : ControlBase
    {
        public Question()
        {
            InitializeComponent();
            drpMainSubject.BindMainSubject(ConstInfo.QuestionType.Question);
        }


        public override void ButtonClick(object sender, System.EventArgs e)
        {
            if (ExamQuery == null)
                return;

            Button b = sender as Button;

            switch (b.Name)
            {
                case "btnAddSubject":
                    MainSubjectBoard msb = new MainSubjectBoard(ConstInfo.QuestionType.Question);
                    msb.ShowDialog();

                    if (msb.SelectedMainSubjectID == 0)
                        return;

                    ExamQuery.MainSubjectID = msb.SelectedMainSubjectID;
                    dgList.ExamQuery = ExamQuery;

                    int rows = dgList.AddSubjects(txtSubject.TextArray);

                    statusEventArgs.Title = rows.ToString() + "行受影响";

                    break;
                case "btnAddKey":
                    ExamQuery.MainSubjectID = Convert.ToInt32(drpMainSubject.SelectedValue);
                    dgList.ExamQuery = ExamQuery;

                    int resultKey = dgList.BindKeys(txtKey.TextArray);

                    if (resultKey == -2)
                        statusEventArgs.Title = string.Format("[{0}!={1}]行数不相等", dgList.Rows.Count, txtKey.TextArray.Length);
                    else
                        statusEventArgs.Title = resultKey + Constant.Affected_Rows;

                    break;
                case "btnUpdate":
                    dgList.UpdateExamData();
                    statusEventArgs.Title = dgList.Rows.Count.ToString() + "行受影响";
                    break;
                case "btnDelete":
                    dgList.DeleteExamData();
                    statusEventArgs.Title = dgList.Rows.Count.ToString() + "行受影响";
                    break;
            }
            OnStatus(statusEventArgs);
            base.ButtonClick(sender, e);

        }

        public override ExamQuery ExamQuery
        {
            get
            {
                return base.ExamQuery;
            }
            set
            {
                dgList.ExamQuery = value;
                dgList.BindExamData(); ;
                base.ExamQuery = value;
            }
        }

        private void drpMainSubject_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ExamQuery == null)
                return;

            MainSubjectInfo msi = drpMainSubject.SelectedItem as MainSubjectInfo;


            ExamQuery eq = ExamQuery;
            eq.MainSubjectID = msi.ID;
            ExamQuery = eq;
        }

    }
}
