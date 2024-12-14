using MediatR;
using System;

namespace ServicioCatering.Application.Commands.AddRecipeToNutritionPlan;

public record AddRecipeToNutritionPlanCommand(Guid NutritionPlanId, Guid RecipeId) : IRequest<Unit>;
