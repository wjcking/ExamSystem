using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using DataUtility;
using System;

namespace EFD.SysCenter.Include
{
    public partial class MainSubject : ControlBase
    {
        public MainSubject()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
         

            string[] array = System.Enum.GetNames(typeof(ConstInfo.QuestionType));

            dgList.Columns.Clear();
            dgList.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn ctxtID = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ctxtSubject = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ctxtTopicTypeID = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ctxtEachPoint = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ctxtContent = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ctxtSort = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn cbtnDelete = new DataGridViewButtonColumn();

            ctxtID.Visible = false;
            ctxtID.Name = "ctxtID";
            ctxtID.HeaderText = "编号";
            ctxtID.DataPropertyName = "ID";
            ctxtID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            ctxtSubject.Name = "ctxtSubject";
            ctxtSubject.HeaderText = "题目";
            ctxtSubject.DataPropertyName = "Subject";
            ctxtSubject.Width = 130;

            ctxtTopicTypeID.Name = "ctxtTopicTypeID";
            ctxtTopicTypeID.HeaderText = "类型";
            ctxtTopicTypeID.DataPropertyName = "TopicTypeID";


            ctxtEachPoint.Name = "ctxtEachPoint";
            ctxtEachPoint.HeaderText = "每分";
            ctxtEachPoint.DataPropertyName = "EachPoint";


            ctxtContent.Name = "ctxtContent";
            ctxtContent.HeaderText = "内容";
            ctxtContent.DataPropertyName = "Content";

            ctxtSort.Name = "ctxtSort";
            ctxtSort.HeaderText = "排序";
            ctxtSort.DataPropertyName = "Sort";

            cbtnDelete.Name = "cbtnDelete";
            cbtnDelete.HeaderText = "删除";
            cbtnDelete.Text = "删除";
            cbtnDelete.UseColumnTextForButtonValue = true;
            cbtnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgList.Columns.AddRange(ctxtID, ctxtSubject, ctxtEachPoint, ctxtTopicTypeID, ctxtContent, ctxtSort, cbtnDelete);
            List<MainSubjectInfo> msiList = Exam.MainSubject.GetListArray(" 100 = 100 ORDER BY [Sort] ASC");
            dgList.BindCheckBox();
            dgList.DataSource = msiList;

            base.Initialize();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                MainSubjectInfo msi = new MainSubjectInfo();
                msi.ID = Convert.ToInt32(dgList.Rows[i].Cells["ctxtID"].Value);
                msi.Subject = dgList.Rows[i].Cells["ctxtSubject"].Value.ToString();
                msi.Sort = Convert.ToInt32(dgList.Rows[i].Cells["ctxtSort"].Value);
                msi.EachPoint = Convert.ToSingle(dgList.Rows[i].Cells["ctxtEachPoint"].Value);
                msi.Content = dgList.Rows[i].Cells["ctxtContent"].Value == null ? "" : dgList.Rows[i].Cells["ctxtContent"].Value.ToString();

                Exam.MainSubject.Update(msi);
            }
            Initialize();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < txtSubject.Lines.Length; i++)
            {
                MainSubjectInfo msi = new MainSubjectInfo();

                msi.Subject = txtSubject.Lines[i];
                msi.TopicTypeID = Convert.ToInt16(txtQuestionType.Lines[i]);
                msi.EachPoint = Convert.ToSingle(txtScore.Lines[i]);
            //    msi.Content = txtContent.Text;
                msi.Sort = i + 1;
                Exam.MainSubject.Add(msi);
                Exam.MainSubjectList.Clear();

            }
            Initialize();

        }

        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgList.Columns[e.ColumnIndex].Name == "cbtnDelete")
            {
                if (MessageBox.Show("确定吗, 该类下面所有试题全部删除", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int mainSubjectID = Convert.ToInt32(dgList.Rows[e.RowIndex].Cells["ctxtID"].Value);
                    Exam.MainSubject.Delete(mainSubjectID);

                    int type = Convert.ToInt32(dgList.Rows[e.RowIndex].Cells["ctxtTopicTypeID"].Value);
                    ConstInfo.QuestionType qt = (ConstInfo.QuestionType)type;
                    string query = string.Format("DELETE * FROM {0} WHERE MainSubjectID={1}", qt, mainSubjectID);

                    Exam.Access.ExecuteNonQuery(query);


                    Exam.MainSubjectList.Clear();
                    Initialize();
                }
            }

        }
    }
}
