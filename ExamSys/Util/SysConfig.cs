using System;
using System.Drawing;
using System.Configuration;
using ExamSys.Util;


namespace ExamSys
{
    public static class SysConfig
    {
        //�����ļ���д��
        public readonly static Cts.XmlHelper SettingsHelper = new Cts.XmlHelper(AppDomain.CurrentDomain.BaseDirectory + "settings.xml");
        //װ����
        public readonly static Decorater Decorater = new Decorater();
        //Appconfig����
        public readonly static Color CategoryColor = Color.FromName(SettingsHelper.GetValue("CategoryColor").Trim());
        public readonly static bool IsResetRegisterInfo = Convert.ToBoolean(ConfigurationManager.AppSettings["IsResetRegisterInfo"]);
        public readonly static bool IsInitialized = Convert.ToBoolean(SettingsHelper.GetValue("IsInitialized"));
        public readonly static bool IsShowSystemCreator = Convert.ToBoolean(SettingsHelper.GetValue("IsShowSystemCreator"));
        public readonly static string DebugHtmlCode = ConfigurationManager.AppSettings["DebugHtmlCode"].ToString();
        public readonly static string DebugMode = GetRegisterAppSetting();
        public readonly static int ExamResultCount = Convert.ToInt32(SettingsHelper.GetValue("ExamResultCount"));
        public readonly static int DropItemWidth = Convert.ToInt32(SettingsHelper.GetValue("DropItemWidth"));
        public static readonly string TemplateCurrentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Efd\\";
        
        public const string JS_ForbiddenContextMenu = "document.oncontextmenu = new Function('event.returnValue=false');";
        public const string JS_ForbiddenSelectStart = "document.onselectstart = new Function('event.returnValue=false;');";

        public const string Option_LimitedTime = "LimitedTime";
        public const string Json_Initialized = "IsInitialized";
        public const string DEBUGE_CODE = "qwert!@#$%~";
        public const string RIGHT_ARROW = " �� ";
        public const string Platform_Actived_Reminder = "��������Ծ���˳��Ծ�";
        public const string Encrypt_Key = "wjcking";
        public  static readonly string DecryptedDataCache =    Environment.GetEnvironmentVariable("TEMP")  + "\\dataCache.ebk" ;
        //�Ƿ񽻾�
        public static bool IsHandedIn = false;


        public static bool EnabledSound
        {
            get
            {
              return   Convert.ToBoolean(SettingsHelper.GetValue("EnabledSound"));
            }
            set
            {
                SettingsHelper.SetValue("EnabledSound", value.ToString());
            }
        }

        /// <summary>
        /// ���ע��������ý�
        /// </summary>
        /// <returns></returns>
        private static string GetRegisterAppSetting()
        {
            if (ConfigurationManager.AppSettings["DebugRegisterCode"] == null)
                return String.Empty;

            return ConfigurationManager.AppSettings["DebugRegisterCode"];
        }

        public static string TemplatePath(string tempName)
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Template\\" + tempName + "\\";
        }

        public static string TemplatePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Template\\";
        }

        public static string CurrentExamTemplate()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Template\\current.htm";
        }



        public const  string  Subject_TotalName = "�ܼ�";
    }
}