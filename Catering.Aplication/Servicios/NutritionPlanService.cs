using ServicioCatering.Application.Abstractions.Services;
using ServicioCatering.Application.DTOs;
using ServicioCatering.Domain.NutritionalPlans;
using ServicioCatering.Infrastructure.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Application.Servicios;

public class NutritionPlanService : INutritionPlanService
{
    private readonly INutritionPlanRepository _nutritionPlanRepository;

    public NutritionPlanService(INutritionPlanRepository nutritionPlanRepository)
    {
        _nutritionPlanRepository = nutritionPlanRepository;
    }

    public Task AddRecipeToNutritionPlanAsync(Guid nutritionPlanId, Guid recipeId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateNutritionPlanAsync(string name, string objectives)
    {
        var plan = new NutritionPlan(Guid.NewGuid(), name, objectives);
        await _nutritionPlanRepository.AddAsync(plan);
        return plan.Id;
    }

    public Task<NutritionPlanDto> GetNutritionPlanDetailsAsync(Guid nutritionPlanId)
    {
        throw new NotImplementedException();
    }
}
