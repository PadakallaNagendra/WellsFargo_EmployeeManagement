using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace WellsFargo.MobileCommnication.ServiceLayer

{
    public static class AutoMapperConfig
    {
        public static void InitializeMap(IServiceCollection services)
        {
            //Initialize all AutoMapper profiles
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<AutoMapperProfile>();


            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}


