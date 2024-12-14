using MediatR;
using ServicioCatering.Aplication.Dtos;
using ServicioCatering.Application.Abstractions.Queries;
using ServicioCatering.Application.DTOs;
using ServicioCatering.Domain.Repositories;

namespace ServicioCatering.Application.Queries.GetCateringContractsByPatient;

public class GetCateringContractsByPatientQueryHandler : IQueryHandler<GetCateringContractsByPatientQuery, IEnumerable<CateringContractDto>>
{
    private readonly ICateringContractRepository _repository;

    public GetCateringContractsByPatientQueryHandler(ICateringContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CateringContractDto>> Handle(GetCateringContractsByPatientQuery request, CancellationToken cancellationToken)
    {
        var contracts = await _repository.GetByPatientIdAsync(request.PatientId);

        return contracts.Select(c => new CateringContractDto
        {
            Id = c.Id,
            PatientId = c.PatientId,
            NutritionPlanId = c.NutritionPlanId,
            Status = "Active"
        });
    }
}
