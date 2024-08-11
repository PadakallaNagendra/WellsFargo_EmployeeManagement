using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;
using WellsFargo.EmployeeManagement.DatabaseLogic.DbConnect;

namespace WellsFargo.EmployeeManagement.RepositoryLayer
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        public PaymentDetailContext paymentDetailContext;
        public PaymentDetailRepository() {

            paymentDetailContext = new PaymentDetailContext();
        }

        public bool AddPaymentDetils(PaymentDetail paymentDetail)
        {
            paymentDetailContext.PaymentDetail.Add(paymentDetail);
            paymentDetailContext.SaveChanges();
            return true;
        }
        public bool UpdatePaymentDetils(PaymentDetail paymentDetail)
        {
            paymentDetailContext.PaymentDetail.Update(paymentDetail);
            paymentDetailContext.SaveChanges();
            return true;
        }
        public bool DeletePaymentDetilsById(int id)
        {
            PaymentDetail paymentDetail = paymentDetailContext.PaymentDetail.SingleOrDefault(p => p.PaymentDetailId == id);

            if (paymentDetail != null)
            {
                paymentDetailContext.PaymentDetail.Remove(paymentDetail);
                paymentDetailContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PaymentDetail> GetAllPaymentDetails()
        {
            var paymentDetail = paymentDetailContext.PaymentDetail.ToList();
            if (paymentDetail.Count == 0)
                return null;
            else
                return paymentDetail;
        }

        public List<PaymentDetail> GetPaymentDetailsById(int id)
        {
            List<PaymentDetail> paymentDetail = paymentDetailContext.PaymentDetail.ToList().FindAll(p => p.PaymentDetailId == id);
            if (paymentDetail.Count == 0)
                return null;
            else
                return paymentDetail;
        }

       
    }
}
