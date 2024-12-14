using System;

namespace ServicioCatering.Infrastructure.StoredModel.Entities;

internal class CateringContractStoredModel
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid NutritionPlanId { get; set; }
    public string Status { get; set; }
}
