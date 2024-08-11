using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo.EmployeeManagement.DatabaseLogic.ModelManager
{
    public class EmployeeManager: IEmployeeManager
    {
        IEmployeeManager manager;
        public EmployeeManager(IEmployeeManager _manager)
        {
            manager = _manager;
        }

        /// <summary>
        /// To pass the details to EmployeeManager to Add Employee Details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployeeDetils(Employee employee)
        {
            Employee emp = new Employee();
            emp.EmpId = employee.EmpId;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Age = employee.Age;
            emp.UserName = employee.UserName;
            emp.Password = employee.Password;
            emp.Designation = employee.Designation;
            emp.Address = employee.Address;
            manager.AddEmployeeDetils(emp);
            return true;
        }
        public bool UpdateEmployeeDetils(Employee employee)
        {
            List<Employee> employeeList = manager.GetEmployeeDetailsById(employee.EmpId);
            if (employeeList != null)
            {
                Employee employeeData = employeeList[0];
                employeeData.FirstName = employee.FirstName;
                employeeData.LastName = employee.LastName;
                employeeData.Age = employee.Age;
                employeeData.UserName = employee.UserName;
                employeeData.Password = employee.Password;
                employeeData.Designation = employee.Designation;
                employeeData.Address = employee.Address;
                manager.UpdateEmployeeDetils(employeeData);
            }

            return true;
        }
        /// <summary>
        /// To pass the id to EmployeeManager to Delete Employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployeeDetilsById(int id)
        {
            var emp = manager.DeleteEmployeeDetilsById(id);
            if (emp == false)
            {
                return false;
            }
            else
            {

                return true;
            }
        }
        /// <summary>
        /// To Get All Employee Details
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeDetails()
        {
            List<Employee> employees = manager.GetAllEmployeeDetails();

            if (employees != null)
            {
                List<Employee> employeeModels = employees.Select(item => new Employee
                {
                    EmpId = item.EmpId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    UserName = item.UserName,
                    Password = item.Password,
                    Designation = item.Designation
                }).ToList();
                return employeeModels;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// To pass the id to Employeemanager to Get Employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeDetailsById(int id)
        {
            List<Employee> employees = manager.GetEmployeeDetailsById(id);
            if (employees != null)
            {
                List<Employee> employeeModels = employees.Select(item => new Employee
                {
                    EmpId = item.EmpId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    UserName = item.UserName,
                    Password = item.Password,
                    Designation = item.Designation
                }).ToList();
                return employeeModels;
            }
            else
            {
                return null;
            }

        }
    }
}
