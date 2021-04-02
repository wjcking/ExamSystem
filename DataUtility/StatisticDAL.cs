using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Model;

namespace DataUtility
{
    public class StatisticDAL : AccessBasic
    {
        public StatisticDAL()
        {
        }
        public StatisticDAL(string databaseName)
        {
            base.databaseName = databaseName;
        }
        public static List<StatisticInfo> GetList(string databaseName)
        {
            StringBuilder query = new StringBuilder();
            //query.Append("  SELECT   1 AS ID, '选择题' AS Subject, COUNT(*) AS Total ");
            //query.Append("   FROM      Selection ");
            //query.Append("   UNION ");
            //query.Append("   SELECT   2 AS ID, '判断题' AS Subject, COUNT(*) AS Total ");
            //query.Append("   FROM      Judgement ");
            //query.Append("  UNION ");
            //query.Append("  SELECT   3 AS ID, '填空题' AS Subject, COUNT(*) AS Total ");
            //query.Append("   FROM      Fill ");
            //query.Append("  UNION ");
            //query.Append("  SELECT   4 AS ID, '问答题' AS Subject, COUNT(*) AS Total ");
            //query.Append("  FROM      Question ");
            //query.Append("   UNION ");
            query.Append("  SELECT   -1 AS ID, '文档个数' AS Subject, COUNT(*) AS Total ");
            query.Append("  FROM      Outline ");
            query.Append("   WHERE   (Type = 0) ");
            query.Append("   UNION ");
            query.Append("  SELECT   -2 AS ID, '试卷个数' AS Subject, COUNT(*) AS Total ");
            query.Append("   FROM      ExamInfo ");
            query.Append("   WHERE   (IsMaterial = true) ");

            AccessHelper db = new AccessHelper(databaseName);
            List<StatisticInfo> list = new List<StatisticInfo>();
            using (IDataReader dataReader = db.ExecuteReader(query.ToString()))
            {
                while (dataReader.Read())
                {
                    StatisticInfo si = new StatisticInfo();
                    si.ID = Convert.ToInt32(dataReader["ID"]);
                    si.Subject = dataReader["Subject"].ToString();
                    si.Total = Convert.ToInt32(dataReader["Total"]);

                    list.Add(si);
                }
            }


            List<MainSubjectInfo> msiList = new MajorSubject(databaseName).GetListArray(" 100 = 100 ORDER BY [Sort] ASC");

            int[] msiArray = new int[msiList.Count];
            int totalCount = 0;
            for (int i = 0; i < msiList.Count; i++)
            {
                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msiList[i].Type;
                msiArray[i] = Convert.ToInt32(db.ExecuteScalar(string.Format("SELECT COUNT(*) FROM {0} WHERE MainSubjectID = {1}", qt, msiList[i].CurrentID)));
                StatisticInfo si = new StatisticInfo();

                si.ID = msiList[i].ID;
                si.Subject = msiList[i].Subject;
                si.Total = msiArray[i];
                totalCount += si.Total;
                list.Add(si);
            }
            StatisticInfo siTotal = new StatisticInfo();
            siTotal.ID = -3;
            siTotal.Subject = "试题总数";
            siTotal.Total = totalCount;
            list.Add(siTotal);
            return list;
        }

        public List<StatisticInfo> GetTotalCountList()
        {
          return  GetList(base.databaseName);
        }
        public static List<StatisticInfo> GetCountByMainSubjectType(string databaseName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  SELECT   1 AS ID, 'SelectionCount' AS Subject, COUNT(*) AS Total ");
            query.Append("   FROM      Selection ");
            query.Append("   UNION ");
            query.Append("   SELECT   2 AS ID, 'JudgementCount' AS Subject, COUNT(*) AS Total ");
            query.Append("   FROM      Judgement ");
            query.Append("  UNION ");
            query.Append("  SELECT   3 AS ID, 'FillCount' AS Subject, COUNT(*) AS Total ");
            query.Append("   FROM      Fill ");
            query.Append("  UNION ");
            query.Append("  SELECT   4 AS ID, 'QuestionCount' AS Subject, COUNT(*) AS Total ");
            query.Append("  FROM      Question ");
            query.Append("   UNION ");
            query.Append("  SELECT   5 AS ID, 'ExamPaperCount' AS Subject, COUNT(*) AS Total ");
            query.Append("   FROM      ExamInfo ");
            query.Append("   WHERE   (IsMaterial = true) ");

            AccessHelper db = new AccessHelper(databaseName);
            List<StatisticInfo> list = new List<StatisticInfo>();
            using (IDataReader dataReader = db.ExecuteReader(query.ToString()))
            {
                while (dataReader.Read())
                {
                    StatisticInfo si = new StatisticInfo();
                    si.ID = Convert.ToInt32(dataReader["ID"]);
                    si.Subject = dataReader["Subject"].ToString();
                    si.Total = Convert.ToInt32(dataReader["Total"]);
                    list.Add(si);
                }
            }

            return list;
        }

