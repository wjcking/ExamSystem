using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EFD.SysCenter
{
    public class Resource
    {
        private static readonly string DebugExamSysPath = GetDebugPath();
        private static readonly string CenterToSettingPath = Environment.CurrentDirectory + "\\centerToSettingPath.xml";
        private static readonly string FinalPath = Static.Settings.GetValue(Constant.FinalPath) + "\\";
        private static readonly string DebugSettingPath = DebugExamSysPath + "settings.xml";
        private static readonly string DebugDatabase = DebugExamSysPath + "EasyFound.dll";
        private static readonly string DebugSkinPath = DebugExamSysPath + "Skin\\default.ssk";

        private static int ClearFiles(string path)
        {
            if (!Directory.Exists(path))
                return 0;

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                File.Delete(file);
            }

            return files.Length;
        }
        private static string GetDebugPath()
        {
            string debug = Environment.CurrentDirectory.Replace("EFD.SysCenter", "ExamSys") + "\\";

            if (Directory.Exists(debug))
                return debug;

            string debugPath = Static.Settings.GetValue(Constant.DebugPath);

            if (Directory.Exists(debugPath))
                return debugPath + "\\";

            return "";
        }

        public static string ExportDebugDatabase(string databaseFullName)
        {
            //本机debug导出
            if (!File.Exists(databaseFullName))
                return "(debug)路径不存在";

            File.Copy(databaseFullName, DebugDatabase, true);
            return "(debug)数据库导出完毕  " + DebugDatabase + "\r\n";
        }

        public static string ExportDebugSettings()
        {
            if (!Directory.Exists(DebugExamSysPath))
                return "(debug)路径不存在";

            File.Copy(CenterToSettingPath, DebugSettingPath, true);

            return "(debug)配置文件导出完毕   \r\n";
        }

        public static string ExportDebugImage(string databaseName)
        {
            string debugImageLibPath = DebugExamSysPath + "template\\imageLib\\";
            ClearFiles(debugImageLibPath);

            string[] imageFiles = null;
            if (Directory.Exists(Static.ImageLibrary + "\\" + databaseName))
            {

                imageFiles = Directory.GetFiles(Static.ImageLibrary + "\\" + databaseName);
                int number = 0;
                foreach (string file in imageFiles)
                {
                    number++;
                    File.Copy(file, debugImageLibPath + Path.GetFileName(file), true);
                }
                return ("(debug)图库文件导出完毕  " + number + "\r\n");
            }

            return "(debug)图库库不存在 " + Static.ImageLibrary + "\\" + databaseName + "\r\n";
        }

        public static string ExportDebugSkin(string skinPath)
        {
            if (!File.Exists(skinPath))
            {
                return ("(debug)皮肤导出失败  " + skinPath + "\r\n");
            }

            File.Copy(skinPath, DebugSkinPath, true);
            return ("(debug)皮肤导出完毕  " + DebugSkinPath + "\r\n");
        }

        public static string ExportDebugMedia(string databaseName)
        {
            string debugExportMediaLib = DebugExamSysPath + "template\\MediaLib\\";
            ClearFiles(debugExportMediaLib);

            if (Directory.Exists(Static.MediaLibrary + "\\" + databaseName))
            {

                string[] mediaFiles = Directory.GetFiles(Static.MediaLibrary + "\\" + databaseName);
                if (mediaFiles.Length > 0)
                {
                    int number = 0;
                    foreach (string file in mediaFiles)
                    {
                        File.Copy(file, debugExportMediaLib + Path.GetFileName(file), true);
                        number++;
                    }

                    return "(Debug)媒体文件导出完毕  " + number + "\r\n";
                }
                return "(Debug)没有媒体文件\r\n";
            }

            return "(Debug)没有媒体文件\r\n";
        }

        public static string ExportFinalDatabase(string exportDatabaseFile, string databaseName)
        {
            string finalExportDatabasePath = FinalPath + "\\";

            if (string.IsNullOrEmpty(finalExportDatabasePath))
                return "(Final)数据库路径为空";

            if (!Directory.Exists(finalExportDatabasePath))
                Directory.CreateDirectory(finalExportDatabasePath);

            File.Copy(exportDatabaseFile, finalExportDatabasePath + "EasyFound.dll", true);

            return "(Final)数据库导出完毕  " + finalExportDatabasePath + "EasyFound.dll \r\n";
        }

        public static string ExportFinalSetting(string databaseName)
        {
            string path = FinalPath + "\\settings.xml";
            File.Copy(CenterToSettingPath, path, true);

            return "(Final)配置文件导出完毕  " + path + "settings.xml\r\n";
        }

        public static string ExportFinalSkinPath(string skinPath)
        {
            try
            {
                string finalSkinPath = FinalPath + "Skin\\";
                if (!Directory.Exists(finalSkinPath))
                    Directory.CreateDirectory(finalSkinPath);

                //苹果皮肤
                File.Copy(Environment.CurrentDirectory + "\\apple.ssk", finalSkinPath + "apple.ssk", true);

                File.Copy(skinPath, finalSkinPath + "default.ssk", true);
                return "(Final)皮肤导出完毕  " + finalSkinPath + "\r\n";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string ExportFinalImage(string databaseName)
        {
            string finalExportImageLib = FinalPath + "template\\ImageLib\\";
            ClearFiles(finalExportImageLib);

            if (!Directory.Exists(finalExportImageLib))
                Directory.CreateDirectory(finalExportImageLib);

            if (Directory.Exists(Static.ImageLibrary + "\\" + databaseName))
            {

                string[] imageFiles = Directory.GetFiles(Static.ImageLibrary + "\\" + databaseName);

                if (imageFiles.Length > 0)
                {
                    int number = 0;
                    foreach (string file in imageFiles)
                    {
                        File.Copy(file, finalExportImageLib + Path.GetFileName(file), true);
                        number++;
                    }

                    return "(Final)图库文件导出完毕  " + number + "\r\n";
                }

                return "(Final)没有图片 \r\n"; ;
            }
            else
            {

                return "(Final)没有图片 \r\n"; ;
            }
        }

        public static string ExportFinalMedia(string databaseName)
        {
            string finalExportMediaLib = FinalPath + "template\\MediaLib\\";
            ClearFiles(finalExportMediaLib);

            if (!Directory.Exists(finalExportMediaLib))
                Directory.CreateDirectory(finalExportMediaLib);

            if (Directory.Exists(Static.MediaLibrary + "\\" + databaseName))
            {
                string[] mediaFiles = Directory.GetFiles(Static.MediaLibrary + "\\" + databaseName);
                if (mediaFiles.Length > 0)
                {
                    int number = 0;
                    foreach (string file in mediaFiles)
                    {

                        File.Copy(file, finalExportMediaLib + Path.GetFileName(file), true);
                        number++;
                    }

                    return "(Final)媒体文件导出完毕  " + number + "\r\n";
                }

                return "(Final)没有媒体文件" + "\r\n"; ;
            }

            return "(Final)没有媒体文件 " + "\r\n"; ;
        }

        public static string ExportInstallScript(ExamCategoryInfo eci)
        {
            string iss = Environment.CurrentDirectory + "\\inno_dotnet_example.iss";
            string file = File.ReadAllText(iss, Encoding.Default);
            file = file.Replace("<%SourceFileDir%>", FinalPath);
            file = file.Replace("<%InstallFileDir%>", Static.Settings.GetValue(Constant.PublishPath));
            file = file.Replace("<%AppName%>", "[易方得]"+ eci.ExamName);
            file = file.Replace("<%AppVerName%>", eci.ValidCodeCategory );
            file = file.Replace("<%DefaultGroupName%>", eci.ExamName);
            file = file.Replace("<%OutputBaseFilenameFW%>", eci.ValidCodeCategory + "_FW");
            file = file.Replace("<%OutputBaseFilename%>", eci.ValidCodeCategory);
            file = file.Replace("<%GroupName%>", eci.ExamName);
            File.WriteAllText(Static.Settings.GetValue(Constant.InstallScript), file, Encoding.Default);
            return file;
        }
    }
}
