using Microsoft.EntityFrameworkCore;
using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Domain.Repositories;
using TemplateDotNet.Domain.SeedWork;
using TemplateDotNet.Infra.Data.EF.Exceptions;

namespace TemplateDotNet.Infra.Data.EF.Repositories;
public class GenericRepository<TEntity> 
    : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _dbSet;
    private string EntityName { get; set; } = typeof(TEntity).Name!;

    public GenericRepository(TemplateDotNetDbContext context)
        => _dbSet = context.Set<TEntity>();

    virtual public async Task<bool> Insert(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    virtual public async Task<PaginationOutput<TEntity>> GetAll(PaginationInput input)
    {
        if(input.RecordsPerPage == 0) input.RecordsPerPage = 10;
        if(input.Page == 0) input.Page = 1;

        var entities = await _dbSet.ToListAsync();
        var toSkip = (input.Page - 1) * input.RecordsPerPage;
        var returnPaginated = entities.Skip(toSkip).Take(input.RecordsPerPage).ToList();
        var totalRecords = entities.Count;
        return PaginationOutput<TEntity>.FromOutput(totalRecords, returnPaginated);
    }

    virtual public async Task<TEntity?> GetById(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => id == x.Id);
        NotNullException.VerifyIfThisIsNull(entity, $"{EntityName} not found");
        return entity;
    }

    virtual public async Task<bool> Delete(Guid id)
    {
        var entity = await GetById(id);
        _dbSet.Remove(entity!);
        return true;
    }
}
