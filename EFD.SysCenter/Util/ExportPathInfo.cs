using System;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel;

namespace EFD.SysCenter
{

    public class Folder : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.ShowDialog();
            return ofd.SelectedPath;
        }
    }

    /// <summary>
    /// 导出路径
    /// </summary>
    public class ExportPathInfo
    {

        [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("题库路径,同样重新命名以后的试题图片路径")]
        public string DatabasePath
        {
            get { return Static.Settings.GetValue(Constant.DatabasePath); }
            set { Static.Settings.SetValue(Constant.DatabasePath, value); }
        }


        [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("皮肤路径")]
        public string SkinPath
        {
            get { return Static.Settings.GetValue(Constant.SkinPath); }
            set { Static.Settings.SetValue(Constant.SkinPath, value); }
        }

        [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("试题图片路径")]
        public string ImageLibrary
        {
            get { return Static.Settings.GetValue(Constant.ImageLibrary); }
            set { Static.Settings.SetValue(Constant.ImageLibrary, value); }
        }
      


        [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("音频库路径")]
        public string MediaLibrary
        {
            get { return Static.Settings.GetValue(Constant.MediaLibrary); }
            set { Static.Settings.SetValue(Constant.MediaLibrary, value); }
        }

        [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("导出到发布版")]
        public string FinalPath
        {
            get { return Static.Settings.GetValue(Constant.FinalPath); }
            set { Static.Settings.SetValue(Constant.FinalPath, value); }
        }

            [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("导出到debug版")]
        public string DebugPath
        {
            get { return Static.Settings.GetValue(Constant.DebugPath); }
            set { Static.Settings.SetValue(Constant.DebugPath, value); }
        }

        [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("安装脚本")]
        public string InstallScript
        {
            get { return Static.Settings.GetValue(Constant.InstallScript); }
            set { Static.Settings.SetValue(Constant.InstallScript, value); }
        }
        [Editor(typeof(Folder), typeof(UITypeEditor))]
        [Description("发布安装文件路径")]
        public string PublishPath
        {
            get { return Static.Settings.GetValue(Constant.PublishPath); }
            set { Static.Settings.SetValue(Constant.PublishPath, value); }
        }
    }
}
