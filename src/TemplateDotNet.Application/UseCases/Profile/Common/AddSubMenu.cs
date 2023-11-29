using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Profile.Common;
public class AddSubMenu
{    
    public static async Task Add(
        IProfilesSubMenusRepository _profilesSubMenusRepository,
        List<ProfilesSubMenusInput> profilesSubMenus,
        Guid profileId
    )
    {
        foreach (var item in profilesSubMenus)
        {
            var subMenus = new ProfilesSubMenus(item.SubMenuId, profileId);
            await _profilesSubMenusRepository.Insert(subMenus);
        }
    }
}
