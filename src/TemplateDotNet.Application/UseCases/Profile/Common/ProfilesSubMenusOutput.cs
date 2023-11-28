using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Application.UseCases.Profile.Common;
public class ProfilesSubMenusOutput
{
    public Guid SubMenuId { get; private set; }
    public Guid ProfileId { get; private set; }

    public ProfilesSubMenusOutput(Guid subMenuId, Guid profileId)
    {
        SubMenuId = subMenuId;
        ProfileId = profileId;
    }

    public static List<ProfilesSubMenusOutput> FromOutput(List<ProfilesSubMenus>? profilesSubMenus)
    {
        if(profilesSubMenus == null)
            return new List<ProfilesSubMenusOutput>();
        return profilesSubMenus.Select(x => new ProfilesSubMenusOutput(x.SubMenuId, x.ProfileId)).ToList();
    }
}
