using MediatR;
using ServicioCatering.Domain.NutritionalPlans;
using ServicioCatering.Domain.Repositories;
using ServicioCatering.Infrastructure.Abstractions.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioCatering.Application.Commands.CreateNutritionPlan;

public class CreateNutritionPlanCommandHandler : IRequestHandler<CreateNutritionPlanCommand, Guid>
{
    private readonly INutritionPlanRepository _nutritionPlanRepository;

    public CreateNutritionPlanCommandHandler(INutritionPlanRepository nutritionPlanRepository)
    {
        _nutritionPlanRepository = nutritionPlanRepository;
    }

    public async Task<Guid> Handle(CreateNutritionPlanCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Crear el nuevo plan de nutrición usando el repositorio
            var nutritionPlan = new NutritionPlan(Guid.NewGuid(), request.Name, request.Objectives);

            // Agregar el plan al repositorio
            await _nutritionPlanRepository.AddAsync(nutritionPlan);

            // Confirmar los cambios en la base de datos
            return nutritionPlan.Id;
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Failed to create the nutrition plan: {ex.Message}");
        }
    }
}
