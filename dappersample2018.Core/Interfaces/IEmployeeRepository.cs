using dappersample2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dappersample2018.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employees> GetEmployees();
        Employees GetEmployeebyID(int id);
        bool CreateEmployee(Employees emp);
        bool EditEmployee(Employees emp);
        bool DeleteEmployee(int id);
    }
}
