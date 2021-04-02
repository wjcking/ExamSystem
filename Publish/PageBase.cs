using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Model;
using Cts;
using System.Collections.Specialized;
using DataUtility;

namespace Publish
{
    public class PageBase : Page
    {
        protected const string IMAGE_LIB = "ImageLib/";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
 
        /// <summary>
        /// 图片文件前缀
        /// </summary>
        protected string PrefixSubjectImage
        {
            get
            {
                if (ExamInfoID == 0)
                    return string.Empty;

                if (Mid == 0)
                    return string.Empty;
                
                return  ExamInfoID + "-" + Mid + "-S-";
            }
        }
        //ConfigurationManager.AppSettings["ConKey"] +"-" +

        protected string PrefixAnswerImage
        {
            get
            {
                if (ExamInfoID == 0)
                    return string.Empty;

                if (Mid == 0)
                    return string.Empty;

                return  ExamInfoID + "-" + Mid + "-A-";
            }
        }
        protected string ExamInfoQuery
        {
            get
            {
                return String.Format("ExamInfoID={0} AND MainSubjectID={1}", ExamInfoID, Mid);
            }
        }
        protected int ExamInfoID
        {
            get
            {
                return GetQueryInt("ExamInfoID", 0);
            }
        }

        protected int Mid
        {
            get
            {
                return GetQueryInt("Mid", 0);
            }
        }

        // get main subject list to bind to a dropdownlist

        public DropDownList GetMainSubject(DropDownList drp, ConstInfo.QuestionType qt)
        {

            MajorSubject ms = new MajorSubject(EasyConfig.ConnectionKey);
            int topicTypeID = (int)qt;


            List<MainSubjectInfo> msiList = ms.GetListArray(" TopicTypeID = " + topicTypeID.ToString());

            for (int i = 0; i < msiList.Count; i++)
            {
                if (msiList[i].Type <= 0)
                    continue;

                if (msiList[i].Type == (int)qt)
                    drp.Items.Add(new ListItem(msiList[i].Subject, msiList[i].CurrentID));
            }

            if (drp.Items.Count <= 0)
            {
                string url = "/EditMainSubject.aspx?ExamInfoID=" + ExamInfoID;
                Response.Redirect(url, true);
                return null;
            }

            return drp;
        }

        public ListDictionary GetBatchSubjects(string content)
        {
            try
            {
                int index = 0;

                content = content.Replace("．", ".");

                Regex reg = new Regex(@"(?s)(\d{1,3}\..*?)(?=(\d{1,3}\.)|$)");

                ListDictionary dic = new ListDictionary();

                foreach (Match m in reg.Matches(content))
                {
                    //dic.Add(m.Groups[1].Value, m.Groups[2].Value);
                    string s = m.Groups[0].Value;
                    dic.Add(index, m.Groups[0].Value);

                    index++;
                }

                return dic;
            }
            catch (Exception e)
            {
                MsgBox(e.Message);
                return null;
            }
        }

        public ListDictionary GetBatches(string content)
        {
            return GetBatches(content, ConstInfo.QuestionType.Selection);
        }

        public ListDictionary GetBatches(string content, ConstInfo.QuestionType qt)
        {
            try
            {
                const string gbLetters = "Ａ,Ｂ,Ｃ,Ｄ,Ｅ,Ｆ,Ｇ,Ｈ,Ｉ,Ｊ,Ｋ,Ｌ,Ｍ,Ｎ,Ｏ,Ｐ,Ｑ,Ｒ,Ｓ,Ｔ,Ｕ,Ｖ,Ｗ,Ｘ,Ｙ,Ｚ";
                const string letters = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

                int index = 0;

                Regex reg;

                if (qt == ConstInfo.QuestionType.Selection)
                    reg = new Regex(@"(?s)(\d{1,3}\..*?)([A-Z].*?)(?=(\d{1,3}\.)|$)");
                else
                    reg = new Regex(@"(?s)(\d{1,3}\..*?)(.*?)(?=(\d{1,3}\.)|$)");

                //change dots
                string[] lets = letters.Split(",".ToCharArray());
                string[] gblets = gbLetters.Split(",".ToCharArray());

                if (qt == ConstInfo.QuestionType.Selection)
                {
                    for (int i = 0; i < lets.Length; i++)
                        content = content.Replace(gblets[i], lets[i]);
                }

                content = content.Replace("．", ".");
                ListDictionary dic = new ListDictionary();

                foreach (Match m in reg.Matches(content))
                {
                    //dic.Add(m.Groups[1].Value, m.Groups[2].Value);
                    string s = m.Groups[1].Value;
                    dic.Add(index, m.Groups[2].Value);

                    index++;
                }

                return dic;
            }
            catch (Exception e)
            {
                MsgBox(e.Message);
                return null;
            }
        }


        #region 提示框,脚本


