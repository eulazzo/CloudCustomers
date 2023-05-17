using CloudCustomers.Services.Interfaces;
using CloudCustomers.Services.Services;

namespace CloudCustomers.API.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
       services.AddScoped<IUserService, UserService>();
       services.AddHttpClient<IUserService, UserService>();
    }
     
}
