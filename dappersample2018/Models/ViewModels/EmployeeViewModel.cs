using dappersample2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dappersample2018.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            PageInfo = new Models.PageInfo();
            CurrentPageIndex = 1;
        }
        public IEnumerable<Employees> List { get; set; }
        public PageInfo PageInfo { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}