using System;

namespace ServicioCatering.Infrastructure.StoredModel.Entities;

internal class NutritionPlanStoredModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Objectives { get; set; }
}
