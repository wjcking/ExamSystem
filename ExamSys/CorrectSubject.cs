using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using ExamSys.Util;

namespace ExamSys
{
    public partial class CorrectSubject : Form
    {

        private ExamItemInfo examItem;
        private ExamInfo examInfo;
        private const string INPUT = "在这里输入正确答案({0})";

        public CorrectSubject(ExamItemInfo ei)
        {
            InitializeComponent();
            SysConfig.Decorater.FormCloseByKeyUp(this);
            examItem = ei;
            pictureBox.Image = Image.FromFile("Images\\alert.png");

            examInfo = SysData.ExamSysUtil.GetModel(ei.ExamInfoID);
            Text = examInfo.Name;
            lbSubject.Text = ei.Subject;
            lbKey.Text = ei.Key;
            ConstInfo.QuestionType qt = (ConstInfo.QuestionType)ei.CurrentMainSubject.Type;

            if (qt == ConstInfo.QuestionType.Judgement)
                lbKey.Text = (ei.Key.ToLower() == "true") ? "正确" : "错误";

            switch (qt)
            {
                case ConstInfo.QuestionType.Selection:
                    lbTip.Text = String.Format(INPUT, "26个英文字母，大小写不限");
                    txtCorrect.MaxLength = 26;
                    break;
                case ConstInfo.QuestionType.Judgement:
                    lbTip.Text = String.Format(INPUT, "0 = 正确 ，1 = 错误");
                    txtCorrect.MaxLength = 5;
                    break;
                case ConstInfo.QuestionType.Fill:
                    lbTip.Text = String.Format(INPUT, "多个填空用 , 隔开，仅限255个字符");
                    txtCorrect.MaxLength = 255;
                    break;
                case ConstInfo.QuestionType.Question:
                    lbTip.Text = String.Format(INPUT, "仅限10000个字符");
                    txtCorrect.MaxLength = 10000;
                    break;
            }

            lbCorrectNotice.Text = ei.CurrentMainSubject.Subject;
        }


        private void btnTake_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == btnCopy)
            {
                StringBuilder copyInfo = new StringBuilder();

                copyInfo.Append("系统：").Append(Valid.AccessRegisterInfo.ProductName).Append("\r\n");
                copyInfo.Append("题库：").Append(examInfo.Name).Append("\r\n");
                copyInfo.Append("编号：").Append(examItem.ID).Append("\r\n");
                copyInfo.Append("类型：").Append((ConstInfo.QuestionType)examItem.CurrentMainSubject.Type).Append("\r\n");
                copyInfo.Append("大题：").Append(examItem.CurrentMainSubject.Subject).Append("\r\n");
                copyInfo.Append("题目：").Append(examItem.Subject).Append("\r\n");

                Clipboard.SetText(copyInfo.ToString());
                DialogResult dr = MessageBox.Show(copyInfo.ToString(), "信息已复制到剪贴板，是否到官网提交发布？", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    switch (examItem.CorrectionType)
                    {
                        case ConstInfo.CORRECTTYPE_CORRECT:
                            SysData.ExamSysUtil.UpdateCorrectionType((ConstInfo.QuestionType)examItem.CurrentMainSubject.Type, ConstInfo.CORRECTTYPE_SUBMIT, examItem.ID.ToString());
                            break;

                        case ConstInfo.CORRECTTYPE_UPDATED:
                            SysData.ExamSysUtil.UpdateCorrectionType((ConstInfo.QuestionType)examItem.CurrentMainSubject.Type, ConstInfo.CORRECTTYPE_CS, examItem.ID.ToString());
                            break;

                        default:
                            break;
                    }

                  //  System.Diagnostics.Process.Start(SysConfig.SettingsHelper.GetValue(Settings.AddThreadUrl));
                }
            }
            else if (btn == btnCorrect)
            {
                //注册限制
                if (!Valid.IsRegistered)
                {
                    Register.GetNewRegister();
                    return;
                }

                if (string.IsNullOrEmpty(txtCorrect.Text))
                {
                    MessageBox.Show("请输入您需要修改的答案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                DialogResult dr = MessageBox.Show("您确认要修改此答案吗？", "确定吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {

                    ConstInfo.QuestionType qt = (ConstInfo.QuestionType)examItem.CurrentMainSubject.Type;
                    string correctedKey = "";

                    if (qt == ConstInfo.QuestionType.Selection)
                    {
                        if (!Cts.StrTool.IsLetter(txtCorrect.Text))
                        {
                            MessageBox.Show("仅限于26个英文字母，大小写不限", "验证", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        correctedKey = txtCorrect.Text.ToUpper().Trim();
                    }
                    else if (qt == ConstInfo.QuestionType.Judgement)
                    {
                        correctedKey = txtCorrect.Text == "0" ? "True" : "False";
                    }
                    else
                    {
                        correctedKey = txtCorrect.Text;
                    }
                    SysData.ExamSysUtil.UpdateKey(qt, examItem.ID, correctedKey);

                    switch (examItem.CorrectionType)
                    {
                        case ConstInfo.CORRECTTYPE_CORRECT:
                            SysData.ExamSysUtil.UpdateCorrectionType((ConstInfo.QuestionType)examItem.CurrentMainSubject.Type, ConstInfo.CORRECTTYPE_UPDATED, examItem.ID.ToString());
                            break;

                        case ConstInfo.CORRECTTYPE_SUBMIT:
                            SysData.ExamSysUtil.UpdateCorrectionType((ConstInfo.QuestionType)examItem.CurrentMainSubject.Type, ConstInfo.CORRECTTYPE_CS, examItem.ID.ToString());
                            break;

                        default:
                            break;
                    }

                    Close();
                }
            }
            else
                Close();
        }

       


    }
}
