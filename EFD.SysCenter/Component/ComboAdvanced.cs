using System.Collections.Generic;
using System.ComponentModel;
using Model;
using System.Windows.Forms;

namespace EFD.SysCenter
{
    public partial class drpMainSubject : ComboBox
    {
        public drpMainSubject()
        {
            InitializeComponent();
        //    GetMainSubject(ConstInfo.QuestionType.Question);
        }

        public void BindMainSubject(ConstInfo.QuestionType qt)
        {
            List<MainSubjectInfo> mainSubjectList = Exam.GetMainSubjectListByQuestionType( qt);
            MainSubjectInfo first = new MainSubjectInfo();

            first.ID = -1;
            first.Subject = "所有大题";
            Items.Add(first);

            foreach (MainSubjectInfo msi in mainSubjectList)
                Items.Add(msi);

            DisplayMember = "Subject";
            ValueMember = "ID";
            
            SelectedIndex = 0;
        }
        //public void BindSubjectCount(int count)
        //{
        //    if (Items.Count < 0)
        //        return;

        //    Text = "[" + count.ToString() + "]" + Text;
        //}
        public drpMainSubject(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
