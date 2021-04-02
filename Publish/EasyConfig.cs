using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

namespace Publish
{
    public class EasyConfig
    {
        public static readonly DataUtility.ExamSys DataSys = new DataUtility.ExamSys(ConnectionKey);
        public static readonly DataUtility.Outline OutlineSys = new DataUtility.Outline(ConnectionKey);
        //web.config
        public static readonly string DBDirectory = ConfigurationManager.AppSettings["DbDirectory"];
        public static readonly string DBName = ConfigurationManager.AppSettings["DBName"];
        public static readonly string DBNameWithoutExtension = DBName.ToLower().Replace(".mdb", string.Empty);
        public static readonly string ImageRenamedLibraryPath = ConfigurationManager.AppSettings["ImageRenamedLibraryPath"] + DBName + "\\";
        public static readonly string ImageLibraryPath = ConfigurationManager.AppSettings["ImageLibraryPath"];
        public static readonly string MediaLibraryPath = ConfigurationManager.AppSettings["MediaLibraryPath"];
        //服务器各个文件路径
        public static readonly string PathRoot = HttpContext.Current.Server.MapPath("~");
        public static readonly string PathAppData = PathRoot + @"App_data\";
        public static readonly string PathCurrentDatabase = PathAppData + DBName;
        public static readonly string PathDB = PathRoot + "db.mdb"; 

        public static void SetConnectionString(string configName, string providerName, string provider)
        {
            Configuration cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            ConnectionStringsSection oSection = cfg.GetSection("connectionStrings") as ConnectionStringsSection;

            ConnectionStringSettings css = new ConnectionStringSettings(configName, provider, providerName);
 
            oSection.ConnectionStrings.Clear();
            oSection.ConnectionStrings.Add(css);
            oSection.SectionInformation.ForceSave = true;
           
            cfg.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        
        public static void SetConnectionString(string configName, string databaseName)
        {
            const string providerName = "System.Data.OleDb";
            string provider = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;  Data Source='|DataDirectory|{0}';Jet OLEDB:Database Password=cursedhacker;", databaseName);        
            SetConnectionString(configName, providerName, provider);
        }
         
        /// <summary>
        /// 设置appSetting的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="filePath">App.config文件路径</param>
        public static void SetConfiguration(string key, string value)
        {
            Configuration configuration = null;                 //Configuration对象
            AppSettingsSection appSection = null;               //AppSection对象 

            configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            //for windows
            //configuration = ConfigurationManager.OpenExeConfiguration(filePath);
            //取得AppSetting节
            appSection = configuration.AppSettings;
            //赋值并保存
            appSection.Settings[key].Value = value;
            configuration.Save();
        }





        public static string ConnectionKey
        {
            get { return "EFD"; }
        }


    }
}