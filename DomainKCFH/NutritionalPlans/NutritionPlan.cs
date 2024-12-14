using System;
using System.Collections.Generic;
using ServicioCatering.Domain.Abstractions;
using ServicioCatering.Domain.ValueObjects;

namespace ServicioCatering.Domain.NutritionalPlans;

public class NutritionPlan : AggregateRoot
{
    public string Name { get; private set; }
    public string Objectives { get; private set; }
    public List<Recipe> Recipes { get; private set; } = new();

    public NutritionPlan(Guid id, string name, string objectives) : base(id)
    {
        Name = name;
        Objectives = objectives;
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }

    public void RemoveRecipe(Guid recipeId)
    {
        Recipes.RemoveAll(r => r.Id == recipeId);
    }

    public void UpdatePlanName(string planName) => Name = planName;
}
