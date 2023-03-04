using Application;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Repositorios;
using Infra.Context;
using Infra.Repositorio;

namespace Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApplicationAtivo, ApplicationAtivo>();
            services.AddScoped<IRepositoryAtivo, RepositoryAtivo>();
            services.AddScoped<IApplicationYahoo, ApplicationYahoo>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}