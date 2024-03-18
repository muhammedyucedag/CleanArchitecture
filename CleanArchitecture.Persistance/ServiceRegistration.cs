using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infrastructure.Abstractions.Service;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Middleware;
using CleanArchitecture.Persistance.Repository;
using CleanArchitecture.Persistance.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddAutoMapper(typeof(AssemblyReference).Assembly);

        string connectionString = configurationManager.GetConnectionString("SqlServer");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
        })
       .AddEntityFrameworkStores<AppDbContext>()
       .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

        services.AddTransient<ExceptionMiddleware>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Service
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IRoleService, RoleService>();
        //services.AddScoped<IEmailSendingService, EmailSendingService>();
        services.AddScoped<IUserService, UserService>();


        //Repository
        services.AddScoped<ICarReadRepository, CarReadRepository>();
        services.AddScoped<ICarWriteRepository, CarWriteRepository>();

        services.AddScoped<IUserRoleWriteRepository, UserRoleWriteRepository>();
        services.AddScoped<IUserRoleReadRepository, UserRoleReadRepository>();
    }
}
