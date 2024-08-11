using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Interfaces
{
    public interface ILoginManager
    {
        bool AddUserDetils(Login login);
        bool CheckUserLogin(Login login);
    }
}
