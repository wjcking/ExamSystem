using System.Windows.Forms;
using Model;
using System;
using System.Data;
using System.IO;

namespace EFD.SysCenter
{
    public partial class SubjectDetailWnd : Form
    {
        public event SubjectDetailEventHandler OnSubjectDetailSelected;
        private DataTable subjectDetailList = null;

        public ExamQuery ExamQuery
        {
            get;
            set;
        }

        public SubjectDetailWnd()
        {
            InitializeComponent();
            Initialize();
        }

        public void SubjectDetailSelected(SubjectDetailEventArgs e)
        {
            if (OnSubjectDetailSelected != null)
                OnSubjectDetailSelected(this, e);
        }

        public void Initialize()
        {
            dgList.AutoGenerateColumns = false;

            if (ExamQuery == null)
            {

                return;
            }
            Text = String.Format("{0}→{1}→{2}", Exam.SelectedFileName, ExamQuery.MainSubjectID, ExamQuery.SubjectID);

            subjectDetailList = Exam.SubjectDetail.GetSubjectDetailList(ExamQuery.ExamInfoID);
            dgList.DataSource = subjectDetailList;


        
            if (!dgList.Columns.Contains("cbtnChoose"))
            { 
                //DataGridViewCheckBoxColumn cChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
                //cChk.Name = "cChk";
                //cChk.HeaderText = "";
                //cChk.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                //dgList.Columns.Insert(0, cChk);

                DataGridViewButtonColumn cbtnChoose = new System.Windows.Forms.DataGridViewButtonColumn();
                cbtnChoose.Name = "cbtnChoose";
                cbtnChoose.HeaderText = "选择";

                cbtnChoose.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                cbtnChoose.DataPropertyName = "SubjectDetailID";

                dgList.Columns.Add(cbtnChoose);
            } 
             
          
        }

        //添加题目详细
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            SubjectDetailInfo sdi = new SubjectDetailInfo();

            sdi.Title = txtTitle.Text;
            sdi.Content = txtContent.Text;
            sdi.ExamInfoID = ExamQuery.ExamInfoID;
            sdi.MainSubjectID = ExamQuery.MainSubjectID;
            sdi.SubjectID = ExamQuery.SubjectID;

            Exam.SubjectDetail.Add(sdi);
            Initialize();
        }


        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            bool isChecked = false;
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chk = dgList.Rows[i].Cells["cChk"] as DataGridViewCheckBoxCell;
                if (chk.Value == null)
                    continue;

                if (chk.Value.ToString().ToLower() == "true")
                {
                    isChecked = true;
                    int id = Convert.ToInt32(dgList.Rows[i].Cells["SubjectDetailID"].Value);
                    Exam.SubjectDetail.Delete(id);
                    Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '' WHERE SubjectDetail='{1}' ", ExamQuery.QuestionType, id));
                }
            }
            if (isChecked)
                Initialize();
        }

        //选择已有的题目详细
        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow row = subjectDetailList.Rows[e.RowIndex];

            switch (dgList.Columns[e.ColumnIndex].Name)
            {
                case "cbtnChoose":

                    SubjectDetailEventArgs sde = new SubjectDetailEventArgs();
                    sde.SubjectDetailInfo = new SubjectDetailInfo();


                    sde.IsFirst = false;

                    sde.SubjectDetailInfo.ID = Convert.ToInt32(row["SubjectDetailID"]);

                    sde.SubjectDetailInfo.Title = row["Title"].ToString();
                    sde.SubjectDetailInfo.Content = row["SDContent"].ToString();
                    sde.SubjectDetailInfo.MainSubjectID = Convert.ToInt32(row["MainSubjectID"]);
                    sde.SubjectDetailInfo.SubjectID = Convert.ToInt32(row["SubjectID"]);

                    Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '{1}' WHERE ID={2}", ExamQuery.QuestionType, sde.SubjectDetailInfo.ID, ExamQuery.SubjectID));

                    SubjectDetailSelected(sde);
                    Close();
                    return;
                case "cbtnMedia":
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        string mediaLibrary = Static.Settings.GetValue(Constant.MediaLibrary) + "\\";
                        ofd.RestoreDirectory = true;

                        if (!Directory.Exists(mediaLibrary))
                        {
                            Config config = new Config();
                            config.ShowDialog();
                            return;
                        }
                        string currentMediaPath = mediaLibrary + Exam.SelectedFileName + "\\";

                        if (!Directory.Exists(currentMediaPath))
                            Directory.CreateDirectory(currentMediaPath);

                        ofd.InitialDirectory = currentMediaPath;


                        if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                            return;

                        SubjectDetailInfo sdInfo = new SubjectDetailInfo();
                        sdInfo.ExamInfoID = ExamQuery.ExamInfoID;
                        sdInfo.SubjectID = Convert.ToInt32(row["SubjectID"]);
                        sdInfo.MainSubjectID = Convert.ToInt32(row["MainSubjectID"]);
                        sdInfo.ID = Convert.ToInt32(row["SubjectDetailID"]);
                        sdInfo.Media = Path.GetExtension(ofd.FileName);
                        dgList.Rows[e.RowIndex].Cells["cbtnMedia"].Value = sdInfo.MediaName;

                        File.Move(ofd.FileName, currentMediaPath + sdInfo.MediaName);
                        Exam.Access.ExecuteNonQuery(String.Format("UPDATE SubjectDetail SET Media='{0}' WHERE ID={1} ",sdInfo.Media,sdInfo.ID));
                    }
                    return;
            }
        }
        //设置值试题详细第一个 
        private void btnFirst_Click(object sender, EventArgs e)
        {
            bool isSubjectDetialExist = false;
            foreach (DataGridViewRow row in dgList.Rows)
            {
                if (Convert.ToInt32(row.Cells["SubjectID"].Value) == ExamQuery.SubjectID)
                {
                    isSubjectDetialExist = true;
                    break;
                }

            }
            if (!isSubjectDetialExist)
            {
                MessageBox.Show(String.Format("还没有添加 {0} 题目编号为{1}的明细", ExamQuery.SubjectID, ExamQuery.SubjectName));
                return;
            }

            SubjectDetailEventArgs sde = new SubjectDetailEventArgs();
            sde.IsFirst = true;
            Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = 'FIRST' WHERE ID={1}", ExamQuery.QuestionType, ExamQuery.SubjectID));

            SubjectDetailSelected(sde);

            Close();
        }
        //重置试题详细
        private void btnReset_Click(object sender, EventArgs e)
        {
            SubjectDetailEventArgs sde = new SubjectDetailEventArgs();
            sde.IsReset = true;
            SubjectDetailSelected(sde);

            Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '' WHERE ID={1}", ExamQuery.QuestionType, ExamQuery.SubjectID));

            Close();
        }

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgList.Rows)
            {
                if (row.Cells["ctxtMedia"].Value.ToString() != "")
                {
                    SubjectDetailInfo sdInfo = new SubjectDetailInfo();
                    sdInfo.ExamInfoID = ExamQuery.ExamInfoID;
                    sdInfo.SubjectID = Convert.ToInt32(row.Cells["SubjectID"].Value);
                    sdInfo.ID = Convert.ToInt32(row.Cells["SubjectDetailID"].Value);
                    sdInfo.Media = row.Cells["ctxtMedia"].Value.ToString();
                    sdInfo.MainSubjectID = Convert.ToInt32(row.Cells["MainSubjectID"].Value);
                    row.Cells["cbtnMedia"].Value = sdInfo.MediaName;
                }
            }
        }
    }
}
