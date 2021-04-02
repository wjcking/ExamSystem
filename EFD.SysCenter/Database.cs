using System.Windows.Forms;
 

namespace EFD.SysCenter
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
            Init();

        }

        /// <summary>
        /// 初始化listview
        /// </summary>
        private void Init()
        {
            ExamCategoryInfo[] fileList = Exam.DatabaseList;
            ListViewItem lvi = null;

            foreach (ExamCategoryInfo f in fileList)
            {
                ListViewItem.ListViewSubItem lsiLastAccessTime = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem lsiCreationTime = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem lsiFullName = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem lsiLastWriteTime = new ListViewItem.ListViewSubItem();

                lvi = new ListViewItem();
                lvi.Text = f.Name;
                lvi.ImageIndex = 0;

                lsiCreationTime.Text = f.CreationTime.ToString();

                lsiFullName.Text = f.FullName.ToString();
                lsiLastAccessTime.Text = f.LastAccessTime.ToString();
                lsiLastWriteTime.Text = f.LastWriteTime.ToString();

                lvi.SubItems.Add(lsiCreationTime);
                lvi.SubItems.Add(lsiFullName);
                lvi.SubItems.Add(lsiLastAccessTime);
                lvi.SubItems.Add(lsiLastWriteTime);

                lvExam.Items.Add(lvi);
            }
            //选择事件
            lvExam.SelectedIndexChanged += new System.EventHandler(lvExam_SelectedIndexChanged);


        }
        private void lvExam_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvExam.SelectedIndices != null && lvExam.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = lvExam.SelectedIndices;
                lbDetail.Text = lvExam.Items[c[0]].SubItems[2].Text;

            //     Cts.Encrypt.EncryptAccess(lbDetail.Text, false);
            //   Exam.SelectedFilePath = lvExam.Items[c[0]].SubItems[2].Text;
            }

        }

        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;

            switch (tsm.Name)
            {
                case "tsmLarge":
                    lvExam.View = View.LargeIcon;
                    return;
                case "tsmSmall":
                    lvExam.View = View.SmallIcon;
                    return;
                case "tsmDetails":
                    lvExam.View = View.Details;
                    return;
                case "tsmList":
                    lvExam.View = View.List;
                    return;
                case "tsmTile":
                    lvExam.View = View.Tile;
                    return;
            }
        }

        private void lvExam_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(lbDetail.Text))
                return;

            DialogResult = System.Windows.Forms.DialogResult.OK;

            if (lvExam.SelectedIndices != null && lvExam.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = lvExam.SelectedIndices;
       
                   Exam.SelectedFilePath = lvExam.Items[c[0]].SubItems[2].Text;
            }
            Static.Settings.SetValue(Constant.RecentFiles, Exam.SelectedFilePath);
            Close();
        }
    }
}
