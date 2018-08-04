using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dappersample2018.Core.Interfaces;
using dappersample2018.Core.Entities;
using dappersample2018.Data.Repositories;

namespace dappersample2018.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository { get; set; }

        public EmployeeController()
        {
            this._repository = new EmployeeRepository();
        }

        public ActionResult Index()
        {
            var employees = this._repository.GetEmployees();
            return View(employees);
        }
    }
}