        public List<StatisticInfo> GetEmptyInfoByExamInfoID(int examInfoID)
        {
            StringBuilder query = new StringBuilder();
            query.Append("    SELECT 'Selection' as Name, ms.Subject, count(*) as EmptyCount ");
            query.Append("    FROM  Selection as t ");
            query.Append("     left join MainSubject as ms on ms.ID = t.Mainsubjectid ");
            query.Append("      WHERE t.Answer = '' and t.examinfoid =  ").Append(examInfoID);
            query.Append("      group by ms.id,ms.subject ");
            query.Append("         union all ");

            query.Append("      SELECT 'Judgement' as Name, ms.Subject, count(*) as EmptyCount  ");
            query.Append("       FROM  Judgement as t ");
            query.Append("     left join MainSubject as ms on ms.ID = t.Mainsubjectid ");
            query.Append("     WHERE t.Answer = '' and t.examinfoid = ").Append(examInfoID);
            query.Append("      group by ms.id,ms.subject ");
            query.Append("         union all ");

            query.Append("      SELECT 'Fill' as Name, ms.Subject, count(*) as EmptyCount  ");
            query.Append("      FROM  Fill as t ");
            query.Append("     left join MainSubject as ms on ms.ID = t.Mainsubjectid ");
            query.Append("     WHERE t.Answer = '' and t.examinfoid =  ").Append(examInfoID);
            query.Append("     group by ms.id,ms.subject ");
            query.Append("         UNION ALL ");
            query.Append("   SELECT 'Question' as Name, ms.Subject, count(*) as EmptyCount  ");
            query.Append("     FROM  Question as t ");
            query.Append("     left join MainSubject as ms on ms.ID = t.Mainsubjectid ");
            query.Append("    WHERE t.Answer = '' and t.examinfoid = ").Append(examInfoID);
            query.Append("     group by ms.id,ms.subject; ");

            AccessHelper db = new AccessHelper(base.databaseName);
            List<StatisticInfo> list = new List<StatisticInfo>();

            using (IDataReader dataReader = db.ExecuteReader(query.ToString()))
            {
                while (dataReader.Read())
                {
                    StatisticInfo si = new StatisticInfo();
                    si.Subject = dataReader["Subject"].ToString();
                    si.Total = Convert.ToInt32(dataReader["EmptyCount"]);

                    list.Add(si);
                }
            }
            return list;
        }
        public List<StatisticInfo> GetIncorrectInfoByExamInfoID(int examInfoID)
        {
            StringBuilder query = new StringBuilder();
            query.Append("       SELECT 'Selection' as Name, ms.Subject, count(*) as IncorrectCount  ");
            query.Append("        FROM  Selection as t  ");
            query.Append("        left join MainSubject as ms on ms.ID = t.Mainsubjectid  ");
            query.Append("        WHERE t.IncorrectNo > 0 and t.examinfoid = ").Append(examInfoID);
            query.Append("        group by ms.id,ms.subject  ");
            query.Append("         union all  ");

            query.Append("        SELECT 'Judgement' as Name, ms.Subject, count(*) as IncorrectCount   ");
            query.Append("        FROM  Judgement as t  ");
            query.Append("        left join MainSubject as ms on ms.ID = t.Mainsubjectid  ");
            query.Append("        WHERE t.IncorrectNo > 0 and t.examinfoid =  ").Append(examInfoID);
            query.Append("        group by ms.id,ms.subject  ");
            query.Append("          union all  ");

            query.Append("        SELECT 'Fill' as Name, ms.Subject, count(*) as IncorrectCount   ");
            query.Append("        FROM  Fill as t  ");
            query.Append("        left join MainSubject as ms on ms.ID = t.Mainsubjectid  ");
            query.Append("        WHERE t.IncorrectNo > 0 and t.examinfoid = ").Append(examInfoID);
            query.Append("        group by ms.id,ms.subject  ");
            query.Append("          UNION ALL SELECT 'Question' as Name, ms.Subject, count(*) as IncorrectCount   ");
            query.Append("        FROM  Question as t  ");
            query.Append("        left join MainSubject as ms on ms.ID = t.Mainsubjectid  ");
            query.Append("        WHERE t.IncorrectNo > 0 and t.examinfoid =  ").Append(examInfoID);
            query.Append("        group by ms.id,ms.subject;  ");


            AccessHelper db = new AccessHelper(base.databaseName);
            List<StatisticInfo> list = new List<StatisticInfo>();

            using (IDataReader dataReader = db.ExecuteReader(query.ToString()))
            {
                while (dataReader.Read())
                {
                    StatisticInfo si = new StatisticInfo();
                    si.Subject = dataReader["Subject"].ToString();
                    si.Total = Convert.ToInt32(dataReader["IncorrectCount"]);

                    list.Add(si);
                }
            }
            return list;
        }
        public List<StatisticInfo> GetTotalInfoByExamInfoID(int examInfoID)
        {
            StringBuilder query = new StringBuilder();
            query.Append("       SELECT   1 AS ID, 'Selection' AS Subject, COUNT(*) AS TotalCount ");
            query.Append("       FROM      Selection  WHERE ExamInfoID= ").Append(examInfoID);
            query.Append("      UNION all");
            query.Append("        SELECT   2 AS ID, 'Judgement' AS Subject, COUNT(*) AS TotalCount  ");
            query.Append("       FROM      Judgement   WHERE ExamInfoID= ").Append(examInfoID);
            query.Append("     UNION all");
            query.Append("     SELECT   3 AS ID, 'Fill' AS Subject, COUNT(*) AS TotalCount  ");
            query.Append("          FROM      Fill   WHERE ExamInfoID= ").Append(examInfoID);
            query.Append("     UNION all ");
            query.Append("     SELECT   4 AS ID, 'Question' AS Subject, COUNT(*) AS TotalCount  ");
            query.Append("     FROM      Question   WHERE ExamInfoID=").Append(examInfoID);



            AccessHelper db = new AccessHelper(base.databaseName);
            List<StatisticInfo> list = new List<StatisticInfo>();

            using (IDataReader dataReader = db.ExecuteReader(query.ToString()))
            {
                while (dataReader.Read())
                {
                    StatisticInfo si = new StatisticInfo();
                    si.Subject = dataReader["Subject"].ToString();
                    si.Total = Convert.ToInt32(dataReader["TotalCount"]);

                    list.Add(si);
                }
            }
            return list;
        }
        public List<StatisticInfo> GetFavInfoByExamInfoID(int examInfoID)
        {
            StringBuilder query = new StringBuilder();
            query.Append("       SELECT   1 AS ID, 'Selection' AS Subject, COUNT(*) AS FavCount ");
            query.Append("       FROM      Selection  WHERE Fav=true AND ExamInfoID= ").Append(examInfoID);
            query.Append("      UNION all");
            query.Append("        SELECT   2 AS ID, 'Judgement' AS Subject, COUNT(*) AS FavCount  ");
            query.Append("       FROM      Judgement   WHERE Fav=true AND  ExamInfoID= ").Append(examInfoID);
            query.Append("     UNION all");
            query.Append("     SELECT   3 AS ID, 'Fill' AS Subject, COUNT(*) AS FavCount  ");
            query.Append("          FROM      Fill   WHERE Fav=true AND ExamInfoID= ").Append(examInfoID);
            query.Append("     UNION all ");
            query.Append("     SELECT   4 AS ID, 'Question' AS Subject, COUNT(*) AS FavCount  ");
            query.Append("     FROM      Question   WHERE Fav=true AND ExamInfoID=").Append(examInfoID);



            AccessHelper db = new AccessHelper(base.databaseName);
            List<StatisticInfo> list = new List<StatisticInfo>();

            using (IDataReader dataReader = db.ExecuteReader(query.ToString()))
            {
                while (dataReader.Read())
                {
                    StatisticInfo si = new StatisticInfo();
                    si.Subject = dataReader["Subject"].ToString();
                    si.Total = Convert.ToInt32(dataReader["FavCount"]);

                    list.Add(si);
                }
            }
            return list;
        }


          public  int GetEmptyCountByExamInfoID(int examInfoID)
          {
              List<StatisticInfo> list = GetEmptyInfoByExamInfoID(examInfoID);
              int total = 0;
              foreach (StatisticInfo s in list)
              {
                  total += s.Total;
              }
              return total;
          }
          public  int GetIncorrectCountByExamInfoID(int examInfoID) 
          {
              List<StatisticInfo> list = GetIncorrectInfoByExamInfoID(examInfoID);
              int total = 0;
              foreach (StatisticInfo s in list)
              {
                  total += s.Total;
              }
              return total;
          }

          public int GetTotalCountByExamInfoID(int examInfoID)
          {
              List<StatisticInfo> list = GetTotalInfoByExamInfoID(examInfoID);
              int total = 0;
              foreach (StatisticInfo s in list)
              {
                  total += s.Total;
              }
              return total;
          }


          public int GetFavCountByExamInfoID(int examInfoID)
          {
              List<StatisticInfo> list = GetFavInfoByExamInfoID(examInfoID);
              int total = 0;
              foreach (StatisticInfo s in list)
              {
                  total += s.Total;
              }
              return total;
          }
    }
}
