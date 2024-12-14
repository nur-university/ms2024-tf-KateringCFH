using MediatR;
using System;

namespace ServicioCatering.Application.Commands.CreateNutritionPlan;

public record CreateNutritionPlanCommand(string Name, string Objectives) : IRequest<Guid>;
