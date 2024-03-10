using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Configurations;
using CleanArchitecture.Persistance;
using CleanArchitecture.Persistance.Context;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices(builder.Configuration);


builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

EmailConfigurations configurations = new(
                                       Stmp: "smtp.example.com",
                                       Password: "password",
                                       Port: 587,
                                       SSL: true,
                                       Html: true);

builder.Services.AddSingleton(configurations);

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var persistanceAssembly = typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly;
var presentationAssembly = typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly;
var applicationAssembly = typeof(CleanArchitecture.Application.AssemblyReference).Assembly;


builder.Services.AddAutoMapper(persistanceAssembly);

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(applicationAssembly));

builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please insert your JWT Token into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
