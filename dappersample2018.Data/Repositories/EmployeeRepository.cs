using Dapper;
using dappersample2018.Core.Entities;
using dappersample2018.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dappersample2018.Data.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public IEnumerable<Employees> GetEmployees()
        {
            string selectSql = "SELECT * FROM Employees";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var records = connection.Query<Employees>(selectSql);

                return records.ToList();
            }
        }
    }
}
