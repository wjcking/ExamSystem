using System.Windows.Forms;
using Crownwood.Magic.Docking;
using System;
using EFD.SysCenter.Include;
using System.Drawing;

namespace EFD.SysCenter
{
    public partial class SysCenter : Form
    {
        public SysCenter()
        {
            InitializeComponent();
            Init();

        }

        private void LoadWorkspace()
        {
            Workspace ws = new Workspace();
            ws.OnStatusClick += new StatusEventHandler(OnStatusClick);
            ws.ucAddChoice.OnStatusClick += new StatusEventHandler(OnStatusClick);
            ws.ucModifyChoice.OnStatusClick += new StatusEventHandler(OnStatusClick);
            ws.ucFillBlank.OnStatusClick += new StatusEventHandler(OnStatusClick);
            ws.ucQuestion.OnStatusClick += new StatusEventHandler(OnStatusClick);
            ws.ucJudgement.OnStatusClick += new StatusEventHandler(OnStatusClick);
            ws.ucMedia.OnStatusClick += new StatusEventHandler(OnStatusClick);
            panelCenter.Controls.Clear();
            panelCenter.Controls.Add(ws);
            ws.Dock = DockStyle.Fill;
            lbStatus.Text = Exam.SelectedFileName;
            Text = Exam.SelectedFileName;
        }

        private void OnStatusClick(object sender, StatusEventArgs e)
        {
            if (e.IsHighlighted)
            {
                lbStatus.BackColor = Color.DarkBlue;
                lbStatus.ForeColor = Color.White;
            }
            else
            {
                lbStatus.BackColor = Color.DarkBlue;
                lbStatus.ForeColor = Color.White;
            }
            ControlBase cb = sender as ControlBase;
            switch (cb.Name)
            {
                case "Workspace":
                    Text = String.Format("{0} - {1}", Exam.SelectedFileName, e.Title);

                    break;
                case "AddChoice":
                    break;

                case "ModifyChoice":
                    break;
            }

            lbStatus.Text = e.Title;
        }


        private void Init()
        {
            //最近打开的
            tsmRecent.DropDownItems.Add(Static.Settings.GetValue(Constant.RecentFiles));
            tsmRecent.DropDownItems[0].Click += delegate
            {
                Exam.SelectedFilePath = tsmRecent.DropDownItems[0].Text;
                LoadWorkspace();
                tsmSubjectDetail.Visible = true;
            };

            //判断路径是否存在
            string databasePath = Static.Settings.GetValue(Constant.DatabasePath);
            if (!System.IO.Directory.Exists(databasePath))
            {
                Decorator.ShowDialog(new Config());
                Exam.DatabaseFolder = Static.Settings.GetValue(Constant.DatabasePath);

            }
            lbStatus.Text = "当前题库路径:" + Exam.DatabaseFolder;

        }


        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;

            if (tsm == null)
                return;

            switch (tsm.Name)
            {
                    case "menuMaterial":
                    MaterialWnd mw = new MaterialWnd();
                    mw.ShowDialog();
                    return;
                case "tsmTextProcess":
                    TextProcessor processor = new TextProcessor();
                    processor.Show();
                    return;
                case "tsmSubjectDetail":
                    SubjectDetailWnd wnd = new SubjectDetailWnd();
                    wnd.ShowDialog();
                    return;
                case "tsmNew":
                    if (Decorator.ShowDialog(new AddExam()) == System.Windows.Forms.DialogResult.OK)
                        LoadWorkspace();
                    return;
                case "tsmClose":
                    panelCenter.Controls.Clear();
                    tsmSubjectDetail.Visible = false;
                    return;
                case "tsmOption":
                    Decorator.ShowDialog(new Config());
                    return;
                case "tsmOpen":
                    DialogResult dr = Decorator.ShowDialog(new Database());

                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadWorkspace();
                        tsmSubjectDetail.Visible = true;
                    }

                    return;
                case "tsmOpenFolder":
                    System.Diagnostics.Process.Start(Exam.DatabaseFolder);
                    return;
                case "tsmRecent":

                    return;
                case "tsmExam":
                    return;
                case "tsmExit":
                    Environment.Exit(0);
                    return;
            }
        }



    }
}
