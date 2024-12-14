using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServicioCatering.Application.Abstractions.Services;
using ServicioCatering.Application.Services;
using ServicioCatering.Application.Servicios;
using System.Reflection;

namespace ServicioCatering.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        // Registrar servicios
        services.AddScoped<ICateringContractService, CateringContractService>();
        services.AddScoped<INutritionPlanService, NutritionPlanService>();

        return services;
    }
}
