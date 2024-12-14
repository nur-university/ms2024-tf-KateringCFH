using Microsoft.AspNetCore.Mvc;
using MediatR;
using ServicioCatering.Application.Commands.CreateCateringContract;
using ServicioCatering.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicioCatering.Aplication.Dtos;
using ServicioCatering.Application.Queries.GetCateringContractsByPatient;

namespace ServicioCatering.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CateringContractController : ControllerBase
{
    private readonly IMediator _mediator;

    public CateringContractController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCateringContract(Guid patientId, Guid nutritionPlanId, DateTime startDate)
    {
        var command = new CreateCateringContractCommand(patientId, nutritionPlanId, startDate);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{patientId}")]
    public async Task<ActionResult<IEnumerable<CateringContractDto>>> GetContractsByPatient(Guid patientId)
    {
        var query = new GetCateringContractsByPatientQuery(patientId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
