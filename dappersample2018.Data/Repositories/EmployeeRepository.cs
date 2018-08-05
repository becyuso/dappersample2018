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
            string strSql = "SELECT * FROM Employees";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var records = connection.Query<Employees>(strSql);

                return records.ToList();
            }
        }

        public Employees GetEmployeebyID(int ID)
        {
            string strSql = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var records = connection.Query<Employees>(strSql, new { EmployeeID = ID });

                return records == null ? new Employees() : records.FirstOrDefault();
            }
        }

        public bool CreateEmployee(Employees emp)
        {
            string strSql = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate) VALUES(@LastName, @FirstName, @BirthDate, @HireDate); ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var records = connection.Execute(strSql,
                    new
                    {
                        LastName = emp.LastName,
                        FirstName = emp.FirstName,
                        BirthDate = emp.BirthDate,
                        HireDate = emp.HireDate
                    }
                );
                return Convert.ToBoolean(records);
            }
        }

        public bool EditEmployee(Employees emp)
        {
            string strSql = "UPDATE Employees SET LastName=@LastName, FirstName=@FirstName, BirthDate=@BirthDate, HireDate=@HireDate WHERE EmployeeID=@EmployeeID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var records = connection.Execute(strSql,
                    new
                    {
                        LastName = emp.LastName,
                        FirstName = emp.FirstName,
                        BirthDate = emp.BirthDate,
                        HireDate = emp.HireDate,
                        EmployeeID = emp.EmployeeID
                    }
                );
                return Convert.ToBoolean(records);
            }
        }

        public bool DeleteEmployee(int ID)
        {
            string strSql = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var records = connection.Execute(strSql,
                 new
                 {
                     EmployeeID = ID,
                 }
                 );
                return Convert.ToBoolean(records);
            }
        }
    }
}
