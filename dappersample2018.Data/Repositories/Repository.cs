using Dapper;
using dappersample2018.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dappersample2018.Data.Repositories
{
    public class Repository : BaseRepository, IRepository
    {
        public bool create<T>(Dictionary<string, object> dic) where T : class, new()
        {
            T entity = new T();
            string strSql = $"INSERT INTO {entity.GetType().Name} {SetCreatesql(dic)}; ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var records = connection.Execute(strSql,
                    SetParam(dic)
                );
                return Convert.ToBoolean(records);
            }
        }
    }
}
