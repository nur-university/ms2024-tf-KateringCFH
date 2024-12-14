using ServicioCatering.Domain.NutritionalPlans;
using System;
using System.Threading.Tasks;

namespace ServicioCatering.Infrastructure.Abstractions.Repositories;

public interface INutritionPlanRepository
{
    Task AddAsync(NutritionPlan nutritionPlan);
    Task UpdateAsync(NutritionPlan nutritionPlan);
    Task<NutritionPlan?> GetByIdAsync(Guid id);
    Task<NutritionPlan?> GetByNameAsync(string name);
}
