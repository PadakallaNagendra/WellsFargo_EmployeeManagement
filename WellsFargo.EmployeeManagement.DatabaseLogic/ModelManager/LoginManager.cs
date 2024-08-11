using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo.EmployeeManagement.DatabaseLogic.ModelManager
{
    public class LoginManager: ILoginManager
    {
        ILoginManager manager;
        public LoginManager(ILoginManager _manager)
        {
            manager = _manager;
        }
        public bool AddUserDetils(Login login)
        {
            Login user = new Login();
            user.UserId = login.UserId;
            user.UserName = login.UserName;
            user.Password = login.Password;
            manager.AddUserDetils(user);
            return true;
        }
        public bool CheckUserLogin(Login login)
        {
            bool logindata = manager.CheckUserLogin(login);
            if (logindata != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
