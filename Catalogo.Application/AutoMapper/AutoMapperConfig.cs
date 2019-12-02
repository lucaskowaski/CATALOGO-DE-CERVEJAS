using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Catalogo.Application.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ModelToViewModelMappingProfile),
                typeof(ViewModelToModelMappingProfile));
        }
    }
}
