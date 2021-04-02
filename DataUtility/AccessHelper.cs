using System.Data.OleDb;
using System.Collections.Generic;
using System.Data;
using System;

namespace DataUtility
{
    public class AccessHelper : AccessBasic
    {
        public const string Connection_String = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source='{0}';Jet OLEDB:Database Password=cursedhacker;";

        private List<OleDbParameter> paramCollection = new List<OleDbParameter>();

        public AccessHelper()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName">包括路径</param>
        public AccessHelper(string dbName)
        {
            base.databaseName = dbName;
        }

        public int ExecuteNonQuery(string cmdText)
        {
            string connectionString = string.Format(Connection_String, databaseName);
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);

            if (paramCollection.Count > 0)
            {
                foreach (OleDbParameter p in paramCollection)
                    cmd.Parameters.Add(p);
            }

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            //清空参数
            cmd.Parameters.Clear();
            paramCollection.Clear();
            return result;
        }


        public OleDbParameter AddInParameter(string name, System.Data.DbType dbType, object value)
        {
            OleDbParameter p = new OleDbParameter();
            p.DbType = dbType;
            p.ParameterName = name;
            p.Value = value;
            paramCollection.Add(p);
            return p;
        }

        public OleDbDataReader ExecuteReader(string cmdText)
        {
            string connectionString = string.Format(Connection_String, databaseName);

            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);

            if (paramCollection.Count > 0)
            {
                foreach (OleDbParameter p in paramCollection)
                    cmd.Parameters.Add(p);
            }
            conn.Open();

     
            OleDbDataReader dr= cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); 
            //清空参数
            cmd.Parameters.Clear();
            paramCollection.Clear();

            return dr;

        }
        public object ExecuteScalar(string cmdText)
        {
            string connectionString = string.Format(Connection_String, databaseName);

            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);

            if (paramCollection.Count > 0)
            {
                foreach (OleDbParameter p in paramCollection)
                    cmd.Parameters.Add(p);
            }
            conn.Open();


            object o = cmd.ExecuteScalar();
            conn.Close();
            //清空参数
            cmd.Parameters.Clear();
            paramCollection.Clear();
            return o;
        }

        public static DataTable ConvertDataReaderToDataTable(OleDbDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            DataTable schemaTable = dataReader.GetSchemaTable();
            //动态添加列
            foreach (DataRow myRow in schemaTable.Rows)
            {
                DataColumn myDataColumn = new DataColumn();
                myDataColumn.DataType = (Type)myRow["DataType"];
                myDataColumn.ColumnName = myRow["ColumnName"].ToString();
                datatable.Columns.Add(myDataColumn);
            }
            //添加数据
            while (dataReader.Read())
            {
                DataRow myDataRow = datatable.NewRow();
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    myDataRow[i] = dataReader[i];
                }
                datatable.Rows.Add(myDataRow);
                myDataRow = null;
            }
            schemaTable = null;
            return datatable;
        }

    
    }
}
