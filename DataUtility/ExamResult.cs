
using System;
using System.Text;
using System.Data;
using System.Collections.Generic;


using Model;
namespace DataUtility
{
    public class ExamResult : AccessBasic
    {

        //private string databaseName;

        public ExamResult()
        {
        
        }

        public ExamResult(string conn)
        {
            databaseName = conn;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ExamResultInfo model)
        {
                  
    
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ExamResult(");
            strSql.Append("ExamInfoID,[Name],TestWay,Content,IsLimitedTime,DisplayStyle,TestedSubject,TestedScore,CorrectNum)");

            strSql.Append(" values (");
            strSql.Append("@ExamInfoID,@Name,@TestWay,@Content,@IsLimitedTime,@DisplayStyle,@TestedSubject,@TestedScore,@CorrectNum)");
            AccessHelper db = new AccessHelper(databaseName);
            

            db.AddInParameter("ExamInfoID", DbType.String, model.ExamInfoID);

            db.AddInParameter("Name", DbType.AnsiString, model.Name);
            db.AddInParameter("TestWay", DbType.AnsiString, model.TestWay);
            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            db.AddInParameter("IsLimitedTime", DbType.Boolean, model.IsLimitedTime);
            db.AddInParameter("DisplayStyle", DbType.String, model.DisplayStyle);
            db.AddInParameter("TestedSubject", DbType.String, model.TestedSubject);
            db.AddInParameter("TestedScore", DbType.String, model.TestedScore);
            db.AddInParameter("CorrectNum", DbType.String, model.CorrectNum);
            db.ExecuteNonQuery(strSql.ToString());

            //更新考试次数
            //string updateExamInfoQuery = "UPDATE ExamInfo SET TestTimes = TestTimes + 1 WHERE ID = " + model.ExamInfoID.ToString();

          //  db.ExecuteNonQuery(updateExamInfoQuery);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ExamResultInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ExamResult set ");
            strSql.Append("ID=@ID,");
            strSql.Append("ExamInfoID=@ExamInfoID,");
            strSql.Append("PubDate=@PubDate,");
            strSql.Append("Name=@Name,");
            strSql.Append("TestWay=@TestWay,");
            strSql.Append("Content=@Content,");
            strSql.Append("IsLimitedTime=@IsLimitedTime,");
            strSql.Append("DisplayStyle=@DisplayStyle");
            strSql.Append(" where ID=@ID and ExamInfoID=@ExamInfoID and PubDate=@PubDate and Name=@Name and TestWay=@TestWay and Content=@Content and IsLimitedTime=@IsLimitedTime and DisplayStyle=@DisplayStyle ");
            AccessHelper db = new AccessHelper(databaseName);
            
            db.AddInParameter("ID", DbType.Int32, model.ID);
            db.AddInParameter("ExamInfoID", DbType.String, model.ExamInfoID);
            db.AddInParameter("PubDate", DbType.DateTime, model.PubDate);
            db.AddInParameter("Name", DbType.AnsiString, model.Name);
            db.AddInParameter("TestWay", DbType.AnsiString, model.TestWay);
            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            db.AddInParameter("IsLimitedTime", DbType.Boolean, model.IsLimitedTime);
            db.AddInParameter("DisplayStyle", DbType.String, model.DisplayStyle);
            db.ExecuteNonQuery(strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, short ExamInfoID, DateTime PubDate, string Name, string TestWay, string Content, bool IsLimitedTime, short DisplayStyle)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ExamResult ");
            strSql.Append(" where ID=@ID and ExamInfoID=@ExamInfoID and PubDate=@PubDate and Name=@Name and TestWay=@TestWay and Content=@Content and IsLimitedTime=@IsLimitedTime and DisplayStyle=@DisplayStyle ");
            AccessHelper db = new AccessHelper(databaseName);
            
            db.AddInParameter("ID", DbType.Int32, ID);
            db.AddInParameter("ExamInfoID", DbType.String, ExamInfoID);
            db.AddInParameter("PubDate", DbType.DateTime, PubDate);
            db.AddInParameter("Name", DbType.AnsiString, Name);
            db.AddInParameter("TestWay", DbType.AnsiString, TestWay);
            db.AddInParameter("Content", DbType.AnsiString, Content);
            db.AddInParameter("IsLimitedTime", DbType.Boolean, IsLimitedTime);
            db.AddInParameter("DisplayStyle", DbType.String, DisplayStyle);
            db.ExecuteNonQuery(strSql.ToString());

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ExamResultInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ExamResult ");
            strSql.Append(" where ID=@ID  ");
            AccessHelper db = new AccessHelper(databaseName);
            
            db.AddInParameter("ID", DbType.Int32, ID);

            ExamResultInfo model = null;
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
        /// 
        /// </summary>
        public List<ExamResultInfo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ExamResult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<ExamResultInfo> list = new List<ExamResultInfo>();
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

        public List<ExamResultInfo> GetListArrayByCount(int recordCount, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top {0} * ", recordCount);
            strSql.Append(" FROM ExamResult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<ExamResultInfo> list = new List<ExamResultInfo>();
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
        public ExamResultInfo ReaderBind(IDataReader dataReader)
        {
            ExamResultInfo model = new ExamResultInfo();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }

            ojb = dataReader["ExamInfoID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ExamInfoID = (short)dataReader["ExamInfoID"];
            }

            ojb = dataReader["PubDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PubDate = (DateTime)ojb;
            }
            model.Name = dataReader["Name"].ToString();
            model.TestWay = dataReader["TestWay"].ToString();
            model.Content = dataReader["Content"].ToString();
            ojb = dataReader["IsLimitedTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsLimitedTime = (bool)ojb;
            }

            ojb = dataReader["DisplayStyle"];

            if (ojb != null && ojb != DBNull.Value)
            {
                model.DisplayStyle = (short)dataReader["DisplayStyle"];
            }

            ojb = dataReader["TestedSubject"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TestedSubject = (string)dataReader["TestedSubject"];
            }

            ojb = dataReader["TestedScore"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TestedScore = (string)dataReader["TestedScore"];
            }

            ojb = dataReader["CorrectNum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CorrectNum = (string)dataReader["CorrectNum"];
            }   
            return model;
        }

    }
}
