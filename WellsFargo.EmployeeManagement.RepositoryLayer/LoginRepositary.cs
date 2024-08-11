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
    public class LoginRepositary: ILoginRepository
    {
        public EmployeeContext employeeContext;
        public LoginRepositary()
        {
            employeeContext = new EmployeeContext();
        }
        public bool AddUserDetils(Login login)
        {
            employeeContext.Login.Add(login);
            employeeContext.SaveChanges();
            return true;

        }
        public bool CheckLogin(Login login)
        {
            List<Login> logindata = employeeContext.Login.ToList().FindAll(e => e.UserName == login.UserName && e.Password == login.Password);
            if (logindata.Count == 0)
                return false;
            else
                return true;

        }
    }
}
