using System.Windows.Forms;
using System;
using Model;
using System.Collections.Generic;

namespace EFD.SysCenter
{
    public partial class MainSubjectBoard : Form
    {
        private readonly Button[] buttonList;
       
        public int SelectedMainSubjectID { get; set; }

        public MainSubjectBoard(ConstInfo.QuestionType qt)
        {
            InitializeComponent();
            Text = Exam.SelectedFileName;
            List<MainSubjectInfo> list = Exam.GetMainSubjectListByQuestionType(qt);

            if (list.Count == 0)
            { 
                buttonList = new Button[1];
                buttonList[0] = new Button();
                buttonList[0].Name = "0";
                buttonList[0].Text = "目前尚无添加大题";
                buttonList[0].Click += new System.EventHandler(MainSubjectBoard_Click);
                buttonList[0].Dock = DockStyle.Bottom;
                buttonList[0].DialogResult = System.Windows.Forms.DialogResult.OK;
                Controls.Add(buttonList[0]);
                return;
            }

            buttonList = new Button[list.Count];

            for (int i = 0; i < buttonList.Length; i++)
            {
                buttonList[i] = new Button();
                buttonList[i].Name = list[i].ID.ToString();
                buttonList[i].Text = list[i].Subject;
                buttonList[i].Click += new System.EventHandler(MainSubjectBoard_Click);
                buttonList[i].Dock = DockStyle.Bottom;
                buttonList[i].DialogResult = System.Windows.Forms.DialogResult.OK;
                Controls.Add(buttonList[i]);
            }             
        }

        private void MainSubjectBoard_Click(object sender, System.EventArgs e)
        {
            Button b = sender as Button;
            SelectedMainSubjectID = Convert.ToInt32( b.Name);
        }
    }
}
