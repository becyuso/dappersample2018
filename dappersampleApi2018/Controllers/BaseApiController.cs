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
        /// <summary>
        /// Entity Repository
        /// </summary>
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

        /// <summary>
        /// Common Repository by 2018/08/08
        /// </summary>
        private IRepository _IRepository;
        public IRepository IRepository
        {
            set { _IRepository = value; }
            get
            {
                if (_IRepository == null)
                {
                    _IRepository = new Repository();
                }
                return _IRepository;
            }
        }
    }
}
