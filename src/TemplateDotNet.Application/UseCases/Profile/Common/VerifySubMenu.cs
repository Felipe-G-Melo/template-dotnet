using TemplateDotNet.Domain.Exceptions;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Profile.Common;
public class VerifySubMenu
{
    private readonly ISubMenuRepository _subMenuRepository;
    private readonly List<ProfilesSubMenusInput> _profilesSubMenus;

    public VerifySubMenu(ISubMenuRepository subMenuRepository, List<ProfilesSubMenusInput> profilesSubMenus)
    {
        _subMenuRepository = subMenuRepository;
        _profilesSubMenus = profilesSubMenus;
    }

    public async Task IfExists()
    {
        foreach (var subMenu in _profilesSubMenus)
        {
            await _subMenuRepository.GetById(subMenu.SubMenuId);
        }
    }

    public void IsEmpty(List<ProfilesSubMenusInput> subMenus)
    {
        if (subMenus == null || subMenus.Count == 0)
        {
            throw new EntityValidationException("The profile must have at least one submenu");
        }
    }
}
