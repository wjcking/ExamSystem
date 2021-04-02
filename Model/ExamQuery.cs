using System.Text;

namespace Model
{
    public class ExamQuery
    {
        private int mainSubjectID = -1;

        public int MainSubjectID
        {
            get { return mainSubjectID; }
            set { mainSubjectID = value; }
        }
       // public bool IsMaterial { get; set; }
        public string MainSubjectName { get; set; }
        public string SubjectName { get; set; }
        public int ExamInfoID { get; set; }

        public int SubjectID { get; set; }
        public string Keyword { get; set; }
        public ConstInfo.QuestionType QuestionType { get; set; }
        public string Query
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" 1 = 1 ");
                sql.AppendFormat("AND ExamInfoID = {0} ", ExamInfoID);

                if (mainSubjectID > 0)
                    sql.AppendFormat("AND MainSubjectID ={0} ", MainSubjectID);

                if (!string.IsNullOrEmpty(Keyword))
                    sql.AppendFormat("AND [Subject] like \"%{0}%\" ", Keyword);

                sql.Append("  ORDER BY MainSubjectID , ID ");
                return sql.ToString();
            }
        }
    }
}
