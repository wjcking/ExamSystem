
using Model;
using System.Windows.Forms;
namespace EFD.SysCenter.Include
{
    public partial class ModifyChoice : ControlBase
    {
        public ModifyChoice()
        {
            InitializeComponent();
            drpMainSubject.BindMainSubject(ConstInfo.QuestionType.Selection);
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
              //  drpMainSubject.BindSubjectCount(dgList.Rows.Count);
                base.ExamQuery = value;
            }
        }

        private void btnUpdateAnalysis_Click(object sender, System.EventArgs e)
        {
            string[] analysis = txtAnalysis.TextArray;
            int result = dgList.BindAnalysis(analysis);

            if (result == -2)
                base.statusEventArgs.Title = string.Format("[{0}!={1}]行数不相等", dgList.Rows.Count, analysis.Length);
            else
            {
                base.statusEventArgs.Title = result + Constant.Affected_Rows;
                txtAnalysis.Clear();
            }
            OnStatus(base.statusEventArgs);
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

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            dgList.DeleteExamData();

        }

        private void btnUpdateKeys_Click(object sender, System.EventArgs e)
        {
            string[] keys = txtKey.TextArray;

            int result = dgList.BindKeys(keys);


            StatusEventArgs sea = new StatusEventArgs();

            if (result == -2)
                sea.Title = string.Format("[{0}!={1}]行数不相等", dgList.Rows.Count, keys.Length);
            else
            {
                sea.Title = result + Constant.Affected_Rows;
                txtKey.Clear();
            }

            OnStatus(sea);
        }

        private void btnUpdateAll_Click(object sender, System.EventArgs e)
        {
            dgList.UpdateExamData();
        }

        private void btnOrganizChoice_Click(object sender, System.EventArgs e)
        {
            dgList.OrganizeChoiceText();
        }
    }
}
