using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService, CarService>();


string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var persistanceAssembly = typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly;
var presentationAssembly = typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly;
var applicationAssembly = typeof(CleanArchitecture.Application.AssemblyReference).Assembly;

builder.Services.AddAutoMapper(persistanceAssembly);

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(applicationAssembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
