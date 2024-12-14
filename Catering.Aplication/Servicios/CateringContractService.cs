using System;
using System.Threading.Tasks;
using ServicioCatering.Aplication.Dtos;
using ServicioCatering.Application.Abstractions.Services;
using ServicioCatering.Domain.CateringContracts;
using ServicioCatering.Domain.Repositories;

namespace ServicioCatering.Application.Services;

public class CateringContractService : ICateringContractService
{
    private readonly ICateringContractRepository _repository;

    public CateringContractService(ICateringContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateCateringContractAsync(Guid patientId, Guid nutritionPlanId, DateTime deliveryDate)
    {
        try
        {
            var contract = new CateringContract(Guid.NewGuid(), patientId, nutritionPlanId, deliveryDate);
            await _repository.AddAsync(contract);

            return contract.Id;
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Failed to create the catering contract: {ex.Message}");
        }
    }

    public async Task<IEnumerable<CateringContractDto>> GetCateringContractsByPatientAsync(Guid patientId)
    {
        var contracts = await _repository.GetByPatientIdAsync(patientId);
        return contracts.Select(contract => new CateringContractDto
        {
            Id = contract.Id,
            PatientId = contract.PatientId,
            NutritionPlanId = contract.NutritionPlanId,
            DeliveryDate = contract.DeliveryCalendar.DeliveryDates.FirstOrDefault()
        });
    }

    public async Task CancelDeliveryAsync(Guid deliveryId, DateTime cancellationDate)
    {
        var delivery = await _repository.GetDeliveryByIdAsync(deliveryId);

        if (delivery == null)
            throw new InvalidOperationException("Delivery not found");

        delivery.Cancel(cancellationDate);
        await _repository.UpdateAsync(delivery);
    }

}
