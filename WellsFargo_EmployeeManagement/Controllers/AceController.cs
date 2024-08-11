using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo_EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AceController : ControllerBase
    {
        private readonly IAceService _aceService;
        public AceController(IAceService aceService)
        {
                this._aceService = aceService;
        }
        [HttpGet]
        [Route("GetAce")]
        public async Task<string> GetAceData()
        {
            return await _aceService.InvokeCMSEmployeesList();
        }

        [HttpGet]
        [Route("GetAceDetailsById/{id}")]
        public async Task<string> GetAceDataById(int id)
        {
            return await _aceService.InvokeCMSEmployeesById(id);
        }
        [HttpPost]
        [Route("InsertAceDetails")]
        public async Task<string> InsertAceDetails([FromBody]AceDetail aceDetail)
        {
            return await _aceService.InsertCMSEmployeesData(aceDetail);
        }
        [HttpPost]
        [Route("UpdateAceDetails/{id}")]
        public async Task<string> UpdateAceDetails([FromBody] AceDetail aceDetail,[FromRoute]int id)
        {
            return await _aceService.UpdateCMSEmployeesData(aceDetail,id);
        }
        [HttpDelete]
        [Route("DeleteAceDetailsById/{id}")]
        public async Task<string> DeleteAceDataById(int id)
        {
            return await _aceService.DeleteCMSEmployeesData(id);
        }
    }
}
