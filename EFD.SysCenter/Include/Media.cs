using System;
using Model;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace EFD.SysCenter.Include
{
    public partial class Media : ControlBase
    {
        private MainSubjectInfo mainSubjectInfo;
        private ConstInfo.QuestionType tableName =   ConstInfo.QuestionType.Selection;
        //图片库+试题名称
        private string examImageLibrary = Static.ImageLibrary + "\\" + Exam.SelectedFileName + "\\";

        public Media()
        {
            InitializeComponent();
            dgList.AutoGenerateColumns = false;
            drpMainSubject.DataSource = Exam.MainSubject.GetListArray(String.Empty);
            drpMainSubject.DisplayMember = "Subject";
            drpMainSubject.ValueMember = "ID";
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

                BindData();
            }
        }

        private void drpMainSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            if (ExamQuery == null)
                return;

            mainSubjectInfo = drpMainSubject.SelectedItem as MainSubjectInfo;
            tableName = (ConstInfo.QuestionType)mainSubjectInfo.TopicTypeID;

            string theWhere = String.Format("ExamInfoID = {0} AND MainSubjectID = {1} ", ExamQuery.ExamInfoID, mainSubjectInfo.ID);
           // string subjectDetail = " AND SubjectDetail <> '' ";

            //if (cbSubjectDetail.Checked)
            //    theWhere = theWhere + subjectDetail;

            ConstInfo.QuestionType qt = (ConstInfo.QuestionType)mainSubjectInfo.TopicTypeID;

            switch (qt)
            {
                case ConstInfo.QuestionType.Selection:
                    dgList.DataSource = Exam.Choice.GetListArray(theWhere);

                    break;
                case ConstInfo.QuestionType.Fill:
                    dgList.DataSource = Exam.Fill.GetListArray(theWhere);
                    break;
                case ConstInfo.QuestionType.Judgement:
                    dgList.DataSource = Exam.Judgement.GetListArray(theWhere);
                    break;
                case ConstInfo.QuestionType.Question:
                    dgList.DataSource = Exam.Question.GetListArray(theWhere);
                    break;
            }

            foreach (DataGridViewRow row in dgList.Rows)
            {
                if (row.Cells["ctxtSImage"].Value.ToString() != "")
                {

                    int id = Convert.ToInt32(row.Cells["ctxtID"].Value);
                    ExamItemInfo subjectImgInfo = new ExamItemInfo();

           
                    subjectImgInfo.ExamInfoID = ExamQuery.ExamInfoID;
                    subjectImgInfo.MainSubjectID = mainSubjectInfo.ID;
                    subjectImgInfo.ID = id;
                    subjectImgInfo.SImage = row.Cells["ctxtSImage"].Value.ToString();
       
                    if (subjectImgInfo.SImage == "")
                        continue;
 
                    DataGridViewImageCell cellSImage = row.Cells["cimgSImage"] as DataGridViewImageCell;

                    string imageName = "";
                    if (!File.Exists(examImageLibrary + subjectImgInfo.SImageName))
                    {
                        cellSImage.ImageLayout = DataGridViewImageCellLayout.Normal;
                        imageName = Environment.CurrentDirectory + "\\images\\missing.bmp";
                    }
                    else
                    {
                        row.Height = 100;
                        imageName = examImageLibrary + subjectImgInfo.SImageName;
                    }

                    Stream imgStream = File.OpenRead(imageName);
                    cellSImage.Value = Image.FromStream(imgStream);
                    cellSImage.ToolTipText = subjectImgInfo.SImageName;
                    imgStream.Close();
                }

                if (row.Cells["ctxtAImage"].Value.ToString() != "")
                {

                    int id = Convert.ToInt32(row.Cells["ctxtID"].Value);
                    ExamItemInfo subjectImgInfo = new ExamItemInfo();
                    subjectImgInfo.ExamInfoID = ExamQuery.ExamInfoID;
                    subjectImgInfo.MainSubjectID = mainSubjectInfo.ID;
                    subjectImgInfo.ID = id;
                    subjectImgInfo.AImage = row.Cells["ctxtAImage"].Value.ToString();

                    if (subjectImgInfo.AImage == "")
                        continue;

                    DataGridViewImageCell cellSImage = row.Cells["cimgAImage"] as DataGridViewImageCell;

                    string imageName = "";
                    if (!File.Exists(examImageLibrary + subjectImgInfo.AImageName))
                    {
                        cellSImage.ImageLayout = DataGridViewImageCellLayout.Normal;
                        imageName = Environment.CurrentDirectory + "\\images\\missing.bmp";
                    }
                    else
                    {
                        row.Height = 100;
                        imageName = examImageLibrary + subjectImgInfo.AImageName;
                    }

                    Stream imgStream = File.OpenRead(imageName);
                    cellSImage.Value = Image.FromStream(imgStream);
                    cellSImage.ToolTipText = subjectImgInfo.AImageName;
                    imgStream.Close();
                }
            }
        }

        private void dgList_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            //试题id
            int id = Convert.ToInt32(dgList.Rows[e.RowIndex].Cells["ctxtID"].Value);


            //如果图片库不存在
            if (!Directory.Exists(Static.ImageLibrary))
            {
                Config configWnd = new Config();
                configWnd.ShowDialog();
                return;
            }
            //如果试题图片库不存在，则创建
            if (!Directory.Exists(examImageLibrary))
                Directory.CreateDirectory(examImageLibrary);

            switch (dgList.Columns[e.ColumnIndex].Name)
            {

                case "cimgSImage":
                    using (OpenFileDialog ofdSImage = new OpenFileDialog())
                    {

                        ofdSImage.RestoreDirectory = true;
                        ofdSImage.InitialDirectory = examImageLibrary;
                        ofdSImage.Title = String.Format("[主题]{0} -{1} - {2}", Exam.SelectedFileName, mainSubjectInfo.Subject, dgList.Rows[e.RowIndex].Cells["ctxtSubject"].Value);

                        if (ofdSImage.ShowDialog() == DialogResult.OK)
                        {
                            ExamItemInfo subjectImgInfo = new ExamItemInfo();
                            subjectImgInfo.ExamInfoID = ExamQuery.ExamInfoID;
                            subjectImgInfo.MainSubjectID = mainSubjectInfo.ID;
                            subjectImgInfo.ID = id;
                            subjectImgInfo.SImage = Path.GetExtension(ofdSImage.FileName);

                            string subjectDest = examImageLibrary + subjectImgInfo.SImageName;

                            if (!string.IsNullOrEmpty(ofdSImage.FileName))
                            {
                                if (!File.Exists( examImageLibrary + subjectImgInfo.SImageName))
                                File.Move(ofdSImage.FileName, examImageLibrary + subjectImgInfo.SImageName);

                                DataGridViewImageCell cellSImage = dgList.Rows[e.RowIndex].Cells["cimgSImage"] as DataGridViewImageCell;
                                Stream imgStream = File.OpenRead(examImageLibrary + subjectImgInfo.SImageName);
                                cellSImage.Value = Image.FromStream(imgStream);
                                cellSImage.ToolTipText = subjectImgInfo.SImageName;
                                imgStream.Close();
                                dgList.Rows[e.RowIndex].Height = 100;

                            int result =     Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET Simage = '{1}' WHERE ID={2} ", tableName, subjectImgInfo.SImage, id));
                            }
                        }
                    }
                    break;
                case "cimgAImage":
                    using (OpenFileDialog ofdAImage = new OpenFileDialog())
                    {

                        ofdAImage.RestoreDirectory = true;
                        ofdAImage.InitialDirectory = examImageLibrary;
                        ofdAImage.Title = String.Format("[主题]{0} -{1} - {2}", Exam.SelectedFileName, mainSubjectInfo.Subject, dgList.Rows[e.RowIndex].Cells["ctxtSubject"].Value);

                        if (ofdAImage.ShowDialog() == DialogResult.OK)
                        {
                            ExamItemInfo keyImgInfo = new ExamItemInfo();
                            keyImgInfo.ExamInfoID = ExamQuery.ExamInfoID;
                            keyImgInfo.MainSubjectID = mainSubjectInfo.ID;
                            keyImgInfo.ID = id;
                            keyImgInfo.AImage = Path.GetExtension(ofdAImage.FileName);
                            string subjectDest = examImageLibrary + keyImgInfo.AImageName;

                            if (!string.IsNullOrEmpty(ofdAImage.FileName))
                            {
                                if (!File.Exists(examImageLibrary + keyImgInfo.AImageName))
                                File.Move(ofdAImage.FileName, examImageLibrary + keyImgInfo.AImageName);

                                DataGridViewImageCell cellSImage = dgList.Rows[e.RowIndex].Cells["cimgAImage"] as DataGridViewImageCell;
                                Stream imgStream = File.OpenRead(examImageLibrary + keyImgInfo.AImageName);
                                cellSImage.Value = Image.FromStream(imgStream);
                                cellSImage.ToolTipText = keyImgInfo.AImageName;
                                imgStream.Close();
                                dgList.Rows[e.RowIndex].Height = 100;
                                Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET AImage = '{1}' WHERE ID={2} ", tableName, keyImgInfo.AImage, id));
                            }
                        }
                    }
                    break;

            }





        }

        private void dgList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                return;

            if (MessageBox.Show("确定要清除吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

             int id = Convert.ToInt32(dgList.Rows[e.RowIndex].Cells["ctxtID"].Value);

            switch (dgList.Columns[e.ColumnIndex].Name)
            {

                case "cimgSImage":
                    Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET SImage = '' WHERE ID={1} ", tableName , id));
                    dgList.Rows[e.RowIndex].Cells["cimgSImage"].Value = null;
                    return;
                case "cimgAImage":
                    Exam.Access.ExecuteNonQuery(String.Format("UPDATE {0} SET AImage = '' WHERE ID={1} ", tableName, id));
                    dgList.Rows[e.RowIndex].Cells["cimgAImage"].Value = null;
                    return;
            }
        }

    }
}
