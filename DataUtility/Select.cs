using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
namespace DataUtility
{
 	public class Select :AccessBasic
	{
	     public Select()
        {
         
        }

        public Select(string conn)
        {
            databaseName = conn;
        }
	 



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(SelectionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Selection(");
			strSql.Append("[ExamInfoID],[MainSubjectID],[Subject],[Choice],[Multiple],[BreakType],[Answer],[Key],[Analysis],[Image],[Fav],[IncorrectNo],[CorrectionType])");

			strSql.Append(" values (");
			strSql.Append("@ExamInfoID,@MainSubjectID,@Subject,@Choice,@Multiple,@BreakType,@Answer,@Key,@Analysis,@Image,@Fav,@IncorrectNo,@CorrectionType)");
            AccessHelper db = new AccessHelper(databaseName);
			
		
			db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);
			db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
			db.AddInParameter("Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter("Choice", DbType.AnsiString, model.Choice);
			db.AddInParameter("Multiple", DbType.Boolean, model.Multiple);
			db.AddInParameter("BreakType", DbType.String, model.BreakType);
			db.AddInParameter("Answer", DbType.AnsiString, model.Answer);
			db.AddInParameter("Key", DbType.AnsiString, model.Key);
			db.AddInParameter("Analysis", DbType.AnsiString, model.Analysis);
			db.AddInParameter("Image", DbType.AnsiString, model.Image);
			db.AddInParameter("Fav", DbType.Boolean, model.Fav);
			db.AddInParameter("IncorrectNo", DbType.Int32, model.IncorrectNo);
			db.AddInParameter("CorrectionType", DbType.String, model.CorrectionType);
			db.ExecuteNonQuery(strSql.ToString());
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SelectionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Selection set ");
		
            //strSql.Append("ExamInfoID=@ExamInfoID,");
            strSql.Append("MainSubjectID=@MainSubjectID,");
			strSql.Append("Subject=@Subject,");
		 	strSql.Append("Choice=@Choice,");
			strSql.Append("Multiple=@Multiple,");
			strSql.Append("BreakType=@BreakType,");
		

			strSql.Append("[Key]=@Key,");
            strSql.Append("Analysis=@Analysis,");
   

            strSql.Append("Simage=@Simage,");
            strSql.Append("Aimage=@Aimage,");
            strSql.Append("Smedia=@Smedia,");
            strSql.Append("Amedia=@Amedia");

			strSql.Append(" where ID= @ID");
			
            AccessHelper db = new AccessHelper(databaseName);
			
		
            //db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);
            db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
			db.AddInParameter("Subject", DbType.AnsiString, model.Subject);
		 	db.AddInParameter("Choice", DbType.AnsiString, model.Choice);
			db.AddInParameter("Multiple", DbType.Boolean, model.Multiple);
			db.AddInParameter("BreakType", DbType.String, model.BreakType);

			db.AddInParameter("Key", DbType.AnsiString, model.Key);
			db.AddInParameter("Analysis", DbType.AnsiString, model.Analysis);
		

            db.AddInParameter("Simage", DbType.String, model.SImage);
            db.AddInParameter("Aimage", DbType.String, model.AImage);
            db.AddInParameter("Smedia", DbType.String, model.SMedia);
            db.AddInParameter("Amedia", DbType.String, model.AMedia);
            db.AddInParameter("ID", DbType.Int32, model.ID);
			db.ExecuteNonQuery(strSql.ToString());

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Selection ");
			strSql.Append(" where ID=@ID ");
			AccessHelper db = new AccessHelper( databaseName);
			
			db.AddInParameter("ID", DbType.Int32,ID);
		
			db.ExecuteNonQuery(strSql.ToString());

		}
        
        // <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<SelectionInfo> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM Selection ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<SelectionInfo> list = new List<SelectionInfo>();
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
        public List<SelectionInfo> GetListArrayByPaging(string sql)
        {
             
            List<SelectionInfo> list = new List<SelectionInfo>();
            AccessHelper db = new AccessHelper(databaseName);
            using (IDataReader dataReader = db.ExecuteReader(  sql))
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
		public SelectionInfo ReaderBind(IDataReader dataReader)
		{
			SelectionInfo model=new SelectionInfo();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
		model.Index=   	model.ID=(int)ojb;
			}
			ojb = dataReader["ExamInfoID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ExamInfoID=(int)ojb;
			}
			ojb = dataReader["MainSubjectID"];
			if(ojb != null && ojb != DBNull.Value)
            {
                model.MainSubject = ojb.ToString();
                model.CurrentID = ojb.ToString();
				model.MainSubjectID=(int)ojb;
			}
			model.Subject=dataReader["Subject"].ToString();
			model.Choice=dataReader["Choice"].ToString();
			ojb = dataReader["Multiple"];

			if(ojb != null && ojb != DBNull.Value)
			{
				model.Multiple=(bool)ojb;
			}
            ojb = dataReader["BreakType"];

			if(ojb != null && ojb != DBNull.Value)
			{
                model.BreakType = (int)ojb;
			}

			model.Answer=dataReader["Answer"].ToString();
			model.Key=dataReader["Key"].ToString();
			model.Analysis=dataReader["Analysis"].ToString();
			model.Image=dataReader["Image"].ToString();
			ojb = dataReader["PubDate"];

			if(ojb != null && ojb != DBNull.Value)
			{
				model.PubDate=(DateTime)ojb;
			}
			ojb = dataReader["Fav"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Fav=(bool)ojb;
			}
			ojb = dataReader["IncorrectNo"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IncorrectNo=(int)ojb;
			}
            ojb = dataReader["CorrectionType"];
			if(ojb != null && ojb != DBNull.Value)
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

        public int UpdateChoice(int id, string choice)
        {

            string sql = "update [Selection] set Choice = @Choice  where ID= @ID";

            AccessHelper db = new AccessHelper(databaseName);

            db.AddInParameter("Choice", DbType.AnsiString, choice);
            db.AddInParameter("ID", DbType.Int32, id);
            return   db.ExecuteNonQuery(sql);
        }
         
	}
}
