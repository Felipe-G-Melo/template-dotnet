using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Domain.Repositories;
public interface IProfilesSubMenusRepository 
    : IGenericRepository<ProfilesSubMenus>
{
    void RemoveRange(List<ProfilesSubMenus> profilesSubMenus);
}
