using System;
using System.ComponentModel;
using Model;
using ExamSys.Util;
using System.Text;

namespace ExamSys
{
    public partial class CategoryPicker : System.Windows.Forms.CheckedListBox
    {
        public CategoryPicker()
        {
            InitializeComponent();
        }

        public CategoryPicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string CategoryArray
        {
            get
            {
                bool isChecked = false;
                StringBuilder array = new StringBuilder();
                for (int i = 0; i < Items.Count; i++)
                {
                    if (!GetItemChecked(i))
                        continue;

                    isChecked = true;

                    ListItemExamInfo liExamInfo = Items[i] as ListItemExamInfo;
                    array.Append(liExamInfo.ID);
                    array.Append(",");
                }


                return isChecked ? array.ToString().Remove(array.ToString().LastIndexOf(','), 1) : String.Empty;
            }
        }

        /// <summary>
        /// 绑定试卷信息，包括分类
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="isShowAll">是否显示全部试题</param>
        public void BindExamCategory()
        {
            string category = "";

            foreach (ExamInfo ei in SysData.ExamInfoCategoryList)
            {
                //if (ei.PID == 0)
                //    continue;

                ListItemExamInfo liExamInfo = new ListItemExamInfo();
                SysData.GetExamCategoryByRecursion(ei.PID, ref category);
                //   liExamInfo.Index = ++index;
                liExamInfo.ID = ei.ID;
                liExamInfo.Text = category + ei.Name;
                liExamInfo.ExamInfo = ei;
                Items.Add(liExamInfo);
                category = String.Empty;

            }

            for (int i = 0; i < Items.Count; i++)
                SetItemChecked(i, true);

            SelectedIndex = 0;
            DisplayMember = "Text";
        }
    }
}
