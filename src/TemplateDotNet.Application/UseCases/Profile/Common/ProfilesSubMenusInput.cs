namespace TemplateDotNet.Application.UseCases.Profile.Common;
public class ProfilesSubMenusInput
{
    public Guid SubMenuId { get; private set; }

    public ProfilesSubMenusInput(Guid subMenuId)
        => SubMenuId = subMenuId;
}
