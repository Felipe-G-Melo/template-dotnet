using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Domain.SeedWork;

namespace TemplateDotNet.Domain.Repositories;
public interface IGenericRepository<TEntity> 
    where TEntity : BaseEntity
{
    Task<bool> Insert(TEntity entity);
    Task<PaginationOutput<TEntity>> GetAll(PaginationInput input);
    Task<TEntity?> GetById(Guid id);
    Task<bool> Delete(Guid id);
}
