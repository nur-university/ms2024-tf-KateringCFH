using MediatR;
using ServicioCatering.Domain.NutritionalPlans;
using ServicioCatering.Domain.Repositories;
using ServicioCatering.Infrastructure.Abstractions.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioCatering.Application.Commands.AddRecipeToNutritionPlan;

public class AddRecipeToNutritionPlanCommandHandler : IRequestHandler<AddRecipeToNutritionPlanCommand, Unit>
{
    private readonly INutritionPlanRepository _repository;

    public AddRecipeToNutritionPlanCommandHandler(INutritionPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddRecipeToNutritionPlanCommand request, CancellationToken cancellationToken)
    {
        var plan = await _repository.GetByIdAsync(request.NutritionPlanId);

        if (plan == null)
            throw new InvalidOperationException("Nutrition plan not found.");

        //var recipe = new Recipe(request.RecipeId, "Sample Recipe", "Ingredients...");
        //plan.AddRecipe(recipe);

        await _repository.UpdateAsync(plan);

        return Unit.Value;
    }
}
