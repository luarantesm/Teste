using AutoMapper;
using Application.Dtos;
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
                cfg.CreateMap<IEnumerable<AtivoDto>, IEnumerable<Ativo>>();
                cfg.CreateMap<IEnumerable<Ativo>, IEnumerable<AtivoDto>>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
