using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using Model;

namespace DataUtility
{
    /// <summary>

    /// </summary>
    public partial class ExamSys : AccessBasic
    {
        //private string databaseName; 

        public ExamSys()
        {

        }

        public ExamSys(string conn)
        {
            databaseName = conn;
        }

        /// <summary>
        /// 删除试卷以及相关试题
        /// </summary>
        /// <param name="examInfoID"></param>
        public int Delete(int examInfoID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            StringBuilder deletion = new StringBuilder();

            int materialCount = db.ExecuteNonQuery(String.Format("DELETE * FROM ExamInfo WHERE PID={0}  ", examInfoID));

            if (materialCount > 0)
                return -100;

            db.ExecuteNonQuery(String.Format("DELETE * FROM ExamInfo WHERE ID={0}  ", examInfoID));
            db.ExecuteNonQuery(String.Format("DELETE * FROM Selection WHERE ExamInfoID={0}  ", examInfoID));
            db.ExecuteNonQuery(String.Format("DELETE * FROM Judgement WHERE ExamInfoID={0}  ", examInfoID));
            db.ExecuteNonQuery(String.Format("DELETE * FROM Fill WHERE ExamInfoID={0}  ", examInfoID));
            db.ExecuteNonQuery(String.Format("DELETE * FROM Question WHERE ExamInfoID={0}  ", examInfoID));
            db.ExecuteNonQuery(String.Format("DELETE * FROM ExamResult WHERE ExamInfoID={0}  ", examInfoID));

            return 0;

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ExamInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ExamInfo(");
            strSql.Append("[Name],PubDate,[Time],Content,IsMaterial,PID,CanRandom)");

            strSql.Append(" values (");
            strSql.Append("@Name,@PubDate,@Time,@Content,@IsMaterial,@PID,@CanRandom)");

            AccessHelper db = new AccessHelper(databaseName);

            db.AddInParameter("Name", DbType.AnsiString, model.Name);
            db.AddInParameter("PubDate", DbType.DateTime, model.PubDate);
            db.AddInParameter("Time", DbType.String, model.Time);
            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            db.AddInParameter("IsMaterial", DbType.Boolean, model.IsMaterial);
            db.AddInParameter("PID", DbType.Int32, model.PID);
            db.AddInParameter("CanRandom", DbType.Boolean, model.CanRandom);


            db.ExecuteNonQuery(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ExamInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ExamInfo set ");
            strSql.Append("[Name]=@Name,");
            //strSql.Append("PubDate=@PubDate,");
            strSql.Append("[Time]=@Time,");
            strSql.Append("[Content]=@Content,");
            strSql.Append("IsMaterial=@IsMaterial,");
            //	strSql.Append("PID=@PID,");
            strSql.Append("CanRandom=@CanRandom");

            strSql.Append(" where ID=@ID ");
            AccessHelper db = new AccessHelper(databaseName);

            db.AddInParameter("Name", DbType.AnsiString, model.Name);
            //db.AddInParameter("PubDate", DbType.DateTime, model.PubDate);
            db.AddInParameter("Time", DbType.String, model.Time);
            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            db.AddInParameter("IsMaterial", DbType.Boolean, model.IsMaterial);
            //db.AddInParameter("PID", DbType.Int32, model.PID);
            db.AddInParameter("CanRandom", DbType.Boolean, model.CanRandom);
            db.AddInParameter("ID", DbType.Int32, model.ID);
            db.ExecuteNonQuery(strSql.ToString());

        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ExamInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from ExamInfo ");
            strSql.Append(" where [ID]=@ID ");
            AccessHelper db = new AccessHelper(databaseName);



            db.AddInParameter("ID", DbType.Int32, ID);
            ExamInfo model = new ExamInfo();
            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }




        /// <summary>
        /// 获得数据列表 
        /// </summary>
        public List<ExamInfo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ExamInfo ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            else
            {
                strSql.Append(" ORDER BY ID ASC ");
            }

            return GetListByQuery(strSql.ToString());

        }

        /// <summary>
        /// 注册使用，去前百分之30个
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<ExamInfo> GetListByQuery(string query)
        {

            List<ExamInfo> list = new List<ExamInfo>();

            AccessHelper access = new AccessHelper(databaseName);
            using (IDataReader dataReader = access.ExecuteReader(query))
            {
                while (dataReader.Read())
                {
                    ExamInfo ei = ReaderBind(dataReader);
                    ei.TotalCount = dataReader["TotalCount"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["TotalCount"]);
                    ei.IncorrectCount = dataReader["IncorrectCount"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["IncorrectCount"]);
                    ei.EmptyCount = dataReader["EmptyCount"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["EmptyCount"]);
                    ei.FavCount = dataReader["FavCount"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["FavCount"]);
                    list.Add(ei);

                }
            }
            return list;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public ExamInfo ReaderBind(IDataReader dataReader)
        {
            ExamInfo model = new ExamInfo();

            object ojb;
            model.Name = dataReader["Name"].ToString();
            ojb = dataReader["PubDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PubDate = (DateTime)ojb;
            }
            model.Time = Convert.ToInt32(dataReader["Time"]);

            model.Content = dataReader["Content"].ToString();
            ojb = dataReader["IsMaterial"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsMaterial = (bool)ojb;
            }
            ojb = dataReader["PID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PID = (int)ojb;
            }
            ojb = dataReader["CanRandom"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CanRandom = (bool)ojb;
            }
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }

            ojb = dataReader["TestTimes"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TestTimes = (int)ojb;
            }
            ojb = dataReader["Keyword"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Keyword = ojb.ToString();
            }
            ojb = dataReader["LastTestTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastTestTime = ojb.ToString();
            }
            return model;
        }

        public int RefreshFavByExamInfoID(string examInfoID)
        {
            AccessHelper db = new AccessHelper(databaseName);

            int sum = 0;
            string query = string.Format("UPDATE Selection SET [Fav] = false WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Judgement SET [Fav] = false WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Fill SET [Fav] = false WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Question SET [Fav] = false WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE ExamInfo SET [FavCount] = 0 WHERE [ID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            return sum;
        }

        public int RefreshUserAnswersByExamInfoID(string examInfoID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            int sum = 0;
            string query = string.Format("UPDATE Selection SET [Answer] = '' WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Judgement SET [Answer] = '' WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Fill SET [Answer] = '' WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            query = string.Format("UPDATE Question SET [Answer] = '' WHERE [ExamInfoID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query); 
            query = string.Format("UPDATE ExamInfo SET [EmptyCount] = TotalCount WHERE [ID] = {0}  \r\n", examInfoID);
            sum += db.ExecuteNonQuery(query);
            return sum;
        }



        public int UpdateUserAnswers(ConstInfo.QuestionType quest, string answer, string id)
        {
            string query = string.Format("UPDATE {0}  \r\n SET [Answer] = @Answer WHERE [ID] = @ID", quest);

            AccessHelper db = new AccessHelper(databaseName);

            db.AddInParameter("Answer", DbType.AnsiString, answer);
            db.AddInParameter("ID", DbType.Int32, int.Parse(id));
            return db.ExecuteNonQuery(query.ToString());

        }

        public int UpdateNote(ConstInfo.QuestionType quest, string note, string id)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = string.Format("UPDATE {0}  \r\n SET Note = {1} WHERE ID = {2}", quest, note, id);
            return db.ExecuteNonQuery(query);
        }

        public int UpdateFav(ConstInfo.QuestionType quest, string fav, string id)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = string.Format("UPDATE {0}  \r\n SET Fav = {1} WHERE ID = {2}", quest, fav, id);
            return db.ExecuteNonQuery(query);
        }

        public int UpdateInCorrectNo(ConstInfo.QuestionType quest, int inCorrectNo, string id)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = "";

            if (inCorrectNo == 0)
                query = string.Format("UPDATE {0}  \r\n SET InCorrectNo = 0 WHERE ID = {1}", quest, id);
            else
                query = string.Format("UPDATE {0}  \r\n SET InCorrectNo = InCorrectNo +1 WHERE ID = {1}", quest, id);

            return db.ExecuteNonQuery(query);
        }

