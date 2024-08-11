using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo_EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentDetailsService _IStudentDetailsService;
        IEmployeeManager _EmployeeManager;
        public StudentController(IStudentDetailsService IStudentDetailsService, IEmployeeManager EmployeeManager)
        {
            this._IStudentDetailsService = IStudentDetailsService;
            this._EmployeeManager = EmployeeManager;
        }

        /// <summary>
        /// Add student Details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddStudentDetails")]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var studentData =await  _IStudentDetailsService.AddStudentDetils(student);
                return StatusCode(StatusCodes.Status201Created, "student Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateStudentDetails")]
        public async Task<IActionResult> PUT([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var studentData = await _IStudentDetailsService.UpdateStudentDetils(student);
                return StatusCode(StatusCodes.Status201Created, "Student Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        /// <summary>
        /// Get All Student Details
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetAllStudentDetails")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var studentData =  await _IStudentDetailsService.GetAllStudentDetails();
                var employeeData =  _EmployeeManager.GetAllEmployeeDetails();
                if (studentData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, studentData);
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
        /// Get Student Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudentDetailsById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var studentData = await _IStudentDetailsService.GetStudentDetailsById(id);
                if (studentData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Student Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, studentData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        /// <summary>
        /// Delete Student Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteStudentDetailsById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var studentData = await _IStudentDetailsService.GetStudentDetailsById(id);
                if (studentData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Student Id not found");
                }
                else
                {
                    var Data = await _IStudentDetailsService.GetStudentDetailsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "Student details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
