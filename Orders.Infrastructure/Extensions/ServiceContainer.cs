using Microsoft.Extensions.DependencyInjection;
using Orders.Infrastructure.Services.Categories;
using Orders.Infrastructure.Services.Users;
using Orders.Infrastructure.Services.Auth;

namespace Orders.Infrastructure.Extensions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}