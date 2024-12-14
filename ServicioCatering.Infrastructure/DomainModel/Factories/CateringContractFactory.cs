using ServicioCatering.Domain.CateringContracts;
using ServicioCatering.Domain.ValueObjects;
using System;

namespace ServicioCatering.Infrastructure.DomainModel.Factories;

public static class CateringContractFactory
{
    public static CateringContract Create(Guid id, Guid patientId, Guid nutritionPlanId, Calendar deliveryCalendar)
    {
        return new CateringContract(id, patientId, nutritionPlanId, deliveryCalendar);
    }
}
