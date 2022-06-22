using MrtProjectTemplate.Dapper.Concrete;
using MrtProjectTemplate.Services.User;

namespace MrtProjectTemplate.API.Installers
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IDapperManager, DapperManager>(); 
            services.AddTransient<IUserService, UserService>();
        }
    }
}
