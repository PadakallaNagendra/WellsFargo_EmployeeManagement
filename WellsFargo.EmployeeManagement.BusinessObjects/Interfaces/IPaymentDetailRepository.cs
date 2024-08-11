using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Model;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Interfaces
{
  public interface IPaymentDetailRepository
    {
        List<PaymentDetail> GetAllPaymentDetails();
        List<PaymentDetail> GetPaymentDetailsById(int id);
        bool AddPaymentDetils(PaymentDetail paymentDetail);
        bool UpdatePaymentDetils(PaymentDetail paymentDetail);
        bool DeletePaymentDetilsById(int id);
        
    }
}
