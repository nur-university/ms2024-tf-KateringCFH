using ServicioCatering.Aplication.Dtos;
using ServicioCatering.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicioCatering.Application.Abstractions.Services;

public interface ICateringContractService
{
    Task<Guid> CreateCateringContractAsync(Guid patientId, Guid nutritionPlanId, DateTime deliveryDate);

    Task<IEnumerable<CateringContractDto>> GetCateringContractsByPatientAsync(Guid patientId);

    Task CancelDeliveryAsync(Guid deliveryId, DateTime cancellationDate);
}
