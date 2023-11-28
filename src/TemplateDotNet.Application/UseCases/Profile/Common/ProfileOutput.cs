using Entity = TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Application.UseCases.Profile.Common;
public class ProfileOutput
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<ProfilesSubMenusOutput> ProfilesSubMenus { get; private set; }

    public ProfileOutput(Guid id, string name, List<ProfilesSubMenusOutput> profilesSubMenus)
    {
        Id = id;
        Name = name;
        ProfilesSubMenus = profilesSubMenus;
    }

    public static ProfileOutput FromOutput(Entity.Profile profile)
        => new(
            profile.Id,
            profile.Name,
            ProfilesSubMenusOutput.FromOutput(profile.ProfilesSubMenus)
            );
}
