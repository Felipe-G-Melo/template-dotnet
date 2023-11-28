using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Profile.Common;
public class VerifyIfSubMenuExists
{
    private readonly ISubMenuRepository _subMenuRepository;
    private readonly List<ProfilesSubMenusInput> _profilesSubMenus;

    public VerifyIfSubMenuExists(ISubMenuRepository subMenuRepository, List<ProfilesSubMenusInput> profilesSubMenus)
    {
        _subMenuRepository = subMenuRepository;
        _profilesSubMenus = profilesSubMenus;
    }

    public async Task Handle()
    {
        foreach (var subMenu in _profilesSubMenus)
        {
            await _subMenuRepository.GetById(subMenu.SubMenuId);
        }
    }
}
