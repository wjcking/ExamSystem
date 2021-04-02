using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using System.Data.Common;
using Model;

namespace DataUtility
{
  public class FillBlank : AccessBasic
	{
		 
    //private string databaseName;

      public FillBlank()
      {
          
      }

      public FillBlank(string conn)
      {
          databaseName = conn;
      }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(FillInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Fill(");
			strSql.Append("MainSubjectID,[Subject],[Answer],[key],Analysis,[Image],ExamInfoID,Fav,IncorrectNo,CorrectionType)");

			strSql.Append(" values (");
			strSql.Append("@MainSubjectID,@Subject,@Answer,@key,@Analysis,@Image,@ExamInfoID,@Fav,@IncorrectNo,@CorrectionType)");

			AccessHelper db = new AccessHelper(databaseName);		
		
			db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
			db.AddInParameter("Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter("Answer", DbType.AnsiString, model.Answer);
            db.AddInParameter("key", DbType.AnsiString, model.Key);
			db.AddInParameter("Analysis", DbType.AnsiString, model.Analysis == null ? "": model.Analysis);
			db.AddInParameter("Image", DbType.AnsiString, model.Image);
			db.AddInParameter("ExamInfoID", DbType.Int32, model.ExamInfoID);
			db.AddInParameter("Fav", DbType.Boolean, model.Fav);
			db.AddInParameter("IncorrectNo", DbType.Int32, model.IncorrectNo);
			db.AddInParameter("CorrectionType", DbType.String, model.CorrectionType);
			return db.ExecuteNonQuery(strSql.ToString());
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(FillInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Fill set ");
		
		//	strSql.Append("PubDate=@PubDate,");
			strSql.Append("MainSubjectID=@MainSubjectID,");
			strSql.Append("[Subject]=@Subject,");
			strSql.Append("[Answer]=@Answer,");
			strSql.Append("[key]=@key,");
			 strSql.Append("Analysis=@Analysis");
	

			strSql.Append(" where [ID]=@ID");

			AccessHelper db = new AccessHelper(databaseName);

			//db.AddInParameter("PubDate", DbType.DateTime, model.PubDate);
			db.AddInParameter("MainSubjectID", DbType.Int32, model.MainSubjectID);
			db.AddInParameter("Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter("Answer", DbType.AnsiString, model.Answer);
            db.AddInParameter("key", DbType.AnsiString, model.Key);
			 db.AddInParameter("Analysis", DbType.AnsiString, model.Analysis);


            db.AddInParameter("ID", DbType.AnsiString, model.ID);
			db.ExecuteNonQuery(strSql.ToString());

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Fill ");
			strSql.Append(" where ID=@ID");
			AccessHelper db = new AccessHelper(databaseName);
			
			db.AddInParameter("ID", DbType.Int32,ID);
			

			db.ExecuteNonQuery(strSql.ToString());

		}



		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        public List<FillInfo> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM Fill ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            List<FillInfo> list = new List<FillInfo>();
			AccessHelper db = new AccessHelper(databaseName);
			using (IDataReader dataReader = db.ExecuteReader( strSql.ToString()))
			{
				while (dataReader.Read())
				{ 
                    FillInfo fi = ReaderBind(dataReader);
                    fi.SImage = dataReader["SImage"].ToString();
                    fi.AImage = dataReader["AImage"].ToString();
                    fi.SMedia = dataReader["SMedia"].ToString();
                    fi.AMedia = dataReader["AMedia"].ToString();
                    list.Add(fi);
				}
			}
			return list;
		}
        public List<FillInfo> GetListArrayByPaging(string sql)
		{
			 
            List<FillInfo> list = new List<FillInfo>();
			AccessHelper db = new AccessHelper(databaseName);
			using (IDataReader dataReader = db.ExecuteReader( sql))
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
        public FillInfo ReaderBind(IDataReader dataReader)
		{
            FillInfo model = new FillInfo();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
			model.Index =	model.ID=(int)ojb;
			}
			ojb = dataReader["PubDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PubDate=(DateTime)ojb;
			}
			ojb = dataReader["MainSubjectID"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.MainSubject = ojb.ToString();
				model.MainSubjectID=(int)ojb;
			}
			model.Subject=dataReader["Subject"].ToString();
			model.Answer=dataReader["Answer"].ToString();
			model.Key=dataReader["key"].ToString();
			model.Analysis=dataReader["Analysis"].ToString();
			model.Image=dataReader["Image"].ToString();
			ojb = dataReader["ExamInfoID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ExamInfoID=(int)ojb;
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
 

			return model;
		}


	}
}
