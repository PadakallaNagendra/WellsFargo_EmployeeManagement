using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Interfaces
{
    public interface IAceService
    {
        Task<string> InvokeCMSEmployeesList();
        Task<string> InvokeCMSEmployeesById(int id);
        Task<string> InsertCMSEmployeesData(AceDetail aceDetail);
        Task<string> UpdateCMSEmployeesData(AceDetail aceDetail, int id);
        Task<string> DeleteCMSEmployeesData(int id);
    }
}
