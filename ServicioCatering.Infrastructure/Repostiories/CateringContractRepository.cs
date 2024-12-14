using Microsoft.EntityFrameworkCore;
using ServicioCatering.Domain.CateringContracts;
using ServicioCatering.Infrastructure.Abstractions.Repositories;
using ServicioCatering.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioCatering.Infrastructure.Repositories;

internal class CateringContractRepository : ICateringContractRepository
{
    private readonly DomainDbContext _dbContext;

    public CateringContractRepository(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(CateringContract cateringContract)
    {
        await _dbContext.CateringContracts.AddAsync(cateringContract);
    }

    public async Task UpdateAsync(CateringContract cateringContract)
    {
        _dbContext.CateringContracts.Update(cateringContract);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<CateringContract?> GetByIdAsync(Guid id)
    {
        return await _dbContext.CateringContracts
                               .Include(c => c.Deliveries)
                               .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<CateringContract>> GetByPatientIdAsync(Guid patientId)
    {
        return await _dbContext.CateringContracts
                               .Where(c => c.PatientId == patientId)
                               .ToListAsync();
    }
}
