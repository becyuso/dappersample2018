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
        //protected IEmployeeRepository _repository { get; set; }

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