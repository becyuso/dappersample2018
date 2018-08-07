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
using dappersample2018.Models.ViewModels;

namespace dappersample2018.Controllers
{
    public class EmployeeController : BaseController
    {
        //public EmployeeController()
        //{
        //    this._repository = new EmployeeRepository();
        //}

        public ActionResult Index(EmployeeViewModel model)
        {
            var employees = ApiHelper.GetResponseData<Employees>("SelectEmployees", new Dictionary<string, object>());
            model.PageInfo.ResultCount = employees.Count();
            model.List = employees.Skip((model.CurrentPageIndex - 1) * model.PageInfo.PageSize).Take(model.PageInfo.PageSize);
            return View(model);
        }

        public ActionResult ShowResult(EmployeeViewModel model)
        {
            var employees = ApiHelper.GetResponseData<Employees>("SelectEmployees", new Dictionary<string, object>());
            model.PageInfo.ResultCount = employees.Count();
            model.List = employees.Skip((model.CurrentPageIndex - 1) * model.PageInfo.PageSize).Take(model.PageInfo.PageSize);
            return View("Index", model);
        }

        public ActionResult Create()
        {
            return View(new Employees());
        }

        public ActionResult Edit(int ID)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("EmployeeID", ID);
            var employees = ApiHelper.GetResponseObject<Employees>("SelectEmployees", "SelectById", dic) ?? new Employees();
            return View(employees);
        }

        [HttpPost]
        public ActionResult CreateData(Employees emp)
        {
            if (ModelState.IsValid)
            {
                var response = ApiHelper.SendRequest("CreateEmployees", Getdic<Employees>(emp));
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