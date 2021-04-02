using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using System.Data.Common;
using Model;

namespace DataUtility
{
	/// <summary>
	/// 数据访问类Outline。
	/// </summary>
	public class Outline : AccessBasic
	{
		 
       //private string databaseName;

        public Outline()
        {
           
        }

        public Outline(string conn)
        {
            databaseName = conn;
        } 


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(OutlineInfo model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Outline(");
            strSql.Append("PID,Title,Content,ContentType, [type])");

            strSql.Append(" values (");
            strSql.Append("@PID,@Title,@Content,@ContentType, @type)");
            AccessHelper db = new AccessHelper(databaseName);
            

            db.AddInParameter("PID", DbType.Int32, model.PID);
            db.AddInParameter("Title", DbType.AnsiString, model.Title);
            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            db.AddInParameter("ContentType", DbType.String, model.ContentType);
            db.AddInParameter("type", DbType.String, model.Type);
            db.ExecuteNonQuery(strSql.ToString());
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(OutlineInfo model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Outline set ");

            if (!string.IsNullOrEmpty(model.Title))
          //      strSql.Append("[Title]=@Title,");
            strSql.Append("[Content]=@Content");
         //   strSql.Append("[ContentType]=@ContentType,");
        //    strSql.Append("[Type]=@Type");
            strSql.Append(" where [ID]=@ID ");
            AccessHelper db = new AccessHelper(databaseName);
            

            //if (!string.IsNullOrEmpty(model.Title))
            //    db.AddInParameter("Title", DbType.AnsiString, model.Title);

            db.AddInParameter("Content", DbType.AnsiString, model.Content);
            //db.AddInParameter("ContentType", DbType.Int32, model.ContentType);
            //db.AddInParameter("Type", DbType.Int32, model.Type);
            db.AddInParameter("ID", DbType.Int32, model.ID);
            db.ExecuteNonQuery(strSql.ToString());

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
            AccessHelper db = new AccessHelper(databaseName);
            int materialCount = db.ExecuteNonQuery(String.Format("DELETE * FROM Outline WHERE PID={0}  ", ID));

           
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete * from Outline ");
			strSql.Append(" where ID=@ID ");
			
		  	db.AddInParameter("ID", DbType.Int32,ID);
 
		return 	db.ExecuteNonQuery(strSql.ToString());

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public OutlineInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from Outline ");
			strSql.Append(" where ID=@ID ");
			AccessHelper db = new AccessHelper(databaseName);
			
			db.AddInParameter("ID", DbType.Int32,ID);

			OutlineInfo model=null;
			using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
			{
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
                else
                {
                    model = new OutlineInfo();
                    model.Title = "考试大纲与资料";
                    model.Content = "考试大纲与资料";
                    model.ContentType = 2;
                }
			}
			return model;
		}

		


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<OutlineInfo> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ID,PID,[Title],[Type],[ContentType],[Keyword] ");
			strSql.Append(" FROM Outline ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<OutlineInfo> list = new List<OutlineInfo>();

            AccessHelper db =   new AccessHelper(databaseName);

           
			using (IDataReader dataReader = db.ExecuteReader( strSql.ToString()))
			{
				while (dataReader.Read())
				{
                    OutlineInfo info = new OutlineInfo();
                    info.ID = Convert.ToInt32(dataReader["ID"]);
                    info.PID = Convert.ToInt32(dataReader["PID"]);
                    info.Title = Convert.ToString(dataReader["Title"]);
                    info.Keyword = Convert.ToString(dataReader["Keyword"]);

                    info.Type = Convert.ToInt32(dataReader["Type"]);
                    object o = dataReader["ContentType"];
                    if (dataReader["ContentType"] != DBNull.Value)
                        info.ContentType = Convert.ToInt16(dataReader["ContentType"]);
                   // info.Content = dataReader["content"].ToString();
                    list.Add(info);
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
        public OutlineInfo ReaderBind(IDataReader dataReader)
        {
            OutlineInfo model = new OutlineInfo();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            ojb = dataReader["PID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PID = (int)ojb;
            }
            ojb = dataReader["PubDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PubDate = (DateTime)ojb;
            }
            ojb = dataReader["Title"];
            if (ojb != null && ojb != DBNull.Value)
                model.Title = dataReader["Title"].ToString();

          ojb = dataReader["Content"];

            if (ojb != null && ojb != DBNull.Value)
                model.Content = dataReader["Content"].ToString();
            ojb = dataReader["ContentType"];

            if (ojb != null && ojb != DBNull.Value)
            model.ContentType = Convert.ToInt32(dataReader["ContentType"]);
            
            ojb = dataReader["Type"];
            if (ojb != null && ojb != DBNull.Value)
            model.Type = Convert.ToInt32(dataReader["Type"]);
            ojb = dataReader["Keyword"];
            if (ojb != null && ojb != DBNull.Value)
                model.Keyword = Convert.ToString(dataReader["Keyword"]);
            return model;
        } 
	}
}

