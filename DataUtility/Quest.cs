using System;
using System.Data;
using System.Text;
using System.Collections.Generic;


using System.Data.Common;
using Model;

namespace DataUtility
{
    /// <summary>
    /// 数据访问类Question。
    /// </summary>
    public class Quest :AccessBasic
    {


        public Quest()
        {
        
        }

        public Quest(string conn)
        {
            databaseName = conn;
        }

    
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(QuestionInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Question(");
            strSql.Append("ExamInfoID,MainSubjectID,Subject,[Answer],[key],[Image],Fav,IncorrectNo,CorrectionType)");

            strSql.Append(" values (");
            strSql.Append("@ExamInfoID,@MainSubjectID,@Subject,@Answer,@key,@Image,@Fav,@IncorrectNo,@CorrectionType)");
            AccessHelper db = new AccessHelper(databaseName);
            

            db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);
            db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
            db.AddInParameter("Subject", DbType.AnsiString, model.Subject);
            db.AddInParameter("Answer", DbType.AnsiString, model.Answer);
            db.AddInParameter("[key]", DbType.AnsiString, model.Key);
            db.AddInParameter("Image", DbType.AnsiString, model.Image);

            db.AddInParameter("Fav", DbType.Boolean, model.Fav);
            db.AddInParameter("IncorrectNo", DbType.Int32, model.IncorrectNo);

            db.AddInParameter("CorrectionType", DbType.String, model.CorrectionType);
           return  db.ExecuteNonQuery(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(QuestionInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Question set ");

          //  strSql.Append("ExamInfoID=@ExamInfoID,");
            strSql.Append("MainSubjectID=@MainSubjectID,");
            strSql.Append("[Subject]=@Subject,");


            strSql.Append("[key]=@key");

            //strSql.Append("Simage=@Simage,");
            //strSql.Append("Aimage=@Aimage,");
            //strSql.Append("Smedia=@Smedia,");
            //strSql.Append("Amedia=@Amedia");
            //    strSql.Append("Analysis=@Analysis,");

            strSql.Append(" where ID=@ID  ");
            AccessHelper db = new AccessHelper(databaseName);
            

         //   db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);
            db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
            db.AddInParameter("Subject", DbType.AnsiString, model.Subject);
            db.AddInParameter("[key]", DbType.AnsiString, model.Key);


            //db.AddInParameter("Simage", DbType.AnsiString, model.SImage);
            //db.AddInParameter("Aimage", DbType.AnsiString, model.AImage);
            //db.AddInParameter("Smedia", DbType.AnsiString, model.SMedia);
            //db.AddInParameter("Amedia", DbType.AnsiString, model.AMedia);
            db.AddInParameter("ID", DbType.Int32, model.ID);

            db.ExecuteNonQuery(strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Question ");
            strSql.Append(" where ID=@ID ");
            AccessHelper db = new AccessHelper(databaseName);
            
            db.AddInParameter("ID", DbType.Int32, ID);

            db.ExecuteNonQuery(strSql.ToString());

        }


        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<QuestionInfo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Question ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<QuestionInfo> list = new List<QuestionInfo>();
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
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<QuestionInfo> GetListArrayByPaging(string sql)
        {
          
            List<QuestionInfo> list = new List<QuestionInfo>();
            AccessHelper db = new AccessHelper(databaseName);
            using (IDataReader dataReader = db.ExecuteReader(sql))
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
        public QuestionInfo ReaderBind(IDataReader dataReader)
        {
            QuestionInfo model = new QuestionInfo();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Index = model.ID = (int)ojb;
            }
            ojb = dataReader["ExamInfoID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ExamInfoID = (int)ojb;
            }
            ojb = dataReader["MainSubjectID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MainSubject = ojb.ToString();
                model.MainSubjectID = (int)ojb;
            }
            model.Subject = dataReader["Subject"].ToString();
            model.Answer = dataReader["Answer"].ToString();
            model.Key = dataReader["key"].ToString();
            model.Image = dataReader["Image"].ToString();
            ojb = dataReader["PubDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PubDate = (DateTime)ojb;
            }
            ojb = dataReader["Fav"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Fav = (bool)ojb;
            }
            ojb = dataReader["IncorrectNo"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IncorrectNo = (int)ojb;
            }

            ojb = dataReader["CorrectionType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CorrectionType = ojb.ToString();
            }

            ojb = dataReader["Simage"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SImage = ojb.ToString();
            }

            ojb = dataReader["Aimage"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AImage = ojb.ToString();
            }

            ojb = dataReader["Smedia"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SMedia = ojb.ToString();
            }

            ojb = dataReader["Amedia"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AMedia = ojb.ToString();
            }
            ojb = dataReader["SubjectDetail"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SubjectDetail = ojb.ToString();
            }
            return model;
        }
         
    }
}