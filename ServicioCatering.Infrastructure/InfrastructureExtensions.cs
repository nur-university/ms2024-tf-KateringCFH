using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServicioCatering.Domain.Abstractions;
using ServicioCatering.Infrastructure.Abstractions.Repositories;
using ServicioCatering.Infrastructure.DomainModel;
using ServicioCatering.Infrastructure.Repositories;
using ServicioCatering.Infrastructure.StoredModel;

namespace ServicioCatering.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // DbContext para entidades de dominio
        services.AddDbContext<DomainDbContext>(options =>
            options.UseSqlServer(connectionString));

        // DbContext para modelos de almacenamiento
        services.AddDbContext<StoredDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Repositorios
        services.AddScoped<ICateringContractRepository, CateringContractRepository>();
        services.AddScoped<INutritionPlanRepository, NutritionPlanRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
