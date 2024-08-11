using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployeeDetails();
        List<Employee> GetEmployeeDetailsById(int id);
        bool AddEmployeeDetils(Employee employee);
        bool UpdateEmployeeDetils(Employee employee);
        bool DeleteEmployeeDetilsById(int id);

    }
}
