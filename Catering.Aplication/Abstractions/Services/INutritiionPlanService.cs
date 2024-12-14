using ServicioCatering.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace ServicioCatering.Application.Abstractions.Services;

public interface INutritionPlanService
{
    Task<Guid> CreateNutritionPlanAsync(string name, string objectives);
    Task AddRecipeToNutritionPlanAsync(Guid nutritionPlanId, Guid recipeId);
    Task<NutritionPlanDto> GetNutritionPlanDetailsAsync(Guid nutritionPlanId);
}
