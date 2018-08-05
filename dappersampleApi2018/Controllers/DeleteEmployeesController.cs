using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dappersampleApi2018.Controllers
{
    public class DeleteEmployeesController : BaseApiController
    {
        public string Get()
        {
            return "Get";
        }
        public bool Post(Dictionary<string, object> conditions)
        {
            if (conditions["EmployeeID"] == null)
                return false;
            int ID = Convert.ToInt32(conditions["EmployeeID"]);
            var employees = this.IEmployeeRepository.DeleteEmployee(ID);
            return employees;
        }
    }
}
