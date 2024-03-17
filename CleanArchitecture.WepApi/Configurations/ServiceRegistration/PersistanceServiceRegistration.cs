using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infrastructure.Abstractions.Service;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repository;
using CleanArchitecture.Persistance.Service;
using CleanArchitecture.WepApi.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WepApi.Configurations.ServiceRegistration;

public class PersistanceServiceRegistration : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddAutoMapper(typeof(Persistance.AssemblyReference).Assembly);

        string connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddIdentity<AppUser, Role>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
        })
       .AddEntityFrameworkStores<AppDbContext>()
       .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

        services.AddTransient<ExceptionMiddleware>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Service
        services.AddScoped<ICarService, CarService>();
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
