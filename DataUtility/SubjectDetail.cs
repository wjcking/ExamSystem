using System;
using System.Collections.Generic;
using System.Text;

using System.Data.Common;
using System.Data;
using Model;

namespace DataUtility
{
    public class SubjectDetail : AccessBasic
    {
        //private string databaseName;

        public SubjectDetail()
        {

        }

        public SubjectDetail(string conn)
        {
            databaseName = conn;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SubjectID)
        {
            AccessHelper db = new AccessHelper(databaseName);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SubjectDetail where  SubjectID=@SubjectID");

            db.AddInParameter("SubjectID", DbType.Int32, SubjectID);
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
        public void Add(SubjectDetailInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SubjectDetail(");
            strSql.Append("[Content],ExamInfoID,[Image],MainSubjectID,[Media],SubjectID,[Title])");

            strSql.Append(" values (");
            strSql.Append("@Content,@ExamInfoID,@Image,@MainSubjectID,@Media,@SubjectID,@Title)");
            AccessHelper db = new AccessHelper(databaseName);

            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);
            db.AddInParameter("Image", DbType.AnsiString, model.Image);
            db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
            db.AddInParameter("Media", DbType.AnsiString, model.Media);
            db.AddInParameter("SubjectID", DbType.Int32, model.SubjectID);
            db.AddInParameter("Title", DbType.AnsiString, model.Title);
            db.ExecuteNonQuery(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(SubjectDetailInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SubjectDetail set ");
            //strSql.Append("SubjectID=@SubjectID,");
            //strSql.Append("MainSubjectID=@MainSubjectID,");
            //strSql.Append("ExamInfoID=@ExamInfoID,");
            strSql.Append("[Image]=@Image,");
            strSql.Append("[Media]=@Media,");
            strSql.Append("[Title]=@Title,");
            strSql.Append("[Content]=@Content ");
            strSql.Append(" where  SubjectID=@SubjectID AND MainSubjectID=@MainSubjectID AND ExamInfoID=@ExamInfoID");
            AccessHelper db = new AccessHelper(databaseName);


            db.AddInParameter("Image", DbType.AnsiString, model.Image);
            db.AddInParameter("Media", DbType.AnsiString, model.Media);
            db.AddInParameter("Title", DbType.AnsiString, model.Title);
            db.AddInParameter("Content", DbType.AnsiString, model.Content);

            db.AddInParameter("SubjectID", DbType.Int32, model.SubjectID);
            db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
            db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);

            //db.AddInParameter("ID", DbType.Int32, model.);
            db.ExecuteNonQuery(strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SubjectDetail ");
            strSql.Append(" where ID=@ID");
            AccessHelper db = new AccessHelper(databaseName);


            db.AddInParameter("ID", DbType.Int32, ID);


            db.ExecuteNonQuery(strSql.ToString());

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SubjectDetailInfo GetModel(int subjectid, int examinfoid, int mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SubjectDetail ");
            strSql.Append(" where  SubjectID=@SubjectID AND MainSubjectID=@MainSubjectID AND ExamInfoID=@ExamInfoID ");
            AccessHelper db = new AccessHelper(databaseName);


            db.AddInParameter("SubjectID", DbType.Int32, subjectid);
            db.AddInParameter("MainSubjectID", DbType.Int32, mid);
            db.AddInParameter("ExamInfoID", DbType.Int32, examinfoid);

            SubjectDetailInfo model = new SubjectDetailInfo();

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
        public SubjectDetailInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SubjectDetail ");
            strSql.Append(" where  ID =  ");
            strSql.Append(id);
            AccessHelper db = new AccessHelper(databaseName);



            SubjectDetailInfo model = new SubjectDetailInfo();

            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        public DataTable GetSubjectDetailList(int examInfoID)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.Append("  SELECT   sd.ID AS SubjectDetailID, sd.MainSubjectID, sd.Title, sd.Content AS SDContent, sd.SubjectID, sd.Media, sd.[Image], ");
            strSql.Append("                  ms.Subject AS MainSubjectName, exi.Name AS ExamInfoName ");
            strSql.Append(" FROM      ((SubjectDetail sd LEFT OUTER JOIN ");
            strSql.Append("  MainSubject ms ON sd.MainSubjectID = ms.ID) LEFT OUTER JOIN ");
            strSql.Append("  ExamInfo exi ON exi.ID = sd.ExamInfoID) ");
            if (examInfoID > 0)
                strSql.AppendFormat("   WHERE   (sd.ExamInfoID = {0}) ", examInfoID);
            strSql.Append("   ORDER BY sd.ID DESC ");

            AccessHelper db = new AccessHelper(databaseName);

            IDataReader dataReader = db.ExecuteReader(strSql.ToString());

            return AccessHelper.ConvertDataReaderToDataTable(dataReader);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<SubjectDetailInfo> GetListByArray(string sql)
        {

           AccessHelper db = new AccessHelper(databaseName);


            List<SubjectDetailInfo> sdList = new List<SubjectDetailInfo>();

            using (IDataReader dataReader = db.ExecuteReader(sql))
            {
                while (dataReader.Read())
                {
                    SubjectDetailInfo model = new SubjectDetailInfo();
                    model = ReaderBind(dataReader);
                    sdList.Add(model);
                }
            }
            return sdList;
        }
         
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public SubjectDetailInfo ReaderBind(IDataReader dataReader)
        {
            SubjectDetailInfo model = new SubjectDetailInfo();
            object ojb;
            model.Content = dataReader["Content"].ToString();
            ojb = dataReader["ExamInfoID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ExamInfoID = (int)ojb;
            }
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            model.Image = dataReader["Image"].ToString();
            ojb = dataReader["MainSubjectID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MainSubjectID = (int)ojb;
            }
            model.Media = dataReader["Media"].ToString();
            ojb = dataReader["SubjectID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SubjectID = (int)ojb;
            }
            model.Title = dataReader["Title"].ToString();
            return model;
        }

    }
}
