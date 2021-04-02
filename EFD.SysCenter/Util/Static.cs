using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace EFD.SysCenter
{
    public class Static
    {

        //配置文件读写器
        public readonly static Cts.XmlHelper Settings = new Cts.XmlHelper(AppDomain.CurrentDomain.BaseDirectory + "settings.xml");
        public static string ImageLibrary = Static.Settings.GetValue(Constant.ImageLibrary);
       //public static readonly DataUtility.Outline OutlineSys = new DataUtility.Outline(ConnectionKey);

        //public static readonly string ImageRenamedLibraryPath = ConfigurationManager.AppSettings["ImageRenamedLibraryPath"] + DBName + "\\";
        //public static readonly string ImageLibraryPath = ConfigurationManager.AppSettings["ImageLibraryPath"];
        //public static readonly string MediaLibraryPath = ConfigurationManager.AppSettings["MediaLibraryPath"];
        //服务器各个文件路径
        //public static readonly string PathRoot = "";
        //public static readonly string PathAppData = PathRoot + @"App_data\";
        //public static readonly string PathCurrentDatabase = PathAppData + DBName;
        //   public static readonly string PathDB = PathRoot + "db.mdb";


        public static string MediaLibrary  = Static.Settings.GetValue(Constant.MediaLibrary);
    }
}
