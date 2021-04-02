using System.Windows.Forms;
using Model;
using System;

namespace EFD.SysCenter.Include
{
    public partial class ControlBase : UserControl
    {

        protected StatusEventArgs statusEventArgs = new StatusEventArgs();
        public event StatusEventHandler OnStatusClick;
        private bool isInitialized = false;
        private ExamQuery examQuery = null;

        /// <summary>
        /// 事件委托执行，执行主窗体
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnStatus(StatusEventArgs e)
        {
            if (OnStatusClick != null)
            {
                OnStatusClick(this, e);
            }
        }

        public virtual ExamQuery ExamQuery
        {
            get { return examQuery; }
            set { examQuery = value; }
        }
        /// <summary>
        /// 是否执行了初始化函数
        /// </summary>
        public bool IsInitialized
        {
            get { return isInitialized; }
            set { isInitialized = value; }
        }

       // 载入试题数据 
        //public virtual void Initialize(ExamQuery eq)
        //{
        //    isInitialized = true;           
        //}
        //public virtual int Add(ExamItemInfo item)
        //{
        //    return 0;
        //} 
        
        //public virtual int Add(ExamItemInfo[] items)
        //{
        //    return 0;
        //}

        //public virtual int Update(ExamItemInfo item)
        //{
        //    return 0;
        //}
        //public virtual int Update(ExamItemInfo[] item)
        //{
        //    return 0;
        //}

        //public virtual int Delete(int id)
        //{
        //    return 0;
        //}

        //public virtual int Delete(int[] id)
        //{
        //    return 0;
        //}

        /// <summary>
        /// 初始化，如果执行了，就不在执行了
        /// </summary>
        public virtual void Initialize()
        {
            //InitializeComponent();
            
            isInitialized = true;
        }

        public virtual void ButtonClick(object sender, EventArgs e) 
        {

        }

        public   ControlBase()
        {
            
        }



    }
}
