using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using System.Data.Common;
using Model;
using System.Data.OleDb;

namespace DataUtility
{
    public class ExamHistory : AccessBasic
    {

        //private string databaseName;

        public ExamHistory()
        {
 
        }

        
        public ExamHistory(string conn)
        {
            databaseName = conn;
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(HistoryInfo hi)
        {
            AccessHelper db = new AccessHelper(databaseName);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from history where 1 = 1 and  Keyword=@Keyword and SearchType=@SearchType and RecordCount=@RecordCount and PageNumber=@PageNumber  and  MainSubjectID=@MainSubjectID and ExamInfoID=@ExamInfoID  ");
                      
                         
            db.AddInParameter("Keyword", DbType.AnsiString, hi.Keyword);
            db.AddInParameter("SearchType", DbType.AnsiString, hi.SearchType);
            db.AddInParameter("RecordCount", DbType.AnsiString, hi.RecordCount);           
            db.AddInParameter("PageNumber", DbType.AnsiString, hi.PageNumber);                        
            db.AddInParameter("MainSubjectID", DbType.Int32, hi.MainSubjectID);
            db.AddInParameter("ExamInfoID", DbType.Int32, hi.ExamInfoID);
            
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
        public void Add(HistoryInfo model)
        {
    

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into history(");
            strSql.Append(" MainSubject,ExamInfoName,Keyword,SearchType,RecordCount,PageNumber,Testway,SqlRecordCount,SqlSearch,Score,MainSubjectID,ExamInfoID,TestTimes, [Percent])");

            strSql.Append(" values (");
            strSql.Append(" @MainSubject,@ExamInfoName,@Keyword,@SearchType,@RecordCount,@PageNumber,@Testway,@SqlRecordCount,@SqlSearch,@Score,@MainSubjectID,@ExamInfoID,@TestTimes, @Percent)");
            AccessHelper db = new AccessHelper(databaseName);
            

            db.AddInParameter("MainSubject", DbType.AnsiString, model.MainSubject);
            db.AddInParameter("ExamInfoName", DbType.AnsiString, model.ExamInfoName);
            db.AddInParameter("Keyword", DbType.AnsiString, model.Keyword);
            db.AddInParameter("SearchType", DbType.AnsiString, model.SearchType);
            db.AddInParameter("RecordCount", DbType.AnsiString, model.RecordCount);
            db.AddInParameter("PageNumber", DbType.AnsiString, model.PageNumber);
            db.AddInParameter("Testway", DbType.AnsiString, model.Testway);
            db.AddInParameter("SqlRecordCount", DbType.AnsiString, model.SqlRecordCount);
            db.AddInParameter("SqlSearch", DbType.AnsiString, model.SqlSearch);
            db.AddInParameter("Score", DbType.AnsiString, model.Score);
            
            db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
            db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);
            db.AddInParameter("TestTimes", DbType.Int32, model.TestTimes);
            db.AddInParameter("Percent", DbType.AnsiString, model.Percent);
            db.ExecuteNonQuery(strSql.ToString());
        }
   

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HistoryInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from history ");
            strSql.Append(" where ID=@ID  ");
            AccessHelper db = new AccessHelper(databaseName);
            
            db.AddInParameter("ID", DbType.Int32, ID);
      
            HistoryInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        public List<HistoryInfo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top 5000 * ");
            strSql.Append(" FROM history ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<HistoryInfo> list = new List<HistoryInfo>();
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
        /// 对象实体绑定数据
        /// </summary>
        public HistoryInfo ReaderBind(IDataReader dataReader)
        {
            HistoryInfo model = new HistoryInfo();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            model.MainSubject = dataReader["MainSubject"].ToString();
            model.ExamInfoName = dataReader["ExamInfoName"].ToString();
            model.Keyword = dataReader["Keyword"].ToString();
            model.SearchType = dataReader["SearchType"].ToString();
            model.RecordCount = dataReader["RecordCount"].ToString();
            model.PageNumber = dataReader["PageNumber"].ToString();
            model.Testway = dataReader["Testway"].ToString();
            model.SqlRecordCount = dataReader["SqlRecordCount"].ToString();
            model.SqlSearch = dataReader["SqlSearch"].ToString();
            model.Score = dataReader["Score"].ToString();

            ojb = dataReader["PubDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PubDate = (DateTime)ojb;
            }
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PubDate = (DateTime)ojb;
            }
            ojb = dataReader["MainSubjectID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MainSubjectID = (int)ojb;
            }
            ojb = dataReader["ExamInfoID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ExamInfoID = (int)ojb;
            }
            ojb = dataReader["TestTimes"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TestTimes = (int)ojb;
            }
			        ojb = dataReader["Percent"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Percent = ojb.ToString();
            }
            return model;
        }

    }
}
