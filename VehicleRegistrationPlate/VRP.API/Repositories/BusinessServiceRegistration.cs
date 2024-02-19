using System.Reflection;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.Repositories.IServices.Procedures;
using VRP.API.Repositories.Services.Locations;
using VRP.API.Repositories.Services.Procedure;

namespace VRP.API.Repositories
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<ICommuneService, CommuneService>();
            services.AddScoped<IProcedureService, ProcedureService>();
            return services;
        }
    }
}
