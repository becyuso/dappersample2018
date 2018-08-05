using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dappersample2018.Core.Interfaces;
using dappersample2018.Core.Entities;
using dappersample2018.Data.Repositories;
using dappersampleApi2018.ApiHelper;
using Newtonsoft.Json;

namespace dappersample2018.Controllers
{
    public class EmployeeController : BaseController
    {
        //public EmployeeController()
        //{
        //    this._repository = new EmployeeRepository();
        //}

        public ActionResult Index()
        {
            var employees = ApiHelper.GetResponseData<Employees>("SelectEmployees", new Dictionary<string, object>());
            //var employees = this._repository.GetEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View(new Employees());
        }

        public ActionResult Edit(int ID)
        {
            var employees = ApiHelper.GetResponseData<Employees>("SelectEmployees", new Dictionary<string, object>()).FirstOrDefault(x => x.EmployeeID == ID) ?? new Employees();
            //var employees = this._repository.GetEmployeebyID(ID);
            return View(employees);
        }

        [HttpPost]
        public ActionResult CreateData(Employees emp)
        {
            if (ModelState.IsValid)
            {
                var response = ApiHelper.SendRequest("CreateEmployees", Getdic<Employees>(emp));
                //var response = this._repository.CreateEmployee(emp);
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
                var response = ApiHelper.SendRequest("UpdateEmployees", Getdic<Employees>(emp));
                //var response = this._repository.EditEmployee(emp);
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
            var dic = new Dictionary<string, object>();
            dic.Add("EmployeeID", ID);
            var response = ApiHelper.SendRequest("DeleteEmployees", dic);
            //var response = this._repository.DeleteEmployee(ID);
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

        protected static Dictionary<string, object> Getdic<T>(T model) where T : class
        {
            var dic = new Dictionary<string, object>();
            var pro = model.GetType().GetProperties();
            foreach (var item in pro)
            {
                dic.Add(item.Name, item.GetValue(model));
            }
            return dic;
        }
    }
}