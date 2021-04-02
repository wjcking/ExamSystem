using System;
using System.Data;
using System.Text;
using System.Collections.Generic;


using System.Data.Common;
using Model;

namespace DataUtility
{
    public class MajorSubject:AccessBasic
    {

        //private string databaseName;

        public MajorSubject()
        {
          
        }

        public MajorSubject(string conn)
        {
            databaseName = conn;
        }


        public int GetSubjectNumber(ConstInfo.QuestionType qt, int mainSubjectID, TemplateInfo temp)
        {
            AccessHelper db = new AccessHelper(databaseName);
            StringBuilder strSql = new StringBuilder();

            //单一检索记录
            //if (temp.IsCreatedByQuery)
            //    return temp.RecordCount;

            //返回多个检索记录，组卷
            if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Search)
            {
                HistoryInfo hi =    temp.GetHistoryInfoByMainSubjectID(mainSubjectID);
                return int.Parse(hi.RecordCount);
            }
            strSql.AppendFormat("select count(ID) from {0} where MainSubjectID= {1} and ExamInfoID = {2} ", qt, mainSubjectID, temp.ExamInfoID);


            if (temp != null)
            {

                if (temp.TestWay == ConstInfo.TestWay.正式考试 || temp.TestWay == ConstInfo.TestWay.试题学习)
                    strSql.Append(string.Empty);
                else if (temp.TestWay == ConstInfo.TestWay.我的收藏)
                    strSql.Append(" AND Fav = true");
                else if (temp.TestWay == ConstInfo.TestWay.错题重做)
                    strSql.Append(" AND InCorrectNo > 0");
            }

            

            int cmdresult;

            object obj = db.ExecuteScalar(strSql.ToString());

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                cmdresult = 0;
            else
                cmdresult = int.Parse(obj.ToString());


