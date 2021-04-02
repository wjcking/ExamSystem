using System;
using System.Text;

namespace ExamSys.Util
{
    public  static class Pagination
    {
        public static int GetPageCount(int recordCount, int pageSize)
        {
            return (int)Math.Ceiling((double)recordCount / pageSize);
        }

        // 获取排序的方式（"ASC"表示升序，"DESC"表示降序）
        private static String GetSortType(bool ascending)
        {
            return (ascending ? "ASC" : "DESC");
        }
        // 获取一个布尔值，该值指示排序的方式是否为升序。
        private static bool IsAscending(String orderType)
        {
            return ((orderType.ToUpper() == "DESC") ? false : true);
        }

        public static String Paging(int pageSize, int pageIndex, int recordCount, String tableName, String queryFields, String primaryKey, bool ascending, String condition)
        {

            StringBuilder queryString = new StringBuilder();

            int pageCount = GetPageCount(recordCount, pageSize);     //分页的总数
            int middleIndex = (int)Math.Ceiling((double)pageCount / 2);                   //中间页的索引
            //                                             //第一页的索引
            int lastIndex = pageCount;                                     //最后一页的索引

            //pageIndex <= firstIndex || 
            if (pageIndex == 1)
            {
                queryString.Append("SELECT TOP ");
                queryString.Append(pageSize).Append(" ");
                queryString.Append(queryFields);
                queryString.Append(" FROM ");
                queryString.Append(tableName);

                if (!string.IsNullOrEmpty(condition))
                {
                    queryString.Append(" WHERE 100 = 100 AND ");
                    queryString.Append(condition);
                }

                queryString.Append(" ORDER BY ");
                queryString.Append(primaryKey).Append(" ");
                queryString.Append(GetSortType(ascending));

            }

            else if (pageIndex > 1 && pageIndex < pageCount)
            {

                queryString.AppendFormat("SELECT {0} FROM {1} ", queryFields, tableName);

                queryString.Append(" WHERE ");

                queryString.AppendFormat("  {0} < (SELECT min({0}) ", primaryKey);
                queryString.AppendFormat("  FROM (SELECT TOP {0} {1}  FROM {2}", pageIndex * pageSize - pageSize, primaryKey, tableName);

                if (string.IsNullOrEmpty(condition))
                    queryString.AppendFormat("   ORDER BY {0} DESC)) ", primaryKey);
                else
                    queryString.AppendFormat("  WHERE {0} ORDER BY {1} DESC)) ", condition, primaryKey);

                queryString.AppendFormat("AND {0} >= (SELECT min({0}) ", primaryKey);
                queryString.AppendFormat("  FROM (SELECT TOP {0} {1}  FROM {2}", pageIndex * pageSize, primaryKey, tableName);

                if (string.IsNullOrEmpty(condition))
                    queryString.AppendFormat("   ORDER BY {0} DESC)) ", primaryKey);
                else
                    queryString.AppendFormat("  WHERE {0} ORDER BY {1} DESC)) ", condition, primaryKey);

                if (string.IsNullOrEmpty(condition))
                    queryString.AppendFormat(" ORDER BY {0} DESC", primaryKey);
                else
                    queryString.AppendFormat("  AND  {0} ORDER BY {1} DESC", condition, primaryKey);

            }

            else if (pageIndex >= lastIndex)
            {
                queryString.Append("SELECT * FROM ( ");
                queryString.AppendFormat("SELECT TOP {0} {1} ", recordCount - pageSize * (lastIndex - 1), queryFields);
                queryString.Append(" FROM ");
                queryString.Append(tableName);

                if (!string.IsNullOrEmpty(condition))
                {
                    queryString.Append(" WHERE ");
                    queryString.Append(condition);
                }
                queryString.AppendFormat(" ORDER BY {0} ASC ", primaryKey);
                queryString.AppendFormat(" ) TableA ORDER BY {0} DESC ", primaryKey);


            }
            return queryString.ToString();
        } 
    }
}
