using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo_EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeManager manager;
        public EmployeeController(IEmployeeManager _manager)
        {
            manager = _manager;
        }

        /// <summary>
        /// Add Employee Details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddEmployeeDetails")]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var employees = manager.AddEmployeeDetils(employee);
                return StatusCode(StatusCodes.Status201Created, "Employee Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IActionResult PUT([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var employees = manager.UpdateEmployeeDetils(employee);
                return StatusCode(StatusCodes.Status201Created, "Employee Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        /// <summary>
        /// Get All Employee Details
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetAllEmployeeDetails")]
        public IActionResult Get()
        {
            try
            {
                var employee = manager.GetAllEmployeeDetails();
                if (employee != null)
                {
                    return StatusCode(StatusCodes.Status200OK, employee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        /// <summary>
        /// Get Employee Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeDetailsById/{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var emp = manager.GetEmployeeDetailsById(id);
                if (emp == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Employee Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, emp);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        /// <summary>
        /// Delete Employee Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteEmployeeDetailsById/{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var emp = manager.GetEmployeeDetailsById(id);
                if (emp == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Employee Id not found");
                }
                else
                {
                    var employee = manager.DeleteEmployeeDetilsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "Employee details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
