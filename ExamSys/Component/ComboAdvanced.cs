using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using ExamSys.Util;
using Model;

namespace ExamSys
{
    public partial class ComboAdvanced : ComboBox
    {
        public ComboAdvanced()
        {
            InitializeComponent();
        }

        public ComboAdvanced(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// 绑定试卷信息，包括分类
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="isShowAll">是否显示全部试题</param>
        public   void BindExamInfo( bool isShowAll)
        {
            DropDownStyle = ComboBoxStyle.DropDownList;

            string category = "";

            if (isShowAll && Valid.IsRegistered)
                Items.Add("全部试题");

            int index = 0;
            foreach (ExamInfo ei in SysData.ExamInfoListWithoutCategory)
            {
                ListItemExamInfo liExamInfo = new ListItemExamInfo();
                SysData.GetExamCategoryByRecursion(ei.PID, ref category);
                liExamInfo.ID = ei.ID;
                liExamInfo.Text = category + ei.Name;
                liExamInfo.ExamInfo = ei;
                Items.Add(liExamInfo);
                category = String.Empty;
                index++;
            }

          //  ListItemExamInfo.Index = 0;
            IntegralHeight = false;
            MaxDropDownItems = 20;
            SelectedIndex = 0;
            DropDownWidth = 650;
            DisplayMember = "Text";
        }
    }
}
