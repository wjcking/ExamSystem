using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using ExamSys.Util;
using Model;

namespace ExamSys.Options
{
    public partial class NetSet : UserControl
    {
        public const string RequestPage = "RequestPage";
        public NetSet()
        {
            InitializeComponent();
            txtRemoteURL.Text = SysConfig.SettingsHelper.GetValue(RequestPage);

            if (SysData.LocalCustomerInfo == null)
                return;
            txtNickName.Text = SysData.LocalCustomerInfo.Nickname;
            txtPassword.Text = SysData.LocalCustomerInfo.Password;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
           
         //WebClient webClient = new WebClient();
        // //webClient.DownloadwebClient.ResponseHeaders["Cookie"]String(txtRemoteURL.Text);
         //   string header = ;
         //   webClient.Headers.Add("Cookie", header);//在给服务器发送消息时加上这个Session值
         //   webClient.Headers[HttpRequestHeader.Cookie] = header;

         //   webClient.DownloadString(txtRemoteURL.Text);
         //    header = webClient.ResponseHeaders["Set-Cookie"];
         //   webClient.Headers.Add("Cookie", header);//在给服务器发送消息时加上这个Session值
         //   webClient.Headers[HttpRequestHeader.Cookie] = header;


         //   byte[] byRemoteInfo = webClient.UploadValues(txtRemoteURL.Text, "POST", VarPost);

         //   string remoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);
            CustomerInfo ci = Network.GetCustomerInfo(txtNickName.Text, txtPassword.Text);

            if (ci == null)
            {
                MessageBox.Show("获取失败");
            }
            else
            {
                MessageBox.Show(ci.CustomerName);
            }
        }

        private class CookieAwareWebClient : WebClient
        {
            public CookieAwareWebClient()
                : this(new CookieContainer())
            { }
            public CookieAwareWebClient(CookieContainer c)
            {
                this.CookieContainer = c;
            }
            public CookieContainer CookieContainer { get; set; }

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);

                var castRequest = request as HttpWebRequest;
                if (castRequest != null)
                {
                    castRequest.CookieContainer = this.CookieContainer;
                }

                return request;
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://www.google.cn/");   
        }

        public void Save()
        {
            SysConfig.SettingsHelper.SetValue(RequestPage, txtRemoteURL.Text);
        }
    }
}
