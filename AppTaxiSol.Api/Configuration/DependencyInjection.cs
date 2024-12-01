using AppTaxiSol.Data.Interfaces;
using AppTaxiSol.Data.Repositories;

namespace AppTaxiSol.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDetalleViajeRepository, DetalleViajeRepository>();
            services.AddScoped<IGrupoUsuariosRepository, GrupoUsuariosRepository>();
            services.AddScoped<IGrupoUsuariosDetalleRepository, GrupoUsuariosDetalleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITaxiRepository, TaxiRepository>();
            services.AddScoped<IUserGroupRequestsRepository, UserGroupRequestsRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IViajeRepository, ViajeRepository>();

            return services;
        }
    }
}
