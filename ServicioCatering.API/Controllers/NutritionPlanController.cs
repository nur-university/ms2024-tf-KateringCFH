using Microsoft.AspNetCore.Mvc;
using MediatR;
using ServicioCatering.Application.Commands.AddRecipeToNutritionPlan;
using ServicioCatering.Application.DTOs;
using System;
using System.Threading.Tasks;
using ServicioCatering.Application.Commands.CreateNutritionPlan;

namespace ServicioCatering.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NutritionPlanController : ControllerBase
{
    private readonly IMediator _mediator;

    public NutritionPlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateNutritionPlan(string name, string objectives)
    {
        var command = new CreateNutritionPlanCommand(name, objectives);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{nutritionPlanId}/add-recipe")]
    public async Task<ActionResult> AddRecipe(Guid nutritionPlanId, Guid recipeId)
    {
        var command = new AddRecipeToNutritionPlanCommand(nutritionPlanId, recipeId);
        await _mediator.Send(command);
        return NoContent();
    }
}
