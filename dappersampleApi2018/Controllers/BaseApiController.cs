using dappersample2018.Core.Interfaces;
using dappersample2018.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dappersampleApi2018.Controllers
{
    public class BaseApiController : ApiController
    {
        private IEmployeeRepository _IEmployeeRepository;
        public IEmployeeRepository IEmployeeRepository
        {
            set { _IEmployeeRepository = value; }
            get
            {
                if (_IEmployeeRepository == null)
                {
                    _IEmployeeRepository = new EmployeeRepository();
                }
                return _IEmployeeRepository;
            }
        }
    }
}
