using MediatR;
using ServicioCatering.Application.Abstractions.Commands;
using ServicioCatering.Domain.CateringContracts;
using ServicioCatering.Domain.Repositories;
using ServicioCatering.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioCatering.Application.Commands.CreateCateringContract;

public class CreateCateringContractCommandHandler : ICommandHandler<CreateCateringContractCommand, Guid>
{
    private readonly ICateringContractRepository _repository;

    public CreateCateringContractCommandHandler(ICateringContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCateringContractCommand request, CancellationToken cancellationToken)
    {
        var calendar = new Calendar();
        calendar.AddDate(request.StartDate);

        var cateringContract = new CateringContract(
            Guid.NewGuid(),
            request.PatientId,
            request.NutritionPlanId,
            calendar
        );

        await _repository.AddAsync(cateringContract);

        return cateringContract.Id;
    }
}
