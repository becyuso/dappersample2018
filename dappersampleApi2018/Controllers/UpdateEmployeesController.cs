using dappersample2018.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dappersampleApi2018.Controllers
{
    public class UpdateEmployeesController : BaseApiController
    {
        public string Get()
        {
            return "Get";
        }
        public bool Post(Dictionary<string, object> conditions)
        {
            var emp = new Employees();
            emp.EmployeeID = Convert.ToInt32(conditions["EmployeeID"]);
            emp.LastName = conditions["LastName"] == null ? "" : Convert.ToString(conditions["LastName"]);
            emp.FirstName = conditions["FirstName"] == null ? "" : Convert.ToString(conditions["FirstName"]);
            if (conditions["BirthDate"] != null)
                emp.BirthDate = Convert.ToDateTime(conditions["BirthDate"]);
            if (conditions["HireDate"] != null)
                emp.HireDate = Convert.ToDateTime(conditions["HireDate"]);
            var employees = this.IEmployeeRepository.EditEmployee(emp);
            return employees;
        }
    }
}
