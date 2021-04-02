using Model;
using System.Data;
using System.Text;
using System;

namespace DataUtility
{
    /// <summary>
    /// 这里面都是windows界面调用的
    /// </summary>
    public partial class ExamSys
    {
        public int RefreshInCorrectNoByExamInfoID(string examInfoID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            int sum = 0;
            string query = string.Format("UPDATE Selection SET  InCorrectNo = 0 WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Judgement SET InCorrectNo = 0 WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Fill SET InCorrectNo = 0 WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Question SET InCorrectNo = 0 WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE ExamInfo SET [IncorrectCount] = 0 WHERE [ID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            return sum;
        }

        public int RefreshFavByExamInfoID(ConstInfo.QuestionType quest, string examInfoID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = string.Format("UPDATE {0}  \r\n SET [Fav] = false WHERE [ExamInfoID] = {1}", quest, examInfoID);
            return db.ExecuteNonQuery(query);
        }

        public int RefreshUserAnswersByExamInfoID(ConstInfo.QuestionType quest, string answer, string examInfoID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = string.Format("UPDATE {0}  \r\n SET [Answer] = '' WHERE [ExamInfoID] = {1}", quest, examInfoID);
            return db.ExecuteNonQuery(query);
        }

        public int RefreshUserAnswersByMainSubjectID(ConstInfo.QuestionType quest, string answer, string mainSubjectID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = string.Format("UPDATE {0}  \r\n SET [Answer] = '' WHERE [MainSubjectID] = {1}", quest, mainSubjectID);
            return db.ExecuteNonQuery(query);
        }

        public int RefreshFav()
        {

            int sum = 0;
            AccessHelper db = new AccessHelper(databaseName);
            string query = "UPDATE Selection SET [Fav] = false";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Judgement SET [Fav] = false";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Fill SET [Fav] = false";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Question SET [Fav] = false";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE ExamInfo SET [FavCount] = 0";
            sum += db.ExecuteNonQuery(query);

            return sum;
        }

        public int RefreshInCorrect()
        {
            AccessHelper db = new AccessHelper(databaseName);
            int sum = 0;
            string query = "UPDATE Selection SET  InCorrectNo = 0";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Judgement SET InCorrectNo = 0";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Fill SET InCorrectNo = 0";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Question SET InCorrectNo = 0";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE ExamInfo SET [IncorrectCount] = 0";
            sum += db.ExecuteNonQuery(query);
            return sum;
        }

        public int RefreshUserAnswers()
        {
            AccessHelper db = new AccessHelper(databaseName);
            int sum = 0;
            string query = "UPDATE Selection SET [Answer] = ''";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Judgement SET [Answer] = ''";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Fill SET [Answer] = ''";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE Question SET [Answer] = ''";
            sum += db.ExecuteNonQuery(query);
            query = "UPDATE ExamInfo SET [EmptyCount] = TotalCount";
            sum += db.ExecuteNonQuery(query);
            return sum;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RegisterInfo RegisterInfo
        {
            get
            {
                AccessHelper db = new AccessHelper(databaseName);
                string strSql = "SELECT TOP 1 ValidXML,ProductName FROM Easy";

                RegisterInfo regInfo = new RegisterInfo();
                using (IDataReader dataReader = db.ExecuteReader(strSql))
                {
                    if (dataReader.Read())
                    {
                        regInfo.ValidXml = dataReader["ValidXML"].ToString();
                        regInfo.ProductName = dataReader["ProductName"].ToString();
                    }
                }
                return regInfo;
            }
        }

        public int UpdateRegisterInfo(string encryptedXml, string productName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Easy set ");
            strSql.Append("ValidXML=@ValidXML");
            strSql.Append(",ProductName=@ProductName");
            AccessHelper db = new AccessHelper(databaseName);
            db.AddInParameter("ValidXML", DbType.AnsiString, encryptedXml);
            db.AddInParameter("ProductName", DbType.AnsiString, productName);
            return db.ExecuteNonQuery(strSql.ToString());
        }
        public int UpdateRegisterInfo(string encryptedXml)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Easy set ");
            strSql.Append("ValidXML=@ValidXML");
            AccessHelper db = new AccessHelper(databaseName);
            db.AddInParameter("ValidXML", DbType.AnsiString, encryptedXml);
            return db.ExecuteNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 模拟考试sql
        /// </summary>
        /// <param name="ri"></param>
        /// <returns></returns>
        public static RegroupQuery GetRegroupQuery(RegroupQuery ri)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder countQuery = new StringBuilder();
            AccessHelper acc = new AccessHelper();
            int result = 1;

            string condition = "";
            switch (ri.TestWay)
            {
                case ConstInfo.TestWay.正式考试:
                case ConstInfo.TestWay.计时考试:
                    countQuery.AppendFormat(" SELECT count(*) ", ri.RecordMax);
                    countQuery.AppendFormat(" FROM {0} AS t LEFT JOIN ExamInfo AS e ON e.ID=t.ExamInfoID ", ri.QuestionType);
                    countQuery.AppendFormat(" WHERE t.MainSubjectID = {0}", ri.MainSubjectID);
                    countQuery.AppendFormat(" AND e.PID in ({0}) ", ri.CategoryArray);
                    break;
                case ConstInfo.TestWay.错题重做:


                    condition = " AND t.IncorrectNo > 0  ";
                    countQuery.AppendFormat(" SELECT count(*) ", ri.RecordMax);
                    countQuery.AppendFormat(" FROM {0} AS t LEFT JOIN ExamInfo AS e ON e.ID=t.ExamInfoID ", ri.QuestionType);
                    countQuery.AppendFormat(" WHERE t.MainSubjectID = {0}", ri.MainSubjectID);
                    countQuery.AppendFormat(" AND e.PID in ({0}) ", ri.CategoryArray);
                    countQuery.Append(condition);

                    break;
                case ConstInfo.TestWay.我的收藏:


                    condition = " AND t.Fav = true  ";
                    countQuery.AppendFormat(" SELECT count(*) ", ri.RecordMax);
                    countQuery.AppendFormat(" FROM {0} AS t LEFT JOIN ExamInfo AS e ON e.ID=t.ExamInfoID ", ri.QuestionType);
                    countQuery.AppendFormat(" WHERE t.MainSubjectID = {0}", ri.MainSubjectID);
                    countQuery.AppendFormat(" AND e.PID in ({0}) ", ri.CategoryArray);
                    countQuery.Append(condition);
                    break;
            }

            result =  Convert.ToInt32(acc.ExecuteScalar(countQuery.ToString()));
            ri.RecordMax = result > ri.RecordMax ? ri.RecordMax : result;

            if (ri.RecordMax == 0)
                return null;


            switch (ri.QuestionType)
            {
                case ConstInfo.QuestionType.Selection:
                    query.AppendFormat(" SELECT TOP {0} e.PID AS CategoryID, e.Name AS CategoryName, t.* ", ri.RecordMax);
                    query.Append(" FROM Selection AS t LEFT JOIN ExamInfo AS e ON e.ID=t.ExamInfoID ");
                    query.AppendFormat(" WHERE t.MainSubjectID = {0}", ri.MainSubjectID);
                    query.AppendFormat(" AND e.PID in ({0}) ", ri.CategoryArray);
                    query.Append(condition);
                    query.AppendFormat(" ORDER BY Rnd(-(1*{0}*t.ID)); ", ri.RndNumber);
                    break;

                case ConstInfo.QuestionType.Fill:
                    query.AppendFormat(" SELECT TOP {0} e.PID AS CategoryID, e.Name AS CategoryName, t.* ", ri.RecordMax);
                    query.Append(" FROM Fill AS t LEFT JOIN ExamInfo AS e ON e.ID=t.ExamInfoID ");
                    query.AppendFormat(" WHERE t.MainSubjectID = {0} ", ri.MainSubjectID);
                    query.AppendFormat(" AND e.PID in ({0}) ", ri.CategoryArray);
                    query.Append(condition);
                    query.AppendFormat(" ORDER BY Rnd(-(1*{0}*t.ID)); ", ri.RndNumber);
                    break;

                case ConstInfo.QuestionType.Judgement:
                    query.AppendFormat(" SELECT TOP {0} e.PID AS CategoryID, e.Name AS CategoryName, t.* ", ri.RecordMax);
                    query.Append(" FROM Judgement AS t LEFT JOIN ExamInfo AS e ON e.ID=t.ExamInfoID ");
                    query.AppendFormat(" WHERE t.MainSubjectID = {0} ", ri.MainSubjectID);
                    query.AppendFormat(" AND e.PID in ({0}) ", ri.CategoryArray);
                    query.Append(condition);
                    query.AppendFormat(" ORDER BY Rnd(-(1*{0}*t.ID)); ", ri.RndNumber);
                    break;

                case ConstInfo.QuestionType.Question:
                    query.AppendFormat(" SELECT TOP {0} e.PID AS CategoryID, e.Name AS CategoryName, t.* ", ri.RecordMax);
                    query.Append(" FROM Question AS t LEFT JOIN ExamInfo AS e ON e.ID=t.ExamInfoID ");
                    query.AppendFormat(" WHERE t.MainSubjectID = {0} ", ri.MainSubjectID);
                    query.AppendFormat(" AND e.PID in ({0}) ", ri.CategoryArray);
                    query.Append(condition);
                    query.AppendFormat(" ORDER BY Rnd(-(1*{0}*t.ID)); ", ri.RndNumber);
                    break;
            }

            ri.SqlQuery = query.ToString();
            return ri;
        }
    }
}
