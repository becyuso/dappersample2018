using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dappersample2018.Data.Repositories
{
    public abstract class BaseRepository
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public BaseRepository()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        /// <summary>
        /// 組合Sql字串
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        protected static string SetCreatesql(Dictionary<string, object> dic)
        {
            string sql = "(";
            string sqlvalue = " VALUES(";
            int C = 1;
            foreach (var item in dic)
            {
                if (item.Value == null)
                    continue;
                sql += item.Key + ",";
                sqlvalue += "@C" + C.ToString() + ",";
                C++;
            }
            return sql.Substring(0, sql.Length - 1) + ")" + sqlvalue.Substring(0, sqlvalue.Length - 1) + ")";
        }

        protected static object SetParam(Dictionary<string, object> dic)
        {
            object[] strAry = GetParamAry(dic);
            switch (strAry.Length)
            {
                case 1:
                    return new { C1 = Getval(strAry[0]) };
                case 2:
                    return new { C1 = Getval(strAry[0]), C2 = Getval(strAry[1]) };
                case 3:
                    return new { C1 = Getval(strAry[0]), C2 = Getval(strAry[1]), C3 = Getval(strAry[2]) };
                case 4:
                    return new { C1 = Getval(strAry[0]), C2 = Getval(strAry[1]), C3 = Getval(strAry[2]), C4 = Getval(strAry[3]) };
                case 5:
                    return new { C1 = Getval(strAry[0]), C2 = Getval(strAry[1]), C3 = Getval(strAry[2]), C4 = Getval(strAry[3]), C5 = Getval(strAry[4]) };
                default:
                    return new { };
            }
        }
        protected static object[] GetParamAry(Dictionary<string, object> dic)
        {
            List<object> strlist = new List<object>();
            foreach (var item in dic)
            {
                if (item.Value == null)
                    continue;
                strlist.Add(item.Value);
            }
            return strlist.ToArray();
        }
        protected static object Getval(object obj)
        { 
            if (obj == null)
                return obj;
            switch (obj.GetType().FullName)
            {
                case "System.String":
                    return obj.ToString();
                case "System.DateTime":
                    return Convert.ToDateTime(obj);
                case "System.Int32":
                    return Convert.ToInt32(obj);
                default:
                    return "";
            }
        }
    }
}
