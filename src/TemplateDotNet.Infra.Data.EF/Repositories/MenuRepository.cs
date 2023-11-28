using Microsoft.EntityFrameworkCore;
using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Infra.Data.EF.Repositories;
public class MenuRepository : GenericRepository<Menu>, IMenuRepository
{
    public MenuRepository(TemplateDotNetDbContext context)
        : base(context)
    { }

    public async Task<List<Menu>> GetByProfileId(Guid profileId)
    {
        return await _dbSet
            .Include(x => x.SubMenus)
            .Where(x => x.SubMenus.Any(x => x.ProfilesSubMenus.Any(x => x.ProfileId == profileId)))
            .ToListAsync();
    }
}
