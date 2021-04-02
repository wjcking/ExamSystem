using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ExamSys.Options
{
    public partial class FileFolder : UserControl
    {
        public const string LibraryPath = "LibraryPath";
        public FileFolder()
        {
            InitializeComponent();
            txtFolder.Text = SysConfig.SettingsHelper.GetValue(LibraryPath);
        }
        /// <summary>
        /// 择本系统或相关文件目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folders = new FolderBrowserDialog();

            if (folders.ShowDialog() == DialogResult.OK)
            {
                if (folders.SelectedPath.IndexOf(Application.StartupPath) > -1)
                {
                    MessageBox.Show("您不能选择本系统或相关文件目录，请重新选择？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtFolder.Text = folders.SelectedPath;
            }
        }

        public void Save()
        {
            if (System.IO.Directory.Exists(txtFolder.Text))
                SysConfig.SettingsHelper.SetValue(LibraryPath, txtFolder.Text);
        }
    }
}
