using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ExamSys.Util
{
   
    public static class SysData
    {
            public const string Xml_MyInfo = "MyInfo.xml";
        //数据操作静态类
        public readonly static DataUtility.AccessHelper AccessHelper = new DataUtility.AccessHelper();
        public readonly static DataUtility.Outline OutlineUtil = new DataUtility.Outline();
        public readonly static DataUtility.ExamSys ExamSysUtil = new DataUtility.ExamSys();
        public readonly static DataUtility.ExamHistory ExamHistoryUtil = new DataUtility.ExamHistory();
        public readonly static DataUtility.StatisticDAL StatisticUtil = new DataUtility.StatisticDAL();
        public readonly static DataUtility.MajorSubject MajorSubjectUtil = new DataUtility.MajorSubject();

        //获得大纲列表，不包括内容
        public readonly static List<OutlineInfo> OutlineList = OutlineUtil.GetListArray(string.Empty);
        public readonly static List<ExamInfo> ExamInfoList = ExamSysUtil.GetListArray(" 100 = 100 ORDER BY [ID] ASC ");
        public readonly static List<ExamInfo> ExamInfoListWithoutCategory = GetExamInfoListByRegister();
        public readonly static List<ExamInfo> ExamInfoCategoryList = ExamSysUtil.GetListArray(" 100 = 100 AND IsMaterial = false ORDER BY [ID]");
        public readonly static List<MainSubjectInfo> MainSubjectList = MajorSubjectUtil.GetListArray("100 = 100 ORDER BY [sort] ASC");

        //提交信息
        public static SubmitInfo SubmitInfo = null;

        private static List<ExamInfo> GetExamInfoListByRegister()
        {
            string query = Valid.IsRegistered ? " 100 = 100 AND IsMaterial = true ORDER BY [LastTestTime] DESC, ID ASC " : "SELECT TOP 2 * FROM ExamInfo WHERE IsMaterial = true ORDER BY [ID] ASC ";
       
            List<ExamInfo> examInfoListWithoutCategory = null;

            if (Valid.IsRegistered)
                examInfoListWithoutCategory = ExamSysUtil.GetListArray(query);
            else
                examInfoListWithoutCategory = ExamSysUtil.GetListByQuery(query);

            return examInfoListWithoutCategory;

        }
        /// <summary>
        /// 从库中中写入json
        /// </summary>
        public static void GenerateJson()
        {
            StringBuilder json = new StringBuilder();
            Newtonsoft.Json.Formatting jsonFormatting = Newtonsoft.Json.Formatting.None;

            List<ExamInfo> examInfoListWithoutCategory = GetExamInfoListByRegister();
            List<ExamResultInfo> examResultList = new DataUtility.ExamResult().GetListArray("100 = 100 ORDER BY [Pubdate] DESC");
            List<OutlineInfo> outlineList = OutlineUtil.GetListArray(string.Empty);
            //库中数据
            json.Append("var jsonExamInfoListWithoutCategory = " + JsonConvert.SerializeObject(examInfoListWithoutCategory, jsonFormatting) + ";");
          //禁用右键菜单
            if (SysConfig.DEBUGE_CODE != SysConfig.DebugHtmlCode)
                json.Append(SysConfig.JS_ForbiddenSelectStart + SysConfig.JS_ForbiddenContextMenu);

            json.Append("\r\n");
            json.Append("var jsonExamResultList = " + JsonConvert.SerializeObject(examResultList, jsonFormatting) + ";\r\n");
            //以下还是内存中的内容
            json.Append("var jsonExamInfoCategoryList = " + JsonConvert.SerializeObject(ExamInfoCategoryList, jsonFormatting) + ";\r\n");
            json.Append("var jsonMainSubjectList = " + JsonConvert.SerializeObject(MainSubjectList, jsonFormatting) + ";\r\n");
            json.Append("var jsonOutlineList = " + JsonConvert.SerializeObject(outlineList, jsonFormatting) + ";\r\n");
            
            System.IO.File.WriteAllText(Environment.CurrentDirectory + @"\template\js\cache.js", json.ToString(), Encoding.Default);
        }

        /// <summary>
        /// 如果是第一次运行了
        /// </summary>
        public static void InitializeJson()
        {
            if (SysConfig.IsInitialized)
                return;

            List<StatisticInfo> statisticList = StatisticUtil.GetTotalCountList();
            StringBuilder json = new StringBuilder();

            json.Append("var jsonStatisticList = " + JsonConvert.SerializeObject(statisticList, Newtonsoft.Json.Formatting.None) + ";\r\n");

            System.IO.File.WriteAllText(Environment.CurrentDirectory + @"\template\js\Init.js", json.ToString(), Encoding.Default);

            SysConfig.SettingsHelper.SetValue("IsInitialized", "true");
        }
        /// <summary>
        /// 递归获得试卷分类
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="category"></param>
        public static void GetExamCategoryByRecursion(int parentId, ref string category)
        {
            List<ExamInfo> examList = SysData.GetExamCategoryListByPid(parentId);

            foreach (ExamInfo ei in examList)
            {
                if (ei.ID == parentId)
                {
                    category = ei.Name.Trim() + SysConfig.RIGHT_ARROW.Trim() + category;
                    GetExamCategoryByRecursion(ei.PID, ref category);
                }
            }
        }

        /// <summary>
        /// 根据pid获取试卷分类数据缓存
        /// </summary>
        /// <param name="currentPid"></param>
        /// <returns></returns>
        public static List<ExamInfo> GetExamCategoryListByPid(int currentPid)
        {
            List<ExamInfo> temp = new List<ExamInfo>();

            foreach (ExamInfo ei in ExamInfoCategoryList)
                if (ei.ID == currentPid)
                    temp.Add(ei);

            return temp;
        }

        /// <summary>
        /// 根据pid获取试卷数据缓存
        /// </summary>
        /// <param name="currentPid"></param>
        /// <returns></returns>
        public static List<ExamInfo> GetExamListByPid(int currentPid)
        {
            List<ExamInfo> temp = new List<ExamInfo>();

            foreach (ExamInfo ei in ExamInfoList)
                if (ei.PID == currentPid)
                    temp.Add(ei);

            return temp;
        }

        /// <summary>
        /// 根据pid获取资料数据缓存
        /// </summary>
        /// <param name="currentPid"></param>
        /// <returns></returns>
        public static List<OutlineInfo> GetOutlineListByPid(int currentPid)
        {
            List<OutlineInfo> temp = new List<OutlineInfo>();

            foreach (OutlineInfo oi in OutlineList)
            {
                if (oi.PID == currentPid)
                    temp.Add(oi);
            }

            return temp;
        }

        /// <summary>
        /// 从缓存中获取试卷列表（不包括分类名）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ExamInfo GetExamListByID(int id)
        {
            foreach (ExamInfo ei in ExamInfoListWithoutCategory)
            {
                if (ei.ID == id)
                    return ei;
            }

            ExamInfo e = new ExamInfo();
            e.ID = 0;
            e.Name = "所有题库";
            return e;
        }
        public static CustomerInfo LocalCustomerInfo
        {
            get {

                XmlSerializer xs = new XmlSerializer(typeof(CustomerInfo));
                FileStream fs = null;
                fs = new FileStream(Xml_MyInfo, FileMode.Open, FileAccess.Read);
                CustomerInfo ci = (CustomerInfo)xs.Deserialize(fs);
                fs.Close();

                return ci;
            }
        }
       public static void SerializeCustomerInfo(CustomerInfo customerInfo )
        { 
            XmlSerializer ser = new XmlSerializer(typeof(CustomerInfo));

            MemoryStream stream = new MemoryStream(10);
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.GetEncoding("GB2312"));
            writer.Formatting = System.Xml.Formatting.Indented;//缩进
            ser.Serialize(writer, customerInfo);

            stream.Position = 0;
            string line = "";
            using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("GB2312")))
            {
                line = reader.ReadToEnd();
            }
            writer.Close();

            File.WriteAllText(Xml_MyInfo, line, Encoding.GetEncoding("GB2312"));
        }
    }
}
