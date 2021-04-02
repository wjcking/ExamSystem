using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace ExamSys.Util
{
    public class Decorater
    {
        private Form form;
        private DataGridView dataGridView;
        private Dictionary<string, Form> initializedForm = new Dictionary<string, Form>();

        /// <summary>
        /// 获取初始化窗口的实例
        /// </summary>
        public Dictionary<string, Form> InitializedForm
        {
            get { return initializedForm; }
        }

        public Decorater()
        {
             initializedForm.Add("Submit", null);
            initializedForm.Add("EFDBrowser", null);
            initializedForm.Add("EasyChart", null);
            initializedForm.Add("SearchTask", null);
            initializedForm.Add("History", null);
            initializedForm.Add("Regroup", null);

        }

    

        /// <summary>
        /// 打开新窗口，如果已经打开则激活
        /// </summary>
        /// <param name="formType"></param>
        public Form Activate(Type formType)
        {
            string formName = formType.Name;

            if (initializedForm[formName] == null)
            {
                switch (formName)
                {
                 
                    case "EFDBrowser":
                        initializedForm[formName] = new EFDBrowser();
                        break;
                    case "EasyChart":
                        initializedForm[formName] = new EasyChart();
                        break;
                    case "SearchTask":
                        initializedForm[formName] = new SearchTask();
                        break;
                    case "History":
                        initializedForm[formName] = new History();
                        break;
                     case "Regroup":
                        initializedForm[formName] = new Regroup();
                        break;
                     case "Submit":
                        initializedForm[formName] = new Submit();
                        break;

                }
                initializedForm[formName].Show();
                initializedForm[formName].FormClosing += delegate
                {
                    initializedForm[formName].Dispose();
                    initializedForm[formName] = null;
                };

            }
            else
            {
                initializedForm[formName].WindowState = (initializedForm[formName].WindowState == FormWindowState.Minimized) ? FormWindowState.Normal : initializedForm[formName].WindowState;
                initializedForm[formName].Activate();
            }

            return initializedForm[formName];
        }


        /// <summary>
        /// 按ESC关闭窗口
        /// </summary>
        /// <param name="form"></param>
        public void FormCloseByKeyUp(Form form)
        {

            this.form = form;
            this.form.KeyUp += new KeyEventHandler(FormClose_KeyUp);
        }

        /// <summary>
        /// 数据网格画出行号
        /// </summary>
        /// <param name="dataGridView"></param>
        public void DrawDataGridRowNumber(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            this.dataGridView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgv_RowPostPaint);
        }


      
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                             e.RowBounds.Location.Y,
                                             dataGridView.RowHeadersWidth - 4,

                                               e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                 dataGridView.RowHeadersDefaultCellStyle.Font,
                                  rectangle,
                                 dataGridView.RowHeadersDefaultCellStyle.ForeColor,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void FormClose_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                form.Close();
        }
    }
}
