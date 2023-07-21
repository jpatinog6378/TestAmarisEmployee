using Amaris.WebAPI.Core.Employee;
using Amaris.WebAPI.Core.Employee.Interfaces;
using Amaris.WebAPI.Core.Helpers;
using Amaris.WebAPI.Core.Helpers.Interfaces;
using Amaris.WebAPI.Core.RequestWebAPI;
using Amaris.WebAPI.Core.RequestWebAPI.Interfaces;
using Amaris.WebAPI.Service.CacheService;
using Amaris.WebAPI.Service.CacheService.Interfaces;

namespace Amaris.WebAPI.Ioc.Dependencies
{
    public class RegisterDependency
    {
        //Se inicia el registro de las inyecciones de dependencias donde se inicia por la interfaz
        //y despues la clase.
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IRequestWebAPICore, RequestWebAPICore>();
            services.AddScoped<IEmployeeCore, EmployeeCore>();
            services.AddScoped<ICacheCore, CacheCore>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddMemoryCache();
        }
    }
}