            return cmdresult;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string conditions)
        {
            AccessHelper db = new AccessHelper(databaseName);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MainSubject");

            if (!string.IsNullOrEmpty(conditions))
                strSql.Append("where " + conditions);

            
            //db.AddInParameter("ID", DbType.Int32,ID);
            //db.AddInParameter("Subject", DbType.AnsiString,Subject);
            //db.AddInParameter("TopicTypeID", DbType.String,TopicTypeID);
            //db.AddInParameter("EachPoint", DbType.AnsiString,EachPoint);
            //db.AddInParameter("Content", DbType.AnsiString,Content);
            //db.AddInParameter("PubDate", DbType.DateTime,PubDate);
            int cmdresult;
            object obj = db.ExecuteScalar(strSql.ToString());
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(MainSubjectInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MainSubject(");
            strSql.Append("Subject,TopicTypeID,EachPoint,Content,Sort)");

            strSql.Append(" values (");
            strSql.Append("@Subject,@TopicTypeID,@EachPoint,@Content,@Sort)");
            AccessHelper db = new AccessHelper(databaseName);
            

            db.AddInParameter("Subject", DbType.AnsiString, model.Subject);
            db.AddInParameter("TopicTypeID", DbType.Int16, model.TopicTypeID);
            db.AddInParameter("EachPoint", DbType.AnsiString, model.EachPoint);
            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            db.AddInParameter("Content", DbType.Int32, model.Sort);
      
            db.ExecuteNonQuery(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(MainSubjectInfo model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update MainSubject set ");

            strSql.Append("[Subject]=@Subject,");
            strSql.Append("[Sort]=@Sort,");
            strSql.Append("EachPoint=@EachPoint,");
            strSql.Append("[Content]=@Content");

            strSql.Append(" where ID=@ID ");
            AccessHelper db = new AccessHelper(databaseName);
            

            db.AddInParameter("[Subject]", DbType.AnsiString, model.Subject);
            db.AddInParameter("[Sort]", DbType.Int32, model.Sort);
            db.AddInParameter("EachPoint", DbType.AnsiString, model.EachPoint);
            db.AddInParameter("[Content]", DbType.AnsiString, model.Content);

            db.AddInParameter("ID", DbType.Int32, model.ID);
            int line = db.ExecuteNonQuery(strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MainSubject ");
            strSql.Append(" where ID=@ID");
            AccessHelper db = new AccessHelper(databaseName);
            
            db.AddInParameter("ID", DbType.Int32, ID);

            db.ExecuteNonQuery(strSql.ToString());

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MainSubjectInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from MainSubject ");
            strSql.Append(" where ID=@ID");

            AccessHelper db = new AccessHelper(databaseName);
            
            db.AddInParameter("ID", DbType.Int32, ID);


            MainSubjectInfo model = null;
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
        /// 得到一个对象实体
        /// </summary>
        public MainSubjectInfo GetModel(string query)
        {          

            AccessHelper db = new AccessHelper(databaseName);

            MainSubjectInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(query.ToString()))
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
        public List<MainSubjectInfo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM MainSubject  ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }


            List<MainSubjectInfo> list = new List<MainSubjectInfo>();
            AccessHelper db = new AccessHelper(databaseName);
            using (IDataReader dataReader = db.ExecuteReader( strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="examInfoID"></param>
        /// <returns></returns>
        public List<MainSubjectInfo> GetListArray(TemplateInfo temp)
        {
            StringBuilder strSql = new StringBuilder();

       
                strSql.Append("select ID,Subject,TopicTypeID,EachPoint,Content,PubDate,[Sort] ");
                strSql.Append(" FROM MainSubject ORDER BY [Sort] ASC");
            
            List<MainSubjectInfo> list = new List<MainSubjectInfo>();
            AccessHelper db = new AccessHelper(databaseName);

            using (IDataReader dataReader = db.ExecuteReader( strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    int typeID = Convert.ToInt32(dataReader["TopicTypeID"]);

                    ConstInfo.QuestionType qt = (ConstInfo.QuestionType)typeID;
                    int currentSubjectNumber = 0;

                    //MainSubjectID is dataReader["ID"]
                    switch (qt)
                    {
                        case ConstInfo.QuestionType.Selection:
                            currentSubjectNumber = (temp.IsShowSelection) ? GetSubjectNumber(qt, Convert.ToInt32(dataReader["ID"]), temp) : 0;
                            break;

                        case ConstInfo.QuestionType.Judgement:
                            currentSubjectNumber = (temp.IsShowJudgement) ? GetSubjectNumber(qt, Convert.ToInt32(dataReader["ID"]), temp) : 0;
                            break;

                        case ConstInfo.QuestionType.Fill:
                            currentSubjectNumber = (temp.IsShowFill) ? GetSubjectNumber(qt, Convert.ToInt32(dataReader["ID"]), temp) : 0;
                            break;

                        case ConstInfo.QuestionType.Question:
                            currentSubjectNumber = (temp.IsShowQuestion) ? GetSubjectNumber(qt, Convert.ToInt32(dataReader["ID"]), temp) : 0;
                            break;
                    }

                    if (currentSubjectNumber > 0)
                    {
                        MainSubjectInfo msi = ReaderBind(dataReader);
                        msi.SubjectSum = currentSubjectNumber;
                        list.Add(msi);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public MainSubjectInfo ReaderBind(IDataReader dataReader)
        {
            MainSubjectInfo model = new MainSubjectInfo();

           
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CurrentID = ojb.ToString();
                model.ID = (int)ojb;
            }

            //     model.SubjectSum = GetListArray("

            model.Subject = dataReader["Subject"].ToString();

            ojb = dataReader["TopicTypeID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TopicTypeID = (short)ojb;
                model.Type = Convert.ToInt32(ojb);
            }
            ojb = dataReader["EachPoint"];
            if (ojb != null && ojb != DBNull.Value)
                model.EachPoint = (float)ojb;

            model.Content = dataReader["Content"].ToString();
            //ojb = dataReader["PubDate"];

            //if (ojb != null && ojb != DBNull.Value)
            //{
            //    model.PubDate = (DateTime)ojb;
            //}

            ojb = dataReader["Sort"];

            if (ojb != null && ojb != DBNull.Value)
            {
                model.Sort = Convert.ToInt32(ojb);
            }
            return model;
        }

    }
}
