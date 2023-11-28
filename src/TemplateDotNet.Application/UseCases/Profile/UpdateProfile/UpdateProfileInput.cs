using TemplateDotNet.Application.UseCases.Profile.Common;

namespace TemplateDotNet.Application.UseCases.Profile.UpdateProfile;
public class UpdateProfileInput
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<ProfilesSubMenusInput> ProfilesSubMenus { get; private set; }

    public UpdateProfileInput(
        Guid id,
        string name,
        List<ProfilesSubMenusInput> profilesSubMenus
    )
    {
        Id = id;
        Name = name;
        ProfilesSubMenus = profilesSubMenus;
    }
}
