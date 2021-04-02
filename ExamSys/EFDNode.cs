using System.Windows.Forms;
using ExamSys.Util;
using ExamSys.Agency;
namespace ExamSys
{
    public partial class EFDNode : Form
    {
        private readonly PopulateNode populateNode;
        public event EFDNodeSelectEventHandler AfterEFDNodeSelected;

        public static bool IsActivated = false;

      

        public EFDNode()
        {
            InitializeComponent();
            populateNode = new PopulateNode(tvEFD);
            populateNode.DataBind(PopulateNode.NodeListType.ExamInfo);
            tvEFD.ExpandAll();
            Decorater.BindExamInfoToDropDownList(comboBox1);
        }

        class ExamInfoListItem
        {
            private int id;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private ExamInfoListItem next;

            public ExamInfoListItem Next
            {
                get { return next; }
                set { next = value; }
            }
        }

       

        public void OnEFDNodeSelected(EFDNodeSelectedEventArgs e)
        {
            if (AfterEFDNodeSelected != null)
            {
                AfterEFDNodeSelected(this, e);
            }
        }

        private void tvEFD_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "-1")
                return;

            int id = int.Parse(e.Node.Name);

            EFDNodeSelectedEventArgs efdNodeSelectedEventArgs = new EFDNodeSelectedEventArgs();

            efdNodeSelectedEventArgs.SelectedExamInfo = SystemData.GetExamListByID(id);
            OnEFDNodeSelected(efdNodeSelectedEventArgs);
        }

    }
}
