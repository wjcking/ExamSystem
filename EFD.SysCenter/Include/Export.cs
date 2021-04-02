using System.Windows.Forms;
using System.Collections.Generic;
using DataUtility;
using System.Text;
using Model;
using Cts;
using System.IO;
using System;
namespace EFD.SysCenter.Include
{
    public partial class Export : ControlBase
    {
        public Export()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            dgList.AutoGenerateColumns = false;
            dgList.DataSource = Exam.DatabaseList;

            cdrpSkin.DataSource = Exam.GetSkinList();
            cdrpSkin.DisplayMember = "Name";
            cdrpSkin.ValueMember = "FullName";

            base.Initialize();
        }

        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            txtOutput.Clear();

            switch (dgList.Columns[e.ColumnIndex].Name)
            {
                case "cbtnXml":
                    string md5Category = Cts.Encrypt.StringToMD5Hash(Exam.DatabaseList[e.RowIndex].ValidCodeCategory);
                    txtOutput.AppendText(Exam.DatabaseList[e.RowIndex].ValidCodeCategory);
                    txtOutput.AppendText(Environment.NewLine);
                    txtOutput.AppendText(md5Category);
                    txtOutput.AppendText(Environment.NewLine);

                    if (dgList.Rows[e.RowIndex].Cells["ctxtMachineID"].Value == null)
                    {
                        txtOutput.Text = "请输入机器号";
                        return;
                    }
                    VerifyInfo vci = new VerifyInfo();
                    vci.ProductName = Exam.DatabaseList[e.RowIndex].ExamName;
                    vci.MachineID = dgList.Rows[e.RowIndex].Cells["ctxtMachineID"].Value.ToString();
                    vci.CategoryID = Exam.DatabaseList[e.RowIndex].ValidCodeCategory;
                    txtOutput.AppendText(Encrypt.GetValidCode(vci));

                    break;
                case "ctxtName":
                    List<StatisticInfo> slist = DataUtility.StatisticDAL.GetList(Exam.DatabaseList[e.RowIndex].FullName);

                    ExamSys examSys = new ExamSys(Exam.DatabaseList[e.RowIndex].FullName);
                    List<ExamInfo> elist = examSys.GetListArray("");

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


                    break;
                case "cbtnDebugPath":
                    ExamCategoryInfo eci = Exam.DatabaseList[e.RowIndex];

                    AccessHelper ass = new AccessHelper(eci.FullName);
                    ass.ExecuteNonQuery("UPDATE ExamInfo SET LastTestTime = null, TestTimes=0 ");
                    txtOutput.AppendText(Resource.ExportDebugDatabase(eci.FullName));
                    txtOutput.AppendText(Resource.ExportDebugSettings());
                    txtOutput.AppendText(Resource.ExportDebugImage(eci.NameWithoutExtension));
                    txtOutput.AppendText(Resource.ExportDebugMedia(eci.NameWithoutExtension));

                    object skinPath = dgList.Rows[e.RowIndex].Cells["cdrpSkin"].Value;
                    if (skinPath != null)
                        txtOutput.AppendText(Resource.ExportDebugSkin(skinPath.ToString()));

                    txtOutput.AppendText(Resource.ExportFinalDatabase(eci.FullName, eci.NameWithoutExtension));
                    txtOutput.AppendText(Resource.ExportFinalImage(eci.NameWithoutExtension));
                    txtOutput.AppendText(Resource.ExportFinalMedia(eci.NameWithoutExtension));
                    if (skinPath != null)
                        txtOutput.AppendText(Resource.ExportFinalSkinPath(skinPath.ToString()));


                    Resource.ExportInstallScript(eci);
                    break;
            }
        }

        private void BindTableField(int index)
        {
            txtOutput.Clear();
            Dictionary<string, string[]> list = AccessBasic.GetFieldNames(Exam.DatabaseList[index].FullName);

            foreach (KeyValuePair<string, string[]> kv in list)
            {

                StringBuilder databaseString = new StringBuilder();
                databaseString.AppendFormat("{0} ", kv.Key);
                databaseString.AppendFormat(":{0} ", kv.Value.Length);
                databaseString.Append("\r\n");
                databaseString.Append(string.Empty.PadRight(80, '-'));
                databaseString.Append("\r\n");

                for (int i = 0; i < kv.Value.Length; i++)
                {
                    databaseString.Append(kv.Value[i]);
                    databaseString.Append("\t");

                    if (i % 5 == 0 && i != 0)
                        databaseString.Append("\r\n");
                }

                databaseString.Append("\r\n");
                databaseString.Append("\r\n");

                txtOutput.AppendText(databaseString.ToString());
            }
        }
        private void btnExecuteQuery_Click(object sender, System.EventArgs e)
        {
            DialogResult confirmOne = MessageBox.Show("确定吗？！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmOne == DialogResult.No)
                return;

            DialogResult confirmAgain = MessageBox.Show("确定吗？！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmAgain == DialogResult.No)
                return;

            txtOutput.Clear();

            try
            {
                for (int i = 0; i < Exam.DatabaseList.Length; i++)
                {

                    AccessHelper ass = new AccessHelper(Exam.DatabaseList[i].FullName);
                    int result = ass.ExecuteNonQuery(cbxQuery.Text);
                    txtOutput.AppendText(result.ToString());
                }
            }
            catch (System.Exception exp)
            {
                txtOutput.Text = exp.Message;
            }

        }

        private void btnFillXml_Click(object sender, System.EventArgs e)
        {
            txtOutput.Clear();
            for (int i = 0; i < Exam.DatabaseList.Length; i++)
            {
                ExamSys es = new ExamSys(Exam.DatabaseList[i].FullName);
                VerifyInfo vci = new VerifyInfo();

                vci.ProductName = Exam.DatabaseList[i].ExamName;
                //分类
                vci.CategoryID = Exam.DatabaseList[i].ValidCodeCategory;

                string encryptedXml = Encrypt.EncryptVerifyXml(vci, true);
                int result = es.UpdateRegisterInfo(encryptedXml, vci.ProductName);
                txtOutput.AppendText(Exam.DatabaseList[i].ValidCodeCategory);
                txtOutput.AppendText("-");
                txtOutput.AppendText(Exam.DatabaseList[i].ExamName);

                txtOutput.AppendText("\r\n");
            }
        }
        //填充总数
        private void btnTotalCount_Click(object sender, System.EventArgs e)
        {
            txtOutput.Clear();
            for (int i = 0; i < Exam.DatabaseList.Length; i++)
            {
                StatisticDAL stat = new StatisticDAL(Exam.DatabaseList[i].FullName);
                AccessHelper ass = new AccessHelper(Exam.DatabaseList[i].FullName);

                ass.ExecuteNonQuery("DELETE * FROM ExamResult");
                ass.ExecuteNonQuery("UPDATE ExamInfo SET LastTestTime = null, TestTimes=0 ");
                ass.ExecuteNonQuery("UPDATE Selection SET Answer='',Fav=false,IncorrectNo=0 ");
                ass.ExecuteNonQuery("UPDATE Judgement SET Answer='',Fav=false,IncorrectNo=0 ");
                ass.ExecuteNonQuery("UPDATE Fill SET Answer='',Fav=false,IncorrectNo=0 ");
                ass.ExecuteNonQuery("UPDATE Question SET Answer='',Fav=false,IncorrectNo=0 ");

                ExamSys es = new ExamSys(Exam.DatabaseList[i].FullName);
                List<ExamInfo> examList = es.GetListArray(" IsMaterial = true");

                txtOutput.AppendText(Exam.DatabaseList[i].Name);
                txtOutput.AppendText("\r\n");
                txtOutput.AppendText("\r\n");
                foreach (ExamInfo ei in examList)
                {
                    int totalCount = stat.GetTotalCountByExamInfoID(ei.ID);
                    txtOutput.AppendText(ei.Name + "=" + totalCount.ToString());
                    ass.ExecuteNonQuery(string.Format("UPDATE ExamInfo Set  TotalCount = {0}, EmptyCount={0}, IncorrectCount=0 WHERE ID= {1}", totalCount, ei.ID));
                    txtOutput.AppendText(" ");
                    Application.DoEvents();
                }
                txtOutput.AppendText("\r\n");
                txtOutput.AppendText("\r\n");
            }
        }
    }
}

