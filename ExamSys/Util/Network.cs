using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using Model;
using ExamSys.Util;
using System.Diagnostics;

namespace ExamSys
{
    public class Network
    {
        private static string requestPage = SysConfig.SettingsHelper.GetValue(Options.NetSet.RequestPage);
        public static bool IsDownload = false;
        public static string GetFailedString()
        {
            StringBuilder error = new StringBuilder();

            error.Append("失败的原因可能有以下几项\r\n");
            error.Append("1) 未连接网络\r\n");
            error.Append("2) 防火墙阻止(如360安全卫士)\r\n");
            error.Append("3) 网速过慢超时\r\n");
            error.Append("4) 提交地址不存在，可在工具-配置菜单中设置\r\n");

            return error.ToString();
        }


        public static CustomerInfo GetCustomerInfo(string nickName, string password)
        {
            
            try
            {
                WebClient webClient = new WebClient();
                NameValueCollection VarPost = new NameValueCollection();

                VarPost.Add("type", "customer");//将textBox1中的数据变为用a标识的参数，并用POST传值方式传给网页 

                VarPost.Add("nickname", nickName);
                VarPost.Add("password", password);

                byte[] byRemoteInfo = webClient.UploadValues(requestPage, "POST", VarPost);

                string remoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);
                File.WriteAllText("MyInfo.xml", remoteInfo, Encoding.Default);


                return SysData.LocalCustomerInfo;
            }
            catch (Exception exp)
            {
                CustomerInfo ci = new CustomerInfo();
                ci.ID = -1;
                ci.Intro = exp.Message;

                return ci;
            }
        }
 
        public static List<string> MyProcess
        {
            get
            {
                List<string> myProcess = new List<string>();

                Process[] procs = Process.GetProcesses();
                foreach (Process p in procs)
                {
                 
                    if (string.IsNullOrEmpty(p.MainWindowTitle))
                        continue;
                    myProcess.Add(p.MainWindowTitle);
                }

                return myProcess;
            }
        }

        public static string MyProcessText
        {
            get
            {

                List<string> myProcess = MyProcess;
                StringBuilder sb = new StringBuilder();

                sb.Append("在考试的时候我总共运行着");
                sb.Append(myProcess.Count);
                sb.Append("个应用程序");

                sb.Append(" 其中包括：");
                foreach (string p in myProcess)
                {
                    sb.Append(p);
                    sb.Append("；");
                }

                return sb.ToString();
            }
        }
        public static string ClientOS
        {
            get
            {
                try
                {
                    System.Management.SelectQuery query = new System.Management.SelectQuery("Win32_OperatingSystem");
                    System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query);
                    System.Management.ManagementObjectCollection objs = searcher.Get();

                    string os = "";
                    foreach (System.Management.ManagementObject obj in objs)
                        os = obj.GetPropertyValue("Caption").ToString();

                    return os;
                }
                catch (Exception e)
                {
                    return "操作系统获取错误：" + e.Message;
                }
            }
        }


        public static string GetRemoteString(string type)
        {   
            WebClient webClient = new WebClient();
            NameValueCollection VarPost = new NameValueCollection();

            VarPost.Add("type",type);//将textBox1中的数据变为用a标识的参数，并用POST传值方式传给网页 

            byte[] byRemoteInfo = webClient.UploadValues(requestPage, "POST", VarPost);
            string remoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);

            return remoteInfo;

        }

        public static string GetRemoteExamResult()
        {
            WebClient webClient = new WebClient();
            NameValueCollection VarPost = new NameValueCollection();

            VarPost.Add("type","netresult");
            VarPost.Add("categoryid", Valid.AccessRegisterInfo.CategoryID);

            byte[] byRemoteInfo = webClient.UploadValues(requestPage, "POST", VarPost);

            string remoteInfo = System.Text.Encoding.Default.GetString(byRemoteInfo);
            string netResult = "var netResult=" + remoteInfo;
            File.WriteAllText("template/js/netresult.js", netResult, Encoding.Default);
            return remoteInfo;
        }

        public static void GetNetInitialization()
        {
            if (IsDownload)
                return;

            string remoteInfo = GetRemoteString("netinit");
            File.WriteAllText("template/netinit.htm", remoteInfo, Encoding.Default);
            IsDownload = true;
        }
         
    }
}
