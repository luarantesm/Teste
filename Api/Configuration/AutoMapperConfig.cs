using Application.Dtos;
using AutoMapper;
using Domain.Entidades;

namespace Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection ResolveAutoMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AtivoDto, Ativo>();
                cfg.CreateMap<Ativo, AtivoDto>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}