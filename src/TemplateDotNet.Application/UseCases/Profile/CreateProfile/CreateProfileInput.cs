using TemplateDotNet.Application.UseCases.Profile.Common;

namespace TemplateDotNet.Application.UseCases.Profile.CreateProfile;
public class CreateProfileInput
{
    public string Name { get; private set; }
    public List<ProfilesSubMenusInput> ProfilesSubMenus { get; private set; }

    public CreateProfileInput(string name, List<ProfilesSubMenusInput> profilesSubMenus)
    {
        Name = name;
        ProfilesSubMenus = profilesSubMenus;
    }
}