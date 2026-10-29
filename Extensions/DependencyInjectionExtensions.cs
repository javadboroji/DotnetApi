using DotnetApi.Interfaces;
using DotnetApi.Repository;
using DotnetApi.Services;

namespace DotnetApi.Extensions;


public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(
          this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleService, RoleService>();   
        services.AddTransient<LifeTimeService>();

        return services;
    }
}

