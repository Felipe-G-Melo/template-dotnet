using Microsoft.EntityFrameworkCore;
using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;
using TemplateDotNet.Infra.Data.EF.Exceptions;

namespace TemplateDotNet.Infra.Data.EF.Repositories;
public class ProfileRepository 
    : GenericRepository<Profile>, IProfileRepository
{
    public ProfileRepository(TemplateDotNetDbContext context)
        : base(context)
    {
    }

    override public async Task<Profile?> GetById(Guid id)
    {
        var entity = await _dbSet.Include(x => x.ProfilesSubMenus).FirstOrDefaultAsync(x => id == x.Id);
        NotNullException.VerifyIfThisIsNull(entity, $"Profile not found");
        return entity;
    }

    override public async Task<PaginationOutput<Profile>> GetAll(PaginationInput input)
    {
        if (input.RecordsPerPage == 0) input.RecordsPerPage = 10;
        if (input.Page == 0) input.Page = 1;

        var entities = await _dbSet.Include(x => x.ProfilesSubMenus).ToListAsync();
        var toSkip = (input.Page - 1) * input.RecordsPerPage;
        var returnPaginated = entities.Skip(toSkip).Take(input.RecordsPerPage).ToList();
        var totalRecords = entities.Count;
        return PaginationOutput<Profile>.FromOutput(totalRecords, returnPaginated);
    }
}
