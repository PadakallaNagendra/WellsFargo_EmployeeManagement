using AutoMapper;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Model;


namespace WellsFargo.MobileCommnication.ServiceLayer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaymentDetailDTO, PaymentDetail>();
            CreateMap<PaymentDetail, PaymentDetailDTO>();
        }
    }

}
