using ServicioCatering.Domain.NutritionalPlans;
using System;

namespace ServicioCatering.Infrastructure.DomainModel.Factories;

public static class NutritionPlanFactory
{
    public static NutritionPlan Create(Guid id, string name, string objectives)
    {
        return new NutritionPlan(id, name, objectives);
    }
}
