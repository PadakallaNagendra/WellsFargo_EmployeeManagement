using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo.EmployeeManagement.ServiceLayer
{
    public class AceService : IAceService
    {
        private IAceRepository _aceRepository;
        public AceService(IAceRepository aceRepository)
        {
                this._aceRepository= aceRepository;
        }
        public async Task<string> InvokeCMSEmployeesList()
        {
         return await this._aceRepository.InvokeCMSEmployeesList();
        }
        public async Task<string> InvokeCMSEmployeesById(int id)
        {
            return await this._aceRepository.InvokeCMSEmployeesById(id);
        }

        public async Task<string> InsertCMSEmployeesData(AceDetail aceDetail)
        {
            return await this._aceRepository.InsertCMSEmployeesData(aceDetail);
        }

        public async Task<string> UpdateCMSEmployeesData(AceDetail aceDetail, int id)
        {
            return await this._aceRepository.UpdateCMSEmployeesData(aceDetail,id);
        }

        public async Task<string> DeleteCMSEmployeesData(int id)
        {
            return await this._aceRepository.DeleteCMSEmployeesData(id);
        }
    }
}
