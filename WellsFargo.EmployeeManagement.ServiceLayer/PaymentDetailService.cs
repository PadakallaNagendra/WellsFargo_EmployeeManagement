using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;
using WellsFargo.EmployeeManagement.BusinessObjects.Model;
using AutoMapper;
namespace WellsFargo.EmployeeManagement.ServiceLayer
{
    public class PaymentDetailService : IPaymentDetailService
    {
        IPaymentDetailRepository paymentDetailRepository;

        private readonly IMapper _mapper;

        public PaymentDetailService(IPaymentDetailRepository _paymentDetailRepository) 
        {
            paymentDetailRepository = _paymentDetailRepository;

        }

        public bool AddPaymentDetils(PaymentDetailDTO paymentDetailDTO)
        {
            PaymentDetail obj = new PaymentDetail();
            obj.PaymentDetailId = paymentDetailDTO.PaymentDetailId;
            obj.SecurityCode = paymentDetailDTO.SecurityCode;
            obj.CardOwnerName = paymentDetailDTO.CardOwnerName;
            obj.CardNumber = paymentDetailDTO.CardNumber;
            obj.ExpirationDate = paymentDetailDTO.ExpirationDate;
            //_mapper.Map(paymentDetailDTO, obj);
            paymentDetailRepository.AddPaymentDetils(obj);
            return true;
        }

        public bool UpdatePaymentDetils(PaymentDetailDTO paymentDetailDTO)
        {
            PaymentDetail obj = new PaymentDetail();
            obj.PaymentDetailId = paymentDetailDTO.PaymentDetailId;
            obj.SecurityCode = paymentDetailDTO.SecurityCode;
            obj.CardOwnerName = paymentDetailDTO.CardOwnerName;
            obj.CardNumber = paymentDetailDTO.CardNumber;
            obj.ExpirationDate = paymentDetailDTO.ExpirationDate;
            // _mapper.Map(paymentDetailDTO, obj);
            paymentDetailRepository.UpdatePaymentDetils(obj);
            return true;
        }

        public bool DeletePaymentDetilsById(int id)
        {

            var payment = paymentDetailRepository.DeletePaymentDetilsById(id);
            if (payment == false)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public List<PaymentDetailDTO> GetAllPaymentDetails()
        {
            List<PaymentDetailDTO> listobj = new List<PaymentDetailDTO>();

           var payment = paymentDetailRepository.GetAllPaymentDetails();
            foreach(var item in payment)
            {
                PaymentDetailDTO objdto = new PaymentDetailDTO();
                objdto.PaymentDetailId = item.PaymentDetailId;
                objdto.CardNumber = item.CardNumber;
                objdto.ExpirationDate = item.ExpirationDate;
                objdto.CardOwnerName = item.CardOwnerName;
                objdto.SecurityCode = item.SecurityCode;
                listobj.Add(objdto);

            }
            return listobj;
        }

        public List<PaymentDetailDTO> GetPaymentDetailsById(int id)
        {
            List<PaymentDetailDTO> listobj = new List<PaymentDetailDTO>();
            var payment = paymentDetailRepository.GetPaymentDetailsById(id);
            foreach (var item in payment)
            {
                PaymentDetailDTO objdto = new PaymentDetailDTO();
                objdto.PaymentDetailId = item.PaymentDetailId;
                objdto.CardNumber = item.CardNumber;
                objdto.ExpirationDate = item.ExpirationDate;
                objdto.CardOwnerName = item.CardOwnerName;
                objdto.SecurityCode = item.SecurityCode;
                listobj.Add(objdto);

            }
            return listobj;
        }

        
    }
}
