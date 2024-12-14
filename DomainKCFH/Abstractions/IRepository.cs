using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.Abstractions;

public interface IRepository<TEntity> where TEntity : AggregateRoot
{
    Task<TEntity> GetByIdAsync(Guid id, bool readOnly = false);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);

}
