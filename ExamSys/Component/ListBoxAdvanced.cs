using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Model;
using ExamSys.Util;
using DataUtility;
using System.Data;

namespace ExamSys
{
    public partial class ListBoxAdvanced : ListBox
    {
        public ListBoxAdvanced()
        {
            InitializeComponent();
        }

        public ListBoxAdvanced(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void AddMessage(string message)
        {
            Items.Add(message);
            SelectedIndex = Items.Count - 1;
        }

        /// <summary>
        /// 绑定试卷信息，包括分类
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="isShowAll">是否显示全部试题</param>
        public  void BindExamInfo(bool isShowAll)
        {
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
          
            SelectedIndex = 0;
            DisplayMember = "Text";
        }

        public void GetProvince()
        {
            DataSource = AreaDAL.GetProvince();
           DisplayMember  = "province";
            ValueMember = "provinceid";
        }

        public void GetCitiesByProvinceID(string provinceID)
        {
            DataSource = AreaDAL.GetCitiesByProvinceID(provinceID);
            DisplayMember = "city";
            ValueMember = "CityID";
        }

        public void GetAreaByCityID(string cityID)
        {

            DataSource = AreaDAL.GetAreaByCityID(cityID); 
            DisplayMember = "area";
            ValueMember = "areaid";
        }

        private void ListBoxAdvanced_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