        public void MsgBox(string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), System.Guid.NewGuid().ToString(), string.Format("<script  type=\"text/javascript\">alert('{0}')</script>", msg));
        }

        public void MsgBox(string msg, string url)
        {
            ClientScript.RegisterStartupScript(GetType(), System.Guid.NewGuid().ToString(), string.Format("<script  type=\"text/javascript\">alert('{0}');location='{1}'</script>", msg, url));
        }

        public void PopupAlert(string msg)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), System.Guid.NewGuid().ToString(), string.Format("<script  type=\"text/javascript\">alert('{0}');history.back()</script>", msg), false);
        }

        public void PopupAlert(string msg, string url)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), System.Guid.NewGuid().ToString(), string.Format("<script  type=\"text/javascript\">alert('{0}');location='{1}'</script>", msg, url), false);
        }

        public void RegScriptBlock(string script)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), System.Guid.NewGuid().ToString(), string.Format("<script type=\"text/javascript\"> {0} </script>", script), false);
        }
        #endregion

        #region"封装Request"


        protected string GetDecodeString(string strName)
        {
            return HttpContext.Current.Server.UrlDecode(GetString(strName));
        }

        protected string GetEncodeString(string strName)
        {
            return HttpContext.Current.Server.UrlEncode(GetString(strName));
        }
        /// <summary>
        /// 字符串转整型
        /// </summary>
        /// <param name="inValue">传入参数</param>
        /// <param name="defValue">预定返回值</param>
        /// <returns>转换结果</returns>
        private int StrToInt(string inValue, int defValue)
        {
            if (!string.IsNullOrEmpty(inValue) && inValue.Length < 10)
            {
                try
                {
                    return int.Parse(inValue);
                }
                catch
                {
                    return defValue;
                }
            }
            else
            {
                return defValue;
            }
        }

        /// <summary>
        /// 字符串转浮点型
        /// </summary>
        /// <param name="inValue">传入参数</param>
        /// <param name="defValue">预定返回值</param>
        /// <returns>转换结果</returns>
        private float StrToFloat(string inValue, float defValue)
        {
            try
            {
                return float.Parse(inValue);
            }
            catch
            {
                return defValue;
            }
        }

        private bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }




        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        protected bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        protected bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        protected string GetServerString(string strName)
        {
            //
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// 返回上一个页面的地址
        /// </summary>
        /// <returns>上一个页面的地址</returns>
        protected string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;

        }

        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns></returns>
        protected string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }

        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns></returns>
        protected string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }


        /// <summary>
        /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
        /// </summary>
        /// <returns>原始 URL</returns>
        protected string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        protected bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// </summary>
        /// <returns>是否来自搜索引擎链接</returns>
        protected bool IsSearchEnginesGet()
        {
            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获得当前完整Url地址
        /// </summary>
        /// <returns>当前完整Url地址</returns>
        protected string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// 获得指定Url参数的DateTime类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的DateTime类型值</returns>
        protected DateTime GetQueryDate(string strName, string defValue)
        {
            DateTime ret;
            try
            {
                ret = DateTime.Parse(Request.QueryString[strName]);
            }
            catch
            {
                ret = DateTime.Parse(defValue);
            }
            return ret;
        }

        /// <summary>
        /// 获得指定Form参数的DateTime类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Form参数的DateTime类型值</returns>
        protected DateTime GetFormDate(string strName, string defValue)
        {
            DateTime ret;
            try
            {
                ret = DateTime.Parse(Request.Form[strName]);
            }
            catch
            {
                ret = DateTime.Parse(defValue);
            }
            return ret;
        }

        protected DateTime GetDate(string strName, string defValue)
        {
            if (string.IsNullOrEmpty(GetQueryString(strName)))
            {
                return GetFormDate(strName, defValue);
            }
            else
            {
                return GetQueryDate(strName, defValue);
            }
        }


        protected decimal GetDecimal(string strName, decimal defValue)
        {
            decimal ret = defValue;
            decimal.TryParse(GetString(strName, defValue.ToString()), out ret);
            return ret;
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的值</returns>
        protected string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }

        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        protected string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// 返回表单或Url参数的总个数
        /// </summary>
        /// <returns></returns>
        protected int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <returns>表单参数的值</returns>
        protected string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns>Url或表单参数的值</returns>
        protected string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            else
            {
                return GetQueryString(strName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        protected string GetString(string strName, string defValue)
        {
            string ret = "";
            if ("".Equals(GetQueryString(strName)))
            {
                ret = GetFormString(strName);
            }
            else
            {
                ret = GetQueryString(strName);
            }
            if (ret == "")
            {
                ret = defValue;
            }
            return ret;
        }


        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        protected int GetQueryInt(string strName, int defValue)
        {
            return StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        /// <summary>
        /// 获得指定表单参数的int类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的int类型值</returns>
        protected int GetFormInt(string strName, int defValue)
        {
            return StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的int类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        protected int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            else
            {
                return GetQueryInt(strName, defValue);
            }
        }

        /// <summary>
        /// 获得指定Url参数的float类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        protected float GetQueryFloat(string strName, float defValue)
        {
            return StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// 获得指定表单参数的float类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的float类型值</returns>
        protected float GetFormFloat(string strName, float defValue)
        {
            return StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的float类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        protected float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            else
            {
                return GetQueryFloat(strName, defValue);
            }
        }

        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        protected string GetIP()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (null == result || result == String.Empty || IsIP(result))
            {
                return "0.0.0.0";
            }

            return result;

        }
        /// <summary>
        /// 安全方式获得IP
        /// </summary>
        /// <returns></returns>
        protected string GetIPSecurity()
        {
            string result = String.Empty;
            try
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            catch
            {
                result = "0.0.0.0";
            }
            return result;
        }
        #endregion
    }
}