        public int UpdateCorrectionType(ConstInfo.QuestionType quest, string correctionType, string id)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = string.Format("UPDATE {0}  \r\n SET CorrectionType = '{1}'  WHERE ID = {2}", quest, correctionType, id);
            return db.ExecuteNonQuery(query);
        }

        public int UpdateKey(ConstInfo.QuestionType quest, int id, string key)
        {
            string query = string.Format("UPDATE {0}  \r\n SET [Key] = @Key WHERE ID = {1}", quest, id);

            AccessHelper db = new AccessHelper(databaseName);

            db.AddInParameter("Key", DbType.AnsiString, key);

            return db.ExecuteNonQuery(query.ToString());

        }

        public int UpdateAnalysis(ConstInfo.QuestionType quest, int id, string analysis)
        {
            string query = string.Format("UPDATE {0}  \r\n SET [analysis] = @analysis WHERE ID = {1}", quest, id);

            AccessHelper db = new AccessHelper(databaseName);

            db.AddInParameter("analysis", DbType.AnsiString, analysis);

            return db.ExecuteNonQuery(query.ToString());

        }

        public int UpdateMainSubjectID(ConstInfo.QuestionType quest, int id, int mainSubjectID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            string query = string.Format("UPDATE {0}  \r\n SET MainSubjectID = {1} WHERE ID = {2}", quest, mainSubjectID, id);
            return db.ExecuteNonQuery(query);
        }




    }
}

