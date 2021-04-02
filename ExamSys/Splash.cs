using System.Windows.Forms;

namespace ExamSys
{
    public partial class Splash : Form
    {

        //初始化画面
        private readonly static string SplashPhoto = Application.StartupPath + @"\images\" +System.Configuration.ConfigurationManager.AppSettings["Splash"];

        public Splash()
        {
            InitializeComponent();
            BackgroundImage = System.Drawing.Image.FromFile(SplashPhoto);

           // lbTitle.Text = Settings.helper.GetSettingsElement(Settings.Title);

            //lbTitle.Text = Valid.EfdInfo.Title;// string.IsNullOrEmpty(Valid.EfdInfo.Title) ? "易方得考试系统" : lbTitle.Text;
	        lbTitle.Text = "易方得考试系统";

            string lastExamSubject = SysConfig.SettingsHelper.GetValue(Settings.LastExamSubject);

            lblLastExamSubject.Text = string.IsNullOrEmpty(lastExamSubject) ? string.Empty : "上次：" + lastExamSubject;
        }
    }
}
