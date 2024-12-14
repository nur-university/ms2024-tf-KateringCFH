using Microsoft.EntityFrameworkCore;
using MediatR;
using ServicioCatering.Infrastructure.Extensions;
using ServicioCatering.Application;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configuración de base de datos y capas de infraestructura y aplicación


builder.Services.AddApplication();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString); 
//builder.Services.AddMediatR(typeof(Program)); 

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
