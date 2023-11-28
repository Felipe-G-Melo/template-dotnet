using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Infra.Data.EF.Repositories;
public class SubMenuRepository
    : GenericRepository<SubMenu>, ISubMenuRepository
{
    public SubMenuRepository(TemplateDotNetDbContext context) : base(context)
    {
    }
}
