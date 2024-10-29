using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Bussines.Mappings;

namespace Helpers.Extensions
{
    public static class ServiceAutoMappingExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ConfigurationMapping>();
                cfg.AddExpressionMapping();
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}

