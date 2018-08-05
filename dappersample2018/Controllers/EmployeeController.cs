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
    public class EmployeeController : BaseController
    {
        public EmployeeController()
        {
            this._repository = new EmployeeRepository();
        }

        public ActionResult Index()
        {
            var employees = this._repository.GetEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View(new Employees());
        }

        public ActionResult Edit(int ID)
        {
            var employees = this._repository.GetEmployeebyID(ID);
            return View(employees);
        }

        [HttpPost]
        public ActionResult CreateData(Employees emp)
        {
            if (ModelState.IsValid)
            {
                var response = this._repository.CreateEmployee(emp);
                if (response)
                {
                    TempData["resp"] = "Success";
                    return RedirectToAction("Index");
                }
            }
            TempData["resp"] = "Error";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditData(Employees emp)
        {
            if (ModelState.IsValid)
            {
                var response = this._repository.EditEmployee(emp);
                if (response)
                {
                    TempData["resp"] = "Success";
                    return RedirectToAction("Edit", new { ID = emp.EmployeeID });
                }
            }
            TempData["resp"] = "Error";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteData(int ID)
        {
            var response = this._repository.DeleteEmployee(ID);
            if (response)
            {
                TempData["resp"] = "Success";
            }
            else
            {
                TempData["resp"] = "Error";
            }
            return RedirectToAction("Index");
        }
    }
}