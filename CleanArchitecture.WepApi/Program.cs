using CleanArchitecture.WepApi.Configurations;
using CleanArchitecture.WepApi.Middleware;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices(
    builder.Configuration,
    builder.Host,
    typeof(IServiceInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();