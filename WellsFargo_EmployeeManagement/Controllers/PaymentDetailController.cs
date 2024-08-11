using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;
using WellsFargo.EmployeeManagement.BusinessObjects.Model;

namespace WellsFargo_EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        IPaymentDetailService paymentDetailService;

        public PaymentDetailController(IPaymentDetailService _paymentDetailService)
        {
            paymentDetailService = _paymentDetailService;

        }

        /// <summary>
        /// Add Payment Details
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPaymentDetails")]
        public IActionResult Post([FromBody] PaymentDetailDTO paymentDetailDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var paymentDetails = paymentDetailService.AddPaymentDetils(paymentDetailDTO);
                return StatusCode(StatusCodes.Status201Created, "Payment Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

            [HttpPut]
            [Route("UpdatePaymentDetails")]

            public IActionResult PUT([FromBody] PaymentDetailDTO paymentDetailDTO)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                    }
                    var paymentDetails = paymentDetailService.UpdatePaymentDetils(paymentDetailDTO);
                    return StatusCode(StatusCodes.Status201Created, "Employee Details Updated Succesfully");
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
                }
            }

        /// <summary>
        /// Get All Payment Details
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetAllPaymentDetails")]
        public IActionResult Get()
        {
            try
            {
                var paymentDetails = paymentDetailService.GetAllPaymentDetails();
                if (paymentDetails != null)
                {
                    return StatusCode(StatusCodes.Status200OK, paymentDetails);
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
        /// Get Payment Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPaymentDetailsById/{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var payment = paymentDetailService.GetPaymentDetailsById(id);
                if (payment == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Employee Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, payment);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        /// <summary>
        /// Delete Payment Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletePaymentDetailsById/{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var emp = paymentDetailService.GetPaymentDetailsById(id);
                if (emp == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Employee Id not found");
                }
                else
                {
                    var paymentdetail = paymentDetailService.DeletePaymentDetilsById(id);


                    return StatusCode(StatusCodes.Status204NoContent, "Payment details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
