using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infrastructure.Abstractions.Service;
using CleanArchitecture.Infrastructure.Configurations;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repository;
using CleanArchitecture.Persistance.Service;
using CleanArchitecture.WepApi.Middleware;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IEmailSendingService, EmailSendingService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICarReadRepository, CarReadRepository>();
builder.Services.AddScoped<ICarWriteRepository, CarWriteRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ExcepitonMiddleware>();

EmailConfigurations configurations = new(
                                       Stmp: "smtp.example.com",
                                       Password: "password",
                                       Port: 587,
                                       SSL: true,
                                       Html: true);

builder.Services.AddSingleton(configurations);


string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>().AddEntityFrameworkStores<AppDbContext>();

var persistanceAssembly = typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly;
var presentationAssembly = typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly;
var applicationAssembly = typeof(CleanArchitecture.Application.AssemblyReference).Assembly;


builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));


builder.Services.AddAutoMapper(persistanceAssembly);

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(applicationAssembly));

builder.Services.AddValidatorsFromAssembly(applicationAssembly); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
