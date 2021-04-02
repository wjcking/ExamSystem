using System;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Model;
using System.Xml;
using ExamSys.Util;
using System.Net;
using System.Collections.Specialized;

namespace ExamSys
{
    public partial class Submit : Form
    {
        private readonly string requestPage = SysConfig.SettingsHelper.GetValue(Options.NetSet.RequestPage);
        private CustomerInfo customerInfo = new CustomerInfo();

        public Submit()
        {
            InitializeComponent();
            listProvince.GetProvince();


            //txtOutput.AppendText("\r\n");

            //foreach (string s in Network.MyProcess)
            //{
            //    txtOutput.AppendText(s);
            //    txtOutput.AppendText("\r\n");
            //}
            BindData();

        }
        private void BindData()
        {

            customerInfo = SysData.LocalCustomerInfo;
            txtUserName.Text = customerInfo.CustomerName;
            txtJob.Text = customerInfo.Job;
            txtQQ.Text = customerInfo.QQ;
            drpGender.Text = customerInfo.Gender;

            try
            {
                if (customerInfo.Province != "")
                {
                    listProvince.SelectedValue = customerInfo.Province;
                    listCity.GetCitiesByProvinceID(customerInfo.Province);

                }
                if (customerInfo.City != "")
                {
                    listCity.SelectedValue = customerInfo.City;
                    listArea.GetAreaByCityID(customerInfo.City);
                }

                if (customerInfo.Area != "")
                    listArea.SelectedValue = customerInfo.Area;
            }
            catch (Exception e)
            {
                txtOutput.AppendText(string.Format("个人基本信息-所在区域初始化失败，请重新选择(ERROR:{0})\r\n", e.Message));
            }

            lbExamInfoID.Text = SysData.SubmitInfo.TemplateInfo.ExamInfoID.ToString();
            lbTotalCount.Text = "试题总数：" + SysData.SubmitInfo.TotalNumber.ToString();
            lbCorrectCount.Text = "正确个数：" + SysData.SubmitInfo.CorrectNumber.ToString();
            lbOS.Text = Network.ClientOS;
            lbMyProcess.Text = Network.MyProcessText;
            gbExam.Text = SysData.SubmitInfo.TemplateInfo.Title;
            lbStartTime.Text = "开始时间：" + SysData.SubmitInfo.StartTime.ToString();
            lbEndTime.Text = "交卷时间：" + SysData.SubmitInfo.EndTime.ToString();
            lbDuration.Text = "答题时间：" + SysData.SubmitInfo.Duration;
            lbTestWay.Text = "考试方式:" + SysData.SubmitInfo.TemplateInfo.TestWay.ToString();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool canSubmit = false;

            if (SysData.SubmitInfo.TemplateInfo.TestWay == ConstInfo.TestWay.计时考试 || SysData.SubmitInfo.TemplateInfo.TestWay == ConstInfo.TestWay.正式考试)
            {
                canSubmit = true;
            }

            //if (SysData.SubmitInfo.DurationTimeSpan.TotalSeconds < 30)
            //{
            //    canSubmit = false;

            //}
            if (!canSubmit)
            {
                txtOutput.AppendText("[提交条件]考试方式为“正式考试”或“计时测试”；作答时间超过30秒；并且不能交白卷");
                txtOutput.AppendText("\r\n");
                return;
            }


            if (txtUserName.Text.Length < 2)
            {
                tabControl1.SelectedIndex = 1;
                txtUserName.Focus();
                txtOutput.AppendText("请填写署名（必须为2个以上字符）\r\n");
                return;
            }

            if (listProvince.Text == "")
            {
                if (MessageBox.Show("目前您还未选择所在区域，是否要选择？", "我所在的区域", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
                {
                    tabControl1.SelectedIndex = 1;
                    listProvince.Focus();
                    return;
                }
            }

            try
            {

                WebClient webClient = new WebClient();
                NameValueCollection VarPost = new NameValueCollection();

                VarPost.Add("type", "addexamresult");//将textBox1中的数据变为用a标识的参数，并用POST传值方式传给网页 

                VarPost.Add("nickname", customerInfo.Nickname);
                VarPost.Add("password", customerInfo.Password);
                VarPost.Add("starttime", SysData.SubmitInfo.StartTime.ToString());
                VarPost.Add("endtime", SysData.SubmitInfo.EndTime.ToString());
                VarPost.Add("duration", SysData.SubmitInfo.Duration);
                VarPost.Add("testway", SysData.SubmitInfo.TemplateInfo.TestWay.ToString());
                VarPost.Add("totalcount", SysData.SubmitInfo.TotalNumber.ToString());
                VarPost.Add("correctcount", SysData.SubmitInfo.CorrectNumber.ToString());
                VarPost.Add("osversion", SysData.SubmitInfo.OSVersion);
                VarPost.Add("isoneapp", SysData.SubmitInfo.IsOneApp.ToString());
                VarPost.Add("name", txtUserName.Text);
                VarPost.Add("job", txtJob.Text);
                VarPost.Add("gender", drpGender.Text);
                VarPost.Add("qq", txtQQ.Text);
                VarPost.Add("remark", txtRemark.Text);
     
                customerInfo.CustomerName = txtUserName.Text;
                customerInfo.Job = txtJob.Text;
                customerInfo.Gender = drpGender.Text;
                customerInfo.QQ = txtQQ.Text;

                StringBuilder questionType = new StringBuilder();

                questionType.Append(SysData.SubmitInfo.TemplateInfo.IsShowSelection ? "S" : "");
                questionType.Append(SysData.SubmitInfo.TemplateInfo.IsShowJudgement ? "J" : "");
                questionType.Append(SysData.SubmitInfo.TemplateInfo.IsShowFill ? "F" : "");
                questionType.Append(SysData.SubmitInfo.TemplateInfo.IsShowQuestion ? "Q" : "");

                customerInfo.Province = listProvince.SelectedValue == null ? "" : listProvince.SelectedValue.ToString();
                customerInfo.City = listCity.SelectedValue == null ? "" : listCity.SelectedValue.ToString();
                customerInfo.Area = listArea.SelectedValue == null ? "" : listArea.SelectedValue.ToString();

                VarPost.Add("questiontype", questionType.ToString());
                VarPost.Add("province", customerInfo.Province);
                VarPost.Add("city", customerInfo.City);
                VarPost.Add("area", customerInfo.Area);

                VarPost.Add("examinfoid", SysData.SubmitInfo.TemplateInfo.ExamInfoID.ToString());
                VarPost.Add("examname", SysData.SubmitInfo.TemplateInfo.Title);
                VarPost.Add("categoryid", Valid.AccessRegisterInfo.CategoryID);
                VarPost.Add("displaystyle", SysData.SubmitInfo.TemplateInfo.DisplayStyle.ToString());

                byte[] byRemoteInfo = webClient.UploadValues(SysConfig.SettingsHelper.GetValue(Options.NetSet.RequestPage), "POST", VarPost);

                string remoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);

                //序列号customerInfo
                SysData.SerializeCustomerInfo(customerInfo);

                if (remoteInfo == "CLIENT_SUCCESS")
                {
                    SysData.SubmitInfo = null;
                    MessageBox.Show("提交成功");
                    Close();
                }
                else if (remoteInfo == "MEMBER_SUCCESS")
                {
                    SysData.SubmitInfo = null;
                    MessageBox.Show("[注册会员]提交成功");
                    Close();
                }
                else
                {
                    txtOutput.AppendText(remoteInfo);
                }

            }
            catch (Exception exp)
            {
                txtOutput.AppendText("提交失败\r\n");
                txtOutput.AppendText(exp.Message + "\r\n");
                txtOutput.AppendText(Network.GetFailedString());
            }
        }



        private void listProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCity.GetCitiesByProvinceID(listProvince.SelectedValue.ToString());
            if (listProvince.SelectedIndex == 0)
            {
                listCity.DataSource = null;
                listArea.DataSource = null;
            }
        }

        private void listCity_SelectedIndexChanged(object sender, EventArgs e)
        {

            listArea.GetAreaByCityID(listCity.SelectedValue.ToString());
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;

            switch (link.Name)
            {
                case "lkRegister":
                    System.Diagnostics.Process.Start(SysConfig.SettingsHelper.GetValue(Settings.RegisterUrl));
                    return;
                case "linkLabel":
                    Settings settings = new Settings(6);
                    settings.ShowDialog();
                    BindData();
                    return;
            }
        }



    }
}
