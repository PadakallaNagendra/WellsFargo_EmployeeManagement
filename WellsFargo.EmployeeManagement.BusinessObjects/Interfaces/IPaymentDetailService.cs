using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Model;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Interfaces
{
    public interface IPaymentDetailService
    {
        List<PaymentDetailDTO> GetAllPaymentDetails();
        List<PaymentDetailDTO> GetPaymentDetailsById(int id);
        bool AddPaymentDetils(PaymentDetailDTO paymentDetailDTO);
        bool UpdatePaymentDetils(PaymentDetailDTO paymentDetailDTO);
        bool DeletePaymentDetilsById(int id);
       
    }
}
