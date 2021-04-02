using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace DataUtility
{
    public class AccessBasic
    {
        //客户端连接
        protected string databaseName = "|DataDirectory|EasyFound.dll";

        public AccessBasic()
        {
               
        }

        /// <summary>
        /// 适用于试卷后台管理
        /// </summary>
        /// <param name="dbName">完全路径</param>
        public AccessBasic(string dbName)
        {
            databaseName = dbName;
        }

        public static Dictionary<string, string[]> GetFieldNames(string databaseName)
        {
            Dictionary<string, string[]> list = new Dictionary<string, string[]>();

            using (OleDbConnection conn = new OleDbConnection(String.Format(AccessHelper.Connection_String,databaseName)))
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
          
                foreach (DataRow dr in schemaTable.Rows)
                {
                    string tableName = dr["TABLE_NAME"].ToString();

                    DataTable columnTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, dr["TABLE_NAME"].ToString(), null });

                    string[] fields = new string[columnTable.Rows.Count];
                    for ( int i=0;i< columnTable.Rows.Count;i++)                    
                    {
                        fields[i] = columnTable.Rows[i]["COLUMN_NAME"].ToString();
                    }

                    list.Add(tableName, fields);
                }
                conn.Close();
            }

            return list;
        }
        /// <summary>
        /// 将DataReader 转为 DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        public static DataTable ConvertDataReaderToDataTable(IDataReader dr)
        {
            DataTable dt = new DataTable();
            DataTable schemaTb = dr.GetSchemaTable();//得到SqlDataReader的结构，相当于表的结构一样，在这里表的结构信息也被存储成了一个信息表。这个信息表相当于两列多行，第一列存储数据结果表的列名称，第二列存储数据结果表对应列的类型。想象一下我们在设计SqlServer数据库的时候得表结构

            try
            {

                foreach (DataRow sdr in schemaTb.Rows)//通过循环结构表来得到SqlDataReader的列信息，通过这个列信息建立一个DataTable的表结构
                {
                    DataColumn dc = new DataColumn();//创建一个新列
                    // dc.DataType = sdr.GetType();//对于表结构信息的每一行得到当前的列类型
                    dc.DataType = System.Type.GetType("System.String");
                    dc.ColumnName = sdr[0].ToString();//得到列名称
                    dt.Columns.Add(dc);//将新建立的列放入表的列集合中
                }
                //循环SqlDataReader提取数据到达新建立的表中
                while (dr.Read())
                {
                    DataRow dr1 = dt.NewRow();
                    for (int i = 0; i < schemaTb.Rows.Count; i++)//对于原始数据的每一行，循环列将整行信息放入dt中
                    {
                        dr1[i] = dr[i].ToString();
                    }
                    dt.Rows.Add(dr1);
                    dr1 = null;
                }
                schemaTb = null;
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
