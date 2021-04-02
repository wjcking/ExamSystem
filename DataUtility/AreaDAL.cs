using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataUtility
{
   public class AreaDAL
    {
       private const string DatabaseArea = "area.mdb";
        public static DataTable GetProvince()
        {
            AccessHelper acc = new AccessHelper(DatabaseArea);
            IDataReader dr = acc.ExecuteReader("SELECT * FROM province order by id ");

            return AccessBasic.ConvertDataReaderToDataTable(dr);
        }

        public  static DataTable GetCitiesByProvinceID(string provinceID)
        {
            AccessHelper acc = new AccessHelper(DatabaseArea);
            IDataReader dr = acc.ExecuteReader(string.Format("SELECT * FROM city WHERE father = '{0}'",provinceID));

            return AccessBasic.ConvertDataReaderToDataTable(dr);
        }

        public static DataTable GetAreaByCityID(string cityID)
        {
            AccessHelper acc = new AccessHelper(DatabaseArea);
            IDataReader dr = acc.ExecuteReader(string.Format("SELECT * FROM area WHERE father='{0}'",cityID));

            return AccessBasic.ConvertDataReaderToDataTable(dr);
        }
    }
}
