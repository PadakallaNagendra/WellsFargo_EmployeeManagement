using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;
using WellsFargo.EmployeeManagement.DatabaseLogic.DbConnect;

namespace WellsFargo.EmployeeManagement.RepositoryLayer
{
    public class EmployeeRepository: IEmployeeRepository
    {
        public EmployeeContext employeeContext;
        public EmployeeRepository()
        {
            employeeContext = new EmployeeContext();
        }

        /// <summary>
        /// Add Employee Details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployeeDetils(Employee employee)
        {
            employeeContext.Employee.Add(employee);
            employeeContext.SaveChanges();
            return true;

        }
        public bool UpdateEmployeeDetils(Employee employee)
        {
            employeeContext.Employee.Update(employee);
            employeeContext.SaveChanges();
            return true;
        }
        /// <summary>
        /// Delete employee details id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployeeDetilsById(int id)
        {
            Employee employee = employeeContext.Employee.SingleOrDefault(e => e.EmpId == id);

            if (employee != null)
            {
                employeeContext.Employee.Remove(employee);
                employeeContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Get All Employee Details
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeDetails()
        {
            var employee = employeeContext.Employee.ToList();
            if (employee.Count == 0)
                return null;
            else
                return employee;
        }
        /// <summary>
        /// Get Employee Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeDetailsById(int id)
        {
            List<Employee> employee = employeeContext.Employee.ToList().FindAll(e => e.EmpId == id);
            if (employee.Count == 0)
                return null;
            else
                return employee;
        }
    }
}
