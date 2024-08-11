using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo.EmployeeManagement.ServiceLayer
{
    public class LoginService: ILoginManager
    {
        ILoginRepository repository;

        public LoginService(ILoginRepository _repository)
        {
            repository = _repository;
        }

        public bool AddUserDetils(Login login)
        {
            repository.AddUserDetils(login);
            return true;
        }
        public bool CheckUserLogin(Login login)
        {
            var logindata = repository.CheckLogin(login);
            return logindata;
        }

    }
}

