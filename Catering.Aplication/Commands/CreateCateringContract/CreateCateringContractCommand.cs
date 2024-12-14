using ServicioCatering.Application.Abstractions.Commands;
using System;

namespace ServicioCatering.Application.Commands.CreateCateringContract;

public record CreateCateringContractCommand(Guid PatientId, Guid NutritionPlanId, DateTime StartDate) : ICommand<Guid>;
