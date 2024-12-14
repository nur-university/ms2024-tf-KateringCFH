using System;
using ServicioCatering.Domain.Abstractions;
using ServicioCatering.Domain.ValueObjects;

namespace ServicioCatering.Domain.NutritionalPlans;

public class Recipe : Entity
{
    public string Name { get; private set; }
    public NutritionalValue NutritionalValue { get; private set; }
    public string Ingredients { get; private set; }

    public Recipe(Guid id, string name, NutritionalValue nutritionalValue, string ingredients)
        : base(id)
    {
        Name = name;
        NutritionalValue = nutritionalValue;
        Ingredients = ingredients;
    }

    public void UpdateRecipe(string name, NutritionalValue nutritionalValue, string ingredients)
    {
        Name = name;
        NutritionalValue = nutritionalValue;
        Ingredients = ingredients;
    }
}
