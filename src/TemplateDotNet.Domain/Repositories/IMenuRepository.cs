using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Domain.Repositories;
public interface IMenuRepository : IGenericRepository<Menu>
{
    Task<List<Menu>> GetByProfileId(Guid profileId);
}
