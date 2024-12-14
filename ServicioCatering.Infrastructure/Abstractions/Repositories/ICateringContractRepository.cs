using ServicioCatering.Domain.CateringContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicioCatering.Infrastructure.Abstractions.Repositories;

public interface ICateringContractRepository
{
    Task AddAsync(CateringContract cateringContract);
    Task UpdateAsync(CateringContract cateringContract);
    Task<CateringContract?> GetByIdAsync(Guid id);
    Task<IEnumerable<CateringContract>> GetByPatientIdAsync(Guid patientId);
}
