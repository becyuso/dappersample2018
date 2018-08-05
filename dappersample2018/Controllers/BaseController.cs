using dappersample2018.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dappersample2018.Controllers
{
    public class BaseController : Controller
    {
        protected IEmployeeRepository _repository { get; set; }
    }
}