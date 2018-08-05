using dappersample2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dappersampleApi2018.Controllers
{
    public class SelectEmployeesController : BaseApiController
    {
        public string Get()
        {
            return "Get";
        }
        public IEnumerable<Employees> Post(Dictionary<string, object> dic)
        {
             var employees = this.IEmployeeRepository.GetEmployees();
            return employees;
        }
    }
}
