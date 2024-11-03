using Bussines.Services.Interfaces;
using Bussines.Repositories;
using Bussines.Services;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;

namespace Helpers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioSistemaService, UsuarioSistemaService>();
            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioSistemaRepository, UsuarioSistemaRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, string defaultConnection)
        {
            return services.AddDbContext<DataContext>(options => options.UseSqlServer(defaultConnection));
        }
    }
}
